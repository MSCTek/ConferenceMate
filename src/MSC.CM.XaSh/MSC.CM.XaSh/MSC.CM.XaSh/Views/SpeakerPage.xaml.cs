using Microsoft.AppCenter.Analytics;
using MSC.CM.XaSh.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSC.CM.XaSh.Views
{
    public partial class SpeakerPage : ContentPage
    {
        private SpeakerViewModel viewModel;

        public SpeakerPage()
        {
            InitializeComponent();
            BindingContext = viewModel = Startup.ServiceProvider?.GetService<SpeakerViewModel>();
        }

        protected async override void OnAppearing()
        {
            Analytics.TrackEvent("SpeakerPage");
            base.OnAppearing();

            if (viewModel.Speakers.Count == 0)
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