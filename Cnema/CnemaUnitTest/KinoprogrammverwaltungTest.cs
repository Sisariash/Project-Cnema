using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Komponenten.Kinoprogrammverwaltung;
using Komponenten.Kinoprogrammverwaltung.Impl;

using Komponenten.Datenbank;
using Microsoft.AspNet.Identity;
using Komponenten.ET;
using Komponenten.Datenbank.Impl;


namespace CnemaUnitTest
{
    [TestClass]
    public class KinoprogrammverwaltungTest
    {

        IKinoprogrammverwaltung kinoprogrammverwaltung = new Kinoprogrammverwaltung();
        IDatenbankManager datenbankManager = new DatenbankManager();


        [TestMethod]

        public void FilmHinzufuegenTest()
        {

           
            Film film1  = new Film("The Dark Knight", 2008, "Action", 152, "Deutsch", false, 9.0, 16);
            Film film2  = new Film("Star Wars 7", 2017, "Action", 287, "Deutsch", true, 8.8, 6);
            Film film3  = new Film("Star Wars 7", 2017, "Action", 287, "Deutsch", false, 8.8, 6);
            Film film4  = new Film("Cars3", 2017, "Animation", 110, "Deutsch", false, 7.6, 0);
            Film film5  = new Film("Bad Moms 2", 2017, "Komödie", 105, "Deutsch", false, 7.0, 12);
            Film film6  = new Film("Jigsaw", 2017, "Horror", 92, "Deutsch", false, 8.2, 18);
            Film film7  = new Film("Der Pate", 1972, "Krimi", 175, "Deutsch", false, 9.2, 16);
            Film film8  = new Film("Pulp Fiction", 1994, "Drama", 154, "Deutsch", false, 8.9, 16);
            Film film9  = new Film("Yol Arkadasim", 2017, "Komödie", 115, "Türkisch", false, 7.0, 6);
            Film film10 = new Film("Paddington 2", 2017, "Annimation", 104, "Detusch", false, 6.0, 0);

            film1.FilmId = 1;
            film1.FilmId = 2;
            film1.FilmId = 3;
            film1.FilmId = 4;
            film1.FilmId = 5;
            film1.FilmId = 6;
            film1.FilmId = 7;
            film1.FilmId = 8;
            film1.FilmId = 9;
            film1.FilmId = 10;
            


            kinoprogrammverwaltung.FilmHinzufuegen(film1);
            kinoprogrammverwaltung.FilmHinzufuegen(film2);
            kinoprogrammverwaltung.FilmHinzufuegen(film3);
            kinoprogrammverwaltung.FilmHinzufuegen(film4);
            kinoprogrammverwaltung.FilmHinzufuegen(film5);
            kinoprogrammverwaltung.FilmHinzufuegen(film6);
            kinoprogrammverwaltung.FilmHinzufuegen(film7);
            kinoprogrammverwaltung.FilmHinzufuegen(film8);
            kinoprogrammverwaltung.FilmHinzufuegen(film9);
            kinoprogrammverwaltung.FilmHinzufuegen(film10);







        }  

        [TestMethod]

        public void FilmLoeschenTest()
        {

            
            Film film1 = kinoprogrammverwaltung.FilmLesen(1);
            kinoprogrammverwaltung.FilmLoeschen(film1);

            Film film2 = kinoprogrammverwaltung.FilmLesen(2);
            kinoprogrammverwaltung.FilmLoeschen(film2);

            Film film3 = kinoprogrammverwaltung.FilmLesen(3);
            kinoprogrammverwaltung.FilmLoeschen(film3);

            Film film4 = kinoprogrammverwaltung.FilmLesen(4);
            kinoprogrammverwaltung.FilmLoeschen(film4);

            Film film5 = kinoprogrammverwaltung.FilmLesen(5);
            kinoprogrammverwaltung.FilmLoeschen(film5);

            Film film6 = kinoprogrammverwaltung.FilmLesen(6);
            kinoprogrammverwaltung.FilmLoeschen(film6);

            Film film7 = kinoprogrammverwaltung.FilmLesen(7);
            kinoprogrammverwaltung.FilmLoeschen(film7);

            Film film8 = kinoprogrammverwaltung.FilmLesen(8);
            kinoprogrammverwaltung.FilmLoeschen(film8);

            Film film9 = kinoprogrammverwaltung.FilmLesen(9);
            kinoprogrammverwaltung.FilmLoeschen(film9);

            Film film10 = kinoprogrammverwaltung.FilmLesen(10);
            kinoprogrammverwaltung.FilmLoeschen(film10);

            
            Film filmFromDb1 = kinoprogrammverwaltung.FilmLesen(1);
            Assert.IsNull(filmFromDb1);

            Film filmFromDb2 = kinoprogrammverwaltung.FilmLesen(2);
            Assert.IsNull(filmFromDb2);

            Film filmFromDb3 = kinoprogrammverwaltung.FilmLesen(3);
            Assert.IsNull(filmFromDb3);

            Film filmFromDb4 = kinoprogrammverwaltung.FilmLesen(4);
            Assert.IsNull(filmFromDb4);

            Film filmFromDb5 = kinoprogrammverwaltung.FilmLesen(5);
            Assert.IsNull(filmFromDb5);

            Film filmFromDb6 = kinoprogrammverwaltung.FilmLesen(6);
            Assert.IsNull(filmFromDb6);

            Film filmFromDb7 = kinoprogrammverwaltung.FilmLesen(7);
            Assert.IsNull(filmFromDb7);

            Film filmFromDb8 = kinoprogrammverwaltung.FilmLesen(8);
            Assert.IsNull(filmFromDb8);

            Film filmFromDb9 = kinoprogrammverwaltung.FilmLesen(9);
            Assert.IsNull(filmFromDb9);





        }
        
        [TestMethod]
        public void FilmAendernTest()
        {
            // Init Kinoprogramverwaltung
            IKinoprogrammverwaltung kinoprogrammverwaltung = new Kinoprogrammverwaltung();

            // Init film
            Film film = kinoprogrammverwaltung.FilmLesen(2);
            film.Titel = "Parry Hotter";
            film.Jahr = 1998;
            // Set other attributes

            // Auskommentiert weil FilmeAendern nun bool zurückgibt (Charly)
            // Method to test
            //Film geanderterFilm = kinoprogrammverwaltung.FilmAendern(film);

            // Check conditions
            //Assert.AreEqual(geanderterFilm.FilmId, film.FilmId);
            //Assert.AreEqual(geanderterFilm.Titel, film.Titel);
            ///Assert.AreEqual(geanderterFilm.Jahr, film.Jahr);
        }

    }
}

