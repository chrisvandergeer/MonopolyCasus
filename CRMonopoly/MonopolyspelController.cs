using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein.gebeurtenis;
using System.Diagnostics;
using CRMonopoly;
using Microsoft.Practices.Unity;

namespace CRMonopoly.domein
{
    public class MonopolyspelController
    {
        public Monopolyspel Spel { get; private set; }

        [InjectionConstructor]
        public MonopolyspelController(Monopolyspel spel)
        {
            Spel = spel;
        }

        public Speler StartSpel()
        {
            int aantalSpelers = Spel.Spelers.Count();
            if (aantalSpelers < 2 || aantalSpelers > 8)
                throw new ApplicationException("Illegal state, you need minimal 2 and maximal 8 players for a game");
            return  Spel.Spelers[0];
        }

        public void StartBeurt(Speler speler)
        {
            Gebeurtenissen gebeurtenissen = speler.BepaalStartgebeurtenissen();
            speler.UitTeVoerenGebeurtenissen = gebeurtenissen;
        }
        
        public Speler EindeBeurt(Speler speler)
        {
            speler.WorpenInHuidigeBeurt.Reset();
            int pos = Spel.Spelers.IndexOf(speler);
            int posNieuweSpeler = pos < Spel.Spelers.Count - 1 ? pos + 1 : 0;
            Speler nieuweSpeler = Spel.Spelers[posNieuweSpeler];
            return nieuweSpeler;
        }

        internal void addSpeler(string spelerNaam)
        {
            Spel.Add(new Speler(spelerNaam));
        }
    }
}
