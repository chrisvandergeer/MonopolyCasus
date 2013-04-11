using CRMonopoly.domein.gebeurtenis.kans;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CRMonopoly.domein.gebeurtenis;
using System.Collections.Generic;
using CRMonopoly.domein;

namespace CRMonopolyTest
{    
    
    /// <summary>
    ///This is a test class for VerlaatDeGevangenisTest and is intended
    ///to contain all VerlaatDeGevangenisTest Unit Tests
    ///</summary>
    [TestClass()]
    public class VerlaatDeGevangenisTest
    {
        /// <summary>
        /// De kaartstapel waar de VerlaatDeGevangenis kaart vanaf komt.
        /// </summary>
        private List<Gebeurtenis> kaarten = new List<Gebeurtenis>();

        /// <summary>
        /// Class under test
        /// </summary>
        private VerlaatDeGevangenis kaart;

        [TestInitialize]
        public void setup()
        {
            kaarten = new List<Gebeurtenis>();
            kaart = new VerlaatDeGevangenis(kaarten);
        }

        /// <summary>
        ///A test for Gebeurtenisnaam
        ///</summary>
        [TestMethod()]
        public void GebeurtenisnaamTest()
        {
            Assert.AreEqual("Verlaat de gevangenis zonder te betalen", kaart.Gebeurtenisnaam());
        }

        /// <summary>
        ///A test for IsVerplicht
        ///</summary>
        [TestMethod()]
        public void IsVerplichtTest()
        {
            Speler eigenaar = new Speler("SpelerX");
            eigenaar.InGevangenis = true;
            Assert.IsTrue(kaart.IsVerplicht());     // kaart komt van stapel
            kaart.VoerUit(eigenaar);                // kaart wordt overhandigd aan de speler
            Assert.IsFalse(kaart.IsVerplicht());    // kaart is in bezit van speler
            kaart.VoerUit(eigenaar);                // kaart wordt uitgevoerd en teruggelegd op stapel
            Assert.IsTrue(kaart.IsVerplicht());     // kaart komt van stapel 
        }

        /// <summary>
        ///A test for VoerUit
        ///</summary>
        [TestMethod()]
        public void VoerUitTest()
        {
            Speler eigenaar = new Speler("Speler X");
            eigenaar.InGevangenis = true;
            Assert.IsTrue(kaart.IsVerplicht());
            Assert.AreEqual(0, kaarten.Count);
            Assert.IsFalse(eigenaar.HeeftVerlaatDeGevangenisKaart());
            kaart.VoerUit(eigenaar); // Kaart komt in bezit van de speler
            Assert.IsFalse(kaart.IsVerplicht());
            Assert.AreEqual(0, kaarten.Count);
            Assert.IsTrue(eigenaar.HeeftVerlaatDeGevangenisKaart());
            kaart.VoerUit(eigenaar); // Kaart wordt gespeeld en wordt teruggelegd op de stapel.
            Assert.IsTrue(kaart.IsVerplicht());
            Assert.AreEqual(1, kaarten.Count);
            Assert.IsFalse(eigenaar.HeeftVerlaatDeGevangenisKaart());
        }

    }
}
