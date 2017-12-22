using Komponenten.ET;
using Komponenten.Kinoprogrammverwaltung;
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
        IKinoprogrammverwaltung kv = (IKinoprogrammverwaltung)App.Current.Properties["programm"];
        private DateTime tag = DateTime.Today;

        public Kinoprogramm()
        {
            InitializeComponent();
            List<String> tage = new List<string>();
            for (int i=0; i<14; i++)
            {
                String day = DateTime.Today.AddDays(i).ToString("dd. MM. yyyy");
                tage.Add(day);
            }
            TagKinoprogramm.ItemsSource = tage;
        }

        

        private void Tag_ListView(object sender, SelectionChangedEventArgs e)
        {
            String tagAuswahl = (String)TagKinoprogramm.SelectedItem;
            if (tagAuswahl != null)
            {
                tag = DateTime.ParseExact(tagAuswahl, "dd. MM. yyyy", System.Globalization.CultureInfo.InvariantCulture);
            }
            List<Film> filme = new List<Film>();
            foreach (Vorstellung v in kv.AlleVorstellungenLesen())
            {
                if (v != null && v.DateTime.Date.Equals(tag.Date) && !filme.Contains(v.Film))
                {
                    filme.Add(v.Film);
                }
            }
            FilmKinoprogramm.ItemsSource = filme;
        }

        private void Film_ListView(object sender, SelectionChangedEventArgs e)
        {
            List<String> zeiten = new List<String>();
            foreach (Vorstellung v in kv.AlleVorstellungenLesen())
            {
                if (v != null && v.Film != null && FilmKinoprogramm.SelectedItem.Equals(v.Film))
                {
                    zeiten.Add(v.DateTime.ToString("HH:mm"));
                }
            }
            UhrzeitKinoprogramm.ItemsSource = zeiten;
        }

        private void Uhrzeit_ListView(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Buchung_Button(object sender, RoutedEventArgs e)
        {
            Bestellung bestellung = new Bestellung();
            this.NavigationService.Navigate(bestellung);
        }

        private void FilmeBewerten_Button(object sender, RoutedEventArgs e)
        {
            FilmfuerBewertungAuswaehlen filmfuerBewertungAuswaehlen = new FilmfuerBewertungAuswaehlen();
            this.NavigationService.Navigate(filmfuerBewertungAuswaehlen);
        }

        private void FilmDetails_Button(object sender, RoutedEventArgs e)
        {
            FilmDetails filmDetails = new FilmDetails();
            this.NavigationService.Navigate(filmDetails);
        }

        private void FilmeFiltern_Click(object sender, RoutedEventArgs e)
        {
            FilmeFiltern filmeFiltern = new FilmeFiltern();
            this.NavigationService.Navigate(filmeFiltern);
        }

        private void Logout_Button(object sender, RoutedEventArgs e)
        {
            StartBildschirm startBildschirm = new StartBildschirm();
            this.NavigationService.Navigate(startBildschirm);
        }
    }
}
