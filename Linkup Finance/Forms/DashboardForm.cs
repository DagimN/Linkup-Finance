using System;
using System.Data;
using System.Windows.Forms;
using LiveCharts.Wpf;
using LiveCharts;
using LiveCharts.Configurations;
using Linkup_Finance.Managers;

namespace Linkup_Finance.Forms
{
    public partial class DashboardForm : Form
    {
        private LineSeries incomeSeries, expenseSeries;
        private Axis xAxis, yAxis, xPayrollAxis, yPayrollAxis;
        private ProjectForm projectForm;
        private SettingsForm settingsForm;
        private MainForm mainForm;
        private int zoomValue = 99;
        private AccountType loggedInAccountType;

        private class DateModel
        {
            public System.DateTime DateTime { get; set; }
            public double Value { get; set; }

        }
        public DashboardForm(ProjectForm projectForm, SettingsForm settingsForm, MainForm mainForm)
        {
            InitializeComponent();
            this.projectForm = projectForm;
            this.settingsForm = settingsForm;
            this.mainForm = mainForm;

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
                Stroke = System.Windows.Media.Brushes.DodgerBlue,
                Fill = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(50, 160, 220, 255))
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

            xPayrollAxis = new Axis
            {
                LabelFormatter = value => new DateTime((long)(value * TimeSpan.FromDays(1).Ticks)).ToString("dd MMM yyyy"),
                MaxRange = DateTime.MaxValue.Subtract(TimeSpan.FromDays(146400)).Year,
                MinValue = DateTime.Now.Subtract(TimeSpan.FromDays(15)).Ticks / TimeSpan.TicksPerDay,
                MaxValue = DateTime.Now.AddDays(15).Ticks / TimeSpan.TicksPerDay
            };

            yPayrollAxis = new Axis
            {
                MinValue = 0,
                Foreground = incomeSeries.Fill,
                LabelFormatter = value => value + " ETB"
            };

            transactionChart.Series = new SeriesCollection(dayConfig);
            payrollChart.Series = new SeriesCollection(dayConfig);
            bankPieChart.LegendLocation = LegendLocation.Right;

            pettyCashSolidGauge.Uses360Mode = true;
            pettyCashSolidGauge.To = projectForm.bankManager.GetTotalPettyVaultsBound();

            transactionChart.Pan = PanningOptions.X;
            transactionChart.AxisX.Add(xAxis);
            transactionChart.AxisY.Add(yAxis);

            payrollChart.Pan = PanningOptions.X;
            payrollChart.AxisX.Add(xPayrollAxis);
            payrollChart.AxisY.Add(yPayrollAxis);

            payrollDateSelection.Value = DateTime.Now;
            transactionDateSelection.Value = DateTime.Now;
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

        private void payrollDateSelection_ValueChanged(object sender, EventArgs e)
        {
            DateTime dateSelection = payrollDateSelection.Value;
            xPayrollAxis.MinValue = dateSelection.Subtract(TimeSpan.FromDays(15)).Ticks / TimeSpan.TicksPerDay;
            xPayrollAxis.MaxValue = dateSelection.AddDays(15).Ticks / TimeSpan.TicksPerDay;
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            mainForm.Logout();
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            projectForm.incomeTableAdapter.Fill(projectForm.linkupDatabaseDataSet.Income);
            projectForm.expenseTableAdapter.Fill(projectForm.linkupDatabaseDataSet.Expense);
            projectForm.banksTableAdapter.Fill(projectForm.linkupDatabaseDataSet.Banks);
            settingsForm.employeesTableAdapter.Fill(settingsForm.linkupDatabaseDataSet.Employees);
            settingsForm.employeeLogsTableAdapter.Fill(settingsForm.linkupDatabaseDataSet.EmployeeLogs);

            transactionChart.Series.Add(incomeSeries);
            transactionChart.Series.Add(expenseSeries);

            LoadChart(projectForm.incomeTableAdapter.GetData());
            LoadChart(projectForm.expenseTableAdapter.GetData());
            LoadChart(projectForm.banksTableAdapter.GetData());
            LoadChart(settingsForm.employeeLogsTableAdapter.GetData());

            numBanksLabel.Text = $"Bank Accounts Owned   {projectForm.banksTableAdapter.GetData().Rows.Count}";
            pettyCashLabel.Text = $"Petty Cash Remaining   {projectForm.bankManager.GetTotalPettyVaultsAmount()}";
            bankTotalLabel.Text = $"Total   {projectForm.bankManager.GetTotalBankAmount(projectForm.banksTableAdapter.GetData())} ETB";
            pettyCashSolidGauge.Value = double.Parse(projectForm.bankManager.GetTotalPettyVaultsAmount().ToString());

            employeeAmountLabel.Text = settingsForm.userManager.GetEmployeeCount(settingsForm.employeesTableAdapter.GetData()).ToString();
            paidEmployeesCountLabel.Text = settingsForm.userManager.GetPaidEmployeeCount(settingsForm.employeesTableAdapter.GetData()).ToString();

            totalBonusLabel.Text = $"Total Bonus: {settingsForm.userManager.GetTotalBonus(settingsForm.employeeLogsTableAdapter.GetData())}";
            totalTaxLabel.Text = $"Total Income Tax: {settingsForm.userManager.GetTotalIncomeTax(settingsForm.employeeLogsTableAdapter.GetData())}";
            totalPensionLabel.Text = $"Total Pension: {settingsForm.userManager.GetTotalPension(settingsForm.employeeLogsTableAdapter.GetData())}";
            totalNetLabel.Text = $"Total Net: {settingsForm.userManager.GetTotalNet(settingsForm.employeeLogsTableAdapter.GetData())}";
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

                    if (loggedInAccountType == AccountType.Admin)
                    {
                        incomeSeries.Values.Add(new DateModel
                        {
                            DateTime = time,
                            Value = double.Parse(sortedData[i].ItemArray[8].ToString())
                        });
                    }
                    else
                    {
                        if(sortedData[i].ItemArray[4].ToString() == "1")
                        {
                            incomeSeries.Values.Add(new DateModel
                            {
                                DateTime = time,
                                Value = double.Parse(sortedData[i].ItemArray[8].ToString())
                            });
                        }
                    }
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

                    if (loggedInAccountType == AccountType.Admin)
                    {
                        expenseSeries.Values.Add(new DateModel
                        {
                            DateTime = time,
                            Value = double.Parse(sortedData[i].ItemArray[10].ToString())
                        });
                    }
                    else
                    {
                        if (sortedData[i].ItemArray[12].ToString() == "1")
                        {
                            expenseSeries.Values.Add(new DateModel
                            {
                                DateTime = time,
                                Value = double.Parse(sortedData[i].ItemArray[10].ToString())
                            });
                        }
                    }
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

            if(dataTable is LinkupDatabaseDataSet.EmployeeLogsDataTable)
            {
                payrollChart.Series.Clear();
                sortedData = projectForm.SortData(dataTable);

                for(int i = 0; i < dataTable.Rows.Count; i++)
                {
                    payrollChart.Series.Add(new ColumnSeries
                    {
                        Values = new ChartValues<DateModel>
                        {
                            new DateModel
                            {
                                DateTime = (DateTime)sortedData[i].ItemArray[6],
                                Value = double.Parse(sortedData[i].ItemArray[5].ToString())
                            }
                        },
                        Title = dataTable.Rows[i].ItemArray[1].ToString(),
                        ScalesYAt = 0,
                        MaxColumnWidth = 50,
                        Fill = System.Windows.Media.Brushes.DodgerBlue
                    });
                }
            }
        }

        public void RefreshDashboard()
        {
            settingsForm.employeeLogsTableAdapter.Fill(settingsForm.linkupDatabaseDataSet.EmployeeLogs);

            pettyCashSolidGauge.To = projectForm.bankManager.GetTotalPettyVaultsBound();
            numBanksLabel.Text = $"Bank Accounts Owned   {projectForm.banksTableAdapter.GetData().Rows.Count}";
            pettyCashLabel.Text = $"Petty Cash Remaining   {projectForm.bankManager.GetTotalPettyVaultsAmount()}";
            bankTotalLabel.Text = $"Total   {projectForm.bankManager.GetTotalBankAmount()} ETB";
            pettyCashSolidGauge.Value = double.Parse(projectForm.bankManager.GetTotalPettyVaultsAmount().ToString());

            employeeAmountLabel.Text = settingsForm.userManager.GetEmployeeCount().ToString();
            paidEmployeesCountLabel.Text = settingsForm.userManager.GetPaidEmployeeCount().ToString();

            totalBonusLabel.Text = $"Total Bonus: {settingsForm.userManager.GetTotalBonus(settingsForm.employeeLogsTableAdapter.GetData())}";
            totalTaxLabel.Text = $"Total Income Tax: {settingsForm.userManager.GetTotalIncomeTax(settingsForm.employeeLogsTableAdapter.GetData())}";
            totalPensionLabel.Text = $"Total Pension: {settingsForm.userManager.GetTotalPension(settingsForm.employeeLogsTableAdapter.GetData())}";
            totalNetLabel.Text = $"Total Net: {settingsForm.userManager.GetTotalNet(settingsForm.employeeLogsTableAdapter.GetData())}";
        }

        public void SetAccountType(AccountType type)
        {
            loggedInAccountType = type;
        }
        #endregion
    }
}
