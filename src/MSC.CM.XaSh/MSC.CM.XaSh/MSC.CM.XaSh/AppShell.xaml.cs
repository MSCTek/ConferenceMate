using MSC.CM.XaSh.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MSC.CM.XaSh
{
    public partial class AppShell : Xamarin.Forms.Shell
    {

        Random rand = new Random();
        Dictionary<string, Type> routes = new Dictionary<string, Type>();
        public Dictionary<string, Type> Routes { get { return routes; } }

        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();
        }

        void RegisterRoutes()
        {
            //routes.Add("monkeydetails", typeof(MonkeyDetailPage));
            //routes.Add("beardetails", typeof(BearDetailPage));
            //routes.Add("catdetails", typeof(CatDetailPage));
            //routes.Add("dogdetails", typeof(DogDetailPage));
            //routes.Add("elephantdetails", typeof(ElephantDetailPage));

            routes.Add("about", typeof(AboutPage));
            routes.Add("feedback", typeof(FeedbackPage));

            foreach (var item in routes)
            {
                Routing.RegisterRoute(item.Key, item.Value);
            }
        }

        public ICommand AboutPageCommand => new Command(async () => await NavigateToPageAsync("about"));
        public ICommand FeedbackPageCommand => new Command(async () => await NavigateToPageAsync("feedback"));

        private async Task NavigateToPageAsync(string pageName)
        {
            await Shell.Current.GoToAsync(new ShellNavigationState(pageName));
            Shell.Current.FlyoutIsPresented = false;
        }

        void OnNavigating(object sender, ShellNavigatingEventArgs e)
        {
            // Cancel any back navigation
            //if (e.Source == ShellNavigationSource.Pop)
            //{
            //    e.Cancel();
            //}
        }

        void OnNavigated(object sender, ShellNavigatedEventArgs e)
        {
        }
    }
}
