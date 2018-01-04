using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Komponenten.ET;
using Komponenten.Datenbank;
using Komponenten.Datenbank.Impl;
using Komponenten.Util;
using System.Data.SqlTypes;

namespace Komponenten.Kundenverwaltung.Impl
{
    public class Kundenverwaltung : IKundenverwaltung
    {
        public IDatenbankManager dbManager;

        public Kundenverwaltung(IDatenbankManager datenbankManager)
        {
            dbManager = datenbankManager;
        }
        public Kundenverwaltung()
        {
            dbManager = DatenbankManager.Instance;
        }

        public bool FilmBewerten(int bewertung, Film film, Kunde kunde)
        {
            // Prüfung ob Bewertung erlaubt (Pro Film und Kunde nur 1 Bewertung!)

            List<FilmBewertung> alleBewertungen = dbManager.AlleFilmBewertungenLesen();
            foreach (FilmBewertung bew in alleBewertungen)
            {
                if (bew.Kunde.BenutzerId == kunde.BenutzerId && bew.Film.FilmId == film.FilmId)
                {
                    return false;
                }
            }
            FilmBewertung filmBewertung = new FilmBewertung(bewertung);
            filmBewertung.Film = film;
            filmBewertung.Kunde = kunde;
            if (!dbManager.FilmBewertungHinzufügen(filmBewertung))
            {
                throw new Exception();
            }

            return true;
        }

        public void DurchschnittBerechnen(Film film)
        {
            double summe = 0;
            int counter = 0;

            List<FilmBewertung> alleBewertungenAktuell = dbManager.AlleFilmBewertungenLesen();
            foreach (FilmBewertung bew in alleBewertungenAktuell)
            {
                if (bew.Film.FilmId == film.FilmId)
                {
                    summe += bew.Bewertung;
                    counter++;
                }
            }
            if (counter != 0)
            {
                film.BewertungAvg = (summe / counter);
                dbManager.Update();
            }
        }

        public bool KundeLogin(int id, string passwort, out Kunde k)
        {
            k = null;
            if (dbManager.KundeLesen(id) != null)
            {
                k = dbManager.KundeLesen(id);
                return Utils.VerifyPassword(k.Passwort, passwort);
            }
            else
                return false;
        }

        public bool AdminLogin(int id, string passwort, out Admin a)
        {
            a = null;
            if (dbManager.AdminLesen(id) != null)
            {
                a = dbManager.AdminLesen(id);
                return Utils.VerifyPassword(a.Passwort, passwort);
            }
            else
                return false;
        }

        public bool KundeRegistrieren(String passwort, String name, String vorname, DateTime geburtsdatum, out Kunde k)
        {
            if (geburtsdatum < SqlDateTime.MinValue)
            {
                throw new SqlTypeException();
            }
            else
            {
                k = new Kunde(passwort, name, vorname, geburtsdatum);
                return dbManager.KundeHinzufuegen(k);
            }
        }

        public bool AdminRegistrieren(Admin admin)
        {
            return dbManager.AdminHinzufuegen(admin);
        }
    }
}
