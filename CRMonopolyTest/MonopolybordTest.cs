﻿using CRMonopoly.domein;
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
            OnsDorpBuilder.DORPSSTRAAT, Monopolybord.ALGEMEEN_FONDS_NAAM, OnsDorpBuilder.BRINK,
            BelastingVeldenBuilder.INKOMSTENBELASTING, "Station zuid", ArnhemBuilder.STEENSTRAAT, Monopolybord.KANS_NAAM, 
            ArnhemBuilder.KETELSTRAAT, ArnhemBuilder.VELPERPLEIN, 
            // BottomLeft Corner
            "Gevangenis", 
            // Left Row
            HaarlemBuilder.BARTELJORISSTRAAT, NutsbedrijvenBuilder.ELEKTRICITEITSBEDRIJF, HaarlemBuilder.ZIJLWEG, 
            HaarlemBuilder.HOUTSTRAAT, "Station west", UtrechtBuilder.NEUDE, 
            Monopolybord.ALGEMEEN_FONDS_NAAM, UtrechtBuilder.BILTSTRAAT, UtrechtBuilder.VREEBURG, 
            // TopLeft Corner
            "Vrij parkeren", 
            // Top Row
            GroningenBuilder.ALGEMENE_KERKHOF, Monopolybord.KANS_NAAM, GroningenBuilder.GROTE_MARKT, 
            GroningenBuilder.HEERESTRAAT, "Station noord", DenHaagBuilder.SPUI, 
            DenHaagBuilder.PLEIN, NutsbedrijvenBuilder.WATERLEIDING, DenHaagBuilder.LANGE_POTEN,
            // TopRight Corner
            "Naar de gevangenis",
            // Right row
            RotterdamBuilder.HOFPLEIN, RotterdamBuilder.BLAAK, Monopolybord.ALGEMEEN_FONDS_NAAM,
            RotterdamBuilder.COOLSINGEL, "Station oost", Monopolybord.KANS_NAAM, 
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
