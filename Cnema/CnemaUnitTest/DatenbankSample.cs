using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Komponenten.Datenbank;
using Komponenten.Datenbank.Impl;
using Komponenten.ET;
using Komponenten.Kundenverwaltung.Impl;

namespace CnemaUnitTest
{
    [TestClass]
    public class DatenbankSample
    {
        [TestMethod]
        public void CreateSample()
        {
            DatenbankManager db = DatenbankManager.Instance;

            //Alles löschen
            foreach (Kunde k in db.AlleKundenLesen()) db.KundeLoeschen(k);
            foreach (Admin a in db.AlleAdminsLesen()) db.AdminLoeschen(a);
            foreach (Bestellung b in db.AlleBestellungenLesen()) db.BestellungLoeschen(b);
            foreach (FilmBewertung fb in db.AlleFilmBewertungenLesen()) db.FilmBewertungLöschen(fb);
            foreach (Vorstellung v in db.AlleVorstellungenLesen()) db.VorstellungLoeschen(v);
            foreach (Film f in db.AlleFilmeLesen()) db.FilmLoeschen(f);
            foreach (Saal s in db.AlleSaeleLesen()) db.SaalLoeschen(s);

            //Beispieldaten hinzufügen für Präsentation

            // Admins
            // Admins müssen bereits vor Programmstart angelegt werden; würden in einer reale Anwendung nach dem ersten Start gelöscht und neu erstellt werden
            Admin admin = new Admin(Komponenten.Util.Utils.HashPassword("admin"), "Admin");
            db.AdminHinzufuegen(admin);

            Admin admin2 = new Admin(Komponenten.Util.Utils.HashPassword("admin2"), "Admin2");
            db.AdminHinzufuegen(admin2);

            //Kunden

            Kunde kunde1 = new Kunde(Komponenten.Util.Utils.HashPassword("123"), "Güloglu", "Osman", new DateTime(1991,08,11));
            db.KundeHinzufuegen(kunde1);

            Kunde kunde2 = new Kunde(Komponenten.Util.Utils.HashPassword("456"), "Herzog", "Karl", new DateTime(1986, 06, 10));
            db.KundeHinzufuegen(kunde2);

            Kunde kunde3 = new Kunde(Komponenten.Util.Utils.HashPassword("789"), "Hamberger", "Jonathan", new DateTime(1996, 04, 27));
            db.KundeHinzufuegen(kunde3);

            // Säle
            Saal saal1 = new Saal("Saal 1", 150);
            Saal saal2 = new Saal("Saal 2", 100);
            Saal saal3 = new Saal("Saal 3", 80);
            db.SaalHinzufügen(saal1);
            db.SaalHinzufügen(saal2);
            db.SaalHinzufügen(saal3);

            // Filme
            Film film1 = new Film("The Big Lebowski", 1998, "Komödie", 117, "Deutsch", false, 12);
            Film film2 = new Film("Djumanji: Willkommen im Djungel (3D)", 2017, "Abenteuer", 119, "Deutsch", true, 12);
            Film film3 = new Film("Djumanji: Willkommen im Djungel", 2017, "Abenteuer", 119, "Deutsch", false, 12);
            Film film4 = new Film("Star Wars: Die letzen Jedi", 2017, "Science-Fiction", 152, "Deutsch", false, 12);
            Film film5 = new Film("Star Wars: The Last Jedi(Englisch)", 2017, "Science-Fiction", 152, "Englisch", false, 12);
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
            Film film28 = new Film("Der Hobbit: Smaugs Einöde (3D)", 2013, "Fantasy", 161, "Deutsch", true, 12);
            Film film29 = new Film("La La Land", 2017, "Romanze", 128, "Deutsch", false, 12);
            Film film30 = new Film("Walk the Line", 2006, "Romanze", 136, "Deutsch", false, 12);
            Film film31 = new Film("Gladiator", 2000, "Action", 171, "Deutsch", false, 16);
            Film film32 = new Film("The Last Samurai (Englisch)", 2003, "Abenteuer", 154, "Englisch", false, 16);
            Film film33 = new Film("Es (3D)", 2017, "Horror", 135, "Deutsch", true, 16);
            Film film34 = new Film("Sherlock Holmes", 2009, "Krimi", 128, "Deutsch", false, 12);
            Film film35 = new Film("Die Passion Christi", 2004, "Drama", 127, "Deutsch", false, 16);
 
            db.FilmHinzufuegen(film1);
            db.FilmHinzufuegen(film2);
            db.FilmHinzufuegen(film3);
            db.FilmHinzufuegen(film4);
            db.FilmHinzufuegen(film5);
            db.FilmHinzufuegen(film6);
            db.FilmHinzufuegen(film7);
            db.FilmHinzufuegen(film8);
            db.FilmHinzufuegen(film9);
            db.FilmHinzufuegen(film10);
            db.FilmHinzufuegen(film11);
            db.FilmHinzufuegen(film12);
            db.FilmHinzufuegen(film13);
            db.FilmHinzufuegen(film14);
            db.FilmHinzufuegen(film15);
            db.FilmHinzufuegen(film16);
            db.FilmHinzufuegen(film17);
            db.FilmHinzufuegen(film18);
            db.FilmHinzufuegen(film19);
            db.FilmHinzufuegen(film20);
            db.FilmHinzufuegen(film21);
            db.FilmHinzufuegen(film22);
            db.FilmHinzufuegen(film23);
            db.FilmHinzufuegen(film24);
            db.FilmHinzufuegen(film25);
            db.FilmHinzufuegen(film26);
            db.FilmHinzufuegen(film27);
            db.FilmHinzufuegen(film28);
            db.FilmHinzufuegen(film29);
            db.FilmHinzufuegen(film30);
            db.FilmHinzufuegen(film31);
            db.FilmHinzufuegen(film32);
            db.FilmHinzufuegen(film33);
            db.FilmHinzufuegen(film34);
            db.FilmHinzufuegen(film35);


            // Vorstellung

            //23.01
            Vorstellung v1 = new Vorstellung(film1, saal1, new DateTime(2018, 01, 23, 15, 30, 0));
            Vorstellung v2 = new Vorstellung(film2, saal1, new DateTime(2018, 01, 23, 17, 0, 0));
            Vorstellung v3 = new Vorstellung(film3, saal1, new DateTime(2018, 01, 23, 20, 0, 0));
            Vorstellung v4 = new Vorstellung(film4, saal1, new DateTime(2018, 01, 23, 22, 0, 0));
            Vorstellung v5 = new Vorstellung(film5, saal1, new DateTime(2018, 01, 23, 11, 0, 0));
            Vorstellung v6 = new Vorstellung(film6, saal2, new DateTime(2018, 01, 23, 15, 30, 0));
            Vorstellung v7 = new Vorstellung(film7, saal2, new DateTime(2018, 01, 23, 17, 0, 0));
            Vorstellung v8 = new Vorstellung(film8, saal2, new DateTime(2018, 01, 23, 20, 0, 0));
            Vorstellung v9 = new Vorstellung(film9, saal2, new DateTime(2018, 01, 23, 22, 0, 0));
            Vorstellung v10 = new Vorstellung(film10, saal2, new DateTime(2018, 01, 23, 11, 0, 0));
            Vorstellung v11 = new Vorstellung(film11, saal3, new DateTime(2018, 01, 23, 15, 30, 0));
            Vorstellung v12 = new Vorstellung(film12, saal3, new DateTime(2018, 01, 23, 17, 0, 0));
            Vorstellung v13 = new Vorstellung(film13, saal3, new DateTime(2018, 01, 23, 20, 0, 0));
            Vorstellung v14 = new Vorstellung(film14, saal3, new DateTime(2018, 01, 23, 22, 0, 0));
            Vorstellung v15 = new Vorstellung(film15, saal3, new DateTime(2018, 01, 23, 11, 0, 0));

            //24.01
            Vorstellung v16 = new Vorstellung(film16, saal1, new DateTime(2018, 01, 24, 15, 30, 0));
            Vorstellung v17 = new Vorstellung(film17, saal1, new DateTime(2018, 01, 24, 17, 0, 0));
            Vorstellung v18 = new Vorstellung(film18, saal1, new DateTime(2018, 01, 24, 20, 0, 0));
            Vorstellung v19 = new Vorstellung(film19, saal1, new DateTime(2018, 01, 24, 22, 0, 0));
            Vorstellung v20 = new Vorstellung(film20, saal1, new DateTime(2018, 01, 24, 11, 0, 0));
            Vorstellung v21 = new Vorstellung(film21, saal2, new DateTime(2018, 01, 24, 15, 30, 0));
            Vorstellung v22 = new Vorstellung(film22, saal2, new DateTime(2018, 01, 24, 17, 0, 0));
            Vorstellung v23 = new Vorstellung(film23, saal2, new DateTime(2018, 01, 24, 20, 0, 0));
            Vorstellung v24 = new Vorstellung(film24, saal2, new DateTime(2018, 01, 24, 22, 0, 0));
            Vorstellung v25 = new Vorstellung(film25, saal2, new DateTime(2018, 01, 24, 11, 0, 0));
            Vorstellung v26 = new Vorstellung(film26, saal3, new DateTime(2018, 01, 24, 15, 30, 0));
            Vorstellung v27 = new Vorstellung(film27, saal3, new DateTime(2018, 01, 24, 17, 0, 0));
            Vorstellung v28 = new Vorstellung(film28, saal3, new DateTime(2018, 01, 24, 20, 0, 0));
            Vorstellung v29 = new Vorstellung(film29, saal3, new DateTime(2018, 01, 24, 22, 0, 0));
            Vorstellung v30 = new Vorstellung(film30, saal3, new DateTime(2018, 01, 24, 11, 0, 0));

            //25.01
            Vorstellung v31 = new Vorstellung(film1, saal1, new DateTime(2018, 01, 25, 15, 30, 0));
            Vorstellung v32 = new Vorstellung(film2, saal1, new DateTime(2018, 01, 25, 17, 0, 0));
            Vorstellung v33 = new Vorstellung(film3, saal1, new DateTime(2018, 01, 25, 20, 0, 0));
            Vorstellung v34 = new Vorstellung(film4, saal1, new DateTime(2018, 01, 25, 22, 0, 0));
            Vorstellung v35 = new Vorstellung(film5, saal1, new DateTime(2018, 01, 25, 11, 0, 0));
            Vorstellung v36 = new Vorstellung(film6, saal2, new DateTime(2018, 01, 25, 15, 30, 0));
            Vorstellung v37 = new Vorstellung(film7, saal2, new DateTime(2018, 01, 25, 17, 0, 0));
            Vorstellung v38 = new Vorstellung(film8, saal2, new DateTime(2018, 01, 25, 20, 0, 0));
            Vorstellung v39 = new Vorstellung(film9, saal2, new DateTime(2018, 01, 25, 22, 0, 0));
            Vorstellung v40 = new Vorstellung(film10, saal2, new DateTime(2018, 01, 25, 11, 0, 0));
            Vorstellung v41 = new Vorstellung(film11, saal3, new DateTime(2018, 01, 25, 15, 30, 0));
            Vorstellung v42 = new Vorstellung(film12, saal3, new DateTime(2018, 01, 25, 17, 0, 0));
            Vorstellung v43 = new Vorstellung(film13, saal3, new DateTime(2018, 01, 25, 20, 0, 0));
            Vorstellung v44 = new Vorstellung(film14, saal3, new DateTime(2018, 01, 25, 22, 0, 0));
            Vorstellung v45 = new Vorstellung(film15, saal3, new DateTime(2018, 01, 25, 11, 0, 0));

            //26.01

            Vorstellung v46 = new Vorstellung(film16, saal1, new DateTime(2018, 01, 26, 15, 30, 0));
            Vorstellung v47 = new Vorstellung(film17, saal1, new DateTime(2018, 01, 26, 17, 0, 0));
            Vorstellung v48 = new Vorstellung(film18, saal1, new DateTime(2018, 01, 26, 20, 0, 0));
            Vorstellung v49 = new Vorstellung(film19, saal1, new DateTime(2018, 01, 26, 22, 0, 0));
            Vorstellung v50 = new Vorstellung(film20, saal1, new DateTime(2018, 01, 26, 11, 0, 0));
            Vorstellung v51 = new Vorstellung(film21, saal2, new DateTime(2018, 01, 26, 15, 30, 0));
            Vorstellung v52 = new Vorstellung(film22, saal2, new DateTime(2018, 01, 26, 17, 0, 0));
            Vorstellung v53 = new Vorstellung(film23, saal2, new DateTime(2018, 01, 26, 20, 0, 0));
            Vorstellung v54 = new Vorstellung(film24, saal2, new DateTime(2018, 01, 26, 22, 0, 0));
            Vorstellung v55 = new Vorstellung(film25, saal2, new DateTime(2018, 01, 26, 11, 0, 0));
            Vorstellung v56 = new Vorstellung(film26, saal3, new DateTime(2018, 01, 26, 15, 30, 0));
            Vorstellung v57 = new Vorstellung(film27, saal3, new DateTime(2018, 01, 26, 17, 0, 0));
            Vorstellung v58 = new Vorstellung(film28, saal3, new DateTime(2018, 01, 26, 20, 0, 0));
            Vorstellung v59 = new Vorstellung(film29, saal3, new DateTime(2018, 01, 26, 22, 0, 0));
            Vorstellung v60 = new Vorstellung(film30, saal3, new DateTime(2018, 01, 26, 11, 0, 0));

            //27.01

            Vorstellung v61 = new Vorstellung(film7, saal1, new DateTime(2018, 01, 27, 15, 30, 0));
            Vorstellung v62 = new Vorstellung(film2, saal1, new DateTime(2018, 01, 27, 17, 0, 0));
            Vorstellung v63 = new Vorstellung(film3, saal1, new DateTime(2018, 01, 27, 20, 0, 0));
            Vorstellung v64 = new Vorstellung(film4, saal1, new DateTime(2018, 01, 27, 22, 0, 0));
            Vorstellung v65 = new Vorstellung(film9, saal1, new DateTime(2018, 01, 27, 11, 0, 0));
            Vorstellung v66 = new Vorstellung(film27, saal2, new DateTime(2018, 01, 27, 15, 30, 0));
            Vorstellung v67 = new Vorstellung(film7, saal2, new DateTime(2018, 01, 27, 17, 0, 0));
            Vorstellung v68 = new Vorstellung(film8, saal2, new DateTime(2018, 01, 27, 20, 0, 0));
            Vorstellung v69 = new Vorstellung(film9, saal2, new DateTime(2018, 01, 27, 22, 0, 0));
            Vorstellung v70 = new Vorstellung(film7, saal2, new DateTime(2018, 01, 27, 11, 0, 0));
            Vorstellung v71 = new Vorstellung(film11, saal3, new DateTime(2018, 01, 27, 15, 30, 0));
            Vorstellung v72 = new Vorstellung(film12, saal3, new DateTime(2018, 01, 27, 17, 0, 0));
            Vorstellung v73 = new Vorstellung(film13, saal3, new DateTime(2018, 01, 27, 20, 0, 0));
            Vorstellung v74 = new Vorstellung(film14, saal3, new DateTime(2018, 01, 27, 22, 0, 0));
            Vorstellung v75 = new Vorstellung(film21, saal3, new DateTime(2018, 01, 27, 11, 0, 0));

            //28.01
            Vorstellung v76 = new Vorstellung(film31, saal1, new DateTime(2018, 01, 28, 15, 30, 0));
            Vorstellung v77 = new Vorstellung(film32, saal1, new DateTime(2018, 01, 28, 17, 0, 0));
            Vorstellung v78 = new Vorstellung(film33, saal1, new DateTime(2018, 01, 28, 20, 0, 0));
            Vorstellung v79 = new Vorstellung(film34, saal1, new DateTime(2018, 01, 28, 22, 0, 0));
            Vorstellung v80 = new Vorstellung(film35, saal1, new DateTime(2018, 01, 28, 11, 0, 0));
            Vorstellung v81 = new Vorstellung(film21, saal2, new DateTime(2018, 01, 28, 15, 30, 0));
            Vorstellung v82 = new Vorstellung(film22, saal2, new DateTime(2018, 01, 28, 17, 0, 0));
            Vorstellung v83 = new Vorstellung(film23, saal2, new DateTime(2018, 01, 28, 20, 0, 0));
            Vorstellung v84 = new Vorstellung(film24, saal2, new DateTime(2018, 01, 28, 22, 0, 0));
            Vorstellung v85 = new Vorstellung(film25, saal2, new DateTime(2018, 01, 28, 11, 0, 0));
            Vorstellung v86 = new Vorstellung(film26, saal3, new DateTime(2018, 01, 28, 15, 30, 0));
            Vorstellung v87 = new Vorstellung(film27, saal3, new DateTime(2018, 01, 28, 17, 0, 0));
            Vorstellung v88 = new Vorstellung(film28, saal3, new DateTime(2018, 01, 28, 20, 0, 0));
            Vorstellung v89 = new Vorstellung(film29, saal3, new DateTime(2018, 01, 28, 22, 0, 0));
            Vorstellung v90 = new Vorstellung(film30, saal3, new DateTime(2018, 01, 28, 11, 0, 0));

            //29.01

            Vorstellung v91 = new Vorstellung(film1, saal1, new DateTime(2018, 01, 29, 15, 30, 0));
            Vorstellung v92 = new Vorstellung(film2, saal1, new DateTime(2018, 01, 29, 17, 0, 0));
            Vorstellung v93 = new Vorstellung(film3, saal1, new DateTime(2018, 01, 29, 20, 0, 0));
            Vorstellung v94 = new Vorstellung(film4, saal1, new DateTime(2018, 01, 29, 22, 0, 0));
            Vorstellung v95 = new Vorstellung(film5, saal1, new DateTime(2018, 01, 29, 11, 0, 0));
            Vorstellung v96 = new Vorstellung(film6, saal2, new DateTime(2018, 01, 29, 15, 30, 0));
            Vorstellung v97 = new Vorstellung(film7, saal2, new DateTime(2018, 01, 29, 17, 0, 0));
            Vorstellung v98 = new Vorstellung(film8, saal2, new DateTime(2018, 01, 29, 20, 0, 0));
            Vorstellung v99 = new Vorstellung(film9, saal2, new DateTime(2018, 01, 29, 22, 0, 0));
            Vorstellung v100 = new Vorstellung(film10, saal2, new DateTime(2018, 01, 29, 11, 0, 0));
            Vorstellung v101 = new Vorstellung(film11, saal3, new DateTime(2018, 01, 29, 15, 30, 0));
            Vorstellung v102 = new Vorstellung(film12, saal3, new DateTime(2018, 01, 29, 17, 0, 0));
            Vorstellung v103 = new Vorstellung(film13, saal3, new DateTime(2018, 01, 29, 20, 0, 0));
            Vorstellung v104 = new Vorstellung(film14, saal3, new DateTime(2018, 01, 29, 22, 0, 0));
            Vorstellung v105 = new Vorstellung(film15, saal3, new DateTime(2018, 01, 29, 11, 0, 0));


            //30.01

            Vorstellung v106 = new Vorstellung(film16, saal1, new DateTime(2018, 01, 30, 15, 30, 0));
            Vorstellung v107 = new Vorstellung(film17, saal1, new DateTime(2018, 01, 30, 17, 0, 0));
            Vorstellung v108 = new Vorstellung(film18, saal1, new DateTime(2018, 01, 30, 20, 0, 0));
            Vorstellung v109 = new Vorstellung(film19, saal1, new DateTime(2018, 01, 30, 22, 0, 0));
            Vorstellung v110 = new Vorstellung(film20, saal1, new DateTime(2018, 01, 30, 11, 0, 0));
            Vorstellung v111 = new Vorstellung(film21, saal2, new DateTime(2018, 01, 30, 15, 30, 0));
            Vorstellung v112 = new Vorstellung(film22, saal2, new DateTime(2018, 01, 30, 17, 0, 0));
            Vorstellung v113 = new Vorstellung(film23, saal2, new DateTime(2018, 01, 30, 20, 0, 0));
            Vorstellung v114 = new Vorstellung(film24, saal2, new DateTime(2018, 01, 30, 22, 0, 0));
            Vorstellung v115 = new Vorstellung(film25, saal2, new DateTime(2018, 01, 30, 11, 0, 0));
            Vorstellung v116 = new Vorstellung(film26, saal3, new DateTime(2018, 01, 30, 15, 30, 0));
            Vorstellung v117 = new Vorstellung(film27, saal3, new DateTime(2018, 01, 30, 17, 0, 0));
            Vorstellung v118 = new Vorstellung(film28, saal3, new DateTime(2018, 01, 30, 20, 0, 0));
            Vorstellung v119 = new Vorstellung(film29, saal3, new DateTime(2018, 01, 30, 22, 0, 0));
            Vorstellung v120 = new Vorstellung(film30, saal3, new DateTime(2018, 01, 30, 11, 0, 0));

            //31.01

            Vorstellung v121 = new Vorstellung(film31, saal1, new DateTime(2018, 01, 31, 15, 30, 0));
            Vorstellung v122 = new Vorstellung(film32, saal1, new DateTime(2018, 01, 31, 17, 0, 0));
            Vorstellung v123 = new Vorstellung(film33, saal1, new DateTime(2018, 01, 31, 20, 0, 0));
            Vorstellung v124 = new Vorstellung(film34, saal1, new DateTime(2018, 01, 31, 22, 0, 0));
            Vorstellung v125 = new Vorstellung(film35, saal1, new DateTime(2018, 01, 31, 11, 0, 0));
            Vorstellung v126 = new Vorstellung(film21, saal2, new DateTime(2018, 01, 31, 15, 30, 0));
            Vorstellung v127 = new Vorstellung(film22, saal2, new DateTime(2018, 01, 31, 17, 0, 0));
            Vorstellung v128 = new Vorstellung(film23, saal2, new DateTime(2018, 01, 31, 20, 0, 0));
            Vorstellung v129 = new Vorstellung(film24, saal2, new DateTime(2018, 01, 31, 22, 0, 0));
            Vorstellung v130 = new Vorstellung(film25, saal2, new DateTime(2018, 01, 31, 11, 0, 0));
            Vorstellung v131 = new Vorstellung(film26, saal3, new DateTime(2018, 01, 31, 15, 30, 0));
            Vorstellung v132 = new Vorstellung(film27, saal3, new DateTime(2018, 01, 31, 17, 0, 0));
            Vorstellung v133 = new Vorstellung(film28, saal3, new DateTime(2018, 01, 31, 20, 0, 0));
            Vorstellung v134 = new Vorstellung(film29, saal3, new DateTime(2018, 01, 31, 22, 0, 0));
            Vorstellung v135 = new Vorstellung(film30, saal3, new DateTime(2018, 01, 31, 11, 0, 0));

            //01.02
            Vorstellung v136 = new Vorstellung(film1, saal1, new DateTime(2018, 02, 01, 15, 30, 0));
            Vorstellung v137 = new Vorstellung(film2, saal1, new DateTime(2018, 02, 01, 17, 0, 0));
            Vorstellung v138 = new Vorstellung(film3, saal1, new DateTime(2018, 02, 01, 20, 0, 0));
            Vorstellung v139 = new Vorstellung(film4, saal1, new DateTime(2018, 02, 01, 22, 0, 0));
            Vorstellung v140 = new Vorstellung(film5, saal1, new DateTime(2018, 02, 01, 11, 0, 0));
            Vorstellung v141 = new Vorstellung(film6, saal2, new DateTime(2018, 02, 01, 15, 30, 0));
            Vorstellung v142 = new Vorstellung(film7, saal2, new DateTime(2018, 02, 01, 17, 0, 0));
            Vorstellung v143 = new Vorstellung(film8, saal2, new DateTime(2018, 02, 01, 20, 0, 0));
            Vorstellung v144 = new Vorstellung(film9, saal2, new DateTime(2018, 02, 01, 22, 0, 0));
            Vorstellung v145 = new Vorstellung(film10, saal2, new DateTime(2018, 02, 01, 11, 0, 0));
            Vorstellung v146 = new Vorstellung(film11, saal3, new DateTime(2018, 02, 01, 15, 30, 0));
            Vorstellung v147 = new Vorstellung(film12, saal3, new DateTime(2018, 02, 01, 17, 0, 0));
            Vorstellung v148 = new Vorstellung(film13, saal3, new DateTime(2018, 02, 01, 20, 0, 0));
            Vorstellung v149 = new Vorstellung(film14, saal3, new DateTime(2018, 02, 01, 22, 0, 0));
            Vorstellung v150 = new Vorstellung(film15, saal3, new DateTime(2018, 02, 01, 11, 0, 0));


            db.VorstellungHinzufuegen(v1);
            db.VorstellungHinzufuegen(v2);
            db.VorstellungHinzufuegen(v3);
            db.VorstellungHinzufuegen(v4);
            db.VorstellungHinzufuegen(v5);
            db.VorstellungHinzufuegen(v6);
            db.VorstellungHinzufuegen(v7);
            db.VorstellungHinzufuegen(v8); 
            db.VorstellungHinzufuegen(v9);
            db.VorstellungHinzufuegen(v10);
            db.VorstellungHinzufuegen(v11);
            db.VorstellungHinzufuegen(v12);
            db.VorstellungHinzufuegen(v13);
            db.VorstellungHinzufuegen(v14);
            db.VorstellungHinzufuegen(v15);
            db.VorstellungHinzufuegen(v16);
            db.VorstellungHinzufuegen(v17);
            db.VorstellungHinzufuegen(v18);
            db.VorstellungHinzufuegen(v19);
            db.VorstellungHinzufuegen(v20);
            db.VorstellungHinzufuegen(v21);
            db.VorstellungHinzufuegen(v22);
            db.VorstellungHinzufuegen(v23);
            db.VorstellungHinzufuegen(v24);
            db.VorstellungHinzufuegen(v25);
            db.VorstellungHinzufuegen(v26);
            db.VorstellungHinzufuegen(v27);
            db.VorstellungHinzufuegen(v28);
            db.VorstellungHinzufuegen(v29);
            db.VorstellungHinzufuegen(v30);
            db.VorstellungHinzufuegen(v31);
            db.VorstellungHinzufuegen(v32);
            db.VorstellungHinzufuegen(v33);
            db.VorstellungHinzufuegen(v34);
            db.VorstellungHinzufuegen(v35);
            db.VorstellungHinzufuegen(v36);
            db.VorstellungHinzufuegen(v37);
            db.VorstellungHinzufuegen(v38);
            db.VorstellungHinzufuegen(v39);
            db.VorstellungHinzufuegen(v40);
            db.VorstellungHinzufuegen(v41);
            db.VorstellungHinzufuegen(v42);
            db.VorstellungHinzufuegen(v43);
            db.VorstellungHinzufuegen(v44);
            db.VorstellungHinzufuegen(v45);
            db.VorstellungHinzufuegen(v46);
            db.VorstellungHinzufuegen(v47);
            db.VorstellungHinzufuegen(v48);
            db.VorstellungHinzufuegen(v49);
            db.VorstellungHinzufuegen(v50);
            db.VorstellungHinzufuegen(v51);
            db.VorstellungHinzufuegen(v52);
            db.VorstellungHinzufuegen(v53);
            db.VorstellungHinzufuegen(v54);
            db.VorstellungHinzufuegen(v55);
            db.VorstellungHinzufuegen(v56);
            db.VorstellungHinzufuegen(v57);
            db.VorstellungHinzufuegen(v58);
            db.VorstellungHinzufuegen(v59);
            db.VorstellungHinzufuegen(v60);
            db.VorstellungHinzufuegen(v61);
            db.VorstellungHinzufuegen(v62);
            db.VorstellungHinzufuegen(v63);
            db.VorstellungHinzufuegen(v64);
            db.VorstellungHinzufuegen(v65);
            db.VorstellungHinzufuegen(v66);
            db.VorstellungHinzufuegen(v67);
            db.VorstellungHinzufuegen(v68);
            db.VorstellungHinzufuegen(v69);
            db.VorstellungHinzufuegen(v70);
            db.VorstellungHinzufuegen(v71);
            db.VorstellungHinzufuegen(v72);
            db.VorstellungHinzufuegen(v73);
            db.VorstellungHinzufuegen(v74);
            db.VorstellungHinzufuegen(v75);
            db.VorstellungHinzufuegen(v76);
            db.VorstellungHinzufuegen(v77);
            db.VorstellungHinzufuegen(v78);
            db.VorstellungHinzufuegen(v79);
            db.VorstellungHinzufuegen(v80);
            db.VorstellungHinzufuegen(v81);
            db.VorstellungHinzufuegen(v82);
            db.VorstellungHinzufuegen(v83);
            db.VorstellungHinzufuegen(v84);
            db.VorstellungHinzufuegen(v85);
            db.VorstellungHinzufuegen(v86);
            db.VorstellungHinzufuegen(v87);
            db.VorstellungHinzufuegen(v88);
            db.VorstellungHinzufuegen(v90);
            db.VorstellungHinzufuegen(v91);
            db.VorstellungHinzufuegen(v92);
            db.VorstellungHinzufuegen(v93);
            db.VorstellungHinzufuegen(v94);
            db.VorstellungHinzufuegen(v95);
            db.VorstellungHinzufuegen(v96);
            db.VorstellungHinzufuegen(v97);
            db.VorstellungHinzufuegen(v98);
            db.VorstellungHinzufuegen(v99);
            db.VorstellungHinzufuegen(v100);
            db.VorstellungHinzufuegen(v100);
            db.VorstellungHinzufuegen(v101);
            db.VorstellungHinzufuegen(v102);
            db.VorstellungHinzufuegen(v103);
            db.VorstellungHinzufuegen(v104);
            db.VorstellungHinzufuegen(v105);
            db.VorstellungHinzufuegen(v106);
            db.VorstellungHinzufuegen(v107);
            db.VorstellungHinzufuegen(v108);
            db.VorstellungHinzufuegen(v109);
            db.VorstellungHinzufuegen(v110);
            db.VorstellungHinzufuegen(v111);
            db.VorstellungHinzufuegen(v112);
            db.VorstellungHinzufuegen(v113);
            db.VorstellungHinzufuegen(v114);
            db.VorstellungHinzufuegen(v115);
            db.VorstellungHinzufuegen(v116);
            db.VorstellungHinzufuegen(v117);
            db.VorstellungHinzufuegen(v118);
            db.VorstellungHinzufuegen(v119);
            db.VorstellungHinzufuegen(v120);
            db.VorstellungHinzufuegen(v121);
            db.VorstellungHinzufuegen(v122);
            db.VorstellungHinzufuegen(v123);
            db.VorstellungHinzufuegen(v124);
            db.VorstellungHinzufuegen(v125);
            db.VorstellungHinzufuegen(v126);
            db.VorstellungHinzufuegen(v127);
            db.VorstellungHinzufuegen(v128);
            db.VorstellungHinzufuegen(v129);
            db.VorstellungHinzufuegen(v130);
            db.VorstellungHinzufuegen(v131);
            db.VorstellungHinzufuegen(v132);
            db.VorstellungHinzufuegen(v133);
            db.VorstellungHinzufuegen(v134);
            db.VorstellungHinzufuegen(v135);
            db.VorstellungHinzufuegen(v136);
            db.VorstellungHinzufuegen(v137);
            db.VorstellungHinzufuegen(v138);
            db.VorstellungHinzufuegen(v139);
            db.VorstellungHinzufuegen(v140);
            db.VorstellungHinzufuegen(v141);
            db.VorstellungHinzufuegen(v142);
            db.VorstellungHinzufuegen(v143);
            db.VorstellungHinzufuegen(v144);
            db.VorstellungHinzufuegen(v145);
            db.VorstellungHinzufuegen(v146);
            db.VorstellungHinzufuegen(v147);
            db.VorstellungHinzufuegen(v148);
            db.VorstellungHinzufuegen(v149);
            db.VorstellungHinzufuegen(v150);


            // Filmbewertungen

            FilmBewertung fbw1 = new FilmBewertung(4);
            fbw1.Kunde = kunde1;
            fbw1.Film = film7;

            FilmBewertung fbw2 = new FilmBewertung(5);
            fbw2.Kunde = kunde2;
            fbw2.Film = film7;

            FilmBewertung fbw3 = new FilmBewertung(3);
            fbw3.Kunde = kunde3;
            fbw3.Film = film7;

            FilmBewertung fbw4 = new FilmBewertung(2);
            fbw4.Kunde = kunde1;
            fbw4.Film = film11;

            FilmBewertung fbw5 = new FilmBewertung(5);
            fbw5.Kunde = kunde3;
            fbw5.Film = film11;

            db.FilmBewertungHinzufügen(fbw1);
            db.FilmBewertungHinzufügen(fbw2);
            db.FilmBewertungHinzufügen(fbw3);
            db.FilmBewertungHinzufügen(fbw4);
            db.FilmBewertungHinzufügen(fbw5);

            // Nur für Testzwecke, um neuen Durchschnitt berechnen und in DB eintragen zu können
            Kundenverwaltung kv = new Kundenverwaltung();
            kv.DurchschnittBerechnen(film7);
            kv.DurchschnittBerechnen(film11);

        }
    }
}
