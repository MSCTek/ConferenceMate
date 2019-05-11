using QuikRide.Interfaces;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing;
using ZXing.Net.Mobile.Forms;

namespace QuikRide.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BarcodeReaderPage : ZXingScannerPage, IContentPage
    {
        public BarcodeReaderPage()
        {
            InitializeComponent();
        }

        public async void Handle_OnScanResult(Result result)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                await Application.Current.MainPage.DisplayAlert("Scanned result", result.Text, "OK");
            });
        }

        public void PrepareForDispose()
        {
        }
    }
}