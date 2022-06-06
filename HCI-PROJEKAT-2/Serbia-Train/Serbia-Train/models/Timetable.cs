using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serbia_Train.models
{
    public class Timetable: BaseClass
    {

        public TimeSpan Start { get; set; }

        public TimeSpan End { get; set; }

        public TimeSpan ComebackStart { get; set; }

        public TimeSpan ComebackEnd { get; set; }

        public Train Train { get; set; }

        public TypeTimetable TypeTimetable { get; set; }

        public static ObservableCollection<Timetable> Timetables { get; set; } = new ObservableCollection<Timetable>();


        public static void Initialize_Timetable()
        {
            Timetable t1 = new Timetable() {
                Start = new TimeSpan(13,0,0),
                End = new TimeSpan(15, 0, 0),
                ComebackStart = new TimeSpan(16, 0, 0),
                ComebackEnd = new TimeSpan(18, 0, 0),
                TypeTimetable = TypeTimetable.SVAKI_DAN
            };

            Train tr1 = Train.Trains.Where(t=> t.Name.Equals("Vrabac")).FirstOrDefault();

            t1.Train = tr1;

            

            Timetable t2 = new Timetable()
            {
                Start = new TimeSpan(10, 30, 0),
                End = new TimeSpan(11, 30, 0),
                ComebackStart = new TimeSpan(19, 30, 0),
                ComebackEnd = new TimeSpan(20, 30, 0),
                TypeTimetable = TypeTimetable.VIKEND
            };


            Train tr2 = Train.Trains.Where(t => t.Name.Equals("Soko")).FirstOrDefault();

            t2.Train = tr2;

            

            Timetables.Add(t1);

            Timetables.Add(t2);
        }


    }
}
