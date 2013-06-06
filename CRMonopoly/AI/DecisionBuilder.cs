using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein.gebeurtenis;
using CRMonopoly.domein;
using CRMonopoly.domein.gebeurtenis.kans;

namespace CRMonopoly.AI
{
    public class DecisionBuilder
    {
        private Dictionary<Type, IDecision> Decisions2Make;

        public DecisionBuilder()
        {
            Decisions2Make = new Dictionary<Type, IDecision>();
            Decisions2Make.Add(typeof(OntvangGeld), new AltijdDoen());
            Decisions2Make.Add(typeof(BetaalBelasting), new NietDoen());
            Decisions2Make.Add(typeof(BetaalHuur), new NietDoen());
            Decisions2Make.Add(typeof(BetaalGeld), new NietDoen());
            Decisions2Make.Add(typeof(KoopStraat), new KoopStraatDecision());
            //Decisions2Make.Add(typeof(GaNaarGebeurtenis), null);
            Decisions2Make.Add(typeof(DoeBodOpAndermansStraat), new DoeBodOpAndermansStraatDecision());
        }

        internal IDecision geefDecisionVoorType(Type gebeurtenisType)
        {
            IDecision decision = null;
            try
            {
                decision = Decisions2Make[gebeurtenisType];
            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine("================================================================");
                Console.WriteLine(ex.Message);
                Console.WriteLine(gebeurtenisType.ToString());
                Console.WriteLine("================================================================");
            }
            return decision;
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
