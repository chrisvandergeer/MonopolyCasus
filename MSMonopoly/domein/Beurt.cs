using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSMonopoly.domein
{
    public class Beurt
    {
        private List<Actie> _actieMogelijkheden = new List<Actie>();
        public List<Worp> Worpen        { get; private set;         }
        public Speler HuidigeSpeler     { get; set;                 }
        private StringBuilder Log       { get; set;                 }

        public Beurt(Speler speler)
        {
            HuidigeSpeler = speler;
            Worpen = new List<Worp>();
            Log = new StringBuilder();
        }

        public void Gooi()
        {
            Random random = new Random();
            int dobbelsteen1 = random.Next(1, 6);
            int dobbelsteen2 = random.Next(1, 6);
            Worpen.Add(new Worp(dobbelsteen1, dobbelsteen2));
            WriteLog(HuidigeSpeler.Naam + " gooit " + LaatsteWorp().Totaal() + "(" + dobbelsteen1 + "+" + dobbelsteen2 + ")");
        }

        public void Verplaats() {
            Veld nieuwePositie = HuidigeSpeler.Verplaats(LaatsteWorp().Totaal());
            WriteLog("Nieuwe positie wordt " + nieuwePositie.Naam());
        }

        public bool Is3KeerDubbel()
        {
            return Worpen.Count == 3 && LaatsteWorp().IsDubbel();
        }

        public Worp LaatsteWorp()
        {
            return Worpen.Last();
        }

        public void WriteLog(string bericht)
        {
            Log.AppendLine(bericht);
        }

        public string ReadLog()
        {
            string result = Log.ToString();
            Log.Clear();
            return result;
        }

        public void BepaalActie()
        {
            Actie actie = HuidigeSpeler.HuidigePositie.BepaalActie(this);
        }
    }
}
