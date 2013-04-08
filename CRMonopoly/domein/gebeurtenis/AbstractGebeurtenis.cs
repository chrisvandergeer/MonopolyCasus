using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRMonopoly.domein.gebeurtenis
{
    public abstract class AbstractGebeurtenis : Gebeurtenis
    {

        public override bool Equals(object obj)
        {
            if (obj.GetType().Equals(GetType())) {
                Gebeurtenis g = (Gebeurtenis) obj;
                return g.Gebeurtenisnaam().Equals(Gebeurtenisnaam());
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Gebeurtenisnaam().GetHashCode();
        }

        abstract public bool VoerUit(Speler speler);

        abstract public bool IsVerplicht();

        abstract public string Gebeurtenisnaam();
    }
}
