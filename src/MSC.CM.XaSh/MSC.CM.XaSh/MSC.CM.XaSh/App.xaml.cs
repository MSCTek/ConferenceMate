using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MSC.CM.XaSh.Services;
using MSC.CM.XaSh.Views;

namespace MSC.CM.XaSh
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
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
