using CRMonopoly.domein.gebeurtenis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CRMonopoly.domein;
using CRMonopoly.domein.velden;
using CRMonopoly.builders;

namespace CRMonopolyTest
{
    
    
    /// <summary>
    ///This is a test class for Ga3PlaatsenTerugTest and is intended
    ///to contain all Ga3PlaatsenTerugTest Unit Tests
    ///</summary>
    [TestClass()]
    public class Ga3PlaatsenTerugTest
    {

        /// <summary>
        ///A test for IsVerplicht
        ///</summary>
        [TestMethod()]
        public void IsVerplichtTest()
        {
            Assert.IsTrue(new Ga3PlaatsenTerug().IsVerplicht());
        }

        /// <summary>
        ///A test for VoerUit
        ///</summary>
        [TestMethod()]
        public void VoerUitTest()
        {
            Speler speler = new Speler("test");
            Monopolybord bord = new Monopolybord();
            speler.Bord = bord;
            Veld start = bord.GeefVeld(Start.VELD_NAAM);
            speler.HuidigePositie = start;
            GebeurtenisResult result = new Ga3PlaatsenTerug().VoerUit(speler);
            Assert.AreEqual(AmsterdamBuilder.LEIDSESTRAAT, speler.HuidigePositie.Naam);
        }

        [TestMethod()]
        public void GaNaarTest()
        {
            Monopolybord bord = new Monopolybord();
            Veld veld = bord.GeefVeld(AmsterdamBuilder.LEIDSESTRAAT);
            Veld nieuwVeld = bord.GeefVeld(veld, -3);
            Assert.AreEqual(RotterdamBuilder.COOLSINGEL, nieuwVeld.Naam);

            veld = bord.GeefVeld(Start.VELD_NAAM);
            nieuwVeld = bord.GeefVeld(veld, -1);
            Assert.AreEqual(AmsterdamBuilder.KALVERSTRAAT, nieuwVeld.Naam);
        }
    }
}
