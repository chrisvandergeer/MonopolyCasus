using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using MSMonopoly.domein;

namespace MSMonopoly
{
    class SpelinfoLogger
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
                Console.Write(o);
            }
            Console.WriteLine();
        }

        public void log(Loggable loggable)
        {
        }
    }
}
