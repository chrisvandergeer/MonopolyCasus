using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein;
using CRMonopoly.domein.gebeurtenis;

namespace CRMonopoly.AI
{
    class ArtificialPlayerIntelligence
    {
        //private static ArtificialPlayerIntelligence _instance;

        private List<IDecision> Decisions2Make;
        private DecisionBuilder decisionBuilder;

        public ArtificialPlayerIntelligence()
        {
            Decisions2Make = new List<IDecision>();
            Decisions2Make.Add(new KoopStraatDecision());
            decisionBuilder = new DecisionBuilder();
        }

        //public static ArtificialPlayerIntelligence Instance()
        //{
        //    if (_instance == null)
        //    {
        //        ArtificialPlayerIntelligence instance = new ArtificialPlayerIntelligence();
        //        _instance = instance;
        //        return instance;
        //    }
        //    return _instance;
        //}

        public void HandelWorpAf(Speler speler)
        {
            //foreach (IDecision decision in Decisions2Make)
            //{
            //    Gebeurtenis gebeurtenis = decision.GeefUitTeVoerenGebeurtenis(gebeurtenissen, speler);
            //    if (gebeurtenis != null)
            //    {
            //        GebeurtenisResult result = gebeurtenis.VoerUit(speler);
            //        gebeurtenissen.Add(result);
            //        if (result.IsUitgevoerd)
            //            gebeurtenissen.Remove(gebeurtenis);
            //    }
            //}
            // Derde argument zou een instance moeten zijn van een Beslissings class voor de category van Gebeurtenis.
            // Hoe wel de methode kan die zelf ook wel ophalen.
            handelGebeurtenissenAfVanType(GebeurtenisType.OntvangGeld, speler, true);
            handelGebeurtenissenAfVanType(GebeurtenisType.BetaalGeld, speler, false);
            handelGebeurtenissenAfVanType(GebeurtenisType.Verplaats, speler, true);
            handelGebeurtenissenAfVanType(GebeurtenisType.Aankopen, speler, false);
        }

        private void handelGebeurtenissenAfVanType(GebeurtenisType gebeurtenisType, Speler speler, bool altijdUitvoeren)
        {
            Gebeurtenissen ontvangsten = speler.UitTeVoerenGebeurtenissen.GeefGebeurtenissenVanType(gebeurtenisType);
            foreach (Gebeurtenis g in ontvangsten)
            {
                if (altijdUitvoeren || g.IsVerplicht())
                {
                    voerGebeurtenisUit(speler, g);
                }
                else
                {
                    IDecision beslisser = decisionBuilder.geefDecisionVoorType(gebeurtenisType);
                    if (beslisser.doenJN(g, speler))
                    {
                        voerGebeurtenisUit(speler, g);
                    }
                    else {
                        GebeurtenisResult result = GebeurtenisResult.NietUitgevoerd(speler, "heeft", g.Gebeurtenisnaam, "niet uitgevoerd omdat deze optioneel is.");
                        speler.UitTeVoerenGebeurtenissen.Add(result);
                        speler.UitTeVoerenGebeurtenissen.Remove(g);
                    }
                }
            }
        }

        private static void voerGebeurtenisUit(Speler speler, Gebeurtenis g)
        {
            GebeurtenisResult result = g.VoerUit(speler);
            if (result.IsUitgevoerd)
            {
                speler.UitTeVoerenGebeurtenissen.Add(result);
                speler.UitTeVoerenGebeurtenissen.Remove(g);
            }
        }

        private void handelVerplichteGebeurtenissenAf(Speler speler)
        {
            Gebeurtenissen verplichtingen = speler.UitTeVoerenGebeurtenissen.GeefVerplichteGebeurtenissen();
            verplichtingen.GeefGebeurtenissenVanType(GebeurtenisType.OntvangGeld);
            throw new NotImplementedException();
        }
    }
}
