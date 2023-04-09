using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadRiderAPI.MapboxModels.Geocoding
{
    public class LocationByPlacement
    {
        const int MAX_PAGE_SIZE = 10;
        public int PageNumber { get; set; } = 1;

        int _pageSize = 4;

        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > MAX_PAGE_SIZE) ? MAX_PAGE_SIZE : value;
            }
        }

    }
}
