using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCIProjekat1.model;

namespace HCIProjekat1.util
{
    public class Currency_Service
    {
        public List<PD_Currency> valute;

        public Currency_Service()
        {
            valute = new List<PD_Currency>();
        }

        public void Initialize()
        {
            Console.WriteLine("*******************VALUTE*******************");



            using (var reader = new StreamReader(@"C:\Users\vaske\Desktop\Currency\Currency\valute_csv\physical_currency_list.csv"))
            {

                //List<string> listB = new List<string>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    this.valute.Add(new PD_Currency() { Currency_Code = values[0], Currency_Name = values[1] });

                }

            }

            using (var reader = new StreamReader(@"C:\Users\vaske\Desktop\Currency\Currency\valute_csv\digital_currency_list.csv"))
            {


                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    this.valute.Add(new PD_Currency() { Currency_Code = values[0], Currency_Name = values[1] });

                }

            }
            //this.valute.ForEach(e => Console.WriteLine(e));
            //Console.WriteLine("Velicina liste je::::: " + valute.Count);

        }

        public PD_Currency isValuteExist(String val)
        {
            PD_Currency ldpc = this.valute.FirstOrDefault(e => e.Currency_Code.ToUpper() == val.ToUpper());

            return ldpc;
        }

    }
}
