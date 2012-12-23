using System;
using Newtonsoft.Json.Linq;

namespace CustomersVisualization.PreProcessor
{
    public class GoogleMapsGeolocalizationServiceParser
    {
        private const string Results = "results";
        private const string Geometry = "geometry";
        private const string Location = "location";
        private const string Latitude = "lat";
        private const string Longitude = "lng";

        public GeolocalizationResult ParseJsonText(string text)
        {
            var mainObject = JObject.Parse(text);
            var results = (JArray)mainObject[Results];

            foreach (var result in results)
            {
                var geometry = (JObject)result[Geometry];
                var location = (JObject)geometry[Location];

                return new GeolocalizationResult
                {
                    Latitude = double.Parse(location[Latitude].ToString()),
                    Longitude = double.Parse(location[Longitude].ToString())
                };
            }

            throw new Exception("Can't parse Google's json text");
        }

    }
}
