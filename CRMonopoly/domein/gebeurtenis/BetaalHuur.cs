using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRMonopoly.domein.gebeurtenis
{
    class BetaalHuur : AbstractGebeurtenis
    {
        private Straat VerhuurdeStraat { get; set; }

        public BetaalHuur(Straat straat)
        {
            VerhuurdeStraat = straat;
        }

        public override bool VoerUit(Speler speler)
        {
            return speler.Betaal(VerhuurdeStraat.GeefTeBetalenHuur(), VerhuurdeStraat.Eigenaar);
        }

        public override bool IsVerplicht()
        {
            return true;
        }

        public override string Gebeurtenisnaam()
        {
            return Gebeurtenisnamen.BETAAL_HUUR;
        }

        public override string ToString()
        {
            return string.Format("Huur betalen: {0} geldeenheden huur aan {1}", VerhuurdeStraat.GeefTeBetalenHuur(), VerhuurdeStraat.Eigenaar.Name);
        }



    }
}
