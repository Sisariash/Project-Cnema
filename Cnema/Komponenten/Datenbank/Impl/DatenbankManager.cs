﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Komponenten.Kinoprogrammverwaltung.ET;
using Komponenten.Bestellverwaltung.ET;

namespace Komponenten.Datenbank.Impl
{
    class DatenbankManager: IDatenbankManager
    {

        private CnemaContext cnemaContext = new CnemaContext();

        // Filme
        public Film FilmLesen(int id)
        {
            Film film = cnemaContext.Filme.Find(id);
            return film;
        }

        public List<Film> AlleFilmeLesen()
        {
            return cnemaContext.Filme.ToList();
        }

        public Film FilmAendern(Film film)
        {
            cnemaContext.SaveChanges();
            return film;
        }

        public bool FilmHinzufuegen(Film film)
        {
            cnemaContext.Filme.Add(film);
            cnemaContext.SaveChanges();
            return true;
        }

        public bool FilmLoeschen(Film film)
        {
            cnemaContext.Filme.Remove(film);
            cnemaContext.SaveChanges();
            return true;
        }

        // Vorstellung
        public Vorstellung VorstellungLesen(int id)
        {
            Vorstellung vorstellung = cnemaContext.Vorstellungen.Find(id);
            return vorstellung;
        }

        public List<Vorstellung> AlleVorstellungenLesen()
        {
            return cnemaContext.Vorstellungen.ToList();
        }

        public bool VorstellungHinzufuegen(Vorstellung vorstellung)
        {
            cnemaContext.Vorstellungen.Add(vorstellung);
            cnemaContext.SaveChanges();
            return true;
        }

        public Vorstellung VorstellungAendern(Vorstellung vorstellung)
        {
            cnemaContext.SaveChanges();
            return vorstellung;
        }

        public bool VorstellungLoeschen(Vorstellung vorstellung)
        {
            cnemaContext.Vorstellungen.Remove(vorstellung);
            cnemaContext.SaveChanges();
            return true;
        }

    }
}
