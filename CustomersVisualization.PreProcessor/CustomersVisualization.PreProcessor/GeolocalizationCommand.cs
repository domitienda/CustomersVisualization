using System;
using System.Text;

namespace CustomersVisualization.PreProcessor
{
    public class GeolocalizationCommand : IEquatable<GeolocalizationCommand>
    {
        public string Town { get; set; }
        public string Country { get; set; }

        public bool Equals(GeolocalizationCommand other)
        {
            return (Town.ToLower() == other.Town.ToLower()) &&
                   (Country.ToLower() == other.Country.ToLower());
        }

        public override int GetHashCode()
        {
            var asciiBytes = Encoding.ASCII.GetBytes(Town.ToLower() + Country.ToLower());
            return BitConverter.ToInt32(asciiBytes, 0);
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}", Town, Country);
        }
    }
}
