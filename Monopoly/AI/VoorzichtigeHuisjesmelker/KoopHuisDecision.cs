using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoly.domein;
using Monopoly.domein.gebeurtenissen;

namespace Monopoly.AI.VoorzichtigeHuisjesmelker
{
    public class KoopHuisDecision : IDecision
    {
        public bool decide(Speler speler, IGebeurtenis gebeurtenis)
        {
            bool decision = speler.Bezittingen.Kasgeld > (speler.Spel.Bord.geefMaximumHuur() + ((KoopHuis)gebeurtenis).GeefKandidaatstraat(speler).PrijsVoorEenHuis);
            return decision;
        }
    }
}
