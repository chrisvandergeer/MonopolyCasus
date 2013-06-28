using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Monopoly.domein;
using Monopoly.domein.labels;
using Monopoly.domein.velden;

namespace MonopolyTest
{

    /// <summary>
    ///This is a test class for SpelbordTest and is intended
    ///to contain all spelbordTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SpelbordTest
    { 
        private Worp altijdEenGooien = Worp.GooiDobbelstenen();
        private string[] bordLayout = new String[] {
            // BottomRight Corner
            Veldnamen.START, 
            // Bottom Row
            Veldnamen.DORPSSTRAAT, Veldnamen.ALGEMEEN_FONDS, Veldnamen.BRINK,
            Veldnamen.INKOMSTENBELASTING, Veldnamen.STATION_ZUID, Veldnamen.STEENSTRAAT, Veldnamen.KANS, 
            Veldnamen.KETELSTRAAT, Veldnamen.VELPERPLEIN, 
            // BottomLeft Corner
            Veldnamen.GEVANGENIS, 
            // Left Row
            Veldnamen.BARTELJORISSTRAAT, Veldnamen.NUTS_ELEKTRICITEIT, Veldnamen.ZIJLWEG, 
            Veldnamen.HOUTSTRAAT, Veldnamen.STATION_WEST, Veldnamen.NEUDE, 
            Veldnamen.ALGEMEEN_FONDS, Veldnamen.BILTSTRAAT, Veldnamen.VREEBURG, 
            // TopLeft Corner
            Veldnamen.VRIJ_PARKEREN, 
            // Top Row
            Veldnamen.AKERKHOF, Veldnamen.KANS, Veldnamen.GROTE_MARKT, 
            Veldnamen.HEERESTRAAT, Veldnamen.STATION_NOORD, Veldnamen.SPUI, 
            Veldnamen.PLEIN, Veldnamen.NUTS_WATERLEIDING, Veldnamen.LANGE_POTEN,
            // TopRight Corner
            Veldnamen.GA_NAAR_GEVANGENIS,
            // Right row
            Veldnamen.HOFPLEIN, Veldnamen.BLAAK, Veldnamen.ALGEMEEN_FONDS,
            Veldnamen.COOLSINGEL, Veldnamen.STATION_OOST, Veldnamen.KANS, 
            Veldnamen.LEIDSCHESTRAAT, Veldnamen.EXTRAINKOMSTENBELASTING, Veldnamen.KALVERSTRAAT
        };


        [TestInitialize()]
        public void Initialize()
        {
            altijdEenGooien.Gedobbeldeworp1 = 1;
            altijdEenGooien.Gedobbeldeworp2 = 0;
        }

        /// <summary>
        ///A test for GeefVeld
        ///</summary>
        [TestMethod()]
        public void GeefVeldTest()
        {
            Spelbord bord = new Spelbord();
            Veld start = bord.GeefVeld(Veldnamen.START);
            Worp worp = Worp.GooiDobbelstenen();
            worp.Gedobbeldeworp1 = 1;
            worp.Gedobbeldeworp2 = 1;
            Veld veld = bord.GeefVeld(start, worp);
            Assert.AreEqual(Veldnamen.ALGEMEEN_FONDS, veld.Naam);
        }

        /// <summary>
        ///A test for StartVeld
        ///</summary>
        [TestMethod()]
        public void StartVeldTest()
        {
            Assert.AreEqual("Start", new Spelbord().GeefVeld(Veldnamen.START).Naam);
        }

        /// <summary>
        ///A test for Monopolybord Constructor
        ///</summary>
        [TestMethod()]
        public void MonopolybordConstructorTest()
        {
            Spelbord bord = new Spelbord();
            Veld result = bord.GeefVeld(Veldnamen.START);
            for (int veldTeller = 1; veldTeller < 40; veldTeller++)
            {
                result = checkVolgendeVeld(bord, result, veldTeller);
            }
        }

        private Veld checkVolgendeVeld(Spelbord target, Veld veld, int veldTeller)
        {
            string expectedName = bordLayout[veldTeller];
            Veld result = target.GeefVeld(veld, altijdEenGooien);
            Assert.AreSame(expectedName, result.Naam, String.Format("Naam van veld {0} is fout. (Exp: {1}; Act: {2})", veldTeller, expectedName, result.Naam));
            return result;
        }

        /// <summary>
        ///A test for Straat
        ///</summary>
        [TestMethod()]
        public void StraatTest()
        {
            Spelbord bord = new Spelbord();
            Veld straat = bord.GeefVeld(Veldnamen.KETELSTRAAT);
            Assert.AreEqual("Ketelstraat", straat.Naam);
        }

        /// <summary>
        ///A test for count VerkoopbareVelden
        ///</summary>
        [TestMethod()]
        public void CountVerkoopbareVeldenTest()
        {
            Spelbord bord = new Spelbord();
            int teller = 0;
            foreach (Veld veld in bord.Velden)
            {
                if (veld is IHypotheekveld) teller++;
            }
            int expected = 28;
            Assert.AreEqual(expected, teller, String.Format("Het aantal verkoopbare velden zou {0} moeten zijn, niet {1}", expected, teller));
        }

        /// <summary>
        ///A test for GeefVeld
        ///</summary>
        [TestMethod()]
        public void GeefVeldTestAchteruit()
        {
            Spelbord spelbord = new Spelbord();
            Veld start = spelbord.GeefVeld(Veldnamen.START);
            Veld veld = spelbord.GeefVeld(start, -1);
            Assert.AreEqual(Veldnamen.KALVERSTRAAT, veld.Naam);
        }

        /// <summary>
        ///A test for GeefVeld
        ///</summary>
        [TestMethod()]
        public void GeefVeldTestVooruit()
        {
            Spelbord spelbord = new Spelbord();
            Veld kalverstraat = spelbord.GeefVeld(Veldnamen.KALVERSTRAAT);
            Veld veld = spelbord.GeefVeld(kalverstraat, 1);
            Assert.AreEqual(Veldnamen.START, veld.Naam);
        }
    }
}
