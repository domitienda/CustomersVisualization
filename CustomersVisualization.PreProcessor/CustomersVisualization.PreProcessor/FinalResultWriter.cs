using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace CustomersVisualization.PreProcessor
{
    public class FinalResultWriter
    {
        private const string FinalFileName = "GeolocResult.csv";

        public void WriteFile(IEnumerable<ProcessedRecord> processedRecords)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("EventDateTime;Town;Country;Lat;Lon");

            foreach (var processedRecord in processedRecords)
            {
                // Fix some errors that I found on the database, probably due
                // to test or similar.
                if (processedRecord.EventDateTime > DateTime.Now)
                    continue;

                // For sure this is not the best approach to do these things.
                // Needs improvement and some lookup over Lat/Lon & Dates Formatting.
                var builtStringDate = 
                    string.Format("{0}T00:00:00.000Z", processedRecord.EventDateTime.ToString("MM/dd/yyyy"));

                stringBuilder.AppendFormat("{0};{1};{2};{3};{4}\r\n",
                    builtStringDate,
                    processedRecord.Town, processedRecord.Country,
                    processedRecord.Geolocalization.Latitude.ToString(CultureInfo.InvariantCulture).Replace(',', '.'),
                    processedRecord.Geolocalization.Longitude.ToString(CultureInfo.InvariantCulture).Replace(',','.'));
            }

            File.WriteAllText(FinalFileName, stringBuilder.ToString());
        }
    }
}
