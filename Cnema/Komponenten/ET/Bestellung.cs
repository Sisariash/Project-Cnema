using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Komponenten.ET
{
    public class Bestellung
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BestellId { get; private set; }
        public virtual Vorstellung Vorstellung { get; set; }
        public virtual Kunde Kunde { get; set; }
        public double Preis { get; set; }

        public Bestellung(Vorstellung vorstellung, Kunde kunde, double preis)
        {
            Vorstellung = vorstellung;
            Kunde = kunde;
            Preis = preis;
        }
        public Bestellung()
        {
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
