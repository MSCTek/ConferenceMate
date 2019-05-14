using Microsoft.Extensions.Logging;
using MSC.CM.Xam.ModelObj.CM;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace MSC.CM.XaSh.Services
{
    public class AzureDataStore : IDataStore<Announcement>
    {
        HttpClient _client;
        IEnumerable<Announcement> _announcements;
        ILogger<AzureDataStore> _logger;

        public AzureDataStore(ILogger<AzureDataStore> logger = null, IHttpClientFactory httpClientFactory = null)
        {
            _logger = logger;
            _client = httpClientFactory == null ? new HttpClient() : httpClientFactory.CreateClient("AzureWebsites");

            if (httpClientFactory == null)
                _client.BaseAddress = new Uri($"{App.AzureBackendUrl}/");

            _announcements = new List<Announcement>();
        }

        bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;

        public async Task<Announcement> GetItemAsync(string id)
        {
            return null;
        }

        public async Task<IEnumerable<Announcement>> GetItemsAsync(bool forceRefresh = false)
        {
            return null;
        }
    }
}
