using CRMonopoly.domein;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CRMonopoly.builders;
using CRMonopoly.domein.velden;

namespace CRMonopolyTest
{
    
    
    /// <summary>
    ///This is a test class for BeurtTest and is intended
    ///to contain all BeurtTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BeurtTest
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
        ///A test for Beurt Constructor
        ///</summary>
        [TestMethod()]
        public void BeurtConstructorTest()
        {
            Monopolyspel spel = new Monopolyspel();
            spel.Add(new Speler("Speler"));
            Beurt target = new Beurt(spel);
            Assert.IsNotNull(target, "De Beurt zou nu geinstantieerd moeten zijn.");
        }

        /// <summary>
        ///A test for GooiDobbelstenen
        ///</summary>
        [TestMethod()]
        public void GooiDobbelstenenTest()
        {
            Monopolyspel spel = new Monopolyspel();
            Speler speler1 = new Speler("Speler_1");
            spel.Add(speler1);
            spel.Add(new Speler("Speler_2"));
            Beurt target = spel.Start();

            target.StartBeurt();
            // speler1 zou verplaatst moeten zijn.
            Assert.AreNotSame(spel.Bord.StartVeld(), speler1.HuidigePositie);
        }

        /// <summary>
        ///A test for WisselBeurt
        ///</summary>
        [TestMethod()]
        public void WisselBeurtTest()
        {
            Monopolyspel spel = new Monopolyspel();
            spel.Add(new Speler("Speler_1"));
            Speler speler2 = new Speler("Speler_2");
            spel.Add(speler2);
            Beurt target = new Beurt(spel);
            target.WisselBeurt(speler2);

            Assert.AreSame(speler2, target.HuidigeSpeler, "De beurt had gewisseld moeten zijn.");
        }


        /// <summary>
        ///A test for 3 times double is move to the jail
        /// This test depends on Moles. Download it from http://research.microsoft.com/en-us/projects/moles/ and install it.
        ///</summary>
        [TestMethod()]
        [HostType("Moles")]
        public void GooiDrieKeerDubbelResultsInGaNaarGevangenis()
        {
            Monopolyspel spel = new Monopolyspel();
            Speler speler1 = new Speler("Speler_1");
            spel.Add(speler1);
            Speler speler2 = new Speler("Speler_2");
            spel.Add(speler2);

            // Mock van de Worp.GooiDobbelstenen methode. De methode returned een Worp mock waarbij altijd 1, 1 wordt gegooid.
            //CRMonopoly.domein.Moles.MWorp.GooiDobbelstenen = () =>
            //{
            //    CRMonopoly.domein.Moles.MWorp worp = new CRMonopoly.domein.Moles.MWorp();
            //    worp.Gedobbeldeworp1Get = () => { return 1; };
            //    worp.Gedobbeldeworp2Get = () => { return 1; };
            //    worp.IsDubbelGegooid = () => { return true; };
            //    worp.Totaal = () => { return 2; };
            //    worp.ToString = () => { return "2*"; };
            //    return worp;
            //};

            // Start de test. Eerste worp
            Beurt beurt = spel.Start();
            Speler spelerAanDeBeurt = beurt.HuidigeSpeler;
            beurt.StartBeurt();
            Assert.AreEqual(1, beurt.WorpenInHuidigeBeurt.LaatsteWorp().Gedobbeldeworp1, "De worp had 1 moeten zijn (Moled).");
            Assert.AreEqual(1, beurt.WorpenInHuidigeBeurt.LaatsteWorp().Gedobbeldeworp2, "De worp had 1 moeten zijn (Moled).");
            Assert.AreEqual(spelerAanDeBeurt, beurt.HuidigeSpeler, "De spelers moeten niet gewisseld zijn.");
            Assert.AreEqual(Monopolybord.ALGEMEEN_FONDS_NAAM, beurt.HuidigeSpeler.HuidigePositie.Naam, "Veld naam is niet goed");

            // Tweede worp
            beurt.StartBeurt();
            Assert.AreEqual(1, beurt.WorpenInHuidigeBeurt.LaatsteWorp().Gedobbeldeworp1, "De worp had 1 moeten zijn (Moled).");
            Assert.AreEqual(1, beurt.WorpenInHuidigeBeurt.LaatsteWorp().Gedobbeldeworp2, "De worp had 1 moeten zijn (Moled).");
            Assert.AreEqual(spelerAanDeBeurt, beurt.HuidigeSpeler, "De spelers moeten niet gewisseld zijn.");
            Assert.AreEqual(BelastingVeldenBuilder.INKOMSTENBELASTING, beurt.HuidigeSpeler.HuidigePositie.Naam, "Veld naam is niet goed");

            // Derde worp en direct naar de gevangenis.
            beurt.StartBeurt();
            Assert.AreEqual(1, beurt.WorpenInHuidigeBeurt.LaatsteWorp().Gedobbeldeworp1, "De worp had 1 moeten zijn (Moled).");
            Assert.AreEqual(1, beurt.WorpenInHuidigeBeurt.LaatsteWorp().Gedobbeldeworp2, "De worp had 1 moeten zijn (Moled).");
            Assert.AreEqual(spelerAanDeBeurt, beurt.HuidigeSpeler, "De spelers moeten niet gewisseld zijn.");
            Assert.AreEqual(GevangenisOpBezoek.VELD_NAAM, beurt.HuidigeSpeler.HuidigePositie.Naam, "Veld naam is niet goed");

            Assert.IsTrue(beurt.HuidigeSpeler.InGevangenis, "De speler zou in de gevangenis moeten zitten. Niet alleen op bezoek.");
        }


    }
}
