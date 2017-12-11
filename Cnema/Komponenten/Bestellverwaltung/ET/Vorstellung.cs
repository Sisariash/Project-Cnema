﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Komponenten.Kinoprogrammverwaltung.ET;
using System.ComponentModel.DataAnnotations.Schema;

namespace Komponenten.Bestellverwaltung.ET
{
    public class Vorstellung
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VorstellungId { get; private set; }
        public virtual Film Film { get; set; }
        public virtual Saal Saal { get; set; }
        public DateTime DateTime { get; set; }
        public virtual List<Bestellung> Bestellungen { get; set; }

        public Vorstellung()
        {
        }
        public Vorstellung(Film film, Saal saal, DateTime dateTime)
        {
            Film = film;
            Saal = saal;
            DateTime = dateTime;
        }
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || this.GetType() != obj.GetType()) return false;
            Vorstellung other = (Vorstellung)obj;
            if (!this.VorstellungId.Equals(other.VorstellungId)) return false;
            return true;
        }
        public override int GetHashCode()
        {
            return VorstellungId;
        }
    }
}
