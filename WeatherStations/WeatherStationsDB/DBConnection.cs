using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace WeatherStationsDB
{
    public static class DBConnection
    {
        public static MySqlConnection GetConnection()
        {
            string ConnectionString = "Server=localhost; database=weather_stations; UID=harv; password=password";
            MySqlConnection connection = new MySqlConnection(ConnectionString);

            return connection;
        }
    }
}
