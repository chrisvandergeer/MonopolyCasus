using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRMonopoly.domein.gebeurtenis.creator
{
    public class SpeelVerlaatDeGevangenisGebeurtenisCreator : GebeurtenisCreator
    {
        public bool IsGebeurtenisVoorSpeler(Speler speler)
        {
            return speler.InGevangenis && speler.HeeftVerlaatDeGevangenisKaart();
        }

        public Gebeurtenis MaakGebeurtenis(Speler speler)
        {
            return speler.GeefVerlaatDeGevangeniskaart();
        }
    }
}
