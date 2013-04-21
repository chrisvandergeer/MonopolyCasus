using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein.gebeurtenis;

namespace CRMonopoly.domein.velden
{
    class GaNaarGevangenisVeld : Veld
    {
        public GaNaarGevangenisVeld() : base("Naar de Gevangenis") { }

        public override Gebeurtenis bepaalGebeurtenis(Speler speler)
        {
            return new GaNaarGevangenis();
        }
    }
}
