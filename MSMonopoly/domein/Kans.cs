using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MSMonopoly.domein.acties;

namespace MSMonopoly.domein
{
    class Kans : Veld
    {
        public bool IsTekoop()
        {
            return false;
        }

        public string Naam()
        {
            return "Kans";
        }

        public Actie BepaalActie(Beurt huidigeBeurt)
        {
            return new GaDoorNaarStart(huidigeBeurt.HuidigeSpeler, huidigeBeurt);
        }
    }
}
