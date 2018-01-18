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
    /// Interaction logic for FilmFuerDetailsAuswaehlen.xaml
    /// </summary>
    public partial class FilmFuerDetailsAuswaehlen : Page
    {
        IKinoprogrammverwaltung kpv = (IKinoprogrammverwaltung)Application.Current.Properties["programm"];

        public FilmFuerDetailsAuswaehlen()
        {
            InitializeComponent();
            List<Film> alleFilme = kpv.AlleFilmLesen();
            alleFilme.Sort();
            Programm.ItemsSource = alleFilme;
        }

        private void Bewertung_Button(object sender, RoutedEventArgs e)
        {
            if (Programm.SelectedItem != null)
            {
                FilmDetails filmdetails = new FilmDetails((Film)Programm.SelectedItem);
                this.NavigationService.Navigate(filmdetails);
            }
            else
                Auswahlfehler.Content = "Bitte Film auswählen";
        }


        private void Abbrechen_Click(object sender, RoutedEventArgs e)
        {
            Kinoprogramm kinoprogramm = new Kinoprogramm();
            this.NavigationService.Navigate(kinoprogramm);
        }
    }
}
