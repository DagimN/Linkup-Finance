using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.IO.Path;
using static System.IO.Directory;
using static System.Environment;
using System.Windows.Forms;
using Linkup_Finance.Managers;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Tables;

namespace Linkup_Finance.Forms
{
    public partial class SettingsForm : Form
    {
        public UserManager userManager;
        private DashboardForm dashboardForm;
        private ProjectForm projectForm;
        private AccountType loggedInAccountType;
        private string loggedInUserName;
        public SettingsForm()
        {
            InitializeComponent();
            userManager = new UserManager();

            salaryDueDateSelection.Value = DateTime.Now.AddDays(30);
            locationLabel.Text = Combine(GetFolderPath(SpecialFolder.MyDocuments), "Linkup Finance Attachements", "Export Data");
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            this.employeeLogsTableAdapter.Fill(this.linkupDatabaseDataSet.EmployeeLogs);
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
            }

            if (usersComboBox.Items.Count > 0)
                usersComboBox.Text = usersComboBox.Items[0].ToString();

            if(loggedInUserName != null && loggedInUserName != "Admin" && loggedInAccountType != AccountType.Other)
            {
                User user = userManager.GetUser(loggedInUserName);
                string type;

                if (user.GetAccountType() == AccountType.Admin)
                    type = "Administrator";
                else if (user.GetAccountType() == AccountType.Accountant)
                    type = "Accountant";
                else
                    type = "Other";

                userPictureBox.Tag = user;
                profileNameLabel.Text = $"Name: {user.GetName()}";
                profileJobTitleLabel.Text = $"Job Title: {user.GetJob()}";
                profileTypeLabel.Text = $"Type: {type}";
            }
                
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

            dashboardForm.RefreshDashboard();

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

                string total = employee.GetNetTotal(0.00m).ToString();
                netSalaryTotalLabel.Text = $"Net Total: {total.Substring(0, total.IndexOf('.') + 3)} ETB";

                RemoveItems(employeePayrollDataGridView, employeesComboBox.Text);
            }

            dataComboBox.Text = "Balance Sheet";
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
                BackColor = Color.Transparent,
                FillColor = Color.FromArgb(210, 65, 60)
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

                        User user = userManager.GetUser(name);
                        profileNameLabel.Text = $"Name: {user.GetName()}";
                        profileTypeLabel.Text = $"Type: {strType}";
                        profileJobTitleLabel.Text = $"Job Title: {user.GetJob()}";
                        userPictureBox.Tag = user;

                        usersComboBox.Items.Add(user.GetName());
                        usersComboBox.Text = user.GetName();
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
            User user = (User)userPictureBox.Tag;

            if (!profileNameTextBox.Visible)
            {
                if (user != null)
                {
                    profileNameTextBox.Visible = true;
                    profileJobTitleTextBox.Visible = true;
                    profileAdminRadioButton.Visible = true;
                    profileAccountantRadioButton.Visible = true;
                    profileOtherRadioButton.Visible = true;
                    profilePasswordTextBox.Visible = true;
                    profilePasswordLabel.Visible = true;
                    profileNameLabel.Text = "Name: ";
                    profileTypeLabel.Text = "Type: ";
                    profileJobTitleLabel.Text = "Job Title: ";
                    profileNameTextBox.Text = user.GetName();
                    profileJobTitleTextBox.Text = user.GetJob();
                    profilePasswordTextBox.Text = user.GetPassword();

                    if (user.GetAccountType() == AccountType.Admin)
                        profileAdminRadioButton.Checked = true;
                    else if (user.GetAccountType() == AccountType.Accountant)
                        profileAccountantRadioButton.Checked = true;
                    else
                        profileOtherRadioButton.Checked = true;

                    editProfileButton.Text = "Submit";
                }
            }
            else
            {
                string oldName = user.GetName();
                string newName = profileNameTextBox.Text;
                string newJob = profileJobTitleTextBox.Text;
                string newPassword = profilePasswordTextBox.Text;
                AccountType newType;

                if (profileAdminRadioButton.Checked)
                    newType = AccountType.Admin;
                else if (profileAccountantRadioButton.Checked)
                    newType = AccountType.Accountant;
                else
                    newType = AccountType.Other;

                if (userManager.EditUser(user, newName, newJob, newPassword, newType))
                {
                    profileJobTitleTextBox.Visible = false;
                    profilePasswordTextBox.Visible = false;
                    profilePasswordLabel.Visible = false;
                    profileNameTextBox.Visible = false;
                    profileJobTitleTextBox.Visible = false;
                    profileAdminRadioButton.Visible = false;
                    profileAccountantRadioButton.Visible = false;
                    profileOtherRadioButton.Visible = false;
                    profileNameLabel.Text = $"Name: {user.GetName()}";
                    profileJobTitleLabel.Text = $"Job Title: {user.GetJob()}";
                    editProfileButton.Text = "Edit Profile";

                    if (user.GetAccountType() == AccountType.Admin)
                        profileTypeLabel.Text = "Type: Administrator";
                    else if (user.GetAccountType() == AccountType.Accountant)
                        profileTypeLabel.Text = "Type: Accountant";
                    else
                        profileTypeLabel.Text = "Type: Other";

                    usersComboBox.Items.Remove(oldName);
                    usersComboBox.Items.Add(newName);
                    usersComboBox.Text = newName;
                    editEmployeeButton.Text = "Edit";
                    userPictureBox.Tag = user;
                }
            }
        }

        private void removeUserButton_Click(object sender, EventArgs e)
        {
            User user = (User)usersComboBox.Tag;

            userManager.RemoveUser(user);
            usersComboBox.Items.Remove(user.GetName());

            if (usersComboBox.Items.Count > 0)
                usersComboBox.Text = usersComboBox.Items[0].ToString();
            else
            {
                usersComboBox.Tag = null;

                otherUserNameLabel.Text = "Name: ";
                otherUserJobTitleLabel.Text = "Job Title: ";
                otherUserTypeLabel.Text = "Type: ";
            }
        }

        private void usersComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            string name = usersComboBox.Text;
            User user = userManager.GetUser(name);
            string type;

            if (user.GetAccountType() == AccountType.Admin)
                type = "Administrator";
            else if (user.GetAccountType() == AccountType.Accountant)
                type = "Accountant";
            else
                type = "Other";

            usersComboBox.Tag = user;
            otherUserNameLabel.Text = $"Name: {user.GetName()}";
            otherUserJobTitleLabel.Text = $"Job Title: {user.GetJob()}";
            otherUserTypeLabel.Text = $"Type: {type}";
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
                BackColor = Color.Transparent,
                FillColor = Color.FromArgb(210, 65, 60)
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

                            string total = employee.GetNetTotal(0.00m).ToString();
                            netSalaryTotalLabel.Text = $"Net Total: {total.Substring(0, total.IndexOf('.') + 3)} ETB";

                            RemoveItems(employeePayrollDataGridView, employee.GetName());

                            dashboardForm.RefreshDashboard();
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
                if(employee != null)
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
            }
            else
            {
                string oldName = employee.GetName();
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

                        employeesComboBox.Items.Remove(oldName);
                        employeesComboBox.Items.Add(employee.GetName());
                        employeesComboBox.Text = employee.GetName(); 

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
                payEmployeeButton.Enabled = false;
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

            string total = employee.GetNetTotal(0.00m).ToString();
            netSalaryTotalLabel.Text = $"Net Total: {total.Substring(0, total.IndexOf('.') + 3)} ETB";

            employeeLogsTableAdapter.Fill(this.linkupDatabaseDataSet.EmployeeLogs);
            RemoveItems(employeePayrollDataGridView, employee.GetName());
        }

        private void removeEmployeeButton_Click(object sender, EventArgs e)
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
                else
                    salaryDueDateSelection.Value = oldDate;
            }
        }

        private void payEmployeeButton_Click(object sender, EventArgs e)
        {
            Employee employee = (Employee)employeesComboBox.Tag;
            string bonusText = bonusTextBox.Text;
            decimal bonus;
            bool isValid;

            if(bonusText == "")
            {
                bonus = 0.00m;
                isValid = true;
            }
            else
                isValid = decimal.TryParse(bonusText, out bonus);

            if (isValid)
            {
                if (employee.Pay(bonus))
                {
                    employeeLogsTableAdapter.Fill(this.linkupDatabaseDataSet.EmployeeLogs);
                    dashboardForm.RefreshDashboard();
                    dashboardForm.LoadChart(employeeLogsTableAdapter.GetData());
                    RemoveItems(employeePayrollDataGridView, employee.GetName());
                    salaryDueDateSelection.Value = DateTime.Now.AddDays(30);
                }
                else
                {
                    //TODO: Report Database Error
                }
            }
            else
            {
                //TODO: Report decimal Error
            }   
        }

        private void bonusTextBox_TextChanged(object sender, EventArgs e)
        {
            Employee employee = (Employee)employeesComboBox.Tag;
            string bonusText = bonusTextBox.Text;
            decimal bonus;
            bool isValid = decimal.TryParse(bonusText, out bonus);

            if (isValid)
                netSalaryTotalLabel.Text = $"Net Total: {employee.GetNetTotal(bonus)}";
            else
            {
                if (bonusText != "")
                    netSalaryTotalLabel.Text = "Invalid Bonus Value";
                else
                    netSalaryTotalLabel.Text = $"Net Total: {employee.GetNetTotal(0m)}";
            }
        }

        #endregion

        #region MiscTab

        private void exportPDFButton_Click(object sender, EventArgs e)
        {
            PdfDocument doc = new PdfDocument();
            PdfSection sec = doc.Sections.Add();
            PdfUnitConvertor unitCvtr = new PdfUnitConvertor();
            PdfMargins margin = new PdfMargins();
            PdfBrush brush = PdfBrushes.Black;
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 16f, FontStyle.Bold));
            PdfStringFormat format = new PdfStringFormat(PdfTextAlignment.Center);
            PdfPageBase page = sec.Pages.Add();
            PdfTable table = new PdfTable();
            string[][] dataSource;
            string pdfLocation;
            float y = 20;

            margin.Top = unitCvtr.ConvertUnits(2.54f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
            margin.Bottom = margin.Top;
            margin.Left = unitCvtr.ConvertUnits(3.17f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
            margin.Right = margin.Left;
            sec.PageSettings.Width = PdfPageSize.A4.Width;
            sec.PageSettings.Margins = margin;

            if (dataComboBox.Text == "Balance Sheet")
            {
                DataTable incomeDataTable, expenseDataTable, employeeLogsDataTable;
                
                projectForm.incomeTableAdapter.Fill(projectForm.linkupDatabaseDataSet.Income);
                projectForm.expenseTableAdapter.Fill(projectForm.linkupDatabaseDataSet.Expense);
                employeeLogsTableAdapter.Fill(linkupDatabaseDataSet.EmployeeLogs);

                incomeDataTable = projectForm.incomeTableAdapter.GetData();
                expenseDataTable = projectForm.expenseTableAdapter.GetData();
                employeeLogsDataTable = employeeLogsTableAdapter.GetData();

                pdfLocation = Combine(GetFolderPath(SpecialFolder.MyDocuments), "Linkup Finance Attachements", "Export Data", "Balance Sheet.pdf");

                page.Canvas.DrawString("Balance Sheet", font, brush, page.Canvas.ClientSize.Width / 2, y, format);
                y += font.MeasureString("Balance Sheet", format).Height + 5;

                int i = 1;
                decimal total = 0m;
                string[] header = { "Date", "Description", "Bank", "Type" ,"Payer", "Amount" };
                dataSource = new string[incomeDataTable.Rows.Count + expenseDataTable.Rows.Count + employeeLogsDataTable.Rows.Count + 2][];

                dataSource[0] = header;
                foreach (string[] item in SortData(ExportDataSource(incomeDataTable, expenseDataTable, employeeLogsDataTable)))
                {
                    dataSource[i++] = item;
                    if(item[3] == "Income")
                        total += decimal.Parse(item[5]);
                    else
                        total -= decimal.Parse(item[5]);
                }

                string[] finalItem = { " ", " ", " ", " ","Total", total.ToString() };
                dataSource[i] = finalItem;
            }
            else if (dataComboBox.Text == "Income Sheet")
            {
                DataTable incomeDataTable;
                projectForm.incomeTableAdapter.Fill(projectForm.linkupDatabaseDataSet.Income);

                incomeDataTable = projectForm.incomeTableAdapter.GetData();

                pdfLocation = Combine(GetFolderPath(SpecialFolder.MyDocuments), "Linkup Finance Attachements", "Export Data", "Income Sheet.pdf");

                page.Canvas.DrawString("Income Sheet", font, brush, page.Canvas.ClientSize.Width / 2, y, format);
                y += font.MeasureString("Income Sheet", format).Height + 5;

                int i = 1;
                decimal total = 0m;
                string[] header = { "Date", "Description", "Bank", "Payer", "Amount" };
                dataSource = new string[incomeDataTable.Rows.Count + 2][];

                dataSource[0] = header;
                foreach (string[] item in SortData(ExportDataSource(incomeDataTable)))
                {
                    dataSource[i++] = item;
                    total += decimal.Parse(item[4]);
                }

                string[] finalItem = { " ", " ", " ", "Total", total.ToString() };
                dataSource[i] = finalItem;
            }
            else
            {
                DataTable expenseDataTable, employeeLogsDataTable;

                projectForm.expenseTableAdapter.Fill(projectForm.linkupDatabaseDataSet.Expense);
                employeeLogsTableAdapter.Fill(linkupDatabaseDataSet.EmployeeLogs);

                expenseDataTable = projectForm.expenseTableAdapter.GetData();
                employeeLogsDataTable = employeeLogsTableAdapter.GetData();

                pdfLocation = Combine(GetFolderPath(SpecialFolder.MyDocuments), "Linkup Finance Attachements", "Export Data", "Expense Sheet.pdf");

                page.Canvas.DrawString("Expense Sheet", font, brush, page.Canvas.ClientSize.Width / 2, y, format);
                y += font.MeasureString("Expense Sheet", format).Height + 5;

                int i = 1;
                decimal total = 0m;
                string[] header = { "Date", "Description", "Bank", "Payer", "Amount" };
                dataSource = new string[expenseDataTable.Rows.Count + employeeLogsDataTable.Rows.Count + 2][];

                dataSource[0] = header;
                foreach (string[] item in SortData(ExportDataSource(expenseDataTable, employeeLogsDataTable)))
                {
                    dataSource[i++] = item;
                    total += decimal.Parse(item[4]);
                }

                string[] finalItem = { " ", " ", " ", "Total", total.ToString() };
                dataSource[i] = finalItem;
            }
            
            table.Style.CellPadding = 2;
            table.Style.HeaderSource = PdfHeaderSource.Rows;
            table.Style.HeaderRowCount = 1;
            table.Style.ShowHeader = true;
            table.Style.HeaderStyle.BackgroundBrush = PdfBrushes.CadetBlue;
            table.Style.HeaderStyle.StringFormat = format;
            table.DataSource = dataSource;
            table.Draw(page, new PointF(0, y), new PdfTableLayoutFormat { Layout = PdfLayoutType.Paginate });
            doc.SaveToFile(pdfLocation);
            doc.Close();
            System.Diagnostics.Process.Start(pdfLocation);
        }

        private void exportXLSButton_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Custom Functions

        public void Link(DashboardForm dashboardForm)
        {
            this.dashboardForm = dashboardForm;
        }

        public void Link(ProjectForm projectForm)
        {
            this.projectForm = projectForm;
        }

        public void SetAccountType(string userName, AccountType type)
        {
            loggedInUserName = userName;
            loggedInAccountType = type;
        }

        private void RemoveItems(Guna.UI2.WinForms.Guna2DataGridView dataGridView, string name)
        {
            List<int> tobeRemovedList = new List<int>();
            int removed = 0;

            for (int i = 0; i < dataGridView.Rows.Count; i++)
                if (dataGridView.Rows[i].Cells[2].Value != null)
                    if (dataGridView.Rows[i].Cells[0].Value.ToString() != name)
                        tobeRemovedList.Add(i);

            foreach (int rowIndex in tobeRemovedList)
            {
                dataGridView.Rows.RemoveAt(rowIndex - removed);
                removed++;
            }
        }

        private string[][] ExportDataSource(params DataTable[] dataTables)
        {
            string[][] dataSource;
            int index = 0;

            if (dataTables.Length == 3)
            {
                dataSource = new string[dataTables[0].Rows.Count + dataTables[1].Rows.Count + dataTables[2].Rows.Count][];

                for(int j = 0; j < dataTables.Length; j++)
                {
                    if(j == 0)
                    {
                        for (int i = 0; i < dataTables[j].Rows.Count; i++)
                        {
                            string[] item = { dataTables[j].Rows[i].ItemArray[9].ToString().Substring(0, 9).Trim(),
                                  dataTables[j].Rows[i].ItemArray[2].ToString(),
                                  dataTables[j].Rows[i].ItemArray[3].ToString(),
                                  "Income",
                                  dataTables[j].Rows[i].ItemArray[1].ToString(),
                                  dataTables[j].Rows[i].ItemArray[5].ToString() };
                           
                            dataSource[i] = item;
                            index++;
                        }
                    }

                    if(j == 1)
                    {
                        int secIndex = index;
                        for (int i = 0; i < dataTables[j].Rows.Count; i++)
                        {
                            string[] item = { dataTables[j].Rows[i].ItemArray[8].ToString().Substring(0, 9).Trim(),
                                  dataTables[j].Rows[i].ItemArray[7].ToString(),
                                  dataTables[j].Rows[i].ItemArray[6].ToString(),
                                  "Expense",
                                  dataTables[j].Rows[i].ItemArray[13].ToString(),
                                  dataTables[j].Rows[i].ItemArray[2].ToString() };
                          
                            dataSource[secIndex + i] = item;
                            index++;
                        }
                    }

                    if(j == 2)
                    {
                        int thrIndex = index;
                        for (int i = 0; i < dataTables[j].Rows.Count; i++)
                        {
                            string[] item = { dataTables[j].Rows[i].ItemArray[6].ToString().Substring(0, 9).Trim(),
                                  "Employee Salary Payment",
                                  " ",
                                  "Expense",
                                  dataTables[j].Rows[i].ItemArray[1].ToString(),
                                  dataTables[j].Rows[i].ItemArray[5].ToString() };

                            dataSource[thrIndex + i] = item;
                            index++;
                        }
                    }
                }
            }
            else if(dataTables.Length == 2)
            {
                dataSource = new string[dataTables[0].Rows.Count + dataTables[1].Rows.Count][];

                for (int j = 0; j < dataTables.Length; j++)
                {
                    if (j == 0)
                    {
                        for (int i = 0; i < dataTables[j].Rows.Count; i++)
                        {
                            string[] item = { dataTables[j].Rows[i].ItemArray[8].ToString().Substring(0, 9).Trim(),
                                  dataTables[j].Rows[i].ItemArray[7].ToString(),
                                  dataTables[j].Rows[i].ItemArray[6].ToString(),
                                  dataTables[j].Rows[i].ItemArray[13].ToString(),
                                  dataTables[j].Rows[i].ItemArray[2].ToString() };
                            
                            dataSource[i] = item;
                            index++;
                        }
                    }

                    if (j == 1)
                    {
                        int secIndex = index;
                        for (int i = 0; i < dataTables[j].Rows.Count; i++)
                        {
                            string[] item = { dataTables[j].Rows[i].ItemArray[6].ToString().Substring(0, 9).Trim(),
                                  "Employee Salary Payment",
                                  " ",
                                  dataTables[j].Rows[i].ItemArray[1].ToString(),
                                  dataTables[j].Rows[i].ItemArray[5].ToString() };
                            
                            dataSource[i + secIndex] = item;
                            index++;
                        }
                    }
                }
            }
            else
            {
                dataSource = new string[dataTables[0].Rows.Count][];

                for (int i = 0; i < dataTables[0].Rows.Count; i++)
                {
                    string[] item = { dataTables[0].Rows[i].ItemArray[9].ToString().Substring(0, 9).Trim(),
                                  dataTables[0].Rows[i].ItemArray[2].ToString(),
                                  dataTables[0].Rows[i].ItemArray[3].ToString(),
                                  dataTables[0].Rows[i].ItemArray[1].ToString(),
                                  dataTables[0].Rows[i].ItemArray[5].ToString() };
                    
                    dataSource[i] = item;
                    index++;
                }
            }

            return dataSource;
        }

        private string[][] SortData(string[][] dataSource)
        {
            string[][] sortArray = new string[dataSource.Length][];
            
            for (int i = 0; i < dataSource.Length; i++)
            {
                sortArray[i] = dataSource[i];
                MessageBox.Show(dataSource[i][0]);
            }
               
            int inner, numElements = sortArray.Length;
            string[] temp;
            int h = 1;

            while (h <= numElements / 3)
                h = h * 3 + 1;
            while (h > 0)
            {
                for (int outer = h; outer <= numElements - 1; outer++)
                {
                    temp = sortArray[outer];
                    inner = outer;

                    while ((inner > h - 1) && DateTime.Compare(DateTime.Parse(sortArray[inner - h][0].ToString()), DateTime.Parse(temp[0].ToString())) == 1)
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


        #endregion
    }
}
