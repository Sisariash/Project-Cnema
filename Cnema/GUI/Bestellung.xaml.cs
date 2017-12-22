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
    public partial class Bestellung : Page
    {
        public Bestellung()
        {
            InitializeComponent();
            txtNumErwachsene.Text = _anzahlErwachsen.ToString();
            txtNumKinder.Text = _anzahlKinder.ToString();
        }

        private int _anzahlErwachsen = 0;
        private int _anzahlKinder = 0;

        public int AnzahlErwachsen
        {
            get { return _anzahlErwachsen; }
            set
            {
                if (value >= 0)
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
                if (value >= 0)
                {
                    _anzahlKinder = value;
                    txtNumKinder.Text = value.ToString();
                }
            }
        }

        private void BestellungBestaetigen_Button(object sender, RoutedEventArgs e)
        {
            BestellungBestaetigung bestellungbestaetigung = new BestellungBestaetigung();
            this.NavigationService.Navigate(bestellungbestaetigung);
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
    }
}
