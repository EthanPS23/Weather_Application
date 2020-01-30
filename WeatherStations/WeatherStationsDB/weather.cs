using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStationsDB
{
    public class Weather
    {
		public int StationID { get; set; }
		public DateTime Date { get; set; }
		public int Hour { get; set; }
		public int Temp { get; set; }
		public int? RH { get; set; }
		public int? Snow_Pack { get; set; }
		public int? Snow_New { get; set; }
		public int? Precip_New { get; set; }
		public int? Hr_Snow { get; set; }
		public int? Wind_Speed { get; set; }
		public int? Max_Wind_Speed { get; set; }
		public string Wind_Dir { get; set; }

		public Weather(int iD, DateTime date, int hour, int temp, int? rH, int? snow_Pack, int? snow_New, int? precip_New, int? hr_Snow, int? windSpeed, int? max_Wind_Speed, string wind_Dir)
		{
			StationID = iD;
			Date = date;
			Hour = hour;
			Temp = temp;
			RH = rH;
			Snow_Pack = snow_Pack;
			Snow_New = snow_New;
			Precip_New = precip_New;
			Hr_Snow = hr_Snow;
			Wind_Speed = windSpeed;
			Max_Wind_Speed = max_Wind_Speed;
			Wind_Dir = wind_Dir;
		}
	}
}
