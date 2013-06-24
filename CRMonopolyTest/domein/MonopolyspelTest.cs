using CRMonopoly.domein;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using CRMonopoly.AI;

namespace CRMonopolyTest
{    
    /// <summary>
    ///This is a test class for MonopolyspelTest and is intended
    ///to contain all MonopolyspelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MonopolyspelTest
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

        [TestMethod()]
        public void AantalSpelersTest()
        {
            Monopolyspel spel = new Monopolyspel();
            // Changes after Unity implementation.
            spel.Bord = new Monopolybord();

            spel.Add(new Speler("Speler X", new RiskyStraatKopendePlayerAI()));
            spel.Add(new Speler("Speler Y", new RiskyStraatKopendePlayerAI()));
            spel.Add(new Speler("Speler Z", new RiskyStraatKopendePlayerAI()));
            Assert.AreEqual(3, spel.AantalSpelers());
        }

        [TestMethod()]
        public void SpelersMetDezelfdeNaamZijnNietToegestaanTest()
        {
            Monopolyspel spel = new Monopolyspel();
            // Changes after Unity implementation.
            spel.Bord = new Monopolybord();

            Assert.IsTrue(spel.Add(new Speler("Jan", new RiskyStraatKopendePlayerAI())));
            Assert.IsTrue(spel.Add(new Speler("Piet", new RiskyStraatKopendePlayerAI())));
            Assert.IsFalse(spel.Add(new Speler("Jan", new RiskyStraatKopendePlayerAI())));
            Assert.AreEqual(2, spel.AantalSpelers());
        }

        [TestMethod()]
        public void EindeBeurtTest()
        {
            Monopolyspel spel = new Monopolyspel();
            // Changes after Unity implementation.
            spel.Bord = new Monopolybord();

            spel.Add(new Speler("Speler X", null));
            spel.Add(new Speler("Speler Y", null));
            MonopolyspelController beurt = new MonopolyspelController(spel);
            Speler speler = beurt.StartSpel();
            beurt.StartBeurt(speler);
            Speler speler2 = beurt.EindeBeurt(speler);
            Assert.AreEqual("Speler Y", speler2.Name);
        }

        [TestMethod()]
        [ExpectedException(typeof(ApplicationException), "Illegal state, you need minimal 2 players for a game")]
        public void StartTestTeWeinigSpelers()
        {
            Monopolyspel spel = new Monopolyspel();
            // Changes after Unity implementation.
            spel.Bord = new Monopolybord();

            spel.Add(new Speler("Speler 1", null));
            MonopolyspelController controller = new MonopolyspelController(spel);
            controller.StartSpel();
        }

        [TestMethod()]
        [ExpectedException(typeof(ApplicationException), "Illegal state, you need minimal 2 players for a game")]
        public void StartTestTeVeelSpelers()
        {
            Monopolyspel spel = new Monopolyspel();
            // Changes after Unity implementation.
            spel.Bord = new Monopolybord();
            // Changes after Unity implementation.
            spel.Bord = new Monopolybord();

            spel.Add(new Speler("Speler 1", null)); spel.Add(new Speler("Speler 2", null));
            spel.Add(new Speler("Speler 3", null)); spel.Add(new Speler("Speler 4", null));
            spel.Add(new Speler("Speler 5", null)); spel.Add(new Speler("Speler 6", null));
            spel.Add(new Speler("Speler 7", null)); spel.Add(new Speler("Speler 8", null));
            spel.Add(new Speler("Speler 9", null));
            MonopolyspelController controller = new MonopolyspelController(spel);
            controller.StartSpel();
        }

        [TestMethod()]
        public void StartTestMinimaalAantalSpelers()
        {
            Monopolyspel spel = new Monopolyspel();
            // Changes after Unity implementation.
            spel.Bord = new Monopolybord();

            spel.Add(new Speler("Speler 1", null));
            spel.Add(new Speler("Speler 2", null));
            MonopolyspelController controller = new MonopolyspelController(spel);
            Assert.AreEqual("Speler 1", controller.StartSpel().Name);
        }

        [TestMethod()]
        public void StartTestMaximaalAantalSpelers()
        {
            Monopolyspel spel = new Monopolyspel();
            // Changes after Unity implementation.
            spel.Bord = new Monopolybord();

            spel.Add(new Speler("Speler 1", null)); spel.Add(new Speler("Speler 2", null));
            spel.Add(new Speler("Speler 3", null)); spel.Add(new Speler("Speler 4", null));
            spel.Add(new Speler("Speler 5", null)); spel.Add(new Speler("Speler 6", null));
            spel.Add(new Speler("Speler 7", null)); spel.Add(new Speler("Speler 8", null));
            Speler speler = new MonopolyspelController(spel).StartSpel();
            Assert.AreEqual("Speler 1", speler.Name);
        }


        /// <summary>
        ///A test for Monopolyspel Constructor
        ///</summary>
        [TestMethod()]
        public void MonopolyspelConstructorTest()
        {
            Monopolyspel target = new Monopolyspel();
            Assert.IsNotNull(target, "Het monopolyspel zou hier geinstantieerd moeten zijn.");
        }

        /// <summary>
        ///A test for ErIsEenVerliezer
        ///</summary>
        [TestMethod()]
        public void ErIsEenVerliezerTest()
        {
            Monopolyspel spel = new Monopolyspel();
            // Changes after Unity implementation.
            spel.Bord = new Monopolybord();
            // Changes after Unity implementation.
            spel.Bord = new Monopolybord();

            Speler spelerX = new Speler("Speler X", null);
            spel.Add(spelerX);
            Speler spelerY = new Speler("Speler Y", null);
            spel.Add(spelerY);
            Speler spelerZ = new Speler("Speler Z", null);
            spel.Add(spelerZ);

            bool expected = false;
            bool actual = spel.ErIsEenVerliezer();
            Assert.AreEqual(expected, actual, "Er zou op dit moment nog geen verliezer mogen zijn.");

            // Dit is een truc die waarschijnlijk gaat verdwijnen (at some point).
            int startbedrag = 1500;
            spelerZ.Ontvang(-(startbedrag + 5));
           
            expected = true;
            actual = spel.ErIsEenVerliezer();
            Assert.AreEqual(expected, actual, "Er zou op dit moment een verliezer mogen zijn.");
        }

        /// <summary>
        ///A test for Start
        ///</summary>
        [TestMethod()]
        public void StartTest()
        {
            Monopolyspel spel = new Monopolyspel();
            // Changes after Unity implementation.
            spel.Bord = new Monopolybord();

            Speler spelerX = new Speler("Speler X", null);
            spel.Add(spelerX);
            Speler spelerY = new Speler("Speler Y", null);
            spel.Add(spelerY);
            Speler spelerZ = new Speler("Speler Z", null);
            spel.Add(spelerZ);
            Speler speler = new MonopolyspelController(spel).StartSpel();
            Assert.AreSame(speler, spelerX, "De eerste speler zou aan de beurt moeten zijn.");
        }
    }
}
