using Microsoft.AppCenter.Analytics;
using MSC.CM.XaSh.ViewModels;
using Plugin.Media;
using Plugin.Media.Abstractions;
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
            //TODO: Navigation is via the view, not the viewmodel... rework this eventually.
            //BindingContext = viewModel = Startup.ServiceProvider?.GetService<MyProfileEditViewModel>() ?? new MyProfileEditViewModel();
        }

        protected async override void OnAppearing()
        {
            Analytics.TrackEvent("MyProfileEditPage");
            base.OnAppearing();

            //Workaround here
            BindingContext = viewModel = Startup.ServiceProvider?.GetService<MyProfileEditViewModel>() ?? new MyProfileEditViewModel();
            await Refresh();
        }

        private async void ExsitingPictureButton_Clicked(object sender, EventArgs e)
        {
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                return;
            }
            var file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
            });

            if (file == null)
                return;

            image.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;
            });
        }

        private async void NewPictureButton_Clicked(object sender, EventArgs e)
        {
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Test",
                SaveToAlbum = true,
                CompressionQuality = 75,
                CustomPhotoSize = 50,
                PhotoSize = PhotoSize.MaxWidthHeight,
                MaxWidthHeight = 2000,
                DefaultCamera = CameraDevice.Front
            });

            if (file == null)
                return;

            DisplayAlert("File Location", file.Path, "OK");

            image.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;
            });
        }

        private async Task Refresh()
        {
            await viewModel.LoadVM();
        }
    }
}