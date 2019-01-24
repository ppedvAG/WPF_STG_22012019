using ppedv.StrawberrySledgehammer.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.StrawberrySledgehammer.Data.EF
{
    public class EfContext : DbContext
    {
        public DbSet<Orchester> Orchester { get; set; }
        public DbSet<Instrument> Instrumente { get; set; }
        public DbSet<Veranstaltung> Veranstaltungen { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Orchester>()
                        .Property(x => x.Name)
                        .HasColumnName("Ochestername")
                        .HasMaxLength(67)
                        .IsRequired();
        }
    }
}
