using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRMonopoly.domein.gebeurtenis.creator
{
    public class SpeelVerlaatDeGevangenisGebeurteniscreator : GebeurtenisCreator
    {
        public bool IsGebeurtenisVoorSpeler(Speler speler)
        {
            return speler.InGevangenis && speler.HeeftVerlaatDeGevangeniskaart();
        }

        public Gebeurtenis MaakGebeurtenis(Speler speler)
        {
            return speler.GeefVerlaatDeGevangeniskaart();
        }
    }
}
