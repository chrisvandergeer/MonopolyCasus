using Monopoly.domein;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Monopoly.domein.velden;
using System.Collections.Generic;
using Monopoly.builders;
using Monopoly.domein.labels;

namespace MonopolyTest
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
        ///A test for BezitHelft
        ///</summary>
        [TestMethod()]
        public void BezitHelftTest3StratenInStad()
        {
            Monopolyspel spel = new Monopolyspel();
            Speler spelerX = spel.VoegSpelerToe("Speler x");
            Speler spelerY = spel.VoegSpelerToe("Speler y");
            Straat steenstraat = (Straat) spel.Bord.GeefVeld(Veldnamen.STEENSTRAAT);
            Straat ketelstraat = (Straat) spel.Bord.GeefVeld(Veldnamen.KETELSTRAAT);
            Straat velperplein = (Straat)spel.Bord.GeefVeld(Veldnamen.VELPERPLEIN);
            Stad arnhem = steenstraat.Stad;

            Assert.IsFalse(arnhem.BezitHelft(spelerX));
            
            steenstraat.Verkoop(spelerX);
            Assert.IsFalse(arnhem.BezitHelft(spelerX));
            
            ketelstraat.Verkoop(spelerX);
            Assert.IsTrue(arnhem.BezitHelft(spelerX));
            
            velperplein.Verkoop(spelerX);
            Assert.IsTrue(arnhem.BezitHelft(spelerX));

        }

        /// <summary>
        ///A test for BezitHelft
        ///</summary>
        [TestMethod()]
        public void BezitHelftTest2StratenInStad()
        {
            Monopolyspel spel = new Monopolyspel();
            Speler spelerX = spel.VoegSpelerToe("Speler x");
            Speler spelerY = spel.VoegSpelerToe("Speler y");
            Straat dorpstraat = (Straat)spel.Bord.GeefVeld(Veldnamen.DORPSSTRAAT);
            Straat brink = (Straat)spel.Bord.GeefVeld(Veldnamen.BRINK);
            Stad onsdorp = dorpstraat.Stad;

            Assert.IsFalse(onsdorp.BezitHelft(spelerX));

            dorpstraat.Verkoop(spelerX);
            Assert.IsFalse(onsdorp.BezitHelft(spelerX));

            brink.Verkoop(spelerX);
            Assert.IsTrue(onsdorp.BezitHelft(spelerX));

        }

        /// <summary>
        ///A test for BezitStad
        ///</summary>
        [TestMethod()]
        public void BezitStadTest()
        {
            Monopolyspel spel = new Monopolyspel();
            Speler spelerX = spel.VoegSpelerToe("Speler x");
            Speler spelerY = spel.VoegSpelerToe("Speler y");
            Straat dorpstraat = (Straat)spel.Bord.GeefVeld(Veldnamen.DORPSSTRAAT);
            Straat brink = (Straat)spel.Bord.GeefVeld(Veldnamen.BRINK);
            Stad onsdorp = dorpstraat.Stad;
            // test
            Assert.IsFalse(onsdorp.BezitStad(spelerX));

            dorpstraat.Verkoop(spelerX);
            Assert.IsFalse(onsdorp.BezitStad(spelerX));

            brink.Verkoop(spelerX);
            Assert.IsTrue(onsdorp.BezitStad(spelerX));
        }

        /// <summary>
        ///A test for IsAllesVerkocht
        ///</summary>
        [TestMethod()]
        public void IsAllesVerkochtTest()
        {
            Monopolyspel spel = new Monopolyspel();
            Speler spelerX = spel.VoegSpelerToe("Speler x");
            Speler spelerY = spel.VoegSpelerToe("Speler y");
            Straat dorpstraat = (Straat)spel.Bord.GeefVeld(Veldnamen.DORPSSTRAAT);
            Straat brink = (Straat)spel.Bord.GeefVeld(Veldnamen.BRINK);
            Stad onsdorp = dorpstraat.Stad;
            // test
            Assert.IsFalse(onsdorp.IsAllesVerkocht());

            dorpstraat.Verkoop(spelerX);
            Assert.IsFalse(onsdorp.IsAllesVerkocht());

            brink.Verkoop(spelerY);
            Assert.IsTrue(onsdorp.IsAllesVerkocht());
        }

    }
}
