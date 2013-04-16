using CRMonopoly.domein;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CRMonopolyTest
{
    
    
    /// <summary>
    ///This is a test class for BeurtTest and is intended
    ///to contain all BeurtTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BeurtTest
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
        ///A test for Beurt Constructor
        ///</summary>
        [TestMethod()]
        public void BeurtConstructorTest()
        {
            Monopolyspel spel = new Monopolyspel();
            spel.Add(new Speler("Speler"));
            Beurt target = new Beurt(spel);
            Assert.IsNotNull(target, "De Beurt zou nu geinstantieerd moeten zijn.");
        }

        /// <summary>
        ///A test for GooiDobbelstenen
        ///</summary>
        [TestMethod()]
        public void GooiDobbelstenenTest()
        {
/*
 * Check how this should be tested. The Beurt needs a initialized MonopolyBord to be able to move.
 * 
            Speler speler = new Speler("Speler");
            Beurt target = new Beurt(speler);
            string expected = "Speler gooit ";
            string actual = target.GooiDobbelstenen();
            Assert.AreEqual(expected, actual.Substring(0, expected.Length), "De log string is niet correct.");
 */       }

        /// <summary>
        ///A test for WisselBeurt
        ///</summary>
        [TestMethod()]
        public void WisselBeurtTest()
        {
            Monopolyspel spel = new Monopolyspel();
            spel.Add(new Speler("Speler_1"));
            Speler speler2 = new Speler("Speler_2");
            spel.Add(speler2);
            Beurt target = new Beurt(spel);
            target.WisselBeurt(speler2);

            Assert.AreSame(speler2, target.Speler, "De beurt had gewisseld moeten zijn.");
        }

//        /// <summary>
//        ///A test for init
//        ///</summary>
//        [TestMethod()]
//        [DeploymentItem("CRMonopoly.exe")]
//        public void initTest()
//        {
//            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
//            Beurt_Accessor target = new Beurt_Accessor(param0); // TODO: Initialize to an appropriate value
//            Speler speler = null; // TODO: Initialize to an appropriate value
//            target.init(speler);
//            Assert.Inconclusive("A method that does not return a value cannot be verified.");
//        }

    }
}
