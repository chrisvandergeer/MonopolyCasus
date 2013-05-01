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
        private SpelinfoLogger() { }

        internal static void Log(string info)
        {
            Console.WriteLine(info);
        }

        internal static void Log(params object[] info)
        {
            foreach (object o in info) 
            {
                Console.Write(o + " ");
            }
            Console.WriteLine();
        }

        internal static void NewlineLog(params object[] info)
        {
            Log("");
            Log(info);
        }

        internal static void LogSpelInfo(Monopolyspel spel)
        {
            Log("");
            Log("Tussenstand");
            Log(string.Format("{0,-15}{1,-15}{2,-15}", "Naam", "Geld", "Straten"));
            foreach (Speler speler in spel.Spelers) 
            {
                string regel = string.Format("{0,-15}{1,-15}{2,-15}", speler, speler.Geldeenheden, speler.getStraten().Count());
                Log(regel);
            }
            Log("");
        }

    }
}
