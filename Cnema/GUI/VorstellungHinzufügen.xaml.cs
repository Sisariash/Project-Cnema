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
using Komponenten.Kinoprogrammverwaltung;
using System.Globalization;

namespace GUI
{
    /// <summary>
    /// Interaktionslogik für VorstellungHinzufügen.xaml
    /// </summary>
    public partial class VorstellungHinzufügen : Window
    {
        private Vorstellung vorstellung;
        private AdminBereichneu adminBereichneu;
        private IKinoprogrammverwaltung kv = (IKinoprogrammverwaltung)App.Current.Properties["programm"];
        public VorstellungHinzufügen(Vorstellung v, AdminBereichneu a)
        {
            InitializeComponent();
            vorstellung = v;
            adminBereichneu = a;
            SaalAuswahl.ItemsSource = kv.SaeleLesen();
            FilmAuswahl.ItemsSource = kv.AlleFilmLesen();
        }

        private void ButtonVorstellungHinzufuegenSpeichern_Click(object sender, RoutedEventArgs e)
        {
            
            if (TagAuswahl.SelectedDate != null && UhrzeitAuswahl.SelectedIndex > -1 && SaalAuswahl.SelectedIndex > -1 && FilmAuswahl.SelectedIndex > -1)
            {
                StringBuilder datum = new StringBuilder(TagAuswahl.SelectedDate.Value.ToString("dd.MM.yyyy"));
                datum.Append(".");
                datum.Append(UhrzeitAuswahl.Text);
                DateTime dateTime;
                bool datumKorrekt = DateTime.TryParseExact(datum.ToString(), "dd.MM.yyyy.HH:mm",CultureInfo.InvariantCulture , DateTimeStyles.None, out dateTime);
                if (datumKorrekt)
                {
                    if (kv.VorstellungHinzufuegen(dateTime, (Saal)SaalAuswahl.SelectedItem, (Film)FilmAuswahl.SelectedItem))
                    {
                        Close();
                        adminBereichneu.LadeVorstellungen();
                    }
                    else
                    {
                        Fehlermeldung.Content = "Keine Vorstellung zu diesem Zeitpunkt möglich.";
                        Fehlermeldung.Visibility = Visibility.Visible;
                    }
                }
                else
                {
                    Fehlermeldung.Content = "Datum inkorrekt";
                    Fehlermeldung.Visibility = Visibility.Visible;
                }
            }         
        }

        private void ButtonVorstellungHinzufuegenAbbrechen_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void TagAuswahl_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Fehlermeldung.Visibility = Visibility.Hidden;
        }

        private void UhrzeitAuswahl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Fehlermeldung.Visibility = Visibility.Hidden;
        }
    }
}
