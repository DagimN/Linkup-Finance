using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
            newProjectLabel.Visible = true;
            submitButton.Visible = true;
            projectNameTextBox.Visible = true;
            exitSubmissionButton.Visible = true;
            projectNameTextBox.Text = "Project/Company Name";
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            string projectName = projectNameTextBox.Text;
            if (!projectManager.Exists(projectName))
            {
                projectOption.Items.Add(projectName);
                projectOption.Text = projectName;

                projectManager.AddProject(projectName);

                this.projectsTableAdapter.Fill(this.linkupDatabaseDataSet.Projects);
                projectManager.RetrieveProjects(projectsTableAdapter);

                newProjectLabel.Visible = false;
                submitButton.Visible = false;
                projectNameTextBox.Visible = false;
                exitSubmissionButton.Visible = false;
            }
        }

        private void ProjectForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'linkupDatabaseDataSet.Projects' table. You can move, or remove it, as needed.
            this.projectsTableAdapter.Fill(this.linkupDatabaseDataSet.Projects);

            projectManager.RetrieveProjects(projectsTableAdapter);
            foreach(Project project in projectManager.projects)
            {
                projectOption.Items.Add(project.GetProjectName());
            }
        }

        private void cartesianChart1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

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
    }
}
