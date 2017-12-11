using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Komponenten.Datenbank;
using Komponenten.Kinoprogrammverwaltung.ET;

namespace CnemaUnitTest
{
    [TestClass]
    public class UnitTest4
    {
        [TestMethod]
        public void TestMethod1()
        {
            CnemaContext context = new CnemaContext();
            //Saal saal1 = new Saal("Saal1", 100);
            //context.Säle.Add(saal1);
            context.SaveChanges();
            Saal saal2 = context.Säle.Find("Saal1");
            Assert.IsNotNull(saal2);
        }
    }
}
