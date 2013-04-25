using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein.velden;

namespace CRMonopoly.domein.gebeurtenis
{
    class BetaalHuur : AbstractGebeurtenis
    {
        private velden.Station station;

        private VerkoopbaarVeld VeldWaarvoorHuurWordtOntvangen { get; set; }

        public BetaalHuur(VerkoopbaarVeld veld) : base("Huur betalen")
        {
            VeldWaarvoorHuurWordtOntvangen = veld;
        }

        public override bool VoerUit(Speler speler)
        {
            int huurbedrag = VeldWaarvoorHuurWordtOntvangen.GeefTeBetalenHuur();
            Speler eigenaar = VeldWaarvoorHuurWordtOntvangen.GeefEigenaar();
            if (speler.Betaal(huurbedrag, eigenaar))
            {
                Logger.log(Gebeurtenisnaam, ":", huurbedrag, "aan", eigenaar);
                return true;
            }
            return false;
        }

        public override bool IsVerplicht()
        {
            return true;
        }

        public override string ToString()
        {
            return string.Format("Huur betalen: {0} geldeenheden huur aan {1}", VeldWaarvoorHuurWordtOntvangen.GeefTeBetalenHuur(), VeldWaarvoorHuurWordtOntvangen.GeefEigenaar().Name);
        }
        
    }
}
