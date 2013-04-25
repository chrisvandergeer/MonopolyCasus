using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein.gebeurtenis;

namespace CRMonopoly.domein.velden
{
    class GevangenisOpBezoek : Veld
    {
        public static string VELD_NAAM = "Op bezoek in de gevangenis";
        public GevangenisOpBezoek() : base(VELD_NAAM) { }

        public override Gebeurtenis bepaalGebeurtenis(Speler speler)
        {
            return new Vrij();
        }
    }
}
