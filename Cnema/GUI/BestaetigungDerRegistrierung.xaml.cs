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
    /// Interaktionslogik für BestaetigungDerRegistrierung.xaml
    /// </summary>
    public partial class BestaetigungDerRegistrierung : Page
    {
        public BestaetigungDerRegistrierung()
        {
            InitializeComponent();

            Kunde kunde = (Kunde)Application.Current.Properties["neuRegistriert"];
            Ausgabe.Content = kunde.BenutzerId;
        }

        private void ZumLogin_Click(object sender, RoutedEventArgs e)
        {
            StartBildschirm startBildschirm = new StartBildschirm();
            this.NavigationService.Navigate(startBildschirm);
        }
    }
}
