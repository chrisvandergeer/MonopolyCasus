using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein;
using CRMonopoly.domein.gebeurtenis;

namespace CRMonopoly.AI
{
    class ArtificialPlayerIntelligence
    {
        private static ArtificialPlayerIntelligence _instance;

        private List<IDecision> Decisions2Make;

        public ArtificialPlayerIntelligence()
        {
            Decisions2Make = new List<IDecision>();
            Decisions2Make.Add(new KoopStraatDecision());
        }

        public static ArtificialPlayerIntelligence Instance()
        {
            if (_instance == null)
            {
                ArtificialPlayerIntelligence instance = new ArtificialPlayerIntelligence();
                _instance = instance;
                return instance;
            }
            return _instance;
        }

        public void HandelWorpAf(Gebeurtenissen gebeurtenissen, Speler speler)
        {
            foreach (IDecision decision in Decisions2Make)
            {
                Gebeurtenis gebeurtenis = decision.GeefUitTeVoerenGebeurtenis(gebeurtenissen, speler);
                if (gebeurtenis != null)
                {
                    GebeurtenisResult result = gebeurtenis.VoerUit(speler);
                    gebeurtenissen.Add(result);
                    if (result.IsUitgevoerd)
                        gebeurtenissen.Remove(gebeurtenis);
                }
            }
        }
    }
}
