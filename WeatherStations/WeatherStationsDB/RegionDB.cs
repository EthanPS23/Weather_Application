using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStationsDB
{
    public class RegionDB
    {
        // method to get a list of the regions
        public static List<Region> GetRegions()
        {
            var dt = SQL.GetDataTable("select * from Region"); // get all of the regions as a datatable
            List<Region> regions = dt.AsEnumerable() //convert the datatable to a list of regions
                .Select(row => new Region
                (
                    row.Field<int>(0), // set the RegionID to column 0
                    row.Field<string>(1) // set the region name to column 1
                )).ToList();

            return regions;
        }

        // method to set the regions in the database
        public static bool SetRegions(List<Region> regions)
        {
            var result = false;
            // sql to insert into the region table. If a duplicate key exists then the values will be updated
            string sql = "INSERT INTO Region " +
                            "(RegionID,RegionName) " +
                        "VALUES " +
                            "({0},{1})" +
                        "ON DUPLICATE KEY UPDATE RegionName = '{1}';";
            string sqlStatement = "";
            foreach (var region in regions)
            {
                sqlStatement += String.Format(sql, region.RegionID, region.RegionName);
            }

            result = SQL.SetDataTable(sqlStatement) >= 0; // if the number of rows affected is 0 or more than result is true

            return result;
        }
    }
}
