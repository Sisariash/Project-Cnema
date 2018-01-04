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
        IList<ET.Vorstellung> ProgrammAnzeigen();
        Bestellung Reservieren(Kunde kunde, ET.Vorstellung vorstellung);
        Bestellung Reservieren(Kunde kunde, ET.Vorstellung vorstellung, double preis);
        Bestellung ReservierenErmaessigt(Kunde kunde, ET.Vorstellung vorstellung);
        void BestellungStornieren(Bestellung bestellung);
        int FreiePlaetzeAnzeigen(Vorstellung vorstellung);
        IList<ET.Vorstellung> ProgrammFilternTag(DayOfWeek tag);
        IList<ET.Vorstellung> ProgrammFilternTitel(String titel);
        IList<ET.Vorstellung> ProgrammFilternTitel(String titel, IList<Vorstellung> vorstellungen);
        IList<ET.Vorstellung> ProgrammFilternGenre(String genre);
        IList<ET.Vorstellung> ProgrammFiltern3d(bool is3d);
    }
}
