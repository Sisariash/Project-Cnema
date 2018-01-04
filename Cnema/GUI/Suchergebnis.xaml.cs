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
        IList<Vorstellung> vorstellungen;
        public Suchergebnis(IList<Vorstellung> v)
        {
            InitializeComponent();
            vorstellungen = v;
            passendeFilme.ItemsSource = v;
        }

        private void passendeFilme_ListView(object sender, SelectionChangedEventArgs e)
        {

        }

        private void zurueck_Button(object sender, RoutedEventArgs e)
        {
            Kinoprogramm kinoprogramm = new Kinoprogramm();
            this.NavigationService.Navigate(kinoprogramm);
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

        private void Logout_Button(object sender, RoutedEventArgs e)
        {
            StartBildschirm startBildschirm = new StartBildschirm();
            this.NavigationService.Navigate(startBildschirm);
        }
    }
}
