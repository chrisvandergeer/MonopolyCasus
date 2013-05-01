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
        private Monopolybord Bord { get; set; }
        public Speler HuidigeSpeler { get; set; }
        public Gebeurtenissen Gebeurtenissen { get; private set; }

        public Beurt(Monopolyspel spel)
        {
            Bord = spel.Bord;
            Speler speler = spel.Spelers[0];
            init(speler);
        }

        private void init(Speler speler) 
        {
            speler.WorpenInHuidigeBeurt.Reset();
            HuidigeSpeler = speler;
            Gebeurtenissen = new Gebeurtenissen();
        }

        /// <summary>
        /// Alternatief voor een beurt inclusief afhandeling van gevangenisgebeurtenissen.
        /// </summary>
        public void SpeelBeurt()
        {
            do
            {
                HuidigeSpeler.GooiDobbelstenen();
                SpelinfoLogger.Log(HuidigeSpeler, "gooit", HuidigeSpeler.WorpenInHuidigeBeurt.LaatsteWorp());
                Gebeurtenis gebeurtenis = HuidigeSpeler.Verplaats();
                if (!gebeurtenis.VoerUit(HuidigeSpeler))
                {
                    Gebeurtenissen.Add(gebeurtenis);
                }
            } while (HuidigeSpeler.IsNogEenKeerGooien());
        }

        internal void WisselBeurt(Speler speler)
        {
            init(speler);
        }
    }
}
