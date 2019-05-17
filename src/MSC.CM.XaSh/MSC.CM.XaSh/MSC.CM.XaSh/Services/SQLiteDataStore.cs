using Microsoft.AppCenter.Crashes;
using Microsoft.Extensions.Logging;
using MSC.CM.Xam;
using SQLite;
using System;
using System.Collections.Generic;
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
            //includes session and user data
            var returnMe = new List<objModel.Session>();
            var dataResults = await conn.Table<dataModel.Session>().ToListAsync();

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
                            .Where(x => x.UserId == speaker.UserId).FirstOrDefaultAsync();
                        speaker.User = user != null ? user.ToModelObj() : null;

                        sessionObjMod.SessionSpeakers.Add(s.ToModelObj());
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

        public async Task<int> WriteFeedbackRecord(dataModel.Feedback feedbackData)
        {
            return await conn.InsertAsync(feedbackData);
        }
    }
}