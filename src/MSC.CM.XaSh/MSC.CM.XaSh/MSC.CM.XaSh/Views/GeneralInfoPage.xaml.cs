using Microsoft.AppCenter.Analytics;
using MSC.CM.XaSh.ViewModels;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSC.CM.XaSh.Views
{
    public partial class GeneralInfoPage : ContentPage
    {
        private GeneralInfoViewModel viewModel;

        public GeneralInfoPage()
        {
            InitializeComponent();
            BindingContext = viewModel = Startup.ServiceProvider?.GetService<GeneralInfoViewModel>() ?? new GeneralInfoViewModel();
            //TODO: workaround https://github.com/xamarin/Xamarin.Forms/issues/6098
            Refresh();
        }

        protected async override void OnAppearing()
        {
            Analytics.TrackEvent("GeneralInfoPage");
            base.OnAppearing();

            await Refresh();
        }

        private async Task Refresh()
        {
            await viewModel.RefreshUserData();
        }
    }
}