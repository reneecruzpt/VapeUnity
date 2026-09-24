namespace VapeUnity.Models
{
    public class AddressResult
    {
        public string FormattedAddress { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }
    }

    public class GeocodingResult
    {
        public string Status { get; set; }
        public GeocodingAddressResult[] Results { get; set; }
    }

    public class GeocodingAddressResult
    {
        public string FormattedAddress { get; set; }
        public GeocodingGeometry Geometry { get; set; }
    }

    public class GeocodingGeometry
    {
        public GeocodingLocation Location { get; set; }
    }

    public class GeocodingLocation
    {
        public double Lat { get; set; }
        public double Lng { get; set; }
    }
}
