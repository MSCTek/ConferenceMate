using QuikRide.Interfaces;
using QuikRide.ViewModels;
using System;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace QuikRide.Views
{
    public class LoyaltyScannerPage : ContentPage
    {
        private ZXingDefaultOverlay overlay;
        private LoyaltyScannerViewModel vm;
        private ZXingScannerView zxing;

        public LoyaltyScannerPage() : base()
        {
            zxing = new ZXingScannerView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                AutomationId = "zxingScannerView",
            };
            zxing.OnScanResult += (result) =>
            {
                // Stop analysis until we navigate away so we don't keep reading barcodes
                zxing.IsAnalyzing = false;

                Guid barcodeGuid;
                if (Guid.TryParse(result.Text, out barcodeGuid))
                {
                    vm.RecordScanAsync(barcodeGuid);

                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        // Show an alert
                        //await DisplayAlert("Scanned Barcode", result.Text, "OK");

                        // Navigate away
                        //await Navigation.PopAsync();
                        var navServ = ((QuikRide.App)Xamarin.Forms.Application.Current).Kernel.GetService(typeof(INavigationService)) as INavigationService;
                        navServ.NavigateTo<LoyaltyBonusViewModel>();
                    });

                    /*.BeginInvokeOnMainThread(async () =>
                    {
                        await Application.Current.MainPage.DisplayAlert("Thanks!", "You're the best!", "OK");
                    });*/
                }
                else
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        await Application.Current.MainPage.DisplayAlert("Oh oh!", "Try a loyalty barcode next time!", "OK");
                    });
                }
            };
            overlay = new ZXingDefaultOverlay
            {
                TopText = "Hold your phone up to the barcode",
                BottomText = "Scanning will happen automatically",
                ShowFlashButton = zxing.HasTorch,
                AutomationId = "zxingDefaultOverlay",
            };
            overlay.FlashButtonClicked += (sender, e) =>
            {
                zxing.IsTorchOn = !zxing.IsTorchOn;
            };
            var grid = new Grid
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            grid.Children.Add(zxing);
            grid.Children.Add(overlay);

            // The root page of your application
            Content = grid;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            vm = this.BindingContext as LoyaltyScannerViewModel;
            zxing.IsScanning = true;
        }

        protected override void OnDisappearing()
        {
            zxing.IsScanning = false;

            base.OnDisappearing();
        }
    }
}