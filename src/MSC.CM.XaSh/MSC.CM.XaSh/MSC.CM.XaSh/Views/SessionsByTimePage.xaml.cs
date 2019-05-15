using Microsoft.AppCenter.Analytics;
using MSC.CM.XaSh.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSC.CM.XaSh.Views
{
    public partial class SessionsByTimePage : ContentPage
    {
        private SessionsByTimeViewModel viewModel;

        public SessionsByTimePage()
        {
            InitializeComponent();
            BindingContext = viewModel = Startup.ServiceProvider?.GetService<SessionsByTimeViewModel>();
        }

        protected async override void OnAppearing()
        {
            Analytics.TrackEvent("SessionsByTimePage");
            base.OnAppearing();

            if (viewModel.Sessions.Count == 0)
            {
                MainListView.IsRefreshing = true;
                await viewModel.RefreshListViewData();
                MainListView.EndRefresh();
            }
        }

        private async void MainListView_Refreshing(object sender, EventArgs e)
        {
            MainListView.IsRefreshing = true;
            await viewModel.RefreshListViewData();
            MainListView.EndRefresh();
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null; // de-select the row
        }
    }
}