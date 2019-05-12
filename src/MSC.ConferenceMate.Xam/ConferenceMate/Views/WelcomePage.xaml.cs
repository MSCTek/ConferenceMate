﻿using ConferenceMate.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ConferenceMate.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomePage : ContentPage
    {
        public WelcomePage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (BindingContext != null)
            {
                var vm = (WelcomeViewModel)BindingContext;
                await vm.Init();
            }
        }
    }
}