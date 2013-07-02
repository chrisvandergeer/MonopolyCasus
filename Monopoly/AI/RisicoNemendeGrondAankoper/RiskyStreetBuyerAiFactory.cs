using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoly.domein.gebeurtenissen;

namespace Monopoly.AI.RisicoNemendeGrondAankoper
{
    class RiskyStreetBuyerAiFactory
    {
        public static IAIDecider geefRiskyStreetBuyerAI()
        {
            IAIDecider decider = new AIDecider();
            AddDecisions(decider);
            return decider;
        }

        private static void AddDecisions(IAIDecider aiDecider)
        {
            aiDecider.AddDecision(Gebeurtenisnamen.KOOP_HUIS, new KoopHuisDecision());
            aiDecider.AddDecision(Gebeurtenisnamen.DOE_BOD_OPANDERMANSTRAAT, new DoeBodOpAndermansStraatDecision());
        }

    }
}
