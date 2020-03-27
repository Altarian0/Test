using FunctionTestApp.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FunctionTestApp.Pages
{
    /// <summary>
    /// Interaction logic for ChartDrawTest.xaml
    /// </summary>
    public partial class ChartDrawTest : Page
    {
        public ChartDrawTest()
        {
            InitializeComponent();
            ChartPrices.ChartAreas.Add(new ChartArea("Main"));

            Series series = new Series("Man")
            {
                IsValueShownAsLabel = true
            };
            ChartPrices.Series.Add(series);

            ChartTypes.ItemsSource = Enum.GetValues(typeof(SeriesChartType));

        }

        private void ChartTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ChartTypes.SelectedItem is SeriesChartType selectedType)
            {

                var contracts = DBHelper.GetContext().Contract.ToList();
                Series currentSeries = new Series();
                try
                {
                    currentSeries = ChartPrices.Series.Where(n=>n.Name == "Man").Single();
                }
                catch
                {
                    MessageBox.Show("Такой серии не сущетсвует!");
                }

                currentSeries.ChartType = selectedType;
                currentSeries.Points.Clear();


                if (FromDatePicker.SelectedDate is DateTime fromDate &&
                    ToDatePicker.SelectedDate is DateTime toDate)
                {
                    foreach (var contract in contracts.Where(n => n.Date > fromDate && n.Date < toDate).ToList())
                    {
                        currentSeries.Points.AddXY(contract.Date,
                                                   contract.ContractTotalPrice);
                    }
                }
                else
                {
                    foreach (var contract in contracts)
                    {
                        currentSeries.Points.AddXY(contract.Date,
                                                   contract.ContractTotalPrice);
                    }
                }
            }
        }
    }
}
