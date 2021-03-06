﻿using System.Collections.Generic;

namespace ppedv.StrawberrySledgehammer.Model
{
    public class Orchester : Entity
    {
        public string Name { get; set; }
        public virtual HashSet<Instrument> Instrumente { get; set; } = new HashSet<Instrument>();
        public virtual HashSet<Veranstaltung> Veranstaltungen { get; set; } = new HashSet<Veranstaltung>();

    }
}
