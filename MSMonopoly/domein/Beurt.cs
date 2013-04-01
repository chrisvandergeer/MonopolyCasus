using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MSMonopoly.domein.gebeurtenis;

namespace MSMonopoly.domein
{
    public class Beurt
    {
        public Speler Speler { get; set; }
        private Dobbelsteen Dobbelstenen { get; set; }
        private List<Worp> Worpen { get; set; }
        public Gebeurtenissen UitTeVoerenGebeurtenissen { get; private set; }

        public Beurt(Speler speler)
        {
            Speler = speler;
            Worpen = new List<Worp>();
            Dobbelstenen = new Dobbelsteen();
            UitTeVoerenGebeurtenissen = new Gebeurtenissen();
        }

        public void GooiDobbelstenen()
        {
            Worp worp = Dobbelstenen.Gooi2Dobbelstenen();
            Worpen.Add(worp);
            Veld veld = Speler.Verplaats(worp);
            UitTeVoerenGebeurtenissen.Add(veld.bepaalGebeurtenis(Speler));
        }

        public Worp GetLaatsteWorp()
        {
            return Worpen.Last();
        }

    }
}
