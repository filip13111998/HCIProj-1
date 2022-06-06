using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serbia_Train.models
{
    public class Wagon :BaseClass
    {
        public TypeWagon VagonType { get; set; }

        public Wagon(TypeWagon vt)
        {
            this.VagonType = vt;
        }

        public int GetSedista()
        {
            if (this.VagonType == TypeWagon.MALI)
            {
                return 10;
            }
            if (this.VagonType == TypeWagon.SREDNJI)
            {
                return 20;
            }
            else
            {
                return 30;
            }
        }

        public String GetImage()
        {
            if (this.VagonType == TypeWagon.MALI)
            {
                return "/assets/wagon1.png";
            }
            if (this.VagonType == TypeWagon.SREDNJI)
            {
                return "/assets/wagon2.png";
            }
            else
            {
                return "/assets/wagon3.png";
            }
        }

        public override String ToString()
        {
            return "wagon typee";
        }
    }
}
