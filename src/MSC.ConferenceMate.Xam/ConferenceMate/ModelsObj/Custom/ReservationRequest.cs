using GalaSoft.MvvmLight;
using System;

namespace QuikRide.ModelsObj
{
    public partial class ReservationRequest : ObservableObject
    {
        public string ArrivalDisplay
        {
            get
            {
                if (HasArrivalTime)
                {
                    return $"{((DateTime)RequestedArrivalStart).ToString("h:mm tt")} - {((DateTime)RequestedArrivalEnd).ToString("h:mm tt")}";
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        public bool HasArrivalTime { get { return RequestedArrivalStart == null ? false : true; } }
        public bool HasPickupTime { get { return RequestedPickupStart == null ? false : true; } }

        public string PickupDisplay
        {
            get
            {
                if (HasPickupTime)
                {
                    return $"{((DateTime)RequestedPickupStart).ToString("h:mm tt")} - {((DateTime)RequestedPickupEnd).ToString("h:mm tt")}";
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        public string RequestDateDisplay
        {
            get
            {
                if (HasPickupTime)
                {
                    return $"{((DateTime)RequestedPickupStart).ToString("dddd, MMMM d, yyyy")}";
                }
                else if (HasArrivalTime)
                {
                    return $"{((DateTime)RequestedArrivalStart).ToString("dddd, MMMM d, yyyy")}";
                }
                else
                {
                    return string.Empty;
                }
            }
        }
    }
}