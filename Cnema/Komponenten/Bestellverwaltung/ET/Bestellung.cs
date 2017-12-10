﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komponenten.Bestellverwaltung.ET
{
    public class Bestellung
    {
        [Key]
        public int BestellId { get; set; }
        public virtual Vorstellung Vorstellung { get; set; }
        public virtual Kunde Kunde { get; set; }
        public double Preis { get; set; }
        private static int nextId = 0;

        public Bestellung(Vorstellung vorstellung, Kunde kunde, double preis)
        {
            BestellId = nextId++;
            Vorstellung = vorstellung;
            Kunde = kunde;
            Preis = preis;
        }
        public Bestellung()
        {
            BestellId = nextId++;
        }

        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (this.GetType() != obj.GetType() || obj == null) return false;
            Bestellung other = (Bestellung)obj;
            if (!this.BestellId.Equals(other.BestellId)) return false;
            return true;
        }
        public override int GetHashCode()
        {
            return BestellId;
        }
    }
}
