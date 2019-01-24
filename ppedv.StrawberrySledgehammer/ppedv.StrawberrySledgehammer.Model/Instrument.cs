using System.Collections.Generic;

namespace ppedv.StrawberrySledgehammer.Model
{
    public class Instrument : Entity
    {
        public string Name { get; set; }
        public Material Material { get; set; }
        public string Stimmung { get; set; }
        public bool IstChromatisch { get; set; }

        public virtual HashSet<Orchester> Orchester { get; set; } = new HashSet<Orchester>();
    }
}
