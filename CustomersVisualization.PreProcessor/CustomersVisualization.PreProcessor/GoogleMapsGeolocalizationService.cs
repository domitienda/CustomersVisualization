
using EasyHttp.Http;

namespace CustomersVisualization.PreProcessor
{
    public class GoogleMapsGeolocalizationService
    {
        private const string ServiceUrl = "http://maps.googleapis.com/maps/api/geocode/json?address={0}&sensor=false";

        public GeolocalizationResult PerformGeolocalization(GeolocalizationCommand command)
        {
            var http = new HttpClient
            {
                Request = { Accept = HttpContentTypes.ApplicationJson }
            };

            var builtUrl = string.Format(ServiceUrl, command);
            var response = http.Get(builtUrl);
            var parser = new GoogleMapsGeolocalizationServiceParser();
            return parser.ParseJsonText(response.RawText);
        }
    }
}
