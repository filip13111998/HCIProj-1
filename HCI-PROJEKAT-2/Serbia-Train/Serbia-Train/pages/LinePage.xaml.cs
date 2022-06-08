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
using Serbia_Train.models;

namespace Serbia_Train.pages
{
    /// <summary>
    /// Interaction logic for LinePage.xaml
    /// </summary>
    public partial class LinePage : Page
    {
        MainWindow Mw { get; set; }
        public LinePage(MainWindow mw)
        {
            InitializeComponent();
            this.Mw = mw;
            this.Line_Left_Menu.DataContext = Line.Line_List;

            Add_Line_Filed.GotFocus += RemoveLine;
            Add_Line_Filed.LostFocus += AddLine;

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

        public void Set_Map()
        {
            this._LineNavigationBarFrame.Navigate(new MapPage(Mw));
        }

        public void Set_Map_Page(object sender , RoutedEventArgs e)
        {
            this._LineNavigationBarFrame.Navigate(new MapPage(Mw));
        }

        public void Set_Traffic_Page(object sender, RoutedEventArgs e)
        {
            this._LineNavigationBarFrame.Navigate(new Trafic(Mw));
        }


        public void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {

            this.Line_Vis.Visibility = Visibility.Visible;

            var row = (DataGridRow)sender;

            if (row == null) return;

            var line = row.Item as Line;

            //Console.WriteLine(line.Name);

            MapPage.Line_Name = line.Name;
            Trafic.Line_Name = line.Name;
            Set_Map();
            

        }


        public void Add_Line_Click(object sender, RoutedEventArgs e)
        {
            String Line_Str_Name = this.Add_Line_Filed.Text;

            Line li = Line.Line_List.Where(l => l.Name.Equals(Line_Str_Name)).FirstOrDefault();

            if (li != null)
            {
                Console.WriteLine("VEC POSTOJI Linijaa");
                return;
            }

            Line New_Line = new Line() { Name = Line_Str_Name };

            Line.Line_List.Add(New_Line);

        }

        public void RemoveLine(object sender, EventArgs e)
        {


            if (Add_Line_Filed.Text == "Add Line")
            {

                Add_Line_Filed.Text = "";
            }
        }

        public void AddLine(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Add_Line_Filed.Text))
                Add_Line_Filed.Text = "Add Line";
        }

    }
}
