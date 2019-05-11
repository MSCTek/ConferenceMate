namespace QuikRide.ExternalAPIModels.What3WordsModel
{
    public class Bounds
    {
        public Northeast northeast { get; set; }
        public Southwest southwest { get; set; }
    }

    public class Crs
    {
        public Properties properties { get; set; }
        public string type { get; set; }
    }

    public class Geometry
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Northeast
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Properties
    {
        public string href { get; set; }
        public string type { get; set; }
    }

    public class RootObject
    {
        public Bounds bounds { get; set; }
        public Crs crs { get; set; }
        public Geometry geometry { get; set; }
        public string language { get; set; }
        public string map { get; set; }
        public Status status { get; set; }
        public string thanks { get; set; }
        public string words { get; set; }
    }

    public class Southwest
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Status
    {
        public string reason { get; set; }
        public int status { get; set; }
    }
}