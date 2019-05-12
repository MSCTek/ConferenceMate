using ConferenceMate.UWP.Modules;

namespace ConferenceMate.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            ZXing.Net.Mobile.Forms.WindowsUniversal.ZXingScannerViewRenderer.Init();

            LoadApplication(new ConferenceMate.App(new UWPPlatformModule()));
        }
    }
}