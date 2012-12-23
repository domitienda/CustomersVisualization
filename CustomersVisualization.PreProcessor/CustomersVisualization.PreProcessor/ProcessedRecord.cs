namespace CustomersVisualization.PreProcessor
{
    public class ProcessedRecord : OriginalRecord
    {
        public ProcessedRecord()
        {
            
        }

        public ProcessedRecord(OriginalRecord originalRecord)
        {
            EventDateTime = originalRecord.EventDateTime;
            Town = originalRecord.Town;
            Country = originalRecord.Country;
        }

        public GeolocalizationResult Geolocalization { get; set; }
    }
}
