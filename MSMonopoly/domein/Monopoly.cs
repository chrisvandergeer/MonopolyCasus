using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSMonopoly.domein
{
    public class Monopoly
    {
        public List<Speler> Spelers { get; private set; }
        public List<Veld> Velden    { get; private set; }
        public Beurt HuidigeBeurt   { get; private set; }

        public Monopoly()
        {
            Spelers = new List<Speler>();
            Velden = new List<Veld>();
        }

        public void Add(Veld veld)
        {
            Velden.Add(veld);
        }

        public void Add(Stad stad)
        {
            foreach (Veld straat in stad.Straten) {
                Add(straat);
            }
        }

        public void Add(Speler speler)
        {
            Spelers.Add(speler);
            speler.initSpeler(this);
        }

        public Beurt Start()
        {
            HuidigeBeurt = new Beurt(Spelers.First());
            return StartBeurt();
        }

        private Beurt StartBeurt()
        {
            Speler huidigeSpeler = HuidigeBeurt.HuidigeSpeler;
            HuidigeBeurt.WriteLog(huidigeSpeler.Naam + "is aan de beurt");
            return HuidigeBeurt;
        }
    }
}
