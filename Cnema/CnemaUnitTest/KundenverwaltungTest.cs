using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Komponenten.Kundenverwaltung.ET;
using System.Data.Entity;
using Komponenten.Datenbank;

namespace CnemaUnitTest
{
    [TestClass]
    public class KundenverwaltungTest
    {
        CnemaContext db = new CnemaContext();

        [TestMethod]
        public void PersonenAnlegenTest()
        {
            
            Kunde k1 = new Kunde("geheim", "charly", "herzog", new DateTime(1986, 10, 6));
        }
    }
}
