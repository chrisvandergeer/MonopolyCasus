using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSMonopoly.domein
{
    public class Speler
    {
        public string Naam          { get; set; }
        public int Geldeenheden     { get; private set; }
        public List<Straat> Straten { get; private set; }
        public Monopoly Monopolybord { get; set; }
        public Veld HuidigePositie { get; set; }

        public Speler()
        {
            Geldeenheden = 1500;
            Straten = new List<Straat>();
        }

        public void initSpeler(Monopoly monopoly)
        {
            Monopolybord = monopoly;
            HuidigePositie = monopoly.Velden.First();
        }

        public Veld Verplaats(int aantalStappen)
        {
            int huidigePositie = Monopolybord.Velden.IndexOf(HuidigePositie);
            int nieuwePositie = huidigePositie + aantalStappen;
            int totaalVelden = Monopolybord.Velden.Count;
            if (nieuwePositie > totaalVelden)
                nieuwePositie -= totaalVelden;
            HuidigePositie = Monopolybord.Velden[nieuwePositie];
            return HuidigePositie;
        }

        public Veld VerplaatsNaarStart()
        {
            HuidigePositie = Monopolybord.Velden[0];
            return HuidigePositie;
        }

        public void Betaal(int bedrag)
        {
            Geldeenheden -= bedrag;
        }

        internal void Ontvang(int bedrag)
        {
            Geldeenheden += bedrag;
        }
    }
}
