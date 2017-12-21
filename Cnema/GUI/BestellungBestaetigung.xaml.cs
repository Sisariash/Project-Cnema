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
    /// Interaktionslogik für BestellungBestaetigung.xaml
    /// </summary>
    public partial class BestellungBestaetigung : Page
    {
        public BestellungBestaetigung()
        {
            InitializeComponent();
        }

        private void Bestaetigen_Button(object sender, RoutedEventArgs e)
        {
            IhreBestellung ihrebestellung = new IhreBestellung();
            this.NavigationService.Navigate(ihrebestellung);
        }

        private void TxtNumErwachsene_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TxtNumKinder_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
