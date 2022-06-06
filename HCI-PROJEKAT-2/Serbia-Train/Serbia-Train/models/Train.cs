using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serbia_Train.models
{
    public class Train : BaseClass
    {

        public String Name { get; set; }

        public ObservableCollection<Wagon> Wagons{ get;set;} = new ObservableCollection<Wagon>();

        public static ObservableCollection<Train> Trains { get; set; } = new ObservableCollection<Train>();
        //{

        //    new Voz()
        //    {
        //        Name = "Soko",
        //        Vagoni = new ObservableCollection<Vagon>
        //        {
        //            new Vagon(VagonType.MALI),new Vagon(VagonType.SREDNJI)
        //        }

        //    },new Voz()
        //    {
        //        Name = "Galeb",
        //        Vagoni = new ObservableCollection<Vagon>
        //        {
        //            new Vagon(VagonType.SREDNJI),new Vagon(VagonType.SREDNJI)
        //        }
        //    },

        //    new Voz()
        //    {
        //        Name = "Orao",
        //        Vagoni = new ObservableCollection<Vagon>
        //        {
        //            new Vagon(VagonType.VELIKI),new Vagon(VagonType.SREDNJI),new Vagon(VagonType.MALI)
        //        }
        //    }

        //};

        //public static List<Voz> Vozovi { get; set; } = new List<Voz> { 

        //    new Voz()
        //    {
        //        Name = "Soko",
        //        Vagoni = new List<Vagon>
        //        {
        //            new Vagon(VagonType.MALI),new Vagon(VagonType.SREDNJI)
        //        }
        //    },

        //    new Voz()
        //    {
        //        Name = "Galeb",
        //        Vagoni = new List<Vagon>
        //        {
        //            new Vagon(VagonType.SREDNJI),new Vagon(VagonType.SREDNJI)
        //        }
        //    },

        //    new Voz()
        //    {
        //        Name = "Orao",
        //        Vagoni = new List<Vagon>
        //        {
        //            new Vagon(VagonType.VELIKI),new Vagon(VagonType.SREDNJI),new Vagon(VagonType.MALI)
        //        }
        //    }

        //};

        public Train()
        {

        }



        public Train(String name, ObservableCollection<Wagon> vagoniList)
        {
            this.Name = name;
            this.Wagons = vagoniList;
        }


        public static void InitializeTrains()
        {
            Train v = new Train
            {
                Name = "Vrabac",

                Wagons = new ObservableCollection<Wagon>() {
                new Wagon(TypeWagon.MALI),
                new Wagon(TypeWagon.VELIKI),
                new Wagon(TypeWagon.VELIKI),
                new Wagon(TypeWagon.SREDNJI)


            }
            };

            Train v2 = new Train()
            {
                Name = "Soko",
                Wagons = new ObservableCollection<Wagon>
                {
                    new Wagon(TypeWagon.MALI),new Wagon(TypeWagon.SREDNJI)
                }

            };

            Train v3 = new Train()
            {
                Name = "Galeb",
                Wagons = new ObservableCollection<Wagon>
                {
                    new Wagon(TypeWagon.SREDNJI),new Wagon(TypeWagon.SREDNJI)
                }
            };

            Train v4 = new Train()
            {
                Name = "Orao",
                Wagons = new ObservableCollection<Wagon>
                {
                    new Wagon(TypeWagon.VELIKI),new Wagon(TypeWagon.SREDNJI),new Wagon(TypeWagon.MALI)
                }
            };



            Train.Trains.Add(v);
            Train.Trains.Add(v2);
            Train.Trains.Add(v3);
            Train.Trains.Add(v4);

        }


    }
}
