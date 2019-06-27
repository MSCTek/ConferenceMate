using CodeGenHero.DataService;
using Microsoft.AppCenter.Analytics;
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
    public class AzureDataLoader : AzureDataLoaderBase, IDataLoader
    {
        private const int MAX_MINUTES_BETWEEN_UPDATES = 10;

        public AzureDataLoader(IHttpClientFactory httpClientFactory = null, ILogger<AzureDataLoader> logger = null)
            : base(httpClientFactory, logger)
        {
        }

        public enum UpdateableTableNames
        {
            User,
            Session,
            SessionLike,
            SessionSpeaker
        }

        private bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;

        public Task<bool> CheckNetworkAndAPIHeartbeat()
        {
            throw new NotImplementedException();
        }

        public Task<bool> CheckRefreshAuthToken()
        {
            throw new NotImplementedException();
        }

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

                var client = GetHttpClient(Consts.UNAUTHORIZED);
                var result = await client.PostAsync("/api/token ", content);

                if (result.IsSuccessStatusCode)
                {
                    var resultContent = JsonConvert.DeserializeObject<AuthenticationResult>(await result.Content.ReadAsStringAsync());
                    //App.Token = resultContent.access_token;

                    //TODO: get the refresh token out of here too

                    //AuthenticationHeaderValue auth = new AuthenticationHeaderValue("bearer", resultContent.access_token);
                    //_client.DefaultRequestHeaders.Add(auth);

                    Analytics.TrackEvent("Successful Login", new Dictionary<string, string> { { "user", user } });

                    return true;
                }
                else
                {
                    Analytics.TrackEvent("Unsuccessful Login", new Dictionary<string, string> { { "user", user } });
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
                bool result = await GetWebAPIDataService(Consts.UNAUTHORIZED).IsServiceOnlineAsync();
                return result;
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
                    if (await _conn.Table<Announcement>().CountAsync() > 0)
                    {
                        var lastUpdated = await _conn.Table<Announcement>().OrderByDescending(x => x.ModifiedUtcDate).FirstAsync();
                        lastUpdatedDate = lastUpdated != null ? lastUpdated?.ModifiedUtcDate : null;
                    }
                }
                else
                {
                    //truncate the table
                    await _conn.Table<Announcement>().DeleteAsync();
                }

                var dtos = await GetWebAPIDataService(Consts.AUTHORIZED).GetAllPagesAnnouncementsAsync(lastUpdatedDate);
                int count = 0;
                if (dtos.Any())
                {
                    foreach (var r in dtos)
                    {
                        count += await _conn.InsertOrReplaceAsync(r.ToModelData());
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
                    if (await _conn.Table<FeedbackInitiatorType>().CountAsync() > 0)
                    {
                        var lastUpdated = await _conn.Table<FeedbackInitiatorType>().OrderByDescending(x => x.ModifiedUtcDate).FirstAsync();
                        lastUpdatedDate = lastUpdated != null ? lastUpdated?.ModifiedUtcDate : null;
                    }
                }
                else
                {
                    //truncate the table
                    await _conn.Table<FeedbackInitiatorType>().DeleteAsync();
                }
                var dtos = await GetWebAPIDataService(Consts.AUTHORIZED).GetAllPagesFeedbackInitiatorTypesAsync(lastUpdatedDate);
                int count = 0;
                if (dtos.Any())
                {
                    foreach (var r in dtos)
                    {
                        count += await _conn.InsertOrReplaceAsync(r.ToModelData());
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
                    if (await _conn.Table<FeedbackType>().CountAsync() > 0)
                    {
                        var lastUpdated = await _conn.Table<FeedbackType>().OrderByDescending(x => x.ModifiedUtcDate).FirstAsync();
                        lastUpdatedDate = lastUpdated != null ? lastUpdated?.ModifiedUtcDate : null;
                    }
                }
                else
                {
                    //truncate the table
                    await _conn.Table<FeedbackType>().DeleteAsync();
                }
                var dtos = await GetWebAPIDataService(Consts.AUTHORIZED).GetAllPagesFeedbackTypesAsync(lastUpdatedDate);
                int count = 0;
                if (dtos.Any())
                {
                    foreach (var r in dtos)
                    {
                        count += await _conn.InsertOrReplaceAsync(r.ToModelData());
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
                    if (await _conn.Table<Room>().CountAsync() > 0)
                    {
                        var lastUpdated = await _conn.Table<Room>().OrderByDescending(x => x.ModifiedUtcDate).FirstAsync();
                        lastUpdatedDate = lastUpdated != null ? lastUpdated?.ModifiedUtcDate : null;
                    }
                }
                else
                {
                    //truncate the table
                    await _conn.Table<Room>().DeleteAsync();
                }
                var dtos = await GetWebAPIDataService(Consts.AUTHORIZED).GetAllPagesRoomsAsync(lastUpdatedDate);
                int count = 0;
                if (dtos.Any())
                {
                    foreach (var r in dtos)
                    {
                        count += await _conn.InsertOrReplaceAsync(r.ToModelData());
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
                        if (await _conn.Table<SessionLike>().CountAsync() > 0)
                        {
                            var lastUpdated = await _conn.Table<SessionLike>().OrderByDescending(x => x.ModifiedUtcDate).FirstAsync();
                            lastUpdatedDate = lastUpdated != null ? lastUpdated?.ModifiedUtcDate : null;
                        }
                    }
                    else
                    {
                        //truncate the table
                        await _conn.Table<SessionLike>().DeleteAsync();
                    }
                    var dtos = await GetWebAPIDataService(Consts.AUTHORIZED).GetAllPagesSessionLikesAsync(lastUpdatedDate);
                    int count = 0;
                    if (dtos.Any())
                    {
                        foreach (var r in dtos)
                        {
                            count += await _conn.InsertOrReplaceAsync(r.ToModelData());
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
                        if (await _conn.Table<Session>().CountAsync() > 0)
                        {
                            var lastUpdated = await _conn.Table<Session>().OrderByDescending(x => x.ModifiedUtcDate).FirstAsync();
                            lastUpdatedDate = lastUpdated != null ? lastUpdated?.ModifiedUtcDate : null;
                        }
                    }
                    else
                    {
                        //truncate the table
                        await _conn.Table<Session>().DeleteAsync();
                    }
                    var dtos = await GetWebAPIDataService(Consts.AUTHORIZED).GetAllPagesSessionsAsync(lastUpdatedDate);
                    int count = 0;
                    if (dtos.Any())
                    {
                        foreach (var r in dtos)
                        {
                            count += await _conn.InsertOrReplaceAsync(r.ToModelData());
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
                        if (await _conn.Table<SessionSpeaker>().CountAsync() > 0)
                        {
                            var lastUpdated = await _conn.Table<SessionSpeaker>().OrderByDescending(x => x.ModifiedUtcDate).FirstAsync();
                            lastUpdatedDate = lastUpdated != null ? lastUpdated?.ModifiedUtcDate : null;
                        }
                    }
                    else
                    {
                        //truncate the table
                        await _conn.Table<SessionSpeaker>().DeleteAsync();
                    }
                    var dtos = await GetWebAPIDataService(Consts.AUTHORIZED).GetAllPagesSessionSpeakersAsync(lastUpdatedDate);
                    int count = 0;
                    if (dtos.Any())
                    {
                        foreach (var r in dtos)
                        {
                            count += await _conn.InsertOrReplaceAsync(r.ToModelData());
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
                        if (await _conn.Table<UserProfile>().CountAsync() > 0)
                        {
                            var lastUpdated = await _conn.Table<UserProfile>().OrderByDescending(x => x.ModifiedUtcDate).FirstAsync();
                            lastUpdatedDate = lastUpdated != null ? lastUpdated?.ModifiedUtcDate : null;
                        }
                    }
                    else
                    {
                        //truncate the table
                        await _conn.Table<UserProfile>().DeleteAsync();
                    }
                    var dtos = await GetWebAPIDataService(Consts.AUTHORIZED).GetAllPagesUserProfilesAsync(lastUpdatedDate);
                    int count = 0;
                    if (dtos.Any())
                    {
                        foreach (var r in dtos)
                        {
                            count += await _conn.InsertOrReplaceAsync(r.ToModelData());
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
            var record = await _conn.Table<MobileModelData.LastUpdated>().Where(x => x.TableName == tableName).FirstOrDefaultAsync();
            if (record != null)
            {
                return (record.LastUpdatedUTC < DateTime.UtcNow.AddMinutes(MAX_MINUTES_BETWEEN_UPDATES)) ? true : false;
            }
            return true;
        }

        private async Task<bool> SetLastUpdatedNow(UpdateableTableNames updateableTableName)
        {
            return 1 == await _conn.InsertOrReplaceAsync(new MobileModelData.LastUpdated() { TableName = updateableTableName.ToString(), LastUpdatedUTC = DateTime.UtcNow });
        }
    }
}