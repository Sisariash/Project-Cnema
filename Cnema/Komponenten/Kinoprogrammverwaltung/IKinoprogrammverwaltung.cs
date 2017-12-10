using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace Komponenten.Kinoprogrammverwaltung
{
    public interface IKinoprogrammverwaltung
    {


        bool Hinzufuegen(ET.Film film);
        ET.Film Aendern(ET.Film film);
        bool Loeschen(ET.Film film);
        bool VorstellungErzeugen(ET.Film film, ET.Saal saal, DateTime Zeitpunkt);
        void VorstellungEntfernen(string vorstellungId);
    }
}
