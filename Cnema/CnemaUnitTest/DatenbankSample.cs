using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Komponenten.Datenbank;
using Komponenten.Datenbank.Impl;
using Komponenten.ET;
using Komponenten.Kundenverwaltung.Impl;

namespace CnemaUnitTest
{
    [TestClass]
    public class DatenbankSample
    {
        [TestMethod]
        public void CreateSample()
        {
            DatenbankManager db = new DatenbankManager();

            //Alles löschen
            foreach (Kunde k in db.AlleKundenLesen()) db.KundeLoeschen(k);
            foreach (Admin a in db.AlleAdminsLesen()) db.AdminLoeschen(a);
            foreach (Bestellung b in db.AlleBestellungenLesen()) db.BestellungLoeschen(b);
            foreach (FilmBewertung fb in db.AlleFilmBewertungenLesen()) db.FilmBewertungLöschen(fb);
            foreach (Vorstellung v in db.AlleVorstellungenLesen()) db.VorstellungLoeschen(v);
            foreach (Film f in db.AlleFilmeLesen()) db.FilmLoeschen(f);
            foreach (Saal s in db.AlleSaeleLesen()) db.SaalLoeschen(s);

            //Beispieldaten hinzufügen
            Admin admin = new Admin(Komponenten.Util.Utils.HashPassword("admin"), "Admin");
            db.AdminHinzufuegen(admin);
            Saal saal1 = new Saal("Saal 1", 80);
            Saal saal2 = new Saal("Saal 2", 100);
            Saal saal3 = new Saal("Hugo-Laue-Saal", 150);
            db.SaalHinzufügen(saal1);
            db.SaalHinzufügen(saal2);
            db.SaalHinzufügen(saal3);
            Film film1 = new Film("The Big Lebowski", 1998, "Comedy", 117, "Deutsch", false, 12);
            Film film2 = new Film("Djumanji: Willkommen im Djungel", 2017, "Adventure", 119, "Deutsch", true, 12);
            Film film3 = new Film("Djumanji: Willkommen im Djungel", 2017, "Adventure", 119, "Deutsch", false, 12);
            Film film4 = new Film("Star Wars: Die letzen Jedi", 2017, "Science-Fiction", 152, "Deutsch", false, 12);
            Film film5 = new Film("Star Wars: Die letzen Jedi", 2017, "Science-Fiction", 152, "Englisch", false, 12);
            Film film6 = new Film("Jigsaw", 2017, "Horror", 92, "Deutsch", false, 18);
            db.FilmHinzufuegen(film1);
            db.FilmHinzufuegen(film2);
            db.FilmHinzufuegen(film3);
            db.FilmHinzufuegen(film4);
            db.FilmHinzufuegen(film5);
            db.FilmHinzufuegen(film6);
            Vorstellung v1 = new Vorstellung(film1, saal1, new DateTime(2017, 12, 29, 18, 0, 0));
            Vorstellung v2 = new Vorstellung(film2, saal1, new DateTime(2017, 12, 29, 20, 30, 0));
            Vorstellung v3 = new Vorstellung(film3, saal2, new DateTime(2017, 12, 28, 20, 30, 0));
            Vorstellung v4 = new Vorstellung(film4, saal3, new DateTime(2017, 12, 29, 18, 0, 0));
            db.VorstellungHinzufuegen(v1);
            db.VorstellungHinzufuegen(v2);
            db.VorstellungHinzufuegen(v3);
            db.VorstellungHinzufuegen(v4);
        }
    }
}
