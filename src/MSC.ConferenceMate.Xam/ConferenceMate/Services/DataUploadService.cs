using QuikRide.Interfaces;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace QuikRide.Services
{
    public class UploadDataService
    {
        private static UploadDataService _instance;
        private IDataRetrievalService _dataService;

        private UploadDataService()
        {
            _dataService = ((QuikRide.App)Xamarin.Forms.Application.Current).Kernel.GetService(typeof(IDataRetrievalService)) as IDataRetrievalService;
        }

        public static UploadDataService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UploadDataService();
                }
                return _instance;
            }
        }

        public async Task RunQueuedUpdatesAsync(CancellationToken token)
        {
            if (_dataService == null)
            {
                _dataService = ((QuikRide.App)Xamarin.Forms.Application.Current).Kernel.GetService(typeof(IDataRetrievalService)) as IDataRetrievalService;
            }
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                await _dataService.RunQueuedUpdatesAsync(token);
            }
            else
            {
                Debug.WriteLine($"No connectivity - RunQueuedUpdatesAsync cannot run");
            }
        }
    }
}