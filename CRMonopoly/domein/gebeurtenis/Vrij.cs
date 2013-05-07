using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRMonopoly.domein.gebeurtenis
{
    class Vrij : AbstractGebeurtenis
    {

        public Vrij() : base(Gebeurtenisnamen.VRIJ) { }

        public override GebeurtenisResult VoerUit(Speler speler)
        {
            return GebeurtenisResult.Uitgevoerd("Even bijkomen op 'Vrij parkeren'"); 
        }

        public override bool IsVerplicht()
        {
            return true;
        }

        public override string ToString()
        {
            return Gebeurtenisnaam;
        }
    }
}
