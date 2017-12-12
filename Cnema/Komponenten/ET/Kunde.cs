﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Komponenten.ET
{
    public class Kunde
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KundenId { get; private set; }
        public String Passwort { get; private set; }
        public String Vorname { get; set; }
        public String Name { get; set; }
        public DateTime Geburtsdatum { get; set; }
        public virtual List<Bestellung> Bestellungen { get; set; }
        public virtual List<FilmBewertung> FilmBewertungen { get; set; }

        public Kunde()
        {
        }

        public Kunde (String passwort, String vorname, String name, DateTime geburtsdatum)
        {
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