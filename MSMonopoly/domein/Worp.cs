using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSMonopoly.domein
{
    public class Worp
    {
        public int Dobbelsteen1 { get; set; }
        public int Dobbelsteen2 { get; set; }

        public Worp(int dobbelsteen1, int dobbelsteen2)
        {
            Dobbelsteen1 = dobbelsteen1;
            Dobbelsteen2 = dobbelsteen2;
        }

        public bool IsDubbel()
        {
            return Dobbelsteen1 == Dobbelsteen2;
        }


        public int Totaal()
        {
            return Dobbelsteen1 + Dobbelsteen2;
        }
    }
}
