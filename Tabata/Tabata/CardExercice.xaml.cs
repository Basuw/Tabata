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
    /// Logique d'interaction pour CardExercice.xaml
    /// </summary>
    public partial class CardExercice : UserControl
    {
        public Manager Manager => (App.Current as App).LeManager;
        public CardExercice()
        {
            InitializeComponent();
        }

        private void clickHeart(object sender, RoutedEventArgs e)
        {
            Manager.exoSelect.changeFav(exoName.Text, Manager.ListExo, Manager.ExoFav);
            contentControl.Content = new CardExercice();
        }
    }
}
