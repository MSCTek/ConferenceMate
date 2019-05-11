using QuikRide.ModelsObj;
using System;

namespace QuikRide.SampleObjModels
{
    public static class SampleReservationRequest
    {
        public static ReservationRequest Sample1
        {
            get
            {
                return new ReservationRequest()
                {
                    DestinationLocation = SampleLocation.SampleCosleyZoo,
                    DestinationLocationId = SampleLocation.CosleyZooId,
                    PickupLocation = SampleLocation.SampleHome,
                    PickupLocationId = SampleLocation.HomeId,
                    RequestedArrivalEnd = DateTime.Now.Date.AddDays(4).AddHours(9d), //9am, four days from now
                    RequestedArrivalStart = DateTime.Now.Date.AddDays(4).AddHours(8d), //8am, four days from now
                    RequestedPickupEnd = DateTime.Now.Date.AddDays(4).AddHours(9d),
                    RequestedPickupStart = DateTime.Now.Date.AddDays(4).AddHours(8d),
                    ReservationRequestCancellationReasonTypeId = 0,
                    ReservationRequestId = Guid.NewGuid(),
                    ReservationRequestStatusTypeId = 0,
                    CreatedBy = "admin",
                    CreatedUtcDate = DateTime.UtcNow,
                    ModifiedBy = "admin",
                    ModifiedUtcDate = DateTime.UtcNow,
                };
            }
        }

        public static ReservationRequest Sample2
        {
            get
            {
                return new ReservationRequest()
                {
                    PickupLocation = SampleLocation.SampleCosleyZoo,
                    PickupLocationId = SampleLocation.CosleyZooId,
                    DestinationLocation = SampleLocation.SampleHome,
                    DestinationLocationId = SampleLocation.HomeId,
                    RequestedPickupEnd = DateTime.Now.Date.AddDays(4).AddHours(15d), //3pm, four days from now
                    RequestedPickupStart = DateTime.Now.Date.AddDays(4).AddHours(16d), //4pm, four days from now
                    RequestedArrivalEnd = DateTime.Now.Date.AddDays(4).AddHours(15d),
                    RequestedArrivalStart = DateTime.Now.Date.AddDays(4).AddHours(16d),
                    ReservationRequestCancellationReasonTypeId = 0,
                    ReservationRequestId = Guid.NewGuid(),
                    ReservationRequestStatusTypeId = 0,
                    CreatedBy = "admin",
                    CreatedUtcDate = DateTime.UtcNow,
                    ModifiedBy = "admin",
                    ModifiedUtcDate = DateTime.UtcNow,
                };
            }
        }
    }
}