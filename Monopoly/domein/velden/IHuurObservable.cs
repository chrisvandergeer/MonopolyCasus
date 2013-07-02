using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopoly.domein.velden
{
    public interface IHuurObservable
    {
        void addObserver(IHuurObserver observer);
    }
}
