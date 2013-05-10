using CRMonopoly.domein.gebeurtenis.kans;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CRMonopoly.domein;
using CRMonopoly.domein.gebeurtenis;

namespace CRMonopolyTest
{
    
    
    /// <summary>
    ///This is a test class for GaNaarGebeurtenisTest and is intended
    ///to contain all GaNaarGebeurtenisTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GaNaarGebeurtenisTest
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
        ///A test for GaNaarGebeurtenis Constructor
        ///</summary>
        [TestMethod()]
        public void GaNaarGebeurtenisConstructorTest()
        {
            string bestemmingVeldnaam = "GaNaarGebeurtenis Bestemming";
            string gebeurtenisnaam = "GaNaarGebeurtenisConstructorTest";
            GaNaarGebeurtenis target = new GaNaarGebeurtenis(bestemmingVeldnaam, gebeurtenisnaam);
            Assert.IsNotNull(target, "De GaNaarGebeurtenis instance mag niet null zijn.");
        }

        // TODO: GaNaarGebeurtenisTest verder implementeren.

        ///// <summary>
        /////A test for IsVerplicht
        /////</summary>
        //[TestMethod()]
        //public void IsVerplichtTest()
        //{
        //    string bestemmingVeldnaam = string.Empty; // TODO: Initialize to an appropriate value
        //    string gebeurtenisnaam = string.Empty; // TODO: Initialize to an appropriate value
        //    GaNaarGebeurtenis target = new GaNaarGebeurtenis(bestemmingVeldnaam, gebeurtenisnaam); // TODO: Initialize to an appropriate value
        //    bool expected = false; // TODO: Initialize to an appropriate value
        //    bool actual;
        //    actual = target.IsVerplicht();
        //    Assert.AreEqual(expected, actual);
        //    Assert.Inconclusive("Verify the correctness of this test method.");
        //}

        ///// <summary>
        /////A test for KomtLangsStart
        /////</summary>
        //[TestMethod()]
        //[DeploymentItem("CRMonopoly.exe")]
        //public void KomtLangsStartTest()
        //{
        //    PrivateObject param0 = null; // TODO: Initialize to an appropriate value
        //    GaNaarGebeurtenis_Accessor target = new GaNaarGebeurtenis_Accessor(param0); // TODO: Initialize to an appropriate value
        //    Speler speler = null; // TODO: Initialize to an appropriate value
        //    bool expected = false; // TODO: Initialize to an appropriate value
        //    bool actual;
        //    actual = target.KomtLangsStart(speler);
        //    Assert.AreEqual(expected, actual);
        //    Assert.Inconclusive("Verify the correctness of this test method.");
        //}

        ///// <summary>
        /////A test for VoerUit
        /////</summary>
        //[TestMethod()]
        //public void VoerUitTest()
        //{
        //    string bestemmingVeldnaam = string.Empty; // TODO: Initialize to an appropriate value
        //    string gebeurtenisnaam = string.Empty; // TODO: Initialize to an appropriate value
        //    GaNaarGebeurtenis target = new GaNaarGebeurtenis(bestemmingVeldnaam, gebeurtenisnaam); // TODO: Initialize to an appropriate value
        //    Speler speler = null; // TODO: Initialize to an appropriate value
        //    GebeurtenisResult expected = null; // TODO: Initialize to an appropriate value
        //    GebeurtenisResult actual;
        //    actual = target.VoerUit(speler);
        //    Assert.AreEqual(expected, actual);
        //    Assert.Inconclusive("Verify the correctness of this test method.");
        //}

        ///// <summary>
        /////A test for Bestemming
        /////</summary>
        //[TestMethod()]
        //[DeploymentItem("CRMonopoly.exe")]
        //public void BestemmingTest()
        //{
        //    PrivateObject param0 = null; // TODO: Initialize to an appropriate value
        //    GaNaarGebeurtenis_Accessor target = new GaNaarGebeurtenis_Accessor(param0); // TODO: Initialize to an appropriate value
        //    string expected = string.Empty; // TODO: Initialize to an appropriate value
        //    string actual;
        //    target.Bestemming = expected;
        //    actual = target.Bestemming;
        //    Assert.AreEqual(expected, actual);
        //    Assert.Inconclusive("Verify the correctness of this test method.");
        //}
    }
}
