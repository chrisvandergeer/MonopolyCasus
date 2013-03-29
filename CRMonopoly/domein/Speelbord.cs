using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSMonopoly.domein
{
    class Speelbord
    {
        public List<Veld> Velden { get; private set; }

        public Speelbord()
        {
            Velden = new List<Veld>();
            for (int i = 0; i < 40; i++)
            {
                Velden.Add(new Veld("Veld " + i));
            }
        }


    }
}
