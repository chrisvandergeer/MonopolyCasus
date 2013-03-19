using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MSMonopoly.domein;

namespace MSMonopoly.builders
{
    public class MonopolySpelBuilder
    {
        public Monopoly Build()
        {
            StadBuilder stadBuilder = new StadBuilder();
            Monopoly spel = new Monopoly();
            spel.Add(new Start());
            spel.Add(stadBuilder.BuildAmsterdam());
            spel.Add(new Kans());
            spel.Add(stadBuilder.BuildArnhem());
            spel.Add(new Gevangenis());
            spel.Add(stadBuilder.BuildDenHaag());
            return spel;
        }
    }
}
