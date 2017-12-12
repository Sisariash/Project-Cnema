using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Komponenten.ET
{
    public class Kunde : Benutzer
    {
        public String Name { get; set; }
        public String Vorname { get; set; }
        public DateTime Geburtsdatum { get; set; }
        public virtual List<Bestellung> Bestellungen { get; set; }
        public virtual List<FilmBewertung> FilmBewertungen { get; set; }


        public Kunde(String passwort, String name, String vorname, DateTime geburtsdatum) : base(passwort)
        {
            Name = name;
            Vorname = vorname;
            Geburtsdatum = geburtsdatum;
        }

        public Kunde()
        { }
    }
}
