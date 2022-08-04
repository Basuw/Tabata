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
using System.Windows.Threading;

namespace Tabata
{
    /// <summary>
    /// Logique d'interaction pour chrono.xaml
    /// </summary>

    public partial class chrono : UserControl
    {
        public Manager Manager => (App.Current as App).LeManager;
        public chrono()
        {
            InitializeComponent();
            DataContext = Manager.progSelect;
            place = 1;
            timerTime = new TimeSpan(0, 0, Manager.progSelect.ExerciceDuration);
            nbExec = Manager.progSelect.TailleTab;
            first = true;
            //init next ex
            nameNextEx.Text = Manager.progSelect.ExosList[place].Name;
            diffNextEx.Text = Manager.progSelect.ExosList[place].Difficulty.ToString();
            dureeNextEx.Text = Manager.progSelect.ExerciceDuration.ToString();
            //init begenning ex
            NameCurrent.Text= Manager.progSelect.ExosList[0].Name;
            BitmapImage bmi = new BitmapImage(new Uri(Manager.progSelect.ExosList[0].Image, UriKind.Relative));
            Img.Source = bmi;
            chronoTimer.Items.Add(timerTime);
            //init color
            rect.Fill = Brushes.LimeGreen;
            chronoTimer.Background = Brushes.LimeGreen;
            //init avancée
            nb=nbExo();
            avancee.Text = "0 / "+nb;
        }
        private int nb;
        private int place;
        public int Place { get { return place; } set { place = value; } }
        private bool first;
        public bool First { get { return first; } set { first = value; } }
        private bool pause = false;

        DispatcherTimer timer = new DispatcherTimer();
        public DispatcherTimer Timer { get { return timer; } set { timer = value; } }

        private TimeSpan timerTime;
        public TimeSpan TimerTime { get { return timerTime; } set { timerTime = value; } }
        private bool exo = true;
        public bool Exo { get { return exo; } set { exo = value; } }

        private int nbExec;
        
        public int nbExo()
        {
            if (Manager.progSelect.RestDuration == 0)
            {
                return Manager.progSelect.TailleTab;
            }
            else
            {
                return (Manager.progSelect.TailleTab + 1) / 2;
            }
        }
        public void TimerMethod()
        {
            timer.Tick += new EventHandler(dispatcher_timer);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }
        private void dispatcher_timer(object sender, EventArgs e)
        {

            if (TimerTime.Seconds == 0) // end of this chrono
            {
                if (nbExec == 1)// end of chrono & end of program
                {
                    avancee.Text = Place.ToString() + "/" + nb;
                    NameCurrent.Text = "Fin du programme, félicitations !";
                    BitmapImage mi = new BitmapImage(new Uri("", UriKind.Relative));
                    Img.Source = mi;
                    rect.Fill = Brushes.Goldenrod;
                    chronoTimer.Background = Brushes.Goldenrod;

                    return; 
                }
                else // end of this chrono but start of the others exos 
                {
                    nbExec--;
                    first = true;
                    execChrono();
                    depop();
                }
                if (!exo)
                {
                    avancee.Text =Place.ToString()+"/"+nb;
                }
            }
            if (first)// first tick of the chrono  
            {
                timerTime = new TimeSpan(timerTime.Hours, timerTime.Minutes, timerTime.Seconds);
                chronoTimer.Items.Clear();
                chronoTimer.Items.Add(timerTime);
                first = false;
            }
            else
            {
                timerTime = new TimeSpan(timerTime.Hours, timerTime.Minutes, timerTime.Seconds - 1);
                chronoTimer.Items.Clear();
                chronoTimer.Items.Add(timerTime);
            }
        }
        public void execChrono()
        {
            timer.Interval = new TimeSpan(0, 0, 1);
            TimeSpan timerExo = new TimeSpan(0, 0, Manager.progSelect.ExerciceDuration);
            if (Manager.progSelect.RestDuration == 0)//if no rest duration timer always for exo time
            {
                TimerTime = timerExo;
            }
            else
            {
                TimeSpan timerRest = new TimeSpan(0, 0, Manager.progSelect.RestDuration);
                if (Exo)//if exo == true timer time = timer rest -> switch
                {
                    TimerTime = timerRest;
                    Exo = false;
                    rect.Fill = Brushes.LightBlue;
                    chronoTimer.Background = Brushes.LightBlue;

                }
                else
                {

                    TimerTime = timerExo;
                    Exo = true;
                    rect.Fill = Brushes.LimeGreen;
                    chronoTimer.Background = Brushes.LimeGreen;
                }
            }

        }
        private void depop() //end of each rest
        {
            if (!exo)//Rest
            {
                NameCurrent.Text = "Repos";
                BitmapImage bmi = new BitmapImage(new Uri("img/meditation.jpg", UriKind.Relative));
                Img.Source = bmi;
            }
            else//Exo
            {
                place++;
                //Name + img current exo


                //vignette nextExo
                if (nbExec<=1)
                {

                    nameNextEx.Text = "/";
                    diffNextEx.Text = "/";
                    dureeNextEx.Text = "/";
                    NameCurrent.Text = Manager.progSelect.ExosList[place - 1].Name;
                    BitmapImage bmi = new BitmapImage(new Uri(Manager.progSelect.ExosList[place - 1].Image, UriKind.Relative));
                    Img.Source = bmi;


                }
                else
                {
                    NameCurrent.Text = Manager.progSelect.ExosList[place - 1].Name;
                    BitmapImage bmi = new BitmapImage(new Uri(Manager.progSelect.ExosList[place - 1].Image, UriKind.Relative));
                    Img.Source = bmi;
                    nameNextEx.Text = Manager.progSelect.ExosList[place].Name;
                    diffNextEx.Text = Manager.progSelect.ExosList[place].Difficulty.ToString();
                }
            }
        }

        private void chronoTimer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void PAUSE(object sender, RoutedEventArgs e)
        {
            if (!pause)
            {
                pause = true;
                timer.Stop();
            }
            else
            {
                pause = false;
                timer.Start();
            }
        }
        private void EXIT(object sender, RoutedEventArgs e)
        {
            (this.Parent as Canvas).Children.Remove(this);//marche poa
        }
        private void GO(object sender, RoutedEventArgs e)
        {
            TimerMethod();
            goButton.Visibility = Visibility.Collapsed;
        }
        
    }
}
