using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein;
using CRMonopoly.domein.gebeurtenis;
using CRMonopoly.AI;
using Microsoft.Practices.Unity;

// Usefull links: 
// Mocking framework Fakes
// http://www.richonsoftware.com/post/2012/04/05/Using-Stubs-and-Shim-to-Test-with-Microsoft-Fakes-in-Visual-Studio-11.aspx
// Mocking framework Moles (voorloper van Fakes)
//  http://research.microsoft.com/en-us/projects/moles/
// Adding Unity to Your Application
// http://msdn.microsoft.com/en-us/library/ff660927%28v=PandP.20%29.aspx

namespace CRMonopoly
{
    class Program
    {
        [Dependency]
        public MonopolyspelController Controller   { get; set; }
        //[Dependency]
        //public AbstractPlayerAI ai     { get; set; }

        private Speler HuidigeSpeler                { get; set; }
        
        static void Main(string[] args)
        {
            // Implemented Unity: 5 Singleton objects are managed by unity atm.
            // Program: This is done so Unity can inject the dependencies Controller and ai
            // MonopolyspelController: Gets injected into Program. Monopolyspel gets injected into the controller constructor.
            // Monopolyspel is used in MonopolyspelController and gets Monopolybord injected.
            // !! Sorry, not anymore !!   ArtificialPlayerIntelligence: Gets injected into Player.  

            IUnityContainer container = new UnityContainer();
            container.RegisterType<Monopolyspel>("Spel");
            container.RegisterType<MonopolyspelController>("myController");
            container.RegisterType<Monopolybord>("Bord");
            //container.RegisterType<AbstractPlayerAI>("myAI");
            container.RegisterType<Program>("program");

            container.Resolve<Program>().run();
        }

        public Program()
        {
        }
        public void run()
        {
            init();
            HuidigeSpeler = Controller.StartSpel();
            while (! HuidigeSpeler.GeeftOp)
            {
                SpeelRonde();
                //Console.ReadLine();
            }
        }

        private void init()
        {
            //Monopolyspel spel = new Monopolyspel();
            //spel.Add(new Speler("Jan"));
            //spel.Add(new Speler("Roel"));
            //spel.Add(new Speler("Chris"));
            //Controller = new MonopolyspelController();
            Controller.addSpeler("Jan", new RiskyStraatKopendePlayerAI());
            Controller.addSpeler("Roel", new RiskyStraatKopendePlayerAI());
            Controller.addSpeler("Chris", new RiskyStraatKopendePlayerAI());
        }

        public void SpeelRonde()
        {
            for (int i = 0; i < Controller.Spel.AantalSpelers(); i++)
            {                
                SpelinfoLogger.NewlineLog("Speler", HuidigeSpeler, "start de beurt vanaf ", HuidigeSpeler.HuidigePositie);
                SpeelSpelersbeurt();
                if (HuidigeSpeler.GeeftOp)
                {   // Getting out if the current player has given up.
                    break;
                }
            }
            SpelinfoLogger.LogSpelInfo(Controller.Spel);
        }

        public void SpeelSpelersbeurt()
        {
            Controller.StartBeurt(HuidigeSpeler);
            while ((!HuidigeSpeler.GeeftOp) && HuidigeSpeler.UitTeVoerenGebeurtenissen.BevatGooiDobbelstenenGebeurtenis())
            {
                HuidigeSpeler.UitTeVoerenGebeurtenissen.GeefDobbelstenenGebeurtenis().VoerUit(HuidigeSpeler);
                HuidigeSpeler.UitTeVoerenGebeurtenissen.LogUitgevoerdeGebeurtenissen();
                HuidigeSpeler.HandelWorpAf();
                // Nadat de standaard gebeurtenissen zijn afgehandeld zijn eventuele extra gebeurtenissen aan de beurt.
                HuidigeSpeler.HandelExtraZakenAfBinnenDeWorp();
            }
            if (!HuidigeSpeler.GeeftOp)
            { // We only continue if the player hasn't given up.
                HuidigeSpeler = Controller.EindeBeurt(HuidigeSpeler);
            }
        }
    }
}
