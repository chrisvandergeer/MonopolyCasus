using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRMonopoly.domein
{
    public class Worp
    {
        private static Dobbelsteen _dobbelsteen = new Dobbelsteen();

        private Worp()
        {
        }

        public int Gedobbeldeworp1 { get; set; }
        public int Gedobbeldeworp2 { get; set; }

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
            worp.Gedobbeldeworp1 = _dobbelsteen.Gooi();
            worp.Gedobbeldeworp2 = _dobbelsteen.Gooi();
            return worp;
        }
    }
}
