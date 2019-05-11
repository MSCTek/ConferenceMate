using GalaSoft.MvvmLight.Command;
using QuikRide.Interfaces;
using QuikRide.ModelsObj;
using QuikRide.SampleObjModels;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace QuikRide.ViewModels
{
    public class MyReservationRequestsViewModel : CustomViewModelBase
    {
        private ObservableCollection<ReservationRequest> _myRequests;

        public MyReservationRequestsViewModel(INavigationService navService, IDataLoadService dataLoadService, IDataRetrievalService dataRetrievalService)
            : base(navService, dataLoadService, dataRetrievalService)
        {
            MyRequests = new ObservableCollection<ReservationRequest>();
        }

        public RelayCommand<Guid> CancelCommand
        {
            get
            {
                return new RelayCommand<Guid>(async (id) =>
                {
                    //TODO: rts cancel
                    await Application.Current.MainPage.DisplayAlert("TODO",
                        $"Write code to cancel this reservation: {id}!", "OK");
                });
            }
        }

        public RelayCommand<Location> MapCommand
        {
            get
            {
                return new RelayCommand<Location>((location) =>
                {
                    LaunchMapApp(location);
                });
            }
        }

        public ObservableCollection<ReservationRequest> MyRequests
        {
            get { return _myRequests; }
            set { Set(() => MyRequests, ref _myRequests, value); }
        }

        public override async Task Init()
        {
            //we usually do async calls here to get data here, but sample data is call synchronously
            MyRequests = new ObservableCollection<ReservationRequest>()
            {
                SampleReservationRequest.Sample1,
                SampleReservationRequest.Sample2
            };
        }

        public void LaunchMapApp(Location location)
        {
            string name = string.Empty;
            // Windows Phone doesn't like ampersands in the names and the normal URI escaping doesn't help
            if (location.Name.ToLower() != "home")
            {
                name = location.Name.Replace("&", "and"); // var name = Uri.EscapeUriString(place.Name);
            }
            var loc = string.Format("{0},{1}", location.Latitude, location.Longitude);
            var addr = Uri.EscapeUriString($"{location.AddressLine1},{location.City},{location.State} {location.PostalCode}");

            string request = string.Empty;

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    // iOS doesn't like %s or spaces in their URLs, so manually replace spaces with +s
                    request = string.Format("http://maps.apple.com/maps?q={0}&sll={1}", name.Replace(' ', '+'), loc);
                    break;

                case Device.Android:
                    // pass the address to Android if we have it
                    request = string.Format("geo:0,0?q={0}({1})", string.IsNullOrWhiteSpace(addr) ? loc : addr, name);
                    break;

                case Device.UWP:
                    request = string.Format("bingmaps:?cp={0}&q={1}", loc, name);
                    break;
            };

            Device.OpenUri(new Uri(request));
        }
    }
}