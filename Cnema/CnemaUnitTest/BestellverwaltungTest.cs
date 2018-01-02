using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Komponenten.Datenbank;
using Komponenten.ET;
using Komponenten.Bestellverwaltung.Impl;
using Komponenten.Kundenverwaltung.Impl;
using Komponenten.Datenbank.Impl;

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
            Kunde testKunde = dbm.KundeLesen(3);
            Vorstellung testVorstellung = dbm.VorstellungLesen(1);
            bestellverwaltung.Reservieren(testKunde, testVorstellung);
        }
    }
}
