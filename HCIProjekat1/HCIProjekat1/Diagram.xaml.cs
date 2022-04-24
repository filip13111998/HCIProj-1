using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using HCIProjekat1.model;
using HCIProjekat1.util;
using HCIProjekat1.view_model;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Helpers;
using LiveCharts.Wpf;


namespace HCIProjekat1
{
    /// <summary>
    /// Interaction logic for Diagram.xaml
    /// </summary>
    public partial class Diagram : Page ,INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
        MultExchangeViewModel Mewm2 { get; set; }

        public List<string> dates { get; set; } = new List<string>();
        public List<List<double>> data { get; set; } = new List<List<double>>();

        public List<string> dates2 { get; set; } = new List<string>();
        public List<List<double>> data2 { get; set; } = new List<List<double>>();


        public SeriesCollection sc { get; set; } = new SeriesCollection();

        public Func<double,string> yFormatter { get; set; }

        public String prop { get; set; } = "neki";

        public int Brojac { get; set; } = 0;
        public Diagram(MultExchangeViewModel Mewm)
        {
            this.Mewm2 = Mewm;
            this.DataContext = this;
            this.LoadBarChartData();
            InitializeComponent();
            

        }


        public void LoadBarChartData()
        {
            
            Console.WriteLine("DATA IS " + data.Count);
            //Console.WriteLine("SERIES IS " + this.mcChart.Series.Count);
            //BarSeries barSeries = mcChart.Series.Clear();
            //Series s = barSeries;
            //(BarSeries)mcChart.Series.Clear();
            //(BarSeries)mcChart.Series items = (BarSeries)mcChart.Series.Clear();
            this.Remove_Bar_Chart_Series(data.Count);
            for (int i = 0; i < data.Count; i++)
            {
                
                ((BarSeries)mcChart.Series[i]).ItemsSource =
                new KeyValuePair<string, double>[]{
                new KeyValuePair<string, double>(dates.ElementAt(dates.Count-1), data.ElementAt(i).ElementAt(data.ElementAt(i).Count - 1)),
                new KeyValuePair<string, double>(dates.ElementAt(dates.Count-2), data.ElementAt(i).ElementAt(data.ElementAt(i).Count - 2)),
                new KeyValuePair<string, double>(dates.ElementAt(dates.Count-3), data.ElementAt(i).ElementAt(data.ElementAt(i).Count - 3)),
                new KeyValuePair<string, double>(dates.ElementAt(dates.Count-4), data.ElementAt(i).ElementAt(data.ElementAt(i).Count - 4)),
                new KeyValuePair<string, double>(dates.ElementAt(dates.Count-5), data.ElementAt(i).ElementAt(data.ElementAt(i).Count - 5))};
                
                
            }
            if (this.Brojac > data.Count)
            {
                this.Remove_Bar_Chart_Series(data.Count);
               

            }
            this.Brojac = data.Count;

        }

        public void Remove_Bar_Chart_Series(int index)
        {
            //((BarSeries)mcChart.Series[index]).ItemsSource = null;
            
            for (int i = index; i < this.Brojac; i++)
            {
                ((BarSeries)mcChart.Series[index]).ItemsSource = null;
            }

        }

        public void New_Window(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
    
            TableWindow win = new TableWindow();
          
            win.DataContext = this.Mewm2.Get_Transaction(btn.Name.Split('_')[1], btn.Name.Split('_')[2]);
          
            win.Show();
        }

        private void Time_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
           
            if (btn.Name.Equals("btn1"))
            {
                this.Mewm2.Type = "1min";
            }
            else if (btn.Name.Equals("btn5"))
            {
                this.Mewm2.Type = "5min";
            }
            else if (btn.Name.Equals("btn15"))
            {
                this.Mewm2.Type = "15min";
            }
            else if (btn.Name.Equals("btn30"))
            {
                this.Mewm2.Type = "30min";
            }
            else if (btn.Name.Equals("btn1h"))
            {
                this.Mewm2.Type = "60min";
            }
            else if (btn.Name.Equals("btn1d"))
            {
                this.Mewm2.Type = "Daily";
            }
            else if (btn.Name.Equals("btn1w"))
            {
                this.Mewm2.Type = "Weekly";
            }
            else
            {
                this.Mewm2.Type = "Monthly";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            var combo = sender as ComboBox;
           
            var value = combo.SelectedItem as ComboBoxItem;

            if (!value.ToString().Split(' ')[1].Equals(this.Mewm2.Diagram_Type))
            {

                this.Mewm2.Diagram_Type = value.ToString().Split(' ')[1];
            }

        }

        public void Update_Data()
        {
            this.data = new List<List<double>>();
            this.sc = new SeriesCollection();
            //Console.WriteLine("SC " + this.sc.Count);
            //Console.WriteLine("MET " + this.Mewm2.Met.ExcTrans.Count);
            if(this.Mewm2.Met.ExcTrans.Count==0)
            {
                return;
            }
            this.dates = this.Mewm2.Met.ExcTrans[0].lTranItm.Select(e => e.Date).ToList();
            
            if (this.Mewm2.Diagram_Type.Equals("Open"))
            {
                Console.WriteLine("OPEN");
                this.Mewm2.Met.ExcTrans.ForEach(e => this.data.Add(e.lTranItm.Select(el => Convert.ToDouble(el.Open)).ToList()));
                   
                this.data.ForEach(e =>
                {
                    var tem = new ChartValues<double>();

                    foreach (var n in e)
                    {
                        tem.Add(n);

                    }
                    
                    this.sc.Add(new LiveCharts.Wpf.LineSeries()
                    {
                        Title = "Open",
                        Values = tem

                    }
                    );

                }
                

                );
                ;

            }
            else if (this.Mewm2.Diagram_Type.Equals("Low"))
            {
                this.Mewm2.Met.ExcTrans.ForEach(e => this.data.Add(e.lTranItm.Select(el => Convert.ToDouble(el.Low)).ToList()));
                Console.WriteLine("LOW");
                this.data.ForEach(e =>
                {
                    var tem = new ChartValues<double>();

                    foreach (var n in e)
                    {
                        tem.Add(n);

                    }
                    
                    this.sc.Add(new LiveCharts.Wpf.LineSeries()
                    {
                        Title = "Low",
                        Values = tem

                    }
                    );

                }

                );
            }
            else if (this.Mewm2.Diagram_Type.Equals("High"))
            {
               this.Mewm2.Met.ExcTrans.ForEach(e => this.data.Add(e.lTranItm.Select(el => Convert.ToDouble(el.High)).ToList()));
                
                this.data.ForEach(e =>
                {
                    var tem = new ChartValues<double>();

                    foreach (var n in e)
                    {
                        tem.Add(n);

                    }
                    
                    this.sc.Add(new LiveCharts.Wpf.LineSeries()
                    {
                        Title = "High",
                        Values = tem

                    }
                    );

                }

                );
            }
            else
            {
                
                //Console.WriteLine(this.Mewm2.Met.ExcTrans.Count + " exc");
                this.Mewm2.Met.ExcTrans.ForEach(e => this.data.Add(e.lTranItm.Select(el => Convert.ToDouble(el.Close)).ToList()));
                
                this.data.ForEach(e =>
                {
                    var tem = new ChartValues<double>();
                   
                    foreach (var n in e)
                    {
                        //Console.WriteLine("STOO PUTA");
                        tem.Add(n);
                        
                    }
                    
                    //Console.WriteLine("Broj " + tem.Count);
                    //Console.WriteLine("USO OVDe");
                    this.sc.Add(new LiveCharts.Wpf.LineSeries()
                    {
                        Title = "Close",
                        Values = tem

                    }
                    );
                    Console.WriteLine("SC2 " + this.sc.Count);

                }
                  
                );
            }
            

            yFormatter = value => value.ToString();
   
        }

        
    }
}
