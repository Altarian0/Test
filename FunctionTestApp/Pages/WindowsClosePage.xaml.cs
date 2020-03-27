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

namespace FunctionTestApp.Pages
{
    /// <summary>
    /// Interaction logic for WindowsClosePage.xaml
    /// </summary>
    public partial class WindowsClosePage : Page
    {
        DispatcherTimer Timer = new DispatcherTimer();

        DateTime StopTime = new DateTime();
        DateTime StartTime = DateTime.Now;
        public WindowsClosePage()
        {
            InitializeComponent();
            StopTime = DateTime.Now + new TimeSpan(0, 0, 0, 5);
            Timer.Interval = new TimeSpan(0, 0, 0, 1);
            Timer.Tick += TimerTick;
            Timer.Start();
            TimeLabel.Content = $"До закрытия окон осталось {(StopTime - StartTime).ToString().Split(new char[] { '.' })[0]}";

        }

        private void ReloadTimer()
        {
            StopTime = DateTime.Now + new TimeSpan(0, 0, 0, 5);
            StartTime = DateTime.Now;
            TimeLabel.Content = $"До закрытия окон осталось {(StopTime - StartTime).ToString().Split(new char[] { '.' })[0]}";
        }

        private void TimerTick(object sender, EventArgs e)
        {
            DateTime StartTime = DateTime.Now;
            TimeLabel.Content = $"До закрытия окон осталось {(StopTime - StartTime).ToString().Split(new char[] { '.' })[0]}";
            if (StartTime>StopTime)
            {
                WindowsClose();
                Timer.Stop();
                NavigationService.Navigate(new StartPage());
            }
        }

        private void WindowsClose()
        {
            while (App.Current.Windows.Count > 1)
            {
                App.Current.Windows[1].Close();
            }
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            Window window = new Window();
            window.Height = 200;
            window.Width = 250;
            window.Show();

            ReloadTimer();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            ReloadTimer();
        }
    }
}
