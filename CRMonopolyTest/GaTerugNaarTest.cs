using CRMonopoly.domein.gebeurtenis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CRMonopoly.domein;
using CRMonopoly.domein.velden;
using CRMonopoly.builders;

namespace CRMonopolyTest
{
    
    
    /// <summary>
    ///This is a test class for GaTerugNaarTest and is intended
    ///to contain all GaTerugNaarTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GaTerugNaarTest
    {

        /// <summary>
        ///A test for IsVerplicht
        ///</summary>
        [TestMethod()]
        public void IsVerplichtTest()
        {
            Assert.IsTrue(new GaTerugNaar(new Start()).IsVerplicht());
        }

        /// <summary>
        ///A test for VoerUit
        ///</summary>
        [TestMethod()]
        public void VoerUitTest()
        {
            Monopolybord bord = new Monopolybord();
            Speler speler = new Speler("Chris");
            speler.Bord = bord;
            speler.HuidigePositie = bord.GeefVeld(AmsterdamBuilder.KALVERSTRAAT);
            Straat straat = (Straat) bord.GeefVeld(ArnhemBuilder.STEENSTRAAT);
            straat.Eigenaar = new Speler("Roel");
            GebeurtenisResult result = new GaTerugNaar(straat).VoerUit(speler);
            StringAssert.Contains(result.Melding, "ga terug naar Steenstraat");
            StringAssert.Contains(result.Melding, "Chris betaald 6 huur aan Roel");
        }
    }
}
