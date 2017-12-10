using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Komponenten.Kundenverwaltung.ET
{
    public class Kunde
    {
        private static int nextId = 1000;

        [Key]
        public int KundenId { get; private set; }
        [Required]
        public String Passwort { get; private set; }
        [Required]
        public String Vorname { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public DateTime Geburtsdatum { get; set; }
        public virtual SortedList<int, Bestellung> Bestellungen { get; set; }
        public virtual SortedList<int, FilmBewertung> FilmBewertungen { get; set; }

        public Kunde()
        {
            KundenId = nextId++;
        }

        public Kunde (String passwort, String vorname, String name, DateTime geburtsdatum)
        {
            KundenId = nextId++;
            Passwort = passwort;
            Vorname = vorname;
            Name = name;
            Geburtsdatum = geburtsdatum;
        }

        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (this.GetType() != obj.GetType() || obj == null) return false;
            Kunde other = (Kunde)obj;
            if (!this.KundenId.Equals(other.KundenId)) return false;
            return true;
        }

        public override int GetHashCode()
        {
            return KundenId * 31;
        }



    }
}
