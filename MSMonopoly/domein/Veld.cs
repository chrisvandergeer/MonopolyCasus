﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSMonopoly.domein
{
    public interface Veld
    {
        string Naam();
        bool IsTekoop();
        Actie BepaalActie(Beurt huidigeBeurt);
    }
}