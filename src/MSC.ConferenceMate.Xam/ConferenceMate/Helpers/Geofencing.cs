using System;

//see https://github.com/aritchie/geofences
//couldn't make it work with Xamarin.Essentials

namespace QuikRide.Helpers.Geofencing
{
    public enum GeofenceStatus
    {
        Unknown = 0,
        Inside = 1,
        Outside = 2
    }

    public static class PositionUtils
    {
        public static bool IsPositionInside(this GeofenceRegion region, Position position)
        {
            var distance = region.Center.GetDistanceTo(position);
            var inside = distance.TotalMeters <= region.Radius.TotalMeters;
            return inside;
        }
    }

    public sealed class Distance
    {
        public const int KM_TO_METERS = 1000;
        public const double KM_TO_MILES = 0.621371;
        public const double MILES_TO_KM = 1.60934;
        public double TotalKilometers { get; set; }
        public double TotalMeters => this.TotalKilometers * 1000;
        public double TotalMiles => this.TotalKilometers * KM_TO_MILES;

        public static Distance FromKilometers(double km)
        {
            return new Distance
            {
                TotalKilometers = km
            };
        }

        public static Distance FromMeters(double meters)
        {
            return new Distance
            {
                TotalKilometers = meters / KM_TO_METERS
            };
        }

        public static Distance FromMiles(int miles)
        {
            return new Distance
            {
                TotalKilometers = miles * MILES_TO_KM
            };
        }

        public static bool operator !=(Distance x, Distance y)
        {
            return x.TotalKilometers != y.TotalKilometers;
        }

        public static bool operator <(Distance x, Distance y)
        {
            return x.TotalKilometers < y.TotalKilometers;
        }

        public static bool operator ==(Distance x, Distance y)
        {
            return x.TotalKilometers == y.TotalKilometers;
        }

        public static bool operator >(Distance x, Distance y)
        {
            return x.TotalKilometers > y.TotalKilometers;
        }

        public override bool Equals(object obj)
        {
            var other = obj as Distance;
            if (other == null)
                return false;

            if (this.TotalKilometers.Equals(other.TotalKilometers))
                return false;

            return false;
        }

        public override int GetHashCode()
        {
            return this.TotalKilometers.GetHashCode();
        }

        public override string ToString()
        {
            return $"{this.TotalKilometers} KM";
        }
    }

    public class GeofenceRegion
    {
        public GeofenceRegion(string identifier, Position center, Distance radius)
        {
            this.Identifier = identifier;
            this.Center = center;
            this.Radius = radius;
        }

        public Position Center { get; }
        public string Identifier { get; }
        public Distance Radius { get; }
    }

    public class Position
    {
        private double latitude;

        private double longitude;

        public Position()
        {
        }

        public Position(double lat, double lng)
        {
            this.Latitude = lat;
            this.Longitude = lng;
        }

        public double Latitude
        {
            get => this.latitude;
            set
            {
                if (value < -90 || value > 90)
                    throw new ArgumentException($"Invalid latitude value - {value}");

                this.latitude = value;
            }
        }

        public double Longitude
        {
            get => this.longitude;
            set
            {
                if (value < -180 || value > 180)
                    throw new ArgumentException($"Invalid longitude value - {value}");

                this.longitude = value;
            }
        }

        public Distance GetDistanceTo(Position other)
        {
            var d1 = this.Latitude * (Math.PI / 180.0);
            var num1 = this.Longitude * (Math.PI / 180.0);
            var d2 = other.Latitude * (Math.PI / 180.0);
            var num2 = other.Longitude * (Math.PI / 180.0) - num1;
            var d3 = Math.Pow(Math.Sin((d2 - d1) / 2.0), 2.0) +
                     Math.Cos(d1) * Math.Cos(d2) * Math.Pow(Math.Sin(num2 / 2.0), 2.0);

            var meters = 6376500.0 * (2.0 * Math.Atan2(Math.Sqrt(d3), Math.Sqrt(1.0 - d3)));
            return Distance.FromMeters(meters);
        }

        public override string ToString() => $"Latitude: {this.Latitude} - Longitude: {this.Longitude}";
    }
}