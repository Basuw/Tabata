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
    /// Logique d'interaction pour mini_exo.xaml
    /// </summary>
    public partial class mini_exo : UserControl
    {
        public Manager Manager => (App.Current as App).LeManager;
        public mini_exo()
        {
            InitializeComponent();
            Time.DataContext = Manager.progSelect;
        }
    }
}
