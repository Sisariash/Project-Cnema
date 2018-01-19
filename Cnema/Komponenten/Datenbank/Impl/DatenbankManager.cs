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

    // Datenbank-Manager dient als Schutz-Proxy, der den direkten Zugriff auf DBContext verhindert

    public class DatenbankManager : IDatenbankManager
    {
        private CnemaContext cnemaContext = new CnemaContext();

        // Singleton - Muster

        private static DatenbankManager instance;

        private DatenbankManager() { }

        public static DatenbankManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DatenbankManager();
                }
                return instance;
            }
        }

        public bool Update()
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
                cnemaContext.Entry(film).State = System.Data.Entity.EntityState.Modified;
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
                if (film.Vorstellungen != null)
                {
                    Vorstellung[] vs = new Vorstellung[film.Vorstellungen.Count];
                    film.Vorstellungen.CopyTo(vs);
                    foreach (Vorstellung v in vs)
                    {
                        if (v != null) VorstellungLoeschen(v);
                    }
                }
                if (film.FilmBewertungen != null)
                {
                    FilmBewertung[] fbs = new FilmBewertung[film.FilmBewertungen.Count];
                    film.FilmBewertungen.CopyTo(fbs);
                    foreach (FilmBewertung fb in fbs)
                    {
                        if (fb != null) FilmBewertungLöschen(fb);
                    }
                }
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

        public Vorstellung VorstellungLesen(DateTime dateTime, Saal saal)
        {
            Vorstellung vorstellung = cnemaContext.Vorstellungen
                .Where(c => c.DateTime.Equals(dateTime))
                .Where(c => c.Saal.SaalName.Equals(saal.SaalName))
                .SingleOrDefault();
            return vorstellung;
        }

        public bool VorstellungExistiert(DateTime dateTime, Saal saal)
        {
            Vorstellung vorstellung = VorstellungLesen(dateTime, saal);
            return vorstellung != null;
        }

        public List<Vorstellung> AlleVorstellungenLesen()
        {
            return cnemaContext.Vorstellungen.ToList();
        }

        public bool VorstellungHinzufuegen(Vorstellung vorstellung)
        {
            try
            {
                List<Vorstellung> vorstellungenSelberSaal = vorstellung.Saal.Vorstellungen;
                if (vorstellungenSelberSaal != null)
                {
                    foreach (Vorstellung v in vorstellungenSelberSaal)
                    {
                        DateTime startFilm = v.DateTime;
                        DateTime endeFilm = v.DateTime.AddMinutes(v.Film.Laenge);
                        if (startFilm.Ticks <= vorstellung.DateTime.Ticks && endeFilm.Ticks >= vorstellung.DateTime.Ticks)
                        {
                            return false;
                        }
                    }
                }
                cnemaContext.Vorstellungen.Add(vorstellung);
                cnemaContext.SaveChanges();
                return true;

            }
            catch  { return false; }
        }

        public bool VorstellungAendern()
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
                if (vorstellung.Bestellungen != null)
                {
                    Bestellung[] bs = new Bestellung[vorstellung.Bestellungen.Count];
                    vorstellung.Bestellungen.CopyTo(bs);
                    foreach (Bestellung b in bs)
                    {
                        if (b != null) BestellungLoeschen(b);
                    }
                }
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

        public bool BestellungAendern()
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

        public bool KundeAendern()
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
                if (kunde.Bestellungen != null)
                {
                    Bestellung[] bs = new Bestellung[kunde.Bestellungen.Count];
                    kunde.Bestellungen.CopyTo(bs);
                    foreach (Bestellung b in bs)
                    {
                        if (b != null) BestellungLoeschen(b);
                    }
                }
                if (kunde.FilmBewertungen != null)
                {
                    FilmBewertung[] fbs = new FilmBewertung[kunde.FilmBewertungen.Count];
                    kunde.FilmBewertungen.CopyTo(fbs);
                    foreach (FilmBewertung fb in fbs)
                    {
                        if (fb != null) FilmBewertungLöschen(fb);
                    }
                }
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

        public bool AdminAendern()
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

        //Saal
        public Saal SaalLesen(String saalname)
        {
            return cnemaContext.Säle.Find(saalname);
        }

        public List<Saal> AlleSaeleLesen()
        {
            return cnemaContext.Säle.ToList();
        }

        public bool SaalHinzufügen(Saal saal)
        {
            try
            {
                cnemaContext.Säle.Add(saal);
                cnemaContext.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public bool SaalLoeschen(Saal saal)
        {
            try
            {
                if (saal.Vorstellungen != null)
                {
                    Vorstellung[] vs = new Vorstellung[saal.Vorstellungen.Count];
                    saal.Vorstellungen.CopyTo(vs);
                    foreach (Vorstellung v in vs)
                    {
                        if (v != null) VorstellungLoeschen(v);
                    }
                }
                cnemaContext.Säle.Remove(saal);
                cnemaContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //FilmBewertung
        public FilmBewertung FilmBewertungLesen(int id)
        {
            return cnemaContext.FilmBewertungen.Find(id);
        }

        public List<FilmBewertung> AlleFilmBewertungenLesen()
        {
            return cnemaContext.FilmBewertungen.ToList();
        }


        public bool FilmBewertungHinzufügen(FilmBewertung filmBewertung)
        {

            try
            {
                cnemaContext.FilmBewertungen.Add(filmBewertung);
                cnemaContext.SaveChanges();
                return true;
            }
            catch { return false; }

        }

        public bool FilmBewertungLöschen(FilmBewertung filmBewertung)
        {
            try
            {
                cnemaContext.FilmBewertungen.Remove(filmBewertung);
                cnemaContext.SaveChanges();
                return true;
            }
            catch { return false; }
        }
    }
}
