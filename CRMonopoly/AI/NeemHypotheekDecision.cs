using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein.gebeurtenis;
using CRMonopoly.domein;

namespace CRMonopoly.AI
{
    public class NeemHypotheekDecision : IDecision
    {
        public Gebeurtenis GeefUitTeVoerenGebeurtenis(Gebeurtenissen gebeurtenissen, Speler speler)
        {
            return gebeurtenissen.GeefGebeurtenis(Gebeurtenisnamen.NEEM_HYPOTHEEK);
        }

        public bool doenJN(Gebeurtenis gebeurtenis, Speler speler)
        {
            return false;
            //speler.Geldeenheden < 10 && spele
        }
    }
}
