namespace QuikRide
{
    public static class Config
    //public static class ConfigPublic
    {
#if DEV
        public static string AppCenterDroid = string.Empty;
        public static string AppCenterIOS = string.Empty;
        public static string AppCenterUWP = string.Empty;
        public static string BingMapsKey = string.Empty;
        public static string What3WordsBaseUrl = "https://api.what3words.com/v2/";
        public static string What3WordsAPIKey = string.Empty;
        public static string BaseWebApiUrl = string.Empty;
#elif QA
        public static string AppCenterDroid = string.Empty;
        public static string AppCenterIOS = string.Empty;
        public static string AppCenterUWP = string.Empty;
        public static string BingMapsKey = string.Empty;
#elif PROD
        public static string AppCenterDroid = string.Empty;
        public static string AppCenterIOS = string.Empty;
        public static string AppCenterUWP = string.Empty;
        public static string BingMapsKey = string.Empty;
#else
        public static string AppCenterDroid = string.Empty;
        public static string AppCenterIOS = string.Empty;
        public static string AppCenterUWP = string.Empty;
        public static string BingMapsKey = string.Empty;
#endif
    }
}