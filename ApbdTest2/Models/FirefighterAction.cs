﻿using System;
using System.Collections.Generic;

#nullable disable

namespace ApbdTest2.Models
{
    public partial class FirefighterAction
    {
        public int IdFirefighter { get; set; }
        public int IdAction { get; set; }

        public virtual Action IdActionNavigation { get; set; }
        public virtual Firefighter IdFirefighterNavigation { get; set; }
    }
}
