using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein.gebeurtenis;
using System.Diagnostics;

namespace CRMonopoly.domein
{
    public class Beurt
    {
        private Monopolyspel Spel { get; set; }
        private Monopolybord Bord { get; set; }
        public Speler Speler { get; set; }
        //private List<Worp> Worpen { get; set; }
        public Gebeurtenissen Gebeurtenissen { get; private set; }
        public Worp Worp { get; protected set; }
        private int aantalKerenDubbelGegooid = 0;

        public Beurt(Monopolyspel spel)
        {
            Spel = spel;
            Bord = spel.Bord;
            Speler speler = spel.Spelers[0];
            init(speler);
        }

        private void init(Speler speler) 
        {
            Speler = speler;
            aantalKerenDubbelGegooid = 0;
            //Worpen = new List<Worp>();
            Gebeurtenissen = new Gebeurtenissen();
        }

        public virtual void GooiDobbelstenen()
        {
            Gebeurtenis gebeurtenis = null;
            Worp = Worp.GooiDobbelstenen();
            if (Worp.IsDubbelGegooid()) {
                if (isErDrieKeerDubbelGegooid())
                {
                    gebeurtenis = new GaNaarGevangenis();
                }
                else
                {
                    laatDeSpelerUitDeGevangenis();
                }
            }
            // Als de speler niet in de gevangenis zit.
            if (!Speler.InGevangenis)
            {
                voerGebeurtenisUit(gebeurtenis);
            }
        }

        private void voerGebeurtenisUit(Gebeurtenis gebeurtenis)
        {
            if (gebeurtenis == null)
            {
                gebeurtenis = Bord.Verplaats(Speler, Worp);
            }
            // Checken: Als de gebeurtenis niet uitgevoerd kan worden, wat dan??
            if (!gebeurtenis.VoerUit(Speler))
            {
                Console.WriteLine(String.Format("Alert!! Gebeurtenis {0} is niet uitgevoerd!!", gebeurtenis.Gebeurtenisnaam));
            }
        }

        private void laatDeSpelerUitDeGevangenis()
        {
            Speler.InGevangenis = false;
        }

        private bool isErDrieKeerDubbelGegooid()
        {
            return ++aantalKerenDubbelGegooid == 3;
        }

        internal void WisselBeurt(Speler speler)
        {
            init(speler);
        }
    }
}
