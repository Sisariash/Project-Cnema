using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Komponenten.ET
{
    public class Film : IComparable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FilmId { get; set; }
        public string Titel { get; set; }
        public int Jahr { get; set; }
        public string Genre { get; set; }
        public int Laenge { get; set; }
        public string Sprache { get; set; }
        public bool Is3D { get; set; }
        public double BewertungAvg { get; set; }
        public int Fsk { get; set; }
        public virtual List<Vorstellung> Vorstellungen { get; set; }
        public virtual List<FilmBewertung> FilmBewertungen { get; set; }

        public Film()
        {
        }

        public Film(string titel, int jahr, string genre, int laenge, string sprache, bool is3D, int fsk)
        {
            Titel = titel;
            Jahr = jahr;
            Genre = genre;
            Laenge = laenge;
            Sprache = sprache;
            Is3D = is3D;
            Fsk = fsk;
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

        public int CompareTo(object obj)
        {
            Film other = (Film)obj;
            return this.Titel.CompareTo(other.Titel);
        }

        //Genren
        public static List<String> Genres()
        {
            return new List<string>( new string[] 
                {
                    "Animation",
                    "Action",
                    "Abenteuer",
                    "Fantasy",
                    "Drama",
                    "Horror",
                    "Komödie",                  
                    "Krimi",
                    "Romanze",
                    "Science-Fiction",
                    "Thriller"
                });
        }


    }
}
