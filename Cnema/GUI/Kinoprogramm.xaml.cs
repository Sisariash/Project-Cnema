using Komponenten.ET;
using Komponenten.Kinoprogrammverwaltung;
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
    /// Interaktionslogik für Kinoprogramm.xaml
    /// </summary>
    public partial class Kinoprogramm : Page
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Kinoprogramm));
        IKinoprogrammverwaltung kv = (IKinoprogrammverwaltung)App.Current.Properties["programm"];
        Kunde kundeAngemeldet = (Kunde)Application.Current.Properties["aktuellerBenutzer"];
        private DateTime tag = DateTime.Today;

        public Kinoprogramm()
        {
            InitializeComponent();
            DateTime[] tage = new DateTime[14];
            for (int i=0; i<14; i++)
            {
                tage[i] = DateTime.Today.AddDays(i);
            }
            TagKinoprogramm.ItemsSource = tage;

            Gruss.Content = "Grüß Gott, " + kundeAngemeldet.Vorname + " " + kundeAngemeldet.Name + "!";
        }

        private void Tag_ListView(object sender, SelectionChangedEventArgs e)
        {
            FilmKinoprogramm.UnselectAll();
            DateTime tagAuswahl = (DateTime)TagKinoprogramm.SelectedItem;
            if (tagAuswahl != null)
            {
                tag = tagAuswahl;
            }
            List<Vorstellung> vorstellungen = new List<Vorstellung>();
            foreach (Vorstellung v in kv.AlleVorstellungenLesen())
            {
                if (v != null && v.DateTime.Date.Equals(tag.Date))
                {
                    vorstellungen.Add(v);
                }
            }
            vorstellungen.Sort();
            FilmKinoprogramm.ItemsSource = vorstellungen;
        }

        private void Buchung_Button(object sender, RoutedEventArgs e)
        {
            if (FilmKinoprogramm.SelectedItem != null)
            {
                BestellungSeite bestellung = new BestellungSeite((Vorstellung)FilmKinoprogramm.SelectedItem);
                this.NavigationService.Navigate(bestellung);
            }
        }

        private void FilmeBewerten_Button(object sender, RoutedEventArgs e)
        {
            FilmfuerBewertungAuswaehlen filmfuerBewertungAuswaehlen = new FilmfuerBewertungAuswaehlen();
            this.NavigationService.Navigate(filmfuerBewertungAuswaehlen);
        }

        private void FilmDetails_Button(object sender, RoutedEventArgs e)
        {
            FilmFuerDetailsAuswaehlen filmdetails = new FilmFuerDetailsAuswaehlen();
            this.NavigationService.Navigate(filmdetails);
        }

        private void FilmeFiltern_Click(object sender, RoutedEventArgs e)
        {
            FilmeFiltern filmeFiltern = new FilmeFiltern();
            this.NavigationService.Navigate(filmeFiltern);
        }

        private void Logout_Button(object sender, RoutedEventArgs e)
        {
            Kunde kunde = (Kunde)Application.Current.Properties["aktuellerBenutzer"];
            log.Info("Kunde " + kunde.Vorname + " " + kunde.Name + " hat sich abgemeldet.");
            StartBildschirm startBildschirm = new StartBildschirm();
            this.NavigationService.Navigate(startBildschirm);
        }
    }
}
