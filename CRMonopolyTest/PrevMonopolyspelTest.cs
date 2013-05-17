
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CRMonopoly.domein;

namespace CRMonopolyTest
{
    
    
    /// <summary>
    ///This is a test class for MonopolyspelTest and is intended
    ///to contain all MonopolyspelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PrevMonopolyspelTest
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
        ///A test for Monopolyspel Constructor
        ///</summary>
        [TestMethod()]
        public void MonopolyspelConstructorTest()
        {
            Monopolyspel target = new Monopolyspel();
            Assert.IsNotNull(target, "never should happen"); 
        }

        [TestMethod()]
        public void AddSpelerTest()
        {
            Monopolyspel spel = new Monopolyspel();
            // Changes after Unity implementation.
            spel.Bord = new Monopolybord();

            spel.Add(new Speler("Roel"));
            Assert.IsTrue(1 == spel.AantalSpelers());
            spel.Add(new Speler("Chris"));
            Assert.IsTrue(2 == spel.AantalSpelers());
        }

        [TestMethod()]
        public void StartSpelTest()
        {
            //Monopolyspel spel = new Monopolyspel();
            //Speler roel = new Speler("Roel");
            //spel.Add(roel);
            //spel.Add(new Speler("Chris"));
            //Assert.IsFalse(roel.Beurt);
            //spel.Start();
            //Assert.IsTrue(roel.Beurt);
        }
    }
}
