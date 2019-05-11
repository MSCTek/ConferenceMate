using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Plugin.CurrentActivity;
using Plugin.Permissions;
using QuikRide.Droid.Modules;
using QuikRide.Droid.Services;
using QuikRide.Helpers;
using Xamarin.Forms;

namespace QuikRide.Droid
{
    [Activity(Label = "QuikRide", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            //for barcode reader
            global::ZXing.Net.Mobile.Android.PermissionsHandler.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            CrossCurrentActivity.Current.Init(this, savedInstanceState);

            //xam essentals
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            //barcode reader
            ZXing.Net.Mobile.Forms.Android.Platform.Init();

            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            //maps
            Xamarin.FormsMaps.Init(this, savedInstanceState);

            LoadApplication(new App(new DroidPlatformModule()));

            //safe backgrounding
            SubscribeToMessages();
        }

        private void SubscribeToMessages()
        {
            //implement safe backgrounding
            MessagingCenter.Subscribe<StartUploadDataMessage>(this, "StartUploadDataMessage", message =>
            {
                var intent = new Intent(this, typeof(DroidRunQueuedUpdateService));
                StartService(intent);
            });

            MessagingCenter.Subscribe<StopUploadDataMessage>(this, "StopUploadDataMessage", message =>
            {
                var intent = new Intent(this, typeof(StopUploadDataMessage));
                StopService(intent);
            });
        }
    }
}