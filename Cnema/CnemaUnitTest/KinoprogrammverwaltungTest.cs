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

        
        static IDatenbankManager datenbankManager = DatenbankManager.Instance;
        IKinoprogrammverwaltung kinoprogrammverwaltung = new Kinoprogrammverwaltung();

        //FilmTests
        [TestMethod]
        public void FilmTest()
        {
            datenbankManager.SaalLoeschen(datenbankManager.SaalLesen("Testsaal"));
            Film film = new Film("Test", 1996, "Action", 130, "Deutsch", false, 18);
            Assert.IsTrue(kinoprogrammverwaltung.FilmHinzufuegen(film));
            Saal saal = new Saal("Testsaal", 80);
            Assert.IsTrue(datenbankManager.SaalHinzufügen(saal));
            Vorstellung vorstellung = kinoprogrammverwaltung.VorstellungHinzufuegen(DateTime.Now, saal, film);
            Assert.IsTrue(kinoprogrammverwaltung.FilmLoeschen(film));
            Assert.IsTrue(datenbankManager.SaalLoeschen(saal));
        }


        [TestMethod]

        public void FilmHinzufuegenTest()
        {


            Film film1 = new Film("The Big Lebowski", 1998, "Komödie", 117, "Deutsch", false, 12, );
            Film film2 = new Film("Djumanji: Willkommen im Djungel (3D)", 2017, "Abenteuer", 119, "Deutsch", true, 12);
            Film film3 = new Film("Djumanji: Willkommen im Djungel", 2017, "Abenteuer", 119, "Deutsch", false, 12);
            Film film4 = new Film("Star Wars: Die letzen Jedi", 2017, "Science-Fiction", 152, "Deutsch", false, 12);
            Film film5 = new Film("Star Wars: The Last Jedi", 2017, "Science-Fiction", 152, "Englisch", false, 12);
            Film film6 = new Film("Jigsaw", 2017, "Horror", 92, "Deutsch", false, 18);
            Film film7 = new Film("Pokemon - Der Film", 1998, "Animation", 110, "Deutsch", false, 12);
            Film film8 = new Film("The Dark Knight", 2008, "Action", 152, "Deutsch", false, 16);
            Film film9 = new Film("Cars3", 2017, "Animation", 110, "Deutsch", false, 0);
            Film film10 = new Film("Bad Moms 2", 2017, "Komödie", 105, "Deutsch", false, 12);
            Film film11 = new Film("Der Pate", 1972, "Krimi", 175, "Deutsch", false, 16);
            Film film12 = new Film("Pulp Fiction", 1994, "Drama", 154, "Deutsch", false, 16);
            Film film13 = new Film("Yol Arkadasim (Türkisch)", 2017, "Komödie", 115, "Türkisch", false, 6);
            Film film14 = new Film("Paddington 2", 2017, "Animation", 104, "Deutsch", false, 0);
            Film film15 = new Film("The Commuter", 2017, "Thriller", 105, "Deutsch", false, 12);
            Film film16 = new Film("Greatest Showman", 2017, "Drama", 105, "Deutsch", false, 6);
            Film film17 = new Film("Greatest Showman (Englisch)", 2017, "Drama", 105, "Englisch", false, 6);
            Film film18 = new Film("Insidious: The Last Key", 2017, "Thriller", 104, "Deutsch", false, 16);
            Film film19 = new Film("Ayla (Türkisch)", 2017, "Drama", 124, "Türkisch", false, 12);
            Film film20 = new Film("Titanic", 1997, "Romanze", 104, "Deutsch", false, 12);
            Film film21 = new Film("Coco - Lebendiger als das Leben!", 2017, "Abenteuer", 10, "Deutsch", false, 0);
            Film film22 = new Film("Happy Deathday", 2017, "Horror", 97, "Deutsch", false, 12);
            Film film23 = new Film("Die Verurteilten", 1994, "Krimi", 144, "Deutsch", false, 12);
            Film film24 = new Film("Avatar - Aufbruch nach Pandora (3D)", 2009, "Fantasy", 162, "Deutsch", true, 12);
            Film film25 = new Film("Interstellar", 2014, "Abenteuer", 169, "Deutsch", false, 12);
            Film film26 = new Film("Mad Max: Fury Road (3D)", 2015, "Thriller", 121, "Deutsch", true, 16);
            Film film27 = new Film("Life of Pi: Schiffbruch mit Tiger (3D)", 2012, "Abenteuer", 127, "Deutsch", true, 12);
            Film film28 = new Film("Der Hobbit: Smaugs Einöde (3D) ", 2013, "Fantasy", 161, "Deutsch", true, 12);
            Film film29 = new Film("La La Land ", 2017, "Romanze", 128, "Deutsch", false, 12);
            Film film30 = new Film("Walk the Line) ", 2006, "Romanze", 136, "Deutsch", false, 12);

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
            kinoprogrammverwaltung.FilmHinzufuegen(film11);
            kinoprogrammverwaltung.FilmHinzufuegen(film12);
            kinoprogrammverwaltung.FilmHinzufuegen(film13);
            kinoprogrammverwaltung.FilmHinzufuegen(film14);
            kinoprogrammverwaltung.FilmHinzufuegen(film15);
            kinoprogrammverwaltung.FilmHinzufuegen(film16);
            kinoprogrammverwaltung.FilmHinzufuegen(film17);
            kinoprogrammverwaltung.FilmHinzufuegen(film18);
            kinoprogrammverwaltung.FilmHinzufuegen(film19);
            kinoprogrammverwaltung.FilmHinzufuegen(film20);
            kinoprogrammverwaltung.FilmHinzufuegen(film21);
            kinoprogrammverwaltung.FilmHinzufuegen(film22);
            kinoprogrammverwaltung.FilmHinzufuegen(film23);
            kinoprogrammverwaltung.FilmHinzufuegen(film24);
            kinoprogrammverwaltung.FilmHinzufuegen(film25);
            kinoprogrammverwaltung.FilmHinzufuegen(film26);
            kinoprogrammverwaltung.FilmHinzufuegen(film27);
            kinoprogrammverwaltung.FilmHinzufuegen(film28);
            kinoprogrammverwaltung.FilmHinzufuegen(film29);
            kinoprogrammverwaltung.FilmHinzufuegen(film30);





        }

        [TestMethod]

        public void FilmLoeschenTest()
        {

            //Immer Aktuelle ID zum Löschen nehmen
            Film film1 = kinoprogrammverwaltung.FilmLesen(1);
            kinoprogrammverwaltung.FilmLoeschen(film1);


            Film filmFromDb1 = kinoprogrammverwaltung.FilmLesen(1);
            Assert.IsNull(filmFromDb1);

            
        }

        [TestMethod]
        public void FilmAendernTest()
        {

            //Immer Aktuelle ID nehmen
            IKinoprogrammverwaltung kinoprogrammverwaltung = new Kinoprogrammverwaltung();

            
            Film film = kinoprogrammverwaltung.FilmLesen(69);
            film.Titel = "Parry Hotter";
            film.Jahr = 1998;

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

        
            Saal saalFromDb1 = datenbankManager.SaalLesen("saal1");
            Assert.IsNull(saalFromDb1);

        
        }
        //VorstellungTests
        [TestMethod]
        public void VorstellungHinzufuegenTest()
        {

            Film film1 = new Film("The Dark Knight", 2008, "Action", 152, "Deutsch", false, 16);
            Film film2 = new Film("Star Wars 7 (3D)", 2017, "Action", 287, "Deutsch", true, 6);
            Film film3 = new Film("Star Wars 7", 2017, "Action", 287, "Deutsch", false, 6);

            Saal saal1 = datenbankManager.SaalLesen("Saal1"); 
            Saal saal2 = datenbankManager.SaalLesen("Saal2"); 
            Saal saal3 = datenbankManager.SaalLesen("Saal3");  

            Vorstellung vorstellung1 = new Vorstellung(film1, saal1, new DateTime(2018, 01, 13, 18, 0, 0));
            Vorstellung vorstellung2 = new Vorstellung(film2, saal2, new DateTime(2018, 01, 13, 18, 0, 0));
            Vorstellung vorstellung3 = new Vorstellung(film3, saal1, new DateTime(2018, 01, 13, 18, 0, 0));

            bool vorstellungHinzufuegen1 = datenbankManager.VorstellungHinzufuegen(vorstellung1);
            bool vorstellungHinzufuegen2 = datenbankManager.VorstellungHinzufuegen(vorstellung2);
            bool vorstellungHinzufuegen3 = datenbankManager.VorstellungHinzufuegen(vorstellung3);

            // Cleaning
            datenbankManager.FilmLoeschen(film1);
            datenbankManager.FilmLoeschen(film2);
            datenbankManager.FilmLoeschen(film3);

            datenbankManager.VorstellungLoeschen(vorstellung1);
            datenbankManager.VorstellungLoeschen(vorstellung2);
            datenbankManager.VorstellungLoeschen(vorstellung3);

            Assert.IsTrue(vorstellungHinzufuegen1);
            Assert.IsTrue(vorstellungHinzufuegen2);
            Assert.IsFalse(vorstellungHinzufuegen3);
        }
    

    [TestMethod]

    public void VorstellungLoeschenTest()
    {

        //Immer Aktuelle Vorstellung ID nehmen
        Vorstellung vorstellung1 = datenbankManager.VorstellungLesen(67);
        datenbankManager.VorstellungLoeschen(vorstellung1);


        Vorstellung saalFromDb1 = datenbankManager.VorstellungLesen(67);
        Assert.IsNull(saalFromDb1);

     

    }

        [TestMethod]
        public void VorstellungAendernTest()
        {


            Saal saal1 = new Saal("MegaSaal", 150);
            

            Vorstellung vorstellung1 = datenbankManager.VorstellungLesen(61);
            vorstellung1.DateTime = DateTime.Now;
            vorstellung1.Saal = saal1;
            
        
    
        }
    }
}

