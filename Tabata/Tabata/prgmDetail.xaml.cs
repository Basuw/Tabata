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
    /// Logique d'interaction pour prgmDetail.xaml
    /// </summary>
    public partial class prgmDetail : UserControl
    {
        public Manager Manager => (App.Current as App).LeManager;
        public prgmDetail()
        {
            InitializeComponent();
            DataContext = Manager.progSelect;
            maListBox.ItemsSource = Manager.progSelect.ExosList;
            muscleListBox.ItemsSource = Manager.progSelect.MuscleList;
        }
        private void clkChrono(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new chrono();
        }

        private void maListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
