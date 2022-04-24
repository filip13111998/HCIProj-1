using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HCIProjekat1.view_model;

namespace HCIProjekat1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //reference to view model.
        MultExchangeViewModel Mewm { get; set; } = new MultExchangeViewModel();
        public MainWindow()
        {


            InitializeComponent();
            //Set DataContext
            this.Mewm.Em = new Empty();
            this.Mewm.Dg = new Diagram(Mewm);
            this.Mewm.Er = new Error();

            this.DataContext = Mewm;
            //Set main window in view model class.
            Mewm.Mw = this;
            this.Set_Empty_Page();
            Console.WriteLine(this.Mewm.Met);


        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    this.PEra.Content += "Hahaha";
        //}

        //private void Button_Click2(object sender, RoutedEventArgs e)
        //{
        //    TableWindow win2 = new TableWindow();
        //    win2.Show();
        //}

        private void Set_Error_Page()
        {
            //Console.WriteLine("AJDEE");
            _NavigationFrame.Navigate(this.Mewm.Er);
            //Console.WriteLine("AJDEE222");

        }
        private void Set_Empty_Page()
        {

            _NavigationFrame.Navigate(this.Mewm.Em);
        }
        private void Set_Diagram_Page()
        {

            _NavigationFrame.Navigate(this.Mewm.Dg);
        }

        private void Set_Type(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            this.Mewm.Type = btn.Name;


        }

        public void Add_New_Valute(object sender, RoutedEventArgs e)
        {

            Boolean ret_val = this.Mewm.Add_New_Transaction(this.from_tb.Text, this.to_tb.Text);
            if (!ret_val)
            {
                //If met is empty...load error page
                if (this.Mewm.Met.ExcTrans.Count == 0)
                {
                    //Console.WriteLine("I OVDE");
                    this.Set_Error_Page();
                    return;
                }
                else //if met is not empty,then show msg box only...
                {
                    MessageBox.Show("Wrong input!", "Error 404");
                }

            }
            //Console.WriteLine(this.Mewm.Dg.root_control.Name);

            this.Set_Diagram_Page();

        }

        public void Button_Delete(object sender, RoutedEventArgs e)
        {

            Button btn = sender as Button;
            StackPanel sp = btn.Parent as StackPanel;
            MessageBox.Show(btn.Name.ToString());
            this.Mewm.Dg.root_control.Children.Remove(sp);
            //Console.WriteLine(this.Mewm.Dg.root_control.Name);
            this.Mewm.Delete_Transaction(btn.Name.Split('_')[1], btn.Name.Split('_')[2]);
            if (this.Mewm.Dg.root_control.Children.Count == 0)
            {
                this.Set_Empty_Page();
                //this.Mewm.Dg.scroll_valute.Height = 0;
            }

        }


    }
}
