using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Komponenten.ET;

namespace Komponenten.Kundenverwaltung
{
    public interface IKundenverwaltung
    {
        bool Registrieren(Kunde kunde);
        bool Login(int Id, String passwort);
        void FilmBewerten(int bewertung);
    }
}
