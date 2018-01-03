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
        bool KundeRegistrieren(String passwort, String name, String vorname, DateTime geburtsdatum, out Kunde k);
        bool AdminRegistrieren(Admin admin);
        bool KundeLogin(int id, String passwort, out Kunde k);
        bool AdminLogin(int id, String passwort, out Admin a);
        bool FilmBewerten(int bewertung, Film film, Kunde kunde);
        void DurchschnittBerechnen(Film film);
    }
}
