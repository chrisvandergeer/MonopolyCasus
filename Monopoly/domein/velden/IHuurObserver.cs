﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopoly.domein.velden
{
    public interface IHuurObserver
    {
        void huurUpdate(Veld veld);
    }
}
