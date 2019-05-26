using Microsoft.AppCenter.Analytics;
using MSC.CM.XaSh.ViewModels;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSC.CM.XaSh.Views
{
    public partial class MyProfileEditPage : ContentPage
    {
        private MyProfileEditViewModel viewModel;

        public MyProfileEditPage()
        {
            InitializeComponent();
            BindingContext = viewModel = Startup.ServiceProvider?.GetService<MyProfileEditViewModel>() ?? new MyProfileEditViewModel();
        }

        protected async override void OnAppearing()
        {
            Analytics.TrackEvent("MyProfileEditPage");
            base.OnAppearing();

            await Refresh();
        }

        private async Task Refresh()
        {
            await viewModel.LoadVM();
        }
    }
}