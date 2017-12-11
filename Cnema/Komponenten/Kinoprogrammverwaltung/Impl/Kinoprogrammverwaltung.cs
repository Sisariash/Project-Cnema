using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Komponenten.Kinoprogrammverwaltung.ET;
using Komponenten.Datenbank;
using Komponenten.Datenbank.Impl;
using Komponenten.Bestellverwaltung.ET;

namespace Komponenten.Kinoprogrammverwaltung.Impl
{
    public class Kinoprogrammverwaltung : IKinoprogrammverwaltung
    {
        private IDatenbankManager datenbankManager = new DatenbankManager();

        // Film Logik
        public Film FilmLesen(int id)
        {
            return datenbankManager.FilmLesen(id);
        }

        public List<Film> AlleFilmLesen()
        {
            return datenbankManager.AlleFilmeLesen();
        }

        public Film FilmAendern(Film film)
        {
            return datenbankManager.FilmAendern(film);
        }

        public bool FilmHinzufuegen(Film film)
        {
            datenbankManager.FilmHinzufuegen(film);
            return true;
        }

        public bool FilmLoeschen(Film film)
        {
            datenbankManager.FilmLoeschen(film);
            return true;
        }


        // Vorstellungen Logik

        public bool VorstellungHinzufuegen(DateTime zeitpunkt, Saal saal, Film film)
        {
            Vorstellung vorstellung = new Vorstellung();
            vorstellung.DateTime    = zeitpunkt;
            vorstellung.Film        = film;
            vorstellung.Saal        = saal;

            datenbankManager.VorstellungHinzufuegen(vorstellung);
            return true;
        }

        public bool VorstellungLoeschen(Vorstellung vorstellung)
        {
            datenbankManager.VorstellungLoeschen(vorstellung);
            return true;
        }
    }
}
