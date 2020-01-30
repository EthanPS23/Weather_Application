using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStationsDB
{
    public class DataRetrieval
    {
        private string ParksCanadaWeatherStationURL = @"https://avalanche.pc.gc.ca/station-eng.aspx?d=";

        // create the links required for getting the date. Returns th list of links
        private List<string> GenerateLink()
        {
            var links = new List<string>();

            // creating the links for the available data. Data Started becoming readily available in 2016.
            // Starting in 2016 and adding days until the todays current date is reached
            for (DateTime date = new DateTime(2016,1,1); date.Date.ToShortDateString() == DateTime.Today.ToShortDateString(); date.AddDays(1))
            {
                links.Add(ParksCanadaWeatherStationURL + date.ToString("YYYY-MM-dd"));
            }

            return links;
        }


    }
}
