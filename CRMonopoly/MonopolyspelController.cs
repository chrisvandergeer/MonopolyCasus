using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein.gebeurtenis;
using System.Diagnostics;

namespace CRMonopoly.domein
{
    public class MonopolyspelController
    {
        public Monopolyspel Spel { get; private set; }

        public MonopolyspelController(Monopolyspel spel)
        {
            Spel = spel;
        }

        /// <summary>
        /// Alternatief voor een beurt inclusief afhandeling van gevangenisgebeurtenissen.
        /// </summary>
        [Obsolete]
        public void SpeelBeurt(Speler speler)
        {
            do
            {
                speler.GooiDobbelstenen();
                SpelinfoLogger.Log(speler, "gooit", speler.WorpenInHuidigeBeurt.LaatsteWorp());
                Gebeurtenis gebeurtenis = speler.Verplaats();
                if (!gebeurtenis.VoerUit(speler))
                {
                    speler.UitTeVoerenGebeurtenissen.Add(gebeurtenis);
                }
            } while (speler.IsNogEenKeerGooien());
        }

        public Speler StartSpel()
        {
            int aantalSpelers = Spel.Spelers.Count();
            if (aantalSpelers < 2 || aantalSpelers > 8)
                throw new ApplicationException("Illegal state, you need minimal 2 and maximal 8 players for a game");
            return  Spel.Spelers[0];
        }

        public Gebeurtenissen StartBeurt(Speler speler)
        {
            return speler.BepaalStartgebeurtenissen();
        }
        
        public Speler EindeBeurt(Speler speler)
        {
            speler.WorpenInHuidigeBeurt.Reset();
            int pos = Spel.Spelers.IndexOf(speler);
            int posNieuweSpeler = pos < Spel.Spelers.Count - 1 ? pos + 1 : 0;
            Speler nieuweSpeler = Spel.Spelers[posNieuweSpeler];
            return nieuweSpeler;
        }
    }
}
