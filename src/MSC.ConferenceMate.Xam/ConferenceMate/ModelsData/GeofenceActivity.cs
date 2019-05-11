using SQLite;
using System;

namespace QuikRide.ModelsData
{
    [Table("GeofenceActivity")]
    public class GeofenceActivity
    {
        public DateTime ActivityUtcDateTime { get; set; }

        [PrimaryKey]
        public Guid GeofenceActivityId { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string Region { get; set; }

        public string Status { get; set; }
    }
}