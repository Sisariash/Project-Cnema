using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komponenten.ET
{
    public class Benutzer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BenutzerId { get; private set; }
        public String Passwort { get; private set; }

        public Benutzer (String passwort)
        {
            Passwort = passwort;
        }

        public Benutzer()
        { }

        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (this.GetType() != obj.GetType() || obj == null) return false;
            Benutzer other = (Benutzer)obj;
            if (!this.BenutzerId.Equals(other.BenutzerId)) return false;
            return true;
        }

        public override int GetHashCode()
        {
            return BenutzerId * 31;
        }
    }
}
