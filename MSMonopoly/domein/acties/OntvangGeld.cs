using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSMonopoly.domein.acties
{
    class OntvangGeld : Actie
    {
        private Speler Ontvanger { get; set; }
        private int Geldeenheden { get; set; }

        public OntvangGeld(Speler ontvanger, int geldeenheden)
        {
            Ontvanger = ontvanger;
            Geldeenheden = geldeenheden;
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
            Ontvanger.Betaal(Geldeenheden);
        }
    }
}
