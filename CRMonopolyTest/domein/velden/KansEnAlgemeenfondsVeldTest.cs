using CRMonopoly.domein.velden;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CRMonopoly.domein;
using CRMonopoly.domein.gebeurtenis;
using CRMonopoly.builders;
using System.Collections.Generic;

namespace CRMonopolyTest
{
    
    
    /// <summary>
    ///This is a test class for KansEnAlgemeenfondsVeldTest and is intended
    ///to contain all KansEnAlgemeenfondsVeldTest Unit Tests
    ///</summary>
    [TestClass()]
    public class KansEnAlgemeenfondsVeldTest
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
        ///A test for KansEnAlgemeenfondsVeld Constructor
        ///</summary>
        [TestMethod()]
        public void KansEnAlgemeenfondsVeldConstructorTest()
        {
            string naam = "KansOfFonds";
            KansEnAlgemeenfondsVeld target = new KansEnAlgemeenfondsVeld(naam);
            Assert.IsNotNull(target, "De instance van KansEnAlgemeenfondsVeld mag niet null zijn.");
        }

        // TODO: KansEnAlgemeenfondsVeldTest verder implementeren.

        ///// <summary>
        /////A test for bepaalGebeurtenis
        /////</summary>
        //[TestMethod()]
        //public void bepaalGebeurtenisTest()
        //{
        //    string naam = string.Empty; // TODO: Initialize to an appropriate value
        //    KansEnAlgemeenfondsVeld target = new KansEnAlgemeenfondsVeld(naam); // TODO: Initialize to an appropriate value
        //    Speler speler = null; // TODO: Initialize to an appropriate value
        //    Gebeurtenis expected = null; // TODO: Initialize to an appropriate value
        //    Gebeurtenis actual;
        //    actual = target.bepaalGebeurtenis(speler);
        //    Assert.AreEqual(expected, actual);
        //    Assert.Inconclusive("Verify the correctness of this test method.");
        //}

        ///// <summary>
        /////A test for Builder
        /////</summary>
        //[TestMethod()]
        //public void BuilderTest()
        //{
        //    string naam = string.Empty; // TODO: Initialize to an appropriate value
        //    KansEnAlgemeenfondsVeld target = new KansEnAlgemeenfondsVeld(naam); // TODO: Initialize to an appropriate value
        //    KaartenBuilder expected = null; // TODO: Initialize to an appropriate value
        //    KaartenBuilder actual;
        //    target.Builder = expected;
        //    actual = target.Builder;
        //    Assert.AreEqual(expected, actual);
        //    Assert.Inconclusive("Verify the correctness of this test method.");
        //}

        ///// <summary>
        /////A test for Kaarten
        /////</summary>
        //[TestMethod()]
        //public void KaartenTest()
        //{
        //    string naam = string.Empty; // TODO: Initialize to an appropriate value
        //    KansEnAlgemeenfondsVeld target = new KansEnAlgemeenfondsVeld(naam); // TODO: Initialize to an appropriate value
        //    List<Gebeurtenis> expected = null; // TODO: Initialize to an appropriate value
        //    List<Gebeurtenis> actual;
        //    target.Kaarten = expected;
        //    actual = target.Kaarten;
        //    Assert.AreEqual(expected, actual);
        //    Assert.Inconclusive("Verify the correctness of this test method.");
        //}
    }
}
