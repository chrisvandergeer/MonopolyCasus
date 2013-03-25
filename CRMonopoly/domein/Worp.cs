using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRMonopoly.domein
{
    class Worp
    {
        public int Dobbelsteen1 { get; private set; }
        public int Dobbelsteen2 { get; private set; }

        public Worp(int d1, int d2)
        {
            Dobbelsteen1 = d1;
            Dobbelsteen2 = d2;
        }

        public int Totaal()
        {
            return Dobbelsteen1 + Dobbelsteen2;
        }

        public bool IsDubbelGegooid()
        {
            return Dobbelsteen1 == Dobbelsteen2;
        }
    }
}
