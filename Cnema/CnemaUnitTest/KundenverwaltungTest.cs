using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using Komponenten.Datenbank;
using Komponenten.ET;
using Komponenten.Kundenverwaltung;
using Komponenten.Kundenverwaltung.Impl;
using Komponenten.Kinoprogrammverwaltung.Impl;
using System.Collections.Generic;
using Komponenten.Datenbank.Impl;
using Komponenten.Util;

namespace CnemaUnitTest
{
    [TestClass]
    public class KundenverwaltungTest
    {
        static DatenbankManager dbm = new DatenbankManager();
        Kundenverwaltung kv = new Kundenverwaltung(dbm);
        Kinoprogrammverwaltung kpv = new Kinoprogrammverwaltung(dbm);


        /*Kunde k1 = new Kunde(Utils.HashPassword("geheim"), "Herzog", "Charly", new DateTime(1986, 10, 6));
        Kunde k2 = new Kunde(Utils.HashPassword("hall1"), "Ketchum", "Ash", new DateTime(1996, 4, 2));
        Kunde k3 = new Kunde(Utils.HashPassword("123qwe"), "Stallone", "Silvester", new DateTime(1950, 5, 12));
        Admin a1 = new Admin(Utils.HashPassword("test"), "Kapo");
        Admin a2 = new Admin(Utils.HashPassword("secret"), "Junior");
        Assert.IsTrue(kv.KundeRegistrieren(k1));
        Assert.IsTrue(kv.KundeRegistrieren(k2));
        Assert.IsTrue(kv.KundeRegistrieren(k3));
        Assert.IsTrue(kv.AdminRegistrieren(a1));
        Assert.IsTrue(kv.AdminRegistrieren(a2)); */

        [TestMethod]
        public void PersonenAnlegenTest()
        {
            // Admins anlegen für Testzwecke

            Admin a1 = new Admin(Utils.HashPassword("geheim"), "A1");
            Admin a2 = new Admin(Utils.HashPassword("secret"), "A2");
            kv.AdminRegistrieren(a1);
            kv.AdminRegistrieren(a2);
          
        } 

        [TestMethod]
        public void FilmAnlegenTest()
        {

            /*Film f1 = new Film ("Pokémon - I choose you", 2017, "Anime", 100, "Englisch", false, 5, 12);
            Film f2 = new Film ("Rambo III", 1994, "Action", 120, "Deutsch", false, 4, 18);
            Film f3 = new Film("Gladiator", 2002, "Abenteuer", 130, "Deutsch", true, 3, 16); 

            Assert.IsTrue(kpv.FilmHinzufuegen(f1));
            Assert.IsTrue(kpv.FilmHinzufuegen(f2));
            Assert.IsTrue(kpv.FilmHinzufuegen(f3));

            kv.FilmBewerten(5, kpv.FilmLesen(9), kv.dbManager.KundeLesen(15));
            kv.FilmBewerten(5, kpv.FilmLesen(9), kv.dbManager.KundeLesen(16));
            kv.FilmBewerten(3, kpv.FilmLesen(10), kv.dbManager.KundeLesen(17));
            kv.FilmBewerten(4, kpv.FilmLesen(11), kv.dbManager.KundeLesen(15));
            kv.FilmBewerten(4, kpv.FilmLesen(11), kv.dbManager.KundeLesen(16)); */
        }

        [TestMethod]
        public void LoginTest()
        {
            // WICHTIG: Immer aktuelle, von Datenbank generierte ID eintragen!!

            // Korrekte ID und Passwörter
            //Assert.IsTrue(kv.KundeLogin(15,"geheim"));
            //Assert.IsTrue(kv.AdminLogin("secret"));

            // Falsches Passwort
            //Assert.IsFalse(kv.KundeLogin(16, "superduper"));
            //Assert.IsFalse(kv.AdminLogin("secr3t"));
            // ID nicht vorhanden
            //Assert.IsFalse(kv.KundeLogin(1000, "geheim"));
        }


        [TestMethod]
        public void PasswortHashingTest()
        {
            // Hashwert ist immer unterschiedlich, die Prüfung auf Korrektheit stimmt trotzdem immer überein
            // User user = new User();
            // user.username = "max.mustermann@web.de"
            // user.password = Utils.HashPassword("password123");
            // datenbankManager.UserHinzufuegen(user);
            //
            string passwordOfUserInDB = Utils.HashPassword("password123"); // === user.UserId Beim Registireren brauchen wir das

            // Correct Password
            // login(string username, string password) {
            //  User user = datenbankManager.UserLesen("max.mustermann@web.de")
            //  if (user == null) { 
            //      // User mit Benutzername existiert nicht 
            // } else if (Utils.VerifyPassword(user.password, "password123")) {
            //        // User Login successful
            //  } else {
            //       // Wrong passwords
            // }
            Assert.IsTrue(Utils.VerifyPassword(passwordOfUserInDB, "password123"));

            // Wrong password
            Assert.IsFalse(Utils.VerifyPassword(passwordOfUserInDB, "password345"));
        }

        [TestMethod]
        public void FilmBewertenTest()
        {
            //Alle bestehenden Bewertungen löschen
            List<FilmBewertung> bewertungen = kv.dbManager.AlleFilmBewertungenLesen();
            foreach (FilmBewertung fb in bewertungen) { kv.dbManager.FilmBewertungLöschen(fb); }

            Film film = kpv.FilmLesen(1);
            Kunde kunde = kv.dbManager.KundeLesen(1);
            FilmBewertung bewertung = kv.FilmBewerten(10, film, kunde);
            Assert.IsNotNull(bewertung);
            bewertungen = kv.dbManager.AlleFilmBewertungenLesen();
            Assert.AreEqual(1, bewertungen.Count);
            Assert.AreEqual(kunde, bewertung.Kunde);
            Assert.AreEqual(film, bewertung.Film);
            kv.dbManager.FilmBewertungLöschen(bewertung);
            bewertungen = kv.dbManager.AlleFilmBewertungenLesen();
            Assert.AreEqual(0, bewertungen.Count);
        }
    }
}