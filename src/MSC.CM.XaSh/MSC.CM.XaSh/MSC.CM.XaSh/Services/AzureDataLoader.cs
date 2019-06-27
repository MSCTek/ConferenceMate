using CodeGenHero.DataService;
using Microsoft.AppCenter.Crashes;
using Microsoft.Extensions.Logging;
using MSC.CM.Xam;
using MSC.CM.Xam.ModelData.CM;
using MSC.CM.XaSh.Helpers;
using MSC.ConferenceMate.API.Client;
using MSC.ConferenceMate.API.Client.Interface;
using MSC.ConferenceMate.DataService.Models;
using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using static MSC.ConferenceMate.DataService.Constants.Enums;

namespace MSC.CM.XaSh.Services
{
    public class AzureDataLoader : IDataLoader
    {
        private const int MAX_MINUTES_BETWEEN_UPDATES = 10;

        private HttpClient _client;
        private IHttpClientFactory _httpClientFactory;
        private ILogger<AzureDataLoader> _logger;
        private SQLiteAsyncConnection conn = App.Database.conn;
        private IWebApiDataServiceCM webAPIDataService;

        //public AzureDataLoader(ILogger<AzureDataStore> _logger = null, IHttpClientFactory _httpClientFactory = null)
        public AzureDataLoader(IHttpClientFactory httpClientFactory = null, ILogger<AzureDataLoader> logger = null)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            _client = _httpClientFactory == null ? new HttpClient() : _httpClientFactory.CreateClient("BackEndAPI");

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

        public enum UpdateableTableNames
        {
            User,
            Session,
            SessionLike,
            SessionSpeaker
        }

        private bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;

        public async Task<bool> GetAuthToken(string user, string pass)
        {
            try
            {
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("grant_type", "password"),
                    new KeyValuePair<string, string>("username", user),
                    new KeyValuePair<string, string>("password", pass)
                });
                var result = await _client.PostAsync("/api/token ", content);

                if (result.IsSuccessStatusCode)
                {
                    var resultContent = JsonConvert.DeserializeObject<AuthenticationResult>(await result.Content.ReadAsStringAsync());
                    //AuthenticationHeaderValue auth = new AuthenticationHeaderValue("bearer", resultContent.access_token);
                    //_client.DefaultRequestHeaders.Add(auth);

                    App.Token = resultContent.access_token;
                    _client = _httpClientFactory == null ? new HttpClient() : _httpClientFactory.CreateClient("BackEndAPI");
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
                Crashes.TrackError(ex);
                return false;
            }
        }

        public async Task<bool> HeartbeatCheck()
        {
            try
            {
                Debug.WriteLine("Heartbeat Check");
                return await webAPIDataService.IsServiceOnlineAsync();
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
                return false;
            }
        }

        public async Task<int> LoadAnnouncementsAsync(bool forceRefresh = false)
        {
            try
            {
                DateTime? lastUpdatedDate = null;
                if (!forceRefresh)
                {
                    if (await conn.Table<Announcement>().CountAsync() > 0)
                    {
                        var lastUpdated = await conn.Table<Announcement>().OrderByDescending(x => x.ModifiedUtcDate).FirstAsync();
                        lastUpdatedDate = lastUpdated != null ? lastUpdated?.ModifiedUtcDate : null;
                    }
                }
                else
                {
                    //truncate the table
                    await conn.Table<Announcement>().DeleteAsync();
                }
                var dtos = await webAPIDataService.GetAllPagesAnnouncementsAsync(lastUpdatedDate);
                int count = 0;
                if (dtos.Any())
                {
                    foreach (var r in dtos)
                    {
                        count += await conn.InsertOrReplaceAsync(r.ToModelData());
                    }
                    return count;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
                return 0;
            }
        }

        public async Task<int> LoadFeedbackInitiatorTypesAsync(bool forceRefresh = false)
        {
            try
            {
                DateTime? lastUpdatedDate = null;
                if (!forceRefresh)
                {
                    if (await conn.Table<FeedbackInitiatorType>().CountAsync() > 0)
                    {
                        var lastUpdated = await conn.Table<FeedbackInitiatorType>().OrderByDescending(x => x.ModifiedUtcDate).FirstAsync();
                        lastUpdatedDate = lastUpdated != null ? lastUpdated?.ModifiedUtcDate : null;
                    }
                }
                else
                {
                    //truncate the table
                    await conn.Table<FeedbackInitiatorType>().DeleteAsync();
                }
                var dtos = await webAPIDataService.GetAllPagesFeedbackInitiatorTypesAsync(lastUpdatedDate);
                int count = 0;
                if (dtos.Any())
                {
                    foreach (var r in dtos)
                    {
                        count += await conn.InsertOrReplaceAsync(r.ToModelData());
                    }
                    return count;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
                return 0;
            }
        }

        public async Task<int> LoadFeedbackTypesAsync(bool forceRefresh = false)
        {
            try
            {
                DateTime? lastUpdatedDate = null;
                if (!forceRefresh)
                {
                    if (await conn.Table<FeedbackType>().CountAsync() > 0)
                    {
                        var lastUpdated = await conn.Table<FeedbackType>().OrderByDescending(x => x.ModifiedUtcDate).FirstAsync();
                        lastUpdatedDate = lastUpdated != null ? lastUpdated?.ModifiedUtcDate : null;
                    }
                }
                else
                {
                    //truncate the table
                    await conn.Table<FeedbackType>().DeleteAsync();
                }
                var dtos = await webAPIDataService.GetAllPagesFeedbackTypesAsync(lastUpdatedDate);
                int count = 0;
                if (dtos.Any())
                {
                    foreach (var r in dtos)
                    {
                        count += await conn.InsertOrReplaceAsync(r.ToModelData());
                    }
                    return count;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
                return 0;
            }
        }

        public async Task<int> LoadRoomsAsync(bool forceRefresh = false)
        {
            try
            {
                DateTime? lastUpdatedDate = null;
                if (!forceRefresh)
                {
                    if (await conn.Table<Room>().CountAsync() > 0)
                    {
                        var lastUpdated = await conn.Table<Room>().OrderByDescending(x => x.ModifiedUtcDate).FirstAsync();
                        lastUpdatedDate = lastUpdated != null ? lastUpdated?.ModifiedUtcDate : null;
                    }
                }
                else
                {
                    //truncate the table
                    await conn.Table<Room>().DeleteAsync();
                }
                var dtos = await webAPIDataService.GetAllPagesRoomsAsync(lastUpdatedDate);
                int count = 0;
                if (dtos.Any())
                {
                    foreach (var r in dtos)
                    {
                        count += await conn.InsertOrReplaceAsync(r.ToModelData());
                    }
                    return count;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
                return 0;
            }
        }

        public async Task<int> LoadSessionLikesAsync(bool forceRefresh = false)
        {
            try
            {
                if (await NeedsDataRefresh(UpdateableTableNames.SessionLike))
                {
                    DateTime? lastUpdatedDate = null;
                    if (!forceRefresh)
                    {
                        if (await conn.Table<SessionLike>().CountAsync() > 0)
                        {
                            var lastUpdated = await conn.Table<SessionLike>().OrderByDescending(x => x.ModifiedUtcDate).FirstAsync();
                            lastUpdatedDate = lastUpdated != null ? lastUpdated?.ModifiedUtcDate : null;
                        }
                    }
                    else
                    {
                        //truncate the table
                        await conn.Table<SessionLike>().DeleteAsync();
                    }
                    var dtos = await webAPIDataService.GetAllPagesSessionLikesAsync(lastUpdatedDate);
                    int count = 0;
                    if (dtos.Any())
                    {
                        foreach (var r in dtos)
                        {
                            count += await conn.InsertOrReplaceAsync(r.ToModelData());
                        }
                        SetLastUpdatedNow(UpdateableTableNames.SessionLike);
                        return count;
                    }
                    else
                    {
                        return 0;
                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
                return 0;
            }
        }

        public async Task<int> LoadSessionsAsync(bool forceRefresh = false)
        {
            try
            {
                if (await NeedsDataRefresh(UpdateableTableNames.Session))
                {
                    DateTime? lastUpdatedDate = null;
                    if (!forceRefresh)
                    {
                        if (await conn.Table<Session>().CountAsync() > 0)
                        {
                            var lastUpdated = await conn.Table<Session>().OrderByDescending(x => x.ModifiedUtcDate).FirstAsync();
                            lastUpdatedDate = lastUpdated != null ? lastUpdated?.ModifiedUtcDate : null;
                        }
                    }
                    else
                    {
                        //truncate the table
                        await conn.Table<Session>().DeleteAsync();
                    }
                    var dtos = await webAPIDataService.GetAllPagesSessionsAsync(lastUpdatedDate);
                    int count = 0;
                    if (dtos.Any())
                    {
                        foreach (var r in dtos)
                        {
                            count += await conn.InsertOrReplaceAsync(r.ToModelData());
                        }
                        SetLastUpdatedNow(UpdateableTableNames.Session);
                        return count;
                    }
                    else
                    {
                        return 0;
                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
                return 0;
            }
        }

        public async Task<int> LoadSessionSpeakersAsync(bool forceRefresh = false)
        {
            try
            {
                if (await NeedsDataRefresh(UpdateableTableNames.SessionSpeaker))
                {
                    DateTime? lastUpdatedDate = null;
                    if (!forceRefresh)
                    {
                        if (await conn.Table<SessionSpeaker>().CountAsync() > 0)
                        {
                            var lastUpdated = await conn.Table<SessionSpeaker>().OrderByDescending(x => x.ModifiedUtcDate).FirstAsync();
                            lastUpdatedDate = lastUpdated != null ? lastUpdated?.ModifiedUtcDate : null;
                        }
                    }
                    else
                    {
                        //truncate the table
                        await conn.Table<SessionSpeaker>().DeleteAsync();
                    }
                    var dtos = await webAPIDataService.GetAllPagesSessionSpeakersAsync(lastUpdatedDate);
                    int count = 0;
                    if (dtos.Any())
                    {
                        foreach (var r in dtos)
                        {
                            count += await conn.InsertOrReplaceAsync(r.ToModelData());
                        }
                        SetLastUpdatedNow(UpdateableTableNames.SessionSpeaker);
                        return count;
                    }
                    else
                    {
                        return 0;
                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
                return 0;
            }
        }

        public async Task<int> LoadUsersAsync(bool forceRefresh = false)
        {
            try
            {
                if (await NeedsDataRefresh(UpdateableTableNames.User))
                {
                    DateTime? lastUpdatedDate = null;
                    if (!forceRefresh)
                    {
                        if (await conn.Table<UserProfile>().CountAsync() > 0)
                        {
                            var lastUpdated = await conn.Table<UserProfile>().OrderByDescending(x => x.ModifiedUtcDate).FirstAsync();
                            lastUpdatedDate = lastUpdated != null ? lastUpdated?.ModifiedUtcDate : null;
                        }
                    }
                    else
                    {
                        //truncate the table
                        await conn.Table<UserProfile>().DeleteAsync();
                    }
                    var dtos = await webAPIDataService.GetAllPagesUserProfilesAsync(lastUpdatedDate);
                    int count = 0;
                    if (dtos.Any())
                    {
                        foreach (var r in dtos)
                        {
                            count += await conn.InsertOrReplaceAsync(r.ToModelData());
                        }
                        SetLastUpdatedNow(UpdateableTableNames.User);
                        return count;
                    }
                    else
                    {
                        return 0;
                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
                return 0;
            }
        }

        private async Task<bool> NeedsDataRefresh(UpdateableTableNames updateableTableName)
        {
            string tableName = updateableTableName.ToString();
            var record = await conn.Table<MobileModelData.LastUpdated>().Where(x => x.TableName == tableName).FirstOrDefaultAsync();
            if (record != null)
            {
                return (record.LastUpdatedUTC < DateTime.UtcNow.AddMinutes(MAX_MINUTES_BETWEEN_UPDATES)) ? true : false;
            }
            return true;
        }

        private async Task<bool> SetLastUpdatedNow(UpdateableTableNames updateableTableName)
        {
            return 1 == await conn.InsertOrReplaceAsync(new MobileModelData.LastUpdated() { TableName = updateableTableName.ToString(), LastUpdatedUTC = DateTime.UtcNow });
        }
    }
}