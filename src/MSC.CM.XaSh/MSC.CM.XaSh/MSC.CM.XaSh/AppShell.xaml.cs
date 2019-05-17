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
        private Random rand = new Random();
        private Dictionary<string, Type> routes = new Dictionary<string, Type>();

        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();
        }

        public ICommand AboutPageCommand => new Command(async () => await NavigateToPageAsync("about"));
        public ICommand FeedbackPageCommand => new Command(async () => await NavigateToPageAsync("feedback"));
        public Dictionary<string, Type> Routes { get { return routes; } }

        private async Task NavigateToPageAsync(string pageName)
        {
            await Shell.Current.GoToAsync(new ShellNavigationState(pageName));
            Shell.Current.FlyoutIsPresented = false;
        }

        private void OnNavigated(object sender, ShellNavigatedEventArgs e)
        {
        }

        private void OnNavigating(object sender, ShellNavigatingEventArgs e)
        {
            // Cancel any back navigation
            //if (e.Source == ShellNavigationSource.Pop)
            //{
            //    e.Cancel();
            //}
        }

        private void RegisterRoutes()
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
    }
}