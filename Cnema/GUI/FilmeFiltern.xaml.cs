using Komponenten.Bestellverwaltung;
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
            IBestellverwaltung bv = (IBestellverwaltung)App.Current.Properties["bestellung"];
            IList<Vorstellung> ergebnis = null;
            String kriteriumRadionButton = null;
            String kriteriumTitelsuche = null;

            if (Montag.IsChecked == true)
            {
                ergebnis = bv.ProgrammFilternTag(DayOfWeek.Monday);
                kriteriumRadionButton = "Montag";
            }
            else if (Dienstag.IsChecked == true)
            {
                ergebnis = bv.ProgrammFilternTag(DayOfWeek.Tuesday);
                kriteriumRadionButton = "Dienstag";
            }
            else if (Mittwoch.IsChecked == true)
            {
                ergebnis = bv.ProgrammFilternTag(DayOfWeek.Wednesday);
                kriteriumRadionButton = "Mittwoch";
            }
            else if (Donnerstag.IsChecked == true)
            {
                ergebnis = bv.ProgrammFilternTag(DayOfWeek.Thursday);
                kriteriumRadionButton = "Donnerstag";
            }
            else if (Freitag.IsChecked == true)
            {
                ergebnis = bv.ProgrammFilternTag(DayOfWeek.Friday);
                kriteriumRadionButton = "Freitag";
            }
            else if (Samstag.IsChecked == true)
            {
                ergebnis = bv.ProgrammFilternTag(DayOfWeek.Saturday);
                kriteriumRadionButton = "Samstag";
            }
            else if (Sonntag.IsChecked == true)
            {
                ergebnis = bv.ProgrammFilternTag(DayOfWeek.Sunday);
                kriteriumRadionButton = "Sonntag";
            }
            else if (zweiD.IsChecked == true)
            {
                ergebnis = bv.ProgrammFiltern3d(false);
                kriteriumRadionButton = "2D";
            }
            else if (dreiD.IsChecked == true)
            {
                ergebnis = bv.ProgrammFiltern3d(true);
                kriteriumRadionButton = "3D";
            }
            else if (Animation.IsChecked == true)
            {
                ergebnis = bv.ProgrammFilternGenre("Animation");
                kriteriumRadionButton = "Animation";
            }
            else if (Action.IsChecked == true)
            {
                ergebnis = bv.ProgrammFilternGenre("Action");
                kriteriumRadionButton = "Action";
            }
            else if (Abenteuer.IsChecked == true)
            {
                ergebnis = bv.ProgrammFilternGenre("Abenteuer");
                kriteriumRadionButton = "Abenteuer";
            }
            else if (Fantasy.IsChecked == true)
            {
                ergebnis = bv.ProgrammFilternGenre("Fantasy");
                kriteriumRadionButton = "Fantasy";
            }
            else if (Drama.IsChecked == true)
            {
                ergebnis = bv.ProgrammFilternGenre("Drama");
                kriteriumRadionButton = "Drama";
            }
            else if (Horror.IsChecked == true)
            {
                ergebnis = bv.ProgrammFilternGenre("Horror");
                kriteriumRadionButton = "Horror";
            }
            else if (Komödie.IsChecked == true)
            {
                ergebnis = bv.ProgrammFilternGenre("Komödie");
                kriteriumRadionButton = "Komödie";
            }
            else if (Krimi.IsChecked == true)
            {
                ergebnis = bv.ProgrammFilternGenre("Krimi");
                kriteriumRadionButton = "Krimi";
            }
            else if (Romanze.IsChecked == true)
            {
                ergebnis = bv.ProgrammFilternGenre("Romanze");
                kriteriumRadionButton = "Romanze";
            }
            else if (Science_Fiction.IsChecked == true)
            {
                ergebnis = bv.ProgrammFilternGenre("Science-Fiction");
                kriteriumRadionButton = "Science-Fiction";
            }
            else if (Thriller.IsChecked == true)
            {
                ergebnis = bv.ProgrammFilternGenre("Thriller");
                kriteriumRadionButton = "Thriller";
            }

            if (ergebnis != null)
            {
                if (FilmName.Text != null && FilmName.Text != "")
                {
                    // Suche nach Titel UND einer Kategorie möglich
                    ergebnis = bv.ProgrammFilternTitel(FilmName.Text, ergebnis);
                    kriteriumTitelsuche = FilmName.Text;
                }
            }
            else if (FilmName.Text != null && FilmName.Text != "")
            {
                ergebnis = bv.ProgrammFilternTitel(FilmName.Text);
                kriteriumTitelsuche = FilmName.Text;
            }

            if (ergebnis != null)
            {
                // Kriterien zum Anzeigen an nächste Seite übergeben
                String suchwort = null;
                if (kriteriumRadionButton != null && kriteriumTitelsuche == null)
                    suchwort = kriteriumRadionButton;
                else if (kriteriumRadionButton == null && kriteriumTitelsuche != null)
                    suchwort = "\"" + kriteriumTitelsuche + "\"";
                else 
                    suchwort = kriteriumRadionButton + "  +  " + "\"" + kriteriumTitelsuche + "\"";

                Suchergebnis suchergebnis = new Suchergebnis(ergebnis, suchwort);
                this.NavigationService.Navigate(suchergebnis);
            }
            
        }

        private void Action_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Abbrechen_Click(object sender, RoutedEventArgs e)
        {
            Kinoprogramm programm = new Kinoprogramm();
            this.NavigationService.Navigate(programm);
        }
    }
}
