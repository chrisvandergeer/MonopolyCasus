using CRMonopoly.domein;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CRMonopoly.domein.gebeurtenis;

namespace CRMonopolyTest
{
    
    
    /// <summary>
    ///This is a test class for KaartTest and is intended
    ///to contain all KaartTest Unit Tests
    ///</summary>
    [TestClass()]
    public class KaartTest
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
        ///A test for Kaart Constructor
        ///</summary>
        [TestMethod()]
        public void KaartConstructorTest()
        {
            Kaart target = buildKaart("Speler", null, false);
            Assert.IsNotNull(target, "Kaart instance mag niet null zijn.");
        }

        private static Kaart buildKaart(String spelerNaam, Gebeurtenis gebeurtenis, bool verplaatsKaartNaarSpeler)
        {
            return new Kaart(spelerNaam, gebeurtenis, verplaatsKaartNaarSpeler);
        }

        /// <summary>
        ///A test for properties
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CRMonopoly.exe")]
        public void NaamTest()
        {
            String spelerNaam = "Speler";
            bool kaartNaarSpelerYN = true;
            Gebeurtenis gebeurtenis = new Vrij();
            Kaart target = buildKaart(spelerNaam, gebeurtenis, kaartNaarSpelerYN);
            Assert.AreEqual(spelerNaam, target.Naam,
                String.Format("De naam van de speler in de Kaart is niet correct (Exp: {0}; Act: {1}).", spelerNaam, target.Naam));
            Assert.AreEqual(kaartNaarSpelerYN, target.KaartNaarSpeler,
                String.Format("De indicatie of de kaart naar de speler moet is niet correct (Exp: {0}; Act: {1}).", kaartNaarSpelerYN, target.KaartNaarSpeler));
            Assert.AreEqual(gebeurtenis, target.Actie,
                String.Format("De gebeurtenis in de Kaart is niet correct (Exp: {0}; Act: {1}).", gebeurtenis, target.Actie));
        }
    }
}
