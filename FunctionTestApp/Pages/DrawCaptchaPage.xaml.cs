using System;
using System.Collections.Generic;
using System.Drawing;
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

namespace FunctionTestApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для DrawCaptchaPage.xaml
    /// </summary>
    public partial class DrawCaptchaPage : Page
    {
        public DrawCaptchaPage()
        {
            InitializeComponent();
        }

        private void Captcha_Click(object sender, RoutedEventArgs e)
        {
            int inc = 0;

            Captcha.Children.Clear();
            CaptchaLabel.Text = "";

            char[] chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray(); 

            Random random = new Random();

            for (int i = 0; i < 7; i++)
            {
                CaptchaLabel.Text += chars[random.Next(0, chars.Length)];
            }

            RotateTransform rotateTransform = new RotateTransform();
            rotateTransform.Angle = random.Next(-90, 90);
            CaptchaLabel.RenderTransform = rotateTransform;

            while (inc < 200)
            {
                inc++;

                
                int left = random.Next(0, (int)Captcha.Width);
                int right = random.Next(0, (int)Captcha.Width);
                int top = random.Next(0, (int)Captcha.Height);
                int bottom = random.Next(0, (int)Captcha.Height);

                Ellipse ellipse = new Ellipse();
                ellipse.Fill = System.Windows.Media.Brushes.Red;
                ellipse.Height = 10;
                ellipse.Width = 10;
                ellipse.Margin = new Thickness(left, top, right, bottom);

                
                
                Captcha.Children.Add(ellipse);
                
            }
        }
    }
}
