using CRMonopoly.domein;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CRMonopoly.domein.velden;
using System.Collections.Generic;

namespace CRMonopolyTest
{
    
    
    /// <summary>
    ///This is a test class for NutsbedrijvenTest and is intended
    ///to contain all NutsbedrijvenTest Unit Tests
    ///</summary>
    [TestClass()]
    public class NutsbedrijvenTest
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
        ///A test for Nutsbedrijven Constructor
        ///</summary>
        [TestMethod()]
        public void NutsbedrijvenConstructorTest()
        {
            Nutsbedrijven target = new Nutsbedrijven();
            Assert.IsNotNull(target, "De instantie van Nutsbedrijven mag niet null zijn.");
        }

        /// <summary>
        ///A test for Add
        ///</summary>
        [TestMethod()]
        public void AddTest()
        {
            Nutsbedrijven target = new Nutsbedrijven();
            addNutsbedrijfVeldToNutsbedrijven(target, "Mars");
            Assert.IsTrue(target.AlleNutsBedrijven.Count == 1,
                String.Format("Nutsbedrijf(Veld) had aan de lijst toegevoegd moeten zijn, maar de lijst bevat nu {0} elementen.", target.AlleNutsBedrijven.Count));
        }

        /// <summary>
        ///A test for AlleNutsBedrijven
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CRMonopoly.exe")]
        public void AlleNutsBedrijvenTest()
        {
            Nutsbedrijven target = new Nutsbedrijven();
            List<Nutsbedrijf> actual = target.AlleNutsBedrijven;
            Assert.IsNotNull(actual, "De lijst met nustbedrijven mag niet null zijn.");
            Nutsbedrijf nutsbedrijf = new Nutsbedrijf("Nutsbedrijf01");
            Assert.IsTrue(target.AlleNutsBedrijven.Count == 0,
                String.Format("De lijst met Nutsbedrijf(velden) moet leeg zijn, maar de lijst bevat nu {0} elementen.", target.AlleNutsBedrijven.Count));
            target.Add(nutsbedrijf);
            Assert.IsTrue(target.AlleNutsBedrijven.Count == 1,
                String.Format("Nutsbedrijf(Veld) had aan de lijst toegevoegd moeten zijn, maar de lijst bevat nu {0} elementen.", target.AlleNutsBedrijven.Count));

            addNutsbedrijfVeldToNutsbedrijven(target, "Nutsbedrijf02");
            Assert.IsTrue(target.AlleNutsBedrijven.Count == 2,
                String.Format("Twee Nutsbedrijf(Velden) hadden aan de lijst toegevoegd moeten zijn, maar de lijst bevat nu {0} elementen.", target.AlleNutsBedrijven.Count));
        }

        /// <summary>
        ///A test for getBedrijfByName
        ///</summary>
        [TestMethod()]
        public void getBedrijfByNameTest()
        {
            Nutsbedrijven target = new Nutsbedrijven();
            addNutsbedrijfVeldToNutsbedrijven(target, "Nutsbedrijf_A");
            addNutsbedrijfVeldToNutsbedrijven(target, "Nutsbedrijf_B");
            addNutsbedrijfVeldToNutsbedrijven(target, "Nutsbedrijf_C");

            Assert.IsTrue(target.AlleNutsBedrijven.Count == 3,
                String.Format("Drie nutsbedrijfVelden hadden aan de lijst toegevoegd moeten zijn, maar de lijst bevat nu {0} elementen.", target.AlleNutsBedrijven.Count));

            Nutsbedrijf nutsbedrijf = target.getBedrijfByName("VeldNietTeVinden");
            Assert.IsNull(nutsbedrijf, "getBedrijfByName() had geen resultaat mogen opleveren, maar er werd wel een Nutsbedrijf gevonden.");

            nutsbedrijf = target.getBedrijfByName("Nutsbedrijf_B");
            Assert.IsNotNull(nutsbedrijf,
                String.Format("getBedrijfByName() had een resultaat mogen opleveren, maar het Nutsbedrijf '{0}' werd niet gevonden.", "Nutsbedrijf_B"));
            Assert.AreEqual("Nutsbedrijf_B", nutsbedrijf.Naam,
                String.Format("getBedrijfByName() heeft niet het verwachte resultaat opgeleverd. (Exp: '{0}'; Act: {1}).", "Nutsbedrijf_B", nutsbedrijf.Naam));

        }

        private static void addNutsbedrijfVeldToNutsbedrijven(Nutsbedrijven target, String id)
        {
            Nutsbedrijf nutsbedrijfVeld = new Nutsbedrijf(id);
            target.Add(nutsbedrijfVeld);
        }
    }
}
