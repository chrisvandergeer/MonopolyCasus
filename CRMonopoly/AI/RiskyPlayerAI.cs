using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein;
using CRMonopoly.domein.gebeurtenis;
using CRMonopoly.domein.gebeurtenis.kans;
using CRMonopoly.domein.velden;

namespace CRMonopoly.AI
{
    class RiskyPlayerAI
    {
        private static double VERKOOPPRIJS_MULTIPLIER = 1.2;
        private static double SAFETYZONE_MULTIPLIER = 1.5;
        //private static ArtificialPlayerIntelligence _instance;

        private List<IDecision> Decisions2Make;
        private DecisionBuilder decisionBuilder;
        private Gebeurtenis geselecteerdeGebeurtenis = null;
        private Gebeurtenis[] voorgaandeGebeurtenissen = new Gebeurtenis[10];

        public RiskyPlayerAI()
        {
            Decisions2Make = new List<IDecision>();
            Decisions2Make.Add(new KoopStraatDecision());
            decisionBuilder = new DecisionBuilder();
        }

        // Standaard Gebeurtenissen afhandelen
        public void HandelWorpAf(Speler speler)
        {
            Console.WriteLine(String.Format("{0}: AI bepaald wat te doen.", speler.Name));
            while ((!speler.GeeftOp) && isErEenGebeurtenisAfTeHandelen(speler))
            {
                voerGeselecteerdeGebeurtenisUit(speler);
            }
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
        private void voerGeselecteerdeGebeurtenisUit(Speler speler)
        {
            Console.WriteLine(String.Format("{0}: AI voert {1} uit.", speler.Name, geselecteerdeGebeurtenis.Gebeurtenisnaam));
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
        private Gebeurtenis selecteerGebeurtenisVanType(GebeurtenisType gebeurtenisType, Speler speler, bool altijdUitvoeren)
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

        // Extra zaken afhandelen binnen de worp.
        public void HandelExtraZakenAfBinnenDeWorp(Speler speler, MonopolyspelController controller)
        {
            Console.WriteLine(String.Format("{0}: AI bepaald wat extra gebeurtenissen uit te voeren.", speler.Name));
            List<VerkoopbaarVeld> aanTeKopenStraten = controller.geefMogelijkeActiesVoorSpeler(speler);
            while (checkOfErStratenZijnDieAanTeKopenZijn(speler, controller, aanTeKopenStraten))
            {
                voerGeselecteerdeTaakUit(speler);
                // Of de andere speler het aanbod geaccepteerd heeft of niet, we gaan een andere straat proberen.
                aanTeKopenStraten.Remove(((DoeBodOpAndermansStraat)geselecteerdeGebeurtenis).StraatOmOpTeBieden);
            }
        }
        private void voerGeselecteerdeTaakUit(Speler speler)
        {
            Console.WriteLine(String.Format("{0}: AI voert extra taak {1} uit.", speler.Name, geselecteerdeGebeurtenis.Gebeurtenisnaam));
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

        private bool checkOfErStratenZijnDieAanTeKopenZijn(Speler speler, MonopolyspelController controller, List<VerkoopbaarVeld> aanTeKopenStraten)
        {
            selecteerDeJuisteStraten(speler, aanTeKopenStraten);
            VerkoopbaarVeld selectedStraat = selecteerDeJuisteStraat(speler, controller, aanTeKopenStraten);
            if (selectedStraat != null)
            {
                geselecteerdeGebeurtenis = new DoeBodOpAndermansStraat(selectedStraat, (int)(selectedStraat.GeefAankoopprijs() * 1.1));
            }
            return selectedStraat != null;
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
        private VerkoopbaarVeld selecteerDeJuisteStraat(Speler speler, MonopolyspelController controller, List<VerkoopbaarVeld> aantekopenStraten)
        {
            VerkoopbaarVeld veld = null;

            foreach (VerkoopbaarVeld tempVeld in aantekopenStraten)
            {
                if (veld == null) {
                    veld = tempVeld;
                }
                else if (veldIsAanTeKopen(speler, controller, tempVeld) && veld.GeefTeBetalenHuur(speler) < tempVeld.GeefTeBetalenHuur(speler))
                {   // Het veld selecteren als de huurprijs hoger is dan het nu geselecteerde veld
                    veld = tempVeld;
                }
            }
            
            return veld;
        }
        private bool veldIsAanTeKopen(Speler speler, MonopolyspelController controller, VerkoopbaarVeld tempVeld)
        {
            // Een veld is aan te kopen als het resterende geldbedrag 1.5 * de maximale huur op het hele bord is.
            return ((speler.Geldeenheden - (int)(tempVeld.GeefAankoopprijs() * VERKOOPPRIJS_MULTIPLIER))
                > (SAFETYZONE_MULTIPLIER * controller.geefMaximalHuurprijs()));
        }
    }
}
