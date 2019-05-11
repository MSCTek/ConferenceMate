using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Ninject;
using Ninject.Modules;
using QuikRide.Interfaces;
using QuikRide.Modules;
using QuikRide.ViewModels;
using QuikRide.Views;
using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace QuikRide
{
    public partial class App : Application
    {
        public App(params INinjectModule[] platformModules)
        {
            InitializeComponent();
            NavPage = new NavigationPage();

            // Register navigation module with ninject - we can register our navigation service here too, if we want to.
            Kernel = new StandardKernel(new CoreModule(), new NavigationModule(NavPage));

            Kernel.Load(platformModules);

            //initialize the database
            var asyncconn = Kernel.Get<ISQLite>().GetAsyncConnection();
            var conn = Kernel.Get<ISQLite>().GetConnection();
            if (conn != null && asyncconn != null)
            {
                var db = Kernel.Get<IDatabase>();
                db.SetConnection(conn, asyncconn);
                db.CreateTables();
            }
            else
            {
                string message = "ERROR: SQLite Database could not be created.";
                Debug.WriteLine(message);
                Exception ex = new InvalidOperationException(message);
                Crashes.TrackError(ex);
                throw ex;
            }

            var welcome = new WelcomePage();
            welcome.BindingContext = new WelcomeViewModel();
            MainPage = welcome;
        }

        public IKernel Kernel { get; set; }

        public NavigationPage NavPage { get; }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            AppCenter.Start($"android={Config.AppCenterDroid};" +
                  $"uwp={Config.AppCenterUWP};" +
                  $"ios={Config.AppCenterIOS};",
                  typeof(Analytics), typeof(Crashes));
        }
    }
}