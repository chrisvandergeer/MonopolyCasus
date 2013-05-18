using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRMonopoly.domein.gebeurtenis.creator
{
    class GooiDobbelstenenGebeurtenisCreator : GebeurtenisCreator
    {
        public bool IsGebeurtenisVoorSpeler(Speler speler)
        {
            return true;
        }

        public Gebeurtenis MaakGebeurtenis(Speler speler)
        {
            return new GooiDobbelstenenGebeurtenis();
        }
    }
}
