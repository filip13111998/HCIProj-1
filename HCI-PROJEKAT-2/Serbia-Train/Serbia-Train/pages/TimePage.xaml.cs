using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Interaction logic for TimePage.xaml
    /// </summary>
    public partial class TimePage : Page
    {
        MainWindow Mw { get; set; }

        public String Last_Train_Name { get; set; }

        public TimePage(MainWindow mw)
        {
            InitializeComponent();

            PaletteHelper paletteHelper = new PaletteHelper();

            var theme = paletteHelper.GetTheme();

            theme.SetPrimaryColor((Color)ColorConverter.ConvertFromString("#a8d0e6"));

            paletteHelper.SetTheme(theme);

            this.Mw = mw;

            this.Trains_Left_Menu.DataContext = Train.Trains;

            Start_Filed.GotFocus += RemoveTextStart;
            Start_Filed.LostFocus += AddTextStart;

            End_Filed.GotFocus += RemoveTextEnd;
            End_Filed.LostFocus += AddTextEnd;

            Comeback_Start_Filed.GotFocus += RemoveTextComebackStart;
            Comeback_Start_Filed.LostFocus += AddTextComebackStart;

            Comeback_End_Filed.GotFocus += RemoveTextComebackEnd;
            Comeback_End_Filed.LostFocus += AddTextComebackEnd;



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
        private void OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            PropertyDescriptor propertyDescriptor = (PropertyDescriptor)e.PropertyDescriptor;
            e.Column.Header = propertyDescriptor.DisplayName;
            if (propertyDescriptor.DisplayName == "Train")
            {
                e.Cancel = true;
            }
        }

        public void Set_DataContext(String Train_Name)
        {
            this.Combo.Items.Clear();
            //Console.WriteLine(Train_Name);

            ObservableCollection<Timetable> Timetable_List = new ObservableCollection<Timetable>();

            List<Timetable> timetables = Timetable.Timetables.Where(tt => tt.Train.Name.ToLower().Equals(Train_Name.ToLower())).ToList();

            

            this.Timetable_Grid.DataContext = timetables;

            List<String> Lista_Combo = new List<string>() { "RADNI_DAN" , "SVAKI_DAN" , "VIKEND"};
            //this.Combo.Items.Add("RADNI_DAN");
            //this.Combo.Items.Add("SVAKI_DAN");
            //this.Combo.Items.Add("VIKEND");

            foreach (Timetable t in timetables)
            {
               
                if(t.TypeTimetable == TypeTimetable.SVAKI_DAN)
                {
                    Lista_Combo.Clear();
                }
                else if(t.TypeTimetable == TypeTimetable.RADNI_DAN)
                {
                    Lista_Combo.Remove("SVAKI_DAN");
                    Lista_Combo.Remove("RADNI_DAN");
                }
                else
                {
                     Lista_Combo.Remove("SVAKI_DAN");
                    Lista_Combo.Remove("VIKEND");
                }
                
            }

            if (Lista_Combo.Count == 0)
            {
                this.Add_Timetable.IsEnabled = false;
            }
            else
            {
                this.Add_Timetable.IsEnabled = true;
            }

            foreach (string s in Lista_Combo)
            {
                this.Combo.SelectedItem = this.Combo.Items.Add(s);
            }

            

        }

        public void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {

            this.Content_Part.Visibility = Visibility.Visible;

            var row = (DataGridRow)sender;

            if (row == null) return;

            var train = row.Item as Train;

            //this.Train_Name.Content = train.Name;

            //this.Temp_Train_Name = train.Name;

            Last_Train_Name = train.Name;

            Set_DataContext(train.Name);
            //Draw New Composition
            //this.Draw_Composition(train);

        }

        public void Add_Timetable_Click(object sender, RoutedEventArgs e)
        {
            Timetable t = new Timetable();

            String Start_Time = this.Start_Filed.Text;
            Console.WriteLine(Start_Time + " VREME");

            if (Start_Time == "" || Start_Time == "Start Time" )
            {
                return;
            }

            t.Start = new TimeSpan(Int32.Parse(Start_Time.Split(':')[0]), Int32.Parse(Start_Time.Split(':')[1].Split(' ')[0]), 0);

            String End_Time = this.End_Filed.Text;

            if (End_Time == "" || End_Time == "End Time")
            {
                return;
            }

            t.End = new TimeSpan(Int32.Parse(End_Time.Split(':')[0]), Int32.Parse(Start_Time.Split(':')[1].Split(' ')[0]), 0);

            String Come_Start_Time = this.Comeback_Start_Filed.Text;

            if (Come_Start_Time == "" || Come_Start_Time == "Comeback Start Time")
            {
                return;
            }

            t.ComebackStart = new TimeSpan(Int32.Parse(Come_Start_Time.Split(':')[0]), Int32.Parse(Start_Time.Split(':')[1].Split(' ')[0]), 0);

            String Come_End_Time = this.Comeback_End_Filed.Text;

            if (Come_End_Time == "" || Come_End_Time == "Comeback End Time")
            {
                return;
            }

            t.ComebackEnd = new TimeSpan(Int32.Parse(Come_End_Time.Split(':')[0]), Int32.Parse(Start_Time.Split(':')[1].Split(' ')[0]), 0);

            String typeItem = this.Combo.SelectedItem.ToString();
            //string value = typeItem.Content.ToString();
            //Console.WriteLine(typeItem + "ae");


            if (typeItem == "SVAKI_DAN")
            {
                t.TypeTimetable = TypeTimetable.SVAKI_DAN;
            }
            else if (typeItem == "RADNI_DAN")
            {
                t.TypeTimetable = TypeTimetable.RADNI_DAN;
            }
            else
            {
                t.TypeTimetable = TypeTimetable.VIKEND;
            }

            Train tr = Train.Trains.Where(tt => tt.Name.ToLower().Equals(Last_Train_Name.ToLower())).FirstOrDefault();

            t.Train = tr;

            Timetable.Timetables.Add(t);

            this.Set_DataContext(tr.Name);

        }


        public void Delete_Click(object sender , RoutedEventArgs e)
        {
            //var currentRowIndex = Timetable_Grid.Items.IndexOf(Timetable_Grid.CurrentItem);
            //Console.WriteLine(currentRowIndex);
            //Console.WriteLine(Timetable_Grid.SelectedItem);

            Timetable t = Timetable_Grid.SelectedItem as Timetable;

            Timetable.Timetables.Remove(t);

            Set_DataContext(Last_Train_Name);
        }

        public void RemoveTextStart(object sender, EventArgs e)
        {
            if (Start_Filed.Text == "Start Time")
            {
                Start_Filed.Text = "";
            }
        }

        public void AddTextStart(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Start_Filed.Text))
                Start_Filed.Text = "Start Time";
        }

        public void RemoveTextEnd(object sender, EventArgs e)
        {
            if (End_Filed.Text == "End Time")
            {
                End_Filed.Text = "";
            }
        }

        public void AddTextEnd(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(End_Filed.Text))
                End_Filed.Text = "End Time";
        }


        public void RemoveTextComebackStart(object sender, EventArgs e)
        {
            if (Comeback_Start_Filed.Text == "Comeback Start Time")
            {
                Comeback_Start_Filed.Text = "";
            }
        }

        public void AddTextComebackStart(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Comeback_Start_Filed.Text))
                Comeback_Start_Filed.Text = "Comeback Start Time";
        }


        public void RemoveTextComebackEnd(object sender, EventArgs e)
        {
            if (Comeback_End_Filed.Text == "Comeback End Time")
            {
                Comeback_End_Filed.Text = "";
            }
        }

        public void AddTextComebackEnd(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Comeback_End_Filed.Text))
                Comeback_End_Filed.Text = "Comeback End Time";
        }

    }
}
