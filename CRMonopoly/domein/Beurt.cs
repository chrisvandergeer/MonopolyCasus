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
        public Monopolyspel Spel { get; private set; }
        public Speler HuidigeSpeler { get; set; }
        public Gebeurtenissen Gebeurtenissen { get; private set; }

        public Beurt(Monopolyspel spel)
        {
            Spel = spel;
            Speler speler = spel.Spelers[0];
            init(speler);
        }

        private void init(Speler speler) 
        {
            speler.WorpenInHuidigeBeurt.Reset();
            HuidigeSpeler = speler;
            Gebeurtenissen = HuidigeSpeler.BepaalStartgebeurtenissen();
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

        public void EindeBeurt()
        {
            int pos = Spel.Spelers.IndexOf(HuidigeSpeler);
            int posNieuweSpeler = pos < Spel.Spelers.Count - 1 ? pos + 1 : 0;
            init(Spel.Spelers[posNieuweSpeler]);
        }

        internal void WisselBeurt(Speler speler)
        {
            
        }
    }
}
