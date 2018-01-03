﻿using System;
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
            LadeVorstellungen();
            LadeBestellungen();
            LadeKunden();
            LadeAdmins();        }

 

        public void LadeVorstellungen()
        {
            listViewVorstellung.ItemsSource = DatenbankManager.Instance.AlleVorstellungenLesen();
        }

        public void LadeBestellungen()
        {
            listViewBestellungen.ItemsSource = DatenbankManager.Instance.AlleBestellungenLesen();
        }
        public void LadeKunden()
        {
            listViewKunden.ItemsSource = DatenbankManager.Instance.AlleKundenLesen();
        }
        public void LadeAdmins()
        {
            listViewAdmins.ItemsSource = DatenbankManager.Instance.AlleAdminsLesen();
        }
        public void LadeFilme()
        {
            listViewFilme.ItemsSource = DatenbankManager.Instance.AlleFilmeLesen();
        }

        // Context Menu


            private void ContextMenuListViewVorstellungEdit_OnClick(object sender, RoutedEventArgs e)
        {
            /**if (listViewVorstellung.SelectedIndex > -1)
            {
                Vorstellung selectedVorstellung = (Vorstellung)listViewVorstellung.SelectedItem; // casting the list view 
                FilmHinzufuegenNeu filmHinzufuegenNeu = new FilmHinzufuegenNeu(selectedVorstellung, this);
                filmHinzufuegenNeu.ShowDialog();
            }
            */
        }

        private void ContextMenuListViewVorstellungRemove_OnClick(object sender, RoutedEventArgs e)
        {

            // Wieso Löscht das nicht die Vorstellung????
            if (listViewVorstellung.SelectedIndex > -1)
            {
                Vorstellung selectedvorstellung = (Vorstellung)listViewVorstellung.SelectedItem; // casting the list view 
                DatenbankManager.Instance.VorstellungLoeschen(selectedvorstellung);

                LadeVorstellungen();
            }

        }

  
        private void ContextMenuListViewBestellungEdit_OnClick(object sender, RoutedEventArgs e)
        {


        }

        private void ContextMenuListViewBestellungRemove_OnClick(object sender, RoutedEventArgs e)
        {
            
            if (listViewBestellungen.SelectedIndex > -1)
            {
                Bestellung selectedbestellung = (Bestellung)listViewBestellungen.SelectedItem; // casting the list view 
                DatenbankManager.Instance.BestellungLoeschen(selectedbestellung);

                LadeBestellungen();
            }
            
        }

        private void ContextMenuListViewKundeEdit_OnClick(object sender, RoutedEventArgs e)
        {


        }

      private void ContextMenuListViewKundeRemove_OnClick(object sender, RoutedEventArgs e)
        {

            if (listViewKunden.SelectedIndex > -1)
            {
                Kunde selectedKunde = (Kunde)listViewKunden.SelectedItem; // casting the list view 
                DatenbankManager.Instance.KundeLoeschen(selectedKunde);

                LadeKunden();
            }


        }

        private void ContextMenuListViewAdminEdit_OnClick(object sender, RoutedEventArgs e)
        {

        }

        private void ContextMenuListViewAdminRemove_OnClick(object sender, RoutedEventArgs e)
        {
            if (listViewAdmins.SelectedIndex > -1)
            {
                Admin selectedAdmin = (Admin)listViewAdmins.SelectedItem; // casting the list view 
                DatenbankManager.Instance.AdminLoeschen(selectedAdmin);

                LadeAdmins();
            }
        }



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
            VorstellungHinzufügen vorstellungHinzufügen = new VorstellungHinzufügen(null, this);
            vorstellungHinzufügen.ShowDialog();
        }

        private void ListViewFilme_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

       

        private void ListViewVorstellung_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListViewBestellungen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListViewKunden_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListViewAdmin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void MenuItemAdminLogout_Click(object sender, RoutedEventArgs e)
        {
            StartBildschirm startBildschirm = new StartBildschirm();
            this.NavigationService.Navigate(startBildschirm);
        }


    }
}
