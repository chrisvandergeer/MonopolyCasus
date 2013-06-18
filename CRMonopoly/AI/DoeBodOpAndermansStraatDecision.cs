using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein.gebeurtenis;
using CRMonopoly.domein;
using CRMonopoly.domein.velden;

namespace CRMonopoly.AI
{
    class DoeBodOpAndermansStraatDecision : IDecision
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
            // Ga tot aankoop over als het resterende geldbedrag 1.5 * de maximale huur op het hele bord is.
            //return ((speler.Geldeenheden - biedOpStraat.StraatOmOpTeBieden.GeefAankoopprijs())
            //    > (1.5 * speler.Bord.geefMaximalHuurprijs()));
            Console.WriteLine("*************************");
            return true;
        }

    }
}
