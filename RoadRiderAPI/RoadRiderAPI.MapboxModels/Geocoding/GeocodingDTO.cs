namespace RoadRiderAPI.MapboxModels.Geocoding
{
    public class GeocodingDTO
    {
        public string Id { get; set; }

        public string Type { get; set; }

        public IEnumerable<string> PlaceType { get; set; }

        public double Relevance { get; set; }

        public string PlaceName { get; set; }

        public Geometry Geometry { get; set; }

        public Properties Properties { get; set; }
    }
}