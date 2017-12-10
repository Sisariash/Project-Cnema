using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Komponenten.Kinoprogrammverwaltung.ET
{
    public class Film
    {
        [Key]
        public int filmId { get; set; }
        public string titel { get; set; }
        public int jahr { get; set; }
        public string genre { get; set; }
        public int laenge { get; set; }
        public string sprache { get; set; }
        public bool is3D { get; set; }
        public double bewertungAvg { get; set; }
        public int fsk { get; set; }
        private static int nextId = 0;

        public Film()
        {
            this.filmId = nextId++;
        }

        public Film(string titel, int jahr, string genre, int laenge, string sprache, bool is3D, double bewertungAvg, int fsk)
        {
            this.titel = titel;
            this.jahr = jahr;
            this.genre = genre;
            this.laenge = laenge;
            this.sprache = sprache;
            this.is3D = is3D;
            this.bewertungAvg = bewertungAvg;
            this.fsk = fsk;
        }

        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || this.GetType() != obj.GetType()) return false;

            Film other = (Film)obj;

            if (!this.filmId.Equals(other.filmId)) return false;

            return true;
        }

        public override int GetHashCode()
        {
            return filmId;

        }
    }
}
