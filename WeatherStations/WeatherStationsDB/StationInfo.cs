using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStationsDB
{
    public class StationInfo
    {
        public int StationID { get; set; }
        public int RegionID { get; set; }
        public int Elevation { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Description { get; set; }

        public StationInfo(int stationID, int regionID, int elevation, decimal latitude, decimal longitude, string description)
        {
            StationID = stationID;
            RegionID = regionID;
            Elevation = elevation;
            Latitude = latitude;
            Longitude = longitude;
            Description = description;
        }
    }
}
