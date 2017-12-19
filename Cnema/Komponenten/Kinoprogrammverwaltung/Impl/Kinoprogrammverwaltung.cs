using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Komponenten.Util;
using Komponenten.Util.Impl;
using Komponenten.ET;

namespace Komponenten.Kinoprogrammverwaltung.Impl
{
    public class Kinoprogrammverwaltung : IKinoprogrammverwaltung
    {
        private IDatenbankManager datenbankManager = new DatenbankManager();

        public Kinoprogrammverwaltung(IDatenbankManager datenbankManager)
        {
            this.datenbankManager = datenbankManager;
        }

        public Kinoprogrammverwaltung() { }

        // Film Logik
        public Film FilmLesen(int id)
        {
            return datenbankManager.FilmLesen(id);
        }

        public List<Film> AlleFilmLesen()
        {
            return datenbankManager.AlleFilmeLesen();
        }

        public bool FilmAendern()
        {
            return datenbankManager.FilmAendern();
        }

        public bool FilmHinzufuegen(Film film)
        {
            datenbankManager.FilmHinzufuegen(film);
            return true;
        }

        public bool FilmLoeschen(Film film)
        {
            return datenbankManager.FilmLoeschen(film);
        }


        // Vorstellungen Logik

        public Vorstellung VorstellungHinzufuegen(DateTime zeitpunkt, Saal saal, Film film)
        {
            Vorstellung vorstellung = new Vorstellung();
            vorstellung.DateTime    = zeitpunkt;
            vorstellung.Film        = film;
            vorstellung.Saal        = saal;

            datenbankManager.VorstellungHinzufuegen(vorstellung);
            return vorstellung;
        }

        public bool VorstellungLoeschen(Vorstellung vorstellung)
        {
            datenbankManager.VorstellungLoeschen(vorstellung);
            return true;
        }
    }
}
