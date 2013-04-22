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
        public BetaalBelasting(string id, int belasting) : base(id)
        {
            this.belasting = belasting;
        }

        public override bool VoerUit(Speler speler)
        {
            if (speler.Betaal(belasting, Speler.BANK))
            {
                Logger.log(speler, "betaald", belasting, " ", Gebeurtenisnaam);
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
            return string.Format("Belasting betalen: {0} geldeenheden aan {1}", belasting, Gebeurtenisnaam);
        }



    }
}
