using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStationsDB
{
    public class Region
    {
        public int RegionID { get; set; }
        public string RegionName { get; set; }

        public Region(int regionID, string regionName)
        {
            RegionID = regionID;
            RegionName = regionName;
        }
    }
}
