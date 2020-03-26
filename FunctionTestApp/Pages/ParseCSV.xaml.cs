using FunctionTestApp.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;

namespace FunctionTestApp.Pages
{
    /// <summary>
    /// Interaction logic for ParseCSV.xaml
    /// </summary>
    public partial class ParseCSV : Page
    {
        List<Volunteer> volunteers = new List<Volunteer>();
        string path = "";
        public ParseCSV()
        {
            InitializeComponent();
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV files (*.csv)|*.csv";
            openFileDialog.ShowDialog();

            path = openFileDialog.FileName;
            PathBox.Text = path;
        }

        private void ImportButton_Click(object sender, RoutedEventArgs e)
        {
            volunteers.Clear();
            VolunteerData.Items.Clear();


            foreach (var volunteer in Volunteer.ParseVolunteer(path))
            {
                volunteers.Add(volunteer);
            }

            foreach (var volunteer in volunteers)
            {
                VolunteerData.Items.Add(volunteer);
            }

            var VolCode = volunteers.Select(n=>n.CountryCode).Distinct().ToList();

            foreach (var Country in VolCode)
            {
                ExportComboBox.Items.Add(Country);
            }
        }

        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                Filter = "File format (*.csv)|*.csv"
            };
            saveFileDialog.ShowDialog();

            using (FileStream stream = File.Create(saveFileDialog.FileName))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    if (ExportComboBox.Text != "")
                    {
                        foreach (var item in volunteers.Where(n=>n.CountryCode == ExportComboBox.Text).ToList())
                        {
                            writer.WriteLine(item.Id + "," + item.Name + "," + item.LastName + "," + item.CountryCode + "," + item.Gender);
                        }
                    }
                }
            }


        }
    }
}
