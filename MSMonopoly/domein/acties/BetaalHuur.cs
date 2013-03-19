using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSMonopoly.domein.acties
{
    class BetaalHuur : Actie
    {
        private Speler HuurBetaler    { get; set; }
        private Straat Straat { get; set; }

        public BetaalHuur(Speler huurBetaler, Straat huurVoorStraat)
        {
            HuurBetaler = huurBetaler;
            Straat = huurVoorStraat;
        }

        public bool IsVerplicht()
        {
            return true;
        }

        public bool IsBevestigd()
        {
            return true;
        }

        public void VoerUit()
        {
            int huurbedrag = Straat.BepaalHuur();
            HuurBetaler.Betaal(huurbedrag);
            Straat.Eigenaar.Ontvang(huurbedrag);
        }
    }
}
