using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSMonopoly.domein
{
    class Speler
    {
        public string Naam { get; set; }
        private bool _beurt;
        public bool Beurt
        {
            get { return _beurt; }

            set
            {
                if (value)
                {
                    _beurt = true;
                    Worp worp = MonopolySpel.GooiDobbelstenen();
                }
                else
                {
                    _beurt = false;
                }
            }

        }

        public Speler(string naam)
        {
            Naam = naam;
            Beurt = false;
        }



        public Monopolyspel MonopolySpel { get; set; }
    }
}
