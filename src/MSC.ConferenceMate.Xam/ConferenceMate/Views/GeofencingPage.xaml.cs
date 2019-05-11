using QuikRide.Interfaces;
using QuikRide.ViewModels;
using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QuikRide.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GeofencingPage : IContentPage
    {
        private bool shouldTimerRun;

        public GeofencingPage()
        {
            InitializeComponent();
        }

        public void PrepareForDispose()
        {
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (BindingContext != null)
            {
                var vm = (GeofencingViewModel)BindingContext;
                shouldTimerRun = true;
                Device.StartTimer(TimeSpan.FromSeconds(5), () =>
                {
                    Debug.WriteLine("Checking Geofence Status...");
                    vm.CheckGeofenceStatus();
                    // True = Repeat again, False = Stop the timer
                    return shouldTimerRun;
                });
            }
        }

        protected override void OnDisappearing()
        {
            shouldTimerRun = false;
            base.OnDisappearing();
        }
    }
}