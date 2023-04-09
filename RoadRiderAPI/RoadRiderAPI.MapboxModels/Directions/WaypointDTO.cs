using RoadRiderAPI.MapboxModels.Geocoding;

namespace RoadRiderAPI.MapboxModels.Directions
{
    public class WaypointDTO
    {
        public string Name { get; set; }

        public IEnumerable<double> Location { get; set; }

        public double Distance { get; set; }
    }
}
