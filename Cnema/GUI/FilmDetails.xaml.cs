using Komponenten.ET;
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
    /// Interaktionslogik für FilmDetails.xaml
    /// </summary>
    public partial class FilmDetails : Page
    {
        private Film film;

        public FilmDetails(Film filmAuswahl)
        {
            InitializeComponent();
            film = filmAuswahl;
            Titel_Label.Content = film.Titel;
            Jahr_Label.Content = film.Jahr;
            Genre_Label.Content = film.Genre;
            Länge_Label.Content = film.Laenge;
            Sprache_Label.Content = film.Sprache;
            if (film.Is3D)
                Dimension_Label.Content = "3D";
            else
                Dimension_Label.Content = "2D";
            FSK_Label.Content = film.Fsk;
            Bewertung_Label.Content = String.Format("{0:F1} von 5 Sterne", film.BewertungAvg);

        }

        private void Zurueck_Button(object sender, RoutedEventArgs e)
        {
            Kinoprogramm kinoprogramm = new Kinoprogramm();
            this.NavigationService.Navigate(kinoprogramm);
        }
    }
}
