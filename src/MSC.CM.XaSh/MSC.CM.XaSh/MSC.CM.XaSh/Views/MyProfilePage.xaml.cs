using Microsoft.AppCenter.Analytics;
using MSC.CM.XaSh.ViewModels;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSC.CM.XaSh.Views
{
    public partial class MyProfilePage : ContentPage
    {
        private MyProfileViewModel viewModel;

        public MyProfilePage()
        {
            InitializeComponent();
            BindingContext = viewModel = Startup.ServiceProvider?.GetService<MyProfileViewModel>() ?? new MyProfileViewModel();
        }

        protected async override void OnAppearing()
        {
            Analytics.TrackEvent("MyProfilePage");
            base.OnAppearing();

            await Refresh();
        }

        private async Task Refresh()
        {
            await viewModel.LoadVM();
        }
    }
}