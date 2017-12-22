using Komponenten.Datenbank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komponenten.Bestellverwaltung
{
    public class BestellverwaltungFactory
    {
        private Impl.Bestellverwaltung bv;

        public BestellverwaltungFactory(IDatenbankManager db)
        {
            bv = new Impl.Bestellverwaltung(db);
        }

        public IBestellverwaltung GetBestellverwaltung()
        {
            return bv;
        }
    }
}
