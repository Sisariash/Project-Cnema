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
        bool KundeRegistrieren(String passwort, String name, String vorname, DateTime geburtsdatum);
        bool AdminRegistrieren(Admin admin);
        bool KundeLogin(int id, String passwort);
        bool AdminLogin(String passwort);
        FilmBewertung FilmBewerten(int bewertung, Film film, Kunde kunde);
    }
}
