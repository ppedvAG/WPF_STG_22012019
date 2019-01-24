using ppedv.StrawberrySledgehammer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.StrawberrySledgehammer.Data.EF.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**** Strawberry Sledgehammer v0.1 ****");


            var i1 = new Instrument()
            {
                IstChromatisch = true,
                Material = Material.Holz,
                Stimmung = "Mies",
                Name = "Violine"
            };

            var i2 = new Instrument()
            {
                IstChromatisch = true,
                Material = Material.Plastik,
                Stimmung = "Erheiternd",
                Name = "Gitarre"
            };

            var i3 = new Instrument()
            {
                IstChromatisch = true,
                Material = Material.Metall,
                Stimmung = "Traurig",
                Name = "Oboe"
            };

            var i4 = new Instrument()
            {
                IstChromatisch = false,
                Material = Material.Horn,
                Stimmung = "Mächtig",
                Name = "Vikingerhorn"
            };

            var i5 = new Instrument()
            {
                IstChromatisch = false,
                Material = Material.Stein,
                Stimmung = "Hart",
                Name = "Steinxülofon"
            };

            using (var con = new EfContext())
            {
                if (con.Instrumente.Count() == 0)
                {
                    con.Instrumente.AddRange(new[] { i1, i2, i3, i4, i5 });
                    con.SaveChanges();
                }
            }

            using (var con = new EfContext())
            {
                var dt = DateTime.Now;
                var query = con.Instrumente.Where(x => x.Orchester.Any(y => y.Veranstanlungen.Any(z => z.Datum > dt)));
                query.ToList();
                foreach (var i in con.Instrumente.Where(x => x.Stimmung.Length < 100).OrderBy(x => x.Stimmung))
                {
                    Console.WriteLine($"{i.Name} {i.Material} {i.Stimmung}");
                }
            }



            Console.WriteLine("Ende");
            Console.ReadLine();
        }
    }
}
