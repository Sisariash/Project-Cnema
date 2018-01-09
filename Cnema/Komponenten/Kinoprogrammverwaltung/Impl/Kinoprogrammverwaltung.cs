using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Komponenten.Datenbank;
using Komponenten.Datenbank.Impl;
using Komponenten.ET;

namespace Komponenten.Kinoprogrammverwaltung.Impl
{
    public class Kinoprogrammverwaltung : IKinoprogrammverwaltung
    {
        private IDatenbankManager datenbankManager = DatenbankManager.Instance;

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

        public bool FilmAendern(Film film)
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
            return datenbankManager.FilmLoeschen(film);
        }


        // Vorstellungen Logik

        public bool VorstellungHinzufuegen(DateTime zeitpunkt, Saal saal, Film film)
        {
            Vorstellung vorstellung = new Vorstellung();
            vorstellung.DateTime    = zeitpunkt;
            vorstellung.Film        = film;
            vorstellung.Saal        = saal;

            return datenbankManager.VorstellungHinzufuegen(vorstellung);
        }

        public bool VorstellungLoeschen(Vorstellung vorstellung)
        {
            datenbankManager.VorstellungLoeschen(vorstellung);
            return true;
        }

        public List<Vorstellung> AlleVorstellungenLesen()
        {
            return datenbankManager.AlleVorstellungenLesen();
        }

        //Saal Logik
        
        public List<Saal> SaeleLesen()
        {
            return datenbankManager.AlleSaeleLesen();
        }
    }
}
