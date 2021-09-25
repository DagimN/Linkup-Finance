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
        private int zoomValue = 99;

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
            bankPieChart.LegendLocation = LegendLocation.Right;

            pettyCashSolidGauge.Uses360Mode = true;
            pettyCashSolidGauge.To = projectForm.bankManager.GetTotalPettyVaultsBound();

            transactionChart.Pan = PanningOptions.X;
            transactionChart.AxisX.Add(xAxis);
            transactionChart.AxisY.Add(yAxis);
        }

        private void transactionDateSelection_ValueChanged(object sender, EventArgs e)
        {
            DateTime dateSelection = transactionDateSelection.Value;
            xAxis.MinValue = dateSelection.Subtract(TimeSpan.FromDays(5)).Ticks / TimeSpan.TicksPerDay;
            xAxis.MaxValue = dateSelection.AddDays(5).Ticks / TimeSpan.TicksPerDay;
            zoomValue = 99;
            zoomTrackBar.Value = zoomValue;
        }

        private void zoomTrackBar_ValueChanged(object sender, EventArgs e)
        {
            int value = zoomTrackBar.Value;

            if (value > zoomValue)
            {
                xAxis.MinValue += (value - zoomValue) * 2.5;
                xAxis.MaxValue -= (value - zoomValue) * 2.5;
                zoomValue = value;
            }
            else
            {
                xAxis.MinValue -= (zoomValue - value) * 2.5;
                xAxis.MaxValue += (zoomValue - value) * 2.5;
                zoomValue = value;
            }
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            projectForm.incomeTableAdapter.Fill(projectForm.linkupDatabaseDataSet.Income);
            projectForm.expenseTableAdapter.Fill(projectForm.linkupDatabaseDataSet.Expense);
            projectForm.banksTableAdapter.Fill(projectForm.linkupDatabaseDataSet.Banks);

            transactionChart.Series.Add(incomeSeries);
            transactionChart.Series.Add(expenseSeries);

            LoadChart(projectForm.incomeTableAdapter.GetData());
            LoadChart(projectForm.expenseTableAdapter.GetData());
            LoadChart(projectForm.banksTableAdapter.GetData());

            numBanksLabel.Text = $"Bank Accounts Owned   {projectForm.banksTableAdapter.GetData().Rows.Count}";
            pettyCashLabel.Text = $"Petty Cash Remaining   {projectForm.bankManager.GetTotalPettyVaultsAmount()}";
            bankTotalLabel.Text = $"Total   {projectForm.bankManager.GetTotalBankAmount(projectForm.banksTableAdapter.GetData())} ETB";
            pettyCashSolidGauge.Value = double.Parse(projectForm.bankManager.GetTotalPettyVaultsAmount().ToString());
        }

        #region Custom Functions
        public void LoadChart(DataTable dataTable)
        {
            DataRow[] sortedData;

            if (dataTable is LinkupDatabaseDataSet.IncomeDataTable)
            {
                incomeSeries.Values.Clear();
                sortedData = projectForm.SortData(dataTable);

                for (int i = 0; i < sortedData.Length; i++)
                {
                    DateTime time;
                    
                    time = (DateTime)sortedData[i].ItemArray[9];

                    incomeSeries.Values.Add(new DateModel
                    {
                        DateTime = time,
                        Value = double.Parse(sortedData[i].ItemArray[8].ToString())
                    });
                }
            }

            if(dataTable is LinkupDatabaseDataSet.ExpenseDataTable)
            {
                expenseSeries.Values.Clear();
                sortedData = projectForm.SortData(dataTable);

                for (int i = 0; i < sortedData.Length; i++)
                {
                    DateTime time;
                    
                    time = (DateTime)sortedData[i].ItemArray[8];

                    expenseSeries.Values.Add(new DateModel
                    {
                        DateTime = time,
                        Value = double.Parse(sortedData[i].ItemArray[10].ToString())
                    });
                }
            }

            if(dataTable is LinkupDatabaseDataSet.BanksDataTable)
            {
                bankPieChart.Series.Clear();

                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    bankPieChart.Series.Add(new PieSeries
                    {
                        Values = new ChartValues<decimal> { (decimal)dataTable.Rows[i].ItemArray[3] },
                        Title = dataTable.Rows[i].ItemArray[1].ToString()
                    });
                }
            }
        }

        public void RefreshDashboard()
        {
            pettyCashSolidGauge.To = projectForm.bankManager.GetTotalPettyVaultsBound();
            numBanksLabel.Text = $"Bank Accounts Owned   {projectForm.banksTableAdapter.GetData().Rows.Count}";
            pettyCashLabel.Text = $"Petty Cash Remaining   {projectForm.bankManager.GetTotalPettyVaultsAmount()}";
            bankTotalLabel.Text = $"Total   {projectForm.bankManager.GetTotalBankAmount()} ETB";
            pettyCashSolidGauge.Value = double.Parse(projectForm.bankManager.GetTotalPettyVaultsAmount().ToString());
        }
        #endregion
    }
}
