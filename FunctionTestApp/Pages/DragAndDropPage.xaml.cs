using FunctionTestApp.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FunctionTestApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для DragAndDropPage.xaml
    /// </summary>
    public partial class DragAndDropPage : Page
    {
        public DragAndDropPage()
        {
            InitializeComponent();
            
        }

        DropImage DropImage = new DropImage();

        private void ListBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effects = DragDropEffects.Copy;
            }
        }

        private void ListBox1_DragLeave(object sender, DragEventArgs e)
        {

        }

        private void ListBox1_Drop(object sender, DragEventArgs e)
        {
            try
            {
                
                string[] Main = (string[])e.Data.GetData(DataFormats.FileDrop);
                ListBox1.Items.Add(new DropImage { Uri = Main[0].ToString() });
                
            }
            catch
            {

            }
        }

        private void ListBox1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void ListBox1_Copy_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effects = DragDropEffects.Copy;
            }
        }

        private void ListBox1_Copy_Drop(object sender, DragEventArgs e)
        {
            
            ListBox1_Copy.Items.Add(DropImage);
        
        }

        private void ListBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DropImage = (DropImage)ListBox1.SelectedItem;
            DragDrop.DoDragDrop(ListBox1, DropImage.Text, DragDropEffects.Copy);
           
        }
    }
}
