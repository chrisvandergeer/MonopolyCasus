using CRMonopoly.domein;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CRMonopoly.builders;
using CRMonopoly.domein.velden;
using CRMonopoly.domein.gebeurtenis;

namespace CRMonopolyTest
{


    /// <summary>
    ///This is a test class for BeurtTest and is intended
    ///to contain all BeurtTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GooiDobbelstenenGebeurtenisTest
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
            spel.Add(new Speler("Speler_1"));
            spel.Add(new Speler("Speler_2"));

            MonopolyspelController controller = new MonopolyspelController(spel);
            Speler speler = controller.StartSpel();
            Gebeurtenissen gebeurtenissen = controller.StartBeurt(speler);
            Assert.IsTrue(gebeurtenissen.bevatGooiDobbelstenenGebeurtenis(), "De eerste beurt moet altijd de GooiDobbelstenenGebeurtenis hebben.");
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

            MonopolyspelController controller = new MonopolyspelController(spel);
            Speler speler = controller.StartSpel();
            Gebeurtenissen gebeurtenissen = controller.StartBeurt(speler);
            gebeurtenissen.GeefDobbelstenenGebeurtenis().VoerUit(speler);

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

            MonopolyspelController controller = new MonopolyspelController(spel);
            Speler speler = controller.StartSpel();
            Gebeurtenissen gebeurtenissen = controller.StartBeurt(speler);
            gebeurtenissen.GeefDobbelstenenGebeurtenis().VoerUit(speler);
            Speler volgendeSpeler = controller.EindeBeurt(speler);

            Assert.AreSame(speler2, volgendeSpeler, "De beurt had gewisseld moeten zijn.");
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

            Worp mijnSpecialeWorp = new Worp();
            mijnSpecialeWorp.Gedobbeldeworp1 = 1;
            mijnSpecialeWorp.Gedobbeldeworp2 = 1;

            // Mock van de Worp.GooiDobbelstenen methode. De methode returned een Worp mock waarbij altijd 1, 1 wordt gegooid.
            CRMonopoly.domein.Moles.MWorp.GooiDobbelstenen = () =>
            {
                return mijnSpecialeWorp;
            };

            MonopolyspelController controller = new MonopolyspelController(spel);
            Speler speler = controller.StartSpel();
            // Start de test. Eerste worp
            Gebeurtenissen gebeurtenissen = controller.StartBeurt(speler);
            gebeurtenissen.GeefDobbelstenenGebeurtenis().VoerUit(speler);

            Worp huidigeWorp = speler.WorpenInHuidigeBeurt.LaatsteWorp();
            Assert.AreEqual(1, huidigeWorp.Gedobbeldeworp1, "De worp had 1 moeten zijn (Moled).");
            Assert.AreEqual(1, huidigeWorp.Gedobbeldeworp2, "De worp had 1 moeten zijn (Moled).");
            Assert.AreEqual(KansEnAlgemeenFondsVeldBuilder.ALGEMEEN_FONDS_NAAM, speler.HuidigePositie.Naam, "Veld naam is niet goed");
            // Omdat er dubbel is gegooid moet er nu nog steeds een GooiDobbestenenGebeurtenis zitten bij de gebeurtenissen.
            Assert.IsTrue(speler.UitTeVoerenGebeurtenissen.bevatGooiDobbelstenenGebeurtenis(), "Er zou een GooiDobbelstenenGebeurtenis moeten zijn.");

            // Tweede worp
            speler.UitTeVoerenGebeurtenissen.GeefDobbelstenenGebeurtenis().VoerUit(speler);
            huidigeWorp = speler.WorpenInHuidigeBeurt.LaatsteWorp();
            Assert.AreEqual(1, huidigeWorp.Gedobbeldeworp1, "De worp had 1 moeten zijn (Moled).");
            Assert.AreEqual(1, huidigeWorp.Gedobbeldeworp2, "De worp had 1 moeten zijn (Moled).");
            Assert.AreEqual(BelastingVeldenBuilder.INKOMSTENBELASTING, speler.HuidigePositie.Naam, "Veld naam is niet goed");
            Assert.IsTrue(speler.UitTeVoerenGebeurtenissen.bevatGooiDobbelstenenGebeurtenis(), "Er zou een GooiDobbelstenenGebeurtenis moeten zijn.");

            //// Derde worp en direct naar de gevangenis.
            speler.UitTeVoerenGebeurtenissen.GeefDobbelstenenGebeurtenis().VoerUit(speler);
            Assert.AreEqual(1, speler.WorpenInHuidigeBeurt.LaatsteWorp().Gedobbeldeworp1, "De worp had 1 moeten zijn (Moled).");
            Assert.AreEqual(1, speler.WorpenInHuidigeBeurt.LaatsteWorp().Gedobbeldeworp2, "De worp had 1 moeten zijn (Moled).");
            Assert.AreEqual(Gevangenis.VELD_NAAM, speler.HuidigePositie.Naam, "Veld naam is niet goed");

            Assert.IsTrue(speler.InGevangenis, "De speler zou in de gevangenis moeten zitten. Niet alleen op bezoek.");
        }


        // TODO: Implement uit de gevangenis na drie beurten wanneer ????????

    //    /// <summary>
    //    /// A test for 3 turns in jail means free.
    //    /// This test depends on Moles. Download it from http://research.microsoft.com/en-us/projects/moles/ and install it.
    //    ///</summary>
    //    [TestMethod()]
    //    [HostType("Moles")]
    //    public void SpelerInDeGevangenisKanNietVerplaatsen()
    //    {
    //        Monopolyspel spel = new Monopolyspel();
    //        Speler speler1 = new Speler("Speler_1");
    //        spel.Add(speler1);
    //        Speler speler2 = new Speler("Speler_2");
    //        spel.Add(speler2);

    //        int x = 1;
    //        int y = 3;

    //        // Mock van de Worp.GooiDobbelstenen methode. De methode returned een Worp mock waarbij altijd 1, 3 wordt gegooid.
    //        CRMonopoly.domein.Moles.MWorp.GooiDobbelstenen = () =>
    //        {
    //            CRMonopoly.domein.Moles.MWorp worp = new CRMonopoly.domein.Moles.MWorp();
    //            worp.Gedobbeldeworp1Get = () => { return x; };
    //            worp.Gedobbeldeworp2Get = () => { return y; };
    //            worp.IsDubbelGegooid = () => { return x == y; };
    //            worp.Totaal = () => { return x + y; };
    //            worp.ToString = () => { return ((x == y) ? "*" : "") + (x + y); };
    //            return worp;
    //        };

    //        // Plaats de tweede speler in de gevangenis
    //        Gebeurtenis actie = new GaNaarGevangenis();
    //        actie.VoerUit(speler2);
    //        Assert.AreEqual(GevangenisOpBezoek.VELD_NAAM, speler2.HuidigePositie.Naam, "Veld naam is niet goed");
    //        Assert.IsTrue(speler2.InGevangenis, "De speler zou in de gevangenis moeten zitten. Niet alleen op bezoek.");

    //        // Beurt 1
    //        // Geeft beurt aan speler1
    //        Beurt beurt = spel.Start();
    //        beurt.StartBeurt();
    //        Assert.AreEqual(1, beurt.WorpenInHuidigeBeurt.LaatsteWorp().Gedobbeldeworp1, "De worp had 1 moeten zijn (Moled).");
    //        Assert.AreEqual(3, beurt.WorpenInHuidigeBeurt.LaatsteWorp().Gedobbeldeworp2, "De worp had 3 moeten zijn (Moled).");
    //        Assert.AreEqual(speler1, beurt.HuidigeSpeler, "Speler1 had aan de beurt moeten zijn.");
    //        Assert.AreEqual(BelastingVeldenBuilder.INKOMSTENBELASTING, beurt.HuidigeSpeler.HuidigePositie.Naam, "Veld naam is niet goed");

    //        // Geeft beurt aan speler2
    //        spel.EindeBeurt();
    //        beurt.StartBeurt();
    //        Assert.AreEqual(1, beurt.WorpenInHuidigeBeurt.LaatsteWorp().Gedobbeldeworp1, "De worp had 1 moeten zijn (Moled).");
    //        Assert.AreEqual(3, beurt.WorpenInHuidigeBeurt.LaatsteWorp().Gedobbeldeworp2, "De worp had 3 moeten zijn (Moled).");
    //        Assert.AreEqual(speler2, beurt.HuidigeSpeler, "Speler2 had aan de beurt moeten zijn.");
    //        Assert.AreEqual(GevangenisOpBezoek.VELD_NAAM, speler2.HuidigePositie.Naam, "Veld naam is niet goed");
    //        Assert.IsTrue(speler2.InGevangenis, "De speler zou in de gevangenis moeten zitten. Niet alleen op bezoek.");

    //        // Beurt 2
    //        // Geeft beurt aan speler1
    //        spel.EindeBeurt();
    //        beurt.StartBeurt();
    //        Assert.AreEqual(1, beurt.WorpenInHuidigeBeurt.LaatsteWorp().Gedobbeldeworp1, "De worp had 1 moeten zijn (Moled).");
    //        Assert.AreEqual(3, beurt.WorpenInHuidigeBeurt.LaatsteWorp().Gedobbeldeworp2, "De worp had 3 moeten zijn (Moled).");
    //        Assert.AreEqual(speler1, beurt.HuidigeSpeler, "Speler1 had aan de beurt moeten zijn.");
    //        Assert.AreEqual(ArnhemBuilder.KETELSTRAAT, speler1.HuidigePositie.Naam, "Veld naam is niet goed");

    //        // Geeft beurt aan speler2
    //        spel.EindeBeurt();
    //        beurt.StartBeurt();
    //        Assert.AreEqual(1, beurt.WorpenInHuidigeBeurt.LaatsteWorp().Gedobbeldeworp1, "De worp had 1 moeten zijn (Moled).");
    //        Assert.AreEqual(3, beurt.WorpenInHuidigeBeurt.LaatsteWorp().Gedobbeldeworp2, "De worp had 3 moeten zijn (Moled).");
    //        Assert.AreEqual(speler2, beurt.HuidigeSpeler, "Speler2 had aan de beurt moeten zijn.");
    //        Assert.AreEqual(GevangenisOpBezoek.VELD_NAAM, speler2.HuidigePositie.Naam, "Veld naam is niet goed");
    //        Assert.IsTrue(speler2.InGevangenis, "De speler zou in de gevangenis moeten zitten. Niet alleen op bezoek.");

    //        // Beurt 3
    //        // Geeft beurt aan speler1
    //        spel.EindeBeurt();
    //        beurt.StartBeurt();
    //        Assert.AreEqual(1, beurt.WorpenInHuidigeBeurt.LaatsteWorp().Gedobbeldeworp1, "De worp had 1 moeten zijn (Moled).");
    //        Assert.AreEqual(3, beurt.WorpenInHuidigeBeurt.LaatsteWorp().Gedobbeldeworp2, "De worp had 3 moeten zijn (Moled).");
    //        Assert.AreEqual(speler1, beurt.HuidigeSpeler, "Speler1 had aan de beurt moeten zijn.");
    //        Assert.AreEqual(NutsbedrijvenBuilder.ELEKTRICITEITSBEDRIJF, speler1.HuidigePositie.Naam, "Veld naam is niet goed");

    //        // Geeft beurt aan speler2
    //        spel.EindeBeurt();
    //        beurt.StartBeurt();
    //        Assert.AreEqual(1, beurt.WorpenInHuidigeBeurt.LaatsteWorp().Gedobbeldeworp1, "De worp had 1 moeten zijn (Moled).");
    //        Assert.AreEqual(3, beurt.WorpenInHuidigeBeurt.LaatsteWorp().Gedobbeldeworp2, "De worp had 3 moeten zijn (Moled).");
    //        Assert.AreEqual(speler2, beurt.HuidigeSpeler, "Speler2 had aan de beurt moeten zijn.");
    //        Assert.AreEqual(HaarlemBuilder.HOUTSTRAAT, speler2.HuidigePositie.Naam, "Veld naam is niet goed");
    //        Assert.IsFalse(speler2.InGevangenis, "De speler zou in de gevangenis moeten zitten. Niet alleen op bezoek.");
    //    }
    }
}
