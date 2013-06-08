using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein;
using CRMonopoly.domein.gebeurtenis;
using CRMonopoly.domein.gebeurtenis.kans;

namespace CRMonopoly.AI
{
    class ArtificialPlayerIntelligence
    {
        //private static ArtificialPlayerIntelligence _instance;

        private List<IDecision> Decisions2Make;
        private DecisionBuilder decisionBuilder;
        private Gebeurtenis geselecteerdeGebeurtenis = null;
        private Gebeurtenis[] voorgaandeGebeurtenissen = new Gebeurtenis[10];

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
            Console.WriteLine(String.Format("{0}: AI bepaald wat te doen.", speler.Name));
            while ((!speler.GeeftOp) && isErEenGebeurtenisAfTeHandelen(speler))
            {
                voerGeselecteerdeGebeurtenisUit(speler);
            }
        }
        public void HandelExtraGebeurtenissenBinnenDezeWorpAf(Speler speler, MonopolyspelController controller)
        {
            Console.WriteLine(String.Format("{0}: AI bepaald wat extra gebeurtenissen uit te voeren.", speler.Name));
            while ((! speler.GeeftOp) && isErEenExtraGebeurtenisAfTeHandelen(speler, controller))
            {
                voerGeselecteerdeGebeurtenisUit(speler);
            }
        }

        private static void haalExtraGebeurtenissen(Speler speler, MonopolyspelController controller)
        {
            Gebeurtenissen mogelijkeActies = controller.geefMogelijkeActiesVoorSpeler(speler);
            speler.UitTeVoerenGebeurtenissen.Add(mogelijkeActies);
        }

        private bool isErEenGebeurtenisAfTeHandelen(Speler speler)
        {
            geselecteerdeGebeurtenis = null;
            geselecteerdeGebeurtenis = selecteerGebeurtenisVanType(GebeurtenisType.MayorEvent, speler, true);
            if (geselecteerdeGebeurtenis == null) geselecteerdeGebeurtenis = selecteerGebeurtenisVanType(GebeurtenisType.OntvangGeld, speler, true);
            if (geselecteerdeGebeurtenis == null) geselecteerdeGebeurtenis = selecteerGebeurtenisVanType(GebeurtenisType.BetaalGeld, speler, false);
            if (geselecteerdeGebeurtenis == null) geselecteerdeGebeurtenis = selecteerGebeurtenisVanType(GebeurtenisType.Verplaats, speler, true);
            if (geselecteerdeGebeurtenis == null) geselecteerdeGebeurtenis = selecteerGebeurtenisVanType(GebeurtenisType.Aankopen, speler, false);

            return (geselecteerdeGebeurtenis != null);
        }

        private bool isErEenExtraGebeurtenisAfTeHandelen(Speler speler, MonopolyspelController controller)
        {
            haalExtraGebeurtenissen(speler, controller);
            return isErEenGebeurtenisAfTeHandelen(speler);
        }

        private Gebeurtenis selecteerGebeurtenisVanType(GebeurtenisType gebeurtenisType, Speler speler, bool altijdUitvoeren)
        {
            Gebeurtenissen gebeurtenissen = speler.UitTeVoerenGebeurtenissen.GeefGebeurtenissenVanType(gebeurtenisType);
            Gebeurtenis gebeurtenis = selecteerVerplichteGebeurtenis(speler, altijdUitvoeren, gebeurtenissen);
            if (gebeurtenis == null)
            {
                if (gebeurtenis is DoeBodOpAndermansStraat)
                {
                    Console.WriteLine("****");
                }
                gebeurtenis = selecteerOptioneleGebeurtenis(speler, altijdUitvoeren, gebeurtenissen);
            }
            return gebeurtenis;
        }

        private Gebeurtenis selecteerOptioneleGebeurtenis(Speler speler, bool altijdUitvoeren, Gebeurtenissen gebeurtenissen)
        {
            foreach (Gebeurtenis g in gebeurtenissen)
            {
                IDecision beslisser = decisionBuilder.geefDecisionVoorType(g.GetType());
                if (beslisser.doenJN(g, speler))
                {
                    return g;
                }
            }
            return null;
        }

        private Gebeurtenis selecteerVerplichteGebeurtenis(Speler speler, bool altijdUitvoeren, Gebeurtenissen gebeurtenissen)
        {
            foreach (Gebeurtenis g in gebeurtenissen)
            {
                if (altijdUitvoeren || g.IsVerplicht())
                {
                    return g;
                }
            }
            return null;
        }

        private void voerGeselecteerdeGebeurtenisUit(Speler speler)
        {
            Console.WriteLine(String.Format("{0}: AI voert {1} uit.", speler.Name, geselecteerdeGebeurtenis.Gebeurtenisnaam));
            checkGeselecteerdeGebeurtenis(speler);
            GebeurtenisResult result = geselecteerdeGebeurtenis.VoerUit(speler);
            if (result.IsUitgevoerd)
            {
                speler.UitTeVoerenGebeurtenissen.Add(result);
                speler.UitTeVoerenGebeurtenissen.Remove(geselecteerdeGebeurtenis);
            }
            else
            {
                speler.UitTeVoerenGebeurtenissen.Add(result);
                if (geselecteerdeGebeurtenis.Gebeurtenistype == GebeurtenisType.BetaalGeld)
                {
                    Gebeurtenis geefMaarOp = new GeefOp("Handdoek in de ring", String.Format("Speler '{0}' kan '{1}' niet betalen en geeft op.", speler.Name, geselecteerdeGebeurtenis.Gebeurtenisnaam));
                    speler.UitTeVoerenGebeurtenissen.Add(geefMaarOp);
                }
            }
        }

        private void checkGeselecteerdeGebeurtenis(Speler speler)
        {
            for (int teller = voorgaandeGebeurtenissen.Length - 1; teller > 0 ; teller--)
            {
                voorgaandeGebeurtenissen[teller] = voorgaandeGebeurtenissen[teller - 1];
            }
            voorgaandeGebeurtenissen[0] = geselecteerdeGebeurtenis;
            // If all voorgaandeGebeurtenissen are the same we are in an endlessloop
            bool allAreTheSame = true;
            for (int teller = 0; allAreTheSame && (teller < voorgaandeGebeurtenissen.Length - 1); teller++)
            {
                allAreTheSame &= (voorgaandeGebeurtenissen[teller] == voorgaandeGebeurtenissen[teller + 1]);
            }
            if (allAreTheSame)
            {
                Gebeurtenis geefMaarOp = new GeefOp("EndlessLoop", String.Format("Speler '{0}' zit in een loop voor gebeurtenis '{1}'.", speler.Name, geselecteerdeGebeurtenis.Gebeurtenisnaam));
                speler.UitTeVoerenGebeurtenissen.Add(geefMaarOp);
            }
        }

        //private void handelVerplichteGebeurtenissenAf(Speler speler)
        //{
        //    Gebeurtenissen verplichtingen = speler.UitTeVoerenGebeurtenissen.GeefVerplichteGebeurtenissen();
        //    verplichtingen.GeefGebeurtenissenVanType(GebeurtenisType.OntvangGeld);
        //    throw new NotImplementedException();
        //}
    }
}
