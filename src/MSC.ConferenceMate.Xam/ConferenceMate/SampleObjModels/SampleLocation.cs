using QuikRide.ModelsObj;
using System;

namespace QuikRide.SampleObjModels
{
    public static class SampleLocation
    {
        public static Guid CosleyZooId = new Guid("1346b2c7-3da8-4c5a-925f-a63cea876fc4");

        public static Guid HomeId = new Guid("d73a1a5c-8cc4-431c-b361-99bea0266996");

        public static Guid RockinJumpId = new Guid("2148610a-0960-4351-bcad-c0e9279dc6bf");

        public static Guid SafariLandId = new Guid("8789fa57-0bac-44b7-9bc6-6ec73bbbe420");

        public static Location SampleCosleyZoo
        {
            get
            {
                return new Location()
                {
                    LocationId = CosleyZooId,
                    AddressLine1 = "1356 N. Gary Ave",
                    AddressLine2 = "",
                    City = "Wheaton",
                    State = "IL",
                    Name = "Cosley Zoo",
                    Latitude = 41.8970371f,
                    Longitude = -88.1511085f,
                    CreatedBy = "admin",
                    CreatedUtcDate = DateTime.UtcNow,
                    ModifiedBy = "admin",
                    ModifiedUtcDate = DateTime.UtcNow,
                    PostalCode = "60187"
                };
            }
        }

        public static Location SampleHome
        {
            get
            {
                return new Location()
                {
                    LocationId = HomeId,
                    AddressLine1 = "340 Evergreen Ave.",
                    AddressLine2 = "",
                    City = "Glen Ellyn",
                    State = "IL",
                    Name = "Home",
                    Latitude = 41.8739897f,
                    Longitude = -88.0780937f,
                    CreatedBy = "admin",
                    CreatedUtcDate = DateTime.UtcNow,
                    ModifiedBy = "admin",
                    ModifiedUtcDate = DateTime.UtcNow,
                    PostalCode = "60137"
                };
            }
        }

        public static Location SampleRockinJump
        {
            get
            {
                return new Location()
                {
                    LocationId = RockinJumpId,
                    AddressLine1 = "485 Mission St",
                    AddressLine2 = "",
                    City = "Carol Stream",
                    State = "IL",
                    Name = "Rockiin' Jump Tramoline Park",
                    Latitude = 41.940801f,
                    Longitude = -88.1252501f,
                    CreatedBy = "admin",
                    CreatedUtcDate = DateTime.UtcNow,
                    ModifiedBy = "admin",
                    ModifiedUtcDate = DateTime.UtcNow,
                    PostalCode = "60188"
                };
            }
        }

        public static Location SampleSafariLand
        {
            get
            {
                return new Location()
                {
                    LocationId = SafariLandId,
                    AddressLine1 = "701 W. North Ave",
                    AddressLine2 = "",
                    City = "Villa Park",
                    State = "IL",
                    Name = "Safari Land",
                    Latitude = 41.9093015f,
                    Longitude = -87.9391708f,
                    CreatedBy = "admin",
                    CreatedUtcDate = DateTime.UtcNow,
                    ModifiedBy = "admin",
                    ModifiedUtcDate = DateTime.UtcNow,
                    PostalCode = "60181"
                };
            }
        }
    }
}