using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MSMonopoly.domein.acties;

namespace MSMonopoly.domein
{
    class Start : Veld
    {
        public bool IsTekoop()
        {
            return false;
        }

        public string Naam()
        {
            return "Start";
        }

        public Actie BepaalActie(Beurt huidigeBeurt)
        {
            Speler ontvanger = huidigeBeurt.HuidigeSpeler;
            int geldeenheden = 400;
            string melding = "Speler is op start geland en ontvangt daarom " + geldeenheden + " geldeenheden";
            huidigeBeurt.WriteLog(melding);
            return new OntvangGeld(ontvanger, 400);
        }
    }
}
