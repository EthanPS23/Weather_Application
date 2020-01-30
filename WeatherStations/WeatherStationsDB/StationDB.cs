using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStationsDB
{
    public class StationDB
    {
        public static List<Station> GetStations()
        {
            List<Station> stations = new List<Station>();
            Station st;
            MySqlConnection con = DBConnection.GetConnection();

            return null;
        }
    }
}
