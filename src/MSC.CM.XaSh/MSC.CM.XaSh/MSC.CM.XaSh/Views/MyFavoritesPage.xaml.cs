using Microsoft.AppCenter.Analytics;
using MSC.CM.XaSh.ViewModels;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSC.CM.XaSh.Views
{
    public partial class MyFavoritesPage : ContentPage
    {
        private MyFavoritesViewModel viewModel;

        public MyFavoritesPage()
        {
            InitializeComponent();
            BindingContext = viewModel = Startup.ServiceProvider?.GetService<MyFavoritesViewModel>() ?? new MyFavoritesViewModel();
            //TODO: workaround https://github.com/xamarin/Xamarin.Forms/issues/6098
            Refresh();
        }

        protected async override void OnAppearing()
        {
            Analytics.TrackEvent("MyFavoritesPage");
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