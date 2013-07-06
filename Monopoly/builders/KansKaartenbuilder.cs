using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoly.domein;
using Monopoly.domein.gebeurtenissen;
using Monopoly.domein.labels;

namespace Monopoly.builders
{
    public class KansKaartenbuilder
    {
        private Spelbord Bord { get; set; }

        public KansKaartenbuilder(Spelbord bord)
        {
            Bord = bord;
        }

        public GebeurtenisStapel build()
        {
            List<IGebeurtenis> _kaarten = new List<IGebeurtenis>();
            _kaarten.Add(new BetaalGeld(150).SetTekst("Betaal schoolgeld euro 150"));
            _kaarten.Add(new BetaalGeld(15).SetTekst("Boete voor te snel rijden euro 15"));
            _kaarten.Add(VerplaatsSpeler.CreateVerplaatsVooruit("Ga naar Bartiljorisstraat", Bord.GeefVeld(Veldnamen.BARTELJORISSTRAAT)));      // new GaNaarGebeurtenis(HaarlemBuilder.BARTELJORISSTRAAT, gaNaarBartiljorisstraat));
            _kaarten.Add(VerplaatsSpeler.CreateVerplaatsVooruit("Ga naar Station-West", Bord.GeefVeld(Veldnamen.STATION_WEST)));                // new GaNaarGebeurtenis(Stationbuilder.WEST, gaNaarStationWest));
            _kaarten.Add(VerplaatsSpeler.CreateVerplaatsVooruit("Ga naar Start", Bord.GeefVeld(Veldnamen.START)));                              // new GaNaarGebeurtenis(Start.VELD_NAAM, gaNaarStart));
            _kaarten.Add(VerplaatsSpeler.CreateVerplaatsAchteruit("Ga 3 plaatsen terug", 3));       // new Ga3PlaatsenTerug());
            //_kaarten.Add(new GaDirectNaarDeGevangenis());
            _kaarten.Add(VerplaatsSpeler.CreateVerplaatsVooruit("Ga verder naar de Heerestraat.", Bord.GeefVeld(Veldnamen.HEERESTRAAT)));       // new GaNaarGebeurtenis(GroningenBuilder.HEERESTRAAT, "Ga verder naar de Heerestraat. Indien u langs 'Start' komt ontvangt u euro 200"));
            _kaarten.Add(new OntvangGeld(50).SetTekst("De bank betaalt u euro 50 dividend"));
            //_kaarten.Add(new VerlaatDeGevangenis(_kaarten));
            // Repareer uw huizen. Betaal voor elk huis euro 25, betaal voor elk hotel euro 100
            // U wordt aangeslagen voor straatgeld. euro 40 per huis, euro 115 per hotel
            _kaarten.Add(new OntvangGeld(150).SetTekst("Uw bouwverzekering vervalt, u ontvangt euro 150"));
            _kaarten.Add(new BetaalGeld(20).SetTekst("Aangehouden wegens dronkenschap euro 20 boete"));
            _kaarten.Add(VerplaatsSpeler.CreateVerplaatsVooruit("Ga verder naar de Kalverstraat.", Bord.GeefVeld(Veldnamen.KALVERSTRAAT)));       // new GaNaarGebeurtenis(AmsterdamBuilder.KALVERSTRAAT, "Ga verder naar Kalverstraat"));
            _kaarten.Add(new OntvangGeld(100).SetTekst("U hebt een kruiswoordpuzzel gewonnen en ontvangt euro 100"));

            return new GebeurtenisStapel(_kaarten, "Kans");
        }
    }
}
