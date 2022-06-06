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
using Serbia_Train.models;

namespace Serbia_Train.pages
{
    /// <summary>
    /// Interaction logic for HomePageMenager.xaml
    /// </summary>
    public partial class HomePageMenager : Page
    {
        MainWindow Mw { get; set; }
        public HomePageMenager(MainWindow mw)
        {
            InitializeComponent();
            this.Mw = mw;
            this.DataContext = Manager.CurrentManager;
            Set_Menu();
            
        }

        public void Set_Menu()
        {
            this._MenuNavigationBarFrame.Navigate(new MenuPage(this.Mw));
            
        }


       

    }
}
