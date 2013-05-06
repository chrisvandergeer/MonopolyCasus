using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRMonopoly.domein.gebeurtenis.creator
{
    interface GebeurtenisCreator
    {
        bool IsGebeurtenisVoorSpeler(Speler speler);

        Gebeurtenis MaakGebeurtenis(Speler speler);
    }
}
