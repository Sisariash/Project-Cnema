using Komponenten.ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Komponenten.Datenbank;
using System.Xml.Linq;

namespace Komponenten.Datenbank.Impl
{
    class DatenbankManager : IDatenbankManager
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

        public bool FilmAendern(Film film)
        {
            try
            {
                cnemaContext.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public bool FilmHinzufuegen(Film film)
        {
            try
            {
                cnemaContext.Filme.Add(film);
                cnemaContext.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public bool FilmLoeschen(Film film)
        {
            try
            {
                cnemaContext.Filme.Remove(film);
                cnemaContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
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
            try
            {
                cnemaContext.Vorstellungen.Add(vorstellung);
                cnemaContext.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public bool VorstellungAendern(Vorstellung vorstellung)
        {
            try
            {
                cnemaContext.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public bool VorstellungLoeschen(Vorstellung vorstellung)
        {
            try
            {
                cnemaContext.Vorstellungen.Remove(vorstellung);
                cnemaContext.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        //Bestellung
        public Bestellung BestellungLesen(int id)
        {
            return cnemaContext.Bestellungen.Find(id);
        }

        public List<Bestellung> AlleBestellungenLesen()
        {
            return cnemaContext.Bestellungen.ToList();
        }

        public bool BestellungHinzufügen(Bestellung bestellung)
        {
            try
            {
                cnemaContext.Bestellungen.Add(bestellung);
                cnemaContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool BestellungLoeschen(Bestellung bestellung)
        {
            try
            {
                cnemaContext.Bestellungen.Remove(bestellung);
                cnemaContext.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        //Benutzer: Kunde
        public Kunde KundeLesen(int id)
        {
            return cnemaContext.Kunden.Find(id);
        }

        public List<Kunde> AlleKundenLesen()
        {
            return cnemaContext.Kunden.ToList();
        }

        public bool KundeHinzufuegen(Kunde kunde)
        {
            try
            {
                cnemaContext.Kunden.Add(kunde);
                cnemaContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool KundeAendern(Kunde kunde)
        {
            try
            {
                cnemaContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool KundeLoeschen(Kunde kunde)
        {
            try
            {
                cnemaContext.Kunden.Remove(kunde);
                cnemaContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Benutzer: Admin
        public Admin AdminLesen(int id)
        {
            return cnemaContext.Admins.Find(id);
        }

        public List<Admin> AlleAdminsLesen()
        {
            return cnemaContext.Admins.ToList();
        }

        public bool AdminHinzufuegen(Admin admin)
        {
            try
            {
                cnemaContext.Admins.Add(admin);
                cnemaContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool AdminAendern(Admin admin)
        {
            try
            {
                cnemaContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool AdminLoeschen(Admin admin)
        {
            try
            {
                cnemaContext.Admins.Remove(admin);
                cnemaContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
