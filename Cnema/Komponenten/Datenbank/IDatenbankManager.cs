using Komponenten.ET;
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
        //Allgemeine Update Methode zum Speichern von Änderungen an Objekten
        bool Update();
    
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
        bool VorstellungAendern();
        bool VorstellungLoeschen(Vorstellung vorstellung);

        // Benutzer: Kunde
        Kunde KundeLesen(int id);
        List<Kunde> AlleKundenLesen();
        bool KundeHinzufuegen(Kunde kunde);
        bool KundeAendern();
        bool KundeLoeschen(Kunde kunde);

        // Benutzer: Admin
        Admin AdminLesen(int id);
        List<Admin> AlleAdminsLesen();
        bool AdminHinzufuegen(Admin admin);
        bool AdminAendern();
        bool AdminLoeschen(Admin admin);

        //Bestellung
        Bestellung BestellungLesen(int id);
        List<Bestellung> AlleBestellungenLesen();
        bool BestellungHinzufügen(Bestellung bestellung);
        bool BestellungAendern();
        bool BestellungLoeschen(Bestellung bestellung);

        //Saal
        Saal SaalLesen(String saalname);
        List<Saal> AlleSaeleLesen();
        bool SaalHinzufügen(Saal saal);
        bool SaalLoeschen(Saal saal);

        //FilmBewertung
        FilmBewertung FilmBewertungLesen(int id);
        List<FilmBewertung> AlleFilmBewertungenLesen();
        bool FilmBewertungHinzufügen(FilmBewertung filmBewertung);
        bool FilmBewertungLöschen(FilmBewertung filmBewertung);
    }
}
