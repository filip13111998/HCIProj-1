using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCIProjekat1.model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HCIProjekat1.mapper
{
    public class FXJsonToTransactionMapper
    {
        public FXJsonToTransactionMapper()
        {

        }
        /// <summary>
        /// jsonData -> Json Object
        /// type -> 1min,5min...60min,Daily....
        /// </summary>
        /// <param name="jsonData"></param>
        /// <param name="met"></param>
        /// <param name="type"></param>
        public void Map_To_Object(string jsonData, MultipleExchangeTransaction met, string type)
        {
            ExchangeTransaction et = new ExchangeTransaction();

            //initialize object from json
            JObject jObject = JObject.Parse(jsonData);

            //deserialize metadata
            JToken metaToken = jObject["Meta Data"];
            et.From = (string)metaToken["2. From Symbol"];
            //try
            //{
            //    //if((string)metaToken["2. From Symbol"] is null )
            //    //{
            //    //    throw new NullReferenceException();
            //    //}
            //    et.From = (string)metaToken["2. From Symbol"];
            //}
            //catch (NullReferenceException)
            //{
            //    //Console.WriteLine(e.Message);
            //    Console.WriteLine("OPA greskaaa");
            //    return;
            //}
            //et.From = (string)metaToken["2. From Symbol"];
            et.To = (string)metaToken["3. To Symbol"];



            //deserialize array of transactions
            JToken fxToken = jObject[$"Time Series FX ({type})"];
            //Console.WriteLine("TOKENNNN " + fxToken.ToString());

            Dictionary<string, TransactionItem> values = JsonConvert.DeserializeObject<Dictionary<string, TransactionItem>>(fxToken.ToString());
            et.listTransItem = values;

            //et.lTranItm= new ObservableCollection<TransactionItemExtend>(values.Values.ToList());
            et.lTranItm = this.GetList(values.Keys.ToList(), values.Values.ToList());
            met.ExcTrans.Add(et);

        }

        public ObservableCollection<TransactionItemExtend> GetList(List<String> key, List<TransactionItem> val)
        {
            ObservableCollection<TransactionItemExtend> tl = new ObservableCollection<TransactionItemExtend>();
            var kv = key.Zip(val, (n, w) => new { k1 = n, val1 = w });
            foreach (var pair in kv)
            {
                tl.Add(new TransactionItemExtend(pair.k1, pair.val1));
            }
            return tl;
        }
    }
}
