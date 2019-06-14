using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MSC.CM.XaSh.Services;
using MSC.CM.XaSh.Views;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using MSC.CM.XaSh.Database;
using System.IO;

namespace MSC.CM.XaSh
{
	public partial class App : Application
	{
		public const string CURRENT_USER_ID = "CURRENT_USER_ID";
		public static string AzureBackendUrl = "https://conferencemate.azurewebsites.net/api/CM";
		private static ConferenceMateDatabase database;

		public App()
		{
			InitializeComponent();

			Startup.Init();

			MainPage = new AppShell();
		}

		public static ConferenceMateDatabase Database
		{
			get
			{
				if (database == null)
				{
					database = new ConferenceMateDatabase(
					  Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ConferenceMate.db3"));
				}
				return database;
			}
		}

		public static bool UseSampleDataStore { get; set; } = false;

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

			AppCenter.Start("android=;" +
				  "ios=;",
				  typeof(Analytics), typeof(Crashes));
		}
	}
}