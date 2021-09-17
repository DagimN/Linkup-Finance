using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Linkup_Finance.Managers;

namespace Linkup_Finance.Forms
{
    public partial class ProjectForm : Form
    {
        public ProjectManager projectManager;
        public ProjectForm()
        {
            InitializeComponent();
            projectManager = new ProjectManager();
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
            filterLabel.Visible = false;

            switch (filterComboBox.Text)
            {
                case "All":
                    filterComboBox.Text = null;
                    filterLabel.Visible = true;
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
            newIncomePanel.Visible = false;
        }

        private void nonreceiptRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (nonreceiptRadioButton.Checked)
                addReceiptLinkLabel.Enabled = false;
        }

        private void receiptRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (receiptRadioButton.Checked)
                addReceiptLinkLabel.Enabled = true;
        }

        private void submitIncomeButton_Click(object sender, EventArgs e)
        {
            ArrayList newIncomeList = new ArrayList();
            Project project = (Project)incomeDataGridView.Tag;
            decimal gross;
            decimal.TryParse(grossTextBox.Text, out gross);

            if(project != null)
            {
                newIncomeList.Add(nameTextBox.Text);
                newIncomeList.Add(reasonTextBox.Text);
                newIncomeList.Add(bankTextBox.Text);
                newIncomeList.Add(gross);
                if(receiptRadioButton.Checked)
                    newIncomeList.Add(1);
                else
                    newIncomeList.Add(0);

                if (project.AddIncome(newIncomeList))
                {
                    newIncomePanel.Visible = false;
                }
            }
        }
    }
}
