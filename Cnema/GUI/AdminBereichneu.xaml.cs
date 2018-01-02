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

using Komponenten.Datenbank;
using Komponenten.ET;
using Komponenten.Datenbank.Impl;

namespace GUI
{
    /// <summary>
    /// Interaktionslogik für AdminBereichneu.xaml
    /// </summary>
    public partial class AdminBereichneu : Page
    {

        public AdminBereichneu()
        {
            InitializeComponent();
            LadeFilme();
        }

        private void ListViewFilme_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        public void LadeFilme()
        {
            listViewFilme.ItemsSource = DatenbankManager.Instance.AlleFilmeLesen();
        }

        // Context Menu
        private void ContextMenuListViewFilmeEdit_OnClick(object sender, RoutedEventArgs e)
        {
            if (listViewFilme.SelectedIndex > -1)
            {
                Film selectedFilm = (Film) listViewFilme.SelectedItem; // casting the list view 
                FilmHinzufuegenNeu filmHinzufuegenNeu = new FilmHinzufuegenNeu(selectedFilm, this);
                filmHinzufuegenNeu.ShowDialog();
            }
        }

        private void ContextMenuListViewFilmeRemove_OnClick(object sender, RoutedEventArgs e)
        {
            if (listViewFilme.SelectedIndex > -1)
            {
                Film selectedFilm = (Film)listViewFilme.SelectedItem; // casting the list view 
                DatenbankManager.Instance.FilmLoeschen(selectedFilm);

                LadeFilme();
            }
        }

        // Menu Items

        private void MenuItemFilmHinzufuegen_Click(object sender, RoutedEventArgs e)
        {
            FilmHinzufuegenNeu filmHinzufuegenNeu = new FilmHinzufuegenNeu(null, this);
            filmHinzufuegenNeu.ShowDialog();
        }

        private void MenuItemVorstellungHinzufuegen_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItemAdminLogout_Click(object sender, RoutedEventArgs e)
        {
            StartBildschirm startBildschirm = new StartBildschirm();
            this.NavigationService.Navigate(startBildschirm);
        }

    }
}
