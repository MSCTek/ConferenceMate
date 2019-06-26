using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Http;
using Microsoft.Extensions.Logging;
using MSC.CM.Xam.ModelObj.CM;
using MSC.CM.XaSh.Services;
using MSC.CM.XaSh.ViewModels;
using Polly;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Xamarin.Essentials;

namespace MSC.CM.XaSh
{
	public class Startup
	{
		public static IServiceProvider ServiceProvider { get; set; }

		public static string ExtractAppSettings(string filename)
		{
			var location = FileSystem.CacheDirectory;
			string full = null;
			var a = Assembly.GetExecutingAssembly();
			using (var resFilestream = a.GetManifestResourceStream(filename))
			{
				if (resFilestream != null)
				{
					full = Path.Combine(location, filename);

					using (var stream = File.Create(full))
					{
						resFilestream.CopyTo(stream);
					}
				}
			}

			return full;
		}

		public static void Init()
		{
			var configLocation = ExtractAppSettings("MSC.CM.XaSh.appsettings.json");

			var host = new HostBuilder()
				.ConfigureHostConfiguration(c =>
				{
					c.AddCommandLine(new String[] { $"ContentRoot={FileSystem.AppDataDirectory}" });
					c.AddJsonFile(configLocation);
				})
				.ConfigureServices((c, x) => ConfigureServices(c, x))
				.ConfigureLogging(l => l.AddConsole(abc =>
				{
					abc.DisableColors = true;
				}))
				.Build();

			ServiceProvider = host.Services;
		}

		private static void ConfigureServices(HostBuilderContext ctx, IServiceCollection services)
		{
			var world = ctx.Configuration["Hello"];

			//TODO: PAUL to take advantage of this goodness, wire up the CGH httpclient to use the transient http error policy
			services.AddHttpClient("BackEndAPI", client =>
			{
				client.BaseAddress = new Uri(App.AzureBackendUrl);
			}).ConfigureHttpClient(client =>
			{
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
				client.DefaultRequestHeaders.Add("api-version", "1");

				//TODO: Get Bearer token here.
				//string jwt = tokenCache.GetToken("Foo");
				string jwt = "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjdDRTg4OEU1LTVENDItNDgzRC1CMDMwLTQxQjZBNTRFNjY0NyIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWUiOiJEYXZpZEBleGFtcGxlLmNvbSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vYWNjZXNzY29udHJvbHNlcnZpY2UvMjAxMC8wNy9jbGFpbXMvaWRlbnRpdHlwcm92aWRlciI6IkFTUC5ORVQgSWRlbnRpdHkiLCJBc3BOZXQuSWRlbnRpdHkuU2VjdXJpdHlTdGFtcCI6ImZhOGUxYzJmLTU2MDEtNDRkNy1hZWY1LTM0Y2U0YmIwN2VkMiIsIm5iZiI6MTU2MTUyMjM0NiwiZXhwIjoxNTYxNTI1OTQ2LCJpc3MiOiJodHRwOi8vbG9jYWxob3N0IiwiYXVkIjoiZTZiMGY5M2I2MDI1NDQwODlkMzQzNmZhYmM1YjRhYjAifQ.txgbvt9oemQfouVaqJ5fUOk0GIHWEmQ_J39-hVtwmgQ";
				System.Net.Http.Headers.AuthenticationHeaderValue authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", jwt);
				client.DefaultRequestHeaders.Authorization = authorization;
			})
			.AddTransientHttpErrorPolicy(builder => builder.WaitAndRetryAsync(new[]
			{
				TimeSpan.FromSeconds(1),
				TimeSpan.FromSeconds(5),
				TimeSpan.FromSeconds(10)
			}));

			if (ctx.HostingEnvironment.IsDevelopment() && App.UseSampleDataStore)
			{
				//load vms directly from sample data
				//services.AddSingleton<IDataStore, SampleDataStore>();
				//load vms from SQLite
				services.AddSingleton<IDataStore, SQLiteDataStore>();
				services.AddSingleton<IDataLoader, SampleDataLoader>();
				services.AddSingleton<IDataUploader, SampleDataUploader>();
			}
			else
			{
				services.AddSingleton<IDataStore, SQLiteDataStore>();
				services.AddSingleton<IDataLoader, AzureDataLoader>();
				services.AddSingleton<IDataUploader, AzureDataUploader>();
			}

			services.AddTransient<AboutViewModel>(); //viewmodel are created new, everytime
			services.AddTransient<AnnouncementsViewModel>();
			services.AddTransient<FeedbackViewModel>();
			services.AddTransient<GeneralInfoViewModel>();
			services.AddTransient<LocalWeatherViewModel>();
			services.AddTransient<MyFavoritesViewModel>();
			services.AddTransient<MyProfileViewModel>();
			services.AddTransient<SessionsByRoomViewModel>();
			services.AddTransient<SessionsByTimeViewModel>();
			services.AddTransient<SpeakerViewModel>();
			services.AddTransient<WorkshopsViewModel>();

			services.AddTransient<MyProfileEditViewModel>();

			//services.AddTransient<MainPage>();

			services.AddSingleton<App>(); //App is a singleton
		}
	}
}