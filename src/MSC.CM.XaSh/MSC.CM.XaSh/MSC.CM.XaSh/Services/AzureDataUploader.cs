﻿using CodeGenHero.DataService;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.Extensions.Logging;
using MSC.CM.Xam;
using MSC.CM.Xam.ModelData.CM;
using MSC.CM.XaSh.MobileModelData;
using MSC.ConferenceMate.API.Client;
using MSC.ConferenceMate.API.Client.Interface;
using MSC.ConferenceMate.DataService.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using static MSC.ConferenceMate.DataService.Constants.Enums;

namespace MSC.CM.XaSh.Services
{
	public enum QueueableObjects
	{
		Favorite,
		Feedback,
		Chat,
		Bingo,
		Note,
		UserProfileUpdate
	}

	public class AzureDataUploader : IDataUploader
	{
		//TODO: maybe move this to appsettings.json
		private static int MaxNumAttempts = 8;

		//TODO: maybe move this to appsettings.json
		private static int MaxNumUploadBatch = 10;

		private HttpClient _client;

		private ILogger<AzureDataLoader> _logger;
		private SQLiteAsyncConnection conn = App.Database.conn;
		private IWebApiDataServiceCM webAPIDataService;

		//public AzureDataLoader(ILogger<AzureDataStore> _logger = null, IHttpClientFactory _httpClientFactory = null)
		public AzureDataUploader(IHttpClientFactory httpClientFactory = null, ILogger<AzureDataLoader> logger = null)
		{
			_logger = logger;
			_client = httpClientFactory == null ? new HttpClient() : httpClientFactory.CreateClient("BackEndAPI");

			//if (_httpClientFactory == null)
			//    client.BaseAddress = new Uri($"{App.AzureBackendUrl}/");

			//var webApiExecutionContextType = new CMWebApiExecutionContextType();
			//webApiExecutionContextType.Current = (int)ExecutionContextTypes.Base;

			//WebApiExecutionContext context = new WebApiExecutionContext(
			//	executionContextType: webApiExecutionContextType,
			//	baseWebApiUrl: App.AzureBackendUrl,
			//	baseFileUrl: string.Empty,
			//	connectionIdentifier: null);

			webAPIDataService = new WebApiDataServiceCM(null, _client);
		}

		//How many are queued, failed > MaxNumAttempts times?
		public async Task<int> GetCountQueuedRecordsWAttemptsAsync()
		{
			var count = await conn.Table<UploadQueue>().Where(x => x.Success == false && x.NumAttempts > MaxNumAttempts).CountAsync();
			if (count > 0)
			{
				//sending a message to AppCenter right away with user info
				var dict = new Dictionary<string, string>
					{
					   { "userId", Preferences.Get(App.CURRENT_USER_ID, 0).ToString() },
					   { "recordCount", count.ToString() },
					   { "maxNumAttempts", MaxNumAttempts.ToString() },
					};
				Analytics.TrackEvent($"ERROR: Too Many Failed Queue Attempts", dict);
			}
			return count;
		}

		//queue a record in SQLite
		public async Task QueueAsync(Guid recordId, QueueableObjects objName)
		{
			try
			{
				UploadQueue queue = new UploadQueue()
				{
					UploadQueueId = Guid.NewGuid(),
					RecordIdGuid = recordId,
					RecordIdInt = null,
					QueueableObject = objName.ToString(),
					DateQueued = DateTime.UtcNow,
					NumAttempts = 0,
					Success = false
				};

				int count = await conn.InsertOrReplaceAsync(queue);

				Debug.WriteLine($"Queued {recordId} of type {objName}");
			}
			catch (Exception ex)
			{
				Crashes.TrackError(ex);
				Debug.WriteLine($"Error in {nameof(QueueAsync)}");
			}
		}

		public async Task QueueAsync(int recordId, QueueableObjects objName)
		{
			try
			{
				UploadQueue queue = new UploadQueue()
				{
					UploadQueueId = Guid.NewGuid(),
					RecordIdGuid = null,
					RecordIdInt = recordId,
					QueueableObject = objName.ToString(),
					DateQueued = DateTime.UtcNow,
					NumAttempts = 0,
					Success = false
				};

				int count = await conn.InsertOrReplaceAsync(queue);

				Debug.WriteLine($"Queued {recordId} of type {objName}");
			}
			catch (Exception ex)
			{
				Crashes.TrackError(ex);
				Debug.WriteLine($"Error in {nameof(QueueAsync)}");
			}
		}

		public async Task StartQueuedUpdatesAsync(CancellationToken token)
		{
			if (conn == null)
			{
				Debug.WriteLine("FATAL: DataUploader has no access to the Database");
				Crashes.TrackError(new Exception("FATAL: DataUploader has no access to the Database"));
				return;
			}

			if (Connectivity.NetworkAccess == NetworkAccess.Internet)
			{
				await RunQueuedUpdatesAsync(token);
			}
			else
			{
				Debug.WriteLine($"No connectivity - RunQueuedUpdatesAsync cannot run");
			}
		}

		public void StartSafeQueuedUpdates()
		{
			if (Connectivity.NetworkAccess == NetworkAccess.Internet) MessagingCenter.Send<StartUploadDataMessage>(new StartUploadDataMessage(), "StartUploadDataMessage");
		}

		private async Task<bool> RunQueuedFeedbackCreate(UploadQueue q)
		{
			if (webAPIDataService == null) { Analytics.TrackEvent("FATAL: RunQueuedFeedbackCreate webAPIDataService == null"); return false; }

			var record = await conn.Table<Feedback>().Where(x => x.FeedbackId == q.RecordIdGuid).FirstOrDefaultAsync();
			if (record != null)
			{
				var result = await webAPIDataService.CreateFeedbackAsync(record.ToDto());
				if (result.IsSuccessStatusCode)
				{
					Debug.WriteLine($"Successfully Sent Queued Feedback Record");
					return true;
				}
				else if (result.StatusCode == System.Net.HttpStatusCode.Conflict)
				{
					Analytics.TrackEvent($"Conflict Sending Queued Feedback record {q.RecordIdGuid}");
				}
				Analytics.TrackEvent($"Error Sending Queued Feedback record {q.RecordIdGuid}");
				return false;
			}
			return false;
		}

		//run the oldest 10 updates in the SQLite database that haven't had more than MaxNumAttempts retries
		private async Task RunQueuedUpdatesAsync(CancellationToken cts)
		{
			try
			{
				//Take the oldest {MaxNumUploadBatch} records off the queue and only take records that haven't had more than MaxNumAttempts retries
				var queue = await conn.Table<UploadQueue>().Where(x => x.Success == false && x.NumAttempts <= MaxNumAttempts).OrderBy(s => s.DateQueued).Take(MaxNumUploadBatch).ToListAsync();

				Debug.WriteLine($"Running {queue.Count()} Queued Updates");

				foreach (var q in queue)
				{
					//if the system or the user has requested that the process is cancelled, then we need to stop and end gracefully.
					if (cts.IsCancellationRequested)
					{
						break;
					}

					if (q.QueueableObject == QueueableObjects.Feedback.ToString())
					{
						if (await RunQueuedFeedbackCreate(q))
						{
							q.NumAttempts += 1;
							q.Success = true;
							await conn.UpdateAsync(q);
						}
						else
						{
							q.NumAttempts += 1;
							await conn.UpdateAsync(q);
						}
					}
					else if (q.QueueableObject == QueueableObjects.UserProfileUpdate.ToString())
					{
						if (await RunQueuedUserProfileUpdate(q))
						{
							q.NumAttempts += 1;
							q.Success = true;
							await conn.UpdateAsync(q);
						}
						else
						{
							q.NumAttempts += 1;
							await conn.UpdateAsync(q);
						}
					}
				}
			}
			catch (Exception ex)
			{
				Crashes.TrackError(ex);
			}
		}

		private async Task<bool> RunQueuedUserProfileUpdate(UploadQueue q)
		{
			if (webAPIDataService == null) { Analytics.TrackEvent("FATAL: RunQueuedUserProfileUpdate webAPIDataService == null"); return false; }

			var record = await conn.Table<UserProfile>().Where(x => x.UserProfileId == q.RecordIdInt).FirstOrDefaultAsync();
			if (record != null)
			{
				var result = await webAPIDataService.UpdateUserProfileAsync(record.ToDto());
				if (result.IsSuccessStatusCode)
				{
					Debug.WriteLine($"Successfully Sent Queued User Record");
					return true;
				}
				else if (result.StatusCode == System.Net.HttpStatusCode.Conflict)
				{
					Analytics.TrackEvent($"Conflict Sending Queued User record {q.RecordIdInt}");
				}
				Analytics.TrackEvent($"Error Sending Queued User record {q.RecordIdInt}");
				return false;
			}
			return false;
		}
	}

	#region Messages

	public class CancelledMessage
	{
	}

	public class StartUploadDataMessage
	{
	}

	public class StopUploadDataMessage
	{
	}

	#endregion Messages
}