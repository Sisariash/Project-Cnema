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
    /// Interaktionslogik für FilmfuerBewertungAuswaehlen.xaml
    /// </summary>
    public partial class FilmAuswaehlen : Page
    {
        IKinoprogrammverwaltung kpv = (IKinoprogrammverwaltung)Application.Current.Properties["programm"];

        public FilmAuswaehlen()
        {
            InitializeComponent();
            List<Film> filme = kpv.AlleFilmLesen();
            Programm.ItemsSource = filme;
        }

        private void Programm_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Bewertung_Button(object sender, RoutedEventArgs e)
        {
            if (Programm.SelectedItem != null)
            {
                FilmBewerten filmBewerten = new FilmBewerten((Film)Programm.SelectedItem);
                this.NavigationService.Navigate(filmBewerten);
            }
            else
                Auswahlfehler.Content = "Bitte Film auswählen";
        }
    }
}
