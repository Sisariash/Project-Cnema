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
        static DatenbankManager dbm = DatenbankManager.Instance;
        Kundenverwaltung kv = new Kundenverwaltung(dbm);
        Kinoprogrammverwaltung kpv = new Kinoprogrammverwaltung();
        

        [TestMethod]
        public void PersonenAnlegenUndLoeschenTest()
        {
            // Kunden anlegen
            Kunde k1;
            Kunde k2;
            Kunde k3;
            Assert.IsTrue(kv.KundeRegistrieren(Utils.HashPassword("geheim"), "Herzog", "Charly", new DateTime(1986, 10, 6), out k1));
            Assert.IsTrue(kv.KundeRegistrieren(Utils.HashPassword("hall1"), "Ketchum", "Ash", new DateTime(1996, 4, 2), out k2));
            Assert.IsTrue(kv.KundeRegistrieren(Utils.HashPassword("123qwe"), "Stallone", "Silvester", new DateTime(1950, 5, 12), out k3));

            // Admins anlegen
            Admin a1 = new Admin(Utils.HashPassword("geheim"), "Admin1");
            Admin a2 = new Admin(Utils.HashPassword("secret"), "Admin2");
            Assert.IsTrue(kv.AdminRegistrieren(a1));
            Assert.IsTrue(kv.AdminRegistrieren(a2));

            // Kunden loeschen
            Assert.IsTrue(kv.dbManager.KundeLoeschen(k1));
            Assert.IsTrue(kv.dbManager.KundeLoeschen(k2));
            Assert.IsTrue(kv.dbManager.KundeLoeschen(k3));

            //Admins löschen
            Assert.IsTrue(kv.dbManager.AdminLoeschen(a1));
            Assert.IsTrue(kv.dbManager.AdminLoeschen(a2));

            // Versehentliches erneutes Löschen verhindern
            Assert.IsFalse(kv.dbManager.AdminLoeschen(a1));
        } 


        [TestMethod]
        public void LoginTest()
        {
            // Kunden und Admin zu Testzwecken anlegen
            Kunde k1 = null;
            Kunde k2 = null;
            kv.KundeRegistrieren(Utils.HashPassword("geheim"), "Herzog", "Charly", new DateTime(1986, 10, 6), out k1);
            Admin a1 = null;
            Admin a2 = null;
            a1 = new Admin(Utils.HashPassword("secret"), "Admin1");
            kv.AdminRegistrieren(a1);


            // Korrekte ID und Passwörter
            Assert.IsTrue(kv.KundeLogin(k1.BenutzerId, "geheim", out k2));
            Assert.AreEqual(k1, k2); // Selber Kunde wie zuvor?

            Assert.IsTrue(kv.AdminLogin(a1.BenutzerId, "secret", out a2));
            Assert.AreEqual(a1, a2); // Selber Admin wie zuvor?

            // Falsches Passwort, ID Korrekt
            k2 = null;
            a2 = null;
            Assert.IsFalse(kv.KundeLogin(k1.BenutzerId, "superduper", out k2));
            Assert.IsFalse(kv.AdminLogin(a1.BenutzerId, "s3kr3t", out a2));

            // ID nicht vorhanden, Passwort korrekt
            k2 = null;
            a2 = null;
            Assert.IsFalse(kv.KundeLogin(k1.BenutzerId * 123456789, "geheim", out k2));
            Assert.IsFalse(kv.AdminLogin(a1.BenutzerId * 123456789, "secret", out a2));


            // Datenbank bereinigen
            kv.dbManager.KundeLoeschen(k1);
            kv.dbManager.AdminLoeschen(a1);        
        }


        [TestMethod]
        public void PasswortHashingTest()
        {
            String passwort = Utils.HashPassword("password123");
            
            // Korrektes Passwort
            Assert.IsTrue(Utils.VerifyPassword(passwort, "password123"));
            // Falsches Passwort
            Assert.IsFalse(Utils.VerifyPassword(passwort, "pAsswoRd345"));
        }


        [TestMethod]
        public void FilmBewertenTest()
        { 
            // Film und Kunden zu Testzwecken anlegen
            Film f1 = new Film("Rambo III", 1994, "Action", 120, "Deutsch", false, 18);
            kpv.FilmHinzufuegen(f1);
            Kunde k1;
            Kunde k2;
            Kunde k3;
            kv.KundeRegistrieren(Utils.HashPassword("geheim"), "Herzog", "Charly", new DateTime(1986, 10, 6), out k1);
            kv.KundeRegistrieren(Utils.HashPassword("hall1"), "Ketchum", "Ash", new DateTime(1996, 4, 2), out k2);
            kv.KundeRegistrieren(Utils.HashPassword("123qwe"), "Stallone", "Silvester", new DateTime(1950, 5, 12), out k3);

            // Bewertungen abgeben
            Assert.IsTrue(kv.FilmBewerten(5, f1, k1));
            Assert.IsTrue(kv.FilmBewerten(4, f1, k2));
            Assert.IsTrue(kv.FilmBewerten(3, f1, k3));

            // Prüfen, ob pro Kunde und Film nur 1 Bewertung zugelassen wird
            Assert.IsFalse(kv.FilmBewerten(5, f1, k1));
            Assert.IsFalse(kv.FilmBewerten(4, f1, k2));

            // Prüfen ob Durschnittsbewertung korrekt berechnet und gespeichert wurde: (5+4+3)/3 = 4
            kv.DurchschnittBerechnen(f1);
            Assert.AreEqual(4, (int) f1.BewertungAvg);

            
            // Datenbank wieder bereinigen 
            List <FilmBewertung> bewertungen = kv.dbManager.AlleFilmBewertungenLesen();
            foreach (FilmBewertung fb in bewertungen)
            {
                if (fb.Kunde.BenutzerId == k1.BenutzerId || fb.Kunde.BenutzerId == k2.BenutzerId || fb.Kunde.BenutzerId == k3.BenutzerId)
                    kv.dbManager.FilmBewertungLöschen(fb);
            } 

            kv.dbManager.FilmLoeschen(f1);
            kv.dbManager.KundeLoeschen(k1);
            kv.dbManager.KundeLoeschen(k2);
            kv.dbManager.KundeLoeschen(k3);
        }
    }
}