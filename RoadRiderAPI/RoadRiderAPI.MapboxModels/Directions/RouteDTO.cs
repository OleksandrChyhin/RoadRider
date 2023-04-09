namespace RoadRiderAPI.MapboxModels.Directions
{
    public class RouteDTO
    {
        public int Duration { get; set; }

        public int Distance { get; set; }

        public string WeightName { get; set; }

        public int Weight { get; set; }

        public double DurationTypical { get; set; }

        public double WeighTypical { get; set; }

        public string Geometry { get; set; }        

        public string VoiceLocale { get; set; }

        public IEnumerable<WaypointDTO> Waypoints{get;set;}

}
}
