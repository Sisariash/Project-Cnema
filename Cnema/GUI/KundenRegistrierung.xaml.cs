using Komponenten.ET;
using Komponenten.Kundenverwaltung;
using log4net;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUI
{
    /// <summary>
    /// Interaktionslogik für KundenRegistrierung.xaml
    /// </summary>
    public partial class KundenRegistrierung : Page
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(KundenRegistrierung));
        public KundenRegistrierung()
        {
            InitializeComponent();
        }

        private void Registrieren_Button(object sender, RoutedEventArgs e)
        {
            String nachname = this.Nachname.Text;
            String vorname = this.Vorname.Text;
            DateTime geburtsdatum;
            bool geburtsdatumKorrekt = DateTime.TryParse(this.Geburtsdatum.Text, out geburtsdatum);

            if (this.Passwort.Password == null || this.Passwort.Password.Length == 0 || !this.Passwort.Password.Equals(this.PasswortWiederholt.Password) || nachname == null || nachname.Length == 0 || vorname == null || vorname.Length == 0 || !geburtsdatumKorrekt)
            {
                Fehlermeldung.Content = "Angaben sind fehlerhaft";
            }
            else
            {
                String passwort = Komponenten.Util.Utils.HashPassword(this.Passwort.Password);
                IKundenverwaltung kv = (IKundenverwaltung)Application.Current.Properties["kunde"];

                Kunde kunde = null;
                bool check = false;
                try
                {
                    check = kv.KundeRegistrieren(passwort, nachname, vorname, geburtsdatum, out kunde);
                }
                catch (SqlTypeException)
                {
                    Fehlermeldung.Content = "Geburtsdatum ungültig";
                }
                if (check)
                {
                    Application.Current.Properties["neuRegistriert"] = kunde;
                    log.Info("Kunde " + kunde.Vorname + " " + kunde.Name + " hat sich neu registriert.");
                    BestaetigungDerRegistrierung bestaetigungDerRegistrierung = new BestaetigungDerRegistrierung();
                    this.NavigationService.Navigate(bestaetigungDerRegistrierung);
                }
            }
        }
        private void Abbrechen_Click(object sender, RoutedEventArgs e)
        {
            StartBildschirm start = new StartBildschirm();
            this.NavigationService.Navigate(start);
        }
    }
}
