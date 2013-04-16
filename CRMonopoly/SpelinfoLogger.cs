using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using CRMonopoly.domein;

namespace CRMonopoly
{
    public class SpelinfoLogger
    {
        public void log(string info)
        {
            Console.WriteLine(info);
        }

        public void log(object info)
        {
            Console.WriteLine(info.ToString());
        }

        public void log(IEnumerable lijst)
        {
            foreach (object o in lijst) 
            {
                log(o);
            }
        }

        public void log(params object[] info)
        {
            foreach (object o in info) 
            {
                Console.Write(o + " ");
            }
            Console.WriteLine();
        }

        public void log(Loggable loggable)
        {
        }

        public void LogStartBeurt(Speler speler)
        {
            log("");
            log("Speler", speler, "start beurt");
        }

        public void LogSpelInfo(Monopolyspel spel)
        {
            log("");
            log("Tussenstand");
            log(string.Format("{0,-15}{1,-15}{2,-15}", "Naam", "Geld", "Straten"));
            foreach (Speler speler in spel.Spelers) 
            {
                string regel = string.Format("{0,-15}{1,-15}{2,-15}", speler, speler.Geldeenheden, speler.getStraten().Count());
                log(regel);
            }
            log("");
        }
    }
}
