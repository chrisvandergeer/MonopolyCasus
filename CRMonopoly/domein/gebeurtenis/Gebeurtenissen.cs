using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace CRMonopoly.domein.gebeurtenis
{
    public class Gebeurtenissen : IEnumerable
    {
        private List<Gebeurtenis> _gebeurtenissen;

        public Gebeurtenissen()
        {
            _gebeurtenissen = new List<Gebeurtenis>();
        }

        public Gebeurtenissen GeefVerplichteGebeurtenissen()
        {
            Gebeurtenissen result = new Gebeurtenissen();
            foreach (Gebeurtenis gebeurtenis in _gebeurtenissen)
            {
                if (gebeurtenis.IsVerplicht())
                    result.Add(gebeurtenis);
            }
            return result;
        }

        public Gebeurtenissen GeefOptioneleGebeurtenissen()
        {
            Gebeurtenissen result = new Gebeurtenissen();
            foreach (Gebeurtenis gebeurtenis in _gebeurtenissen)
            {
                if (!gebeurtenis.IsVerplicht())
                    result.Add(gebeurtenis);
            }
            return result;
        }

        public void VoerUit(Speler speler)
        {
            foreach (Gebeurtenis gebeurtenis in _gebeurtenissen)
            {
                gebeurtenis.VoerUit(speler);
            }
        }

        public void Add(Gebeurtenis gebeurtenis)
        {
            _gebeurtenissen.Add(gebeurtenis);
        }

        public IEnumerator GetEnumerator()
        {
            return _gebeurtenissen.GetEnumerator();
        }
    }
}
