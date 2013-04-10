using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein;
using CRMonopoly.domein.gebeurtenis;
using CRMonopoly.domein.gebeurtenis.kans;

namespace MSMonopoly.builders
{
    class KanskaartBuilder
    {
        private static string gaNaarBartiljorisstraat = "Ga verder naar Barteljorisstraat. Indien u langs 'Start' komt, ontvangt u ƒ 200";
        private static string gaNaarStationWest = "Reis naar station 'West' en indien u langs 'Start' komt, ontvangt u ƒ 200";
        private static string gaNaarStart = "Ga verder naar 'Start'";

        private Monopolyspel Spel { get; set; }
        private Monopolybord Bord { get; set; }

        public KanskaartBuilder(Monopolyspel spel)
        {
            Spel = spel;
            Bord = spel.Bord;
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
            // Ga verder naar de Herestraat. Indien u langs "Start" komt ontvangt u ƒ 200
            // De bank betaalt u ƒ 50 dividend
            // Verlaat de gevangenis zonder te betalen
            // Repareer uw huizen. Betaal voor elk huis ƒ 25, betaal voor elk hotel ƒ 100
            // U wordt aangeslagen voor straatgeld. ƒ 40 per huis, ƒ 115 per hotel
            // Uw bouwverzekering vervalt, u ontvangt ƒ 150
            kaarten.Add(new BetaalGeld(20, "Aangehouden wegens dronkenschap ƒ 20 boete"));
            // Ga verder naar Kalverstraat
            // U hebt een kruiswoordpuzzel gewonnen en ontvangt ƒ 100
            return kaarten;
        }
    }
}
