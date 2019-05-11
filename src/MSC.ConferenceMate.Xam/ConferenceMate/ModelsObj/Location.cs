using GalaSoft.MvvmLight;
using System;

namespace QuikRide.ModelsObj
{
    public partial class Location : ObservableObject
    {
        private string _addressLine1;
        private string _addressLine2;
        private string _city;
        private string _createdBy;
        private DateTime _createdUtcDate;
        private bool _isDeleted;
        private double? _latitude;
        private Guid _locationId;
        private double? _longitude;
        private string _modifiedBy;
        private DateTime _modifiedUtcDate;
        private string _name;
        private string _postalCode;
        private string _state;

        public string AddressLine1
        {
            get { return _addressLine1; }
            set { Set(() => AddressLine1, ref _addressLine1, value); }
        }

        public string AddressLine2
        {
            get { return _addressLine2; }
            set { Set(() => AddressLine2, ref _addressLine2, value); }
        }

        public string City
        {
            get { return _city; }
            set { Set(() => City, ref _city, value); }
        }

        public string CreatedBy
        {
            get { return _createdBy; }
            set { Set(() => CreatedBy, ref _createdBy, value); }
        }

        public DateTime CreatedUtcDate
        {
            get { return _createdUtcDate; }
            set { Set(() => CreatedUtcDate, ref _createdUtcDate, value); }
        }

        public bool IsDeleted
        {
            get { return _isDeleted; }
            set { Set(() => IsDeleted, ref _isDeleted, value); }
        }

        public double? Latitude
        {
            get { return _latitude; }
            set { Set(() => Latitude, ref _latitude, value); }
        }

        public Guid LocationId
        {
            get { return _locationId; }
            set { Set(nameof(LocationId), ref _locationId, value); }
        }

        public double? Longitude
        {
            get { return _longitude; }
            set { Set(() => Longitude, ref _longitude, value); }
        }

        public string ModifiedBy
        {
            get { return _modifiedBy; }
            set { Set(() => ModifiedBy, ref _modifiedBy, value); }
        }

        public DateTime ModifiedUtcDate
        {
            get { return _modifiedUtcDate; }
            set { Set(() => ModifiedUtcDate, ref _modifiedUtcDate, value); }
        }

        public string Name
        {
            get { return _name; }
            set { Set(() => Name, ref _name, value); }
        }

        public string PostalCode
        {
            get { return _postalCode; }
            set { Set(() => PostalCode, ref _postalCode, value); }
        }

        public string State
        {
            get { return _state; }
            set { Set(() => State, ref _state, value); }
        }
    }
}