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


        //C: \Users\vaske\Desktop\HCI - vezbe\HCI1\HCIProj1\HCIProjekat1\HCIProjekat1\valute_csv\digital_currency_list.csv
            using (var reader = new StreamReader(@"C:\Users\vaske\Desktop\HCI-vezbe\HCI1\HCIProj1\HCIProjekat1\HCIProjekat1\valute_csv\physical_currency_list.csv"))
            {

                 while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    this.valute.Add(new PD_Currency() { Currency_Code = values[0], Currency_Name = values[1] });

                }

            }

            using (var reader = new StreamReader(@"C:\Users\vaske\Desktop\HCI-vezbe\HCI1\HCIProj1\HCIProjekat1\HCIProjekat1\valute_csv\digital_currency_list.csv"))
            {


                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    this.valute.Add(new PD_Currency() { Currency_Code = values[0], Currency_Name = values[1] });

                }

            }
      
        }

        public PD_Currency isValuteExist(String val)
        {
            PD_Currency ldpc = this.valute.FirstOrDefault(e => e.Currency_Code.ToUpper() == val.ToUpper());

            return ldpc;
        }

    }
}
