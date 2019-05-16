using Microsoft.AppCenter.Analytics;
using MSC.CM.XaSh.ViewModels;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSC.CM.XaSh.Views
{
    public partial class SessionsByRoomPage : ContentPage
    {
        private SessionsByRoomViewModel viewModel;

        public SessionsByRoomPage()
        {
            InitializeComponent();
            BindingContext = viewModel = Startup.ServiceProvider?.GetService<SessionsByRoomViewModel>();
        }

        protected async override void OnAppearing()
        {
            Analytics.TrackEvent("SessionsByRoomPage");
            base.OnAppearing();

            await Refresh();
        }

        private async void MainListView_Refreshing(object sender, EventArgs e)
        {
            await Refresh();
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null; // de-select the row
        }

        private async Task Refresh()
        {
            MainListView.IsRefreshing = true;
            await viewModel.RefreshListViewData();
            MainListView.EndRefresh();
        }
    }
}