using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komponenten.Kundenverwaltung
{
    public interface IKundenverwaltung
    {
        bool Registrieren(ET.Kunde kunde);
        bool Login(int Id, String passwort);
        void FilmBewerten(int bewertung);
    }
}
