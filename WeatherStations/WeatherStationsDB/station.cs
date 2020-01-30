using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStationsDB
{
    public class Station
    {
		public int StationID { get; set; }
		public string StationName { get; set; }

		public Station(int stationID, string name)
		{
			StationID = stationID;
			StationName = name;
		}
	}
}
