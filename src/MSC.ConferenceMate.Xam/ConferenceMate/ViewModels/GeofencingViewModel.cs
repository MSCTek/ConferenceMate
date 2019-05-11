using GalaSoft.MvvmLight.Command;
using QuikRide.Helpers.Geofencing;
using QuikRide.Interfaces;
using QuikRide.Mappers;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace QuikRide.ViewModels
{
    public class GeofencingViewModel : CustomViewModelBase
    {
        private ObservableCollection<GeofenceRegion> _myMonitoredRegions;
        private ObservableCollection<ModelsObj.GeofenceActivity> _recentGeofenceActivity;
        private bool isRunning;

        public GeofencingViewModel(INavigationService navService, IDataLoadService dataLoadService, IDataRetrievalService dataRetrievalService) : base(navService, dataLoadService, dataRetrievalService)
        {
            MyMonitoredRegions = new ObservableCollection<GeofenceRegion>();
            RecentGeofenceActivity = new ObservableCollection<ModelsObj.GeofenceActivity>();
        }

        public RelayCommand AddCurrentLocationGeofenceCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if (currentLocation != null && currentLocation.Latitude != 0D && currentLocation.Longitude != 0D)
                    {
                        MyMonitoredRegions.Add(new GeofenceRegion(
                            "CurrentLocation", // identifier - must be unique per registered geofence
                            new Position(currentLocation.Latitude, currentLocation.Longitude), // center point
                            Distance.FromMeters(50) // radius of fence
                        ));
                    }
                });
            }
        }

        public RelayCommand AddFoxBuildGeofenceCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    MyMonitoredRegions.Add(new GeofenceRegion(
                        "Fox.Build", // identifier - must be unique per registered geofence
                        new Position(41.9136805, -88.3127193), // center point
                        Distance.FromMeters(50) // radius of fence
                    ));
                });
            }
        }

        public RelayCommand AddTasteOfHimalayasGeofenceCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    MyMonitoredRegions.Add(new GeofenceRegion(
                        "TasteOfHimalayas", // identifier - must be unique per registered geofence
                        new Position(41.9144739, -88.3168716), // center point
                        Distance.FromMeters(50) // radius of fence
                    ));
                });
            }
        }

        public ObservableCollection<GeofenceRegion> MyMonitoredRegions
        {
            get { return _myMonitoredRegions; }
            set { Set<ObservableCollection<GeofenceRegion>>(() => MyMonitoredRegions, ref _myMonitoredRegions, value); }
        }

        public ObservableCollection<ModelsObj.GeofenceActivity> RecentGeofenceActivity
        {
            get { return _recentGeofenceActivity; }
            set { Set<ObservableCollection<ModelsObj.GeofenceActivity>>(() => RecentGeofenceActivity, ref _recentGeofenceActivity, value); }
        }

        public RelayCommand RemoveAllGeofencesCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    MyMonitoredRegions.Clear();
                });
            }
        }

        private Position currentLocation { get; set; }

        public async void CheckGeofenceStatus()
        {
            if (!isRunning)
            {
                isRunning = true;
                await UpdateLocationAsync();
                foreach (var m in MyMonitoredRegions)
                {
                    RecordStatus(
                        m,
                        m.IsPositionInside(currentLocation) ? GeofenceStatus.Inside : GeofenceStatus.Outside
                    );
                }
                isRunning = false;
            }
        }

        public override async Task Init()
        {
            await UpdateLocationAsync();
            await RefreshRecentGeofenceStatus();
        }

        public async void RecordStatus(GeofenceRegion region, GeofenceStatus status)
        {
            var activity = new ModelsData.GeofenceActivity()
            {
                ActivityUtcDateTime = System.DateTime.UtcNow,
                Region = region.Identifier,
                Status = status.ToString(),
                GeofenceActivityId = System.Guid.NewGuid()
            };

            activity.Longitude = currentLocation.Longitude;
            activity.Latitude = currentLocation.Latitude;

            await DataRetrievalService.WriteGeofencingActivityRecord(activity);

            await RefreshRecentGeofenceStatus();
        }

        public async Task RefreshRecentGeofenceStatus()
        {
            RecentGeofenceActivity = (await DataRetrievalService.GetRecentGeofenceActivity(20)).ToObservableCollection();
        }

        private async Task UpdateLocationAsync()
        {
            //use this opportunity to grab the long/lat.
            var request = new GeolocationRequest(GeolocationAccuracy.Medium);
            var locationRealtime = await Geolocation.GetLocationAsync(request);
            if (locationRealtime == null)
            {
                var locationLastKnown = await Geolocation.GetLastKnownLocationAsync();
                currentLocation = new Position(locationLastKnown.Latitude, locationLastKnown.Longitude);
            }
            else
            {
                currentLocation = new Position(locationRealtime.Latitude, locationRealtime.Longitude);
            }
        }
    }
}