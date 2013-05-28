using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRMonopoly.domein.velden
{
    public interface HuurChangeListener
    {
        void informHuurChange(int huidigeHuurprijs);
    }
}
