using Komponenten.Bestellverwaltung;
using Komponenten.ET;
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
    /// Interaktionslogik für BestellungBestaetigung.xaml
    /// </summary>
    public partial class BestellungBestaetigung : Page
    {
        private int Standard;
        private int Ermaessigt;
        private Vorstellung vorstellung;
        private IBestellverwaltung bv = (IBestellverwaltung)App.Current.Properties["bestellung"];
        private static readonly ILog log = LogManager.GetLogger(typeof(BestellungBestaetigung));

        public BestellungBestaetigung(int standard, int ermaessigt, Vorstellung vorst)
        {
            InitializeComponent();
            vorstellung = vorst;
            Standard = standard;
            Ermaessigt = ermaessigt;
            VorstellungAnzeige.Content = vorstellung.ToString();
            txtNumErwachsene.Text = Standard.ToString();
            txtNumKinder.Text = Ermaessigt.ToString();
            double preis = 0;
            for (int i = 0; i < Standard; i++)
            {
                preis += bv.getStandardPreis();
            }
            for (int j = 0; j < Ermaessigt; j++)
            {
                preis += bv.getErmaessigtPreis();
            }
            PreisTxt.Text = preis.ToString();
        }

        private void Bestaetigen_Button(object sender, RoutedEventArgs e)
        {
            Kunde kunde = (Kunde)App.Current.Properties["aktuellerBenutzer"];
            List<Bestellung> bestellungen = new List<Bestellung>();
            bool fehlerAufgetreten = false;
            try
            {
                for (int erwachsen = 0; erwachsen < Standard; erwachsen++)
                {
                    bestellungen.Add((Bestellung)bv.Reservieren(kunde, vorstellung));
                }
                for (int ermaessigt = 0; ermaessigt < Ermaessigt; ermaessigt++)
                {
                    bestellungen.Add((Bestellung)bv.ReservierenErmaessigt(kunde, vorstellung));
                }
            }
            catch 
            {
                Fehlermeldung.Content = "Beim Bearbeiten Ihrer Bestellung ist ein Fehler aufgetreten.";
                fehlerAufgetreten = true;
                log.Error("Ausnahme beim Hinzufügen der Bestellung.");
            }

            if (!fehlerAufgetreten)
            {
                IhreBestellung ihrebestellung = new IhreBestellung(Standard, Ermaessigt, bestellungen, vorstellung);
                this.NavigationService.Navigate(ihrebestellung);
            }
        }

        private void Abbruch_Click(object sender, RoutedEventArgs e)
        {
            Kinoprogramm kinoprogramm = new Kinoprogramm();
            this.NavigationService.Navigate(kinoprogramm);
        }
    }
}
