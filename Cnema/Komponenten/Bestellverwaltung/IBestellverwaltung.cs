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
        IList<ET.Vorstellung> ProgrammAnzeigen();
        IList<ET.Vorstellung> ProgrammFiltern(String kriterium);
        Bestellung Reservieren(Kunde kunde, ET.Vorstellung vorstellung);
        Bestellung Reservieren(Kunde kunde, ET.Vorstellung vorstellung, double preis);
        void BestellungStornieren(Bestellung bestellung);
    }
}
