﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRMonopoly.domein.gebeurtenis
{
    class GooiDobbelstenenGebeurtenis : AbstractGebeurtenis
    {
        public GooiDobbelstenenGebeurtenis() : base(Gebeurtenisnamen.GOOI_DOBBELSTENEN, GebeurtenisType.FINALLY) { }

        public override GebeurtenisResult VoerUit(Speler speler)
        {
            speler.UitTeVoerenGebeurtenissen.Remove(this);
            if (speler.GooiDobbelstenen())
                speler.UitTeVoerenGebeurtenissen.Add(new GooiDobbelstenenGebeurtenis());
            // RdW: Testing: Gebeurtenissen worden nu opgeslagen in de Speler. Die heeft een UitTeVoerenGebeurtenissen.
            speler.Verplaats();

            GebeurtenisResult result = GebeurtenisResult.Uitgevoerd(speler, "gooit", speler.WorpenInHuidigeBeurt.LaatsteWorp(), "en belandt op", speler.HuidigePositie);
            speler.UitTeVoerenGebeurtenissen.Add(result);

            // RdW: Testing: Alle gebeurtenissen laten verwerken door de AI
            //if (gebeurtenis.IsVerplicht())
            //{
            //    GebeurtenisResult veldGebeurtenisResult = gebeurtenis.VoerUit(speler);
            //    if (!veldGebeurtenisResult.IsUitgevoerd)
            //        speler.UitTeVoerenGebeurtenissen.Add(gebeurtenis);
            //    else
            //        speler.UitTeVoerenGebeurtenissen.Add(veldGebeurtenisResult);
            //}
            //else
            //{
            //    speler.UitTeVoerenGebeurtenissen.Add(gebeurtenis);
            //}
            return null;
        }

        public override bool IsVerplicht()
        {
            return true;
        }
    }
}
