using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Komponenten.Kinoprogrammverwaltung.ET;

namespace Komponenten.Kinoprogrammverwaltung.Impl
{
    public class Kinoprogrammverwaltung : IKinoprogrammverwaltung
    {
        public Film Aendern(Film film)
        {
            throw new NotImplementedException();
        }

        public bool Hinzufuegen(Film film)
        {
            throw new NotImplementedException();
        }

        public bool Loeschen(Film film)
        {
            throw new NotImplementedException();
        }

        public void VorstellungEntfernen(string vorstellungId)
        {
            throw new NotImplementedException();
        }

        public bool VorstellungErzeugen(Film film, Saal saal, DateTime Zeitpunkt)
        {
            throw new NotImplementedException();
        }
    }
}
