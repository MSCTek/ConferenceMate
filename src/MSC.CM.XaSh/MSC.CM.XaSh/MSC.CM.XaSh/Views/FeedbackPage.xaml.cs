using Microsoft.AppCenter.Analytics;
using MSC.CM.XaSh.ViewModels;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSC.CM.XaSh.Views
{
    public partial class FeedbackPage : ContentPage
    {
        private FeedbackViewModel viewModel;

        public FeedbackPage()
        {
            InitializeComponent();
            BindingContext = viewModel = Startup.ServiceProvider?.GetService<FeedbackViewModel>() ?? new FeedbackViewModel();
            //TODO: workaround https://github.com/xamarin/Xamarin.Forms/issues/6098
            viewModel.LoadData();
        }

        protected async override void OnAppearing()
        {
            Analytics.TrackEvent("FeedbackPage");
            base.OnAppearing();
            await viewModel.LoadData();
        }
    }
}