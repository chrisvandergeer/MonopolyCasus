using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein.velden;

namespace CRMonopoly.domein.gebeurtenis
{
    class BetaalBelasting : AbstractGebeurtenis
    {
        private int belasting = 0;
        private string belastingNaam = null;
        public BetaalBelasting(string id, int belasting)
        {
            this.belastingNaam = id;
            this.belasting = belasting;
        }

        public override bool VoerUit(Speler speler)
        {
            if (speler.Betaal(belasting, Speler.BANK))
            {
                Logger.log(speler, "betaald", belasting, " ", belastingNaam);
                return true;
            }
            return false;
        }

        public override bool IsVerplicht()
        {
            return true;
        }

        public override string Gebeurtenisnaam()
        {
            return Gebeurtenisnamen.BETAAL_BELASTING;
        }

        public override string ToString()
        {
            return string.Format("Belasting betalen: {0} geldeenheden aan {1}", belasting, belastingNaam);
        }



    }
}
