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
    /// Interaktionslogik für FilmfuerBewertungAuswaehlen.xaml
    /// </summary>
    public partial class FilmfuerBewertungAuswaehlen : Page
    {
        public FilmfuerBewertungAuswaehlen()
        {
            InitializeComponent();
        }

        private void Filme_ListView(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Bewertung_Button(object sender, RoutedEventArgs e)
        {
            FilmBewerten filmBewerten = new FilmBewerten();
            this.NavigationService.Navigate(filmBewerten);
        }
    }
}
