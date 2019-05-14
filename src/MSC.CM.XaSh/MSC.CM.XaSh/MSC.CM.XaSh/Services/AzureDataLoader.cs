using CodeGenHero.DataService;
using Microsoft.AppCenter.Crashes;
using Microsoft.Extensions.Logging;
using MSC.CM.Xam;
using MSC.CM.Xam.ModelData.CM;
using MSC.ConferenceMate.API.Client;
using MSC.ConferenceMate.API.Client.Interface;
using MSC.ConferenceMate.DataService.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using static MSC.ConferenceMate.DataService.Constants.Enums;

namespace MSC.CM.XaSh.Services
{
    public class AzureDataLoader : IDataLoader
    {
        private SQLiteAsyncConnection conn = App.Database.conn;

        private ILogger<AzureDataStore> logger;
        private IWebApiDataServiceCM webAPIDataService;

        public AzureDataLoader()
        {
        }

        //TODO: PAUL to take advantage of this goodness, wire up the CGH httpclient to use the transient http error policy
        //private HttpClient client;
        //public AzureDataLoader(ILogger<AzureDataStore> _logger = null, IHttpClientFactory _httpClientFactory = null)
        public AzureDataLoader(ILogger<AzureDataStore> _logger = null)
        {
            logger = _logger;
            //client = _httpClientFactory == null ? new HttpClient() : _httpClientFactory.CreateClient("AzureWebsites");

            //if (_httpClientFactory == null)
            //    client.BaseAddress = new Uri($"{App.AzureBackendUrl}/");

            var webApiExecutionContextType = new CMWebApiExecutionContextType();
            webApiExecutionContextType.Current = (int)ExecutionContextTypes.Base;

            WebApiExecutionContext context = new WebApiExecutionContext(
                executionContextType: webApiExecutionContextType,
                baseWebApiUrl: App.AzureBackendUrl,
                baseFileUrl: string.Empty,
                connectionIdentifier: null);

            webAPIDataService = new WebApiDataServiceCM(null, context);
        }

        private bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;

        public async Task<bool> HeartbeatCheck()
        {
            try
            {
                return await webAPIDataService.IsServiceOnlineAsync();
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
                return false;
            }
        }

        public async Task<int> LoadAnnouncementsAsync()
        {
            try
            {
                DateTime? lastUpdatedDate = null;
                if (await conn.Table<Announcement>().CountAsync() > 0)
                {
                    var lastUpdated = await conn.Table<Announcement>().OrderByDescending(x => x.ModifiedUtcDate).FirstAsync();
                    lastUpdatedDate = lastUpdated != null ? lastUpdated?.ModifiedUtcDate : null;
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
    }
}