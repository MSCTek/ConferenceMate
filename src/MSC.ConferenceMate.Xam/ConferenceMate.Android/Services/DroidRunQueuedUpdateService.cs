using Android.App;
using Android.Content;
using Android.OS;
using QuikRide.Helpers;
using QuikRide.Services;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

//https://github.com/RobGibbens/XamarinFormsBackgrounding

namespace QuikRide.Droid.Services
{
    [Service]
    public class DroidRunQueuedUpdateService : Service
    {
        private CancellationTokenSource _cts;

        public override IBinder OnBind(Intent intent)
        {
            return null;
        }

        public override void OnDestroy()
        {
            if (_cts != null)
            {
                _cts.Token.ThrowIfCancellationRequested();

                _cts.Cancel();
            }
            base.OnDestroy();
        }

        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            _cts = new CancellationTokenSource();

            Task.Run(async () =>
            {
                try
                {
                    await UploadDataService.Instance.RunQueuedUpdatesAsync(_cts.Token);
                }
                catch (OperationCanceledException)
                {
                }
                finally
                {
                    if (_cts.IsCancellationRequested)
                    {
                        var message = new CancelledMessage();
                        Device.BeginInvokeOnMainThread(
                            () => MessagingCenter.Send(message, "CancelledMessage")
                        );
                    }
                }
            }, _cts.Token);

            return StartCommandResult.Sticky;
        }
    }
}