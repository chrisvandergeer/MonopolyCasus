using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein.gebeurtenis;

namespace CRMonopoly.domein.velden
{
    class VrijParkeren : Veld
    {
        public static string VELD_NAAM = "Vrij parkeren";
        public VrijParkeren() : base(VELD_NAAM) { } 

        public override Gebeurtenis bepaalGebeurtenis(Speler speler)
        {
            return new Vrij();
        }
    }
}
