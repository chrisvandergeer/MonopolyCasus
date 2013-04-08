using CRMonopoly.domein;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

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
            spel.Add(new Speler("Speler X"));
            spel.Add(new Speler("Speler Y"));
            spel.Add(new Speler("Speler Z"));
            Assert.AreEqual(3, spel.AantalSpelers());
        }

        [TestMethod()]
        public void SpelersMetDezelfdeNaamZijnNietToegestaanTest()
        {
            Monopolyspel spel = new Monopolyspel();
            Assert.IsTrue(spel.Add(new Speler("Jan")));
            Assert.IsTrue(spel.Add(new Speler("Piet")));
            Assert.IsFalse(spel.Add(new Speler("Jan")));
            Assert.AreEqual(2, spel.AantalSpelers());
        }

        [TestMethod()]
        public void EindeBeurtTest()
        {
            Monopolyspel spel = new Monopolyspel();
            spel.Add(new Speler("Speler X"));
            spel.Add(new Speler("Speler Y"));
            spel.Start();
            spel.EindeBeurt();
            Assert.AreEqual("Speler Y", spel.Beurt.Speler.Name);
        }

        [TestMethod()]
        [ExpectedException(typeof(ApplicationException), "Illegal state, you need minimal 2 players for a game")]
        public void StartTestTeWeinigSpelers()
        {
            Monopolyspel spel = new Monopolyspel();
            spel.Add(new Speler("Speler 1"));
            spel.Start();
        }

        [TestMethod()]
        [ExpectedException(typeof(ApplicationException), "Illegal state, you need minimal 2 players for a game")]
        public void StartTestTeVeelSpelers()
        {
            Monopolyspel spel = new Monopolyspel();
            spel.Add(new Speler("Speler 1")); spel.Add(new Speler("Speler 2"));
            spel.Add(new Speler("Speler 3")); spel.Add(new Speler("Speler 4"));
            spel.Add(new Speler("Speler 5")); spel.Add(new Speler("Speler 6"));
            spel.Add(new Speler("Speler 7")); spel.Add(new Speler("Speler 8"));
            spel.Add(new Speler("Speler 9"));
            spel.Start();
        }

        [TestMethod()]
        public void StartTestMinimaalAantalSpelers()
        {
            Monopolyspel spel = new Monopolyspel();
            spel.Add(new Speler("Speler 1"));
            spel.Add(new Speler("Speler 2"));
            Beurt beurt = spel.Start();
            Assert.AreEqual("Speler 1", beurt.Speler.Name);
        }

        [TestMethod()]
        public void StartTestMaximaalAantalSpelers()
        {
            Monopolyspel spel = new Monopolyspel();
            spel.Add(new Speler("Speler 1")); spel.Add(new Speler("Speler 2"));
            spel.Add(new Speler("Speler 3")); spel.Add(new Speler("Speler 4"));
            spel.Add(new Speler("Speler 5")); spel.Add(new Speler("Speler 6"));
            spel.Add(new Speler("Speler 7")); spel.Add(new Speler("Speler 8"));
            Beurt beurt = spel.Start();
            Assert.AreEqual("Speler 1", beurt.Speler.Name);
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
            Speler spelerX = new Speler("Speler X");
            spel.Add(spelerX);
            Speler spelerY = new Speler("Speler Y");
            spel.Add(spelerY);
            Speler spelerZ = new Speler("Speler Z");
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
            Speler spelerX = new Speler("Speler X");
            spel.Add(spelerX);
            Speler spelerY = new Speler("Speler Y");
            spel.Add(spelerY);
            Speler spelerZ = new Speler("Speler Z");
            spel.Add(spelerZ);

            Beurt beurt = spel.Start();
            Assert.IsNotNull(beurt, "Op dit moment zou er een beurt moeten zijn.");

            Assert.AreSame(beurt.Speler, spelerX, "De eerste speler zou aan de beurt moeten zijn.");
        }
    }
}
