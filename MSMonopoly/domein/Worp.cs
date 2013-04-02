using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSMonopoly.domein
{
    public class Worp
    {
        private Dobbelsteen Dobbelsteen { get; set; }

        private int Gedobbeldeworp1 { get; set; }
        private int Gedobbeldeworp2 { get; set; }

        private Worp()
        {
            Dobbelsteen = new Dobbelsteen();
        }

        public int Totaal()
        {
            return Gedobbeldeworp1 + Gedobbeldeworp2;
        }

        public bool isDubbelGegooid()
        {
            return Gedobbeldeworp1 == Gedobbeldeworp2;
        }

        public override string ToString()
        {
            return Totaal() + " (" + Gedobbeldeworp1 + " en " + Gedobbeldeworp2 + ")";
        }

        public static Worp GooiDobbelstenen()
        {
            Worp worp = new Worp();
            worp.Gedobbeldeworp1 = worp.Dobbelsteen.Gooi();
            worp.Gedobbeldeworp2 = worp.Dobbelsteen.Gooi();
            return worp;
        }
    }
}
