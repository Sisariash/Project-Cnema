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
            DatenbankManager db = DatenbankManager.Instance;

            //Alles löschen
            foreach (Kunde k in db.AlleKundenLesen()) db.KundeLoeschen(k);
            foreach (Admin a in db.AlleAdminsLesen()) db.AdminLoeschen(a);
            foreach (Bestellung b in db.AlleBestellungenLesen()) db.BestellungLoeschen(b);
            foreach (FilmBewertung fb in db.AlleFilmBewertungenLesen()) db.FilmBewertungLöschen(fb);
            foreach (Vorstellung v in db.AlleVorstellungenLesen()) db.VorstellungLoeschen(v);
            foreach (Film f in db.AlleFilmeLesen()) db.FilmLoeschen(f);
            foreach (Saal s in db.AlleSaeleLesen()) db.SaalLoeschen(s);

            //Beispieldaten hinzufügen für Präsentation

            // Admin
            Admin admin = new Admin(Komponenten.Util.Utils.HashPassword("admin"), "Admin");
            db.AdminHinzufuegen(admin);

            // Säle
            Saal saal1 = new Saal("Saal 1", 80);
            Saal saal2 = new Saal("Saal 2", 100);
            Saal saal3 = new Saal("Hugo-Laue-Saal", 150);
            db.SaalHinzufügen(saal1);
            db.SaalHinzufügen(saal2);
            db.SaalHinzufügen(saal3);

            // Filme
            Film film1 = new Film("The Big Lebowski", 1998, "Komödie", 117, "Deutsch", false, 12);
            Film film2 = new Film("Djumanji: Willkommen im Djungel (3D)", 2017, "Abenteuer", 119, "Deutsch", true, 12);
            Film film3 = new Film("Djumanji: Willkommen im Djungel", 2017, "Abenteuer", 119, "Deutsch", false, 12);
            Film film4 = new Film("Star Wars: Die letzen Jedi", 2017, "Science-Fiction", 152, "Deutsch", false, 12);
            Film film5 = new Film("Star Wars: The Last Jedi", 2017, "Science-Fiction", 152, "Englisch", false, 12);
            Film film6 = new Film("Jigsaw", 2017, "Horror", 92, "Deutsch", false, 18);
            Film film7 = new Film("Pokemon - Der Film", 1998, "Animation", 110, "Deutsch", false, 12);
            Film film8 = new Film("The Dark Knight", 2008, "Action", 152, "Deutsch", false, 16);
            Film film9 = new Film("Cars3", 2017, "Animation", 110, "Deutsch", false, 0);
            Film film10 = new Film("Bad Moms 2", 2017, "Komödie", 105, "Deutsch", false, 12);
            Film film11 = new Film("Der Pate", 1972, "Krimi", 175, "Deutsch", false, 16);
            Film film12 = new Film("Pulp Fiction", 1994, "Drama", 154, "Deutsch", false, 16);
            Film film13 = new Film("Yol Arkadasim (Türkisch)", 2017, "Komödie", 115, "Türkisch", false, 6);
            Film film14 = new Film("Paddington 2", 2017, "Animation", 104, "Deutsch", false, 0);
            Film film15 = new Film("The Commuter", 2017, "Thriller", 105, "Deutsch", false, 12);
            Film film16 = new Film("Greatest Showman", 2017, "Drama", 105, "Deutsch", false, 6);
            Film film17 = new Film("Greatest Showman (Englisch)", 2017, "Drama", 105, "Englisch", false, 6);
            Film film18 = new Film("Insidious: The Last Key", 2017, "Thriller", 104, "Deutsch", false, 16);
            Film film19 = new Film("Ayla (Türkisch)", 2017, "Drama", 124, "Türkisch", false, 12);
            Film film20 = new Film("Titanic", 1997, "Romanze", 104, "Deutsch", false, 12);
            Film film21 = new Film("Coco - Lebendiger als das Leben!", 2017, "Abenteuer", 10, "Deutsch", false, 0);
            Film film22 = new Film("Happy Deathday", 2017, "Horror", 97, "Deutsch", false, 12);
            Film film23 = new Film("Die Verurteilten", 1994, "Krimi", 144, "Deutsch", false, 12);
            Film film24 = new Film("Avatar - Aufbruch nach Pandora (3D)", 2009, "Fantasy", 162, "Deutsch", true, 12);
            Film film25 = new Film("Interstellar", 2014, "Abenteuer", 169, "Deutsch", false, 12);
            Film film26 = new Film("Mad Max: Fury Road (3D)", 2015, "Thriller", 121, "Deutsch", true, 16);
            Film film27 = new Film("Life of Pi: Schiffbruch mit Tiger (3D)", 2012, "Abenteuer", 127, "Deutsch", true, 12);
            Film film28 = new Film("Der Hobbit: Smaugs Einöde (3D) ", 2013, "Fantasy", 161, "Deutsch", true, 12);
            Film film29 = new Film("La La Land ", 2017, "Romanze", 128, "Deutsch", false, 12);
            Film film30 = new Film("Walk the Line) ", 2006, "Romanze", 136, "Deutsch", false, 12);

            db.FilmHinzufuegen(film1);
            db.FilmHinzufuegen(film2);
            db.FilmHinzufuegen(film3);
            db.FilmHinzufuegen(film4);
            db.FilmHinzufuegen(film5);
            db.FilmHinzufuegen(film6);
            db.FilmHinzufuegen(film7);
            db.FilmHinzufuegen(film8);
            db.FilmHinzufuegen(film9);
            db.FilmHinzufuegen(film10);
            db.FilmHinzufuegen(film11);
            db.FilmHinzufuegen(film12);
            db.FilmHinzufuegen(film13);
            db.FilmHinzufuegen(film14);
            db.FilmHinzufuegen(film15);
            db.FilmHinzufuegen(film16);
            db.FilmHinzufuegen(film17);
            db.FilmHinzufuegen(film18);
            db.FilmHinzufuegen(film19);
            db.FilmHinzufuegen(film20);
            db.FilmHinzufuegen(film21);
            db.FilmHinzufuegen(film22);
            db.FilmHinzufuegen(film23);
            db.FilmHinzufuegen(film24);
            db.FilmHinzufuegen(film25);
            db.FilmHinzufuegen(film26);
            db.FilmHinzufuegen(film27);
            db.FilmHinzufuegen(film28);
            db.FilmHinzufuegen(film29);
            db.FilmHinzufuegen(film30);
          



            // Vorstellung
            Vorstellung v1 = new Vorstellung(film1, saal1, new DateTime(2018, 01, 13, 18, 0, 0));
            Vorstellung v2 = new Vorstellung(film2, saal1, new DateTime(2018, 01, 13, 20, 30, 0));
            Vorstellung v3 = new Vorstellung(film3, saal2, new DateTime(2018, 01, 14, 20, 30, 0));
            Vorstellung v4 = new Vorstellung(film4, saal1, new DateTime(2018, 01, 13, 18, 0, 0));
            db.VorstellungHinzufuegen(v1);
            db.VorstellungHinzufuegen(v2);
            db.VorstellungHinzufuegen(v3);
            db.VorstellungHinzufuegen(v4);
        }
    }
}
