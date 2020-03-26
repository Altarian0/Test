using FunctionTestApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace FunctionTestApp.Pages
{
    /// <summary>
    /// Interaction logic for ImageSortPage.xaml
    /// </summary>
    public partial class ImageSortPage : Page
    {
        string Username;
        FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
        List<SortImage> sortImages = new List<SortImage>();
        public ImageSortPage()
        {
            InitializeComponent();

            Username = Environment.UserName;
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                PathLabel.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            var list = sortImages;
            List<Temp> temps = new List<Temp>();

            //Перебираем список путей
            foreach (var item in list)
            {
                Temp temp = new Temp { Name = item.FileInfo.Name, Length = item.FileInfo.Length };

                //При наличии в списке этого файла, его удаляют, иначе добавляют в список
                if (temps.Contains(temp))
                {
                    File.Delete(item.FileInfo.FullName);
                }
                else
                {
                    temps.Add(temp);
                }
            }

            sortImages.Clear();
            SortListBox.Items.Clear();
            PathLabel.Text = "";
            ClearButton.IsEnabled = false;
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            if (PathLabel.Text != "")
            {
                DirectoryInfo directoryInfo = null;
                SortListBox.Items.Clear();
                sortImages.Clear();
                try
                {
                    directoryInfo = new DirectoryInfo(PathLabel.Text);
                    var allFoundFiles = directoryInfo.GetFiles(@"*.jpg", SearchOption.AllDirectories);
                    var allFoundFilesPng = directoryInfo.GetFiles(@"*.png", SearchOption.AllDirectories);
                    foreach (var file in allFoundFiles)
                    {
                        sortImages.Add(new SortImage { FileInfo = file });
                    }

                    foreach (var file in allFoundFilesPng)
                    {
                        sortImages.Add(new SortImage { FileInfo = file });
                    }

                    foreach (var file in sortImages)
                    {
                        SortListBox.Items.Add("Имя: " + file.FileInfo.Name + ". Размер: " + Math.Round(file.FileInfo.Length / 1024.0 / 1024.0, 2) + " Мб.");
                    }
                }
                catch
                {
                    System.Windows.MessageBox.Show("Неверный путь!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

                ClearButton.IsEnabled = true;
                SortingButton.IsEnabled = true;
            }
            else
            {
                System.Windows.MessageBox.Show("Папка не выбрана", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void SortingButton_Click(object sender, RoutedEventArgs e)
        {
            int Day = 0;
            int Month = 0;
            if (SortingFormat.SelectedItem != null)
            {

                if (SortingFormat.Text == "День")
                {
                    foreach (var item in sortImages)
                    {


                        if (item.FileInfo.CreationTime.Day == Day)
                        {
                            try
                            {

                                item.FileInfo.CopyTo(@"C:\Users\" + Username + @"\Desktop\" + item.FileInfo.CreationTime.ToString("dd.MM.yyyy") + @"\" + item.FileInfo.Name);
                            }
                            catch
                            {

                            }
                        }
                        else
                        {
                            string folderName = item.FileInfo.CreationTime.ToString("dd.MM.yyyy");
                            Day = item.FileInfo.CreationTime.Day;
                            DirectoryInfo newFolder = new DirectoryInfo(@"C:\Users\36\Desktop\" + folderName);
                            if (!newFolder.Exists)
                            {
                                newFolder.Create();
                                item.FileInfo.CopyTo(@"C:\Users\" + Username + @"\Desktop\" + folderName + @"\" + item.FileInfo.Name);
                            }
                            else
                            {
                                try
                                {
                                    item.FileInfo.CopyTo(@"C:\Users\" + Username + @"\Desktop\" + folderName + @"\" + item.FileInfo.Name);
                                }
                                catch
                                {

                                }
                            }
                        }
                    }
                }
                else if (SortingFormat.Text == "Месяц")
                {
                    foreach (var item in sortImages)
                    {


                        if (item.FileInfo.CreationTime.Month == Month)
                        {
                            try
                            {

                            item.FileInfo.CopyTo(@"C:\Users\" + Username + @"\Desktop\" + item.FileInfo.CreationTime.ToString("MM.yyyy") + @"\" + item.FileInfo.Name);
                            }
                            catch
                            {

                            }
                        }
                        else
                        {
                            string folderName = item.FileInfo.CreationTime.ToString("MM.yyyy");
                            Month = item.FileInfo.CreationTime.Month;
                            DirectoryInfo newFolder = new DirectoryInfo(@"C:\Users\36\Desktop\" + folderName);
                            if (!newFolder.Exists)
                            {
                                newFolder.Create();
                                item.FileInfo.CopyTo(@"C:\Users\" + Username + @"\Desktop\" + folderName + @"\" + item.FileInfo.Name);
                            }
                            else
                            {
                                try
                                {
                                    item.FileInfo.CopyTo(@"C:\Users\" + Username + @"\Desktop\" + folderName + @"\" + item.FileInfo.Name);
                                }
                                catch
                                {

                                }
                            }
                        }
                    }
                }
            }
            else
            {
                System.Windows.MessageBox.Show("Выберите тип сортировки");
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            //Рендерим грид
            RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap((int)this.MainGrid.Width,
                                                                           (int)this.MainGrid.Height,
                                                                           96, 96, 
                                                                           PixelFormats.Pbgra32);
            renderTargetBitmap.Render(this.MainGrid);
            
            //Кодируем в изображение
            JpegBitmapEncoder bitmapEncoder = new JpegBitmapEncoder();
            bitmapEncoder.Frames.Add(BitmapFrame.Create(renderTargetBitmap));

            //Выбираем путь сохранения
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Save format (*.jpg)|*.jpg|" +
                                    "Save format (*.png)|*.png";
            saveFileDialog.ShowDialog();
            
            //Создаем файл и сохраняем в нем изображение
            using (FileStream stream = File.Create(saveFileDialog.FileName))
            {
                bitmapEncoder.Save(stream);
            }
        }
    }
}
