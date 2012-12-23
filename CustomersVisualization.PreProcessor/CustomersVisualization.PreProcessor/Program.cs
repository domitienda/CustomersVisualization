using System;
using System.Collections.Generic;

namespace CustomersVisualization.PreProcessor
{
    public class Program
    {
        /// <summary>
        /// Author: Jacob Mendoza :: jacob.mendoza at domitienda.com
        /// Script to process the customers database records and adequate its contents
        /// to generate a file suitable for be processed with CartoDB.com.
        /// </summary>
        static void Main()
        {
            var processResult = new List<ProcessedRecord>();
            var originalFileReader = new OriginalFileReader();
            var googleMapsGeolocalization = new GoogleMapsGeolocalizationService();
            var cachedGoogleMapsGeolocalization = new CachedGoogleMapsGeolocalizationService(googleMapsGeolocalization);

            var originalParseResult = originalFileReader.ReadInitialFile();

            foreach (var originalRecord in originalParseResult)
            {
                GeolocalizationResult geolocResult =
                    cachedGoogleMapsGeolocalization.PerformGeolocalization(
                    new GeolocalizationCommand
                    {
                        Town = originalRecord.Town,
                        Country = originalRecord.Country
                    });

                processResult.Add(new ProcessedRecord(originalRecord)
                {
                    Geolocalization = geolocResult
                });

                Console.WriteLine("Cache Hits: {0} - Cache Misses: {1}", 
                    cachedGoogleMapsGeolocalization.CacheHits, cachedGoogleMapsGeolocalization.CacheMiss);
            }

            var writer = new FinalResultWriter();
            writer.WriteFile(processResult);
        }      
    }
}
