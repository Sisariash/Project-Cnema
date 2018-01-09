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
using System.Windows.Shapes;

using Komponenten.ET;
using Komponenten.Datenbank.Impl;
using Komponenten.Kinoprogrammverwaltung;

namespace GUI
{
    /// <summary>
    /// Interaktionslogik für FilmHinzufuegenNeu.xaml
    /// </summary>
    public partial class FilmHinzufuegenNeu : Window
    {
        private Film film;
        private AdminBereichneu adminBereichneu;

        public FilmHinzufuegenNeu(Film film, AdminBereichneu adminBereichneu)
        {
            InitializeComponent();

            // Set Views
            ComboBoxFilmGenre.ItemsSource = Film.Genres();

            // Set Properties
            if (film != null)
            {
                Title = "Film bearbeiten";

                TextBoxFilmTitel.Text = film.Titel;
                TextBoxFilmJahr.Text = film.Jahr + "";
                TextBoxFilmSprache.Text = film.Sprache;
                TextBoxFilmLaenge.Text = film.Laenge + "";
                ComboBoxFilmGenre.Text = film.Genre;
                TextBoxFilmFsk.Text = film.Fsk + "";
                CheckBoxFilmIs3D.IsChecked = film.Is3D;
            }
            else
            {
                Title = "Film hinzufügen";
            }

            this.film = film;
            this.adminBereichneu = adminBereichneu;
        }

        // Getter & Setter

        private void ButtonFilmHinzufuegenAbbrechen_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonFilmHinzufuegenSpeichern_Click(object sender, RoutedEventArgs e)
        {
            IKinoprogrammverwaltung kinoprogrammverwaltung = (IKinoprogrammverwaltung)App.Current.Properties["programm"];
            // Validate Input
            if(!ValidiereInput())
            {
                return;
            }

            // Definieren
            Film film = this.film;

            if(this.film==null)
            {
                film = new Film();
            }

            // Setze Attribute
            film.Titel = TextBoxFilmTitel.Text;
            film.Sprache = TextBoxFilmSprache.Text;
            film.Jahr = Int32.Parse(TextBoxFilmJahr.Text);
            film.Genre = ComboBoxFilmGenre.Text;
            film.Laenge = Int32.Parse(TextBoxFilmLaenge.Text); 
            film.Fsk = Int32.Parse(TextBoxFilmFsk.Text); 
            film.Is3D = CheckBoxFilmIs3D.IsChecked ?? false; //Falls null dann false

            // Speichern
            if (this.film == null)
            {
                kinoprogrammverwaltung.FilmHinzufuegen(film);
            } else
            {
                kinoprogrammverwaltung.FilmAendern(film);
            }

            Close();

            // Lade Filme
            adminBereichneu.LadeFilme();
        }

        private bool ValidiereInput()
        {
            int x;
            if (!Int32.TryParse(TextBoxFilmJahr.Text, out x))
            {
                MessageBox.Show("Das Jahr muss eine Zahl sein. ", null, MessageBoxButton.OK);
                return false;
            } else
            {
                int year = Int32.Parse(TextBoxFilmJahr.Text);
                int yearMin = 1900;
                int yearMax = DateTime.Now.Year + 1;
                if (year<yearMin || year>yearMax)
                {
                    MessageBox.Show("Das Jahr muss eine Zahl zwischen " + yearMin  + " und " + yearMax + " sein.", null, MessageBoxButton.OK);
                    return false;
                }
            }

            if (!Int32.TryParse(TextBoxFilmLaenge.Text, out x))
            {
                MessageBox.Show("Die Länge muss eine Zahl sein.", null, MessageBoxButton.OK);
                return false;
            }

            if (!Int32.TryParse(TextBoxFilmFsk.Text, out x))
            {
                MessageBox.Show("FSK muss eine Zahl sein.", null, MessageBoxButton.OK);
                return false;
            }

            return true;
        }

    }
}
