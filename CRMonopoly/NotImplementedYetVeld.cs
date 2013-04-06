using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein.gebeurtenis;

namespace CRMonopoly.domein.velden
{
    class NotImplementedYetVeld : Veld
    {
        public NotImplementedYetVeld(String name): base(name)
        {
        }

        public override Gebeurtenis bepaalGebeurtenis(Speler speler)
        {
            return null;
        }
    }
}
