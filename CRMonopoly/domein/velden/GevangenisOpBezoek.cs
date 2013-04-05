using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein.gebeurtenis;

namespace CRMonopoly.domein.velden
{
    class GevangenisOpBezoek : Veld
    {
        public GevangenisOpBezoek() : base("Gevangenis (op bezoek)") { }

        public override Gebeurtenis bepaalGebeurtenis(Speler speler)
        {
            return new Vrij();
        }
    }
}
