﻿using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStationsDB
{
    public class StationDB
    {
        // method to get a list of the stations
        public static List<Station> GetStations()
        {
            var dt = SQL.GetDataTable("select * from station"); // get all of the stations as a datatable
            List<Station> stations = dt.AsEnumerable() //convert the datatable to a list of stations
                .Select(row => new Station
                (
                    row.Field<int>(0), // set the stationID to column 0
                    row.Field<string>(1) // set the station name to column 1
                )).ToList();

            return stations;
        }

        // method to set the stations in the database
        public static bool SetStations(List<Station> stations)
        {
            var result = false;
            // the sql to insert into the station table. If a duplicate key exists then the values will be updated
            string sql = "INSERT INTO Station " +
                            "(StationID,Name) " +
                        "VALUES " +
                            "({0},{1})" +
                        "ON DUPLICATE KEY UPDATE Name = {1};";
            string sqlStatement = "";
            foreach (var station in stations)
            {
                sqlStatement += String.Format(sql, station.StationID, station.Name);
            }
            return result;
        }
    }
}
