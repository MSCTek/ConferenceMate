namespace QuikRide.Mappers
{
    public static class CustomMapper
    {
        public static ModelsObj.GeofenceActivity ToModelObj(this ModelsData.GeofenceActivity source)
        {
            return new ModelsObj.GeofenceActivity()
            {
                ActivityUtcDateTime = source.ActivityUtcDateTime,
                GeofenceActivityId = source.GeofenceActivityId,
                Region = source.Region,
                Status = source.Status,
                Latitude = source.Latitude,
                Longitude = source.Longitude,
            };
        }
    }
}