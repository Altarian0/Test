using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace FunctionTestApp.Pages
{
    /// <summary>
    /// Interaction logic for ImageRelation.xaml
    /// </summary>
    public partial class ImageRelation : Page
    {

        Image image = new Image();
        public ImageRelation()
        {
            InitializeComponent();
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            TestImage.Source = null;
            HeigthLabel.Content = null;
            WidthLabel.Content = null;
            LengthLabel.Content = null;

            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image files (*.jpg)|*.jpg|Image files (*.png)|*.png"
            };
            openFileDialog.ShowDialog();

            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new System.Uri(openFileDialog.FileName);
            bitmapImage.EndInit();

            image.Source = bitmapImage;

            double height = bitmapImage.Height;
            double width = bitmapImage.Width;
            long length = new FileInfo(openFileDialog.FileName).Length;

            if ((length / 1024) < 1024)
            {
                if (width == height - ((height * 25) / 100))
                {
                    HeigthLabel.Content = height;
                    WidthLabel.Content = width;
                    LengthLabel.Content = Math.Round((length / 1024.0), 2) + " Кб.";
                    
                    TestImage.Source = image.Source;
                }
                else
                {
                    HeigthLabel.Content = "Формат изображения должен быть 4х3";
                   
                }
            }
            else
            {
                LengthLabel.Content = "Размер файла не должен превышать 1 мб!";
            }


        }
    }
}
