using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Komponenten.Datenbank;
using Komponenten.ET;


namespace CnemaUnitTest
{
    [TestClass]
    public class BestellverwaltungTest
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
