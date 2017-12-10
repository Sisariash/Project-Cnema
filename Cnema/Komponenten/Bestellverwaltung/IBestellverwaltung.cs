using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Komponenten.Kundenverwaltung.ET;

namespace Komponenten.Bestellverwaltung
{
    public interface IBestellverwaltung
    {
        IList<ET.Vorstellung> ProgrammAnzeigen();
        IList<ET.Vorstellung> ProgrammFiltern(String kriterium);
        bool Reservieren(Kunde kunde, ET.Vorstellung vorstellung);
    }
}
