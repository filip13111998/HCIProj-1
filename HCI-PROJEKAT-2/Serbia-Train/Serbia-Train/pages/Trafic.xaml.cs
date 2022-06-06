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
    /// Interaction logic for Trafic.xaml
    /// </summary>
    public partial class Trafic : Page
    {

        public static String Line_Name { get; set; }
        public static Line My_Line { get; set; }

        public Trafic()
        {
            InitializeComponent();

            Find_Line();

        }


        public void Find_Line()
        {

            this.Lab_Name.Content = "Line: "+Line_Name;

            My_Line = Line.Line_List.Where(l => l.Name.ToLower().Equals(Line_Name.ToLower())).FirstOrDefault();

            this.DataContext = My_Line;

            this.Line_Timetable_Grid.DataContext = My_Line.ListaRedVoznje;

            Set_All_Timetable_DataContext();

        }

        public void Set_All_Timetable_DataContext()
        {

            List<Timetable> lista = new List<Timetable>(Timetable.Timetables);


            foreach (Line l in Line.Line_List)
            {
                foreach (Timetable tim in l.ListaRedVoznje)
                {
                    if (lista.Contains(tim))
                    {
                        lista.Remove(tim);
                    }
                }
            }

            this.All_Timetable_Grid.DataContext = lista;
        }

       public void Add_Click(object sender , RoutedEventArgs e)
       {
            Timetable t = All_Timetable_Grid.SelectedItem as Timetable;

            //Timetable.Timetables.Remove(t);

            My_Line.ListaRedVoznje.Add(t);

            Set_All_Timetable_DataContext();


        }

        public void Delete_Click(object sender, RoutedEventArgs e)
        {


            Timetable t = Line_Timetable_Grid.SelectedItem as Timetable;

            My_Line.ListaRedVoznje.Remove(t);

            Set_All_Timetable_DataContext();

        }


    }
}
