﻿using System;
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

        public void FilmBewerten(int bewertung, Film film, Kunde kunde)
        {
            using (CnemaContext db = new CnemaContext())
            {
                FilmBewertung fbw = new FilmBewertung(bewertung);
                db.FilmBewertungen.Add(fbw);
                // Bewertung zu den beiden n-Seiten hinzufügen
<<<<<<< HEAD
                film.FilmBewertungen.Add(fbw);
                kunde.FilmBewertungen.Add(fbw);
=======
                //film.FilmBewertungen.Add(fbw);
                //kunde.FilmBewertungen.Add(fbw);
                fbw.Film = db.Filme.Find(film.FilmId);
                fbw.Kunde = db.Kunden.Find(kunde.BenutzerId);
>>>>>>> 54a508f1b8feaa6c49ae1aa74f99bf56e5598e00
                db.SaveChanges();
            }
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
