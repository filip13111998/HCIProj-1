using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCIProjekat1.model
{
    public class TransactionItemExtend
    {
        public String Date { get; set; } = "";
        public String Open { get; set; } = "";

        public String High { get; set; }

        public String Low { get; set; }

        public String Close { get; set; }

        public TransactionItemExtend(String d1, TransactionItem t1)
        {
            this.Date = d1;
            this.Open = t1.Open;
            this.High = t1.High;
            this.Low = t1.Low;
            this.Close = t1.Close;
        }
        public override String ToString()
        {
            String s = "Date " + this.Date + " Open: " + this.Open + " High: " + this.High + " Low: " + this.Low + " Close: " + this.Close + "\n";

            return s;
        }
    }
}
