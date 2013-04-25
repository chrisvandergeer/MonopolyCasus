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
        public Speler HuidigeSpeler { get; set; }
        public Worpen WorpenInHuidigeBeurt { get; set; }
        public Gebeurtenissen Gebeurtenissen { get; private set; }
        public Worp Worp { get; protected set; }
        public int AantalKerenDubbelGegooid { get; private set; }

        public Beurt(Monopolyspel spel)
        {
            Spel = spel;
            Bord = spel.Bord;
            Speler speler = spel.Spelers[0];
            init(speler);
        }

        private void init(Speler speler) 
        {
            HuidigeSpeler = speler;
            AantalKerenDubbelGegooid = 0;
            WorpenInHuidigeBeurt = new Worpen();
            Gebeurtenissen = new Gebeurtenissen();
        }

        /// <summary>
        /// Alternatief voor een beurt inclusief afhandeling van gevangenisgebeurtenissen.
        /// </summary>
        public void StartBeurt()
        {
            WorpenInHuidigeBeurt.Add(Worp.GooiDobbelstenen());
            while (WorpenInHuidigeBeurt.LaatsteWorp().IsDubbelGegooid() && !Bord.DeGevangenis.IsGevangene(HuidigeSpeler)) 
            {
                Gebeurtenis gebeurtenis = HuidigeSpeler.Verplaats(WorpenInHuidigeBeurt);
                if (!gebeurtenis.VoerUit(HuidigeSpeler))
                {
                    Gebeurtenissen.Add(gebeurtenis);
                }
            }
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
            if (!HuidigeSpeler.InGevangenis)
            {
                voerGebeurtenisUit(gebeurtenis);
            }
        }

        private void voerGebeurtenisUit(Gebeurtenis gebeurtenis)
        {
            if (gebeurtenis == null)
            {
                gebeurtenis = Bord.Verplaats(HuidigeSpeler, Worp);
            }
            // Checken: Als de gebeurtenis niet uitgevoerd kan worden, wat dan??
            if (!gebeurtenis.VoerUit(HuidigeSpeler))
            {
                Console.WriteLine(String.Format("Alert!! Gebeurtenis {0} is niet uitgevoerd!!", gebeurtenis.Gebeurtenisnaam));
            }
        }

        private void laatDeSpelerUitDeGevangenis()
        {
            HuidigeSpeler.InGevangenis = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        // Chris: Deze methode doet 2 dingen: controleren naar een state en een teller ophogen. 
        private bool isErDrieKeerDubbelGegooid()
        {
            return ++AantalKerenDubbelGegooid == 3;
        }

        internal void WisselBeurt(Speler speler)
        {
            init(speler);
        }
    }
}
