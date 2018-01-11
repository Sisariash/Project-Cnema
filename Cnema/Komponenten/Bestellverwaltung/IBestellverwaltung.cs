using Komponenten.ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komponenten.Bestellverwaltung
{
    public interface IBestellverwaltung
    {
        int getStandardPreis();
        int getErmaessigtPreis();
        List<ET.Vorstellung> ProgrammAnzeigen();
        Bestellung Reservieren(Kunde kunde, ET.Vorstellung vorstellung);
        Bestellung Reservieren(Kunde kunde, ET.Vorstellung vorstellung, double preis);
        Bestellung ReservierenErmaessigt(Kunde kunde, ET.Vorstellung vorstellung);
        void BestellungStornieren(Bestellung bestellung);
        int FreiePlaetzeAnzeigen(Vorstellung vorstellung);
        List<ET.Vorstellung> ProgrammFilternTag(DayOfWeek tag);
        List<ET.Vorstellung> ProgrammFilternTitel(String titel);
        List<ET.Vorstellung> ProgrammFilternTitel(String titel, IList<Vorstellung> vorstellungen);
        List<ET.Vorstellung> ProgrammFilternGenre(String genre);
        List<ET.Vorstellung> ProgrammFiltern3d(bool is3d);
    }
}
