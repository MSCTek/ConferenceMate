﻿using Microsoft.AppCenter.Analytics;
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
            //TODO: Why isn't the constructor being called again when the ServiceProvider is being re-generated during runtime?
            //BindingContext = viewModel = Startup.ServiceProvider?.GetService<FeedbackViewModel>() ?? new FeedbackViewModel();
        }

        protected async override void OnAppearing()
        {
            Analytics.TrackEvent("FeedbackPage");
            base.OnAppearing();

            //Workaround here
            BindingContext = viewModel = Startup.ServiceProvider?.GetService<FeedbackViewModel>() ?? new FeedbackViewModel();
            await viewModel.LoadData();
        }
    }
}