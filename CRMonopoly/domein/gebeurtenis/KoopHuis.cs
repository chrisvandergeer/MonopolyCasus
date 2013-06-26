using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein.velden;

namespace CRMonopoly.domein.gebeurtenis
{
    public class KoopHuis : AbstractGebeurtenis
    {
        public Straat StraatOmOpTeBouwen { get; private set; }
        
        public KoopHuis(Straat straat)
            : base(String.Format("Koop een huis voor {0}.", straat), GebeurtenisType.Bouwen)
        {
            StraatOmOpTeBouwen = straat;
            Console.WriteLine(String.Format("KoopHuis: {0}", StraatOmOpTeBouwen));
        }
        public override GebeurtenisResult VoerUit(Speler speler)
        {
            if (StraatOmOpTeBouwen.MagHuisKopen()) {
                if (StraatOmOpTeBouwen.KoopHuis())
                {
                    return GebeurtenisResult.Uitgevoerd(String.Format("Speler {0} heeft een huis geplaatst op {1}.", speler.Name, StraatOmOpTeBouwen.Naam));
                }
                return GebeurtenisResult.NietUitgevoerd(String.Format("Speler {0} wou een huis plaatsen op {1}, maar kon dat niet betalen.", speler.Name, StraatOmOpTeBouwen.Naam));
            }
            return GebeurtenisResult.NietUitgevoerd(String.Format("Speler {0} wou een huis plaatsen op {1}, maar dat mocht niet.", speler.Name, StraatOmOpTeBouwen.Naam));
        }

        public override bool IsVerplicht()
        {
            return false;
        }
    }
}
