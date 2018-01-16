using Komponenten.Bestellverwaltung;
using Komponenten.Datenbank;
using Komponenten.Datenbank.Impl;
using Komponenten.Kinoprogrammverwaltung;
using Komponenten.Kundenverwaltung;
using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace GUI
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(App));
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            IDatenbankManager datenbankManager = DatenbankManager.Instance;
            KinoprogrammverwaltungFactory kpvFactory = new KinoprogrammverwaltungFactory(datenbankManager);
            BestellverwaltungFactory bvFactory = new BestellverwaltungFactory(datenbankManager);
            KundenverwaltungFactory kvFactory = new KundenverwaltungFactory(datenbankManager);
            Application.Current.Properties["programm"] = kpvFactory.GetKinoprogrammverwaltung();
            Application.Current.Properties["bestellung"] = bvFactory.GetBestellverwaltung();
            Application.Current.Properties["kunde"] = kvFactory.GetKundenverwaltung();
            XmlConfigurator.Configure();
            log.Info("Programm startet");
        }
    }
}
