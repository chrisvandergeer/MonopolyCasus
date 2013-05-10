using CRMonopoly.domein.gebeurtenis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CRMonopoly.domein;

namespace CRMonopolyTest
{
    
    
    /// <summary>
    ///This is a test class for GaNaarGevangenisTest and is intended
    ///to contain all GaNaarGevangenisTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GaNaarGevangenisTest
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
        ///A test for GaNaarGevangenis Constructor
        ///</summary>
        [TestMethod()]
        public void GaNaarGevangenisConstructorTest()
        {
            GaNaarGevangenis target = new GaNaarGevangenis();
            Assert.IsNotNull(target, "GaNaarGevangenis instance mag niet null zijn.");
        }

        // TODO: GaNaarGevangenisTest verder implementeren.

        ///// <summary>
        /////A test for IsVerplicht
        /////</summary>
        //[TestMethod()]
        //public void IsVerplichtTest()
        //{
        //    GaNaarGevangenis target = new GaNaarGevangenis(); // TODO: Initialize to an appropriate value
        //    bool expected = false; // TODO: Initialize to an appropriate value
        //    bool actual;
        //    actual = target.IsVerplicht();
        //    Assert.AreEqual(expected, actual);
        //    Assert.Inconclusive("Verify the correctness of this test method.");
        //}

        ///// <summary>
        /////A test for ToString
        /////</summary>
        //[TestMethod()]
        //public void ToStringTest()
        //{
        //    GaNaarGevangenis target = new GaNaarGevangenis(); // TODO: Initialize to an appropriate value
        //    string expected = string.Empty; // TODO: Initialize to an appropriate value
        //    string actual;
        //    actual = target.ToString();
        //    Assert.AreEqual(expected, actual);
        //    Assert.Inconclusive("Verify the correctness of this test method.");
        //}

        ///// <summary>
        /////A test for VoerUit
        /////</summary>
        //[TestMethod()]
        //public void VoerUitTest()
        //{
        //    GaNaarGevangenis target = new GaNaarGevangenis(); // TODO: Initialize to an appropriate value
        //    Speler speler = null; // TODO: Initialize to an appropriate value
        //    GebeurtenisResult expected = null; // TODO: Initialize to an appropriate value
        //    GebeurtenisResult actual;
        //    actual = target.VoerUit(speler);
        //    Assert.AreEqual(expected, actual);
        //    Assert.Inconclusive("Verify the correctness of this test method.");
        //}

        ///// <summary>
        /////A test for Speler
        /////</summary>
        //[TestMethod()]
        //public void SpelerTest()
        //{
        //    GaNaarGevangenis target = new GaNaarGevangenis(); // TODO: Initialize to an appropriate value
        //    Speler expected = null; // TODO: Initialize to an appropriate value
        //    Speler actual;
        //    target.Speler = expected;
        //    actual = target.Speler;
        //    Assert.AreEqual(expected, actual);
        //    Assert.Inconclusive("Verify the correctness of this test method.");
        //}
    }
}
