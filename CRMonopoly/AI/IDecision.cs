using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein.gebeurtenis;
using CRMonopoly.domein;

namespace CRMonopoly.AI
{
    interface IDecision
    {
        Gebeurtenis GeefUitTeVoerenGebeurtenis(Gebeurtenissen gebeurtenissen, Speler speler);
    }
}
