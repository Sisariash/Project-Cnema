using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Komponenten.ET;
using Komponenten.Datenbank;
using Komponenten.Datenbank.Impl;


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
            dbManager = new DatenbankManager();
        }

        public FilmBewertung FilmBewerten(int bewertung, Film film, Kunde kunde)
        {
            FilmBewertung filmBewertung = new FilmBewertung(bewertung);
            filmBewertung.Film = film;
            filmBewertung.Kunde = kunde;
            if (!dbManager.FilmBewertungHinzufügen(filmBewertung))
            {
                throw new Exception("Bewertung konnte nicht hinzugefügt werden.");
            }
            return filmBewertung;
        }

        public bool KundeLogin(int id, string passwort)
        {
            Kunde k;
            if (dbManager.KundeLesen(id) != null)
            {
                k = dbManager.KundeLesen(id);
                return Utils.VerifyPassword(k.Passwort, passwort);
            }
            else
                return false;
        }

        public bool AdminLogin(string passwort)
        {
            List<Admin> admins = dbManager.AlleAdminsLesen();
            foreach (Admin a in admins)
            {
                if (Utils.VerifyPassword(a.Passwort, passwort))
                    return true;
            }
            return false;
        }

        public bool KundeRegistrieren(Kunde kunde)
        {
            return dbManager.KundeHinzufuegen(kunde);
        }

        public bool AdminRegistrieren(Admin admin)
        {
            return dbManager.AdminHinzufuegen(admin);
        }
    }
}
