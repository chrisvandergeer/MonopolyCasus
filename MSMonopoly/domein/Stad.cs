using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSMonopoly.domein
{
    public class Stad
    {
        public String Naam             { get; set; }
        public List<Straat> Straten    { get; private set; }

        public Stad()
        {
            Straten = new List<Straat>();
        }

        public void Add(Straat straat)
        {
            Straten.Add(straat);
            straat.Stad = this;
        }
    }
}
