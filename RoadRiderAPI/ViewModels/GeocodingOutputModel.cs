using RoadRiderAPI.MapboxModels;
using System.Drawing;

namespace ViewModels
{
    public class GeocodingOutputModel
    {
        public string Id { get; set; }

        public string Type { get; set; }

        public string[] PlaceType { get; set; }

        public double Relevance { get; set; }

        public string PlaceName { get; set; }

        public PointDTO Coordinates { get; set; }

        public string Address { get; set; }
    }
}
