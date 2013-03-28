using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MSMonopoly.domein;

namespace MSMonopoly.domein.gebeurtenis
{
    class KoopStraat : Gebeurtenis
    {
        private Straat TeKopenStraat { get; set; }
        private Speler Koper { get; set; }

        public KoopStraat(Speler speler, Straat straat)
        {
            TeKopenStraat = straat;
            Koper = speler;
        }

        public bool voerUit()
        {
            if (Koper.Betaal(TeKopenStraat.Aankoopprijs, new Speler("Bank")))
            {
                Koper.Add(TeKopenStraat);
                TeKopenStraat.Eigenaar = Koper;
                return true;
            }
            return false;
        }

        public bool isVerplicht()
        {
            return false;
        }

        public override string ToString()
        {
            return Koper.Name + " koopt " + TeKopenStraat.Naam;
        }
    }
}
