using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSMonopoly.domein
{
    public class Worp
    {
        private int Dobbelsteen1 { get; set; }
        private int Dobbelsteen2 { get; set; }

        public Worp(int d1, int d2)
        {
            Dobbelsteen1 = d1;
            Dobbelsteen2 = d2;
        }

        public int Totaal()
        {
            return Dobbelsteen1 + Dobbelsteen2;
        }

        public bool isDubbelGegooid()
        {
            return Dobbelsteen1 == Dobbelsteen2;
        }

        public override string ToString()
        {
            return Dobbelsteen1 + "+" + Dobbelsteen2 + "=" + Totaal();
        }


    }
}
