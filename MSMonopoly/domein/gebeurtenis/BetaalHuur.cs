using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSMonopoly.domein.gebeurtenis
{
    class BetaalHuur : AbstractGebeurtenis
    {
        private Speler HuurTeBetalenSpeler { get; set; }
        private Straat TeBetalenHuurVoorStraat { get; set; }

        public BetaalHuur(Speler speler, Straat straat)
        {
            HuurTeBetalenSpeler = speler;
            TeBetalenHuurVoorStraat = straat;
        }

        public override bool VoerUit()
        {
            return HuurTeBetalenSpeler.Betaal(TeBetalenHuurVoorStraat.Huurprijs, TeBetalenHuurVoorStraat.Eigenaar);
        }

        public override bool IsVerplicht()
        {
            throw new NotImplementedException();
        }

        public override string Gebeurtenisnaam()
        {
            return "Huur betalen";
        }

        public override string ToString()
        {
            return new StringBuilder(Gebeurtenisnaam()).Append(": ").Append(TeBetalenHuurVoorStraat.Huurprijs)
                .Append(" van ").Append(HuurTeBetalenSpeler.Name)
                .Append(" aan ").Append(TeBetalenHuurVoorStraat.Eigenaar).ToString(); 
        }



    }
}
