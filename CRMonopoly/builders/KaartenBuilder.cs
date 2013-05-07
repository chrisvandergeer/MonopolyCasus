using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein;
using CRMonopoly.domein.gebeurtenis;

namespace CRMonopoly.builders
{
    public interface KaartenBuilder
    {
        List<Gebeurtenis> getStapelKaarten();
    }
}
