using Komponenten.ET;
using Komponenten.Kundenverwaltung;
using log4net;
using System;
using System.Collections.Generic;
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
    /// Interaktionslogik für StartBildschirm.xaml
    /// </summary>
    public partial class StartBildschirm : Page
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(StartBildschirm));

        public StartBildschirm()
        {
            InitializeComponent();
        }

        private void Registrieren_Button(object sender, RoutedEventArgs e)
        {
            KundenRegistrierung kundenRegistrierung = new KundenRegistrierung();
            this.NavigationService.Navigate(kundenRegistrierung);
        }


        private void Benutzer_Login_Click(object sender, RoutedEventArgs e)
        {
            IKundenverwaltung kv = (IKundenverwaltung)Application.Current.Properties["kunde"];
            int id = -1;
            bool idKorrekt = Int32.TryParse(ID_Box.Text, out id);
            String passwort = Passwort_Box.Password;

            Kunde kunde;
            bool isKunde = kv.KundeLogin(id, passwort, out kunde);
            Admin admin;
            bool isAdmin = kv.AdminLogin(id, passwort, out admin);

            if (kunde != null && isKunde == true)
            {
                Application.Current.Properties["aktuellerBenutzer"] = kunde;
                log.Info("Kunde " + kunde.Vorname + " " + kunde.Name + " hat sich angemeldet.");
                Kinoprogramm kinoprogramm = new Kinoprogramm();
                this.NavigationService.Navigate(kinoprogramm);

            }
            else if (admin != null && isAdmin == true)
            {
                Application.Current.Properties["aktuellerBenutzer"] = admin;
                log.Info("Admin " + admin.Name + " hat sich angemeldet.");
                AdminBereichneu adminBereichneu = new AdminBereichneu();
                this.NavigationService.Navigate(adminBereichneu);
            }
            else
            {
                Login_Fehler.Content = "Anmeldedaten sind fehlerhaft.";
                log.Error("Fehlgeschlagene Anmeldung mit ID: " + id);
            }
        }
    }
}

