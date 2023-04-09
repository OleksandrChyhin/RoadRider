namespace RoadRiderAPI.MapboxModels.Geocoding
{
    public class GeocodingResponseObject
    {
        public string Type { get; set; }

        public IEnumerable<GeocodingDTO> Features { get; set; }
    }
}
