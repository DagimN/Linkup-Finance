﻿using System;
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
        private DashboardForm dashboardForm;
        public SettingsForm()
        {
            InitializeComponent();
            userManager = new UserManager();

            salaryDueDateSelection.Value = DateTime.Now.AddDays(30);
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'linkupDatabaseDataSet.EmployeeLogs' table. You can move, or remove it, as needed.
            this.employeeLogsTableAdapter.Fill(this.linkupDatabaseDataSet.EmployeeLogs);
            // TODO: This line of code loads data into the 'linkupDatabaseDataSet.UserLog' table. You can move, or remove it, as needed.
            this.userLogTableAdapter.Fill(this.linkupDatabaseDataSet.UserLog);
            usersTableAdapter.Fill(this.linkupDatabaseDataSet.Users);
            employeesTableAdapter.Fill(this.linkupDatabaseDataSet.Employees);

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

                //TODO: Load User Information for viewing
            }

            if (usersComboBox.Items.Count > 0)
                usersComboBox.Text = usersComboBox.Items[0].ToString();

            for(int i = 0; i < employeesTableAdapter.GetData().Rows.Count; i++)
            {
                string name = employeesTableAdapter.GetData().Rows[i].ItemArray[1].ToString();
                string job = employeesTableAdapter.GetData().Rows[i].ItemArray[3].ToString();
                decimal salary = (decimal)employeesTableAdapter.GetData().Rows[i].ItemArray[2];
                string phone = employeesTableAdapter.GetData().Rows[i].ItemArray[4].ToString();
                string email = employeesTableAdapter.GetData().Rows[i].ItemArray[5].ToString();
                DateTime entryDateTime = (DateTime)employeesTableAdapter.GetData().Rows[i].ItemArray[6];
                DateTime salaryDueDateTime = (DateTime)employeesTableAdapter.GetData().Rows[i].ItemArray[7];
                string strStatus = employeesTableAdapter.GetData().Rows[i].ItemArray[8].ToString();
                EmployeeStatus status;

                if (strStatus == "Active")
                    status = EmployeeStatus.Active;
                else
                    status = EmployeeStatus.Inactive;

                employeesComboBox.Items.Add(name);

                userManager.RetrieveEmployees(name, salary, job, phone, email, entryDateTime, salaryDueDateTime, status);
            }

            if (employeesComboBox.Items.Count > 0)
            {
                Employee employee = userManager.GetEmployee(employeesComboBox.Items[0].ToString());
                employeesComboBox.Text = employee.GetName();
                employeesComboBox.Tag = employee;

                nameLabel.Text = employee.GetName();
                employeeProfileJobLabel.Text = $"Job Title: {employee.GetJob()}";
                salaryLabel.Text = $"Salary: {employee.GetSalary()} ETB";
                emailLabel.Text = $"Email: {employee.GetEmail()}";
                phoneLabel.Text = $"Phone: {employee.GetPhone()}";

                if (employee.GetStatus() == EmployeeStatus.Active)
                    activeEmployeeRadioButton.Checked = true;
                else
                    inactiveEmployeeRadioButton.Checked = true;

                salaryDueDateSelection.Value = employee.GetSalaryDueDate();

                string total = employee.GetNetTotal().ToString();
                netSalaryTotalLabel.Text = $"Net Total: {total.Substring(0, total.IndexOf('.') + 3)} ETB";
            }

            dashboardForm.RefreshDashboard();
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

        private void submitEmployeeButton_Click(object sender, EventArgs e)
        {
            string name = employeeNameTextBox.Text;
            string job = employeeJobTitleTextBox.Text;
            string phone = employeePhoneTextBox.Text;
            string email = employeeEmailTextBox.Text;
            string strSalary = employeeSalaryTextBox.Text;
            EmployeeStatus status = EmployeeStatus.Inactive;
            decimal salary;
            DateTime salaryDueDate = DateTime.Now.AddDays(30), entryDateTime = DateTime.Now;
            bool isValid = decimal.TryParse(strSalary, out salary);

            newEmployeePanel.Controls.Remove(employeeErrorChip);
            employeeErrorChip = new Guna.UI2.WinForms.Guna2Chip
            {
                Size = new Size(365, 45),
                Location = new Point(224, 18),
                Text = "",
                Visible = false,
                BackColor = Color.Transparent
            };
            newEmployeePanel.Controls.Add(employeeErrorChip);
            employeeErrorChip.BringToFront();

            if (isValid)
            {
                if (name != "" && job != "")
                {
                    if (!userManager.EmployeeExists(name))
                    {
                        if (userManager.AddEmployee(name, salary, job, phone, email, entryDateTime, salaryDueDate, status))
                        {
                            employeeNameTextBox.ResetText();
                            employeeJobTitleTextBox.ResetText();
                            employeePhoneTextBox.ResetText();
                            employeeEmailTextBox.ResetText();
                            employeeSalaryTextBox.ResetText();
                            newEmployeePanel.Visible = false;
                            employeeErrorChip.Visible = false;

                            employeesComboBox.Items.Add(name);
                            Employee employee = userManager.GetEmployee(name);
                            employeesComboBox.Text = employee.GetName();
                            employeesComboBox.Tag = employee;

                            nameLabel.Text = employee.GetName();
                            employeeProfileJobLabel.Text = $"Job Title: {employee.GetJob()}";
                            salaryLabel.Text = $"Salary: {employee.GetSalary()} ETB";
                            emailLabel.Text = $"Email: {employee.GetEmail()}";
                            phoneLabel.Text = $"Phone: {employee.GetPhone()}";

                            if (employee.GetStatus() == EmployeeStatus.Active)
                                activeEmployeeRadioButton.Checked = true;
                            else
                                inactiveEmployeeRadioButton.Checked = true;

                            salaryDueDateSelection.Value = employee.GetSalaryDueDate();

                            string total = employee.GetNetTotal().ToString();
                            netSalaryTotalLabel.Text = $"Net Total: {total.Substring(0, total.IndexOf('.') + 3)} ETB";
                        }
                        else
                        {
                            employeeErrorChip.Visible = true;
                            employeeErrorChip.Text = "An error as occured when inserting data to the database. Make sure all the required data is correct.";
                        }
                    }
                    else
                    {
                        employeeErrorChip.Visible = true;
                        employeeErrorChip.Text = "An account already exists with the same user name";
                    }
                }
                else
                {
                    employeeErrorChip.Visible = true;
                    employeeErrorChip.Text = "There are missing values that are required to continue. Fill them and try again";
                }
            }
            else
            {
                employeeErrorChip.Visible = true;
                employeeErrorChip.Text = "The salary value is in an incorrect format. Try again.";
            }
        }

        private void editEmployeeButton_Click(object sender, EventArgs e)
        {
            Employee employee = (Employee)employeesComboBox.Tag;
            if (!employeeProfileJobTextBox.Visible)
            {
                employeeProfileJobTextBox.Visible = true;
                salaryTextBox.Visible = true;
                nameTextBox.Visible = true;
                emailTextBox.Visible = true;
                phoneTextBox.Visible = true;
                employeeProfileJobLabel.Text = "Job Title: ";
                salaryLabel.Text = "Salary: ";
                emailLabel.Text = "Email: ";
                phoneLabel.Text = "Phone: ";
                nameTextBox.Text = employee.GetName();
                employeeProfileJobTextBox.Text = employee.GetJob();
                salaryTextBox.Text = employee.GetSalary().ToString();
                emailTextBox.Text = employee.GetEmail();
                phoneTextBox.Text = employee.GetPhone();
                editEmployeeButton.Text = "Submit";
            }
            else
            {
                
                string newJob = employeeProfileJobTextBox.Text;
                string newName = nameTextBox.Text;
                string newEmail = emailTextBox.Text;
                string newPhone = phoneTextBox.Text;
                DateTime newDate = salaryDueDateSelection.Value;
                decimal newSalary;
                bool isValid = decimal.TryParse(salaryTextBox.Text, out newSalary);
                EmployeeStatus newStatus = (activeEmployeeRadioButton.Checked) ? EmployeeStatus.Active : EmployeeStatus.Inactive;

                if (isValid)
                {
                    if (userManager.EditEmployee(employee, newName, newSalary, newJob, newPhone, newEmail, employee.GetEntryDate(), newDate, newStatus))
                    {
                        employeeProfileJobTextBox.Visible = false;
                        salaryTextBox.Visible = false;
                        nameTextBox.Visible = false;
                        emailTextBox.Visible = false;
                        phoneTextBox.Visible = false;
                        nameLabel.Text = employee.GetName();
                        salaryLabel.Text = $"Salary: {employee.GetSalary()}";
                        employeeProfileJobLabel.Text = $"Job Title: {employee.GetJob()}";
                        emailLabel.Text = $"Email: {employee.GetEmail()}";
                        phoneLabel.Text = $"Phone: {employee.GetPhone()}";
                        if (newStatus == EmployeeStatus.Active)
                            activeEmployeeRadioButton.Checked = true;
                        else
                            inactiveEmployeeRadioButton.Checked = true;

                        editEmployeeButton.Text = "Edit";
                    }
                }
            }
        }

        private void activeEmployeeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            Employee employee = (Employee)employeesComboBox.Tag;

            if (activeEmployeeRadioButton.Checked)
            {
                userManager.EditEmployee(employee, employee.GetName(), employee.GetSalary(), employee.GetJob(), employee.GetPhone(), employee.GetEmail(), employee.GetEntryDate(), employee.GetSalaryDueDate(), EmployeeStatus.Active);
                statusPictureBox.Image = Linkup_Finance.Properties.Resources.Active_Image;
            }       
        }

        private void inactiveEmployeeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            Employee employee = (Employee)employeesComboBox.Tag;

            if (inactiveEmployeeRadioButton.Checked)
            {
                userManager.EditEmployee(employee, employee.GetName(), employee.GetSalary(), employee.GetJob(), employee.GetPhone(), employee.GetEmail(), employee.GetEntryDate(), employee.GetSalaryDueDate(), EmployeeStatus.Inactive);
                statusPictureBox.Image = Linkup_Finance.Properties.Resources.Inactive_Image;
            }
        }

        private void employeesComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            string name = employeesComboBox.Text;
            Employee employee = userManager.GetEmployee(name);

            employeesComboBox.Tag = employee;
            nameLabel.Text = employee.GetName();
            employeeProfileJobLabel.Text = $"Job Title: {employee.GetJob()}";
            salaryLabel.Text = $"Salary: {employee.GetSalary()} ETB";
            emailLabel.Text = $"Email: {employee.GetEmail()}";
            phoneLabel.Text = $"Phone: {employee.GetPhone()}";

            if (employee.GetStatus() == EmployeeStatus.Active)
                activeEmployeeRadioButton.Checked = true;
            else
                inactiveEmployeeRadioButton.Checked = true;

            salaryDueDateSelection.Value = employee.GetSalaryDueDate();

            string total = employee.GetNetTotal().ToString();
            netSalaryTotalLabel.Text = $"Net Total: {total.Substring(0, total.IndexOf('.') + 3)} ETB";
        }

        private void removeEmolyeeButton_Click(object sender, EventArgs e)
        {
            Employee employee = (Employee)employeesComboBox.Tag;

            userManager.RemoveEmployee(employee);
            employeesComboBox.Items.Remove(employee.GetName());

            if(employeesComboBox.Items.Count > 0)
                employeesComboBox.Text = employeesComboBox.Items[0].ToString();
            else
            {
                employeesComboBox.Tag = null;
                nameLabel.Text = "Employee Name";
                employeeProfileJobLabel.Text = "Job Title: ";
                salaryLabel.Text = "Salary: ";
                emailLabel.Text = "Email: ";
                phoneLabel.Text = "Phone: ";
                inactiveEmployeeRadioButton.Checked = true;
                salaryDueDateSelection.Value = DateTime.Now.AddDays(30);
                netSalaryTotalLabel.Text = "Net Total: ";
            }
        }

        private void salaryDueDateSelection_ValueChanged(object sender, EventArgs e)
        {
            Employee employee = (Employee)employeesComboBox.Tag;

            if (employee != null)
            {
                DateTime oldDate = employee.GetSalaryDueDate();
                DateTime newDate = salaryDueDateSelection.Value;

                if (DateTime.Compare(newDate, DateTime.Now) > 0)
                    if (!userManager.EditEmployee(employee, employee.GetName(), employee.GetSalary(), employee.GetJob(), employee.GetPhone(), employee.GetEmail(), employee.GetEntryDate(), newDate, employee.GetStatus()))
                        salaryDueDateSelection.Value = oldDate;
                    else
                        salaryDueDateSelection.Value = employee.GetSalaryDueDate();
            }
        }

        #endregion

        #region Custom Functions

        public void Link(DashboardForm dashboardForm)
        {
            this.dashboardForm = dashboardForm;
        }

        #endregion
    }
}
