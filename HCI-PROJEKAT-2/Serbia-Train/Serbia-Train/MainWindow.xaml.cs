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
using Serbia_Train.pages;
using Line = Serbia_Train.models.Line;

namespace Serbia_Train
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            /*Initialize App*/

            Train.InitializeTrains();

            Ticket.InitializeTickets();

            Timetable.Initialize_Timetable();

            Line.Initialize_Line();

            /*End Initialization*/


            Set_Login_Page();
        }

       

        public void Set_Login_Page()
        {
            this._NavigationFrame.Navigate(new LoginPage(this));
        }

        public void Set_Home_Page()
        {
            this._NavigationFrame.Navigate(new HomePageMenager(this));
        }
       

        public void Set_Lines_Page()
        {
            //Console.WriteLine("USO");
            this._NavigationFrame.Navigate(new LinePage(this));
        }


        public void Set_Times_Page()
        {
            this._NavigationFrame.Navigate(new TimePage(this));
        }

        public void Set_Tickets_Page()
        {
            this._NavigationFrame.Navigate(new TicketPage(this));
        }

        public void Set_Trains_Page()
        {
            this._NavigationFrame.Navigate(new TrainPage(this));
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Console.WriteLine("USO");
            IInputElement focusedControl = FocusManager.GetFocusedElement(Application.Current.Windows[0]);
            if (focusedControl is DependencyObject)
            {
                string str = HelpProvider.GetHelpKey((DependencyObject)focusedControl);
                Console.WriteLine(str);
                Console.WriteLine(this);
                HelpProvider.ShowHelp(str, this);
            }
        }

        public void doThings(string param)
        {
            //btnOK.Background = new SolidColorBrush(Color.FromRgb(32, 64, 128));
            Title = param;
        }


    }
}
