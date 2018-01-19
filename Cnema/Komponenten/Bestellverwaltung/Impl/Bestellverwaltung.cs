using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Komponenten.ET;
using Komponenten.Datenbank;
using Komponenten.Datenbank.Impl;

namespace Komponenten.Bestellverwaltung.Impl
{
    public class Bestellverwaltung : IBestellverwaltung
    {
        private int standardpreis = 10;
        private int ermaessigtpreis = 7;
        //Datenbankmanager wird entweder im Konstruktor übergeben, oder neu erzeugt
        IDatenbankManager datenbank;
        public Bestellverwaltung(IDatenbankManager datenbankManager)
        {
            datenbank = datenbankManager;
        }
        public Bestellverwaltung()
        {
            datenbank = DatenbankManager.Instance;
        }
        public List<Vorstellung> ProgrammAnzeigen()
        {
            return datenbank.AlleVorstellungenLesen();
        }

        //Filtern nach Titel
        public List<Vorstellung> ProgrammFilternTitel(String kriterium)
        {
            List<Vorstellung> alle = datenbank.AlleVorstellungenLesen();
            List<Vorstellung> gefiltert = new List<Vorstellung>();
            foreach (Vorstellung vorstellung in alle)
            {
                if (vorstellung.Film.Titel.ToLower().Contains(kriterium.ToLower())) gefiltert.Add(vorstellung);
            }
            return gefiltert;
        }

        //Übergebene Liste nach Titel filtern
        //Wird benötigt, um eine gefilterte Liste erneut nach Titel zu filtern
        public List<Vorstellung> ProgrammFilternTitel(String titel, IList<Vorstellung> vorstellungen)
        {
            if (vorstellungen == null)
            {
                throw new ArgumentNullException("Keine Vorstellungen angegeben");
            }
            List<Vorstellung> gefiltert = new List<Vorstellung>();
            foreach (Vorstellung vorstellung in vorstellungen)
            {
                if (vorstellung.Film.Titel.ToLower().Contains(titel.ToLower())) gefiltert.Add(vorstellung);
            }
            return gefiltert;
        }

        //Filtern nach Genre
        public List<Vorstellung> ProgrammFilternGenre(String genre)
        {
            List<Vorstellung> alle = datenbank.AlleVorstellungenLesen();
            List<Vorstellung> gefiltert = new List<Vorstellung>();
            foreach (Vorstellung vorstellung in alle)
            {
                if (vorstellung.Film.Genre.Equals(genre)) gefiltert.Add(vorstellung);
            }
            return gefiltert;
        }

        //Filtern nach 3d
        public List<Vorstellung> ProgrammFiltern3d(bool is3d)
        {
            List<Vorstellung> alle = datenbank.AlleVorstellungenLesen();
            List<Vorstellung> gefiltert = new List<Vorstellung>();
            foreach (Vorstellung vorstellung in alle)
            {
                if (vorstellung.Film.Is3D == is3d) gefiltert.Add(vorstellung);
            }
            return gefiltert;
        }

        //Filtern nach Wochentag
        public List<Vorstellung> ProgrammFilternTag(DayOfWeek tag)
        {
            List<Vorstellung> alle = datenbank.AlleVorstellungenLesen();
            List<Vorstellung> gefiltert = new List<Vorstellung>();
            foreach (Vorstellung vorstellung in alle)
            {
                if (vorstellung.DateTime.DayOfWeek.Equals(tag)) gefiltert.Add(vorstellung);
            }
            return gefiltert;
        }

        //Bestellung mit Standardpreis 10
        public Bestellung Reservieren(Kunde kunde, Vorstellung vorstellung)
        {
            return Reservieren(kunde, vorstellung, standardpreis);
        }
        //Bestellung mit übergebenem Preis
        public Bestellung Reservieren(Kunde kunde, Vorstellung vorstellung, double preis)
        {
            Bestellung bestellung = new Bestellung(vorstellung, kunde, preis);
            if (FreiePlaetzeAnzeigen(vorstellung) >= 1)
            {
                if (datenbank.BestellungHinzufügen(bestellung))
                {
                    return bestellung;
                }
                else throw new Exception("Bestellung konnte nicht hinzugefügt werden.");
            }
            else throw new Exception("Nicht genug freie Plätze in dieser Vorstellung.");
        }
        //Bestellung mit ermäßigtem Standardpreis
        public Bestellung ReservierenErmaessigt(Kunde kunde, Vorstellung vorstellung)
        {
            return Reservieren(kunde, vorstellung, ermaessigtpreis);
        }

        public void BestellungStornieren(Bestellung bestellung)
        {
            datenbank.BestellungLoeschen(bestellung);
        }

        public int FreiePlaetzeAnzeigen(Vorstellung vorstellung)
        {
            int plaetzeBelegt = 0;
            int plaetzeFrei;
            if (vorstellung != null)
            {
                plaetzeFrei = vorstellung.Saal.AnzahlSitze;
                if (vorstellung.Bestellungen != null)
                {
                    plaetzeBelegt = vorstellung.Bestellungen.Count;
                    plaetzeFrei = vorstellung.Saal.AnzahlSitze - plaetzeBelegt;
                }
                return plaetzeFrei;
            }
            return -1;
        }

        public int getStandardPreis()
        {
            return standardpreis;
        }

        public int getErmaessigtPreis()
        {
            return ermaessigtpreis;
        }
    }
}
