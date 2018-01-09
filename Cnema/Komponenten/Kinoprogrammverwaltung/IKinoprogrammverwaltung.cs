using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using Komponenten.ET;

namespace Komponenten.Kinoprogrammverwaltung
{
    public interface IKinoprogrammverwaltung
    {

        // Filme
        ET.Film FilmLesen(int id);
        List<ET.Film> AlleFilmLesen();
        bool FilmHinzufuegen(ET.Film film);
        bool FilmAendern(Film film);
        bool FilmLoeschen(ET.Film film);

        // Vorstellung
        bool VorstellungHinzufuegen(DateTime zeitpunkt, Saal saal, Film film);
        bool VorstellungLoeschen(Vorstellung vorstellung);
        List<Vorstellung> AlleVorstellungenLesen();

        //Saal
        List<Saal> SaeleLesen();
    }
}
