using CRMonopoly.domein;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CRMonopoly.domein.gebeurtenis;

namespace CRMonopolyTest
{
    
    /// <summary>
    ///This is a test class for GebeurtenissenTest and is intended
    ///to contain all GebeurtenissenTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GebeurtenissenTest
    {

        private Gebeurtenissen GebeurtenissenLijst { get; set; }

        [TestInitialize]
        public void setup()
        {
            GebeurtenissenLijst = new Gebeurtenissen();
            GebeurtenissenLijst.Add(new BetaalHuur(new Straat("",0,new Huur(0,0,0,0,0,0))));
        }

        // TODO: GebeurtenissenTest verder implementeren.
    }
}
