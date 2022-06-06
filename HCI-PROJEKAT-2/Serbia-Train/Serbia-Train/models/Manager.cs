using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serbia_Train.models
{
    public class Manager
    {

        public String FirstName { get; set; }

        public String LastName { get; set; }

        public String UserName { get; set; }

        public String Password { get; set; }

        public static Manager CurrentManager { get; set; }

        public static List<Manager> managerList = new List<Manager>()
        {

            new Manager()
            {
                FirstName="Nikola",
                LastName = "Nikolic",
                UserName = "nik",
                Password = "nik"
            },
            new Manager()
            {
                FirstName="Mladen",
                LastName = "Malic",
                UserName = "mla",
                Password = "mla"
            },
            new Manager()
            {
                FirstName="Petar",
                LastName = "Peric",
                UserName = "per",
                Password = "per"
            },
            new Manager()
            {
                FirstName="Stefan",
                LastName = "Stefanovic",
                UserName = "ste",
                Password = "ste"
            }


        };

    }
}
