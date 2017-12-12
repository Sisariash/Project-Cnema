using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Komponenten.Kinoprogrammverwaltung;
using Komponenten.Kinoprogrammverwaltung.Impl;

using Komponenten.Datenbank;
using Microsoft.AspNet.Identity;
using Komponenten.ET;

namespace CnemaUnitTest
{
    [TestClass]
    public class KinoprogrammverwaltungTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Init Kinoprogramverwaltung
            IKinoprogrammverwaltung kinoprogrammverwaltung = new Kinoprogrammverwaltung();

            // Init film
            Film film = kinoprogrammverwaltung.FilmLesen(1);
            //film.FilmId = 123;
            film.Titel  = "Harry fslkdjasdfjlk";
            film.Jahr = 1998;
            // Set other attributes

            // Method to test
            Film geanderterFilm = kinoprogrammverwaltung.FilmLesen(film.FilmId);

            // Check conditions
            Assert.AreEqual(geanderterFilm.FilmId, film.FilmId);
            Assert.AreEqual(geanderterFilm.Titel, film.Titel);
            Assert.AreEqual(geanderterFilm.Jahr, film.Jahr);
        }

        [TestMethod]
        public void TestMethod2()
        {
            // Init Kinoprogramverwaltung
            IKinoprogrammverwaltung kinoprogrammverwaltung = new Kinoprogrammverwaltung();
            //int numberOfFilms = kinoprogrammverwaltung.getNumberOfFilms();

            // Init film
            Film film = new Film();
            //film.FilmId = 123;
            film.Titel = "Harry Potter";
            film.Jahr = 1999;
            // Set other attributes

            // Method to test
            kinoprogrammverwaltung.FilmHinzufuegen(film);

            Film filmFromDb = kinoprogrammverwaltung.FilmLesen(2);
            //int numberOfFilmsAfter = kinoprogrammverwaltung.getNumberOfFilms();

            // Check conditions
            //Assert.AreEqual(numberOfFilmsAfter, numberOfFilms + 1);
            Assert.IsNotNull(filmFromDb);
        }

        [TestMethod]
        public void TestHashing()
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
