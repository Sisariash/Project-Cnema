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
    /// Interaktionslogik für StartBildschirm.xaml
    /// </summary>
    public partial class StartBildschirm : Page
    {
        public StartBildschirm()
        {
            InitializeComponent();
            //txtBox_Passwort.PasswordChar = '*';
        }

        private void Kunden_Login(object sender, RoutedEventArgs e)
        {

        }

        private void KundenID_TextBox(object sender, TextChangedEventArgs e)
        {

   

        }
        // !!!ACHTUNG!!! Selber geschrieben die Methode ging nicht mit Doppelklick erzeugen
        private void KundenPasswort_PasswortBox(object sender, TextChangedEventArgs e)
        {
            //AdmunPasswort_txt (So habe ich die Box Manuell genannt)

        }





        private void Registrieren_TextBox(object sender, RoutedEventArgs e)
        {

        }

        private void Admin_Login(object sender, RoutedEventArgs e)
        {


        }

        // !!!ACHTUNG!!! Selber geschrieben die Methode ging nicht mit Doppelklick erzeugen
        private void AdminPasswort_PasswortBox(object sender, TextChangedEventArgs e)
        {
            //AdmunPasswort_txt (So habe ich die Box Manuell genannt)

        }


    }
}
