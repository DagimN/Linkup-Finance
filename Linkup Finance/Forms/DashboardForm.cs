using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts.Wpf;
using LiveCharts;
using LiveCharts.Configurations;

namespace Linkup_Finance.Forms
{
    public partial class DashboardForm : Form
    {
        private LineSeries incomeSeries, expenseSeries;
        private Axis xAxis, yAxis;
        private ProjectForm projectForm;

        private class DateModel
        {
            public System.DateTime DateTime { get; set; }
            public double Value { get; set; }

        }
        public DashboardForm(ProjectForm projectForm)
        {
            InitializeComponent();
            this.projectForm = projectForm;

            //Initializing Chart Components
            var dayConfig = Mappers.Xy<DateModel>()
                .X(dayModel => (double)dayModel.DateTime.Ticks / TimeSpan.FromDays(1).Ticks)
                .Y(dayModel => dayModel.Value);

            incomeSeries = new LineSeries
            {
                Values = new ChartValues<DateModel>(),
                Title = "Income",
                Stroke = System.Windows.Media.Brushes.ForestGreen,
                Fill = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(50, 34, 139, 34))
            };

            expenseSeries = new LineSeries
            {
                Values = new ChartValues<DateModel>(),
                Title = "Expense",
                Stroke = System.Windows.Media.Brushes.ForestGreen,
                Fill = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(50, 34, 139, 34))
            };

            xAxis = new Axis
            {
                LabelFormatter = value => new DateTime((long)(value * TimeSpan.FromDays(1).Ticks)).ToString("dd MMM yyyy"),
                MaxRange = DateTime.MaxValue.Subtract(TimeSpan.FromDays(146400)).Year,
                MinValue = DateTime.Now.Subtract(TimeSpan.FromDays(5)).Ticks / TimeSpan.TicksPerDay,
                MaxValue = DateTime.Now.AddDays(3).Ticks / TimeSpan.TicksPerDay
            };

            yAxis = new Axis
            {
                MinValue = 0,
                Foreground = incomeSeries.Fill,
                LabelFormatter = value => value + " ETB"
            };

            transactionChart.Series = new SeriesCollection(dayConfig);
            transactionChart.Pan = PanningOptions.X;
            transactionChart.AxisX.Add(xAxis);
            transactionChart.AxisY.Add(yAxis);
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            projectForm.incomeTableAdapter.Fill(projectForm.linkupDatabaseDataSet.Income);
            projectForm.expenseTableAdapter.Fill(projectForm.linkupDatabaseDataSet.Expense);

            transactionChart.Series.Add(incomeSeries);
            transactionChart.Series.Add(expenseSeries);

            LoadChart(projectForm.incomeTableAdapter.GetData());
            LoadChart(projectForm.expenseTableAdapter.GetData());
        }

        #region Custom Functions
        private void LoadChart(DataTable dataTable)
        {
             DataRow[] sortedData = projectForm.SortData(dataTable);

            if (dataTable is LinkupDatabaseDataSet.IncomeDataTable)
                incomeSeries.Values.Clear();
            else
                expenseSeries.Values.Clear();

            for (int i = 0; i < sortedData.Length; i++)
            {
                DateTime time;
                if (dataTable is LinkupDatabaseDataSet.IncomeDataTable)
                {
                    time = (DateTime)sortedData[i].ItemArray[9];

                    incomeSeries.Values.Add(new DateModel
                    {
                        DateTime = time,
                        Value = double.Parse(sortedData[i].ItemArray[8].ToString())
                    });
                }

                else
                {
                    time = (DateTime)sortedData[i].ItemArray[8];

                    expenseSeries.Values.Add(new DateModel
                    {
                        DateTime = time,
                        Value = double.Parse(sortedData[i].ItemArray[10].ToString())
                    });
                }
            }
        }
        #endregion
    }
}
