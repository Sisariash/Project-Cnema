using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Komponenten.Bestellverwaltung.ET;
using Komponenten.Kundenverwaltung.ET;

namespace Komponenten.Kinoprogrammverwaltung.ET
{
    public class Film
    {
        [Key]
        public int FilmId { get; set; }
        public string Titel { get; set; }
        public int Jahr { get; set; }
        public string Genre { get; set; }
        public int Laenge { get; set; }
        public string Sprache { get; set; }
        public bool Is3D { get; set; }
        public double BewertungAvg { get; set; }
        public int Fsk { get; set; }
        private static int nextId = 0;
        public virtual List<Vorstellung> Vorstellungen { get; set; }
        public virtual List<FilmBewertung> FilmBewertungen { get; set; }

        public Film()
        {
            this.FilmId = nextId++;
        }

        public Film(string titel, int jahr, string genre, int laenge, string sprache, bool is3D, double bewertungAvg, int fsk)
        {
            this.Titel = titel;
            this.Jahr = jahr;
            this.Genre = genre;
            this.Laenge = laenge;
            this.Sprache = sprache;
            this.Is3D = is3D;
            this.BewertungAvg = bewertungAvg;
            this.Fsk = fsk;
        }

        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || this.GetType() != obj.GetType()) return false;

            Film other = (Film)obj;

            if (!this.FilmId.Equals(other.FilmId)) return false;

            return true;
        }

        public override int GetHashCode()
        {
            return FilmId;

        }
    }
}
