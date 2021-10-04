using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;
using System.Threading;
using System.Windows.Forms;
using Linkup_Finance.Managers;
using LiveCharts.Wpf;
using LiveCharts.Configurations;
using LiveCharts;
using System.Collections.Specialized;
using System.Diagnostics;

namespace Linkup_Finance.Forms
{
    public partial class ProjectForm : Form
    {
        //TODO: Handle Resizing of controls when maximized
        public ProjectManager projectManager;
        private DashboardForm dashboardForm;
        public BankManager bankManager;
        private int zoomIncomeValue = 99, zoomExpenseValue = 99;
        private AccountType loggedInAccountType;
        
        private LineSeries grossSeries, netSeries, amountSeries, totalSeries, balanceSeries;
        private Axis xIncomeAxis, yIncomeAxis, xExpenseAxis, yExpenseAxis, xBankAxis, yBankAxis;
        private class DateModel
        {
            public System.DateTime DateTime { get; set; }
            public double Value { get; set; }
            
        }

        public ProjectForm()
        {
            InitializeComponent();
            projectManager = new ProjectManager();
            bankManager = new BankManager();

            //Initializing Chart Components
            var dayConfig = Mappers.Xy<DateModel>()
                .X(dayModel => (double)dayModel.DateTime.Ticks / TimeSpan.FromDays(1).Ticks)
                .Y(dayModel => dayModel.Value);

            grossSeries = new LineSeries
            {
                Values = new ChartValues<DateModel>(),
                Title = "Gross",
                Stroke = System.Windows.Media.Brushes.DodgerBlue,
                Fill = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(50, 160, 220, 255))
            };

            netSeries = new LineSeries
            {
                Values = new ChartValues<DateModel>(),
                Title = "Net",
                Stroke = System.Windows.Media.Brushes.ForestGreen,
                Fill = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(50, 34, 139, 34))
            };

            amountSeries = new LineSeries
            {
                Values = new ChartValues<DateModel>(),
                Title = "Amount",
                Stroke = System.Windows.Media.Brushes.DodgerBlue,
                Fill = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(50, 160, 220, 255))
            };

            totalSeries = new LineSeries
            {
                Values = new ChartValues<DateModel>(),
                Title = "Total",
                Stroke = System.Windows.Media.Brushes.ForestGreen,
                Fill = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(50, 34, 139, 34))
            };

            balanceSeries = new LineSeries
            {
                Values = new ChartValues<DateModel>(),
                Title = "Balance",
                Stroke = System.Windows.Media.Brushes.ForestGreen,
                Fill = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(50, 34, 139, 34))
            };

            xIncomeAxis = new Axis
            {
                LabelFormatter = value => new DateTime((long)(value * TimeSpan.FromDays(1).Ticks)).ToString("dd MMM yyyy"),
                MaxRange = DateTime.MaxValue.Subtract(TimeSpan.FromDays(146400)).Year,
                MinValue = DateTime.Now.Subtract(TimeSpan.FromDays(5)).Ticks / TimeSpan.TicksPerDay,
                MaxValue = DateTime.Now.AddDays(3).Ticks / TimeSpan.TicksPerDay
            };

            yIncomeAxis = new Axis
            {
                MinValue = 0,
                Foreground = netSeries.Fill,
                LabelFormatter = value => value + " ETB"
            };

            xExpenseAxis = new Axis
            {
                LabelFormatter = value => new DateTime((long)(value * TimeSpan.FromDays(1).Ticks)).ToString("dd MMM yyyy"),
                MaxRange = DateTime.MaxValue.Subtract(TimeSpan.FromDays(146400)).Year,
                MinValue = DateTime.Now.Subtract(TimeSpan.FromDays(5)).Ticks / TimeSpan.TicksPerDay,
                MaxValue = DateTime.Now.AddDays(3).Ticks / TimeSpan.TicksPerDay
            };

            yExpenseAxis = new Axis
            {
                MinValue = 0,
                Foreground = netSeries.Fill,
                LabelFormatter = value => value + " ETB"
            };

            xBankAxis = new Axis
            {
                LabelFormatter = value => new DateTime((long)(value * TimeSpan.FromDays(1).Ticks)).ToString("dd MMM yyyy"),
                MaxRange = DateTime.MaxValue.Subtract(TimeSpan.FromDays(146400)).Year,
                MinValue = DateTime.Now.Subtract(TimeSpan.FromDays(5)).Ticks / TimeSpan.TicksPerDay,
                MaxValue = DateTime.Now.AddDays(3).Ticks / TimeSpan.TicksPerDay
            };

            yBankAxis = new Axis
            {
                MinValue = 0,
                Foreground = netSeries.Fill,
                LabelFormatter = value => value + " ETB"
            };

            incomeChart.Series = new SeriesCollection(dayConfig);
            expenseChart.Series = new SeriesCollection(dayConfig);
            bankChart.Series = new SeriesCollection(dayConfig);
            incomeChart.Pan = PanningOptions.X;
            expenseChart.Pan = PanningOptions.X;

            incomeChart.AxisX.Add(xIncomeAxis);
            incomeChart.AxisY.Add(yIncomeAxis);
            expenseChart.AxisX.Add(xExpenseAxis);
            expenseChart.AxisY.Add(yExpenseAxis);
            bankChart.AxisX.Add(xBankAxis);
            bankChart.AxisY.Add(yBankAxis);

            pettyVaultChart.InnerRadius = 15;
            pettyVaultChart.DisableAnimations = false;
            pettyVaultChart.AnimationsSpeed = TimeSpan.FromSeconds(0.4);

            //Assigning each date selector the current datetime
            incomeDateSelection.Value = DateTime.Now;
            expenseDateSelection.Value = DateTime.Now;
            incomeChartDateTimePicker.Value = DateTime.Now;
            expenseChartDateTimePicker.Value = DateTime.Now;
            fromIncomeDateTimePicker.Value = DateTime.Now.Subtract(TimeSpan.FromDays(5));
            toIncomeDateTimePicker.Value = DateTime.Now.AddDays(5);
            fromExpenseDateTimePicker.Value = DateTime.Now.Subtract(TimeSpan.FromDays(5));
            toExpenseDateTimePicker.Value = DateTime.Now.AddDays(5);

            //Loading Petty Vault Data
            if (Linkup_Finance.Properties.Settings.Default.PettyVaultDictionary == null)
                Linkup_Finance.Properties.Settings.Default.PettyVaultDictionary = new System.Collections.Specialized.StringCollection();
            else
            {
                if(Linkup_Finance.Properties.Settings.Default.PettyVaultDictionary.Count > 0)
                {
                    for (int i = 0; i < Linkup_Finance.Properties.Settings.Default.PettyVaultDictionary.Count; i += 3)
                    {
                        string name = Linkup_Finance.Properties.Settings.Default.PettyVaultDictionary[i];
                        decimal value = decimal.Parse(Linkup_Finance.Properties.Settings.Default.PettyVaultDictionary[i + 1]);
                        decimal amount = decimal.Parse(Linkup_Finance.Properties.Settings.Default.PettyVaultDictionary[i + 2]);

                        pettyVaultComboBox.Items.Add(name);
                        bankManager.AddPettyVault(name, value, amount);

                        pettyVaultChart.Series.Add(new PieSeries
                        {
                            Values = new ChartValues<decimal> { amount },
                            Title = name
                        });
                    }

                    foreach (PieSeries series in pettyVaultChart.Series)
                    {
                        series.PushOut = 0;
                        if (series.Title == bankManager.GetFirstIndex().GetName())
                            series.PushOut = 10;
                    }
                    pettyVaultTextBox.Tag = bankManager.GetFirstIndex();
                    pettyVaultTextBox.Text = bankManager.GetFirstIndex().GetName();
                    pettyVaultComboBox.Text = bankManager.GetFirstIndex().GetName();
                }
                else
                {
                    Linkup_Finance.Properties.Settings.Default.PettyVaultDictionary.Add("Petty Vault");
                    Linkup_Finance.Properties.Settings.Default.PettyVaultDictionary.Add("0");
                    Linkup_Finance.Properties.Settings.Default.PettyVaultDictionary.Add("0");
                    Linkup_Finance.Properties.Settings.Default.Save();

                    bankManager.AddPettyVault("Petty Vault", 0m);

                    pettyVaultChart.Series.Add(new PieSeries
                    {
                        Values = new ChartValues<decimal> { 0m },
                        Title = "Petty Vault"
                    });

                    pettyVaultComboBox.Items.Add("Petty Vault");
                    pettyVaultComboBox.Text = "Petty Vault";
                    vaultAmountLabel.Text = "Amount(ETB): 0.00";
                    pettyVaultTextBox.Enabled = false;

                    dashboardForm.RefreshDashboard();
                }
            }
        }

        private void ProjectForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'linkupDatabaseDataSet.EmployeeLogs' table. You can move, or remove it, as needed.
            this.employeeLogsTableAdapter.Fill(this.linkupDatabaseDataSet.EmployeeLogs);
            this.expenseTableAdapter.Fill(this.linkupDatabaseDataSet.Expense);
            this.incomeTableAdapter.Fill(this.linkupDatabaseDataSet.Income);
            this.bankLogsTableAdapter.Fill(this.linkupDatabaseDataSet.BankLogs);
            this.banksTableAdapter.Fill(this.linkupDatabaseDataSet.Banks);
            this.projectsTableAdapter.Fill(this.linkupDatabaseDataSet.Projects);

            foreach (Project project in projectManager.RetrieveProjects(projectsTableAdapter))
                projectOption.Items.Add(project.GetProjectName());

            foreach (Bank bank in bankManager.RetrieveBanks(banksTableAdapter))
                bankOptionBox.Items.Add(bank.GetBankName());

            if (projectOption.Items.Count > 0)
            {
                projectOption.Text = projectOption.Items[0].ToString();

                Project project = projectManager.Exists(projectOption.Text, true);
                projectOption.Tag = project;

                LoadChart(projectOption.Text, incomeTableAdapter.GetData());
                LoadChart(projectOption.Text, expenseTableAdapter.GetData());
                RemoveItems(incomeDataGridView, projectOption.Text);
                RemoveItems(expenseDataGridView, projectOption.Text);
            }

            if (bankOptionBox.Items.Count > 0)
            {
                bankOptionBox.Text = bankOptionBox.Items[0].ToString();

                Bank bank = bankManager.GetBank(bankOptionBox.Text);
                bankOptionBox.Tag = bank;
                balanceAmountLabel.Text = $"Balance(ETB):{bank.GetBalance()}";
                LoadChart(bankOptionBox.Text, bankLogsTableAdapter.GetData());
                foreach (PieSeries series in bankPieChart.Series)
                {
                    series.PushOut = 0;
                    if (series.Title == bank.GetBankName())
                        series.PushOut = 10;

                    pettyVaultChart.Refresh();
                }
            }

            incomeVatLabel.Text = $"Total Vat: {GetTotalVat(incomeTableAdapter.GetData())}";
            expenseVatLabel.Text = $"Total Vat: {GetTotalVat(expenseTableAdapter.GetData())}";

            //TODO: Add data series with the rest of the charts i.e expense, bank 
            incomeChart.Series.Add(grossSeries);
            incomeChart.Series.Add(netSeries);
            expenseChart.Series.Add(amountSeries);
            expenseChart.Series.Add(totalSeries);
            bankChart.Series.Add(balanceSeries);

            filterIncomeComboBox.Text = "All";
            filterExpenseComboBox.Text = "All";
        }

        #region Project

        private void newProjectButton_Click(object sender, EventArgs e)
        {
            newProjectLabel.Visible = true;
            submitButton.Visible = true;
            projectNameTextBox.Visible = true;
            exitSubmissionButton.Visible = true;
            projectNameTextBox.Text = "";
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            string projectName = projectNameTextBox.Text;
            if (!projectManager.Exists(projectName))
            {
                projectOption.Items.Add(projectName);
                projectOption.Text = projectName;
                projectOption.Tag = projectManager.AddProject(projectName);
                
                //Hide the new project submission interface after entry
                newProjectLabel.Visible = false;
                submitButton.Visible = false;
                projectNameTextBox.Visible = false;
                exitSubmissionButton.Visible = false;

                projectOption.Refresh();
            }
            else
            {
                projectNameTextBox.Text = "This name already exists";
                projectNameTextBox.FillColor = Color.FromArgb(240, 160, 140);
            }
        }

        private void projectNameTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            projectNameTextBox.Text = "";
        }

        private void exitSubmissionButton_Click(object sender, EventArgs e)
        {
            newProjectLabel.Visible = false;
            submitButton.Visible = false;
            projectNameTextBox.Visible = false;
            exitSubmissionButton.Visible = false;
        }

        private void projectNameTextBox_Enter(object sender, EventArgs e)
        {
            projectNameTextBox.FillColor = Color.White;
        }

        private void projectNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                submitButton.PerformClick();
        }

        private void removeProjectButton_Click(object sender, EventArgs e)
        {
            string projectName = projectOption.Text;
            
            if (projectName != "")
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this entry?", "Entry Removal", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if(result == DialogResult.Yes)
                {
                    projectManager.RemoveProject(projectName);
                    projectOption.Items.Remove(projectOption.Text);
                    if (projectOption.Items.Count > 0)
                        projectOption.Text = projectOption.Items[0].ToString();
                    else
                        removeProjectButton.Visible = false;
                }
            }
        }

        private void projectOption_SelectedValueChanged(object sender, EventArgs e)
        {
            if(loggedInAccountType == AccountType.Admin) 
                if (projectOption.Text != "")
                    removeProjectButton.Visible = true;

            Thread.Sleep(500);
            Project project = projectManager.Exists(projectOption.Text, true);
            projectOption.Tag = project;

            incomeTableAdapter.Fill(this.linkupDatabaseDataSet.Income);
            expenseTableAdapter.Fill(this.linkupDatabaseDataSet.Expense);
            LoadChart(projectOption.Text, incomeTableAdapter.GetData());
            LoadChart(projectOption.Text, expenseTableAdapter.GetData());
            RemoveItems(incomeDataGridView, projectOption.Text);
            RemoveItems(expenseDataGridView, projectOption.Text);
        }

        #endregion

        #region BankTab

        private void pettyVaultComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            //TODO: Enlargen respective pie chart
            string vaultName = pettyVaultComboBox.Text;
            PettyVault vault = bankManager.GetPettyVault(vaultName);

            pettyVaultTextBox.Tag = vault;
            pettyVaultTextBox.Text = vaultName;
            pettyVaultTextBox.Enabled = false;
            vaultAmountLabel.Text = $"Amount(ETB): {vault.GetAmount()}";

            foreach (PieSeries series in pettyVaultChart.Series)
            {
                series.PushOut = 0;
                if (series.Title == vault.GetName())
                    series.PushOut = 10;

                pettyVaultChart.Refresh();
            }
        }

        private void newPettyVaultButton_Click(object sender, EventArgs e)
        {
            if(pettyVaultTextBox.Enabled)
            {
                if(pettyVaultTextBox.Text != "Invalid Entry. Try Again")
                {
                    string pettyVaultName = pettyVaultTextBox.Text;
                    decimal pettyVaultValue = 0m;
                    bool isValid = (pettyVaultName != "") ? decimal.TryParse(pettyValueTextBox.Text, out pettyVaultValue) : false;
                    StringCollection vaultDictionary = Linkup_Finance.Properties.Settings.Default.PettyVaultDictionary;

                    for (int i = 0; i < vaultDictionary.Count; i += 2)
                    {
                        if (pettyVaultName.ToLower() == vaultDictionary[i].ToLower())
                        {
                            isValid = false;
                            break;
                        }
                    }

                    if (isValid)
                    {
                        Linkup_Finance.Properties.Settings.Default.PettyVaultDictionary.Add(pettyVaultName);
                        Linkup_Finance.Properties.Settings.Default.PettyVaultDictionary.Add(pettyValueTextBox.Text);
                        Linkup_Finance.Properties.Settings.Default.PettyVaultDictionary.Add(pettyValueTextBox.Text);
                        Linkup_Finance.Properties.Settings.Default.Save();

                        bankManager.AddPettyVault(pettyVaultName, pettyVaultValue);

                        pettyVaultChart.Series.Add(new PieSeries
                        {
                            Values = new ChartValues<decimal> { pettyVaultValue },
                            Title = pettyVaultName
                        });

                        pettyVaultComboBox.Items.Add(pettyVaultName);
                        pettyVaultComboBox.Text = pettyVaultName;
                        vaultAmountLabel.Text = $"Amount(ETB): {pettyVaultValue}";
                        pettyVaultTextBox.Enabled = false;

                        dashboardForm.RefreshDashboard();
                    }
                    else
                        pettyVaultTextBox.Text = "Invalid Entry. Try Again";
                }
                else
                    pettyVaultTextBox.Text = "";
            }
            else
            {
                pettyVaultTextBox.Enabled = true;
                pettyVaultTextBox.PlaceholderText = "New Petty Vault Name";
                pettyVaultTextBox.Text = "";
                pettyValueTextBox.Text = "";
                pettyValueTextBox.PlaceholderText = "Insert Value";
                vaultAmountLabel.Text = $"Amount(ETB):";
            }
        }

        private void editValueButton_Click(object sender, EventArgs e)
        {
            decimal value;
            bool isValid = decimal.TryParse(pettyValueTextBox.Text, out value);
            PettyVault vault = (PettyVault)pettyVaultTextBox.Tag;

            if (isValid)
                vault.SetValue(value);
        }

        private void replenishButton_Click(object sender, EventArgs e)
        {
            PettyVault vault = (PettyVault)pettyVaultTextBox.Tag;
            Project project = (Project)projectOption.Tag;
            Bank bank = (Bank)bankOptionBox.Tag;
            decimal amount;
            bool isValid = decimal.TryParse(pettyValueTextBox.Text, out amount);

            if (isValid)
            {
                vault.Replenish(amount, bank);
                vaultAmountLabel.Text = $"Amount(ETB): {vault.GetAmount()}";
                foreach (PieSeries series in pettyVaultChart.Series)
                {
                    if (series.Title == vault.GetName())
                    {
                        series.Values = new ChartValues<decimal> { vault.GetAmount() };
                        break;
                    }
                }
                pettyValueTextBox.Text = "";
                bankLogsTableAdapter.Fill(linkupDatabaseDataSet.BankLogs);
                banksTableAdapter.Fill(linkupDatabaseDataSet.Banks);
                expenseTableAdapter.Fill(linkupDatabaseDataSet.Expense);
                LoadChart(bank.GetBankName(), bankLogsTableAdapter.GetData());
                RemoveItems(bankLogDataGridView, bank.GetBankName());
                RemoveItems(expenseDataGridView, project.GetProjectName());
                balanceAmountLabel.Text = $"Balance:{bank.GetBalance()}";
                dashboardForm.LoadChart(banksTableAdapter.GetData());
                dashboardForm.RefreshDashboard();
            }
            else
            {
                pettyValueTextBox.Text = "Incorrect Format";
                pettyValueTextBox.FillColor = Color.FromArgb(240, 160, 140);
            }   
        }

        private void removeVaultButton_Click(object sender, EventArgs e)
        {
            PettyVault vault = (PettyVault)pettyVaultTextBox.Tag;
            PieSeries removeSeries = null;

            if(vault != null)
            {
                bankManager.RemovePettyVault(vault);
                pettyVaultComboBox.Items.Remove(vault.GetName());

                foreach (PieSeries series in pettyVaultChart.Series)
                {
                    if (series.Title == vault.GetName())
                    {
                        removeSeries = series;
                        break;
                    }
                }

                if (removeSeries != null)
                    pettyVaultChart.Series.Remove(removeSeries);

                if (pettyVaultComboBox.Items.Count > 0)
                    pettyVaultComboBox.Text = pettyVaultComboBox.Items[0].ToString();
                else
                {
                    pettyVaultTextBox.PlaceholderText = "Create Petty Vault";
                    pettyVaultTextBox.Text = "";
                    pettyValueTextBox.Text = "Insert Value";
                    pettyVaultTextBox.Tag = null;
                    vaultAmountLabel.Text = "Amount(ETB):";
                }

                dashboardForm.RefreshDashboard();
            }
        }

        private void pettyValueTextBox_TextChanged(object sender, EventArgs e)
        {
            pettyValueTextBox.FillColor = Color.White;
        }

        private void newBankButton_Click(object sender, EventArgs e)
        {
            newBankPanel.Visible = true;
        }

        private void closeBankPanel_Click(object sender, EventArgs e)
        {
            newBankPanel.Visible = false;
        }

        private void submitBankButton_Click(object sender, EventArgs e)
        { 
            string name = bankNameTextBox.Text;
            string accountID =accountIDTextBox.Text;
            decimal balance;
            bool isValid = decimal.TryParse(bankBalanceTextBox.Text, out balance);
            
            newBankPanel.Controls.Remove(bankErrorChip);
            bankErrorChip = new Guna.UI2.WinForms.Guna2Chip
            {
                Size = new Size(379, 45),
                Location = new Point(377, 9),
                Text = "",
                Visible = false,
                FillColor = Color.FromArgb(210, 65, 60)
            };
            newBankPanel.Controls.Add(bankErrorChip);
            bankErrorChip.BringToFront();

            if (isValid)
            {
                if (name != "" && accountID != "" && balance != 0.00m)
                {
                    if (!bankManager.BankExists(name))
                    {
                        if (bankManager.AddBank(name, accountID, balance))
                        {
                            Bank bank = bankManager.GetBank(name);
                            bankNameTextBox.ResetText();
                            accountIDTextBox.ResetText();
                            bankBalanceTextBox.ResetText();
                            newBankPanel.Visible = false;
                            bankErrorChip.Visible = false;
                            bankOptionBox.Tag = bank;
                            bankOptionBox.Items.Add(name);
                            bankOptionBox.Text = name;
                            balanceAmountLabel.Text = $"Balance(ETB):{bank.GetBalance()}";

                            //TODO: Add new Bank in chart

                            //TODO: Load data to chart
                            this.bankLogsTableAdapter.Fill(this.linkupDatabaseDataSet.BankLogs);
                            LoadChart(name, bankLogsTableAdapter.GetData());
                            dashboardForm.LoadChart(banksTableAdapter.GetData());
                            dashboardForm.RefreshDashboard();
                            foreach (PieSeries series in bankPieChart.Series)
                            {
                                series.PushOut = 0;
                                if (series.Title == name)
                                    series.PushOut = 10;

                                pettyVaultChart.Refresh();
                            }
                        }
                        else
                        {
                            bankErrorChip.Visible = true;
                            bankErrorChip.Text = "An error as occured when inserting data to the database. Make sure all the required data is correct.";
                        }
                    }
                    else
                    {
                        bankErrorChip.Visible = true;
                        bankErrorChip.Text = "A bank with the same name already exists. Try a different alternative.";
                    }
                }
                else
                {
                    bankErrorChip.Visible = true;
                    bankErrorChip.Text = "There are missing values that are required to continue. Fill them and try again";
                }
            }
            else
            {
                bankErrorChip.Visible = true;
                bankErrorChip.Text = "The balance value is in an incorrect format. Try again.";
            }
        }

        private void depositButton_Click(object sender, EventArgs e)
        {
            Bank bank = (Bank)bankOptionBox.Tag;
            decimal value;
            bool isValid = decimal.TryParse(depositTextBox.Text, out value);

            if (isValid)
            {
                bank.Deposit(value);
                bankLogsTableAdapter.Fill(this.linkupDatabaseDataSet.BankLogs);
                LoadChart(bank.GetBankName(), bankLogsTableAdapter.GetData());
                RemoveItems(bankLogDataGridView, bank.GetBankName());
                balanceAmountLabel.Text = $"Balance:{bank.GetBalance()}";
                dashboardForm.LoadChart(banksTableAdapter.GetData());
                dashboardForm.RefreshDashboard();
            }    
            else
                depositTextBox.Text = "Invalid Value";
        }

        private void bankOptionBox_SelectedValueChanged(object sender, EventArgs e)
        {
            Bank bank = bankManager.GetBank(bankOptionBox.Text);
            bankOptionBox.Tag = bank;
            balanceAmountLabel.Text = $"Balance(ETB):{bank.GetBalance()}";
            bankLogsTableAdapter.Fill(this.linkupDatabaseDataSet.BankLogs);
            LoadChart(bankOptionBox.Text, bankLogsTableAdapter.GetData());
            RemoveItems(bankLogDataGridView, bank.GetBankName());
            deleteBankButton.Visible = true;
            foreach (PieSeries series in bankPieChart.Series)
            {
                series.PushOut = 0;
                if (series.Title == bank.GetBankName())
                    series.PushOut = 10;

                bankPieChart.Refresh();
            }
        }

        private void deleteBankButton_Click(object sender, EventArgs e)
        {
            Bank bank = (Bank)bankOptionBox.Tag;

            bankManager.RemoveBank(bank);
            bankOptionBox.Items.Remove(bank.GetBankName());
            dashboardForm.LoadChart(banksTableAdapter.GetData());
            dashboardForm.RefreshDashboard();

            if (bankOptionBox.Items.Count > 0)
                bankOptionBox.Text = bankOptionBox.Items[0].ToString();
            else
            {
                deleteBankButton.Visible = false;
                balanceAmountLabel.Text = $"Balance(ETB): ";
                bankOptionBox.Tag = null;
                bankPieChart.Series.Clear();
                bankChart.Series.Clear();
                RemoveItems(bankLogDataGridView, " ");
            }
        }

        #endregion

        #region ExpenseTab
        private void newExpenseButton_Click(object sender, EventArgs e)
        {
            newExpensePanel.Visible = true;

            expenseTypeComboBox.Text = "None";

            foreach(string bank in bankOptionBox.Items)
                expenseBankComboBox.Items.Add(bank);

            if(expenseBankComboBox.Items.Count > 0)
                expenseBankComboBox.Text = expenseBankComboBox.Items[0].ToString();
        }

        private void closeExpensePanelButton_Click(object sender, EventArgs e)
        {
            newExpensePanel.Visible = false;

            nameExpenseTextBox.ResetText();
            expenseBankComboBox.ResetText();
            reasonExpenseTextBox.ResetText();
            amountExpenseTextBox.ResetText();
            expenseTinTextBox.ResetText();
        }

        private void submitExpenseButton_Click(object sender, EventArgs e)
        {
            Project project = (Project)projectOption.Tag;
           
            string name = nameExpenseTextBox.Text;
            string reason = reasonExpenseTextBox.Text;
            string bank = expenseBankComboBox.Text;
            string product = productExpenseTextBox.Text;
            int tin = -1;
            bool hasReceipt = receiptExpenseRadioButton.Checked;
            decimal amount;
            DateTime date = expenseDateSelection.Value;
            bool isValid = decimal.TryParse(amountExpenseTextBox.Text, out amount);
            bool isTinValid = (expenseTinTextBox.Text != "") ? int.TryParse(expenseTinTextBox.Text, out tin) : true;
            string[] attachements = (string[])submitExpenseButton.Tag;
            Random rand = new Random();
            string folderName = DateTime.Now.ToString("MMMMddyyyy") + rand.Next(999999999) + name;
            string attachmentDirectory = (attachements != null) ? Combine(GetFolderPath(SpecialFolder.MyDocuments), "Linkup Finance Attachements", "Expense", folderName) : null;
            string type = expenseTypeComboBox.Text;

            if (type == "Petty")
                bank = type;

            if (expenseTinTextBox.Text == "")
                tin = 0;

            newExpensePanel.Controls.Remove(expenseErrorChip);
            expenseErrorChip = new Guna.UI2.WinForms.Guna2Chip
            {
                Size = new Size(379, 45),
                Location = new Point(377, 9),
                Text = "",
                Visible = false,
                FillColor = Color.FromArgb(210, 65, 60)
            };
            newExpensePanel.Controls.Add(expenseErrorChip);
            expenseErrorChip.BringToFront();

            if (attachements != null)
            {
                while (Exists(attachmentDirectory))
                {
                    folderName = DateTime.Now.ToString("MMMddyyyy") + rand.Next(999999999) + name;
                    attachmentDirectory = Combine(GetFolderPath(SpecialFolder.MyDocuments), "Linkup Finance Attachements", "Expense", folderName);
                }
            }

            if (isValid && isTinValid)
            {
                if (project != null)
                {
                    if (name != "" && reason != "" && bank != "" && tin != -1 && amount != 0.00m)
                    {
                        if (attachements != null)
                        {
                            if (project.AddExpense(name, reason, product, bank, hasReceipt, amount, project.GetProjectName(), date, tin, type, attachmentDirectory))
                            {
                                //Associate attachements with entry and store in local machine
                                if (attachements != null)
                                {
                                    CreateDirectory(attachmentDirectory);

                                    foreach (string fileName in (string[])submitExpenseButton.Tag)
                                        File.Copy(fileName, Combine(attachmentDirectory, GetFileName(fileName)));
                                }

                                if (type != "Petty")
                                {
                                    Bank bankLog = bankManager.GetBank(bank);
                                    decimal net;

                                    if (type == "Goods")
                                    {
                                        if(amount >= 10000.00m)
                                            net = amount + (amount * 0.15m) - (amount * 0.02m);
                                        else
                                            net = amount + (amount * 0.15m);
                                    }
                                    else if(type == "Service")
                                    {
                                        if(amount >= 3000.00m)
                                            net = amount + (amount * 0.15m) - (amount * 0.02m);
                                        else
                                            net = amount + (amount * 0.15m);
                                    }
                                    else
                                        net = amount + (amount * 0.15m);
                                    
                                    bankLog.SubmitLog(net, "Expense", reason, date, name, false, project.GetProjectName());
                                    this.bankLogsTableAdapter.Fill(this.linkupDatabaseDataSet.BankLogs);
                                    if (bankOptionBox.Text == bank)
                                    {
                                        balanceAmountLabel.Text = $"Balance(ETB):{bankLog.GetBalance()}";

                                        RemoveItems(bankLogDataGridView, bank);
                                    }

                                    LoadChart(bank, bankLogsTableAdapter.GetData());
                                    foreach (PieSeries series in bankPieChart.Series)
                                    {
                                        series.PushOut = 0;
                                        if (series.Title == bankOptionBox.Text)
                                            series.PushOut = 10;

                                        pettyVaultChart.Refresh();
                                    }
                                }
                                else
                                {
                                    Bank.SubmitLog(amount, reason, date, name, project.GetProjectName());
                                    this.bankLogsTableAdapter.Fill(this.linkupDatabaseDataSet.BankLogs);

                                    PettyVault vault = bankManager.GetFirstIndex();
                                    vault.DecreaseValue(amount);

                                    LoadChart("Petty", bankLogsTableAdapter.GetData());
                                }
                                    

                                nameExpenseTextBox.ResetText();
                                expenseBankComboBox.ResetText();
                                reasonExpenseTextBox.ResetText();
                                amountExpenseTextBox.ResetText();
                                expenseTinTextBox.ResetText();
                                submitExpenseButton.Tag = null;
                                productExpenseTextBox.ResetText();
                                expenseDateSelection.Value = DateTime.Now;
                                newExpensePanel.Visible = false;
                                expenseErrorChip.Visible = false;
                                expenseTableAdapter.Fill(this.linkupDatabaseDataSet.Expense);
                                expenseVatLabel.Text = $"Total Vat: {GetTotalVat(expenseTableAdapter.GetData())}";
                                LoadChart(project.GetProjectName(), expenseTableAdapter.GetData());
                                dashboardForm.LoadChart(expenseTableAdapter.GetData());
                                RemoveItems(expenseDataGridView, projectOption.Text);
                            }
                            else
                            {
                                expenseErrorChip.Visible = true;
                                expenseErrorChip.Text = "An error as occured when inserting data to the database. Make sure all the required data is correct.";
                            }

                        }
                        else
                        {
                            expenseErrorChip.Visible = true;
                            expenseErrorChip.Text = "Attachements are missing. Locate the files to associate with this entry and try again";
                        }
                    }
                    else
                    {
                        expenseErrorChip.Visible = true;
                        expenseErrorChip.Text = "There are missing values that are required to continue. Fill them and try again";
                    }
                }
                else
                {
                    expenseErrorChip.Visible = true;
                    expenseErrorChip.Text = "There is no selected project. Select a project and try again.";
                }
            }
            else
            {
                expenseErrorChip.Visible = true;
                expenseErrorChip.Text = "The amount value or the tin number is in an incorrect format. Try again.";
            }
        }

        private void expenseChartDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            DateTime dateSelection = expenseChartDateTimePicker.Value;
            xExpenseAxis.MinValue = dateSelection.Subtract(TimeSpan.FromDays(5)).Ticks / TimeSpan.TicksPerDay;
            xExpenseAxis.MaxValue = dateSelection.AddDays(5).Ticks / TimeSpan.TicksPerDay;
            zoomExpenseValue = 99;
            zoomExpenseTrackBar.Value = zoomExpenseValue;
        }

        private void zoomExpenseTrackBar_ValueChanged(object sender, EventArgs e)
        {
            int value = zoomExpenseTrackBar.Value;
            zoomExpenseNumericUpDown.Value = value;

            if (value > zoomExpenseValue)
            {
                xExpenseAxis.MinValue += (value - zoomExpenseValue) * 2.5;
                xExpenseAxis.MaxValue -= (value - zoomExpenseValue) * 2.5;
                zoomExpenseValue = value;
            }
            else
            {
                xExpenseAxis.MinValue -= (zoomExpenseValue - value) * 2.5;
                xExpenseAxis.MaxValue += (zoomExpenseValue - value) * 2.5;
                zoomExpenseValue = value;
            }
        }

        private void zoomExpenseNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            int value;
            int.TryParse(zoomExpenseNumericUpDown.Value.ToString(), out value);
            zoomExpenseTrackBar.Value = value;
        }

        private void attachementsExpenseButton(object sender, EventArgs e)
        {
            OpenFileDialog attachementDialog = new OpenFileDialog();
            attachementDialog.Filter = "All Files (*.*)|*.*";
            attachementDialog.Multiselect = true;

            DialogResult result = attachementDialog.ShowDialog();

            if (result == DialogResult.OK)
                submitExpenseButton.Tag = attachementDialog.FileNames;
        }

        private void filterExpenseComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            //Change the placeholder text of the search text box whenever a filter has been applied to the data set
            expenseSearchTextBox.Visible = true;
            fromExpenseDateLabel.Visible = false;
            fromExpenseDateTimePicker.Visible = false;
            toExpenseDateLabel.Visible = false;
            toExpenseDateTimePicker.Visible = false;
            searchExpenseButton.Location = new Point(573, 6);
            expenseTableAdapter.Fill(linkupDatabaseDataSet.Expense);
            RemoveItems(expenseDataGridView, projectOption.Text);

            switch (filterExpenseComboBox.Text)
            {
                case "All":
                case "Receipt":
                case "Non-Receipt":
                    expenseSearchTextBox.PlaceholderText = "Expense Name";
                    break;
                case "Amount":
                    expenseSearchTextBox.PlaceholderText = "Amount Value";
                    break;
                case "Reason":
                    expenseSearchTextBox.PlaceholderText = "Reason";
                    break;
                case "Bank":
                    expenseSearchTextBox.PlaceholderText = "Bank's Name";
                    break;
                case "Total":
                    expenseSearchTextBox.PlaceholderText = "Total Value";
                    break;
                case "Type":
                    expenseSearchTextBox.PlaceholderText = "Expense Type";
                    break;
                case "Product":
                    expenseSearchTextBox.PlaceholderText = "Product Name";
                    break;
                case "Date":
                    fromExpenseDateLabel.Visible = true;
                    fromExpenseDateTimePicker.Visible = true;
                    toExpenseDateLabel.Visible = true;
                    toExpenseDateTimePicker.Visible = true;
                    expenseSearchTextBox.Visible = false;
                    searchExpenseButton.Location = new Point(797, 6);

                    break;
            }
        }

        private void searchExpenseButton_Click(object sender, EventArgs e)
        {
            string filter = filterExpenseComboBox.Text;
            string entry = expenseSearchTextBox.Text;

            switch (filter)
            {
                case "All":
                    SearchDataGridView(expenseDataGridView, entry, 0);
                    break;
                case "Amount":
                    SearchDataGridView(expenseDataGridView, entry, 4);
                    break;
                case "Receipt":
                    SearchDataGridView(expenseDataGridView, entry, 8, true);
                    break;
                case "Non-Receipt":
                    SearchDataGridView(expenseDataGridView, entry, 8, false);
                    break;
                case "Reason":
                    SearchDataGridView(expenseDataGridView, entry, 9);
                    break;
                case "Bank":
                    SearchDataGridView(expenseDataGridView, entry, 3);
                    break;
                case "Date":
                    DateTime from = fromExpenseDateTimePicker.Value;
                    DateTime to = toExpenseDateTimePicker.Value;
                    SearchDataGridView(expenseDataGridView, from, to);
                    break;
                case "Product":
                    SearchDataGridView(expenseDataGridView, entry, 1);
                    break;
                case "Type":
                    SearchDataGridView(expenseDataGridView, entry, 2);
                    break;
                case "Total":
                    SearchDataGridView(expenseDataGridView, entry, 7);
                    break;
            }
        }

        private void expenseSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            expenseTableAdapter.Fill(linkupDatabaseDataSet.Expense);
            RemoveItems(expenseDataGridView, projectOption.Text);
        }

        private void expenseDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 11)
            {
                try
                {
                    string url = expenseDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                    if (Exists(url))
                        Process.Start(url);
                    else
                        MessageBox.Show("The folder does not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error has occured: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void expenseTypeComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (expenseTypeComboBox.Text == "Petty")
                expenseBankComboBox.Enabled = false;
            else
                expenseBankComboBox.Enabled = true;
        }

        private void expenseTabPage_Click(object sender, EventArgs e)
        {
            newExpenseButton.Focus();
        }

        private void expenseDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            deleteExpenseEntryButton.Enabled = true;
            deleteExpenseEntryButton.Tag = int.Parse(expenseDataGridView.Rows[e.RowIndex].Cells[14].Value.ToString());
        }

        private void expenseDataGridView_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (!deleteExpenseEntryButton.Focused)
            {
                deleteExpenseEntryButton.Enabled = false;
                deleteExpenseEntryButton.Tag = null;
            }
        }

        private void receiptExpenseRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!receiptExpenseRadioButton.Checked)
            {
                expenseTinTextBox.Text = "";
                expenseTinTextBox.Enabled = false;
            }
            else
                expenseTinTextBox.Enabled = true;
        }

        private void expenseDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Project project = (Project)projectOption.Tag;
            string name = expenseDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
            string product = expenseDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
            string bank = expenseDataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
            decimal amount = (decimal)expenseDataGridView.Rows[e.RowIndex].Cells[4].Value;
            bool hasReceipt = (int.Parse(expenseDataGridView.Rows[e.RowIndex].Cells[8].Value.ToString()) == 1) ? true : false;
            string reason = expenseDataGridView.Rows[e.RowIndex].Cells[9].Value.ToString();
            DateTime date = (DateTime)expenseDataGridView.Rows[e.RowIndex].Cells[10].Value;
            string attachement = expenseDataGridView.Rows[e.RowIndex].Cells[11].Value.ToString();
            int tin = int.Parse(expenseDataGridView.Rows[e.RowIndex].Cells[13].Value.ToString());
            string type = expenseDataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
            int id = int.Parse(expenseDataGridView.Rows[e.RowIndex].Cells[14].Value.ToString());

            if (e.ColumnIndex != 5 && e.ColumnIndex != 6 && e.ColumnIndex != 7)
            {
                project.EditExpense(id, name, product, bank, amount, hasReceipt, reason, date, attachement, tin, type);
                expenseTableAdapter.Fill(linkupDatabaseDataSet.Expense);
                RemoveItems(expenseDataGridView, project.GetProjectName());
                LoadChart(project.GetProjectName(), expenseTableAdapter.GetData());
                dashboardForm.LoadChart(expenseTableAdapter.GetData());
                GetTotalVat(expenseTableAdapter.GetData());
            }
        }

        private void deleteExpenseEntryButton_Click(object sender, EventArgs e)
        {
            Project project = (Project)projectOption.Tag;
            int id = (int)deleteExpenseEntryButton.Tag;

            project.RemoveExpense(id);
            expenseTableAdapter.Fill(linkupDatabaseDataSet.Expense);
            RemoveItems(expenseDataGridView, project.GetProjectName());
            LoadChart(project.GetProjectName(), expenseTableAdapter.GetData());
            dashboardForm.LoadChart(expenseTableAdapter.GetData());
            GetTotalVat(expenseTableAdapter.GetData());
        }

        #endregion

        #region IncomeTab

        private void newIncomeButton_Click(object sender, EventArgs e)
        {
            newIncomePanel.Visible = true;

            incomeTypeComboBox.Text = "None";

            foreach (string bank in bankOptionBox.Items)
                incomeBankComboBox.Items.Add(bank);

            if(incomeBankComboBox.Items.Count > 0)
                incomeBankComboBox.Text = incomeBankComboBox.Items[0].ToString();
        }

        private void closeIncomePanelButton_Click(object sender, EventArgs e)
        {
            nameIncomeTextBox.ResetText();
            incomeBankComboBox.ResetText();
            reasonIncomeTextBox.ResetText();
            grossIncomeTextBox.ResetText();
            submitIncomeButton.Tag = null;
            incomeDateSelection.Value = DateTime.Now;
            newIncomePanel.Visible = false;
            incomeErrorChip.Visible = false;
            newIncomePanel.Visible = false;
        }

        private void submitIncomeButton_Click(object sender, EventArgs e)
        {
            Project project = (Project)projectOption.Tag;
            string name = nameIncomeTextBox.Text;
            string reason = reasonIncomeTextBox.Text;
            string bank = incomeBankComboBox.Text;
            int tin = -1;
            bool hasReceipt = receiptIncomeRadioButton.Checked;
            decimal gross;
            DateTime date = incomeDateSelection.Value;
            bool isValid = decimal.TryParse(grossIncomeTextBox.Text, out gross);
            bool isTinValid = (incomeTinTextBox.Text != "") ? int.TryParse(incomeTinTextBox.Text, out tin) : true;
            string[] attachements = (string[])submitIncomeButton.Tag;
            Random rand = new Random();
            string folderName = DateTime.Now.ToString("MMMMddyyyy") + rand.Next(999999999) + name;
            string attachmentDirectory = (attachements != null) ? Combine(GetFolderPath(SpecialFolder.MyDocuments), "Linkup Finance Attachements", "Income",folderName) : null;
            string type = incomeTypeComboBox.Text;

            newIncomePanel.Controls.Remove(incomeErrorChip);
            incomeErrorChip = new Guna.UI2.WinForms.Guna2Chip
            {
                Size = new Size(379, 45),
                Location = new Point(377, 9),
                Text = "",
                Visible = false,
                FillColor = Color.FromArgb(210, 65, 60)
            };
            newIncomePanel.Controls.Add(incomeErrorChip);
            incomeErrorChip.BringToFront();

            if (incomeTinTextBox.Text == "")
                tin = 0;

            if(attachements != null)
            {
                while (Exists(attachmentDirectory))
                {
                    folderName = DateTime.Now.ToString("MMMddyyyy") + rand.Next(999999999) + name;
                    attachmentDirectory = Combine(GetFolderPath(SpecialFolder.MyDocuments), "Linkup Finance Attachements", folderName);
                }
            }

            if (isValid && isTinValid)
            {
                if (project != null)
                {
                    if (name != "" && reason != "" && bank != "" && tin != -1 && gross != 0.00m)
                    {
                        if(attachements != null)
                        {
                            if (project.AddIncome(name, reason, bank, hasReceipt, gross, project.GetProjectName(), date, tin, (type != "None") ? type : null, attachmentDirectory))
                            {
                                //Associate attachements with entry and store in local machine
                                if (attachements != null)
                                {
                                    CreateDirectory(attachmentDirectory);

                                    foreach (string fileName in (string[])submitIncomeButton.Tag)
                                        File.Copy(fileName, Combine(attachmentDirectory, GetFileName(fileName)));
                                }

                                Bank bankLog = bankManager.GetBank(bank);
                                decimal net = gross + (gross * 0.15m) - (gross * 0.02m);
                                bankLog.SubmitLog(net, "Income", reason, date, name, false, project.GetProjectName());
                                this.bankLogsTableAdapter.Fill(this.linkupDatabaseDataSet.BankLogs);
                                if (bankOptionBox.Text == bank)
                                {
                                    balanceAmountLabel.Text = $"Balance(ETB):{bankLog.GetBalance()}";
                                    List<int> tobeRemovedList = new List<int>();
                                    int removed = 0;

                                    for (int i = 0; i < bankLogDataGridView.Rows.Count; i++)
                                        if (bankLogDataGridView.Rows[i].Cells[2].Value != null)
                                            if (bankLogDataGridView.Rows[i].Cells[2].Value.ToString() != bank)
                                                tobeRemovedList.Add(i);

                                    foreach (int rowIndex in tobeRemovedList)
                                    {
                                        bankLogDataGridView.Rows.RemoveAt(rowIndex - removed);
                                        removed++;
                                    }
                                }
                                    
                                LoadChart(bank, bankLogsTableAdapter.GetData());
                                foreach (PieSeries series in bankPieChart.Series)
                                {
                                    series.PushOut = 0;
                                    if (series.Title == bankOptionBox.Text)
                                        series.PushOut = 10;

                                    pettyVaultChart.Refresh();
                                }

                                nameIncomeTextBox.ResetText();
                                incomeBankComboBox.ResetText();
                                reasonIncomeTextBox.ResetText();
                                grossIncomeTextBox.ResetText();
                                incomeTinTextBox.ResetText();
                                submitIncomeButton.Tag = null;
                                incomeDateSelection.Value = DateTime.Now;
                                newIncomePanel.Visible = false;
                                incomeErrorChip.Visible = false;
                                incomeTableAdapter.Fill(this.linkupDatabaseDataSet.Income);
                                incomeVatLabel.Text = $"Total Vat: {GetTotalVat(incomeTableAdapter.GetData())}";
                                RemoveItems(incomeDataGridView, projectOption.Text);
                                LoadChart(project.GetProjectName() ,incomeTableAdapter.GetData());
                                GetTotalVat(incomeTableAdapter.GetData());
                                dashboardForm.LoadChart(incomeTableAdapter.GetData());
                            }
                            else
                            {
                                incomeErrorChip.Visible = true;
                                incomeErrorChip.Text = "An error as occured when inserting data to the database. Make sure all the required data is correct.";
                            }
                        }
                        else
                        {
                            incomeErrorChip.Visible = true;
                            incomeErrorChip.Text = "Attachements are missing. Locate the files to associate with this entry and try again";
                        }
                    }
                    else
                    {
                        incomeErrorChip.Visible = true;
                        incomeErrorChip.Text = "There are missing values that are required to continue. Fill them and try again";
                    }
                }
                else
                {
                    incomeErrorChip.Visible = true;
                    incomeErrorChip.Text = "There is no selected project. Select a project and try again.";
                }
            }
            else
            {
                incomeErrorChip.Visible = true;
                incomeErrorChip.Text = "The gross value or the tin number is in an incorrect format. Try again.";
            }
        }

        private void zoomIncomeTrackBar_ValueChanged(object sender, EventArgs e)
        {
            int value = zoomIncomeTrackBar.Value;
            zoomIncomeNumericUpDown.Value = value;

            if (value > zoomIncomeValue)
            {
                xIncomeAxis.MinValue += (value - zoomIncomeValue) * 2.5;
                xIncomeAxis.MaxValue -= (value - zoomIncomeValue) * 2.5;
                zoomIncomeValue = value;
            }
            else
            {
                xIncomeAxis.MinValue -= (zoomIncomeValue - value) * 2.5;
                xIncomeAxis.MaxValue += (zoomIncomeValue - value) * 2.5;
                zoomIncomeValue = value;
            }
        }

        private void zoomIncomeNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            int value;
            int.TryParse(zoomIncomeNumericUpDown.Value.ToString(), out value);
            zoomIncomeTrackBar.Value = value;
        }

        private void incomeChartDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            DateTime dateSelection = incomeChartDateTimePicker.Value;
            xIncomeAxis.MinValue = dateSelection.Subtract(TimeSpan.FromDays(5)).Ticks / TimeSpan.TicksPerDay;
            xIncomeAxis.MaxValue = dateSelection.AddDays(5).Ticks / TimeSpan.TicksPerDay;
            zoomIncomeValue = 99;
            zoomIncomeTrackBar.Value = zoomIncomeValue;
        }

        private void searchIncomeButton_Click(object sender, EventArgs e)
        {
            string filter = filterIncomeComboBox.Text;
            string entry = incomeSearchTextBox.Text;

            switch (filter)
            {
                case "All":
                    SearchDataGridView(incomeDataGridView, entry, 0);
                    break;
                case "Gross":
                    SearchDataGridView(incomeDataGridView, entry, 2);
                    break;
                case "Receipt":
                    SearchDataGridView(incomeDataGridView, entry, 6, true);
                    break;
                case "Non-Receipt":
                    SearchDataGridView(incomeDataGridView, entry, 6, false);
                    break;
                case "Reason":
                    SearchDataGridView(incomeDataGridView, entry, 7);
                    break;
                case "Bank":
                    SearchDataGridView(incomeDataGridView, entry, 1);
                    break;
                case "Net":
                    SearchDataGridView(incomeDataGridView, entry, 5);
                    break;
                case "Date":
                    DateTime from = fromIncomeDateTimePicker.Value;
                    DateTime to = toIncomeDateTimePicker.Value;
                    SearchDataGridView(incomeDataGridView, from, to);
                    break;
            }
        }

        private void incomeSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            incomeTableAdapter.Fill(linkupDatabaseDataSet.Income);
            RemoveItems(incomeDataGridView, projectOption.Text);
        }

        private void attachementsIncomeButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog attachementDialog = new OpenFileDialog();
            attachementDialog.Filter = "All Files (*.*)|*.*";
            attachementDialog.Multiselect = true;
            
            DialogResult result = attachementDialog.ShowDialog();

            if(result == DialogResult.OK)
                submitIncomeButton.Tag = attachementDialog.FileNames;
        }

        private void filterIncomeComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            //Change the placeholder text of the search text box whenever a filter has been applied to the data set
            incomeSearchTextBox.Visible = true;
            fromIncomeDateLabel.Visible = false;
            fromIncomeDateTimePicker.Visible = false;
            toIncomeDateLabel.Visible = false;
            toIncomeDateTimePicker.Visible = false;
            searchIncomeButton.Location = new Point(568, 6);
            incomeTableAdapter.Fill(linkupDatabaseDataSet.Income);
            RemoveItems(incomeDataGridView, projectOption.Text);

            switch (filterIncomeComboBox.Text)
            {
                case "All":
                case "Receipt":
                case "Non-Receipt":
                    incomeSearchTextBox.PlaceholderText = "Payer's Name";
                    break;
                case "Gross":
                    incomeSearchTextBox.PlaceholderText = "Gross Value";
                    break;
                case "Reason":
                    incomeSearchTextBox.PlaceholderText = "Reason";
                    break;
                case "Bank":
                    incomeSearchTextBox.PlaceholderText = "Bank's Name";
                    break;
                case "Net":
                    incomeSearchTextBox.PlaceholderText = "Net Value";
                    break;
                case "Date":
                    fromIncomeDateLabel.Visible = true;
                    fromIncomeDateTimePicker.Visible = true;
                    toIncomeDateLabel.Visible = true;
                    toIncomeDateTimePicker.Visible = true;
                    incomeSearchTextBox.Visible = false;
                    searchIncomeButton.Location = new Point(792, 6);

                    break;
            }
        }

        private void incomeDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            deleteIncomeEntryButton.Enabled = true;
            deleteIncomeEntryButton.Tag = int.Parse(incomeDataGridView.Rows[e.RowIndex].Cells[13].Value.ToString());
        }

        private void incomeDataGridView_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (!deleteIncomeEntryButton.Focused)
            {
                deleteIncomeEntryButton.Enabled = false;
                deleteIncomeEntryButton.Tag = null;
            }
        }

        private void deleteIncomeEntryButton_Click(object sender, EventArgs e)
        {
            Project project = (Project)projectOption.Tag;
            int id = (int)deleteIncomeEntryButton.Tag;

            project.RemoveIncome(id);
            incomeTableAdapter.Fill(linkupDatabaseDataSet.Income);
            RemoveItems(incomeDataGridView, project.GetProjectName());
            LoadChart(project.GetProjectName(), incomeTableAdapter.GetData());
            dashboardForm.LoadChart(incomeTableAdapter.GetData());
            GetTotalVat(incomeTableAdapter.GetData());
        }

        private void incomeTabPage_Click(object sender, EventArgs e)
        {
            newIncomeButton.Focus();
        }

        private void receiptIncomeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!receiptIncomeRadioButton.Checked)
            {
                incomeTinTextBox.Text = "";
                incomeTinTextBox.Enabled = false;
            }
            else
                incomeTinTextBox.Enabled = true;
        }

        private void incomeDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9)
            {
                try
                {
                    string url = incomeDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                    if (Exists(url))
                        Process.Start(url);
                    else
                        MessageBox.Show("The folder does not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"Error has occured: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void incomeDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Project project = (Project)projectOption.Tag;
            string name = incomeDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
            string bank = incomeDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
            decimal gross = (decimal)incomeDataGridView.Rows[e.RowIndex].Cells[2].Value;
            bool hasReceipt = (int.Parse(incomeDataGridView.Rows[e.RowIndex].Cells[6].Value.ToString()) == 1) ? true : false;
            string reason = incomeDataGridView.Rows[e.RowIndex].Cells[7].Value.ToString();
            DateTime date = (DateTime)incomeDataGridView.Rows[e.RowIndex].Cells[8].Value;
            string attachement = incomeDataGridView.Rows[e.RowIndex].Cells[9].Value.ToString();
            int tin = int.Parse(incomeDataGridView.Rows[e.RowIndex].Cells[11].Value.ToString());
            string type = incomeDataGridView.Rows[e.RowIndex].Cells[12].Value.ToString();
            int id = int.Parse(incomeDataGridView.Rows[e.RowIndex].Cells[13].Value.ToString());

            if (e.ColumnIndex != 3 && e.ColumnIndex != 4 && e.ColumnIndex != 5)
            {
                project.EditIncome(id, name, bank, gross, hasReceipt, reason, date, attachement, tin, type);
                incomeTableAdapter.Fill(linkupDatabaseDataSet.Income);
                RemoveItems(incomeDataGridView, project.GetProjectName());
                LoadChart(project.GetProjectName(), incomeTableAdapter.GetData());
                dashboardForm.LoadChart(incomeTableAdapter.GetData());
                GetTotalVat(incomeTableAdapter.GetData());
            }
        }

        #endregion

        #region CustomFunctions
        public void LoadChart(string name, DataTable dataTable)
        {
            DataRow[] sortedData = SortData(dataTable);
            
            if(dataTable is LinkupDatabaseDataSet.BankLogsDataTable)
            {
                if(name != "Petty")
                {
                    DataTable banksDataTable = banksTableAdapter.GetData();

                    balanceSeries.Values.Clear();
                    bankPieChart.Series.Clear();

                    for (int i = 0; i < sortedData.Length; i++)
                    {
                        if (name == sortedData[i].ItemArray[1].ToString())
                        {
                            balanceSeries.Values.Add(new DateModel
                            {
                                DateTime = (DateTime)sortedData[i].ItemArray[6],
                                Value = double.Parse(sortedData[i].ItemArray[2].ToString())
                            });
                        }
                    }

                    for (int i = 0; i < banksDataTable.Rows.Count; i++)
                    {
                        bankPieChart.Series.Add(new PieSeries
                        {
                            Values = new ChartValues<decimal> { (decimal)banksDataTable.Rows[i].ItemArray[3] },
                            Title = banksDataTable.Rows[i].ItemArray[1].ToString()
                        });
                    }
                }
                else
                {
                    PettyVault vault = (PettyVault)pettyVaultTextBox.Tag;

                    vaultAmountLabel.Text = $"Amount(ETB):{vault.GetAmount()}";
                    foreach (PieSeries series in pettyVaultChart.Series)
                    {
                        if (series.Title == vault.GetName())
                        {
                            series.Values = new ChartValues<decimal> { vault.GetAmount() };
                            break;
                        }
                    }
                    pettyValueTextBox.Text = "";
                    dashboardForm.RefreshDashboard();
                }
            }
            if(dataTable is LinkupDatabaseDataSet.IncomeDataTable)
            {
                grossSeries.Values.Clear();
                netSeries.Values.Clear();

                for (int i = 0; i < sortedData.Length; i++)
                {
                    DateTime time = (DateTime)sortedData[i].ItemArray[9];

                    if (name == sortedData[i].ItemArray[11].ToString())
                    {
                        if(loggedInAccountType == AccountType.Admin)
                        {
                            grossSeries.Values.Add(new DateModel
                            {
                                DateTime = time,
                                Value = double.Parse(sortedData[i].ItemArray[5].ToString())
                            });
                            netSeries.Values.Add(new DateModel
                            {
                                DateTime = time,
                                Value = double.Parse(sortedData[i].ItemArray[8].ToString())
                            });
                        }
                        else
                        {
                            if(sortedData[i].ItemArray[4].ToString() == "1")
                            {
                                grossSeries.Values.Add(new DateModel
                                {
                                    DateTime = time,
                                    Value = double.Parse(sortedData[i].ItemArray[5].ToString())
                                });
                                netSeries.Values.Add(new DateModel
                                {
                                    DateTime = time,
                                    Value = double.Parse(sortedData[i].ItemArray[8].ToString())
                                });
                            }
                        }
                        
                    }
                }    
            }
            if(dataTable is LinkupDatabaseDataSet.ExpenseDataTable)
            {
                amountSeries.Values.Clear();
                totalSeries.Values.Clear();

                for (int i = 0; i < sortedData.Length; i++)
                {
                    DateTime time = (DateTime)sortedData[i].ItemArray[8];

                    if(name == sortedData[i].ItemArray[11].ToString())
                    {
                        if(loggedInAccountType == AccountType.Admin)
                        {
                            amountSeries.Values.Add(new DateModel
                            {
                                DateTime = time,
                                Value = double.Parse(sortedData[i].ItemArray[2].ToString())
                            });
                            totalSeries.Values.Add(new DateModel
                            {
                                DateTime = time,
                                Value = double.Parse(sortedData[i].ItemArray[10].ToString())
                            });
                        }
                        else
                        {
                            if(sortedData[i].ItemArray[12].ToString() == "1")
                            {
                                amountSeries.Values.Add(new DateModel
                                {
                                    DateTime = time,
                                    Value = double.Parse(sortedData[i].ItemArray[2].ToString())
                                });
                                totalSeries.Values.Add(new DateModel
                                {
                                    DateTime = time,
                                    Value = double.Parse(sortedData[i].ItemArray[10].ToString())
                                });
                            }
                        }
                    }
                }
            }
        }

        private void SearchDataGridView(Guna.UI2.WinForms.Guna2DataGridView dataGridView, string searchEntry, int cellIndex, bool hasReceipt = false)
        {
            //TODO: Change the receipt values from int to string
            List<int> tobeRemovedList = new List<int>();
            int removed = 0;

            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                if (dataGridView.Rows[i].Cells[cellIndex].Value != null)
                {
                    if (dataGridView.Equals(incomeDataGridView))
                    {
                        if (cellIndex == 0 || cellIndex == 1 || cellIndex == 6 || cellIndex == 7)
                        {
                            if (cellIndex == 6)
                            {
                                if (hasReceipt)
                                {
                                    if (int.Parse(dataGridView.Rows[i].Cells[cellIndex].Value.ToString()) != 1)
                                        tobeRemovedList.Add(i);
                                    else
                                        if (searchEntry != dataGridView.Rows[i].Cells[0].Value.ToString())
                                        tobeRemovedList.Add(i);
                                }
                                else
                                {
                                    if (int.Parse(dataGridView.Rows[i].Cells[cellIndex].Value.ToString()) != 0)
                                        tobeRemovedList.Add(i);
                                    else
                                        if (searchEntry != (string)dataGridView.Rows[i].Cells[0].Value.ToString())
                                        tobeRemovedList.Add(i);
                                }
                            }
                            else
                                if (searchEntry != dataGridView.Rows[i].Cells[cellIndex].Value.ToString())
                                    tobeRemovedList.Add(i);
                        }


                        if (cellIndex == 2 || cellIndex == 5)
                        {
                            decimal value;
                            decimal.TryParse(searchEntry, out value);

                            if (value != (decimal)dataGridView.Rows[i].Cells[cellIndex].Value)
                                tobeRemovedList.Add(i);
                        }
                    }
                    else
                    {
                        if (cellIndex == 0 || cellIndex == 1 || cellIndex == 2 || cellIndex == 3 || cellIndex == 8 || cellIndex == 9)
                        {
                            if (cellIndex == 8)
                            { 
                                if (hasReceipt)
                                {
                                    if (int.Parse(dataGridView.Rows[i].Cells[cellIndex].Value.ToString()) != 1)
                                        tobeRemovedList.Add(i);
                                    else
                                        if (searchEntry != dataGridView.Rows[i].Cells[0].Value.ToString())
                                        tobeRemovedList.Add(i);
                                }
                                else
                                {
                                    if (int.Parse(dataGridView.Rows[i].Cells[cellIndex].Value.ToString()) != 0)
                                        tobeRemovedList.Add(i);
                                    else
                                        if (searchEntry != (string)dataGridView.Rows[i].Cells[0].Value.ToString())
                                        tobeRemovedList.Add(i);
                                }
                            }
                            else
                                if (searchEntry != dataGridView.Rows[i].Cells[cellIndex].Value.ToString())
                                    tobeRemovedList.Add(i);
                        }


                        if (cellIndex == 4 || cellIndex == 7)
                        {
                            decimal value;
                            decimal.TryParse(searchEntry, out value);

                            if (value != (decimal)dataGridView.Rows[i].Cells[cellIndex].Value)
                                tobeRemovedList.Add(i);
                        }
                    }
                }
            }

            foreach (int rowIndex in tobeRemovedList)
            {
                dataGridView.Rows.RemoveAt(rowIndex - removed);
                removed++;
            }
        }

        private void SearchDataGridView(Guna.UI2.WinForms.Guna2DataGridView dataGridView, DateTime fromDate, DateTime toDate)
        {
            List<int> tobeRemovedList = new List<int>();
            int removed = 0;
            int cellIndex;

            if (dataGridView.Equals(expenseDataGridView))
                cellIndex = 10;
            else
                cellIndex = 8;

            for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
                if (!(DateTime.Compare((DateTime)dataGridView.Rows[i].Cells[cellIndex].Value, fromDate) >= 0 &&
                    DateTime.Compare((DateTime)dataGridView.Rows[i].Cells[cellIndex].Value, toDate) <= 0))
                    tobeRemovedList.Add(i);

            foreach (int rowIndex in tobeRemovedList)
            {
                dataGridView.Rows.RemoveAt(rowIndex - removed);
                removed++;
            }
        }

        public DataRow[] SortData(DataTable dataTable)
        {
            DataRow[] sortArray = new DataRow[dataTable.Rows.Count];
            int num = 0;
            for(int i = 0; i < dataTable.Rows.Count; i++)
            {
                sortArray[i] = dataTable.Rows[i];
                num++;
            }

            int inner, numElements = sortArray.Length, itemIndex;
            DataRow temp;
            int h = 1;

            if (dataTable is LinkupDatabaseDataSet.IncomeDataTable)
                itemIndex = 9;
            else if (dataTable is LinkupDatabaseDataSet.BankLogsDataTable || dataTable is LinkupDatabaseDataSet.EmployeeLogsDataTable)
                itemIndex = 6;
            else
                itemIndex = 8;

            while (h <= numElements / 3)
                h = h * 3 + 1;
            while (h > 0)
            {
                for (int outer = h; outer <= numElements - 1; outer++)
                {
                    temp = sortArray[outer];
                    inner = outer;

                    while ((inner > h - 1) &&
                        DateTime.Compare((DateTime)sortArray[inner - h].ItemArray[itemIndex],
                                        (DateTime)temp.ItemArray[itemIndex]) == 1)
                    {
                        sortArray[inner] = sortArray[inner - h];
                        inner -= h;
                    }

                    sortArray[inner] = temp;
                }
                h = (h - 1) / 3;
            }

            return sortArray; 
        }

        private void RemoveItems(Guna.UI2.WinForms.Guna2DataGridView dataGridView, string filter)
        {
            List<int> tobeRemovedList = new List<int>();
            int removed;

            if (dataGridView.Equals(bankLogDataGridView))
            {
                removed = 0;

                for (int i = 0; i < dataGridView.Rows.Count; i++)
                    if (dataGridView.Rows[i].Cells[2].Value != null)
                        if (dataGridView.Rows[i].Cells[2].Value.ToString() != filter && dataGridView.Rows[i].Cells[2].Value.ToString() != "Petty")
                            tobeRemovedList.Add(i);

                foreach (int rowIndex in tobeRemovedList)
                {
                    dataGridView.Rows.RemoveAt(rowIndex - removed);
                    removed++;
                }
            }

            if (dataGridView.Equals(incomeDataGridView))
            {
                removed = 0;

                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    if (dataGridView.Rows[i].Cells[10].Value != null)
                        if (dataGridView.Rows[i].Cells[10].Value.ToString() != filter)
                            tobeRemovedList.Add(i);

                    if(loggedInAccountType != AccountType.Admin)
                        if (dataGridView.Rows[i].Cells[6].Value != null)
                            if (dataGridView.Rows[i].Cells[6].Value.ToString() != "1")
                                if(!tobeRemovedList.Contains(i))
                                    tobeRemovedList.Add(i);
                }
                    

                foreach (int rowIndex in tobeRemovedList)
                {
                    dataGridView.Rows.RemoveAt(rowIndex - removed);
                    removed++;
                }
            }

            if (dataGridView.Equals(expenseDataGridView))
            {
                removed = 0;

                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    if (dataGridView.Rows[i].Cells[12].Value != null)
                        if (dataGridView.Rows[i].Cells[12].Value.ToString() != filter && dataGridView.Rows[i].Cells[12].Value.ToString() != "")
                            tobeRemovedList.Add(i);

                    if (loggedInAccountType != AccountType.Admin)
                        if (dataGridView.Rows[i].Cells[8].Value != null)
                            if (dataGridView.Rows[i].Cells[8].Value.ToString() != "1")
                                if(!tobeRemovedList.Contains(i))
                                    tobeRemovedList.Add(i);
                }
                    

                foreach (int rowIndex in tobeRemovedList)
                {
                    dataGridView.Rows.RemoveAt(rowIndex - removed);
                    removed++;
                }
            }   
        }

        public void Link(DashboardForm dashboardForm)
        {
            this.dashboardForm = dashboardForm;
        }

        public void SetAccountType(AccountType type)
        {
            loggedInAccountType = type;
        }

        public decimal GetTotalVat(DataTable dataTable)
        {
            decimal total = 0m;

            if(dataTable is LinkupDatabaseDataSet.IncomeDataTable)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                    total += (decimal)dataTable.Rows[i].ItemArray[6];
            }

            if(dataTable is LinkupDatabaseDataSet.ExpenseDataTable)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                    total += (decimal)dataTable.Rows[i].ItemArray[4];
            }
            
            return total;
        }
        #endregion
    }
}
