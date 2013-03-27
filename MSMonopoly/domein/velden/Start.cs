using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MSMonopoly.domein.gebeurtenis;

namespace MSMonopoly.domein.velden
{
    class Start : Veld
    {

        public Start() : base("Start") { }

        public override Gebeurtenis bepaalGebeurtenis(Speler speler)
        {
            return new OntvangGeld(speler, 400);
        }
    }
}
