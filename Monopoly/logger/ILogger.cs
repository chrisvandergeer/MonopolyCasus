using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoly.domein;

namespace Monopoly.logger
{
    public interface ILogger
    {
        void initialize();
        void finalize();

        void rondeInfo(int p);
        void spelerTussenstand(Speler s);
        void spelerBeurt(string p);
        void logGebeurtenis(string p);
    }
}
