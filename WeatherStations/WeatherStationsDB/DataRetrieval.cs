using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStationsDB
{
    public static class DataRetrieval
    {
        private static string ParksCanadaWeatherStationURL = @"https://avalanche.pc.gc.ca/station-eng.aspx?d=";

        // create the links required for getting the date. Returns th list of links
        public static List<string> GenerateLink()
        {
            var links = new List<string>();

            // creating the links for the available data. Data Started becoming readily available in 2016.
            // Starting in 2016 and adding days until the todays current date is reached
            for (DateTime date = new DateTime(2016,1,1); date.Date.ToShortDateString() != DateTime.Today.ToShortDateString(); date = date.AddDays(1))
            {
                links.Add(ParksCanadaWeatherStationURL + date.ToString("yyyy-MM-dd"));
            }

            return links;
        }

        // obtains the html of the urls
        public static string ObtainHtml(string urlAddress)
        {
            // TODO: determine if try/catch is needed in here
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string html = "";

            // if a aresponse is obtained from the site url then continue
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;

                // checks that the character set of the response is not empty before using it to assign the stream encoding
                if (String.IsNullOrWhiteSpace(response.CharacterSet))
                {
                    readStream = new StreamReader(receiveStream);
                }
                else
                {
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                }

                html = readStream.ReadToEnd();

                // make sure to close the response and read stream
                response.Close();
                readStream.Close();
            }

            return html;
        }

        private void HTMLExamination(string html)
        {

        }
    }
}
