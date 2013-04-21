using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein.gebeurtenis;

namespace CRMonopoly.domein.velden
{
    class GaNaarGevangenisVeld : Veld
    {
        public static string VELD_NAAM = "Naar de Gevangenis";
        public GaNaarGevangenisVeld() : base(VELD_NAAM) { }

        public override Gebeurtenis bepaalGebeurtenis(Speler speler)
        {
            return new GaNaarGevangenis();
        }
    }
}
