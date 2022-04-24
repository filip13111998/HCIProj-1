using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCIProjekat1.model
{
    public class ExchangeTransaction
    {

        public String From { get; set; }


        public String To { get; set; }


        public Dictionary<String, TransactionItem> listTransItem { get; set; } = new Dictionary<String, TransactionItem>();

        public ObservableCollection<TransactionItemExtend> lTranItm { get; set; } = new ObservableCollection<TransactionItemExtend>();

        public override String ToString()
        {
            String s = From + " --- " + To + "\n";
            foreach (KeyValuePair<String, TransactionItem> entry in this.listTransItem)
            {
                s += "\t" + entry.Key + "::::" + entry.Value + "\n";
            }
            return s;
        }
    }
}
