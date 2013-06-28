using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein;
using CRMonopoly.domein.gebeurtenis;
using CRMonopoly.domein.gebeurtenis.kans;
using CRMonopoly.domein.velden;
using CRMonopoly.builders;

namespace CRMonopoly.AI
{
    // Deze class eindigd waarschijnlijk als abstract class voor de verschillende AI classes.
    // Een beslissingen van de AI liggen in de volgorde waarin hij de verschillende mogelijkheden aftast.
    // Bijv. Eerst straten kopen en daarna pas huizen of andersom.
    // Een andere variabele is de keuze of een aankoop kan doorgaan of niet. D.w.z. Neemt het risico (alles
    // kopen zolang er geld is) of weinig risico (bijv. altijd 500 achter de hand hebben).
    // Een andere variabele is wanneer over te gaan tot een aankoop. Bijv. een onverkocht straat altijd kopen,
    // maar alleen een bod op een straat doen 50% van de beurten.
    // Ook de volorde van hypotheek terug betalen vs. nieuwe aankopen is een eigenschap van de betreffende AI.
    //
    // Verder kan ik me voorstellen dat een bod op een straat afgewezen, maar dat de andere speler met een 
    // tegenvoorstel komt (in de vorm van een gebeurtenis).
    abstract class AbstractPlayerAI : IArtificialPlayerIntelligence
    {
        private static double VERKOOPPRIJS_MULTIPLIER = 1.2;
        //private static double SAFETYZONE_MULTIPLIER = 1.5;
        //private static ArtificialPlayerIntelligence _instance;

        protected List<IDecision> Decisions2Make;
        protected DecisionBuilder decisionBuilder;
        //private Gebeurtenis geselecteerdeGebeurtenis = null;
        private Gebeurtenis[] voorgaandeGebeurtenissen = new Gebeurtenis[10];

        public AbstractPlayerAI()
        {
            Decisions2Make = new List<IDecision>();
            Decisions2Make.Add(new KoopStraatDecision());
            decisionBuilder = new DecisionBuilder();
        }

        // Standaard Gebeurtenissen afhandelen
        public void HandelWorpAf(Speler speler)
        {
            Console.WriteLine(String.Format("{0}: {1} bepaald wat te doen.", speler.Name, this.GetType()));
            Gebeurtenis geselecteerdeGebeurtenis = null;
            while ( (geselecteerdeGebeurtenis = isErEenGebeurtenisAfTeHandelen(speler)) != null )
            {
                voerGeselecteerdeGebeurtenisUit(speler, geselecteerdeGebeurtenis);
                if (speler.GeeftOp)
                {
                    break;
                }
            }
        }
        protected abstract Gebeurtenis isErEenGebeurtenisAfTeHandelen(Speler speler);
        //{
        //    Gebeurtenis gebeurtenis = null;
        //    gebeurtenis = selecteerGebeurtenisVanType(GebeurtenisType.MayorEvent, speler, true);
        //    if (gebeurtenis == null) gebeurtenis = selecteerGebeurtenisVanType(GebeurtenisType.OntvangGeld, speler, true);
        //    if (gebeurtenis == null) gebeurtenis = selecteerGebeurtenisVanType(GebeurtenisType.BetaalGeld, speler, false);
        //    if (gebeurtenis == null) gebeurtenis = selecteerGebeurtenisVanType(GebeurtenisType.Verplaats, speler, true);
        //    if (gebeurtenis == null) gebeurtenis = selecteerGebeurtenisVanType(GebeurtenisType.Aankopen, speler, false);
        //    if (gebeurtenis == null) gebeurtenis = selecteerGebeurtenisVanType(GebeurtenisType.Aankopen, speler, false);

        //    return gebeurtenis;
        //}
        // Extra zaken afhandelen binnen de worp.
        public abstract void HandelExtraZakenAfBinnenDeWorp(Speler speler);
        //{
        //    Console.WriteLine(String.Format("{0}: {1} bepaald wat extra gebeurtenissen uit te voeren.", speler.Name, this.GetType()));
        //    gaNaOfErStratenTeKoopZijn(speler);

        //}


        private void voerGeselecteerdeGebeurtenisUit(Speler speler, Gebeurtenis geselecteerdeGebeurtenis)
        {
            Console.WriteLine(String.Format("{0}: {2} voert {1} uit.", speler.Name, geselecteerdeGebeurtenis.Gebeurtenisnaam, this.GetType()));
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
        protected Gebeurtenis selecteerGebeurtenisVanType(GebeurtenisType gebeurtenisType, Speler speler, bool altijdUitvoeren)
        {
            Gebeurtenissen gebeurtenissen = speler.UitTeVoerenGebeurtenissen.GeefGebeurtenissenVanType(gebeurtenisType);
            Gebeurtenis gebeurtenis = selecteerVerplichteGebeurtenis(speler, altijdUitvoeren, gebeurtenissen);
            if (gebeurtenis == null)
            {
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

        protected void gaNaOfErStratenTeKoopZijn(Speler speler)
        {
            List<VerkoopbaarVeld> aanTeKopenStraten = speler.geefMogelijkeStraatAankopenVoorSpeler();
            Gebeurtenis geselecteerdeGebeurtenis = null;
            while ((geselecteerdeGebeurtenis = checkOfErStratenZijnDieAanTeKopenZijn(speler, aanTeKopenStraten)) != null)
            {
                voerGeselecteerdeTaakUit(speler, geselecteerdeGebeurtenis);
                // Of de andere speler het aanbod geaccepteerd heeft of niet, we gaan een andere straat proberen.
                aanTeKopenStraten.Remove(((DoeBodOpAndermansStraat)geselecteerdeGebeurtenis).StraatOmOpTeBieden);
            }
        }
        protected void gaNaOfIkHuizenKanBouwen(Speler speler)
        {
            List<VerkoopbaarVeld> stratenWaaropGebouwdKanWorden = speler.geefMogelijkeStraatWaaropGebouwdKanWorden();
            Gebeurtenis geselecteerdeGebeurtenis = null;
            while ((geselecteerdeGebeurtenis = checkOfErStratenTeBebouwenZijn(speler, stratenWaaropGebouwdKanWorden)) != null)
            {
                voerGeselecteerdeTaakUit(speler, geselecteerdeGebeurtenis);
                // Of de andere speler het aanbod geaccepteerd heeft of niet, we gaan een andere straat proberen.
                stratenWaaropGebouwdKanWorden.Remove(((DoeBodOpAndermansStraat)geselecteerdeGebeurtenis).StraatOmOpTeBieden);
            }
        }

        private Gebeurtenis checkOfErStratenTeBebouwenZijn(Speler speler, List<VerkoopbaarVeld> stratenWaaropGebouwdKanWorden)
        {
            Gebeurtenis geselecteerdeGebeurtenis = null;
            Straat selectedStraat = selecteerDeStraatOmOpTeBouwen(speler, stratenWaaropGebouwdKanWorden);
            if (selectedStraat != null)
            {
                geselecteerdeGebeurtenis = new KoopHuis(selectedStraat);
            }
            return geselecteerdeGebeurtenis;
        }
        private Straat selecteerDeStraatOmOpTeBouwen(Speler speler, List<VerkoopbaarVeld> stratenWaaropGebouwdKanWorden)
        {
            return null;
        }
        private void voerGeselecteerdeTaakUit(Speler speler, Gebeurtenis geselecteerdeGebeurtenis)
        {
            Console.WriteLine(String.Format("{0}: {2} voert extra taak {1} uit.", speler.Name, geselecteerdeGebeurtenis.Gebeurtenisnaam, this.GetType()));
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

        private Gebeurtenis checkOfErStratenZijnDieAanTeKopenZijn(Speler speler, List<VerkoopbaarVeld> aanTeKopenStraten)
        {
            Gebeurtenis geselecteerdeGebeurtenis = null;
            selecteerDeJuisteStraten(speler, aanTeKopenStraten);
            VerkoopbaarVeld selectedStraat = selecteerDeJuisteStraat(speler, aanTeKopenStraten);
            if (selectedStraat != null)
            {
                geselecteerdeGebeurtenis = new DoeBodOpAndermansStraat(selectedStraat, (int)(selectedStraat.GeefAankoopprijs() * 1.1));
            }
            return geselecteerdeGebeurtenis;
        }
        private void selecteerDeJuisteStraten(Speler speler, List<VerkoopbaarVeld> aantekopenStraten)
        {
            List<VerkoopbaarVeld> stratenNietAanTeKopen = new List<VerkoopbaarVeld>();
            foreach (VerkoopbaarVeld veld in aantekopenStraten)
            {
                // Als het een NutsBedrijf is gaan we een aanbod doen.
                if (veld is Nutsbedrijf)
                {
                    if (! spelerBezitHetAndereNutsbedrijfInDezeStad(speler, veld) )
                    {
                        stratenNietAanTeKopen.Add(veld);
                    }
                }
                else if (( veld is Straat) && ( ( AmsterdamBuilder.Instance.Amsterdam.Contains((Straat) veld) ) || ( OnsDorpBuilder.Instance.OnsDorp.Contains((Straat) veld) )))
                {
                    if (!spelerBezitHetAndereNutsbedrijfInDezeStad(speler, veld))
                    {
                        stratenNietAanTeKopen.Add(veld);
                    }
                }

                else {
                    // Zo niet, dan doen we en bod als de speler 2 van de straten van de Stad in bezit heeft.
                    if (! spelerBezitMinimaalTweeStratenInDezeStad(speler, veld))
                    {
                        stratenNietAanTeKopen.Add(veld);
                    }
                }
            }
            // Removing de straten niet aan te kopen van de lijst van aan te kopen straten.
            foreach (VerkoopbaarVeld veld in stratenNietAanTeKopen)
            {
                aantekopenStraten.Remove(veld);
            }
        }

        private bool spelerBezitHetAndereNutsbedrijfInDezeStad(Speler speler, VerkoopbaarVeld veld)
        {
            foreach (VerkoopbaarVeld tempVeld in speler.StratenInBezit)
            {
                if ((tempVeld is Nutsbedrijf) && tempVeld != veld)
                {
                    return true;
                }
            }
            return false;
        }
        private bool spelerBezitMinimaalTweeStratenInDezeStad(Speler speler, VerkoopbaarVeld biedOpStraat)
        {
            int aantal = speler.Bord.geeftAantalStratenInDeStadVanDezeStraatDieInBezitZijnVanSpeler(biedOpStraat, speler);
            return aantal >= 2;
        }
        private VerkoopbaarVeld selecteerDeJuisteStraat(Speler speler, List<VerkoopbaarVeld> aantekopenStraten)
        {
            VerkoopbaarVeld veld = null;

            foreach (VerkoopbaarVeld tempVeld in aantekopenStraten)
            {
                if (veld == null) {
                    veld = tempVeld;
                }
                else if (veldIsAanTeKopen(speler, tempVeld) && veldLevertMeerHuurOp(speler, veld, tempVeld))
                {
                    veld = tempVeld;
                }
            }
            
            return veld;
        }

        private static bool veldLevertMeerHuurOp(Speler speler, VerkoopbaarVeld veld, VerkoopbaarVeld tempVeld)
        {
            return veld.GeefTeBetalenHuur(speler) < tempVeld.GeefTeBetalenHuur(speler);
        }

        private bool veldIsAanTeKopen(Speler speler, VerkoopbaarVeld tempVeld)
        {
            return ((speler.Geldeenheden - geefMijnBodVoorVeld(tempVeld)) > MinimumBedragDatInKasMoetBlijven(speler));
        }

        private int geefMijnBodVoorVeld(VerkoopbaarVeld tempVeld)
        {
            return (int)(tempVeld.GeefAankoopprijs() * VERKOOPPRIJS_MULTIPLIER);
        }

        abstract protected double MinimumBedragDatInKasMoetBlijven(Speler speler);
        //{
        //    return (SAFETYZONE_MULTIPLIER * controller.geefMaximalHuurprijs());
        //}
    }
}
