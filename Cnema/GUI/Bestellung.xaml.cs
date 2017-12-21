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
            txtNumErwachsene.Text = _numValue.ToString();
        }

        private int _numValue = 0;

        public int NumValue
        {
            get { return _numValue; }
            set
            {
                _numValue = value;
                txtNumErwachsene.Text = value.ToString();
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

            if (!int.TryParse(txtNumErwachsene.Text, out _numValue))
                txtNumErwachsene.Text = _numValue.ToString();
        }

        private void CmdUpErwachsene_Click(object sender, RoutedEventArgs e)
        {
            NumValue++;
        }

        private void CmdDownErwachsene_Click(object sender, RoutedEventArgs e)
        {
            NumValue--;
        }

        private void TxtNumKinder_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtNumErwachsene == null)
            {
                return;
            }

            if (!int.TryParse(txtNumErwachsene.Text, out _numValue))
                txtNumErwachsene.Text = _numValue.ToString();
        }

        private void CmdDownKinder_Click(object sender, RoutedEventArgs e)
        {
            NumValue--;
        }

        private void CmdUpKinder_Click(object sender, RoutedEventArgs e)
        {
            NumValue++;
        }
    }
}
