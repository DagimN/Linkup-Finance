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
    public partial class SettingsForm : Form
    {
        public UserManager userManager;
        public SettingsForm()
        {
            InitializeComponent();
            userManager = new UserManager();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'linkupDatabaseDataSet.UserLog' table. You can move, or remove it, as needed.
            this.userLogTableAdapter.Fill(this.linkupDatabaseDataSet.UserLog);
            usersTableAdapter.Fill(this.linkupDatabaseDataSet.Users);

            for (int i = 0; i < usersTableAdapter.GetData().Rows.Count; i++)
            {
                string name = usersTableAdapter.GetData().Rows[i].ItemArray[1].ToString();
                string strType = usersTableAdapter.GetData().Rows[i].ItemArray[2].ToString();
                string job = usersTableAdapter.GetData().Rows[i].ItemArray[4].ToString();
                string password = usersTableAdapter.GetData().Rows[i].ItemArray[3].ToString();
                AccountType type;

                if (strType == "Admin")
                    type = AccountType.Admin;
                else if (strType == "Accountant")
                    type = AccountType.Accountant;
                else
                    type = AccountType.Other;

                usersComboBox.Items.Add(name);

                userManager.RetrieveUsers(name, type, password, job);
            }

            if (usersComboBox.Items.Count > 0)
                usersComboBox.Text = usersComboBox.Items[0].ToString();
        }

        #region UserTab

        private void addUserButton_Click(object sender, EventArgs e)
        {
            newUserPanel.Visible = true;
        }

        private void closeNewUserPanelButton_Click(object sender, EventArgs e)
        {
            newUserPanel.Visible = false;
            userNameTextBox.ResetText();
            jobTitleTextBox.ResetText();
            passwordTextBox.ResetText();
        }

        private void submitUserButton_Click(object sender, EventArgs e)
        {
            string name = userNameTextBox.Text;
            string job = jobTitleTextBox.Text;
            string password = passwordTextBox.Text;
            string strType;
            AccountType type;
            
            newUserPanel.Controls.Remove(userErrorChip);
            userErrorChip = new Guna.UI2.WinForms.Guna2Chip
            {
                Size = new Size(365, 45),
                Location = new Point(224, 18),
                Text = "",
                Visible = false,
                BackColor = Color.Transparent
            };
            newUserPanel.Controls.Add(userErrorChip);
            userErrorChip.BringToFront();

            if (adminRadioButton.Checked)
            {
                type = AccountType.Admin;
                strType = "Administrator";
            }
            else if (accountantRadioButton.Checked)
            {
                type = AccountType.Accountant;
                strType = "Accountant";
            }
            else
            {
                type = AccountType.Other;
                strType = "Other";
            }
                

            if (name != "" && password != "" && job != "")
            {
                if (!userManager.UserExists(name))
                {
                    if (userManager.AddUser(name, type, password, job))
                    {
                        userNameTextBox.ResetText();
                        jobTitleTextBox.ResetText();
                        passwordTextBox.ResetText();
                        newUserPanel.Visible = false;
                        userErrorChip.Visible = false;

                        profileNameLabel.Text = $"Name: {name}";
                        profileTypeLabel.Text = $"Type: {strType}";
                        profileJobTitleLabel.Text = $"Job Title: {job}";
                    }
                    else
                    {
                        userErrorChip.Visible = true;
                        userErrorChip.Text = "An error as occured when inserting data to the database. Make sure all the required data is correct.";
                    }
                }
                else
                {
                    userErrorChip.Visible = true;
                    userErrorChip.Text = "An account already exists with the same user name";
                }
            }
            else
            {
                userErrorChip.Visible = true;
                userErrorChip.Text = "There are missing values that are required to continue. Fill them and try again";
            }
        }

        private void editProfileButton_Click(object sender, EventArgs e)
        {
            if (!profileNameTextBox.Visible)
            {
                profileNameTextBox.Visible = true;
                profileJobTitleTextBox.Visible = true;
                profileAdminRadioButton.Visible = true;
                profileAccountantRadioButton.Visible = true;
                profileOtherRadioButton.Visible = true;
                profileNameLabel.Text = "Name: ";
                profileTypeLabel.Text = "Type: ";
                profileJobTitleLabel.Text = "Job Title: ";
                editProfileButton.Text = "Submit";
            }
            else
            {
                profileNameTextBox.Visible = false;
                profileJobTitleTextBox.Visible = false;
                profileAdminRadioButton.Visible = false;
                profileAccountantRadioButton.Visible = false;
                profileOtherRadioButton.Visible = false;
                profileNameLabel.Text = $"Name: ";
                profileTypeLabel.Text = $"Type: ";
                profileJobTitleLabel.Text = $"Job Title: ";
                editProfileButton.Text = "Edit Profile";
            }
            
        }

        #endregion 

        #region EmployeeTab

        private void closeEmployeePanel_Click(object sender, EventArgs e)
        {
            newEmployeePanel.Visible = false;
        }

        private void addEmployeeButton_Click(object sender, EventArgs e)
        {
            newEmployeePanel.Visible = true;
        }
        #endregion
    }
}
