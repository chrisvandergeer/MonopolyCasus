using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein.gebeurtenis;
using CRMonopoly.domein;

namespace CRMonopoly.AI
{
    public class DecisionBuilder
    {
        private Dictionary<GebeurtenisType, IDecision> Decisions2Make;

        public DecisionBuilder()
        {
            Decisions2Make = new Dictionary<GebeurtenisType, IDecision>();
            Decisions2Make.Add(GebeurtenisType.OntvangGeld, new AltijdDoen());
            Decisions2Make.Add(GebeurtenisType.BetaalGeld, new NietDoen());
            Decisions2Make.Add(GebeurtenisType.Aankopen, new KoopStraatDecision());
        }

        internal IDecision geefDecisionVoorType(GebeurtenisType gebeurtenisType)
        {
            return Decisions2Make[gebeurtenisType];
        }
    }
    public class AltijdDoen : IDecision
    {
        public Gebeurtenis GeefUitTeVoerenGebeurtenis(Gebeurtenissen gebeurtenissen, Speler speler)
        {
            return null;
        }
        public bool doenJN(Gebeurtenis g, Speler speler)
        {
            return true;
        }
    }
    public class NietDoen : IDecision
    {
        public Gebeurtenis GeefUitTeVoerenGebeurtenis(Gebeurtenissen gebeurtenissen, Speler speler)
        {
            return null;
        }
        public bool doenJN(Gebeurtenis g, Speler speler)
        {
            return false;
        }
    }
}
