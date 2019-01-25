using ppedv.StrawberrySledgehammer.Model;
using ppedv.StrawberrySledgehammer.Model.Contracts;
using System;
using System.Linq;

namespace ppedv.StrawberrySledgehammer.Logic
{
    public class Core
    {
        public IRepository Repository { get; private set; }

        public Core(IRepository repo)//do Depency Injection in here
        {
            this.Repository = repo;
        }

        public Core() : this(new Data.EF.EfRepository())
        { }


        public Veranstaltung GetVeranstaltungWithMostWikingerhörner()
        {
            return Repository.GetAll<Orchester>()
                             .OrderByDescending(x => x.Instrumente
                                                      .Count(i => i.Name.ToLower().Contains("vikinger") ||
                                                                  i.Name.ToLower().Contains("wikinger")))?
                             .FirstOrDefault()?
                             .Veranstaltungen
                             .Where(x => x.Datum >= DateTime.Now)
                             .OrderBy(x => x.Datum)
                             .FirstOrDefault();
        }
    }
}
