using QuikRide.Services;
using System.Threading;
using System.Threading.Tasks;

namespace QuikRide.UWP.Services
{
    public class UWPRunQueuedUpdateService
    {
        private CancellationTokenSource _cts;

        public async Task StartAsync()
        {
            _cts = new CancellationTokenSource();

            await UploadDataService.Instance.RunQueuedUpdatesAsync(_cts.Token);
        }

        public void Stop()
        {
            _cts.Cancel();
        }

        //COULD ALSO DO IT SOMETHING LIKE THIS... but it would need to be registered.
        //https://docs.microsoft.com/en-us/windows/uwp/launch-resume/create-and-register-a-background-task
    }
}