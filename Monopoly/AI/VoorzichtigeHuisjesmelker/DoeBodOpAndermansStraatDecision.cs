using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoly.domein;

namespace Monopoly.AI.VoorzichtigeHuisjesmelker
{
    public class DoeBodOpAndermansStraatDecision : IDecision
    {
        public bool decide(Speler speler, IGebeurtenis gebeurtenis)
        {
            return speler.Bezittingen.Kasgeld > speler.Spel.Bord.geefMaximumHuur();
        }
    }
}
