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
        private List<Gebeurtenis> UitTeVoerenGebeurtenissen { get; set; }
        private List<Gebeurtenis> UitgevoerdeGebeurtenissen { get; set; }

        public Beurt(Speler speler)
        {
            Speler = speler;
            Worpen = new List<Worp>();
            Dobbelstenen = new Dobbelsteen();
            UitTeVoerenGebeurtenissen = new List<Gebeurtenis>();
            UitgevoerdeGebeurtenissen = new List<Gebeurtenis>();
        }

        public void GooiDobbelstenen()
        {
            Worp worp = Dobbelstenen.Gooi2Dobbelstenen();
            Worpen.Add(worp);
            Veld veld = Speler.Verplaats(worp);
            UitTeVoerenGebeurtenissen.Add(veld.bepaalGebeurtenis(Speler));
        }

        public List<Gebeurtenis> VerplichteGebeurtenissen()
        {
            List<Gebeurtenis> result = new List<Gebeurtenis>();
            foreach (Gebeurtenis g in UitTeVoerenGebeurtenissen)
            {
                if (g.isVerplicht())
                {
                    result.Add(g);
                }
            }
            return result;
        }

        public bool VoerVerplichteGebeurtenisUit()
        {
            foreach (Gebeurtenis g in VerplichteGebeurtenissen())
            {
                g.voerUit();
            }
            return VerplichteGebeurtenissen().Count == 0;
        }

        public Worp GetLaatsteWorp()
        {
            return Worpen.Last();
        }

    }
}
