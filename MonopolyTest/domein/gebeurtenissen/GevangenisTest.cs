using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly.domein;
using Monopoly.domein.gebeurtenissen;
using Monopoly.domein.labels;

namespace MonopolyTest.domein.gebeurtenissen
{
    [TestClass]
    public class GevangenisTest
    {
        [TestMethod]
        public void TestGevangenisAlleenMaarOpBezoek()
        {
            Monopolyspel spel = new Monopolyspel();
            spel.Bord = new Spelbord();
            spel.VoegSpelerToe("OpBezoekInGevangenis_01");
            Speler speler = spel.Spelers[0];
            VerplaatsSpeler.CreateVerplaatsVooruit("Testing_01", spel.Bord.GeefVeld(Veldnamen.STATION_ZUID)).Voeruit(speler);
            Assert.AreEqual(Veldnamen.STATION_ZUID, speler.Positie.Naam, "Speler zou nu op Station zuid moeten staan.");
            VerplaatsSpeler.CreateVerplaatsVooruit("Testing_02", 5).Voeruit(speler);
            Assert.AreEqual(Veldnamen.GEVANGENIS, speler.Positie.Naam, "Speler zou nu op Gevangenis moeten staan.");
            VerplaatsSpeler.CreateVerplaatsVooruit("Testing_03", 2).Voeruit(speler);
            Assert.AreEqual(Veldnamen.NUTS_ELEKTRICITEIT, speler.Positie.Naam, "Speler zou nu op Elektriciteitsbedrijf moeten staan.");
        }

        [TestMethod]
        public void TestGevangenisAlsGevangene()
        {
            Monopolyspel spel = new Monopolyspel();
            spel.Bord = new Spelbord();
            spel.VoegSpelerToe("Gevangene_01");
            Speler speler = spel.Spelers[0];
            VerplaatsSpeler.CreateVerplaatsVooruit("Testing_01", spel.Bord.GeefVeld(Veldnamen.STATION_NOORD)).Voeruit(speler);
            Assert.AreEqual(Veldnamen.STATION_NOORD, speler.Positie.Naam, "Speler zou nu op Station noord moeten staan.");
            VerplaatsSpeler.CreateVerplaatsVooruit("Testing_02", 5).Voeruit(speler);
            Assert.AreEqual(Veldnamen.GEVANGENIS, speler.Positie.Naam, "Speler zou nu op Gevangenis moeten staan.");
            VerplaatsSpeler.CreateVerplaatsVooruit("Testing_03", 2).Voeruit(speler);
            Assert.AreEqual(Veldnamen.GEVANGENIS, speler.Positie.Naam, "Speler zou nu nog steeds op gevangenis moeten staan.");
        }

        [TestMethod]
        public void TestGevangenisAlsGevangeneUitDeGevangenisMetKansKaart()
        {
            Monopolyspel spel = new Monopolyspel();
            spel.Bord = new Spelbord();
            spel.VoegSpelerToe("Gevangene_01");
            Speler speler = spel.Spelers[0];
            VerplaatsSpeler.CreateVerplaatsVooruit("Testing_01", spel.Bord.GeefVeld(Veldnamen.STATION_NOORD)).Voeruit(speler);
            Assert.AreEqual(Veldnamen.STATION_NOORD, speler.Positie.Naam, "Speler zou nu op Station noord moeten staan.");
            VerplaatsSpeler.CreateVerplaatsVooruit("Testing_02", 5).Voeruit(speler);
            Assert.AreEqual(Veldnamen.GEVANGENIS, speler.Positie.Naam, "Speler zou nu op Gevangenis moeten staan.");
            VerplaatsSpeler.CreateVerplaatsVooruit("Testing_03", 2).Voeruit(speler);
            Assert.AreEqual(Veldnamen.GEVANGENIS, speler.Positie.Naam, "Speler zou nu nog steeds op gevangenis moeten staan.");

        }
    }
}
