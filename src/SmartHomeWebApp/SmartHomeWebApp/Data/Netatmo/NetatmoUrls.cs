namespace Thermometer.Netatmo
{
    public static class NetatmoUrls
    {
        public static string AuthorizeUrl => $"{UrlBase}{UrlRequestAuthorizePath}";
        public static string RequestTokenUrl => $"{UrlBase}{UrlRequestTokenPath}";
        public static string GetStationsDataUrl => $"{UrlBase}{UrlGetStationsData}";
        public static string GetMeasureUrl => $"{UrlBase}{UrlGetMeasuree}";
        public static string GetPublicDataUrl => $"{UrlBase}{UrlGetPublicData}";

        private static readonly string UrlBase = "https://api.netatmo.com";
        private static readonly string UrlRequestAuthorizePath = "/oauth2/authorize";
        private static readonly string UrlRequestTokenPath = "/oauth2/token";
        private static readonly string UrlGetStationsData = "/api/getstationsdata";
        private static readonly string UrlGetMeasuree = "/api/getmeasure";
        private static readonly string UrlGetPublicData = "/api/getpublicdata";
    }
}
