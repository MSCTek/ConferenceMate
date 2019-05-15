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

        public async Task<IEnumerable<objModel.SessionSpeaker>> GetSpeakersAsync()
        {
            //includes session and user data
            var returnMe = new List<objModel.SessionSpeaker>();
            var dataResults = await conn.Table<dataModel.SessionSpeaker>().ToListAsync();

            if (dataResults.Any())
            {
                foreach (var d in dataResults)
                {
                    var objMod = d.ToModelObj();
                    var session = await conn.Table<dataModel.Session>()
                        .Where(x => x.SessionId == d.SessionId).FirstOrDefaultAsync();
                    objMod.Session = session != null ? session.ToModelObj() : null;
                    var user = await conn.Table<dataModel.User>()
                       .Where(x => x.UserId == d.UserId).FirstOrDefaultAsync();
                    objMod.User = user != null ? user.ToModelObj() : null;
                    returnMe.Add(objMod);
                }
            }
            return returnMe;
        }
    }
}