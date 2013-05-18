using CRMonopoly.domein;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CRMonopoly.domein.velden;
using System.Collections.Generic;

namespace CRMonopolyTest
{
    
    
    /// <summary>
    ///This is a test class for BelastingVeldenTest and is intended
    ///to contain all BelastingVeldenTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BelastingVeldenTest
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
        ///A test for BelastingVelden Constructor
        ///</summary>
        [TestMethod()]
        public void BelastingVeldenConstructorTest()
        {
            BelastingVelden target = new BelastingVelden();
            Assert.IsNotNull(target, "BelastingVelden instance kan niet null zijn.");
        }

        /// <summary>
        ///A test for Add
        ///</summary>
        [TestMethod()]
        public void AddTest()
        {
            BelastingVelden target = new BelastingVelden();
            addBelastingVeldToBelastingVelden(target, "MonopolyBelasting", 222);
            Assert.IsTrue(target.AlleBelastingVelden.Count == 1, 
                String.Format("BelastingVeld had aan de lijst toegevoegd moeten zijn, maar de lijst bevat nu {0} elementen.", target.AlleBelastingVelden.Count));
        }

        /// <summary>
        ///A test for AlleBelastingVelden
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CRMonopoly.exe")]
        public void AlleBelastingVeldenTest()
        {
            BelastingVelden target = new BelastingVelden();
            List<BelastingVeld> actual = target.AlleBelastingVelden;
            Assert.IsNotNull(actual, "De lijst met belastingvelden mag niet null zijn.");
            BelastingVeld belastingVeld = new BelastingVeld("MonopolyBelasting01", 123);
            Assert.IsTrue(target.AlleBelastingVelden.Count == 0,
                String.Format("De lijst met belastingvelden moet leeg zijn, maar de lijst bevat nu {0} elementen.", target.AlleBelastingVelden.Count));
            target.Add(belastingVeld);
            Assert.IsTrue(target.AlleBelastingVelden.Count == 1,
                String.Format("BelastingVeld had aan de lijst toegevoegd moeten zijn, maar de lijst bevat nu {0} elementen.", target.AlleBelastingVelden.Count));
            addBelastingVeldToBelastingVelden(target, "MonopolyBelasting02", 234);
            Assert.IsTrue(target.AlleBelastingVelden.Count == 2,
                String.Format("Twee belastingVeld hadden aan de lijst toegevoegd moeten zijn, maar de lijst bevat nu {0} elementen.", target.AlleBelastingVelden.Count));
        }

        private static void addBelastingVeldToBelastingVelden(BelastingVelden target, String id, int bedrag)
        {
            BelastingVeld belastingVeld = new BelastingVeld(id, bedrag);
            target.Add(belastingVeld);
        }

        /// <summary>
        ///A test for getBelastingveldByName
        ///</summary>
        [TestMethod()]
        public void getBelastingveldByNameTest()
        {
            BelastingVelden target = new BelastingVelden();
            addBelastingVeldToBelastingVelden(target, "MonopolyBelasting_A", 987);
            addBelastingVeldToBelastingVelden(target, "MonopolyBelasting_B", 876);
            addBelastingVeldToBelastingVelden(target, "MonopolyBelasting_C", 765);

            Assert.IsTrue(target.AlleBelastingVelden.Count == 3,
                String.Format("Drie belastingVeld hadden aan de lijst toegevoegd moeten zijn, maar de lijst bevat nu {0} elementen.", target.AlleBelastingVelden.Count));

            BelastingVeld belastingVeld = target.getBelastingveldByName("VeldNietTeVinden");
            Assert.IsNull(belastingVeld, "getBelastingveldByName() had geen resultaat mogen opleveren, maar er werd wel een BelastingVeld gevonden.");

            belastingVeld = target.getBelastingveldByName("MonopolyBelasting_B");
            Assert.IsNotNull(belastingVeld,
                String.Format("getBelastingveldByName() had een resultaat mogen opleveren, maar het BelastingVeld '{0}' werd niet gevonden.", "MonopolyBelasting_B"));
            Assert.AreEqual("MonopolyBelasting_B", belastingVeld.Naam,
                String.Format("getBelastingveldByName() heeft niet het verwachte resultaat opgeleverd. (Exp: '{0}'; Act: {1}).", "MonopolyBelasting_B", belastingVeld.Naam));
        }
    }
}
