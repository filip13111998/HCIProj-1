using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using HCIProjekat1.api;
using HCIProjekat1.mapper;
using HCIProjekat1.model;
using HCIProjekat1.util;
using LiveCharts;

namespace HCIProjekat1.view_model
{
    public class MultExchangeViewModel : BaseViewModel
    {

        public MultipleExchangeTransaction Met { get; set; } = new MultipleExchangeTransaction();

        public Forex_API Fap { get; set; } = new Forex_API();

        public FXJsonToTransactionMapper Mapper { get; set; } = new FXJsonToTransactionMapper();

        public Currency_Service Cs { get; set; } = new Currency_Service();


        private string type = "5min";

        public string Type
        {

            get { return type; }
            set
            {
                type = value;
                Update_Met();
                this.Dg.Update_Data();
                this.Dg.LoadBarChartData();
            }

        }

        private string diagram_yype = "Open";

        public string Diagram_Type
        {

            get { return diagram_yype; }
            set
            {
                diagram_yype = value;
                
                this.Dg.Update_Data();
                this.Dg.LoadBarChartData();

            }

        }

        public MainWindow Mw { get; set; }


        public Diagram Dg { get; set; }

        public Error Er { get; set; }
        public Empty Em { get; set; }
        public MultExchangeViewModel()
        {
            //this.mw = mw2;
            Cs.Initialize();
            

        }

        public Boolean Add_New_Transaction(string from_trans, string to_trans)
        {
            string json_data;
            if (!Is_Transaction_Exist(from_trans, to_trans))
            {
                //Console.WriteLine("USO");
                if (Type.Equals("Daily"))
                {
                    PD_Currency pd1 = Cs.isValuteExist(from_trans);
                    PD_Currency pd2 = Cs.isValuteExist(to_trans);
                    if (pd1 != null && pd2 != null)
                    {
                        json_data = Fap.getTwoValuteDaily(pd1.Currency_Code, pd2.Currency_Code);
                        Mapper.Map_To_Object(json_data, Met, "Daily");
                        Add_Item_To_Stackpanel(pd1.Currency_Code + "_" + pd2.Currency_Code);
                        this.Dg.Update_Data();
                        this.Dg.LoadBarChartData();
                        return true;
                    }

                }
                else if (Type.Equals("Weekly"))
                {
                    PD_Currency pd1 = Cs.isValuteExist(from_trans);
                    PD_Currency pd2 = Cs.isValuteExist(to_trans);
                    if (pd1 != null && pd2 != null)
                    {
                        json_data = Fap.getTwoValuteWeekly(pd1.Currency_Code, pd2.Currency_Code);
                        Mapper.Map_To_Object(json_data, Met, "Weekly");
                        Add_Item_To_Stackpanel(pd1.Currency_Code + "_" + pd2.Currency_Code);
                        this.Dg.Update_Data();
                        this.Dg.LoadBarChartData();
                        return true;
                    }
                }
                else if (Type.Equals("Monthly"))
                {
                    PD_Currency pd1 = Cs.isValuteExist(from_trans);
                    PD_Currency pd2 = Cs.isValuteExist(to_trans);
                    if (pd1 != null && pd2 != null)
                    {
                        json_data = Fap.getTwoValuteMonthly(pd1.Currency_Code, pd2.Currency_Code);
                        Mapper.Map_To_Object(json_data, Met, "Monthly");
                        Add_Item_To_Stackpanel(pd1.Currency_Code + "_" + pd2.Currency_Code);
                        this.Dg.Update_Data();
                        this.Dg.LoadBarChartData();
                        return true;
                    }
                }
                else
                {
                    PD_Currency pd1 = Cs.isValuteExist(from_trans);
                    PD_Currency pd2 = Cs.isValuteExist(to_trans);
                    if (pd1 != null && pd2 != null)
                    {
                        json_data = Fap.getTwoValuteInterval(pd1.Currency_Code, pd2.Currency_Code, type.Split('m')[0]);
                        Console.WriteLine(json_data);
                        Mapper.Map_To_Object(json_data, Met, type);
                        //try
                        //{
                        //    Mapper.Map_To_Object(json_data, Met, type);
                        //}
                        //catch (NullReferenceException)
                        //{
                        //    //Console.WriteLine(e.Message);
                        //    Console.WriteLine("OPA greskaaa");
                        //    return false;
                        //}
                        Add_Item_To_Stackpanel(pd1.Currency_Code + "_" + pd2.Currency_Code);
                        Console.WriteLine(this.Met.ExcTrans.Count);
                        this.Dg.Update_Data();
                        this.Dg.LoadBarChartData();
                        Console.WriteLine("DIAGRAM UPDATE");
                        return true;
                    }


                }




            }
            //Console.WriteLine("STIGO OVDE");
            return false;
        }

        public void Delete_Transaction(string from_trans, string to_trans)
        {
            this.Met.ExcTrans.RemoveAll(e => e.From.Equals(from_trans) && e.To.Equals(to_trans));
            this.Dg.Update_Data();
            this.Dg.LoadBarChartData();
        }


        public ExchangeTransaction Get_Transaction(string from_trans, string to_trans)
        {
            //Console.WriteLine("Rez" + this.Met.ExcTrans.Find(e => e.From.Equals(from_trans) && e.To.Equals(to_trans)).lTranItm.Count);
            return this.Met.ExcTrans.Find(e => e.From.Equals(from_trans) && e.To.Equals(to_trans));
        }
        public Boolean Is_Transaction_Exist(string from_trans, string to_trans)
        {
            // don't add two times same item
            IEnumerable<ExchangeTransaction> from = Met.ExcTrans.Where(t => t.From.ToUpper().Equals(from_trans.ToUpper()));
            if (from.ToList().Count == 0)
            {
                return false;
            }
            List<ExchangeTransaction> to = from.Where(t => t.To.ToUpper().Equals(to_trans.ToUpper())).ToList();
            if (to.Count > 0)
            {
                return true;
            }
            return false;
        }


        private void Add_Item_To_Stackpanel(string pdc)
        {

            StackPanel sp = new StackPanel() { 
                Height = 30
               
            };
            sp.Name = "sp_" + pdc;
            sp.Orientation = Orientation.Horizontal;

           ;


            Button btn_val = new Button
            {
                Content = "Table " + pdc,
                Name = "btn_" + pdc + "_" + Type,
                Width = 90,
                

            };
            btn_val.Margin = new Thickness(0, 0, 10, 0); ;
            btn_val.Style = (Style)this.Dg.Resources["TableButton"];

            Button btn_x = new Button
            {
                Content = "X",
                Name = "btn_" + pdc,
                Width = 20
                
               

            };

            btn_x.Style = (Style)this.Dg.Resources["ExitButton"];


            btn_x.Click += this.Mw.Button_Delete;
            btn_val.Click += this.Dg.New_Window;
            //tb.Text = pdc.ToString()+"ha";
            //tb.Name = "tb_" + pdc;
            //Console.WriteLine(tb.Text);
            sp.Children.Add(btn_x);
            sp.Children.Add(btn_val);
            


            this.Dg.root_control.Children.Add(sp);
            //this.Dg.scroll_valute.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
        }
        //this.mw.scroll_valute.Height = 100;


        public void Update_Met()
        {
            MultipleExchangeTransaction Met2 = new MultipleExchangeTransaction();

            foreach (var elem in this.Met.ExcTrans)
            {
                string json_data;
                if (Type.Equals("Daily"))
                {
                    json_data = Fap.getTwoValuteDaily(elem.From, elem.To);
                    Mapper.Map_To_Object(json_data, Met2, "Daily");
                }
                else if (Type.Equals("Weekly"))
                {
                    json_data = Fap.getTwoValuteWeekly(elem.From, elem.To);
                    Mapper.Map_To_Object(json_data, Met2, "Weekly");
                }
                else if (Type.Equals("Monthly"))
                {
                    json_data = Fap.getTwoValuteMonthly(elem.From, elem.To);
                    Mapper.Map_To_Object(json_data, Met2, "Monthly");
                }
                else
                {
                    json_data = Fap.getTwoValuteInterval(elem.From, elem.To, type.Split('m')[0]);
                    Mapper.Map_To_Object(json_data, Met2, Type);

                }

            }
            this.Met = Met2;

        }

    }
}
