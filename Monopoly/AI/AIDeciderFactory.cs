using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoly.AI.RisicoNemendeGrondAankoper;
using Monopoly.AI.VoorzichtigeHuisjesmelker;

namespace Monopoly.AI
{
    class AIDeciderFactory
    {
        public static IAIDecider build(TypesAI aiType)
        {
            IAIDecider decider = null;
            switch (aiType)
            {
                case TypesAI.RiskyStreetBuyer:
                    decider = RiskyStreetBuyerAiFactory.geefRiskyStreetBuyerAI();
                    break;
                case TypesAI.CarefullHouseBuilder:
                    decider = CarefullHouseBuilderAiFactory.geefCarefullHouseBuilderAI();
                    break;
                case TypesAI.Default:
                    decider = new DefaultDecider();
                    break;
            }
            return decider;
        }
    }
}
