using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoly.domein;
using Monopoly.domein.gebeurtenissen;
using Monopoly.domein.labels;

namespace Monopoly.builders
{
    public class AlgemeenFondsKaartenbuilder
    {
        private Spelbord Bord { get; set; }

        public AlgemeenFondsKaartenbuilder(Spelbord bord)
        {
            Bord = bord;
        }

        public GebeurtenisStapel build()
        {
            List<IGebeurtenis> kaarten = new List<IGebeurtenis>();
            kaarten.Add(new OntvangGeld(100).SetTekst("U erft euro 100"));
            kaarten.Add(new OntvangGeld(25).SetTekst("U ontvangt rente van 7% preferente aandelen euro 25"));
            kaarten.Add(new OntvangGeld(200).SetTekst("Een vergissing van de bank in uw voordeel, u ontvangt euro 200"));
            kaarten.Add(VerplaatsSpeler.CreateVerplaatsAchteruit("Ga terug naar Dorpstraat", Bord.GeefVeld(Veldnamen.DORPSSTRAAT)));
            kaarten.Add(new GaDirectNaarDeGevangenis());
            kaarten.Add(new OntvangGeld(10).SetTekst("U hebt de tweede prijs in een schoonheidswedstrijd gewonnen en ontvangt euro 10"));
            kaarten.Add(new BetaalGeld(50).SetTekst("Betaal uw doktersrekening euro 50"));
            kaarten.Add(new BetaalGeld(50).SetTekst("Betaal uw verzekeringspremie euro 50"));
            kaarten.Add(new OntvangGeld(50).SetTekst("Door verkoop van effecten ontvangt u euro 50"));
            //_kaarten.Add(new VerlaatDeGevangenis(_kaarten));
            kaarten.Add(new OntvangGeld(20).SetTekst("Restitutie inkomstenbelasting, u ontvangt euro 20"));
            kaarten.Add(new OntvangGeld(100).SetTekst("Lijfrente vervalt, u ontvangt euro 100"));
            kaarten.Add(new BetaalGeld(100).SetTekst("Betaal het hospitaal euro 100"));
            kaarten.Add(VerplaatsSpeler.CreateVerplaatsVooruit("Ga verder naar Start", Bord.GeefVeld(Veldnamen.START))); 
            return new GebeurtenisStapel(kaarten, "Algemeen Fonds");
        }
    }
}
