using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HCIProjekat1.api
{
    public class Forex_API
    {
        public String apiKey { get; set; } = "68N94TCCTM9S36BQ";

        //public string getTwoValuteMoment(String val1, String val2)
        //{

        //    string QUERY_URL = $"https://www.alphavantage.co/query?function=CURRENCY_EXCHANGE_RATE&from_currency={val1}&to_currency={val2}&apikey={apiKey}";
        //    return makeRequest(QUERY_URL);
        //}

        public string getTwoValuteInterval(String val1, String val2, String minute)
        {

            string QUERY_URL = $"https://www.alphavantage.co/query?function=FX_INTRADAY&from_symbol={val1}&to_symbol={val2}&interval={minute}min&apikey={apiKey}";
            return makeRequest(QUERY_URL);
        }

        public string getTwoValuteDaily(String val1, String val2)
        {

            string QUERY_URL = $"https://www.alphavantage.co/query?function=FX_DAILY&from_symbol={val1}&to_symbol={val2}&apikey={apiKey}";
            return makeRequest(QUERY_URL);
        }

        public string getTwoValuteWeekly(String val1, String val2)
        {

            string QUERY_URL = $"https://www.alphavantage.co/query?function=FX_WEEKLY&from_symbol={val1}&to_symbol={val2}&apikey={apiKey}";
            return makeRequest(QUERY_URL);
        }

        public string getTwoValuteMonthly(String val1, String val2)
        {

            string QUERY_URL = $"https://www.alphavantage.co/query?function=FX_MONTHLY&from_symbol={val1}&to_symbol={val2}&apikey={apiKey}";
            return makeRequest(QUERY_URL);
        }

        public string makeRequest(String QUERY_URL)
        {
            Uri queryUri = new Uri(QUERY_URL);

            using (WebClient client = new WebClient())
            {
                var json_data = client.DownloadString(queryUri);

                return json_data;
            }
        }

    }
}
