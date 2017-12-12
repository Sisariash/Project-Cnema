using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Komponenten.Datenbank;
using Komponenten.ET;
using Komponenten.Bestellverwaltung.Impl;
using Komponenten.Kundenverwaltung.Impl;

namespace CnemaUnitTest
{
    [TestClass]
    public class BestellverwaltungTest
    {
        [TestMethod]
        public void TestReservierung()
        {
            Bestellverwaltung bestellverwaltung = new Bestellverwaltung();
            Kundenverwaltung kundenverwaltung = new Kundenverwaltung();
            Kunde testKunde = new Kunde();
            kundenverwaltung.KundeRegistrieren(testKunde);
            Vorstellung testVorstellung = new Vorstellung();
            bestellverwaltung.Reservieren(testKunde, testVorstellung);
        }
    }
}
