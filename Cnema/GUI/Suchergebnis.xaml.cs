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
    /// Interaktionslogik für Suchergebnis.xaml
    /// </summary>
    public partial class Suchergebnis : Page
    {
        List<Vorstellung> vorstellungen;
        
        public Suchergebnis(List<Vorstellung> v, String kriterium)
        {
            InitializeComponent();
            vorstellungen = v;
            vorstellungen.Sort();
            passendeFilme.ItemsSource = v;
            Kriterium.Content = kriterium;
        }

        private void zurueck_Button(object sender, RoutedEventArgs e)
        {
            FilmeFiltern filmeFiltern = new FilmeFiltern();
            this.NavigationService.Navigate(filmeFiltern);
        }

        private void Vorstellung_Buchen_Click(object sender, RoutedEventArgs e)
        {
            Vorstellung v = (Vorstellung)passendeFilme.SelectedItem;
            if (v != null)
            {
                BestellungSeite bestellungSeite = new BestellungSeite(v);
                this.NavigationService.Navigate(bestellungSeite);
            }
        }

        private void Abbruch_Button(object sender, RoutedEventArgs e)
        {
            Kinoprogramm kinoprogramm = new Kinoprogramm();
            this.NavigationService.Navigate(kinoprogramm);
        }
    }
}
