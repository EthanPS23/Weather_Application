using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStationsDB
{
    public class StationInfoDB
    {
        // method to get a list of the regions
        public static List<StationInfo> GetStationInfo()
        {
            var dt = SQL.GetDataTable("select * from StationInfo"); // get all of the regions as a datatable
            List<StationInfo> regions = dt.AsEnumerable() //convert the datatable to a list of regions
                .Select(row => new StationInfo
                (
                    row.Field<int>(0), // set the StationID to column 0
                    row.Field<int>(1), // set the RegionID to column 1
                    row.Field<int>(2), // set the Elevation to column 2
                    row.Field<decimal>(3), // set the Latitude to column 3
                    row.Field<decimal>(4), // set the Longitude to column 4
                    row.Field<string>(5) // set the Description to column 5
                )).ToList();

            return regions;
        }

        // method to set the regions in the database
        public static bool SetStationInfo(List<StationInfo> stationsInfo)
        {
            var result = false;
            // sql to insert into the StationInfo table. If a duplicate key exists then the values will be updated
            string sql = "INSERT INTO StationInfo " +
                            "(StationID,RegionID,Elevation,Latitude,Longitude,Description) " +
                        "VALUES " +
                            "('{0}','{1}','{2}','{3}','{4}','{5}')" +
                        "ON DUPLICATE KEY UPDATE RegionID='{1}',Elevation='{2}',Latitude='{3}',Longitude='{4}'," +
                            "Description='{5}';";
            string sqlStatement = "";
            foreach (var stationInfo in stationsInfo)
            {
                sqlStatement += String.Format(sql, stationInfo.StationID, stationInfo.RegionID, stationInfo.Elevation,
                    stationInfo.Latitude, stationInfo.Longitude, stationInfo.Description);
            }

            result = SQL.SetDataTable(sqlStatement) >= 0; // if the number of rows affected is 0 or more than result is true

            return result;
        }
    }
}
