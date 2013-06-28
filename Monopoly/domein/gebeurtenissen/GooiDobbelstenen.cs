using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopoly.domein.gebeurtenissen
{
    public class GooiDobbelstenen : Gebeurtenis
    {
        private List<Worp> WorpenInBeurt { get; set; }

        public GooiDobbelstenen() 
            : base(Gebeurtenisnamen.GOOI_DOBBELSTENEN) 
        {
            WorpenInBeurt = new List<Worp>();
        }

        public override bool IsVerplicht()
        {
            return WorpenInBeurt.Count == 0 || LaatsteWorp().IsDubbelGegooid();
        }

        public override bool IsUitvoerbaar(Speler speler)
        {
            return WorpenInBeurt.Count(worp => !worp.IsDubbelGegooid()) == 0;
        }

        public override void Voeruit(Speler speler)
        {
            WorpenInBeurt.Add(Worp.GooiDobbelstenen());
            speler.BeurtGebeurtenissen.VoegResultToe(Gebeurtenisresult.Create(speler, "heeft", LaatsteWorp(), "gegooit"));
            speler.Verplaats(LaatsteWorp());
        }

        public Worp LaatsteWorp()
        {
            return WorpenInBeurt.Last();
        }
    }
}
