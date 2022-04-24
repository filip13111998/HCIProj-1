using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCIProjekat1.model
{
    public class PD_Currency
    {
        public String Currency_Code { get; set; }

        public String Currency_Name { get; set; }


        public override String ToString()
        {

            return Currency_Code + " --- " + Currency_Name;
        }

    }
}
