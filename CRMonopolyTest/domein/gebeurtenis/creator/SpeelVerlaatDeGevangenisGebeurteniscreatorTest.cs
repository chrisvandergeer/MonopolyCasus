using CRMonopoly.domein.gebeurtenis.creator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CRMonopoly.domein;
using CRMonopoly.domein.gebeurtenis;

namespace CRMonopolyTest
{
    
    
    /// <summary>
    ///This is a test class for SpeelVerlaatDeGevangenisGebeurteniscreatorTest and is intended
    ///to contain all SpeelVerlaatDeGevangenisGebeurteniscreatorTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SpeelVerlaatDeGevangenisGebeurteniscreatorTest
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
        ///A test for SpeelVerlaatDeGevangenisGebeurteniscreator Constructor
        ///</summary>
        [TestMethod()]
        public void SpeelVerlaatDeGevangenisGebeurteniscreatorConstructorTest()
        {
            SpeelVerlaatDeGevangenisGebeurteniscreator target = new SpeelVerlaatDeGevangenisGebeurteniscreator();
            Assert.IsNotNull(target, "De SpeelVerlaatDeGevangenisGebeurteniscreator instance mag niet null zijn.");
        }

        // TODO: SpeelVerlaatDeGevangenisGebeurteniscreatorTest verder implementeren.

        ///// <summary>
        /////A test for IsGebeurtenisVoorSpeler
        /////</summary>
        //[TestMethod()]
        //public void IsGebeurtenisVoorSpelerTest()
        //{
        //    SpeelVerlaatDeGevangenisGebeurteniscreator target = new SpeelVerlaatDeGevangenisGebeurteniscreator(); // TODO: Initialize to an appropriate value
        //    Speler speler = null; // TODO: Initialize to an appropriate value
        //    bool expected = false; // TODO: Initialize to an appropriate value
        //    bool actual;
        //    actual = target.IsGebeurtenisVoorSpeler(speler);
        //    Assert.AreEqual(expected, actual);
        //    Assert.Inconclusive("Verify the correctness of this test method.");
        //}

        ///// <summary>
        /////A test for MaakGebeurtenis
        /////</summary>
        //[TestMethod()]
        //public void MaakGebeurtenisTest()
        //{
        //    SpeelVerlaatDeGevangenisGebeurteniscreator target = new SpeelVerlaatDeGevangenisGebeurteniscreator(); // TODO: Initialize to an appropriate value
        //    Speler speler = null; // TODO: Initialize to an appropriate value
        //    Gebeurtenis expected = null; // TODO: Initialize to an appropriate value
        //    Gebeurtenis actual;
        //    actual = target.MaakGebeurtenis(speler);
        //    Assert.AreEqual(expected, actual);
        //    Assert.Inconclusive("Verify the correctness of this test method.");
        //}
    }
}
