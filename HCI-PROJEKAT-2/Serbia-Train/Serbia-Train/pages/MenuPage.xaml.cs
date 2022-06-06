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

namespace Serbia_Train.pages
{
    /// <summary>
    /// Interaction logic for MenuPAge.xaml
    /// </summary>
    public partial class MenuPage : Page
    {

        MainWindow Mw { get; set; }
        public MenuPage(MainWindow mw)
        {
            InitializeComponent();
            this.Mw = mw;
        }

      

        private void Home_Page(object sender, RoutedEventArgs e)
        {
            this.Mw.Set_Home_Page();
        }

        private void Lines(object sender, RoutedEventArgs e)
        {
            this.Mw.Set_Lines_Page();
        }


        private void Times(object sender, RoutedEventArgs e)
        {
            this.Mw.Set_Times_Page();
        }

        private void Trains(object sender, RoutedEventArgs e)
        {
            this.Mw.Set_Trains_Page();
        }

        private void Tickets(object sender, RoutedEventArgs e)
        {
            this.Mw.Set_Tickets_Page();
        }


        private void Log_Out(object sender, RoutedEventArgs e)
        {
            this.Mw.Set_Login_Page();
        }
    }
}
