﻿using ViewModels;

namespace RoadRiderAPI.Core.MapboxAPIs.Geocodings
{
    public interface IGeocodingService
    {
        Task<IEnumerable<GeocodingOutputModel>> ForwardGeocoding(string search/*, bool autocomplete = false, string language = "us", int limit = 5*/);
        Task ReverseGeocoding((double, double) search/*, string language = "us", int limit = 5*/);
    }
}
