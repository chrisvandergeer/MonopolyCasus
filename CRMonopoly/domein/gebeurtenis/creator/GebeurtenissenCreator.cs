using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRMonopoly.domein.gebeurtenis.creator
{
    public class GebeurtenissenCreator
    {
        private static GebeurtenissenCreator _instance;
        private List<GebeurtenisCreator> _gebeurtenissenCreatorList;

        private GebeurtenissenCreator()
        {
            _gebeurtenissenCreatorList = new List<GebeurtenisCreator>();
            _gebeurtenissenCreatorList.Add(new GooiDobbelstenenGebeurteniscreator());
            _gebeurtenissenCreatorList.Add(new SpeelVerlaatDeGevangenisGebeurteniscreator());
        }

        public static GebeurtenissenCreator Instance()
        {
            if (_instance == null)
            {
                GebeurtenissenCreator creator = new GebeurtenissenCreator();
                _instance = creator;
                return creator;
            }
            return _instance;
        }

        public Gebeurtenissen createGebeurtenissen(Speler speler)
        {
            Gebeurtenissen gebeurtenissen = new Gebeurtenissen();
            foreach (GebeurtenisCreator creator in _gebeurtenissenCreatorList)
            {
                if (creator.IsGebeurtenisVoorSpeler(speler))
                    gebeurtenissen.Add(creator.MaakGebeurtenis(speler));
            }
            return gebeurtenissen;
        }
    }
}
