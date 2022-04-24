using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HCIProjekat1.model
{
    public class TransactionItem
    {
        [JsonProperty("1. open")]
        public String Open { get; set; }

        [JsonProperty("2. high")]
        public String High { get; set; }

        [JsonProperty("3. low")]
        public String Low { get; set; }

        [JsonProperty("4. close")]
        public String Close { get; set; }

        public override String ToString()
        {
            String s = "Open: " + this.Open + " High: " + this.High + " Low: " + this.Low + " Close: " + this.Close + "\n";

            return s;
        }
    }
}