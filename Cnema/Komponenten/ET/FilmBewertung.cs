using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Komponenten.ET
{
    public class FilmBewertung
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FilmBewertungId { get; private set; }
        public int Bewertung { get; set; }
        public virtual Kunde Kunde { get; set; }
        public virtual Film Film { get; set; }

        public FilmBewertung()
        {
        }
        public FilmBewertung(int bewertung)
        {
            Bewertung = bewertung;
        }

        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (this.GetType() != obj.GetType() || obj == null) return false;
            FilmBewertung other = (FilmBewertung)obj;
            if (!this.FilmBewertungId.Equals(other.FilmBewertungId)) return false;
            return true;
        }

        public override int GetHashCode()
        {
            return FilmBewertungId * 41;
        }
    }
}
