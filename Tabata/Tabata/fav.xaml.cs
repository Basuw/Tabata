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
    /// Logique d'interaction pour fav.xaml
    /// </summary>
    public partial class fav : UserControl
    {
        public Manager Manager => (App.Current as App).LeManager;

        public fav()
        {
            InitializeComponent();
            ListBoxProg.ItemsSource = Manager.ProgFav;
            ListBoxExo.ItemsSource = Manager.ExoFav;
        }

        private void ListBoxProg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Manager.progSelect = e.AddedItems[0] as Programs;
            contentControl.Content = new prgmDetail();
        }

        private void ListBoxExo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Manager.exoSelect = e.AddedItems[0] as Exos;
            contentControl.Content = new exoDetail();
        }
    }
}
