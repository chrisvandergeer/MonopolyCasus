using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRMonopoly.domein
{
    public class Worpen
    {
        private List<Worp> WorpList { get; set; }

        public Worpen()
        {
            WorpList = new List<Worp>();
        }

        public void Add(Worp worp)
        {
            WorpList.Add(worp);
        }

        public Worp LaatsteWorp()
        {
            return WorpList.Last();
        }

        public bool Is3XDubbelGegooit()
        {
            int pos = WorpList.Count - 1;
            return WorpList.Count > 2 
                && WorpList[pos].IsDubbelGegooid() 
                && WorpList[pos - 1].IsDubbelGegooid() 
                && WorpList[pos - 2].IsDubbelGegooid();
        }

        internal void Reset()
        {
            WorpList.Clear();
        }
    }
}
