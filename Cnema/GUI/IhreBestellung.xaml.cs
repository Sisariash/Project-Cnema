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
    /// Interaktionslogik für IhreBestellung.xaml
    /// </summary>
    public partial class IhreBestellung : Page
    {
        private int standard;
        private int ermaessigt;
        private List<Bestellung> bestellungen;

        public IhreBestellung(int st, int er, List<Bestellung> best)
        {
            standard = st;
            ermaessigt = er;
            bestellungen = best;
            StringBuilder nummern = new StringBuilder();
            foreach (Bestellung b in bestellungen)
            {
                nummern.Append(b.BestellId.ToString() + ", ");
            }
            nummern.Remove(nummern.Length - 2, 2);
            InitializeComponent();
            txtNumErwachsene.Text = standard.ToString();
            txtNumKinder.Text = ermaessigt.ToString();
            BestellnrTxt.Text = nummern.ToString();
        }

        private void TxtNumErwachsene_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TxtNumKinder_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ZumProgramm_Button(object sender, RoutedEventArgs e)
        {
            Kinoprogramm kinoprogramm = new Kinoprogramm();
            this.NavigationService.Navigate(kinoprogramm);
        }
    }
}
