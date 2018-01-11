using Komponenten.Bestellverwaltung;
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
    /// Interaktionslogik für Bestellung.xaml
    /// </summary>
    public partial class BestellungSeite : Page
    {
        private IBestellverwaltung bv = (IBestellverwaltung)App.Current.Properties["bestellung"];
        private Vorstellung vorstellung;
        public BestellungSeite(Vorstellung v)
        {
            InitializeComponent();
            vorstellung = v;
            VorstellungAnzeige.Content = v.ToString();
            txtNumErwachsene.Text = _anzahlErwachsen.ToString();
            txtNumKinder.Text = _anzahlKinder.ToString();
            FreiePlaetze.Content = bv.FreiePlaetzeAnzeigen(vorstellung);
        }

        private int _anzahlErwachsen = 0;
        private int _anzahlKinder = 0;

        public int AnzahlErwachsen
        {
            get { return _anzahlErwachsen; }
            set
            {
                if (value >= 0 && (_anzahlKinder + value) <= bv.FreiePlaetzeAnzeigen(vorstellung))
                {
                    _anzahlErwachsen = value;
                    txtNumErwachsene.Text = value.ToString();
                }
            }
        }
        public int AnzahlKinder
        {
            get { return _anzahlKinder; }
            set
            {
                if (value >= 0 && (_anzahlErwachsen + value) <= bv.FreiePlaetzeAnzeigen(vorstellung))
                {
                    _anzahlKinder = value;
                    txtNumKinder.Text = value.ToString();
                }
            }
        }

        private void BestellungBestaetigen_Button(object sender, RoutedEventArgs e)
        {
            if (_anzahlErwachsen >= 0 && _anzahlKinder >= 0 && (_anzahlErwachsen + _anzahlKinder) > 0 && (_anzahlErwachsen + _anzahlKinder) <= bv.FreiePlaetzeAnzeigen(vorstellung))
            {
                BestellungBestaetigung bestellungbestaetigung = new BestellungBestaetigung(_anzahlErwachsen, _anzahlKinder, vorstellung);
                this.NavigationService.Navigate(bestellungbestaetigung);
            }
        }

        private void TxtNumErwachsene_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtNumErwachsene == null)
            {
                return;
            }

            if (!int.TryParse(txtNumErwachsene.Text, out _anzahlErwachsen))
                txtNumErwachsene.Text = _anzahlErwachsen.ToString();
        }

        private void CmdUpErwachsene_Click(object sender, RoutedEventArgs e)
        {
            AnzahlErwachsen++;
        }

        private void CmdDownErwachsene_Click(object sender, RoutedEventArgs e)
        {
            AnzahlErwachsen--;
        }

        private void TxtNumKinder_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtNumKinder == null)
            {
                return;
            }

            if (!int.TryParse(txtNumKinder.Text, out _anzahlKinder))
                txtNumKinder.Text = _anzahlKinder.ToString();
        }

        private void CmdDownKinder_Click(object sender, RoutedEventArgs e)
        {
            AnzahlKinder--;
        }

        private void CmdUpKinder_Click(object sender, RoutedEventArgs e)
        {
            AnzahlKinder++;
        }

        private void Abbruch_Click(object sender, RoutedEventArgs e)
        {
            Kinoprogramm kinoprogramm = new Kinoprogramm();
            this.NavigationService.Navigate(kinoprogramm);
        }
    }
}
