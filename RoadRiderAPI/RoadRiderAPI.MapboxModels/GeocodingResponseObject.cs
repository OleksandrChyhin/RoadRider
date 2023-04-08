using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadRiderAPI.MapboxModels
{
    public class GeocodingResponseObject
    {
        public string Type { get; set; }       

        public IEnumerable<GeocodingDTO> Features { get; set; }
    }
}
