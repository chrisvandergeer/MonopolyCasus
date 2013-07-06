using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopoly.domein
{
    public class Laatste3Worpen
    {
        private List<Worp> Worpen { get; set; }

        public Laatste3Worpen()
        {
            Worpen = new List<Worp>();
        }

        public Worp LaatsteWorp()
        {
            return Worpen.Last();
        }

        public void AddWorp(Worp worp)
        {
            Worpen.Add(worp);
            if (Worpen.Count > 4)
                Worpen.RemoveAt(0);
        }

        public int AantalWorpen()
        {
            return Worpen.Count;
        }

        public bool IsDrieWorpenDubbelGegooit()
        {
            return Worpen.Count(w => w.IsDubbelGegooid()) == 3;
        }
    }
}
