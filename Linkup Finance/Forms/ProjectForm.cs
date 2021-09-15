using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            newProjectPanel.Visible = true;
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            string projectName = projectNameTextBox.Text;
            if (!projectManager.Exists(projectName))
            {
                projectOption.Items.Add(projectName);
                projectOption.Text = projectName;

                projectManager.AddProject(projectName);

                newProjectPanel.Visible = false;
            }
        }

        private void closeProjectPanelButton_Click(object sender, EventArgs e)
        {
            newProjectPanel.Visible = false;
        }

        private void ProjectForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'linkupDatabaseDataSet.Projects' table. You can move, or remove it, as needed.
            this.projectsTableAdapter.Fill(this.linkupDatabaseDataSet.Projects);
            // TODO: This line of code loads data into the 'linkupDatabaseDataSet.Projects' table. You can move, or remove it, as needed.
            this.projectsTableAdapter.Fill(this.linkupDatabaseDataSet.Projects);
            guna2DataGridView1.DataSource = this.projectsTableAdapter.GetData();
        }
    }
}
