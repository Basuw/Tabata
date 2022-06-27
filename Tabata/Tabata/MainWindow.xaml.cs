using ClassTest;
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

namespace Tabata
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Manager Mgr => (App.Current as App).LeManager;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void clickProfil(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new Profil();
        }
        private void clickSante(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new suiviSante();
        }
        private void clickFavs(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new fav();
        }
        private void clickProgs(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new programmes();
        }
        private void clickExos(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new exos();
        }

    }
}
