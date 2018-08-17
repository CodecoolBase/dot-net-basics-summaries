using System;
using System.Windows;
using System.Windows.Threading;

namespace TimerEventsWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int PROGRESS_MAX = 100;
        private DispatcherTimer _timer;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void TimerEventsWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _timer = new DispatcherTimer();
            _timer.Interval = new TimeSpan(0, 0, 1);
            _timer.Tick += new EventHandler(dispatcherTimer_Tick);
            _timer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            myProgressBar.Value += 10;
            if (myProgressBar.Value >= PROGRESS_MAX)
            {
                _timer.Stop();
            }
        }
    }
}
