using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Logique d'interaction pour suiviSante.xaml
    /// </summary>
    public partial class suiviSante : UserControl
    {
        public Manager Manager => (App.Current as App).LeManager;
        public suiviSante()
        {
            InitializeComponent();
            DataContext = Manager.User;
            IMC.DataContext = Manager.User.IMC();
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo();
            psi.UseShellExecute = true;
            psi.FileName = e.Uri.AbsoluteUri.ToString();
            System.Diagnostics.Process.Start(psi);
        }
    }
}
