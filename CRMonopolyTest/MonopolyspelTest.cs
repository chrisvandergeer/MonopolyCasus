using CRMonopoly.domein;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CRMonopolyTest
{    
    /// <summary>
    ///This is a test class for MonopolyspelTest and is intended
    ///to contain all MonopolyspelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MonopolyspelTest
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

        [TestMethod()]
        public void AantalSpelersTest()
        {
            Monopolyspel spel = new Monopolyspel();
            spel.Add(new Speler("Speler X"));
            spel.Add(new Speler("Speler Y"));
            spel.Add(new Speler("Speler Z"));
            Assert.AreEqual(3, spel.AantalSpelers());
        }

        [TestMethod()]
        public void EindeBeurtTest()
        {
            Monopolyspel spel = new Monopolyspel();
            spel.Add(new Speler("Speler X"));
            spel.Add(new Speler("Speler Y"));
            spel.Start();
            spel.EindeBeurt();
            Assert.AreEqual("Speler Y", spel.Beurt.Speler.Name);
        }

        [TestMethod()]
        [ExpectedException(typeof(ApplicationException), "Illegal state, you need minimal 2 players for a game")]
        public void StartTestTeWeinigSpelers()
        {
            Monopolyspel spel = new Monopolyspel();
            spel.Add(new Speler("Speler 1"));
            spel.Start();
        }

        [TestMethod()]
        [ExpectedException(typeof(ApplicationException), "Illegal state, you need minimal 2 players for a game")]
        public void StartTestTeVeelSpelers()
        {
            Monopolyspel spel = new Monopolyspel();
            spel.Add(new Speler("Speler 1")); spel.Add(new Speler("Speler 2"));
            spel.Add(new Speler("Speler 3")); spel.Add(new Speler("Speler 4"));
            spel.Add(new Speler("Speler 5")); spel.Add(new Speler("Speler 6"));
            spel.Add(new Speler("Speler 7")); spel.Add(new Speler("Speler 8"));
            spel.Add(new Speler("Speler 9"));
            spel.Start();
        }

        [TestMethod()]
        public void StartTestMinimaalAantalSpelers()
        {
            Monopolyspel spel = new Monopolyspel();
            spel.Add(new Speler("Speler 1"));
            spel.Add(new Speler("Speler 2"));
            Beurt beurt = spel.Start();
            Assert.AreEqual("Speler 1", beurt.Speler.Name);
        }

        [TestMethod()]
        public void StartTestMaximaalAantalSpelers()
        {
            Monopolyspel spel = new Monopolyspel();
            spel.Add(new Speler("Speler 1")); spel.Add(new Speler("Speler 2"));
            spel.Add(new Speler("Speler 3")); spel.Add(new Speler("Speler 4"));
            spel.Add(new Speler("Speler 5")); spel.Add(new Speler("Speler 6"));
            spel.Add(new Speler("Speler 7")); spel.Add(new Speler("Speler 8"));
            Beurt beurt = spel.Start();
            Assert.AreEqual("Speler 1", beurt.Speler.Name);
        }


        /// <summary>
        ///A test for Monopolyspel Constructor
        ///</summary>
        [TestMethod()]
        public void MonopolyspelConstructorTest()
        {
            Monopolyspel target = new Monopolyspel();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for AantalSpelers
        ///</summary>
        [TestMethod()]
        public void AantalSpelersTest1()
        {
            Monopolyspel target = new Monopolyspel(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.AantalSpelers();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Add
        ///</summary>
        [TestMethod()]
        public void AddTest()
        {
            Monopolyspel target = new Monopolyspel(); // TODO: Initialize to an appropriate value
            Speler player = null; // TODO: Initialize to an appropriate value
            target.Add(player);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for EindeBeurt
        ///</summary>
        [TestMethod()]
        public void EindeBeurtTest1()
        {
            Monopolyspel target = new Monopolyspel(); // TODO: Initialize to an appropriate value
            target.EindeBeurt();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ErIsEenVerliezer
        ///</summary>
        [TestMethod()]
        public void ErIsEenVerliezerTest()
        {
            Monopolyspel target = new Monopolyspel(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.ErIsEenVerliezer();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for PrintInfo
        ///</summary>
        [TestMethod()]
        public void PrintInfoTest()
        {
            Monopolyspel target = new Monopolyspel(); // TODO: Initialize to an appropriate value
            target.PrintInfo();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Start
        ///</summary>
        [TestMethod()]
        public void StartTest()
        {
            Monopolyspel target = new Monopolyspel(); // TODO: Initialize to an appropriate value
            Beurt expected = null; // TODO: Initialize to an appropriate value
            Beurt actual;
            actual = target.Start();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Beurt
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CRMonopoly.exe")]
        public void BeurtTest()
        {
            Monopolyspel_Accessor target = new Monopolyspel_Accessor(); // TODO: Initialize to an appropriate value
            Beurt expected = null; // TODO: Initialize to an appropriate value
            Beurt actual;
            target.Beurt = expected;
            actual = target.Beurt;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Bord
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CRMonopoly.exe")]
        public void BordTest()
        {
            Monopolyspel_Accessor target = new Monopolyspel_Accessor(); // TODO: Initialize to an appropriate value
            Monopolybord expected = null; // TODO: Initialize to an appropriate value
            Monopolybord actual;
            target.Bord = expected;
            actual = target.Bord;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Spelers
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CRMonopoly.exe")]
        public void SpelersTest()
        {
            Monopolyspel_Accessor target = new Monopolyspel_Accessor(); // TODO: Initialize to an appropriate value
            List<Speler> expected = null; // TODO: Initialize to an appropriate value
            List<Speler> actual;
            target.Spelers = expected;
            actual = target.Spelers;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
