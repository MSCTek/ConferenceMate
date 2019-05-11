using CGH.QuikRide.API.Client;
using CGH.QuikRide.API.Client.Interface;
using CGH.QuikRide.Service.DataService.Models;
using CGH.QuikRide.Xam;
using CodeGenHero.DataService;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using QuikRide.Helpers;
using QuikRide.Interfaces;
using QuikRide.Mappers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using static CGH.QuikRide.Service.DataService.Constants.Enums;
using dataModel = CGH.QuikRide.Xam.ModelData.QR;
using objModel = CGH.QuikRide.Xam.ModelObj.QR;

namespace QuikRide.Services
{
    public class DataRetrievalService : IDataRetrievalService
    {
        private static int MaxNumAttempts = 8;
        private IDatabase _db;
        private IWebApiDataServiceQR _webAPIDataService;

        public DataRetrievalService(IDatabase database)
        {
            _db = database;
            var webApiExecutionContextType = new QRWebApiExecutionContextType();
            webApiExecutionContextType.Current = (int)ExecutionContextTypes.Base;

            WebApiExecutionContext context = new WebApiExecutionContext(
                executionContextType: webApiExecutionContextType,
                baseWebApiUrl: Config.BaseWebApiUrl,
                baseFileUrl: string.Empty,
                connectionIdentifier: null);

            _webAPIDataService = new WebApiDataServiceQR(null, context);

            _currentUserId = 0;
        }

        public async Task<IList<objModel.FeedbackType>> GetAllFeedbackTypes()
        {
            var returnMe = new List<objModel.FeedbackType>();
            var dataResultsFeedbackTypes = await _db.GetAsyncConnection()
                .Table<dataModel.FeedbackType>()
                .ToListAsync();

            var dataResultsFeedbackLanguage = await _db.GetAsyncConnection()
                .Table<dataModel.FeedbackTypeTranslation>()
                .ToListAsync();

            //TODO: make this less ugly
            if (dataResultsFeedbackTypes.Any())
            {
                foreach (var d in dataResultsFeedbackTypes)
                {
                    var m = d.ToModelObj();
                    m.FeedbackTypeTranslations.Add(dataResultsFeedbackLanguage.Where(x => x.FeedbackTypeId == m.FeedbackTypeId && x.LanguageTypeId == 1).FirstOrDefault().ToModelObj());
                    returnMe.Add(m);
                }
            }
            return returnMe;
        }

        public async Task<List<ModelsObj.GeofenceActivity>> GetAllGeofenceActivity()
        {
            var returnMe = new List<ModelsObj.GeofenceActivity>();
            var dataResults = await _db.GetAsyncConnection()
                .Table<ModelsData.GeofenceActivity>()
                .OrderBy(x => x.ActivityUtcDateTime).ToListAsync();

            if (dataResults.Any())
            {
                foreach (var d in dataResults)
                {
                    returnMe.Add(d.ToModelObj());
                }
            }
            return returnMe;
        }

        public async Task<List<objModel.Location>> GetAllLocations()
        {
            var returnMe = new List<objModel.Location>();
            var dataResults = await _db.GetAsyncConnection()
                .Table<dataModel.Location>()
                .OrderBy(x => x.Name).ToListAsync();

            if (dataResults.Any())
            {
                foreach (var d in dataResults)
                {
                    returnMe.Add(d.ToModelObj());
                }
            }
            return returnMe;
        }

        public async Task<List<objModel.User>> GetAllUsers()
        {
            var returnMe = new List<objModel.User>();
            var dataResults = await _db.GetAsyncConnection()
                .Table<dataModel.User>()
                .ToListAsync();

            if (dataResults.Any())
            {
                foreach (var d in dataResults)
                {
                    returnMe.Add(d.ToModelObj());
                }
            }
            return returnMe;
        }

        public async Task<IList<objModel.Vehicle>> GetAllVehicles()
        {
            var returnMe = new List<objModel.Vehicle>();
            var dataResults = await _db.GetAsyncConnection()
                .Table<dataModel.Vehicle>()
                .OrderBy(x => x.LicensePlateNumber).ToListAsync();

            if (dataResults.Any())
            {
                foreach (var d in dataResults)
                {
                    returnMe.Add(d.ToModelObj());
                }
            }
            return returnMe;
        }

        public async Task<List<ModelsObj.GeofenceActivity>> GetRecentGeofenceActivity(int numRecords)
        {
            var returnMe = new List<ModelsObj.GeofenceActivity>();
            var dataResults = await _db.GetAsyncConnection()
                .Table<ModelsData.GeofenceActivity>()
                .OrderByDescending(x => x.ActivityUtcDateTime)
                .Take(numRecords)
                .ToListAsync();

            if (dataResults.Any())
            {
                foreach (var d in dataResults)
                {
                    returnMe.Add(d.ToModelObj());
                }
            }
            return returnMe;
        }

        public async Task<int> WriteBarcodeScanRecord(dataModel.BarcodeScanLog logRecord)
        {
            return await _db.GetAsyncConnection().InsertAsync(logRecord);
        }

        public async Task<int> WriteFeedbackRecord(dataModel.Feedback feedback)
        {
            return await _db.GetAsyncConnection().InsertAsync(feedback);
        }

        public async Task<int> WriteGeofencingActivityRecord(ModelsData.GeofenceActivity geofenceActivity)
        {
            return await _db.GetAsyncConnection().InsertAsync(geofenceActivity);
        }

        #region CurrentUser

        private int _currentUserId;

        public int GetCurrentUserId()
        {
            return _currentUserId;
        }

        public void SetCurrentUserId(int id)
        {
            _currentUserId = id;
        }

        #endregion CurrentUser

        #region QueuedUpdates

        //How many are queued, failed > MaxNumAttempts times?
        public async Task<int> GetCountQueuedRecordsWAttemptsAsync()
        {
            var count = await _db.GetAsyncConnection().Table<QuikRide.ModelsData.Queue>().Where(x => x.Success == false && x.NumAttempts > MaxNumAttempts).CountAsync();
            if (count > 0)
            {
                //sending a message to AppCenter right away with user info
                var dict = new Dictionary<string, string>
                    {
                       { "userId", GetCurrentUserId().ToString() },
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
                ModelsData.Queue queue = new ModelsData.Queue()
                {
                    RecordId = recordId,
                    QueueableObject = objName.ToString(),
                    DateQueued = DateTime.UtcNow,
                    NumAttempts = 0,
                    Success = false
                };

                int count = await _db.GetAsyncConnection().InsertOrReplaceAsync(queue);

                Debug.WriteLine($"Queued {recordId} of type {objName}");
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
                Debug.WriteLine($"Error in {nameof(QueueAsync)}");
            }
        }

        //run the oldest 10 updates in the SQLite database that haven't had more than MaxNumAttempts retries
        public async Task RunQueuedUpdatesAsync(CancellationToken cts)
        {
            try
            {
                //Take the oldest 10 records off the queue and only take records that haven't had more than MaxNumAttempts retries
                var queue = await _db.GetAsyncConnection().Table<ModelsData.Queue>().Where(x => x.Success == false && x.NumAttempts <= MaxNumAttempts).OrderBy(s => s.DateQueued).Take(10).ToListAsync();

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
                            await _db.GetAsyncConnection().UpdateAsync(q);
                        }
                        else
                        {
                            q.NumAttempts += 1;
                            await _db.GetAsyncConnection().UpdateAsync(q);
                        }
                    }
                    else if (q.QueueableObject == QueueableObjects.BarcodeScanLog.ToString())
                    {
                        if (await RunQueuedBarcodeScanLogCreate(q))
                        {
                            q.NumAttempts += 1;
                            q.Success = true;
                            await _db.GetAsyncConnection().UpdateAsync(q);
                        }
                        else
                        {
                            q.NumAttempts += 1;
                            await _db.GetAsyncConnection().UpdateAsync(q);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
            }
        }

        public void StartSafeQueuedUpdates()
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet) MessagingCenter.Send<StartUploadDataMessage>(new StartUploadDataMessage(), "StartUploadDataMessage");
        }

        private async Task<bool> RunQueuedBarcodeScanLogCreate(ModelsData.Queue q)
        {
            if (_webAPIDataService == null) { return false; }

            var record = await _db.GetAsyncConnection().Table<dataModel.BarcodeScanLog>().Where(x => x.BarcodeScanLogId == q.RecordId).FirstOrDefaultAsync();
            if (record != null)
            {
                var result = await _webAPIDataService.CreateBarcodeScanLogAsync(record.ToDto());
                if (result.IsSuccessStatusCode)
                {
                    Debug.WriteLine($"Successfully Sent Queued BarcodeScanLog Record");
                    return true;
                }
                else if (result.StatusCode == System.Net.HttpStatusCode.Conflict)
                {
                    Analytics.TrackEvent($"Conflict Sending Queued BarcodeScanLog record {q.RecordId}");
                }
                Analytics.TrackEvent($"Error Sending Queued BarcodeScanLog record {q.RecordId}");
                return false;
            }
            return false;
        }

        private async Task<bool> RunQueuedFeedbackCreate(ModelsData.Queue q)
        {
            if (_webAPIDataService == null) { return false; }

            var record = await _db.GetAsyncConnection().Table<dataModel.Feedback>().Where(x => x.FeedbackId == q.RecordId).FirstOrDefaultAsync();
            if (record != null)
            {
                var result = await _webAPIDataService.CreateFeedbackAsync(record.ToDto());
                if (result.IsSuccessStatusCode)
                {
                    Debug.WriteLine($"Successfully Sent Queued Feedback Record");
                    return true;
                }
                else if (result.StatusCode == System.Net.HttpStatusCode.Conflict)
                {
                    Analytics.TrackEvent($"Conflict Sending Queued Feedback record {q.RecordId}");
                }
                Analytics.TrackEvent($"Error Sending Queued Feedback record {q.RecordId}");
                return false;
            }
            return false;
        }

        #endregion QueuedUpdates
    }
}