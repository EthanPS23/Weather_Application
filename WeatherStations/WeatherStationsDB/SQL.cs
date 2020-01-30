using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace WeatherStationsDB
{
    public class SQL
    {
        // method to get data from the weatherstations database and return as a datatable
        public static DataTable GetDataTable(string sql)
        {
            var results = new DataTable();
            try
            {
                using (var connection = DBConnection.GetConnection())
                {
                    var command = new MySqlCommand(sql, connection);
                    command.Connection.Open();

                    // create the data adapter
                    var da = new MySqlDataAdapter(command);
                    // query the database and return as a datatable
                    da.Fill(results);
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                // TODO: display the exception
                Debug.WriteLine(ex.Message);
            }

            return results;
        }

        // modifies data in the weather stations database based on the sql query that is obtained. The number
        // of row that were affected is returned, with -1 being an issue occured.
        public static int SetDataTable(string sql)
        {
            var rowsAffected = -1;

            try
            {
                using (var connection =  DBConnection.GetConnection())
                {
                    var command = new MySqlCommand(sql, connection);
                    command.Connection.Open();

                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // TODO: display the exception
                Debug.WriteLine(ex.Message);
            }

            return rowsAffected;
        }
    }
}
