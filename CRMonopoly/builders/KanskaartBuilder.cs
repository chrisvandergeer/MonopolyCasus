using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein;
using CRMonopoly.domein.gebeurtenis;
using CRMonopoly.domein.gebeurtenis.kans;

namespace CRMonopoly.builders
{
    class KanskaartBuilder
    {
        private static string gaNaarBartiljorisstraat = "Ga verder naar Barteljorisstraat. Indien u langs 'Start' komt, ontvangt u ƒ 200";
        private static string gaNaarStationWest = "Reis naar station 'West' en indien u langs 'Start' komt, ontvangt u ƒ 200";
        private static string gaNaarStart = "Ga verder naar 'Start'";

        private Monopolybord Bord { get; set; }

        public KanskaartBuilder(Monopolybord bord)
        {
            Bord = bord;
        }

        public List<Gebeurtenis> build()
        {
            List<Gebeurtenis> kaarten = new List<Gebeurtenis>();
            kaarten.Add(new BetaalGeld(150, "Betaal schoolgeld ƒ 150"));
            kaarten.Add(new BoeteVoorTeSnelRijden());
            kaarten.Add(new GaNaarGebeurtenis(Bord.getBarteljorisstraat(), gaNaarBartiljorisstraat));
            kaarten.Add(new GaNaarGebeurtenis(Bord.GeefStationWest(), gaNaarStationWest));
            kaarten.Add(new GaNaarGebeurtenis(Bord.StartVeld(), gaNaarStart));
            // Ga drie plaatsen terug
            // Ga direct naar de gevangenis. Ga niet langs "Start". U ontvangt geen ƒ 200
            kaarten.Add(new GaNaarGebeurtenis(Bord.Straat(GroningenBuilder.HEERESTRAAT), "Ga verder naar de Herestraat. Indien u langs 'Start' komt ontvangt u ƒ 200"));
            kaarten.Add(new OntvangGeld(50, "De bank betaalt u ƒ 50 dividend"));
            kaarten.Add(new VerlaatDeGevangenis(kaarten));
            // Repareer uw huizen. Betaal voor elk huis ƒ 25, betaal voor elk hotel ƒ 100
            // U wordt aangeslagen voor straatgeld. ƒ 40 per huis, ƒ 115 per hotel
            kaarten.Add(new OntvangGeld(150, "Uw bouwverzekering vervalt, u ontvangt ƒ 150"));
            kaarten.Add(new BetaalGeld(20, "Aangehouden wegens dronkenschap ƒ 20 boete"));
            kaarten.Add(new GaNaarGebeurtenis(Bord.Straat(AmsterdamBuilder.KALVERSTRAAT), "Ga verder naar Kalverstraat"));
            kaarten.Add(new OntvangGeld(100, "U hebt een kruiswoordpuzzel gewonnen en ontvangt ƒ 100"));
            return kaarten;
        }
    }
}
