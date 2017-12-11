using Komponenten.Bestellverwaltung.ET;
using Komponenten.Kinoprogrammverwaltung.ET;
using Komponenten.Kundenverwaltung.ET;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komponenten.Datenbank
{
    class CnemaContext : DbContext
    {
        public DbSet<Vorstellung> Vorstellungen { get; set; }
        public DbSet<Bestellung> Bestellungen { get; set; }
        public DbSet<Film> Filme { get; set; }
        public DbSet<Saal> Säle { get; set; }
        public DbSet<Kunde> Kunden { get; set; }
        public DbSet<FilmBewertung> FilmBewertungen { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}
