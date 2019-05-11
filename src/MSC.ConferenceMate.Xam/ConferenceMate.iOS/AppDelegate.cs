using Foundation;
using QuikRide.Helpers;
using QuikRide.iOS.Modules;
using QuikRide.iOS.Services;
using System;
using UIKit;
using Xamarin.Forms;

namespace QuikRide.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public static Action BackgroundSessionCompletionHandler;

        private IOSRunQueuedUpdateService myiOSUploadDataService;

        //
        // This method is invoked when the application has loaded and is ready to run. In this
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            SubscribeToMessages();

            //barcode reader
            ZXing.Net.Mobile.Forms.iOS.Platform.Init();

            Xamarin.FormsMaps.Init();

            LoadApplication(new App(new IOSPlatformModule()));

            return base.FinishedLaunching(app, options);
        }

        private void SubscribeToMessages()
        {
            MessagingCenter.Subscribe<StartUploadDataMessage>(this, "StartUploadDataMessage", async message =>
            {
                myiOSUploadDataService = new IOSRunQueuedUpdateService();
                await myiOSUploadDataService.StartAsync();
            });

            MessagingCenter.Subscribe<StopUploadDataMessage>(this, "StopUploadDataMessage", message =>
            {
                myiOSUploadDataService.Stop();
            });
        }
    }
}