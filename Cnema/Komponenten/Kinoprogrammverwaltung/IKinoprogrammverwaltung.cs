using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

using Komponenten.Bestellverwaltung.ET;
using Komponenten.Kinoprogrammverwaltung.ET;

namespace Komponenten.Kinoprogrammverwaltung
{
    public interface IKinoprogrammverwaltung
    { 
   
        // Filme
        ET.Film FilmLesen(int id);
        List<ET.Film> AlleFilmLesen();
        bool FilmHinzufuegen(ET.Film film);
        ET.Film FilmAendern(ET.Film film);
        bool FilmLoeschen(ET.Film film);

        // Vorstellung
        bool VorstellungHinzufuegen(DateTime zeitpunkt, Saal saal, Film film);
        bool VorstellungLoeschen(Vorstellung vorstellung);
    }
}
