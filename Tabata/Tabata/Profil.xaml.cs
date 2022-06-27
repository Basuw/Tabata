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
    /// Logique d'interaction pour Profil.xaml
    /// </summary>
    public partial class Profil : UserControl
    {
        public Manager Manager => (App.Current as App).LeManager;
        public Profil()
        {
            InitializeComponent();
            DataContext = Manager.User;
            Age.DataContext = Manager.User.AgeCalcul();
        }

        private void clickModifProf(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new profilModif();
        }
    }
}
