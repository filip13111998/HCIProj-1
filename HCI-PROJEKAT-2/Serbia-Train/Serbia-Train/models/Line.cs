using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serbia_Train.models
{
    public class Line: BaseClass
    {

        public String Name { get; set; }//7a,7b,4,8,11a....
        public ObservableCollection<Station> ListaStanica { get; set; } = new ObservableCollection<Station>();

        public ObservableCollection<Timetable> ListaRedVoznje { get; set; } = new ObservableCollection<Timetable>();


        public static ObservableCollection<Line> Line_List { get; set; } = new ObservableCollection<Line>();


        public static void Initialize_Line()
        {
            Line l1 = new Line();

            Station s11 = new Station();

            s11.Name = "Stan NS";

            s11.Longitude = 19.8227;

            s11.Latitude = 45.2396;

            Station s12 = new Station();

            s12.Name = "Stan BG";

            s12.Longitude = 20.4612;

            s12.Latitude = 44.8125;

            Station s13 = new Station();

            s13.Name = "Stan KG";

            s13.Longitude = 20.9114;

            s13.Latitude = 44.0128;

            l1.Name = "7a";
            
            l1.ListaStanica = new ObservableCollection<Station>();

            l1.ListaStanica.Add(s11);
            l1.ListaStanica.Add(s12);
            l1.ListaStanica.Add(s13);

            Line l2 = new Line();

            Station s21 = new Station();

            s21.Name = "Stan Uzice";

            s21.Longitude = 19.8425;

            s21.Latitude = 43.8556;

            Station s22 = new Station();

            s22.Name = "Stan Nis";

            s22.Longitude = 21.8954;

            s22.Latitude = 43.3209;

            l2.Name = "11b";

            l2.ListaStanica = new ObservableCollection<Station>();

            l2.ListaStanica.Add(s21);
            l2.ListaStanica.Add(s22);



            Line.Line_List.Add(l1);

            Line.Line_List.Add(l2);


        }

    }
}
