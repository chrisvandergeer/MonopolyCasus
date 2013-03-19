using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSMonopoly.domein.acties
{
    class GaDoorNaarStart : Actie
    {
        private Speler Speler { get; set; }
        private Beurt HuidigeBeurt { get; set; }

        public GaDoorNaarStart(Speler speler, Beurt huidigeBeurt)
        {
            Speler = speler;
            HuidigeBeurt = huidigeBeurt;
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
            Speler.VerplaatsNaarStart();
            Actie ontvangGeld = Speler.HuidigePositie.BepaalActie(HuidigeBeurt);
            ontvangGeld.VoerUit();
        }
    }
}
