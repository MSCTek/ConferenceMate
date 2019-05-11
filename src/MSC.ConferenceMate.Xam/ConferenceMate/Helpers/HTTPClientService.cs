using Microsoft.AppCenter.Crashes;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace QuikRide.Helpers
{
    public static class HTTPClientService
    {
        public static async Task<ExternalAPIModels.What3WordsModel.RootObject> RefreshWhat3WordsDataAsync(double longitude, double latitude)
        {
            var locData = new ExternalAPIModels.What3WordsModel.RootObject();

            try
            {
                HttpClient client = new HttpClient();
                client.MaxResponseContentBufferSize = 256000;
                var urlStr = $"https://api.what3words.com/v2/reverse?coords={latitude}%2C{longitude}&key={Config.What3WordsAPIKey}";
                var uri = new Uri(urlStr);
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    locData = JsonConvert.DeserializeObject<ExternalAPIModels.What3WordsModel.RootObject>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
                Crashes.TrackError(ex);
            }

            return locData;
        }
    }
}