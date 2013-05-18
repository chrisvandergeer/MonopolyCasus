using CRMonopoly.domein;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CRMonopolyTest
{
    
    
    /// <summary>
    ///This is a test class for StadTest and is intended
    ///to contain all StadTest Unit Tests
    ///</summary>
    [TestClass()]
    public class StadTest
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
        ///A test for Stad Constructor is not needed.
        ///</summary>
        [TestMethod()]
        public void StadConstructorTest()
        {
            string naam = "NowhereCity";
            int huisprijs = 150;
            Stad target = new Stad(naam, huisprijs);
            Assert.IsNotNull(target, "De stad zou nu geinstantieerd moet zijn.");
        }

        /// <summary>
        ///A test for Add
        ///</summary>
        [TestMethod()]
        public void AddTest()
        {
            string naam = "NowhereCity";
            int huisprijs = 150;
            Stad target = new Stad(naam, huisprijs);
            int straatAankoopprijs1 = 350;
            Huur huur1 = new Huur(1, 2, 3, 4, 5, 6);
            string straatNaam1 = "NoStreet";
            Straat straat1 = new Straat(straatNaam1, straatAankoopprijs1, huur1);
            target.Add(straat1);
            Assert.IsTrue(target.Straten.Count == 1, "Een straat zou nu aan de stad toegevoegd moeten zijn.");

            int straatAankoopprijs2 = 450;
            Huur huur2 = new Huur(10, 20, 30, 40, 50, 60);
            string straatNaam2 = "NoWay";
            Straat straat2 = new Straat(straatNaam2, straatAankoopprijs2, huur2);
            target.Add(straat2);
            Assert.IsTrue(target.Straten.Count == 2, "Twee straten zou nu aan de stad toegevoegd moeten worden.");

            Assert.AreEqual(straat1, target.getStraatByIndex(0), "De eerste straat in de stad is niet de juiste.");
            Assert.AreEqual(straat2, target.getStraatByIndex(1), "De tweede straat in de stad is niet de juiste.");
        }
    }
}
