using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein.gebeurtenis;
using CRMonopoly.domein;

namespace CRMonopoly.AI
{
    class KoopStraatDecision : IDecision
    {
        public Gebeurtenis GeefUitTeVoerenGebeurtenis(Gebeurtenissen gebeurtenissen, Speler speler)
        {
            Gebeurtenis gebeurtenis = null;
            if (speler.Geldeenheden > 200)
                gebeurtenis = gebeurtenissen.GeefGebeurtenis(Gebeurtenisnamen.KOOP_STRAAT);
            return gebeurtenis;
        }
        public bool doenJN(Gebeurtenis g, Speler speler)
        {
            KoopStraat koopStraat = (KoopStraat) g;
            // Ga tot aankoop over als het resterende geldbedrag 200 is.
            return( (speler.Geldeenheden - koopStraat.TeKopenStraat.GeefAankoopprijs()) > 200);
        }
    }
}
