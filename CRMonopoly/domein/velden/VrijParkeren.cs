using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein.gebeurtenis;

namespace CRMonopoly.domein.velden
{
    class VrijParkeren : Veld
    {
        public VrijParkeren() : base("Vrij parkeren") { } 

        public override Gebeurtenis bepaalGebeurtenis(Speler speler)
        {
            return new Vrij();
        }
    }
}
