using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein.gebeurtenis;

namespace CRMonopoly.domein.velden
{
    public class BelastingVeld : Veld
    {
        private int belasting = 0;
        public BelastingVeld(String naam, int belasting)
            : base(naam)
        {
            this.belasting = belasting;
        }

        public override Gebeurtenis bepaalGebeurtenis(Speler speler)
        {
            return new BetaalBelasting(Naam, belasting);
        }

    }
}
