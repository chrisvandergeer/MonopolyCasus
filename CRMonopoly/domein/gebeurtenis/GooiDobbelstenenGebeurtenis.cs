using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRMonopoly.domein.gebeurtenis
{
    class GooiDobbelstenenGebeurtenis : AbstractGebeurtenis
    {
        public static string NAAM = "Gooi dobbelstenen";

        public GooiDobbelstenenGebeurtenis() : base(NAAM) { }

        public override bool VoerUit(Speler speler)
        {
            speler.UitTeVoerenGebeurtenissen.Remove(this);
            if (speler.GooiDobbelstenen())
                speler.UitTeVoerenGebeurtenissen.Add(new GooiDobbelstenenGebeurtenis());
            SpelinfoLogger.Log(speler, "gooit", speler.WorpenInHuidigeBeurt.LaatsteWorp());
            Gebeurtenis gebeurtenis = speler.Verplaats();
            if (!gebeurtenis.IsVerplicht() || !gebeurtenis.VoerUit(speler))
            {
                speler.UitTeVoerenGebeurtenissen.Add(gebeurtenis);
                return false;
            }
            return true;
        }

        public override bool IsVerplicht()
        {
            return true;
        }
    }
}
