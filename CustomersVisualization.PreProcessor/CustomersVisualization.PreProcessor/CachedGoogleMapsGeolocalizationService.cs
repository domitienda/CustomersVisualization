using System;
using System.Collections.Generic;

namespace CustomersVisualization.PreProcessor
{
    public class CachedGoogleMapsGeolocalizationService
    {
        private const int TimeAfterQuery = 1000;
        private readonly GoogleMapsGeolocalizationService _service;
        private readonly Dictionary<GeolocalizationCommand, GeolocalizationResult> _poorManCache;

        public int CacheHits { get; private set; }
        public int CacheMiss { get; private set; }

        public CachedGoogleMapsGeolocalizationService(GoogleMapsGeolocalizationService service)
        {
            _service = service;
            _poorManCache = new Dictionary<GeolocalizationCommand, GeolocalizationResult>();
        }

        public GeolocalizationResult PerformGeolocalization(GeolocalizationCommand command)
        {
            if (_poorManCache.ContainsKey(command))
            {
                CacheHits++;
                return _poorManCache[command];
            }

            var result = _service.PerformGeolocalization(command);
            System.Threading.Thread.Sleep(TimeAfterQuery);

            if (result.HasSomething)
            {
                CacheMiss++;
                _poorManCache.Add(command, result);
                return result;
            }

            throw new Exception("Invalid geolocalization");
        }
    }
}
