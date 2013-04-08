using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein.gebeurtenis;

namespace CRMonopoly.domein.gebeurtenis.kans
{
    interface Gebeurteniskaart
    {
        Gebeurtenis getInstance(Speler speler);
    }
}
