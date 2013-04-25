using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace CRMonopoly.domein.gebeurtenis
{
    /// <summary>
    /// Gebeurtenissen bevat alle verplichte en optionele gebeurtenissen die tijden de huidige beurt uitgevoerd moeten of kunnen worden.
    /// </summary>
    public class Gebeurtenissen : IEnumerable
    {
        private List<Gebeurtenis> _gebeurtenissen;
        private SpelinfoLogger _logger = new SpelinfoLogger();

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
                bool uitgevoerd = gebeurtenis.VoerUit(speler);
            }
        }

        public Gebeurtenissen Add(Gebeurtenis gebeurtenis)
        {
            _gebeurtenissen.Add(gebeurtenis);
            return this;
        }

        public Gebeurtenissen Add(Gebeurtenissen gebeurtenissen)
        {
            foreach (Gebeurtenis g in gebeurtenissen)
            {
                Add(g);
            }
            return this;
        }

        public IEnumerator GetEnumerator()
        {
            return _gebeurtenissen.GetEnumerator();
        }

        public bool bevatKoopStraat()
        {
            return _gebeurtenissen.Where(g => g.Gebeurtenisnaam.Equals(Gebeurtenisnamen.KOOP_STRAAT)).Count() > 0;
        }

        public Gebeurtenis GeefKoopStraatGebeurtenis()
        {
            IEnumerable<Gebeurtenis> r = _gebeurtenissen.Where(g => g.Gebeurtenisnaam.Equals(Gebeurtenisnamen.KOOP_STRAAT));
            return r.Count() > 0 ? r.First() : null;
        }
    }
}
