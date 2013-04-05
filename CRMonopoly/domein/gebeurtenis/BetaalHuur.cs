using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRMonopoly.domein.gebeurtenis
{
    class BetaalHuur : AbstractGebeurtenis
    {
        private Speler Huurbetaler { get; set; }
        private Straat VerhuurdeStraat { get; set; }

        public BetaalHuur(Speler speler, Straat straat)
        {
            Huurbetaler = speler;
            VerhuurdeStraat = straat;
        }

        public override bool VoerUit()
        {
            return Huurbetaler.Betaal(VerhuurdeStraat.GeefTeBetalenHuur(), VerhuurdeStraat.Eigenaar);
        }

        public override bool IsVerplicht()
        {
            return true;
        }

        public override string Gebeurtenisnaam()
        {
            return "Huur betalen";
        }

        public override string ToString()
        {
            return string.Format("{0} betaald {1} geldeenheden huur aan {2}", Huurbetaler.Name, VerhuurdeStraat.GeefTeBetalenHuur(), VerhuurdeStraat.Eigenaar.Name);
        }



    }
}
