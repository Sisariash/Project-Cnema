﻿using Komponenten.ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komponenten.Datenbank
{
    /*
     * DatenbankManager     - dient als Verbindung zwischen Datenbank und die Geschäftslogik (Bestellverwaltung, Kinoprogrammverwaltung, Kundenverwaltung)
     *                      - sorgt für einen kontrollierten Zugriff auf die Datenbank.
     * 
     * Verwaltet alle Datenbankzugriffe der Entities (Filme, User (Admin, Kunde), Säle, Vorstellungen etc.) - CRUD-Methods (Create Read Update Delete).
     * Entities in eigenständige Namespaces packen ist unvorteilheift, da diese komponentenübergreifen eingesetzt werden. 
     * Einige Datenbankanfragen (vorallem lesende) sind auch komponentenübergreifend und produzieren doppelten Code (z.B. Film lesen: Film wird geselen bei Bestellung,
     * bei Bewertung und bei der Programmverwaltung).
     */
    public interface IDatenbankManager
    {
    
        // Filme
        Film FilmLesen(int id);
        List<Film> AlleFilmeLesen();
        bool FilmHinzufuegen(Film film);
        bool FilmAendern(Film film);
        bool FilmLoeschen(Film film);

        // Vorstellung
        Vorstellung VorstellungLesen(int id);
        List<Vorstellung> AlleVorstellungenLesen();
        bool VorstellungHinzufuegen(Vorstellung vorstellung);
        bool VorstellungAendern(Vorstellung vorstellung);
        bool VorstellungLoeschen(Vorstellung vorstellung);

        // Benutzer: Kunde
        /*Benutzer BenutzerLesen(int id);
        List<Benutzer> AlleBenutzerLesen();
        bool BenutzerHinzufuegen(Benutzer benutzer);
        bool BenutzerAendern(Benutzer benutzer);
        bool BenutzerLoeschen(Benutzer benutzer);
        */

        //Bestellung
        Bestellung BestellungLesen(int id);
        List<Bestellung> AlleBestellungenLesen();
        bool BestellungHinzufügen(Bestellung bestellung);
        bool BestellungLoeschen(Bestellung bestellung);
    }
}
