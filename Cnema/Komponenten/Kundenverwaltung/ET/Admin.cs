using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komponenten.Kundenverwaltung.ET
{
    public class Admin
    {
        private static int nextId = 0 ;

        [Key]
        public int AdminId { get; private set; }
        [Required]
        public String Passwort { get; private set; }
        [Required]
        public String Name { get; set; }

        public Admin()
        {
            AdminId = nextId++;
        }

        public Admin(String passwort, String name)
        {
            AdminId = nextId++;
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
