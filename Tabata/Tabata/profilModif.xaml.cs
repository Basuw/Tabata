using System;
using System.Collections.Generic;
using System.IO;
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
    /// Logique d'interaction pour profilModif.xaml
    /// </summary>
    public partial class profilModif : UserControl
    {
        public Manager Mgr => (App.Current as App).LeManager;
        public profilModif()
        {
            InitializeComponent();
            DataContext = Mgr.User;
        }

        private void clickEnrProf(object sender, RoutedEventArgs e)
        {
            Mgr.User.Firstname = chgFisrtname.Text;
            Mgr.User.Lastname = chgLastname.Text;
            Mgr.User.BirthDate = DateTime.Parse(chgBirthDate.Text);
            Mgr.User.Weight = int.Parse(chgWeight.Text);
            Mgr.User.Height = int.Parse(chgHeight.Text);
            Mgr.User.Sexe = chgSexe.Text;
            Mgr.User.SportPractice = chgSportPractice.Text;
            Mgr.User.SportFrequency = int.Parse(chgSportFrequency.Text);
            Mgr.User.WeightGoal = int.Parse(chgWeightGoal.Text);
            Mgr.User.Goal = chgGoal.Text;
            Mgr.User.TrainingGoal = int.Parse(chgTrainingGoal.Text);

            contentControl.Content = new Profil();
            Mgr.DataSave();
        }

        private void modifImage(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.InitialDirectory = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "profilePictures");
            dlg.FileName = "profilImage";
            dlg.DefaultExt = ".jpg | .png";
            dlg.Filter = "All images files (.jpg, .png)|*.jpg;*.png|JPG files (.jpg)|*.jpg|PNG files (.png)|*.png";

            bool? result = dlg.ShowDialog();

            if (result == true) 
            {
                string filename = dlg.FileName;
                imgProfile.Source = new BitmapImage(new Uri(filename, UriKind.Absolute));
                Mgr.User.Image = filename;
            }
        }
    }
}
