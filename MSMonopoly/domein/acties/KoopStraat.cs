using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSMonopoly.domein.acties
{
    class KoopStraat : Actie
    {
        private bool _bevestigd = false;
        private Speler PotentieleKoper { get; set; }
        private Straat StraatInVerkoop { get; set; }

        public KoopStraat(Speler speler, Straat straat)
        {
            PotentieleKoper = speler;
            StraatInVerkoop = straat;
        }

        public bool IsVerplicht()
        {
            return false;
        }

        public bool IsBevestigd()
        {
            return _bevestigd;
        }

        public void VoerUit()
        {
            StraatInVerkoop.Verkoop(PotentieleKoper);
        }
    }
}
