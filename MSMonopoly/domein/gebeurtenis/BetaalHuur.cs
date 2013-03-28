using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSMonopoly.domein.gebeurtenis
{
    class BetaalHuur : Gebeurtenis
    {
        private Speler HuurTeBetalenSpeler { get; set; }
        private Straat TeBetalenHuurVoorStraat { get; set; }

        public BetaalHuur(Speler speler, Straat straat)
        {
            HuurTeBetalenSpeler = speler;
            TeBetalenHuurVoorStraat = straat;
        }

        public bool voerUit()
        {
            return HuurTeBetalenSpeler.Betaal(TeBetalenHuurVoorStraat.Huurprijs, TeBetalenHuurVoorStraat.Eigenaar);
        }

        public bool isVerplicht()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return HuurTeBetalenSpeler.Name + " betaald " + TeBetalenHuurVoorStraat.Huurprijs + 
                " geldeenheden huur aan " + TeBetalenHuurVoorStraat.Eigenaar;
        }
    }
}
