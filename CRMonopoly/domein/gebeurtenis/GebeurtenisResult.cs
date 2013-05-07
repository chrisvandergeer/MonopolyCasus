using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRMonopoly.domein.gebeurtenis
{
    public class GebeurtenisResult
    {
        public bool IsUitgevoerd { get; private set; }
        public string Melding  { get; private set; }

        private GebeurtenisResult() { }

        public static GebeurtenisResult Uitgevoerd(params object[] msg)
        {
            return NewGebeurtenis(true, msg);
        }

        public static GebeurtenisResult NietUitgevoerd(params object[] msg)
        {
            return NewGebeurtenis(false, msg);
        }

        private static GebeurtenisResult NewGebeurtenis(bool b, params object[] msg)
        {
            GebeurtenisResult result = new GebeurtenisResult();
            result.IsUitgevoerd = b;
            StringBuilder builder = new StringBuilder();
            foreach (object o in msg)
                builder.Append(o).Append(" ");
            result.Melding = builder.ToString();
            return result;
        }

        public void Append(string msg)
        {
            Melding = Melding + Environment.NewLine + msg;
        }

        public void LogUitgevoerdeGebeurtenis()
        {
            Console.WriteLine(Melding);
        }
    }
}
