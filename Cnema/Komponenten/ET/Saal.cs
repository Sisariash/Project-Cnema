using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Komponenten.ET
{
    public class Saal
    {

        [Key]
        public string SaalName { get; set; }
        public int AnzahlSitze { get; set; }
        public virtual List<Vorstellung> Vorstellungen { get; set; }


        public Saal(string saalName, int anzahlSitze)
        {

            SaalName = saalName;
            AnzahlSitze = anzahlSitze;
        }
        public Saal() { }

        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || this.GetType() != obj.GetType()) return false;

            Saal other = (Saal)obj;

            if (!this.SaalName.Equals(other.SaalName)) return false;
            if (!this.AnzahlSitze.Equals(other.AnzahlSitze)) return false;

            return true;
        }

        public override int GetHashCode()
        {
            return AnzahlSitze;


        }
    }
}
