namespace CustomersVisualization.PreProcessor
{
    public interface IGeolocalizationService
    {
            GeolocalizationResult PerformGeolocalization(string city, string country);
    }
}
