using CGH.QuikRide.Xam.ModelData.QR;
using System;

namespace QuikRide.SampleDataModels
{
    public static class SampleLocation
    {
        public static Guid ArtInstituteChicagoId = new Guid("1346b2c7-3da8-4c5a-925f-a63cea876fc2");

        public static Guid FabyanVillaMuseumId = new Guid("1346b2c7-3da8-4c5a-925f-a63cea876fc3");

        public static Location SampleArtInstituteChicago
        {
            get
            {
                return new Location()
                {
                    LocationId = ArtInstituteChicagoId,
                    AddressLine1 = "111 S Michigan Ave",
                    AddressLine2 = "",
                    City = "Chicago",
                    State = "IL",
                    Name = "Art Institute of Chicago",
                    Latitude = 41.8795885f,
                    Longitude = -87.625902f,
                    CreatedBy = "admin",
                    CreatedUtcDate = DateTime.UtcNow,
                    ModifiedBy = "admin",
                    ModifiedUtcDate = DateTime.UtcNow,
                    PostalCode = "60603"
                };
            }
        }

        public static Location SampleFabyanVillaMuseum
        {
            get
            {
                return new Location()
                {
                    LocationId = FabyanVillaMuseumId,
                    AddressLine1 = "1925 S Batavia Ave",
                    AddressLine2 = "",
                    City = "Geneva",
                    State = "IL",
                    Name = "Fabyan Villa Museum & Japanese Garden",
                    Latitude = 41.871127f,
                    Longitude = -88.3122367f,
                    CreatedBy = "admin",
                    CreatedUtcDate = DateTime.UtcNow,
                    ModifiedBy = "admin",
                    ModifiedUtcDate = DateTime.UtcNow,
                    PostalCode = "60134"
                };
            }
        }
    }
}