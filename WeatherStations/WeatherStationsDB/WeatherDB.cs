using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStationsDB
{
    public class WeatherDB
    {
        // method to get a list of the regions
        public static List<Weather> GetWeather()
        {
            var dt = SQL.GetDataTable("select * from Weather"); // get all of the regions as a datatable
            List<Weather> regions = dt.AsEnumerable() //convert the datatable to a list of regions
                .Select(row => new Weather
                (
                    row.Field<int>(0), // set the StationID to column 0
                    row.Field<DateTime>(1), // set the date to column 1
                    row.Field<int>(2), // set the hour to column 2
                    row.Field<int>(3), // set the temperature to column 3
                    row.Field<int>(4), // set the relative humidity to column 4
                    row.Field<int>(5), // set the snow pack to column 5
                    row.Field<int>(6), // set the snow new to column 6
                    row.Field<int>(7), // set the precip new to column 7
                    row.Field<int>(8), // set the 24hr snow to column 8
                    row.Field<int>(9), // set the wind speed to column 9
                    row.Field<int>(10), // set the max wind speed to column 10
                    row.Field<string>(11) // set the wind direction to column 11
                )).ToList();

            return regions;
        }

        // method to set the regions in the database
        public static bool InsertWeather(List<Weather> weather)
        {
            var result = false;
            // sql to insert into the StationInfo table.
            string sql = "INSERT INTO Weather " +
                            "(StationID,Date,Hour,Temp,RH,Snow_Pack,Snow_New,Precip_New,24Hr_Snow,Wind_Speed,Max_Wind_Speed,Wind_Dir) " +
                        "VALUES " +
                            "('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}');";
            string sqlStatement = "";
            foreach (var weatherEvent in weather)
            {
                sqlStatement += String.Format(sql, weatherEvent.StationID, weatherEvent.Date, weatherEvent.Hour,
                    weatherEvent.Temp, weatherEvent.RH, weatherEvent.Snow_Pack,weatherEvent.Snow_New, weatherEvent.Precip_New, weatherEvent.Hr_Snow, weatherEvent.Wind_Speed, weatherEvent.Max_Wind_Speed, weatherEvent.Wind_Dir);
            }

            result = SQL.SetDataTable(sqlStatement) >= 0; // if the number of rows affected is 0 or more than result is true

            return result;
        }
    }
}
