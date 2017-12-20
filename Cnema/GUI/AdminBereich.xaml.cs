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
    /// Interaktionslogik für AdminBereich.xaml
    /// </summary>
    public partial class AdminBereich : Page
    {
        public AdminBereich()
        {
            InitializeComponent();
        }

        private void FilmeHinzufuegen_Button(object sender, RoutedEventArgs e)
        {
            FilmHinzufuegen filmHinzufuegen = new FilmHinzufuegen();
            this.NavigationService.Navigate(filmHinzufuegen);
        }

        private void FilmeLoeschen_Button(object sender, RoutedEventArgs e)
        {
            FilmeLoeschen filmeLoeschen = new FilmeLoeschen();
            this.NavigationService.Navigate(filmeLoeschen);
        }

        private void FilmeBearbeiten_Button(object sender, RoutedEventArgs e)
        {
            FilmeBearbeiten filmeBearbeiten = new FilmeBearbeiten();
            this.NavigationService.Navigate(filmeBearbeiten);


        }

        private void KinoprogrammHinzufuegen_Button(object sender, RoutedEventArgs e)
        {
            KinoprogrammHinzufuegen kinoprogrammHinzufuegen = new KinoprogrammHinzufuegen();
            this.NavigationService.Navigate(kinoprogrammHinzufuegen);

        }



        private void KinoprogrammBearbeiten_Button(object sender, RoutedEventArgs e)
        {
            //Lassen wir evtl. weg 

        }

        private void KinoprogrammLoeschen_Button(object sender, RoutedEventArgs e)
        {
            KinoprogrammLoeschen kinoprogrammLoeschen = new KinoprogrammLoeschen();
            this.NavigationService.Navigate(kinoprogrammLoeschen);

        }
    }
}
