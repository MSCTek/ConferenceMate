using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MSC.CM.XaSh.Services;
using MSC.CM.XaSh.Views;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

namespace MSC.CM.XaSh
{
    public partial class App : Application
    {
        public static string AzureBackendUrl = "http://myfirstmobileapp-mobileappservice.azurewebsites.net";

        public static bool UseMockDataStore { get; set; } = false;
        public App()
        {
            InitializeComponent();

            Startup.Init();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            // Handle when your app starts

            AppCenter.Start("android=eb56638a-6ad3-4c3f-b084-52f3b84633d6;" +
                  "ios=daee1b97-de5f-4f66-8982-5ee228fa79fe;",
                  typeof(Analytics), typeof(Crashes));
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
