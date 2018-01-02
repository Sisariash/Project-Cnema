using Komponenten.ET;
using Komponenten.Kundenverwaltung;
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
    /// Interaktionslogik für KundenRegistrierung.xaml
    /// </summary>
    public partial class KundenRegistrierung : Page
    {
        public KundenRegistrierung()
        {
            InitializeComponent();
        }

        private void Name_Textbox(object sender, TextChangedEventArgs e)
        {

        }

        private void Vorname_TextBox(object sender, TextChangedEventArgs e)
        {

        }

        private void Geburtstag_TextBox(object sender, TextChangedEventArgs e)
        {

        }

        
        private void WaehlePasswort_PasswortBox(object sender, TextChangedEventArgs e)
        {


        }

        
        private void WiederholePasswort_PasswortBox(object sender, TextChangedEventArgs e)
        {


        }

        private void Registrieren_Button(object sender, RoutedEventArgs e)
        {
            String nachname = this.Nachname.Text;
            String vorname = this.Vorname.Text;
            DateTime geburtsdatum;
            bool geburtsdatumKorrekt = DateTime.TryParse(this.Geburtsdatum.Text, out geburtsdatum);

            if (this.Passwort.Password == null || this.Passwort.Password.Length == 0 || !this.Passwort.Password.Equals(this.PasswortWiederholt.Password) || nachname == null || nachname.Length == 0 || vorname == null || vorname.Length == 0 || !geburtsdatumKorrekt )
            {
                Fehlermeldung.Visibility = Visibility.Visible;
            }
            else
            {
                String passwort = Komponenten.Util.Utils.HashPassword(this.Passwort.Password);
                IKundenverwaltung kv = (IKundenverwaltung)Application.Current.Properties["kunde"];

                Kunde kunde;
                if (kv.KundeRegistrieren(passwort, nachname, vorname, geburtsdatum, out kunde))
                {
                    Application.Current.Properties["neuRegistriert"] = kunde;
                    BestaetigungDerRegistrierung bestaetigungDerRegistrierung = new BestaetigungDerRegistrierung();
                    this.NavigationService.Navigate(bestaetigungDerRegistrierung);
                }
            }
        }
    }
}
