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
            Assert.IsTrue(kinoprogrammverwaltung.FilmLoeschen(film));
            Assert.IsTrue(datenbankManager.SaalLoeschen(saal));
        }


        [TestMethod]

        public void FilmHinzufuegenTest()
        {

            Film film1 = new Film("The Big Lebowski", 1998, "Komödie", 117, "Deutsch", false, 12);
            Film film2 = new Film("Djumanji: Willkommen im Djungel (3D)", 2017, "Abenteuer", 119, "Deutsch", true, 12);
            Film film3 = new Film("Djumanji: Willkommen im Djungel", 2017, "Abenteuer", 119, "Deutsch", false, 12);

            Assert.IsTrue(datenbankManager.FilmHinzufuegen(film1));
            Assert.IsTrue(datenbankManager.FilmHinzufuegen(film2));
            Assert.IsTrue(datenbankManager.FilmHinzufuegen(film3));

            Assert.IsTrue(datenbankManager.FilmLoeschen(film1));
            Assert.IsTrue(datenbankManager.FilmLoeschen(film2));
            Assert.IsTrue(datenbankManager.FilmLoeschen(film3));

            // Ein Film der nicht existiert, kann nicht gelöscht werden

            Film film4 = null;
            Assert.IsFalse(datenbankManager.FilmLoeschen(film4));
        }

        [TestMethod]

        public void FilmLoeschenTest()
        {

            Film film1 = new Film("The Big Lebowski", 1998, "Komödie", 117, "Deutsch", false, 12);
            datenbankManager.FilmHinzufuegen(film1);

            Assert.AreEqual(film1, datenbankManager.FilmLesen(film1.FilmId));
            Assert.IsTrue(datenbankManager.FilmLoeschen(film1));
        }

        [TestMethod]
        public void FilmAendernTest()
        {
            IKinoprogrammverwaltung kinoprogrammverwaltung = new Kinoprogrammverwaltung();

            Film film0 = new Film("The Big Lebowski", 1998, "Komödie", 117, "Deutsch", false, 12);
            kinoprogrammverwaltung.FilmHinzufuegen(film0);

            film0.Titel = "Test";
            film0.Jahr = 2012;

            kinoprogrammverwaltung.FilmAendern(film0);

            Film Testfilm = kinoprogrammverwaltung.FilmLesen(film0.FilmId);
            Assert.AreEqual("Test", Testfilm.Titel);
            Assert.AreEqual(2012, Testfilm.Jahr);

        }

        //SaalTests

        [TestMethod]
        public void SaalHinzufuegenTest()
        {

            Saal saal1 = new Saal("Saal1", 150);
            Saal saal2 = new Saal("Saal2", 100);
            Saal saal3 = new Saal("Saal3", 75);

            Assert.IsTrue(datenbankManager.SaalHinzufügen(saal1));
            Assert.IsTrue(datenbankManager.SaalHinzufügen(saal2));
            Assert.IsTrue(datenbankManager.SaalHinzufügen(saal3));

            datenbankManager.SaalLoeschen(saal1);
            datenbankManager.SaalLoeschen(saal2);
            datenbankManager.SaalLoeschen(saal3);

        }

        [TestMethod]

        public void SaalLoeschenTest()
        {
            Saal saal1 = new Saal("Saal1", 150);
            datenbankManager.SaalHinzufügen(saal1);
            datenbankManager.SaalLoeschen(saal1);

            Saal saalFromDb1 = datenbankManager.SaalLesen("Saal1");
            Assert.IsNull(saalFromDb1);

        }
        //VorstellungTests
        [TestMethod]
        public void VorstellungHinzufuegenTest()
        {

            Film film1 = new Film("The Dark Knight", 2008, "Action", 152, "Deutsch", false, 16);
            Film film2 = new Film("Star Wars 7 (3D)", 2017, "Action", 287, "Deutsch", true, 6);
            Film film3 = new Film("Star Wars 7", 2017, "Action", 287, "Deutsch", false, 6);

            datenbankManager.FilmHinzufuegen(film1);
            datenbankManager.FilmHinzufuegen(film2);
            datenbankManager.FilmHinzufuegen(film3);

            Saal saal1 = new Saal("Saal1", 150);
            Saal saal2 = new Saal("Saal2", 100);
            Saal saal3 = new Saal("Saal3", 75);

            Vorstellung vorstellung1 = new Vorstellung(film1, saal1, new DateTime(2018, 01, 13, 18, 0, 0));
            Vorstellung vorstellung2 = new Vorstellung(film2, saal2, new DateTime(2018, 01, 13, 18, 0, 0));
            Vorstellung vorstellung3 = new Vorstellung(film3, saal1, new DateTime(2018, 01, 13, 18, 0, 0));

            bool vorstellungHinzufuegen1 = datenbankManager.VorstellungHinzufuegen(vorstellung1);
            bool vorstellungHinzufuegen2 = datenbankManager.VorstellungHinzufuegen(vorstellung2);
            bool vorstellungHinzufuegen3 = datenbankManager.VorstellungHinzufuegen(vorstellung3);

            Assert.IsTrue(vorstellungHinzufuegen1);
            Assert.IsTrue(vorstellungHinzufuegen2);
            Assert.IsFalse(vorstellungHinzufuegen3);

            // Cleaning
            datenbankManager.FilmLoeschen(film1);
            datenbankManager.FilmLoeschen(film2);
            datenbankManager.FilmLoeschen(film3);

            datenbankManager.VorstellungLoeschen(vorstellung1);
            datenbankManager.VorstellungLoeschen(vorstellung2);
            datenbankManager.VorstellungLoeschen(vorstellung3);

            datenbankManager.SaalLoeschen(saal1);
            datenbankManager.SaalLoeschen(saal2);
            datenbankManager.SaalLoeschen(saal3);

        }


        [TestMethod]

        public void VorstellungLoeschenTest()
        {
            Film film1 = new Film("The Dark Knight", 2008, "Action", 152, "Deutsch", false, 16);
            Saal saal1 = new Saal("Saal1", 150);

            Vorstellung vorstellung1 = new Vorstellung(film1, saal1, new DateTime(2018, 01, 13, 18, 0, 0));
            datenbankManager.VorstellungHinzufuegen(vorstellung1);
            datenbankManager.VorstellungLoeschen(vorstellung1);

            Assert.IsNull(datenbankManager.VorstellungLesen(vorstellung1.VorstellungId));

            datenbankManager.SaalLoeschen(saal1);
            datenbankManager.FilmLoeschen(film1);

        }
    }
}

