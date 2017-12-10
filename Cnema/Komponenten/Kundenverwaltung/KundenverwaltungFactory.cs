using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Komponenten.Kundenverwaltung
{
    public class KundenverwaltungFactory
    {
        private Kundenverwaltung kv;

        public KundenverwaltungFactory()
        {
            kv = new Kundenverwaltung();
        }

        public IKundenverwaltung GetKundenverwaltung()
        {
            return kv;
        }
    }
}
