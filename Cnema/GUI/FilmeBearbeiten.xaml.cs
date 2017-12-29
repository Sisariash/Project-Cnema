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
    /// Interaktionslogik für FilmeBearbeiten.xaml
    /// </summary>
    public partial class FilmeBearbeiten : Page
    {
        public FilmeBearbeiten()
        {
            InitializeComponent();
        }

       

        private void Fertig_Button(object sender, RoutedEventArgs e)
        {
            AdminBereich adminBereich = new AdminBereich();
            this.NavigationService.Navigate(adminBereich);
        }

        private void Saal1_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Saal2_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Saal3_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Uhrzeit1700_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Uhrzeit2000_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Uhrzeit2200_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Uhrzeit1930_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Uhrzeit1300_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Uhrzeit1100_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Montag_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Dienstag_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Mittwoch_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Donnerstag_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Freitag_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Samstag_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Sonntag_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Filme_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Abbruch_Click(object sender, RoutedEventArgs e)
        {
            AdminBereich adminBereich = new AdminBereich();
            this.NavigationService.Navigate(adminBereich);
        }
    }
}
