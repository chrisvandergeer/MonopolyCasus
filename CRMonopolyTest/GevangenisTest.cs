using CRMonopoly.domein.velden;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CRMonopoly.domein;
using CRMonopoly.domein.gebeurtenis;
using System.Collections.Generic;

namespace CRMonopolyTest
{   
    
    /// <summary>
    ///This is a test class for GevangenisTest and is intended
    ///to contain all GevangenisTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GevangenisTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        /// <summary>
        ///A test for IsGevangene
        ///</summary>
        [TestMethod()]
        public void IsGevangeneTest()
        {
            Speler speler1 = new Speler("Speler 1");
            Speler speler2 = new Speler("Speler 2");
            Gevangenis gevangenis = new Gevangenis();
            gevangenis.NieuweGevangene(speler1);
            Assert.IsFalse(gevangenis.IsGevangene(speler2));
            Assert.IsTrue(gevangenis.IsGevangene(speler1));
        }

        /// <summary>
        ///A test for LaatVrij
        ///</summary>
        [TestMethod()]
        public void LaatVrijTest()
        {
            Speler speler = new Speler("Speler");
            Gevangenis gevangenis = new Gevangenis();
            gevangenis.NieuweGevangene(speler);
            Assert.IsTrue(gevangenis.IsGevangene(speler));
            gevangenis.LaatVrij(speler);
            Assert.IsFalse(gevangenis.IsGevangene(speler));
        }

        /// <summary>
        ///A test for NieuweGevangene
        ///</summary>
        [TestMethod()]
        public void NieuweGevangeneTest()
        {
            Speler speler = new Speler("Speler");
            Gevangenis gevangenis = new Gevangenis();
            Assert.IsFalse(gevangenis.IsGevangene(speler));
            gevangenis.NieuweGevangene(speler);
            Assert.IsTrue(gevangenis.IsGevangene(speler));
        }

        /// <summary>
        ///A test for WachtBeurt
        ///</summary>
        [TestMethod()]
        public void WachtBeurtTest()
        {
            Speler speler = new Speler("speler");
            Gevangenis gevangenis = new Gevangenis();
            gevangenis.NieuweGevangene(speler);
            Assert.AreEqual(1, gevangenis.WachtBeurt(speler));
            Assert.AreEqual(2, gevangenis.WachtBeurt(speler));
        }

    }
}
