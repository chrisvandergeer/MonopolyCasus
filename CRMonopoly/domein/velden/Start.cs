using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein.gebeurtenis;

namespace CRMonopoly.domein.velden
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
