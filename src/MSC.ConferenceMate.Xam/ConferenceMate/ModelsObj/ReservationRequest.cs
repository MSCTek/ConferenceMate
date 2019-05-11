using GalaSoft.MvvmLight;
using System;

namespace QuikRide.ModelsObj
{
    public partial class ReservationRequest : ObservableObject
    {
        private string _createdBy;
        private DateTime _createdUtcDate;
        private Location _destinationLocation;
        private Guid _destinationLocationId;
        private bool _isDeleted;
        private string _modifiedBy;
        private DateTime _modifiedUtcDate;
        private Location _pickupLocation;
        private Guid _pickupLocationId;
        private DateTime? _requestedArrivalEnd;
        private DateTime? _requestedArrivalStart;
        private DateTime? _requestedPickupEnd;
        private DateTime? _requestedPickupStart;
        private int? _reservationRequestCancellationReasonTypeId;
        private Guid _reservationRequestId;
        private int _reservationRequestStatusTypeId;

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

        public Location DestinationLocation
        {
            get { return _destinationLocation; }
            set { Set(nameof(DestinationLocation), ref _destinationLocation, value); }
        }

        public Guid DestinationLocationId
        {
            get { return _destinationLocationId; }
            set { Set(nameof(DestinationLocationId), ref _destinationLocationId, value); }
        }

        public bool IsDeleted
        {
            get { return _isDeleted; }
            set { Set(() => IsDeleted, ref _isDeleted, value); }
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

        public Location PickupLocation
        {
            get { return _pickupLocation; }
            set { Set(nameof(PickupLocation), ref _pickupLocation, value); }
        }

        public Guid PickupLocationId
        {
            get { return _pickupLocationId; }
            set { Set(nameof(PickupLocationId), ref _pickupLocationId, value); }
        }

        public DateTime? RequestedArrivalEnd
        {
            get { return _requestedArrivalEnd; }
            set { Set(() => RequestedArrivalEnd, ref _requestedArrivalEnd, value); }
        }

        public DateTime? RequestedArrivalStart
        {
            get { return _requestedArrivalStart; }
            set { Set(() => RequestedArrivalStart, ref _requestedArrivalStart, value); }
        }

        public DateTime? RequestedPickupEnd
        {
            get { return _requestedPickupEnd; }
            set { Set(() => RequestedPickupEnd, ref _requestedPickupEnd, value); }
        }

        public DateTime? RequestedPickupStart
        {
            get { return _requestedPickupStart; }
            set { Set(() => RequestedPickupStart, ref _requestedPickupStart, value); }
        }

        public int? ReservationRequestCancellationReasonTypeId
        {
            get { return _reservationRequestCancellationReasonTypeId; }
            set { Set(() => ReservationRequestCancellationReasonTypeId, ref _reservationRequestCancellationReasonTypeId, value); }
        }

        public Guid ReservationRequestId
        {
            get { return _reservationRequestId; }
            set { Set(nameof(ReservationRequestId), ref _reservationRequestId, value); }
        }

        public int ReservationRequestStatusTypeId
        {
            get { return _reservationRequestStatusTypeId; }
            set { Set(() => ReservationRequestStatusTypeId, ref _reservationRequestStatusTypeId, value); }
        }
    }
}