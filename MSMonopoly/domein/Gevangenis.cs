using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MSMonopoly.domein.acties;

namespace MSMonopoly.domein
{
    class Gevangenis : Veld
    {
        public bool IsTekoop()
        {
            return false;
        }

        public string Naam()
        {
            return "Gevangenis";
        }

        public Actie BepaalActie(Beurt huidigeBeurt)
        {
            return new GeenActie();
        }
    }
}
