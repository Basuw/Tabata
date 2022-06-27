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
using ClassTest;

namespace Tabata
{
    /// <summary>
    /// Logique d'interaction pour programmes.xaml
    /// </summary>
    public partial class programmes : UserControl
    {
        public Manager Manager => (App.Current as App).LeManager;
        public programmes()
        {
            InitializeComponent();
            ListBoxReco.ItemsSource = Manager.ListProgReco;
            ListBoxProg.ItemsSource = Manager.ListPrgm;
        }

        private void ListBoxReco_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Manager.progSelect = e.AddedItems[0] as Programs;
            contentControl.Content = new prgmDetail();
        }

        private void ListBoxProg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Manager.progSelect = e.AddedItems[0] as Programs;
            contentControl.Content = new prgmDetail();
        }
    }
}
