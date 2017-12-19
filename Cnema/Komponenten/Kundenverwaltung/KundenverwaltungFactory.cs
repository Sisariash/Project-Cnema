using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Komponenten.Datenbank;

namespace Komponenten.Kundenverwaltung
{
    public class KundenverwaltungFactory
    {
        private Impl.Kundenverwaltung kv;

        public KundenverwaltungFactory(IDatenbankManager db)
        {
            kv = new Impl.Kundenverwaltung(db);
        }

        public IKundenverwaltung GetKundenverwaltung()
        {
            return kv;
        }
    }
}
