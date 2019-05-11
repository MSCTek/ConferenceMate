using CGH.QuikRide.Xam.ModelObj.QR;
using GalaSoft.MvvmLight.Command;
using Microsoft.AppCenter.Crashes;
using QuikRide.Interfaces;
using QuikRide.Mappers;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace QuikRide.ViewModels
{
    public class FeedbackViewModel : CustomViewModelBase
    {
        private string _description;
        private ObservableCollection<FeedbackType> _feedbackTypeList;
        private FeedbackType _selectedFeedbackType;
        private Vehicle _selectedVehicle;
        private string _title;
        private ObservableCollection<Vehicle> _vehicleList;

        public FeedbackViewModel(INavigationService navService, IDataLoadService dataLoadService, IDataRetrievalService dataRetrievalService) :
            base(navService, dataLoadService, dataRetrievalService)
        {
        }

        public string Description
        {
            get { return _description; }
            set { Set(nameof(Description), ref _description, value); }
        }

        public ObservableCollection<FeedbackType> FeedbackTypeList
        {
            get { return _feedbackTypeList; }
            set { Set(nameof(FeedbackTypeList), ref _feedbackTypeList, value); }
        }

        public FeedbackType SelectedFeedbackType
        {
            get { return _selectedFeedbackType; }
            set { Set(nameof(SelectedFeedbackType), ref _selectedFeedbackType, value); }
        }

        public Vehicle SelectedVehicle
        {
            get { return _selectedVehicle; }
            set { Set(nameof(SelectedVehicle), ref _selectedVehicle, value); }
        }

        public RelayCommand SubmitFeedbackCommand
        {
            get
            {
                return new RelayCommand(async () =>
                {
                    try
                    {
                        //build up a feedback data model - we don't need to build an obj model as this will go right into SQLite
                        var feedbackData = new CGH.QuikRide.Xam.ModelData.QR.Feedback()
                        {
                            CreatedBy = "CurrentUser",
                            CreatedUtcDate = DateTime.UtcNow,
                            DataVersion = 1,
                            Description = Description,
                            Dispositioned = false,
                            FeedbackId = Guid.NewGuid(),
                            FeedbackTypeId = SelectedFeedbackType.FeedbackTypeId,
                            IsDeleted = false,
                            ModifiedBy = "CurrentUser",
                            ModifiedUtcDate = DateTime.UtcNow,
                            Title = Title,
                            Latitude = 0D,
                            Longitude = 0D,
                            UserId = DataRetrievalService.GetCurrentUserId(),
                            //TODO: DriverId,
                            DriverId = null,
                            FeedbackInitiatorTypeId = 1, //customer
                            Source = "Mobile App",
                            VehicleId = null
                        };

                        if (SelectedVehicle != null)
                        {
                            feedbackData.VehicleId = SelectedVehicle.VehicleId;
                        }

                        if (location != null && location.Latitude != 0D && location.Longitude != 0D)
                        {
                            feedbackData.Longitude = location.Longitude;
                            feedbackData.Latitude = location.Latitude;
                        }

                        //Write the data to SQLite
                        if (1 == await DataRetrievalService.WriteFeedbackRecord(feedbackData))
                        {
                            //Queue up the record for upload to the Azure Database
                            await DataRetrievalService.QueueAsync(feedbackData.FeedbackId, QueueableObjects.Feedback);
                            //See if right now is a good time to upload the data - 10 records at a time
                            DataRetrievalService.StartSafeQueuedUpdates();
                        }

                        //say thanks!
                        await Application.Current.MainPage.DisplayAlert("Thanks!", "We got your feedback!", "OK");

                        //navigate back to the home
                        //but don't do it this way - this will add another page to the navigation stack!
                        //await NavService.NavigateTo<HomeViewModel>();
                        await NavService.PopToRoot();
                    }
                    catch (Exception ex)
                    {
                        Crashes.TrackError(ex);
                        await Application.Current.MainPage.DisplayAlert("Error", "Something happened, we may not have recieved your feedback!", "OK");
                    }
                });
            }
        }

        public string Title
        {
            get { return _title; }
            set { Set(nameof(Title), ref _title, value); }
        }

        public ObservableCollection<Vehicle> VehicleList
        {
            get { return _vehicleList; }
            set { Set(nameof(VehicleList), ref _vehicleList, value); }
        }

        private Xamarin.Essentials.Location location { get; set; }

        public override async Task Init()
        {
            FeedbackTypeList = (await DataRetrievalService.GetAllFeedbackTypes()).ToObservableCollection();
            VehicleList = (await DataRetrievalService.GetAllVehicles()).ToObservableCollection();

            if (FeedbackTypeList.Any())
            {
                SelectedFeedbackType = FeedbackTypeList[0];
            }

            //SelectedVehicle = VehicleList[0];

            //use this opportunity to grab the long/lat.
            var request = new GeolocationRequest(GeolocationAccuracy.Medium);
            var locationRealtime = await Geolocation.GetLocationAsync(request);
            location = (locationRealtime == null) ? await Geolocation.GetLastKnownLocationAsync() : locationRealtime;
        }
    }
}