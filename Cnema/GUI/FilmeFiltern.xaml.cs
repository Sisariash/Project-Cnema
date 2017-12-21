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
    /// Interaktionslogik für FilmeFiltern.xaml
    /// </summary>
    public partial class FilmeFiltern : Page
    {
        public FilmeFiltern()
        {
            InitializeComponent();
        }

        private void Montag_CheckBox(object sender, RoutedEventArgs e)
        {

        }

        private void Dienstag_CheckBox(object sender, RoutedEventArgs e)
        {

        }

        private void Mittwoch_CheckBox(object sender, RoutedEventArgs e)
        {

        }

        private void Donnerstag_CheckBox(object sender, RoutedEventArgs e)
        {

        }

        private void Freitag_CheckBox(object sender, RoutedEventArgs e)
        {

        }

        private void Samstag_CheckBox(object sender, RoutedEventArgs e)
        {

        }

        private void Sonntag_CheckBox(object sender, RoutedEventArgs e)
        {

        }

        private void Wochenende_CheckBox(object sender, RoutedEventArgs e)
        {

        }

        private void Uhr1700_CheckBox(object sender, RoutedEventArgs e)
        {

        }

        private void Uhr1930_CheckBox(object sender, RoutedEventArgs e)
        {

        }

        private void Uhr2200_CheckBox(object sender, RoutedEventArgs e)
        {

        }

        private void Uhr1100_CheckBox(object sender, RoutedEventArgs e)
        {

        }

        private void Uhr1300_CheckBox(object sender, RoutedEventArgs e)
        {

        }

        private void zweiD_CheckBox(object sender, RoutedEventArgs e)
        {

        }

        private void dreiD_CheckBox(object sender, RoutedEventArgs e)
        {

        }

        private void Action_CheckBox(object sender, RoutedEventArgs e)
        {

        }

        private void Fantasy_CheckBox(object sender, RoutedEventArgs e)
        {

        }

        private void Drama_CheckBox(object sender, RoutedEventArgs e)
        {

        }

        private void Abenteuer_CheckBox(object sender, RoutedEventArgs e)
        {

        }

        private void Horror_CheckBox(object sender, RoutedEventArgs e)
        {

        }

        private void Komoedie_CheckBox(object sender, RoutedEventArgs e)
        {

        }

        private void Krimi_CheckBox(object sender, RoutedEventArgs e)
        {

        }

        private void Liebe_CheckBox(object sender, RoutedEventArgs e)
        {

        }

        private void Animiert_CheckBox(object sender, RoutedEventArgs e)
        {

        }

        private void FilmName_TextBox(object sender, TextChangedEventArgs e)
        {

        }

        private void Suchen_Button(object sender, RoutedEventArgs e)
        {
            Suchergebnis suchergebnis = new Suchergebnis();
            this.NavigationService.Navigate(suchergebnis);
        }
    }
}
