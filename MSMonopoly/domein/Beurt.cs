﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MSMonopoly.domein.gebeurtenis;

namespace MSMonopoly.domein
{
    public class Beurt
    {
        public Speler Speler { get; set; }
        //private List<Worp> Worpen { get; set; }
        //public Gebeurtenissen UitTeVoerenGebeurtenissen { get; private set; }

        public Beurt(Speler speler)
        {
            init(speler);
        }

        private void init(Speler speler) 
        {
            Speler = speler;
            //Worpen = new List<Worp>();
            //UitTeVoerenGebeurtenissen = new Gebeurtenissen();
        }

        public string GooiDobbelstenen()
        {
            Worp worp = Worp.GooiDobbelstenen();
            Gebeurtenis gebeurtenis = Speler.Verplaats(worp);
            gebeurtenis.VoerUit();
            return string.Format("{0} gooit {1} en {2}", Speler.Name, worp, gebeurtenis.ToString());
        }

        internal void WisselBeurt(Speler speler)
        {
            init(speler);
        }
    }
}
