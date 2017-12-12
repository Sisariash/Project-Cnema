using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using Komponenten.Datenbank;
using Komponenten.ET;


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
            Benutzer a1 = new Admin("secret", "Admin1");

            Console.WriteLine("k1:" + k1.GetType().ToString() + k1.BenutzerId);
            Console.WriteLine("a1:" + a1.GetType().ToString() + a1.BenutzerId);

            Assert.IsFalse(k1.Equals(a1));
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
    }
}
