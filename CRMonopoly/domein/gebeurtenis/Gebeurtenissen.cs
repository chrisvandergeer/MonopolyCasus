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
        private List<GebeurtenisResult> _gebeurtenissenResult;

        public Gebeurtenissen()
        {
            _gebeurtenissen = new List<Gebeurtenis>();
            _gebeurtenissenResult = new List<GebeurtenisResult>();
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
                Add(gebeurtenis.VoerUit(speler));
            }
        }

        public int Count()
        {
            return _gebeurtenissen.Count();
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

        public bool bevatGooiDobbelstenenGebeurtenis()
        {
            return bevatGebeurtenis(GooiDobbelstenenGebeurtenis.NAAM);
        }

        public Gebeurtenis GeefDobbelstenenGebeurtenis()
        {
            return GeefGebeurtenis(GooiDobbelstenenGebeurtenis.NAAM);
        }

        public bool bevatGebeurtenis(string gebeurtenisnaam)
        {
            return _gebeurtenissen.Where(g => g.Gebeurtenisnaam.Equals(gebeurtenisnaam)).Count() > 0;
        }

        public Gebeurtenis GeefGebeurtenis(string gebeurtenisnaam)
        {
            IEnumerable<Gebeurtenis> r = _gebeurtenissen.Where(g => g.Gebeurtenisnaam.Equals(gebeurtenisnaam));
            return r.Count() > 0 ? r.First() : null;
        }

        public void Remove(Gebeurtenis gebeurtenis)
        {
            _gebeurtenissen.Remove(gebeurtenis);
        }

        public bool BevatVerplichteGebeurtenis()
        {
            return _gebeurtenissen.Count(g => g.IsVerplicht()) > 0;
        }

        internal void Add(GebeurtenisResult result)
        {
            _gebeurtenissenResult.Add(result);
        }

        internal void LogUitgevoerdeGebeurtenissen()
        {
            foreach (GebeurtenisResult result in _gebeurtenissenResult)
            {
                result.LogUitgevoerdeGebeurtenis();
            }
            _gebeurtenissenResult.Clear();
        }
    }
}
