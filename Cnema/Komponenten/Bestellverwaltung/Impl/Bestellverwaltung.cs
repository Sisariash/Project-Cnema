using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Komponenten.ET;
using Komponenten.Util;
using Komponenten.Util.Impl;

namespace Komponenten.Bestellverwaltung.Impl
{
    public class Bestellverwaltung : IBestellverwaltung
    {
        //Datenbankmanager wird entweder im Konstruktor übergeben, oder neu erzeugt
        IDatenbankManager datenbank;
        public Bestellverwaltung(IDatenbankManager datenbankManager)
        {
            datenbank = datenbankManager;
        }
        public Bestellverwaltung()
        {
            datenbank = new DatenbankManager();
        }
        public IList<Vorstellung> ProgrammAnzeigen()
        {
            return datenbank.AlleVorstellungenLesen();
        }

        //Filtern derzeit nur nach Name möglich
        public IList<Vorstellung> ProgrammFiltern(string kriterium)
        {
            List<Vorstellung> alle = datenbank.AlleVorstellungenLesen();
            List<Vorstellung> gefiltert = new List<Vorstellung>();
            foreach (Vorstellung vorstellung in alle)
            {
                if (vorstellung.Film.Titel.Contains(kriterium)) gefiltert.Add(vorstellung);
            }
            return gefiltert;
        }

        //Bestellung mit Standardpreis 10
        public Bestellung Reservieren(Kunde kunde, Vorstellung vorstellung)
        {
            Bestellung bestellung = new Bestellung(vorstellung, kunde, 10);
            if (datenbank.BestellungHinzufügen(bestellung))
            {
                return bestellung;
            }
            else throw new Exception("Bestellung konnte nicht hinzugefügt werden.");
            
        }
        //Bestellung mit übergebenem Preis
        public Bestellung Reservieren(Kunde kunde, Vorstellung vorstellung, double preis)
        {
            Bestellung bestellung = new Bestellung(vorstellung, kunde, preis);
            if (datenbank.BestellungHinzufügen(bestellung))
            {
                return bestellung;
            }
            else throw new Exception("Bestellung konnte nicht hinzugefügt werden.");
        }

        public void BestellungStornieren(Bestellung bestellung)
        {
            datenbank.BestellungLoeschen(bestellung);
        }
    }
}
