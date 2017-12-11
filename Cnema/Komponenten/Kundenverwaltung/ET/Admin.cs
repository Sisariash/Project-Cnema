using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komponenten.Kundenverwaltung.ET
{
    public class Admin
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AdminId { get; private set; }
        public String Passwort { get; private set; }
        public String Name { get; set; }

        public Admin()
        {
        }

        public Admin(String passwort, String name)
        {
            Passwort = passwort;
            Name = name;
        }

        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (this.GetType() != obj.GetType() || obj == null) return false;
            Admin other = (Admin)obj;
            if (!this.AdminId.Equals(other.AdminId)) return false;
            return true;
        }

        public override int GetHashCode()
        {
            return AdminId;
        }
    }
}
