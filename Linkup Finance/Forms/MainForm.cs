using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Linkup_Finance.Forms;
using System.Data;
using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;
using Linkup_Finance.Managers;

namespace Linkup_Finance
{
    public partial class MainForm : Form
    {
        private bool isViewing = false;
        private static string attachementDirectory = Combine(GetFolderPath(SpecialFolder.MyDocuments), "Linkup Finance Attachements");
        private static string expenseDirectory = Combine(attachementDirectory, "Expense");
        private static string incomeDirectory = Combine(attachementDirectory, "Income");
        private Form activeForm;
        private DashboardForm dashboardForm;
        public ProjectForm projectForm;
        private SettingsForm settingsForm;
        private AccountType loggedInAccountType;

        private Point startPoint = new Point(0, 0);
        private bool drag = false;

        private FormWindowState state = FormWindowState.Normal;

        public MainForm()
        {
            InitializeComponent();

            if (!Exists(attachementDirectory))
                CreateDirectory(attachementDirectory);
            if (!Exists(incomeDirectory))
                CreateDirectory(incomeDirectory);
            if (!Exists(expenseDirectory))
                CreateDirectory(expenseDirectory);

            settingsForm = new SettingsForm();
            projectForm = new ProjectForm();
            dashboardForm = new DashboardForm(projectForm, settingsForm);
            projectForm.Link(dashboardForm);
            settingsForm.Link(dashboardForm);
            
            openChildForm(settingsForm);
            openChildForm(projectForm);
            openChildForm(dashboardForm);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MaximumSize = Screen.FromHandle(this.Handle).WorkingArea.Size;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (isViewing)
            {
                //TransitionPanel(titleBarPanel.Size, new Size(1200, 100), guna2Button1.Location);

                isViewing = false;
            }
            else
            {
                //TransitionPanel(titleBarPanel.Size, new Size(1200, 480), guna2Button1.Location);
                
                isViewing = true;
            }
        }

        //Load Pages to the work panel
        private void openChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Visible = false;

            workPanel.Controls.Remove(activeForm);
            activeForm = childForm;
            activeForm.TopLevel = false;
            workPanel.SuspendLayout();
            workPanel.Controls.Add(activeForm);
            activeForm.Visible = true;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void titleBarPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.drag)
            {
                Point p1 = new Point(e.X, e.Y);
                Point p2 = this.PointToScreen(p1);
                Point p3 = new Point(p2.X - this.startPoint.X,
                                     p2.Y - this.startPoint.Y);

                this.Location = p3;
            }
        }

        private void titleBarPanel_MouseDown(object sender, MouseEventArgs e)
        {
            startPoint = e.Location;
            drag = true;
        }

        private void titleBarPanel_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void titleBarPanel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (state == FormWindowState.Normal)
            {
                for (int i = 0; i < Application.OpenForms.Count; i++)
                    if (Application.OpenForms[i].TopLevel)
                    {
                        Application.OpenForms[i].WindowState = FormWindowState.Maximized;
                        maximizeButton.Image = Linkup_Finance.Properties.Resources.Maximized_Icon;
                    }

                ResizeControls();

                state = FormWindowState.Maximized;
            }

            else
            {
                for (int i = 0; i < Application.OpenForms.Count; i++)
                    if (Application.OpenForms[i].TopLevel)
                    {
                        Application.OpenForms[i].WindowState = FormWindowState.Normal;
                        Application.OpenForms[i].Size = new Size(1200, 586);
                        maximizeButton.Image = Linkup_Finance.Properties.Resources.Maximize_Icon;
                    }

                ResizeControls();

                state = FormWindowState.Normal;
            }
        }

        private void maximizeButton_Click(object sender, EventArgs e)
        {
            if (state == FormWindowState.Normal)
            {
                for (int i = 0; i < Application.OpenForms.Count; i++)
                    if (Application.OpenForms[i].TopLevel)
                    {
                        Application.OpenForms[i].WindowState = FormWindowState.Maximized;
                        maximizeButton.Image = Linkup_Finance.Properties.Resources.Maximized_Icon;
                    }

                ResizeControls();

                state = FormWindowState.Maximized;
            }
                
            else
            {
                for (int i = 0; i < Application.OpenForms.Count; i++)
                    if (Application.OpenForms[i].TopLevel)
                    {
                        Application.OpenForms[i].WindowState = FormWindowState.Normal;
                        Application.OpenForms[i].Size = new Size(1200, 586);
                        maximizeButton.Image = Linkup_Finance.Properties.Resources.Maximize_Icon;
                    }

                ResizeControls();

                state = FormWindowState.Normal;
            }
        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            if (state == FormWindowState.Normal || state == FormWindowState.Maximized)
                for (int i = 0; i < Application.OpenForms.Count; i++)
                    if (Application.OpenForms[i].TopLevel) Application.OpenForms[i].WindowState = FormWindowState.Minimized;
        }

        private void dashboardButton_Click(object sender, EventArgs e)
        {
            openChildForm(dashboardForm);
        }

        private void projectButton_Click(object sender, EventArgs e)
        {
            openChildForm(projectForm);
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            openChildForm(settingsForm);
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string name = userNameTextBox.Text.Trim();
            string password = passwordTextBox.Text.Trim();
            DataTable userDataTable = settingsForm.usersTableAdapter.GetData();
            bool exists = false;

            if (otherCheckBox.Checked)
            {
                if(name != "")
                {
                    logoPictureBox.Visible = false;
                    loginPanel.Visible = false;
                    dashboardButton.Visible = true;
                    settingsButton.Visible = true;
                    projectButton.Visible = true;
                    smallLogoPictureBox.Visible = true;
                    financeLabel.Visible = true;

                    titleBarPanel.Size = new Size(1200, 76);

                    dashboardForm.welcomeNameLabel.Text = name;
                    loggedInAccountType = AccountType.Other;

                    projectForm.SetAccountType(loggedInAccountType);
                    dashboardForm.SetAccountType(loggedInAccountType);
                    settingsForm.SetAccountType(name, loggedInAccountType);

                    dashboardForm.LoadChart(projectForm.incomeTableAdapter.GetData());
                    dashboardForm.LoadChart(projectForm.expenseTableAdapter.GetData());

                    if(projectForm.projectOption.Text != "")
                    {
                        projectForm.LoadChart(projectForm.projectOption.Text, projectForm.incomeTableAdapter.GetData());
                        projectForm.LoadChart(projectForm.projectOption.Text, projectForm.expenseTableAdapter.GetData());
                    }

                    projectForm.newProjectButton.Enabled = false;
                    projectForm.newIncomeButton.Enabled = false;
                    projectForm.newExpenseButton.Enabled = false;
                    projectForm.newBankButton.Enabled = false;
                    projectForm.newPettyVaultButton.Enabled = false;
                    projectForm.depositButton.Enabled = false;
                    projectForm.removeProjectButton.Visible = false;
                    projectForm.replenishButton.Enabled = false;
                    projectForm.removeVaultButton.Enabled = false;

                    settingsButton.Enabled = false;
                    settingsForm.userManager.LogUser(name);
                }
                else
                {
                    userNameTextBox.Text = "Username is not provided.";
                    userNameTextBox.FillColor = Color.FromArgb(240, 160, 140);
                }
            }
            else
            {
                for (int i = 0; i < userDataTable.Rows.Count; i++)
                {
                    if (name.ToLower() == userDataTable.Rows[i].ItemArray[1].ToString().ToLower())
                    {
                        if (password == userDataTable.Rows[i].ItemArray[3].ToString())
                        {
                            logoPictureBox.Visible = false;
                            loginPanel.Visible = false;
                            dashboardButton.Visible = true;
                            settingsButton.Visible = true;
                            projectButton.Visible = true;
                            smallLogoPictureBox.Visible = true;
                            financeLabel.Visible = true;

                            titleBarPanel.Size = new Size(1200, 76);
                            dashboardForm.welcomeNameLabel.Text = name;
                            exists = true;

                            string type = userDataTable.Rows[i].ItemArray[2].ToString();

                            if (type == "Admin")
                                loggedInAccountType = AccountType.Admin;
                            else if (type == "Accountant")
                                loggedInAccountType = AccountType.Accountant;
                            else
                                loggedInAccountType = AccountType.Other;

                            projectForm.SetAccountType(loggedInAccountType);
                            dashboardForm.SetAccountType(loggedInAccountType);
                            settingsForm.SetAccountType(name, loggedInAccountType);

                            dashboardForm.LoadChart(projectForm.incomeTableAdapter.GetData());
                            dashboardForm.LoadChart(projectForm.expenseTableAdapter.GetData());

                            if (loggedInAccountType == AccountType.Other)
                            {
                                projectForm.newProjectButton.Enabled = false;
                                projectForm.newIncomeButton.Enabled = false;
                                projectForm.newExpenseButton.Enabled = false;
                                projectForm.newBankButton.Enabled = false;
                                projectForm.newPettyVaultButton.Enabled = false;
                                projectForm.depositButton.Enabled = false;
                                projectForm.removeProjectButton.Visible = false;
                                projectForm.replenishButton.Enabled = false;
                                projectForm.removeVaultButton.Enabled = false;
                            }

                            if (loggedInAccountType == AccountType.Accountant)
                            {
                                projectForm.newProjectButton.Enabled = false;
                                projectForm.newIncomeButton.Enabled = true;
                                projectForm.newExpenseButton.Enabled = true;
                                projectForm.newBankButton.Enabled = false;
                                projectForm.newPettyVaultButton.Enabled = false;
                                projectForm.depositButton.Enabled = false;
                                projectForm.removeProjectButton.Visible = false;
                                projectForm.replenishButton.Enabled = false;
                                projectForm.removeVaultButton.Enabled = false;
                            }

                            if (loggedInAccountType == AccountType.Admin)
                            {
                                projectForm.newProjectButton.Enabled = true;
                                projectForm.newIncomeButton.Enabled = true;
                                projectForm.newExpenseButton.Enabled = true;
                                projectForm.newBankButton.Enabled = true;
                                projectForm.newPettyVaultButton.Enabled = true;
                                projectForm.depositButton.Enabled = true;
                                projectForm.removeProjectButton.Visible = true;
                                projectForm.replenishButton.Enabled = true;
                                projectForm.removeVaultButton.Enabled = true;
                            }

                            if (loggedInAccountType == AccountType.Admin)
                                settingsButton.Enabled = true;
                            else
                                settingsButton.Enabled = false;

                            settingsForm.userManager.LogUser(name);

                            break;
                        }
                        else
                        {
                            passwordTextBox.Text = "Invalid Password";
                            passwordTextBox.FillColor = Color.FromArgb(240, 160, 140);

                            break;
                        }
                    }
                }

                if (!exists)
                {
                    userNameTextBox.Text = "Username does not exists";
                    userNameTextBox.FillColor = Color.FromArgb(240, 160, 140);
                }
            }
        }

        private void userNameTextBox_TextChanged(object sender, EventArgs e)
        {
            userNameTextBox.FillColor = Color.White;
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
            passwordTextBox.FillColor = Color.White;
        }

        private void otherCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (otherCheckBox.Checked)
                passwordTextBox.Enabled = false;
            else
                passwordTextBox.Enabled = true;
        }

        #region Custom Functions

        public static void TransitionPanel(Size oldSize, Size newsize, Point oldPoint)
        {
            Size oldP = oldSize;
            Size newP = newsize;
            Point oldB = oldPoint;

            if (oldP.Height < newP.Height)
            {
                for (int i = oldP.Height; oldP.Height < newP.Height; i += 5)
                {
                    Thread.Sleep(TimeSpan.FromMilliseconds(0.01));
                }
            }
            else
            {
                for (int i = newP.Height; oldP.Height > newP.Height; i -= 5)
                {
                    Thread.Sleep(TimeSpan.FromMilliseconds(0.01));
                }
            }
        }

        private void ResizeControls()
        {
            Size resizeValue = new Size(this.Width, this.Height - titleBarPanel.Height);
            workPanel.Size = resizeValue;
            projectForm.Size = resizeValue;
            dashboardForm.Size = resizeValue;
            settingsForm.Size = resizeValue;

            if(state == FormWindowState.Maximized)
            {
                projectForm.ledgerTabControl.Size = new Size(1200, 530);
            }
            else
            {
                projectForm.ledgerTabControl.Size = new Size(1200, 590);
            }
        }

        #endregion
    }
}
