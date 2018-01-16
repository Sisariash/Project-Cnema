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
    /// Interaktionslogik für FilmBewerten.xaml
    /// </summary>
    public partial class FilmBewerten : Page
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(FilmBewerten));
        private IKundenverwaltung kv = (IKundenverwaltung)Application.Current.Properties["kunde"];
        private Kunde kunde = (Kunde)Application.Current.Properties["aktuellerBenutzer"];
        private Film film;

        public FilmBewerten(Film filmAuswahl)
        {
            InitializeComponent();
            film = filmAuswahl;
            Filmtitel.Content = film.Titel;
            kv.DurchschnittBerechnen(film);
            Bewertung.Content = String.Format("{0:F1} von 5 Sterne", film.BewertungAvg);
        }

        private void BewertungButton_Click(object sender, RoutedEventArgs e)
        {
            bool bewertungOK = false;
            int bewertung = 0;

            if (Eins.IsChecked == true)
                bewertung = 1;
            else if (Zwei.IsChecked == true)
                bewertung = 2;
            else if (Drei.IsChecked == true)
                bewertung = 3;
            else if (Vier.IsChecked == true)
                bewertung = 4;
            else if (Fünf.IsChecked == true)
                bewertung = 5;

            if (bewertung == 0)
                Fehlermeldung.Content = "Bitte Bewertung auswählen";
            else
            {
                try
                {
                    bewertungOK = kv.FilmBewerten(bewertung, film, kunde);  // Falls false, existiert bereits Bewertung des aktuellen Kunden für diesen Film (Kunde darf pro Film nur einmal abstimmen)
                }
                catch (Exception)   // Exception, falls Hinzufügen zu Datenbank fehlschlug
                {
                    Fehlermeldung.Content = "Systemfehler beim Speichern";
                    log.Error("Systemfehler beim Speichern der Bewertung.");
                }

                if (bewertungOK)
                {
                    kv.DurchschnittBerechnen(film);
                    FilmBewertenabgeschlossen filmBewertenabgeschlossen = new FilmBewertenabgeschlossen();
                    this.NavigationService.Navigate(filmBewertenabgeschlossen);
                }
                else
                {
                    Fehlermeldung.Content = "Diesen Film haben Sie bereits bewertet";
                    log.Info("Kunde " + kunde.Vorname + " " + kunde.Name + " versuchte, " + film.Titel + " mehrfach zu bewerten.");
                }
            }
        }

        private void Abbruch_Button_Click(object sender, RoutedEventArgs e)
        {
            Kinoprogramm kinoprogramm = new Kinoprogramm();
            this.NavigationService.Navigate(kinoprogramm);
        }
    }
}

