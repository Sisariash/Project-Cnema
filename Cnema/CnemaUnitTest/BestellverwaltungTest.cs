using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Komponenten.Datenbank;
using Komponenten.ET;
using Komponenten.Bestellverwaltung.Impl;
using Komponenten.Kundenverwaltung.Impl;
using Komponenten.Datenbank.Impl;
using Komponenten.Util;
using Komponenten.Kinoprogrammverwaltung.Impl;

namespace CnemaUnitTest
{
    [TestClass]
    public class BestellverwaltungTest
    {
        [TestMethod]
        public void TestReservierung()
        {
            DatenbankManager dbm = DatenbankManager.Instance;
            Bestellverwaltung bestellverwaltung = new Bestellverwaltung(dbm);
            Kundenverwaltung kundenverwaltung = new Kundenverwaltung(dbm);
            Kunde testKunde;
            kundenverwaltung.KundeRegistrieren(Utils.HashPassword("1234"), "Wurst", "Hans", new DateTime(1990, 3, 15), out testKunde);
            Film testFilm = new Film("Test", 2000, "Action", 110, "Deutsch", false, 18);
            dbm.FilmHinzufuegen(testFilm);
            Vorstellung testVorstellung = new Vorstellung(testFilm, dbm.SaalLesen("Saal 1"), DateTime.Now);
            dbm.VorstellungHinzufuegen(testVorstellung);
            
            //Bestellung erzeugen
            bestellverwaltung.Reservieren(testKunde, testVorstellung);
            Assert.AreEqual(1, testKunde.Bestellungen.Count);
            //Beim Löschen der Vorstellung soll auch die Bestellung gelöscht werden
            dbm.VorstellungLoeschen(testVorstellung);
            Assert.AreEqual(0, testKunde.Bestellungen.Count);
            
            //Testdaten löschen
            dbm.FilmLoeschen(testFilm);
            dbm.KundeLoeschen(testKunde);
        }

        [TestMethod]
        public void TestSaalAusgebucht()
        {
            // Testdaten anlegen
            DatenbankManager dbm = DatenbankManager.Instance;
            Bestellverwaltung bestellverwaltung = new Bestellverwaltung(dbm);
            Kundenverwaltung kundenverwaltung = new Kundenverwaltung(dbm);
            Kunde testKunde;
            kundenverwaltung.KundeRegistrieren(Utils.HashPassword("9876"), "Cobain", "Kurt", new DateTime(1967, 3, 15), out testKunde);
            Film testFilm = new Film("Nirvana - Der Film", 2000, "Drama", 110, "Deutsch", false, 18);
            dbm.FilmHinzufuegen(testFilm);
            Saal testsaal = new Saal("MiniSaal", 20);
            dbm.SaalHinzufügen(testsaal);
            Vorstellung testVorstellung = new Vorstellung(testFilm, testsaal, DateTime.Now);
            dbm.VorstellungHinzufuegen(testVorstellung);

            // 20 Plätze buchen --> 20 mal Bestellung muss möglich sein
            bool check = false;
            for (int i = 0; i < 20; i++)
            {
                Bestellung testBestellung = bestellverwaltung.Reservieren(testKunde, testVorstellung);
                if (testBestellung == null)
                {
                    check = false;
                    return;
                }
                else
                    check = true;
            }
            Assert.IsTrue(check);

            // 21. Buchung muss fehlschlagen, da Saal dann ausgebucht
            try
            {
                bestellverwaltung.Reservieren(testKunde, testVorstellung);
                Assert.Fail();
            }
            catch (Exception)
            {
                check = false;
            }
            Assert.IsFalse(check);

            // Testdaten wieder löschen
            dbm.FilmLoeschen(testFilm);
            dbm.KundeLoeschen(testKunde);
            dbm.VorstellungLoeschen(testVorstellung);
            dbm.SaalLoeschen(testsaal);
        }
    }
}


