using CGH.QuikRide.Xam.ModelData.QR;
using System;

namespace QuikRide.SampleDataModels
{
    public static class SampleReservationRequest
    {
        public static ReservationRequest SampleFabyanToArtInstitute
        {
            get
            {
                return new ReservationRequest()
                {
                    DestinationLocationId = SampleLocation.ArtInstituteChicagoId,
                    PickupLocationId = SampleLocation.FabyanVillaMuseumId,
                    RequestedArrivalEnd = DateTime.Now.Date.AddDays(2).AddHours(9d), //9am, two days from now
                    RequestedArrivalStart = DateTime.Now.Date.AddDays(2).AddHours(8d), //8am,two days from now
                    RequestedPickupEnd = DateTime.Now.Date.AddDays(2).AddHours(9d),
                    RequestedPickupStart = DateTime.Now.Date.AddDays(2).AddHours(8d),
                    ReservationRequestCancellationReasonTypeId = 0,
                    ReservationRequestId = Guid.NewGuid(),
                    ReservationRequestStatusTypeId = 0,
                    CreatedBy = "admin",
                    CreatedUtcDate = DateTime.UtcNow,
                    ModifiedBy = "admin",
                    ModifiedUtcDate = DateTime.UtcNow,
                    ReservationId = new Guid()
                };
            }
        }
    }
}