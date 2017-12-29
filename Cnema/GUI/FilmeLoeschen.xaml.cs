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
    /// Interaktionslogik für FilmeLoeschen.xaml
    /// </summary>
    public partial class FilmeLoeschen : Page
    {
        public FilmeLoeschen()
        {
            InitializeComponent();
        }

        

        private void Loeschen_Button(object sender, RoutedEventArgs e)
        {
            AdminBereich adminBereich = new AdminBereich();
            this.NavigationService.Navigate(adminBereich);
        }

        private void Filme_ListView(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Abbruch_Click(object sender, RoutedEventArgs e)
        {
            AdminBereich adminBereich = new AdminBereich();
            this.NavigationService.Navigate(adminBereich);
        }
    }
}
