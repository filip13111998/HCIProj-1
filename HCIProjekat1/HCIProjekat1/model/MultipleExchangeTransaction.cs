using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCIProjekat1.model
{
    public class MultipleExchangeTransaction
    {
        public List<ExchangeTransaction> ExcTrans { get; set; }

        public MultipleExchangeTransaction()
        {
            this.ExcTrans = new List<ExchangeTransaction>();
        }

    }
}
