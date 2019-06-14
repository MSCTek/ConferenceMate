using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.Extensions.Logging;
using MSC.CM.Xam;
using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using dataModel = MSC.CM.Xam.ModelData.CM;
using objModel = MSC.CM.Xam.ModelObj.CM;

namespace MSC.CM.XaSh.Services
{
	public class SQLiteDataStore : IDataStore
	{
		private SQLiteAsyncConnection conn = App.Database.conn;
		private ILogger<SQLiteDataStore> logger;

		//TODO: PAUL to take advantage of this goodness, wire up the CGH httpclient to use the transient http error policy
		//private HttpClient client;
		//public AzureDataStore(ILogger<AzureDataStore> _logger = null, IHttpClientFactory _httpClientFactory = null)
		public SQLiteDataStore(ILogger<SQLiteDataStore> _logger = null)
		{
			logger = _logger;
			//client = _httpClientFactory == null ? new HttpClient() : _httpClientFactory.CreateClient("AzureWebsites");

			//if (_httpClientFactory == null)
			//    client.BaseAddress = new Uri($"{App.AzureBackendUrl}/");
		}

		private bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;

		public async Task<IEnumerable<objModel.Announcement>> GetAnnouncementsAsync()
		{
			var returnMe = new List<objModel.Announcement>();
			var dataResults = await conn.Table<dataModel.Announcement>()
				.OrderBy(x => x.ModifiedUtcDate).ToListAsync();

			if (dataResults.Any())
			{
				foreach (var d in dataResults)
				{
					returnMe.Add(d.ToModelObj());
				}
			}
			return returnMe;
		}

		public async Task<IEnumerable<objModel.Session>> GetFavoriteSessionsAsync()
		{
			//includes session and user data
			var returnMe = new List<objModel.Session>();
			var dataResults = await conn.Table<dataModel.SessionLike>().Where(x => x.IsDeleted == false).ToListAsync();
			int currentUserId = Preferences.Get(App.CURRENT_USER_ID, 0);

			if (dataResults.Any())
			{
				foreach (var d in dataResults)
				{
					//var sessionObjMod = d.ToModelObj();
					var sessionDataMod = await conn.Table<dataModel.Session>().Where(x => x.SessionId == d.SessionId && d.UserId == currentUserId).FirstOrDefaultAsync();
					if (sessionDataMod != null)
					{
						var sessionObjMod = sessionDataMod.ToModelObj();
						var sessionSpeakers = await conn.Table<dataModel.SessionSpeaker>()
							.Where(x => x.SessionId == d.SessionId).ToListAsync();
						foreach (var s in sessionSpeakers)
						{
							var speaker = s.ToModelObj();
							var user = await conn.Table<dataModel.User>()
								.Where(x => x.UserId == s.UserId).FirstOrDefaultAsync();
							speaker.User = user != null ? user.ToModelObj() : null;

							sessionObjMod.SessionSpeakers.Add(speaker);
						}
						var sessionLikes = await conn.Table<dataModel.SessionLike>()
						.Where(x => x.SessionId == d.SessionId && x.UserId == currentUserId && x.IsDeleted == false).ToListAsync();
						foreach (var s in sessionLikes)
						{
							sessionObjMod.SessionLikes.Add(s.ToModelObj());
						}
						returnMe.Add(sessionObjMod);
					}
				}
			}
			return returnMe;
		}

		public async Task<IEnumerable<objModel.FeedbackType>> GetFeedbackTypesAsync()
		{
			//includes session and user data
			var returnMe = new List<objModel.FeedbackType>();
			var dataResults = await conn.Table<dataModel.FeedbackType>().ToListAsync();

			if (dataResults.Any())
			{
				foreach (var d in dataResults)
				{
					returnMe.Add(d.ToModelObj());
				}
			}
			return returnMe;
		}

		public async Task<IEnumerable<objModel.Session>> GetSessionsAsync()
		{
			//includes session, speaker and favorite data
			var returnMe = new List<objModel.Session>();
			var dataResults = await conn.Table<dataModel.Session>().ToListAsync();
			int currentUserId = Preferences.Get(App.CURRENT_USER_ID, 0);
			if (dataResults.Any())
			{
				foreach (var d in dataResults)
				{
					var sessionObjMod = d.ToModelObj();
					var sessionSpeakers = await conn.Table<dataModel.SessionSpeaker>()
						.Where(x => x.SessionId == d.SessionId).ToListAsync();
					foreach (var s in sessionSpeakers)
					{
						var speaker = s.ToModelObj();
						var user = await conn.Table<dataModel.User>()
							.Where(x => x.UserId == s.UserId).FirstOrDefaultAsync();
						speaker.User = user != null ? user.ToModelObj() : null;

						sessionObjMod.SessionSpeakers.Add(speaker);
					}
					var sessionLikes = await conn.Table<dataModel.SessionLike>()
						.Where(x => x.SessionId == d.SessionId && x.UserId == currentUserId && x.IsDeleted == false).ToListAsync();
					foreach (var s in sessionLikes)
					{
						sessionObjMod.SessionLikes.Add(s.ToModelObj());
					}
					returnMe.Add(sessionObjMod);
				}
			}
			return returnMe;
		}

		public async Task<IEnumerable<objModel.User>> GetSpeakersAsync()
		{
			//includes session and user data
			var returnMe = new List<objModel.User>();

			//TODO: fix this
			//var dataResults = await conn.Table<dataModel.SessionSpeaker>().ToListAsync();
			//IEnumerable<int> dataResults = await conn.QueryAsync<int>("select distinct UserId from SessionSpeaker");
			//IEnumerable<int> dataResults = await conn.QueryAsync<int>("select UserId from SessionSpeaker");
			List<int> dataResults = (await conn.Table<dataModel.SessionSpeaker>().ToListAsync()).Select(x => x.UserId).Distinct().ToList();

			if (dataResults.Any())
			{
				foreach (var userId in dataResults)
				{
					var user = await conn.Table<dataModel.User>()
					   .Where(x => x.UserId == userId).FirstOrDefaultAsync();
					if (user != null)
					{
						returnMe.Add(user.ToModelObj());
					}
				}
			}
			return returnMe;
		}

		public async Task<objModel.User> GetUserByIdAsync(int userId)
		{
			var dataResult = await conn.Table<dataModel.User>().Where(x => x.UserId == userId).FirstOrDefaultAsync();
			return (dataResult != null) ? dataResult.ToModelObj() : null;
		}

		public async Task SetSessionLikeAsync(int sessionId, bool value)
		{
			int currentUserId = Preferences.Get(App.CURRENT_USER_ID, 0);
			var dataResult = await conn.Table<dataModel.SessionLike>().Where(x => x.SessionId == sessionId && x.UserId == currentUserId && x.IsDeleted == false).FirstOrDefaultAsync();
			if (dataResult != null)
			{   // Data record was previously created.
				dataResult.IsDeleted = !value;
				dataResult.ModifiedUtcDate = DateTime.UtcNow;

				await conn.InsertOrReplaceAsync(dataResult);
			}
			else
			{   // Create new data record.
				if (Preferences.Get(App.CURRENT_USER_ID, 0) != 0)
				{
					var user = await GetUserByIdAsync(Preferences.Get(App.CURRENT_USER_ID, 0));
					if (user != null)
					{
						dataResult = new dataModel.SessionLike()
						{
							CreatedBy = user.UserName,
							CreatedUtcDate = DateTime.UtcNow,
							DataVersion = 1,
							IsDeleted = !value,
							ModifiedBy = user.UserName,
							ModifiedUtcDate = DateTime.UtcNow,
							UserId = user.UserId,
							SessionId = sessionId,
							SessionLikeId = Guid.NewGuid()
						};
						await conn.InsertAsync(dataResult);
					}
					else
					{
						Debug.WriteLine("Can't find user in SQLite");
						Analytics.TrackEvent($"SetSessionLikeAsync - Can't find user in SQLite - id: {Preferences.Get(App.CURRENT_USER_ID, 0)}");
					}
				}
				else
				{
					Debug.WriteLine("No User Logged In");
					Analytics.TrackEvent($"SetSessionLikeAsync - No user is logged in");
				}
			}
		}

		public async Task<bool> ToggleSessionLikeAsync(int sessionId)
		{
			var dataResult = await conn.Table<dataModel.SessionLike>().Where(x => x.SessionId == sessionId).FirstOrDefaultAsync();
			if (dataResult != null)
			{   // Data record was previously created.
				dataResult.IsDeleted = !dataResult.IsDeleted;
				dataResult.ModifiedUtcDate = DateTime.UtcNow;

				return (1 == await conn.InsertOrReplaceAsync(dataResult));
			}
			else
			{   // Create new data record.
				if (Preferences.Get(App.CURRENT_USER_ID, 0) != 0)
				{
					var user = await GetUserByIdAsync(Preferences.Get(App.CURRENT_USER_ID, 0));
					if (user != null)
					{
						dataResult = new dataModel.SessionLike()
						{
							CreatedBy = user.UserName,
							CreatedUtcDate = DateTime.UtcNow,
							DataVersion = 1,
							IsDeleted = false,
							ModifiedBy = user.UserName,
							ModifiedUtcDate = DateTime.UtcNow,
							UserId = user.UserId,
							SessionId = sessionId,
							SessionLikeId = Guid.NewGuid()
						};
						return (1 == await conn.InsertAsync(dataResult));
					}
					else
					{
						Debug.WriteLine("Can't find user in SQLite");
						Analytics.TrackEvent($"SetSessionLikeAsync - Can't find user in SQLite - id: {Preferences.Get(App.CURRENT_USER_ID, 0)}");
					}
				}
				else
				{
					Debug.WriteLine("No User Logged In");
					Analytics.TrackEvent($"SetSessionLikeAsync - No user is logged in");
				}
			}
			return false;
		}

		public async Task<int> UpdateUserRecord(dataModel.User editedCurrentUser)
		{
			return await conn.UpdateAsync(editedCurrentUser);
		}

		public async Task<int> WriteFeedbackRecord(dataModel.Feedback feedbackData)
		{
			return await conn.InsertAsync(feedbackData);
		}
	}
}