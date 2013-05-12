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

        [TestInitialize]
        public void setup()
        {
        }

        /// <summary>
        ///A test for Gebeurtenissen Constructor
        ///</summary>
        [TestMethod()]
        public void GebeurtenissenConstructorTest()
        {
            Gebeurtenissen gebeurtenissen = new Gebeurtenissen();
            Assert.IsNotNull(gebeurtenissen, "De gebeurtenissen instance mag niet null zijn.");
        }

        // Methods Add (3*), bevatGebeurtenis, BevatGooiDobbelStenen, bevatVerplichte, GeefGooiDobbelStenen, GeefGebeurtenis, GeefOptionele, GeefVerplichte, GetEmunerator, log
        // ??VoerUit

        /// <summary>
        ///A test for Gebeurtenissen Constructor
        ///</summary>
        [TestMethod()]
        public void GebeurtenissenAddGebeurtenisTest()
        {
            Gebeurtenissen gebeurtenissen = new Gebeurtenissen();
            gebeurtenissen.Add(new BetaalHuur(new Straat("", 0, new Huur(0, 0, 0, 0, 0, 0))));
            int expected = 1;
            Assert.IsTrue(expected == gebeurtenissen.Count(), "Er zou op dit moment maar 1 element in de gebeurtenissen mogen zitten.");

        }


    }
}
