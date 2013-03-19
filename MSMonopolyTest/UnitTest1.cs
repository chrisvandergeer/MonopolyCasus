using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSMonopoly.builders;
using MSMonopoly.domein;

namespace MSMonopolyTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestBuild()
        {
            MonopolySpelBuilder builder = new MonopolySpelBuilder();
            Monopoly monopoly = builder.Build();
            monopoly.Add(new Speler() { Naam = "Mees"  });
            monopoly.Add(new Speler() { Naam = "Floor" });
            monopoly.Add(new Speler() { Naam = "Hanna" });
            monopoly.Add(new Speler() { Naam = "Chris" });
            monopoly.Start();
        }
    }
}
