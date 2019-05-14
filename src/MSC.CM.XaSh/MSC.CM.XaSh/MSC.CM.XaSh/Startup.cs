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

        static void ConfigureServices(HostBuilderContext ctx, IServiceCollection services)
        {
            var world = ctx.Configuration["Hello"];

           
            services.AddHttpClient("AzureWebsites", client =>
            {
                client.BaseAddress = new Uri(App.AzureBackendUrl);
            })
            .AddTransientHttpErrorPolicy(builder => builder.WaitAndRetryAsync(new[]
            {
                TimeSpan.FromSeconds(1),
                TimeSpan.FromSeconds(5),
                TimeSpan.FromSeconds(10)
            }));

            if (ctx.HostingEnvironment.IsDevelopment())
            {
                services.AddSingleton<IDataStore, MockDataStore>();

            }
            else
            {
                services.AddSingleton<IDataStore, AzureDataStore>();
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

            //services.AddTransient<MainPage>();

            services.AddSingleton<App>(); //App is a singleton
        }

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
    }
}
