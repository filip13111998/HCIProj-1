using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serbia_Train.models
{
    public class Ticket: BaseClass
    {

        public String Id { get; set; }

        public String TrainName { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public String Relation { get; set; }//BG-NS,BG-NIS...

        public static ObservableCollection<Ticket> Tickets { get; set; } = new ObservableCollection<Ticket>();


        public static void InitializeTickets()
        {
            Ticket t1 = new Ticket()
            {
                Id = "1DR",
                TrainName = "Soko",
                Start = new DateTime(2022, 6, 10, 15, 00, 00),
                End = new DateTime(2022, 6, 10, 17, 00, 00),
                Relation = "BG-NS"
            };

            Ticket t2 = new Ticket()
            {
                Id = "1MR",
                TrainName = "Soko",
                Start = new DateTime(2022, 4, 4, 12, 00, 00),
                End = new DateTime(2022, 4, 4, 13, 00, 00),
                Relation = "BG-NS"
            };

            Ticket t3 = new Ticket()
            {
                Id = "55P",
                TrainName = "Soko",
                Start = new DateTime(2022, 4, 4, 12, 00, 00),
                End = new DateTime(2022, 4, 4, 13, 00, 00),
                Relation = "BG-NS"
            };

            Ticket t4 = new Ticket()
            {
                Id = "TTT",
                TrainName = "Galeb",
                Start = new DateTime(2022, 5, 6, 14, 00, 00),
                End = new DateTime(2022, 7, 6, 19, 00, 00),
                Relation = "NS-NIS"
            };

            Ticket t5 = new Ticket()
            {
                Id = "YQQ",
                TrainName = "Galeb",
                Start = new DateTime(2022, 5, 6, 14, 00, 00),
                End = new DateTime(2022, 7, 6, 19, 00, 00),
                Relation = "NS-NIS"
            };

            Ticket.Tickets.Add(t1);
            Ticket.Tickets.Add(t2);
            Ticket.Tickets.Add(t3);
            Ticket.Tickets.Add(t4);
            Ticket.Tickets.Add(t5);
        }

    }
}
