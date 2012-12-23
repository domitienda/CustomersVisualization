namespace CustomersVisualization.PreProcessor
{
    public class GeolocalizationResult
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public bool HasSomething
        {
            get { return Latitude != 0 && Longitude != 0; }
        }
    }
}
