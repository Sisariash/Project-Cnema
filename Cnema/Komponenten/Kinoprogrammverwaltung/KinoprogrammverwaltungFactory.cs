using Komponenten.Datenbank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komponenten.Kinoprogrammverwaltung
{
    public class KinoprogrammverwaltungFactory
    {
        private Impl.Kinoprogrammverwaltung kpv;

        public KinoprogrammverwaltungFactory(IDatenbankManager db)
        {
            kpv = new Impl.Kinoprogrammverwaltung(db);
        }

        public IKinoprogrammverwaltung GetKinoprogrammverwaltung()
        {
            return kpv;
        }
    }
}
