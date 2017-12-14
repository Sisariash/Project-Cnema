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

        //FilmTests

        [TestMethod]

        public void FilmHinzufuegenTest()
        {


            Film film1 = new Film("The Dark Knight", 2008, "Action", 152, "Deutsch", false, 9.0, 16);
            Film film2 = new Film("Star Wars 7", 2017, "Action", 287, "Deutsch", true, 8.8, 6);
            Film film3 = new Film("Star Wars 7", 2017, "Action", 287, "Deutsch", false, 8.8, 6);
            Film film4 = new Film("Cars3", 2017, "Animation", 110, "Deutsch", false, 7.6, 0);
            Film film5 = new Film("Bad Moms 2", 2017, "Komödie", 105, "Deutsch", false, 7.0, 12);
            Film film6 = new Film("Jigsaw", 2017, "Horror", 92, "Deutsch", false, 8.2, 18);
            Film film7 = new Film("Der Pate", 1972, "Krimi", 175, "Deutsch", false, 9.2, 16);
            Film film8 = new Film("Pulp Fiction", 1994, "Drama", 154, "Deutsch", false, 8.9, 16);
            Film film9 = new Film("Yol Arkadasim", 2017, "Komödie", 115, "Türkisch", false, 7.0, 6);
            Film film10 = new Film("Paddington 2", 2017, "Annimation", 104, "Detusch", false, 6.0, 0);

           



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

        //SaalTests

        [TestMethod]
        public void SaalHinzufuegenTest()
        {


            Saal saal1 = new Saal("Saal1", 150);
            Saal saal2 = new Saal("Saal2", 100);
            Saal saal3 = new Saal("Saal3", 75);




            datenbankManager.SaalHinzufügen(saal1);
            datenbankManager.SaalHinzufügen(saal2);
            datenbankManager.SaalHinzufügen(saal3);

        }

        [TestMethod]

        public void SaalLoeschenTest()
        {


            Saal saal1 = datenbankManager.SaalLesen("saal1");
            datenbankManager.SaalLoeschen(saal1);

            Saal saal2 = datenbankManager.SaalLesen("saal2");
            datenbankManager.SaalLoeschen(saal2);

            Saal saal3 = datenbankManager.SaalLesen("saal3");
            datenbankManager.SaalLoeschen(saal3);





            Saal saalFromDb1 = datenbankManager.SaalLesen("saal1");
            Assert.IsNull(saalFromDb1);

            Saal saalFromDb2 = datenbankManager.SaalLesen("saal2");
            Assert.IsNull(saalFromDb2);

            Saal saalFromDb3 = datenbankManager.SaalLesen("saal3");
            Assert.IsNull(saalFromDb3);

        }
        //VorstellungTests
        [TestMethod]
        public void VorstellungHinzufuegenTest()
        {

            // Klappt nicht immer wieso? Fügt manchmal hinzu beim laufen lassen manchmal nicht 
            

            Film film1 = new Film("The Dark Knight", 2008, "Action", 152, "Deutsch", false, 9.0, 16);
            Film film2 = new Film("Star Wars 7", 2017, "Action", 287, "Deutsch", true, 8.8, 6);
            Film film3 = new Film("Star Wars 7", 2017, "Action", 287, "Deutsch", false, 8.8, 6);

            Saal saal1 = new Saal("Saal1", 150);
            Saal saal2 = new Saal("Saal2", 100);
            Saal saal3 = new Saal("Saal3", 75);

            
            Vorstellung vorstellung1 = new Vorstellung(film1, saal1, DateTime.Now);
            Vorstellung vorstellung2 = new Vorstellung(film2, saal2, DateTime.Now);
            Vorstellung vorstellung3 = new Vorstellung(film3, saal3, DateTime.Now);
           

            datenbankManager.VorstellungHinzufuegen(vorstellung1);
            datenbankManager.VorstellungHinzufuegen(vorstellung2);
            datenbankManager.VorstellungHinzufuegen(vorstellung3);
        }
    

    [TestMethod]

    public void VorstellungLoeschenTest()
    {


        Vorstellung vorstellung1 = datenbankManager.VorstellungLesen(10);
        datenbankManager.VorstellungLoeschen(vorstellung1);

        Vorstellung vorstellung2 = datenbankManager.VorstellungLesen(11);
         datenbankManager.VorstellungLoeschen(vorstellung2);

        Vorstellung vorstellung3 = datenbankManager.VorstellungLesen(12);
        datenbankManager.VorstellungLoeschen(vorstellung3);





        Vorstellung saalFromDb1 = datenbankManager.VorstellungLesen(10);
        Assert.IsNull(saalFromDb1);

        Vorstellung saalFromDb2 = datenbankManager.VorstellungLesen(11);
        Assert.IsNull(saalFromDb2);

        Vorstellung saalFromDb3 = datenbankManager.VorstellungLesen(12);
        Assert.IsNull(saalFromDb3);

    }

        [TestMethod]
        public void VorstellungAendernTest()
        {

            // Ist Grün aber passiert nichts???

            Saal saal1 = new Saal("MegaSaal", 150);
            

            Vorstellung vorstellung1 = datenbankManager.VorstellungLesen(15);
            vorstellung1.DateTime = DateTime.Now;
            vorstellung1.Saal = saal1;
            
        
    
        }
    }
}

