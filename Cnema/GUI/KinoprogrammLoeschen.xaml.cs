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
    /// Interaktionslogik für KinoprogrammLoeschen.xaml
    /// </summary>
    public partial class KinoprogrammLoeschen : Page
    {
        public KinoprogrammLoeschen()
        {
            InitializeComponent();
        }

        private void Tag_ListView(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Film_ListView(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Uhrzeit_ListView(object sender, SelectionChangedEventArgs e)
        {

        }



        private void Saal_ListView(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Loeschen_Button(object sender, RoutedEventArgs e)
        {
            AdminBereich adminBereich = new AdminBereich();
            this.NavigationService.Navigate(adminBereich);
        }

        private void Abbruch_Click(object sender, RoutedEventArgs e)
        {
            AdminBereich adminBereich = new AdminBereich();
            this.NavigationService.Navigate(adminBereich);
        }
    }
}
