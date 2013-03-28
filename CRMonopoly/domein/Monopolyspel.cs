using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSMonopoly.domein
{
    class Monopolyspel
    {
        private Speelbord Speelbord { get; set; }
        private List<Speler> Spelers { get; set; }
        private Random _random = new Random();

        public Monopolyspel()
        {
            Speelbord = new Speelbord();
            Spelers = new List<Speler>();
        }

        internal void Add(Speler speler)
        {
            Spelers.Add(speler);
            speler.MonopolySpel = this;
        }

        internal void Start()
        {
            Spelers[0].Beurt = true;
        }

        internal int AantalSpelers()
        {
            return Spelers.Count;
        }

        internal Worp GooiDobbelstenen()
        {
            int dobbelsteen1 = _random.Next(1, 6);
            int dobbelsteen2 = _random.Next(1, 6);
            return new Worp(dobbelsteen1, dobbelsteen2);
        }
    }
}
