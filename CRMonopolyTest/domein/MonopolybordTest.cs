using CRMonopoly.domein;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CRMonopoly.builders;
using CRMonopoly.domein.velden;

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
            Start.VELD_NAAM, 
            // Bottom Row
            OnsDorpBuilder.DORPSSTRAAT, KansEnAlgemeenFondsVeldBuilder.ALGEMEEN_FONDS_NAAM, OnsDorpBuilder.BRINK,
            BelastingVeldenBuilder.INKOMSTENBELASTING, Stationbuilder.ZUID, ArnhemBuilder.STEENSTRAAT, KansEnAlgemeenFondsVeldBuilder.KANS_NAAM, 
            ArnhemBuilder.KETELSTRAAT, ArnhemBuilder.VELPERPLEIN, 
            // BottomLeft Corner
            Gevangenis.VELD_NAAM, 
            // Left Row
            HaarlemBuilder.BARTELJORISSTRAAT, NutsbedrijvenBuilder.ELEKTRICITEITSBEDRIJF, HaarlemBuilder.ZIJLWEG, 
            HaarlemBuilder.HOUTSTRAAT, Stationbuilder.WEST, UtrechtBuilder.NEUDE, 
            KansEnAlgemeenFondsVeldBuilder.ALGEMEEN_FONDS_NAAM, UtrechtBuilder.BILTSTRAAT, UtrechtBuilder.VREEBURG, 
            // TopLeft Corner
            VrijParkeren.VELD_NAAM, 
            // Top Row
            GroningenBuilder.ALGEMENE_KERKHOF, KansEnAlgemeenFondsVeldBuilder.KANS_NAAM, GroningenBuilder.GROTE_MARKT, 
            GroningenBuilder.HEERESTRAAT, Stationbuilder.NOORD, DenHaagBuilder.SPUI, 
            DenHaagBuilder.PLEIN, NutsbedrijvenBuilder.WATERLEIDING, DenHaagBuilder.LANGE_POTEN,
            // TopRight Corner
            GaNaarGevangenisVeld.VELD_NAAM,
            // Right row
            RotterdamBuilder.HOFPLEIN, RotterdamBuilder.BLAAK, KansEnAlgemeenFondsVeldBuilder.ALGEMEEN_FONDS_NAAM,
            RotterdamBuilder.COOLSINGEL, Stationbuilder.OOST, KansEnAlgemeenFondsVeldBuilder.KANS_NAAM, 
            AmsterdamBuilder.LEIDSESTRAAT, BelastingVeldenBuilder.EXTRAINKOMSTENBELASTING, AmsterdamBuilder.KALVERSTRAAT
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
            Assert.AreEqual(KansEnAlgemeenFondsVeldBuilder.ALGEMEEN_FONDS_NAAM, veld.Naam);
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
            Monopolybord bord = new Monopolybord();
            Veld result = bord.StartVeld();
            for (int veldTeller = 1; veldTeller < 40; veldTeller++)
            {
                result = checkVolgendeVeld(bord, result, veldTeller);
            }
        }

        private Veld checkVolgendeVeld(Monopolybord target, Veld veld, int veldTeller)
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
            Monopolybord bord = new Monopolybord();
            Straat straat = bord.Straat(ArnhemBuilder.KETELSTRAAT);
            Assert.AreEqual("Ketelstraat", straat.Naam);
        }
    }
}
