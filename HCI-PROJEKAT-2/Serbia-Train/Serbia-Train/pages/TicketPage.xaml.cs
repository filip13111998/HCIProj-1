using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using MaterialDesignThemes.Wpf;
using Serbia_Train.models;

namespace Serbia_Train.pages
{
    /// <summary>
    /// Interaction logic for Ticket.xaml
    /// </summary>
    public partial class TicketPage : Page
    {
        MainWindow Mw { get; set; }
        public TicketPage(MainWindow mw)
        {
            InitializeComponent();

            PaletteHelper paletteHelper = new PaletteHelper();

            var theme = paletteHelper.GetTheme();

            theme.SetPrimaryColor((Color)ColorConverter.ConvertFromString("#a8d0e6"));

            //theme.SetSecondaryColor((Color)ColorConverter.ConvertFromString("#FFFFFF"));

            paletteHelper.SetTheme(theme);


            this.Mw = mw;
            Set_DataContext();

            Name_Filed.GotFocus += RemoveName;
            Name_Filed.LostFocus += AddName;

            Start_Date_Filed.GotFocus += RemoveStartDate;
            Start_Date_Filed.LostFocus += AddStartDate;

            End_Date_Filed.GotFocus += RemoveEndDate;
            End_Date_Filed.LostFocus += AddEndDate;

            Set_Menu();
        }
        public void Set_Menu()
        {
            this._MenuNavigationBarFrame.Navigate(new MenuPage(this.Mw));

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
                HelpProvider.ShowHelp(str, Mw);
            }
        }

        public void doThings(string param)
        {
            //btnOK.Background = new SolidColorBrush(Color.FromRgb(32, 64, 128));
            Title = param;
        }

        public void Set_DataContext()
        {
            this.DataContext = Ticket.Tickets;

        }

        public void Search_Click(object sender , RoutedEventArgs e)
        {

            ObservableCollection<Ticket> All_Filter_Tcikets = Ticket.Tickets;

            String[] d1_arr;
            DateTime d1=new DateTime();
            if (this.Start_Date_Filed.Text != "" && this.Start_Date_Filed.Text != "Start Date")
            {
                d1_arr = this.Start_Date_Filed.Text.Split('/');
                d1 = new DateTime(Int32.Parse(d1_arr[2]), Int32.Parse(d1_arr[0]), Int32.Parse(d1_arr[1]), 0, 0, 0);
                All_Filter_Tcikets = this.Start_Date_Filter(Ticket.Tickets , d1);
            }

            String[] d2_arr;
            DateTime d2 = new DateTime();
            Console.WriteLine(this.Start_Date_Filed.Text + "Haha");
            if (this.End_Date_Filed.Text != "" && this.End_Date_Filed.Text != "End Date")
            {
                d2_arr = this.End_Date_Filed.Text.Split('/');
                d2 = new DateTime(Int32.Parse(d2_arr[2]), Int32.Parse(d2_arr[0]), Int32.Parse(d2_arr[1]), 0, 0, 0);
                All_Filter_Tcikets = this.End_Date_Filter(All_Filter_Tcikets, d2);
            }

            if (this.Name_Filed.Text != ""  && this.Name_Filed.Text != "Train Name")
            {
                All_Filter_Tcikets = this.Name_Filter(All_Filter_Tcikets, this.Name_Filed.Text);
            }

         
            this.DataContext = All_Filter_Tcikets;

        }

        public ObservableCollection<Ticket> Start_Date_Filter(ObservableCollection<Ticket> Ticket_List,DateTime d1)
        {

            List<Ticket> Filter_Tickets = Ticket_List.Where(t =>  t.Start >= d1).ToList();

            ObservableCollection<Ticket> Cast_Filter_Tickets = new ObservableCollection<Ticket>(Filter_Tickets);

            return Cast_Filter_Tickets;
        }

        public ObservableCollection<Ticket> End_Date_Filter(ObservableCollection<Ticket> Ticket_List , DateTime d2)
        {
            List<Ticket> Filter_Tickets = Ticket_List.Where(t => t.End <= d2).ToList();

            ObservableCollection<Ticket> Cast_Filter_Tickets = new ObservableCollection<Ticket>(Filter_Tickets);

            return Cast_Filter_Tickets;
        }

        public ObservableCollection<Ticket> Name_Filter(ObservableCollection<Ticket> Ticket_List,String Name)
        {
            List<Ticket> Filter_Tickets = Ticket_List.Where(t => t.TrainName.ToLower().Equals(Name.ToLower())).ToList();

            ObservableCollection<Ticket> Cast_Filter_Tickets = new ObservableCollection<Ticket>(Filter_Tickets);

            return Cast_Filter_Tickets;

        }


        public void RemoveName(object sender, EventArgs e)
        {

            if (Name_Filed.Text == "Train Name")
            {
                Name_Filed.Text = "";
            }
        }

        public void AddName(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Name_Filed.Text))
                Name_Filed.Text = "Train Name";
        }

        public void RemoveStartDate(object sender, EventArgs e)
        {

            if (Start_Date_Filed.Text == "Start Date")
            {
                Start_Date_Filed.Text = "";
            }
        }

        public void AddStartDate(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Start_Date_Filed.Text))
                Start_Date_Filed.Text = "Start Date";
        }


        public void RemoveEndDate(object sender, EventArgs e)
        {

            if (End_Date_Filed.Text == "End Date")
            {
                End_Date_Filed.Text = "";
            }
        }

        public void AddEndDate(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(End_Date_Filed.Text))
                End_Date_Filed.Text = "End Date";
        }


    }
}
