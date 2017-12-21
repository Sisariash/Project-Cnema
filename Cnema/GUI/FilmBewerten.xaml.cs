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
    /// Interaktionslogik für FilmBewerten.xaml
    /// </summary>
    public partial class FilmBewerten : Page
    {
        public FilmBewerten()
        {
            InitializeComponent();
        }

       

        private void Zwei_CheckBox(object sender, RoutedEventArgs e)
        {

        }

        private void Drei_CheckBox(object sender, RoutedEventArgs e)
        {

        }

        private void Vier_CheckBox(object sender, RoutedEventArgs e)
        {

        }


        private void Bewertung_Button(object sender, RoutedEventArgs e)
        {

        }

        private void BewertungButton_Click(object sender, RoutedEventArgs e)
        {
            FilmBewertenabgeschlossen filmBewertenabgeschlossen = new FilmBewertenabgeschlossen();
            this.NavigationService.Navigate(filmBewertenabgeschlossen);
        }



        private void Fuenf_CheckBox(object sender, RoutedEventArgs e)
        {

        }

        private void Eins_CheckBox(object sender, RoutedEventArgs e)
        {

        }
    }

 
    }

