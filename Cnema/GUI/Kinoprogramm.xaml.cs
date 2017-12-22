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

namespace GUI
{
    /// <summary>
    /// Interaktionslogik für Kinoprogramm.xaml
    /// </summary>
    public partial class Kinoprogramm : Page
    {
        public Kinoprogramm()
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

        private void Buchung_Button(object sender, RoutedEventArgs e)
        {
            Bestellung bestellung = new Bestellung();
            this.NavigationService.Navigate(bestellung);
        }

        private void FilmeBewerten_Button(object sender, RoutedEventArgs e)
        {
            FilmfuerBewertungAuswaehlen filmfuerBewertungAuswaehlen = new FilmfuerBewertungAuswaehlen();
            this.NavigationService.Navigate(filmfuerBewertungAuswaehlen);
        }

        private void FilmDetails_Button(object sender, RoutedEventArgs e)
        {
            FilmDetails filmDetails = new FilmDetails();
            this.NavigationService.Navigate(filmDetails);
        }

        private void FilmeFiltern_Click(object sender, RoutedEventArgs e)
        {
            FilmeFiltern filmeFiltern = new FilmeFiltern();
            this.NavigationService.Navigate(filmeFiltern);
        }

        private void Logout_Button(object sender, RoutedEventArgs e)
        {
            StartBildschirm startBildschirm = new StartBildschirm();
            this.NavigationService.Navigate(startBildschirm);
        }
    }
}
