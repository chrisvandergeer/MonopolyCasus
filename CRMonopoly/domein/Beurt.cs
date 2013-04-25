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
        private static SpelinfoLogger Logger = new SpelinfoLogger();

        private Monopolybord Bord { get; set; }
        public Speler HuidigeSpeler { get; set; }
        public Worpen WorpenInHuidigeBeurt { get; set; }
        public Gebeurtenissen Gebeurtenissen { get; private set; }

        public Beurt(Monopolyspel spel)
        {
            Bord = spel.Bord;
            Speler speler = spel.Spelers[0];
            init(speler);
        }

        private void init(Speler speler) 
        {
            HuidigeSpeler = speler;
            WorpenInHuidigeBeurt = new Worpen();
            Gebeurtenissen = new Gebeurtenissen();
        }

        /// <summary>
        /// Alternatief voor een beurt inclusief afhandeling van gevangenisgebeurtenissen.
        /// </summary>
        public void StartBeurt()
        {
            do
            {
                WorpenInHuidigeBeurt.Add(Worp.GooiDobbelstenen());
                Logger.log(HuidigeSpeler, "gooit", WorpenInHuidigeBeurt.LaatsteWorp());
                Gebeurtenis gebeurtenis = HuidigeSpeler.Verplaats(WorpenInHuidigeBeurt);
                if (!gebeurtenis.VoerUit(HuidigeSpeler))
                {
                    Gebeurtenissen.Add(gebeurtenis);
                }
            } while (WorpenInHuidigeBeurt.LaatsteWorp().IsDubbelGegooid() && !Bord.DeGevangenis.IsGevangene(HuidigeSpeler));
        }

        internal void WisselBeurt(Speler speler)
        {
            init(speler);
        }
    }
}
