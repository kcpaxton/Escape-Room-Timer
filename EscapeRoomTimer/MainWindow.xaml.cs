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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace EscapeRoomTimer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer _timer;
        TimeSpan _time;
        public MainWindow()
        {
            InitializeComponent();
            
            Timer.Visibility = Visibility.Hidden;
            image.Visibility = Visibility.Hidden;
            Pulse.Visibility = Visibility.Hidden;




        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void StartBtn_Click(object sender, RoutedEventArgs e)
        {
            StartBtn.Visibility = Visibility.Hidden;
            Timer.Visibility = Visibility.Visible;
            image.Visibility = Visibility.Visible;
            Pulse.Visibility = Visibility.Visible;

            Storyboard sb = this.FindResource("Storyboard1") as Storyboard;
            

            _time = TimeSpan.FromHours(1);
            _timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                Timer.Text = _time.ToString("c");

                if (_time == TimeSpan.Zero) _timer.Stop();
                _time = _time.Add(TimeSpan.FromSeconds(-1));
            }, Application.Current.Dispatcher);
            _timer.Start();
            sb.Begin();
        }
    }

}
