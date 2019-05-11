using QuikRide.UWP.Modules;

namespace QuikRide.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            ZXing.Net.Mobile.Forms.WindowsUniversal.ZXingScannerViewRenderer.Init();

            LoadApplication(new QuikRide.App(new UWPPlatformModule()));
        }
    }
}