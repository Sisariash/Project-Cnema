using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Komponenten.Kinoprogrammverwaltung.ET
{
    public class Saal
    {

        [Key]
        public string saalName { get; set; }
        public int anzahlSitze { get; set; }


        public Saal (string saalName, int anzahlSitze)
        {

            this.saalName = saalName;
            this.anzahlSitze = anzahlSitze;
        }

        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || this.GetType() != obj.GetType()) return false;

            Saal other = (Saal)obj;

            if (!this.saalName.Equals(other.saalName)) return false;
            if (!this.anzahlSitze.Equals(other.anzahlSitze)) return false;

            return true;
        }

        public override int GetHashCode()
        {
            return anzahlSitze;


        }
}
