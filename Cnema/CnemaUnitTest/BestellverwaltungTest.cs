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
    }
}
