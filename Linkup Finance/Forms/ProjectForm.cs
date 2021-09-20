using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Collections;
using System.IO;
using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Linkup_Finance.Managers;
using LiveCharts.Wpf;
using LiveCharts.Configurations;
using LiveCharts;
using System.Diagnostics;

namespace Linkup_Finance.Forms
{
    public partial class ProjectForm : Form
    {
        public ProjectManager projectManager;
        private int zoomValue = 99;
        
        private LineSeries grossSeries, netSeries;
        private Axis xAxis, yAxis;
        private class DateModel
        {
            public System.DateTime DateTime { get; set; }
            public double Value { get; set; }
            
        }

        public ProjectForm()
        {
            InitializeComponent();
            projectManager = new ProjectManager();

            var dayConfig = Mappers.Xy<DateModel>()
                .X(dayModel => (double)dayModel.DateTime.Ticks / TimeSpan.FromDays(1).Ticks)
                .Y(dayModel => dayModel.Value);

            grossSeries = new LineSeries
            {
                Values = new ChartValues<DateModel>(),
                Title = "Gross",
                Stroke = System.Windows.Media.Brushes.ForestGreen,
                Fill = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(50, 34, 139, 34))
            };

            netSeries = new LineSeries
            {
                Values = new ChartValues<DateModel>(),
                Title = "Net",
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
                Foreground = netSeries.Fill,
                LabelFormatter = value => value + " ETB"
            };

            incomeChart.Series = new SeriesCollection(dayConfig);
            incomeChart.Pan = PanningOptions.X;
            incomeChart.AxisX.Add(xAxis);
            incomeChart.AxisY.Add(yAxis);
        }

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
                incomeDataGridView.Tag = projectManager.AddProject(projectName);
                
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

        private void ProjectForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'linkupDatabaseDataSet.Income' table. You can move, or remove it, as needed.
            this.incomeTableAdapter.Fill(this.linkupDatabaseDataSet.Income);
            this.projectsTableAdapter.Fill(this.linkupDatabaseDataSet.Projects);

            foreach(Project project in projectManager.RetrieveProjects(projectsTableAdapter))
                projectOption.Items.Add(project.GetProjectName());

            if(projectOption.Items.Count > 0)
            {
                projectOption.Text = projectOption.Items[0].ToString();

                Project project = projectManager.Exists(projectOption.Text, true);
                incomeDataGridView.Tag = project;
            }
             
            incomeChart.Series.Add(grossSeries);
            incomeChart.Series.Add(netSeries);

            LoadIncomeChart(incomeTableAdapter.GetData());

            filterComboBox.Text = "All";
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
                    if (projectOption.Text == "")
                        removeProjectButton.Visible = false;
                }
            }
        }

        private void projectOption_SelectedValueChanged(object sender, EventArgs e)
        {
            if (projectOption.Text != "")
                removeProjectButton.Visible = true;
            Thread.Sleep(1000);
            Project project = projectManager.Exists(projectOption.Text, true);
            incomeDataGridView.Tag = project;
        }

        private void filterComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            //Change the placeholder text of the search text box whenever a filter has been applied to the data set
            switch (filterComboBox.Text)
            {
                case "All":
                    incomeSearchTextBox.PlaceholderText = "Payer's Name";
                    break;
                case "Gross":
                    incomeSearchTextBox.PlaceholderText = "Gross Value";
                    break;
                case "Reason":
                    incomeSearchTextBox.PlaceholderText = "Reason";
                    break;
                case "Receipt":
                case "Non-Receipt":
                    incomeSearchTextBox.PlaceholderText = "Payer's Name";
                    break;
                case "Bank":
                    incomeSearchTextBox.PlaceholderText = "Bank's Name";
                    break;
                case "Net":
                    incomeSearchTextBox.PlaceholderText = "Net Value";
                    break;
            }                
        }

        private void newIncomeButton_Click(object sender, EventArgs e)
        {
            newIncomePanel.Visible = true;
        }

        private void closeIncomePanelButton_Click(object sender, EventArgs e)
        {
            nameTextBox.ResetText();
            bankTextBox.ResetText();
            reasonTextBox.ResetText();
            grossTextBox.ResetText();
            submitIncomeButton.Tag = null;
            incomeDateSelection.Value = DateTime.Now;
            newIncomePanel.Visible = false;
            errorChip.Visible = false;
            newIncomePanel.Visible = false;
        }

        private void submitIncomeButton_Click(object sender, EventArgs e)
        {
            Project project = (Project)incomeDataGridView.Tag;
            string name = nameTextBox.Text;
            string reason = reasonTextBox.Text;
            string bank = bankTextBox.Text;
            bool hasReceipt = receiptRadioButton.Checked;
            decimal gross;
            DateTime date = incomeDateSelection.Value;
            bool isValid = decimal.TryParse(grossTextBox.Text, out gross);
            string[] attachements = (string[])submitIncomeButton.Tag;
            Random rand = new Random();
            string folderName = DateTime.Now.ToString("MMMMddyyyy") + rand.Next(999999999) + name;
            string attachmentDirectory = (attachements != null) ? Combine(GetFolderPath(SpecialFolder.MyDocuments), "Linkup Finance Attachements", folderName) : null;

            newIncomePanel.Controls.Remove(errorChip);
            errorChip = new Guna.UI2.WinForms.Guna2Chip
            {
                Size = new Size(379, 45),
                Location = new Point(377, 9),
                Text = "",
                Visible = false,
            };
            newIncomePanel.Controls.Add(errorChip);
            errorChip.BringToFront();

            if(attachements != null)
            {
                while (Exists(attachmentDirectory))
                {
                    folderName = DateTime.Now.ToString("MMMddyyyy") + rand.Next(999999999) + name;
                    attachmentDirectory = Combine(GetFolderPath(SpecialFolder.MyDocuments), "Linkup Finance Attachements", folderName);
                }
            }

            if (isValid)
            {
                if (project != null)
                {
                    if (name != "" && reason != "" && bank != "" && gross != 0.00m)
                    {
                        if(!(hasReceipt ^ attachements != null))
                        {
                            if (project.AddIncome(name, reason, bank, hasReceipt, gross, date, attachmentDirectory))
                            {
                                //Associate attachements with entry and store in local machine
                                if (attachements != null)
                                {
                                    CreateDirectory(attachmentDirectory);

                                    foreach (string fileName in (string[])submitIncomeButton.Tag)
                                        File.Copy(fileName, Combine(attachmentDirectory, GetFileName(fileName)));
                                }

                                nameTextBox.ResetText();
                                bankTextBox.ResetText();
                                reasonTextBox.ResetText();
                                grossTextBox.ResetText();
                                submitIncomeButton.Tag = null;
                                incomeDateSelection.Value = DateTime.Now;
                                newIncomePanel.Visible = false;
                                errorChip.Visible = false;
                                incomeTableAdapter.Fill(this.linkupDatabaseDataSet.Income);
                                LoadIncomeChart(incomeTableAdapter.GetData());
                            }
                            else
                            {
                                errorChip.Visible = true;
                                errorChip.Text = "An error as occured when inserting data to the database. Make sure all the required data is correct.";
                            }
                                
                        }
                        else
                        {
                            errorChip.Visible = true;
                            errorChip.Text = "Receipt is missing. Locate the receipt file and try again";
                        }
                    }
                    else
                    {
                        errorChip.Visible = true;
                        errorChip.Text = "There are missing values that are required to continue. Fill them and try again";
                    }
                }
                else
                {
                    errorChip.Visible = true;
                    errorChip.Text = "There is no selected project. Select a project and try again.";
                }
            }
            else
            {
                errorChip.Visible = true;
                errorChip.Text = "The gross value is in an incorrect format. Try again.";
            }
        }

        private void zoomTrackBar_ValueChanged(object sender, EventArgs e)
        {
            int value = zoomTrackBar.Value;
            zoomNumericUpDown.Value = value;

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

        private void zoomNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            int value;
            int.TryParse(zoomNumericUpDown.Value.ToString(), out value);
            zoomTrackBar.Value = value;
        }

        private void chartDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            DateTime dateSelection = chartDateTimePicker.Value;
            xAxis.MinValue = dateSelection.Subtract(TimeSpan.FromDays(5)).Ticks / TimeSpan.TicksPerDay;
            xAxis.MaxValue = dateSelection.AddDays(5).Ticks / TimeSpan.TicksPerDay;
            zoomValue = 99;
            zoomTrackBar.Value = zoomValue;
        }

        private void searchIncomeButton_Click(object sender, EventArgs e)
        {
            string filter = filterComboBox.Text;
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
                    SearchDataGridView(incomeDataGridView, entry, 6);
                    break;
                case "Non-Receipt":
                    SearchDataGridView(incomeDataGridView, entry, 6);
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
                    SearchDataGridView(incomeDataGridView, entry, 8);
                    break;
            }
        }

        private void incomeSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            if(incomeSearchTextBox.Text == "")
                incomeTableAdapter.Fill(linkupDatabaseDataSet.Income);
        }

        private void attachementsButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog attachementDialog = new OpenFileDialog();
            attachementDialog.Filter = "All Files (*.*)|*.*";
            attachementDialog.Multiselect = true;
            
            DialogResult result = attachementDialog.ShowDialog();

            if(result == DialogResult.OK)
                submitIncomeButton.Tag = attachementDialog.FileNames;
        }

        private void LoadIncomeChart(LinkupDatabaseDataSet.IncomeDataTable incomeDataTable)
        {
            grossSeries.Values.Clear();
            netSeries.Values.Clear();
            for (int i = 0; i < incomeDataTable.Count; i++)
            {
                DateTime time = (DateTime)incomeDataTable.Rows[i].ItemArray[9];
                grossSeries.Values.Add(new DateModel
                {
                    DateTime = time,
                    Value = double.Parse(incomeDataTable.Rows[i].ItemArray[5].ToString())
                });
                netSeries.Values.Add(new DateModel
                {
                    DateTime = time,
                    Value = double.Parse(incomeDataTable.Rows[i].ItemArray[8].ToString())
                });
            }
        }

        private void SearchDataGridView(Guna.UI2.WinForms.Guna2DataGridView dataGridView, string searchEntry, int cellIndex)
        {
            dataGridView.EndEdit();

            for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
            {
                if(searchEntry != (string)dataGridView.Rows[i].Cells[cellIndex].Value)
                    dataGridView.Rows.RemoveAt(i);
            }
        }
    }
}
