using System.Collections.Generic;

namespace RoadRiderClient.Models
{
    public class GeocodingDTO
    {
        public string Id { get; set; }
        public IEnumerable<string> PlaceType { get; set; }
        public string PlaceName { get; set; }
        public PointDTO Coordinates { get; set; }
        public string Address { get; set; }
        public string Text { get; set; }
        public string Category { get; set; }
    }
}
