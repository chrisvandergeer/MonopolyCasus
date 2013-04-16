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
            //Worpen = new List<Worp>();
            Gebeurtenissen = new Gebeurtenissen();
        }

        public void GooiDobbelstenen()
        {
            Worp worp = Worp.GooiDobbelstenen();
            Gebeurtenis gebeurtenis = Bord.Verplaats(Speler, worp);
            gebeurtenis.VoerUit(Speler);
        }

        internal void WisselBeurt(Speler speler)
        {
            init(speler);
        }
    }
}
