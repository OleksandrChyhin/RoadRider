﻿namespace RoadRiderAPI.MapboxModels
{
    public class GeocodingDTO
    {
        public string Id { get; set; }

        public string Type { get; set; }

        public string[] PlaceType { get; set; }

        public double Relevance { get; set; }       

        public string PlaceName { get; set; }

        public Geometry Geometry { get; set; }

        public Properties Properties { get; set; }
    }
}