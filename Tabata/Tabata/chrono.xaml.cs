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
        private bool pause = false;

        DispatcherTimer timer = new DispatcherTimer();
        public DispatcherTimer Timer { get { return timer; } set { timer = value; } }
        public Manager Manager => (App.Current as App).LeManager;

        public chrono()
        {
            InitializeComponent();
        }
        private TimeSpan timerTime = new TimeSpan(0, 0, 45);

        public TimeSpan TimerTime { get { return timerTime; } set { timerTime = value; } }


        public void TimerMethod()
        {
            timer.Tick += new EventHandler(dispatcher_timer);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }
        private void dispatcher_timer(object sender, EventArgs e)
        {
            if (timerTime.Seconds == 0) return;
            else
            {
                timerTime = new TimeSpan(timerTime.Hours, timerTime.Minutes, timerTime.Seconds - 1);
            }
            chronoTimer.Items.Clear();
            chronoTimer.Items.Add(timerTime);
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
        private void GO(object sender, RoutedEventArgs e)
        {
            TimerMethod();
            goButton.Visibility = Visibility.Collapsed;
        }
        private void EXIT(object sender, RoutedEventArgs e)
        {
            (this.Parent as Canvas).Children.Remove(this);
        }

    }
}
