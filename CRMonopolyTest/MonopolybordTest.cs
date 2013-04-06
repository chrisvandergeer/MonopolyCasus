using CRMonopoly.domein;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CRMonopoly.builders;

namespace CRMonopolyTest
{

    /// <summary>
    ///This is a test class for MonopolybordTest and is intended
    ///to contain all MonopolybordTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MonopolybordTest
    { 
        private Worp altijdEenGooien = Worp.GooiDobbelstenen();
        private string[] bordLayout = new String[] {
            // BottomRight Corner
            "Start", 
            // Bottom Row
            StadBuilder.NAAM_STRAAT_ONS_DORP_DORPSSTRAAT, Monopolybord.ALGEMEEN_FONDS_NAAM, StadBuilder.NAAM_STRAAT_ONS_DORP_BRINK,
            "Inkomstenbelasting", "Station zuid", StadBuilder.NAAM_STRAAT_ARNHEM_STEENSTRAAT, Monopolybord.KANS_NAAM, 
            StadBuilder.NAAM_STRAAT_ARNHEM_KETELSTRAAT, StadBuilder.NAAM_STRAAT_ARNHEM_VELPERPLEIN, 
            // BottomLeft Corner
            "Gevangenis", 
            // Left Row
            StadBuilder.NAAM_STRAAT_HAARLEM_BARTELJORISSTRAAT, "Elektriciteitsbedrijf", StadBuilder.NAAM_STRAAT_HAARLEM_ZIJLWEG, 
            StadBuilder.NAAM_STRAAT_HAARLEM_HOUTSTRAAT, "Station west", StadBuilder.NAAM_STRAAT_UTRECHT_NEUDE, 
            Monopolybord.ALGEMEEN_FONDS_NAAM, StadBuilder.NAAM_STRAAT_UTRECHT_BILTSTRAAT, StadBuilder.NAAM_STRAAT_UTRECHT_VREEBURG, 
            // TopLeft Corner
            "Vrij parkeren", 
            // Top Row
            StadBuilder.NAAM_STRAAT_GRONINGEN_ALGEMENE_KERKHOF, Monopolybord.KANS_NAAM, StadBuilder.NAAM_STRAAT_GRONINGEN_GROTE_MARKT, 
            StadBuilder.NAAM_STRAAT_GRONINGEN_HEERESTRAAT, "Station noord", StadBuilder.NAAM_STRAAT_DEN_HAAG_SPUI, 
            StadBuilder.NAAM_STRAAT_DEN_HAAG_PLEIN, "Waterleiding", StadBuilder.NAAM_STRAAT_DEN_HAAG_LANGE_POTEN,
            // TopRight Corner
            "Naar de gevangenis",
            // Right row
            StadBuilder.NAAM_STRAAT_ROTTERDAM_HOFPLEIN, StadBuilder.NAAM_STRAAT_ROTTERDAM_BLAAK, Monopolybord.ALGEMEEN_FONDS_NAAM,
            StadBuilder.NAAM_STRAAT_ROTTERDAM_COOLSINGEL, "Station oost", Monopolybord.KANS_NAAM, 
            StadBuilder.NAAM_STRAAT_AMSTERDAM_LEIDSESTRAAT, "Extra belasting", StadBuilder.NAAM_STRAAT_AMSTERDAM_KALVERSTRAAT
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
            Monopolybord bord = new Monopolybord();
            Veld start = bord.StartVeld();
            Worp worp = Worp.GooiDobbelstenen();
            worp.Gedobbeldeworp1 = 1;
            worp.Gedobbeldeworp2 = 1;
            Veld veld = bord.GeefVeld(start, worp);
            Assert.AreEqual(Monopolybord.ALGEMEEN_FONDS_NAAM, veld.Naam);
        }

        /// <summary>
        ///A test for StartVeld
        ///</summary>
        [TestMethod()]
        public void StartVeldTest()
        {
            Assert.AreEqual("Start", new Monopolybord().StartVeld().Naam);
        }

        /// <summary>
        ///A test for Monopolybord Constructor
        ///</summary>
        [TestMethod()]
        public void MonopolybordConstructorTest()
        {
            Monopolybord target = new Monopolybord();

            Veld result = target.StartVeld();
            for (int veldTeller = 1; veldTeller < 40; veldTeller++)
            {
                result = checkVolgendeVeld(target, result, veldTeller);
            }
        }

        private Veld checkVolgendeVeld(Monopolybord target, Veld veld, int veldTeller)
        {
            string expectedName = bordLayout[veldTeller];
            Veld result = target.GeefVeld(veld, altijdEenGooien);
            Assert.AreSame(result.Naam, expectedName, String.Format("Naam van veld {0} is fout. (Exp: {1}; Act: {2})", veldTeller, expectedName, result.Naam));
            return result;
        }
    }
}
