using GalaSoft.MvvmLight;
using System;

namespace QuikRide.ModelsObj
{
    public class GeofenceActivity : ObservableObject
    {
        private DateTime _activityUtcDateTime;
        private Guid _geofenceActivityId;
        private double _latitude;
        private double _longitude;
        private string _region;
        private string _status;

        public DateTime ActivityUtcDateTime
        {
            get { return _activityUtcDateTime; }
            set { Set<DateTime>(() => ActivityUtcDateTime, ref _activityUtcDateTime, value); }
        }

        public string DisplayGeofenceActivity
        {
            get
            {
                return $"{ActivityUtcDateTime.ToLocalTime().ToShortDateString()} {ActivityUtcDateTime.ToLocalTime().ToLongTimeString()} - {Region} - {Status}";
            }
        }
        public string DisplayGeofenceActivityDateTime
        {
            get
            {
                return $"{ActivityUtcDateTime.ToLocalTime().ToShortDateString()} {ActivityUtcDateTime.ToLocalTime().ToLongTimeString()}";
            }
        }
        public string DisplayGeofenceActivityRegionStatus
        {
            get
            {
                return $"{Region} - {Status}";
            }
        }



public Guid GeofenceActivityId
        {
            get { return _geofenceActivityId; }
            set { Set<Guid>(() => GeofenceActivityId, ref _geofenceActivityId, value); }
        }

        public double Latitude
        {
            get { return _latitude; }
            set { Set<double>(() => Latitude, ref _latitude, value); }
        }

        public double Longitude
        {
            get { return _longitude; }
            set { Set<double>(() => Longitude, ref _longitude, value); }
        }

        public string Region
        {
            get { return _region; }
            set { Set<string>(() => Region, ref _region, value); }
        }

        public string Status
        {
            get { return _status; }
            set { Set<string>(() => Status, ref _status, value); }
        }
    }
}