﻿using System;

namespace ppedv.StrawberrySledgehammer.Model
{
    public class Veranstanlung : Entity
    {
        public string Name { get; set; }
        public DateTime Datum { get; set; } = DateTime.Now;
        public virtual Orchester Orchester { get; set; }
    }
}
