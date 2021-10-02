using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Windows.Forms;

namespace Linkup_Finance.Managers
{
    public enum AccountType { Admin, Accountant, Other }
    public enum EmployeeStatus { Active, Inactive }

    public class UserManager
    {
        private List<User> usersList;
        private List<Employee> employeesList;

        public UserManager()
        {
            usersList = new List<User>();
            employeesList = new List<Employee>();
        }

        public bool UserExists(string name)
        {
            foreach (User user in usersList)
                if (user.GetName() == name)
                    return true;

            return false;
        }

        public void RetrieveUsers(string name, AccountType type, string password, string job)
        {
            User user = new User(name, type, password, job);
            usersList.Add(user);
        }

        public bool AddUser(string name, AccountType type, string password, string job)
        {
            User user = new User(name, type, password, job);
            usersList.Add(user);

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Linkup_Finance.Properties.Settings.LinkupDBConfig"].ConnectionString))
            {
                try
                {
                    string accType;
                    string insertQuery = "INSERT INTO Users(Name, Type, Password, JobTitle)" +
                                        " VALUES(@Name, @Type, @Password, @JobTitle)";
                    SqlCommand command = new SqlCommand(insertQuery, con);
                    con.Open();

                    if (type == AccountType.Admin)
                        accType = "Admin";
                    else if (type == AccountType.Accountant)
                        accType = "Accountant";
                    else
                        accType = "Other";

                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Type", accType);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@JobTitle", job);
                    command.ExecuteNonQuery();

                    return true;
                }
                catch
                {
                    return false;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public bool RemoveUser(User user)
        {
            usersList.Remove(user);

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Linkup_Finance.Properties.Settings.LinkupDBConfig"].ConnectionString))
            {
                try
                {
                    string deleteQuery = "DELETE FROM Users" +
                                        " WHERE Name=@Name";
                    SqlCommand command = new SqlCommand(deleteQuery, con);

                    con.Open();

                    command.Parameters.AddWithValue("@Name", user.GetName());
                    command.ExecuteNonQuery();

                    return true;
                }
                catch
                {
                    return false;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public User GetUser(string name)
        {
            foreach (User user in usersList)
                if (user.GetName().ToLower() == name.ToLower())
                    return user;

            return null;
        }

        public bool EditUser(User user, string newName, string newJob, string newPassword, AccountType newType)
        {
            string oldName = user.GetName();
            string type;

            if (newType == AccountType.Admin)
                type = "Admin";
            else if (newType == AccountType.Accountant)
                type = "Accountant";
            else
                type = "Other";

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Linkup_Finance.Properties.Settings.LinkupDBConfig"].ConnectionString))
            {
                try
                {
                    string updateQuery = "UPDATE Users " +
                                        "SET Name=@Name, " +
                                            "Type=@Type, " +
                                            "Password=@Password, " +
                                            "JobTitle=@JobTitle " +
                                        "WHERE Name=@OldName";
                    SqlCommand command = new SqlCommand(updateQuery, con);
                    con.Open();
                    command.Parameters.AddWithValue("@Name", newName);
                    command.Parameters.AddWithValue("@Type", type);
                    command.Parameters.AddWithValue("@Password", newPassword);
                    command.Parameters.AddWithValue("@JobTitle", newJob);
                    command.Parameters.AddWithValue("@OldName", oldName);
                    command.ExecuteNonQuery();

                    user.SetName(newName);
                    user.SetType(newType);
                    user.SetPassword(newPassword);
                    user.SetJob(newJob);

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public void LogUser(string name)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Linkup_Finance.Properties.Settings.LinkupDBConfig"].ConnectionString))
            {
                try
                {
                    string insertQuery = "INSERT INTO UserLog(Name, DateTime) " +
                                         "VALUES(@Name, @DateTime)";
                    SqlCommand command = new SqlCommand(insertQuery, con);
                    con.Open();

                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@DateTime", DateTime.Now);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error has occured: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public bool AddEmployee(string name, decimal salary, string job, string phone, string email, DateTime entryDateTime, DateTime salaryDueDate, EmployeeStatus status)
        {
            string empStatus;
            Employee employee = new Employee(name, salary, job, phone, email, entryDateTime, salaryDueDate, status);
            employeesList.Add(employee);

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Linkup_Finance.Properties.Settings.LinkupDBConfig"].ConnectionString))
            {
                try
                {
                    string insertQuery = "INSERT INTO Employees(Name, Salary, Job, Phone, Email, EntryDate, SalaryDue, Status)" +
                                        " VALUES(@Name, @Salary, @Job, @Phone, @Email, @EntryDate, @SalaryDue, @Status)";
                    SqlCommand command = new SqlCommand(insertQuery, con);
                    con.Open();

                    if (status == EmployeeStatus.Active)
                        empStatus = "Active";
                    else
                        empStatus = "Inactive";

                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Salary", salary);
                    command.Parameters.AddWithValue("@Job", job);
                    command.Parameters.AddWithValue("@Phone", phone);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@EntryDate", entryDateTime);
                    command.Parameters.AddWithValue("@SalaryDue", salaryDueDate);
                    command.Parameters.AddWithValue("@Status", empStatus);
                    command.ExecuteNonQuery();

                    return true;
                }
                catch
                {
                    return false;
                }
                finally
                {
                    con.Close();
                }
            }

        }

        public bool EmployeeExists(string name)
        {
            foreach (Employee employee in employeesList)
                if (employee.GetName().ToLower() == name.ToLower())
                    return true;

            return false;
        }

        public bool RemoveEmployee(Employee employee)
        {
            employeesList.Remove(employee);

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Linkup_Finance.Properties.Settings.LinkupDBConfig"].ConnectionString))
            {
                try
                {
                    string deleteQuery = "DELETE FROM Employees" +
                                        " WHERE Name = @Name and EntryDate = @EntryDate";
                    SqlCommand command = new SqlCommand(deleteQuery, con);

                    con.Open();

                    command.Parameters.AddWithValue("@Name", employee.GetName());
                    command.Parameters.AddWithValue("@EntryDate", employee.GetEntryDate());
                    command.ExecuteNonQuery();

                    return true;
                }
                catch
                {
                    return false;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public void RetrieveEmployees(string name, decimal salary, string job, string phone, string email, DateTime entryDateTime, DateTime salaryDueDate, EmployeeStatus status)
        {
            Employee employee = new Employee(name, salary, job, phone, email, entryDateTime, salaryDueDate, status);
            employeesList.Add(employee);
        }

        public Employee GetEmployee(string name)
        {
            foreach (Employee employee in employeesList)
                if (employee.GetName().ToLower() == name.ToLower())
                    return employee;

            return null;
        }

        public int GetEmployeeCount()
        {
            return this.employeesList.Count;
        }

        public int GetEmployeeCount(DataTable dataTable)
        {
            return dataTable.Rows.Count;
        }

        public int GetPaidEmployeeCount()
        {
            int paidEmployee = 0;

            foreach (Employee employee in employeesList)
                if (employee.GetIsPaid())
                    paidEmployee++;

            return paidEmployee;
        }

        public int GetPaidEmployeeCount(DataTable dataTable)
        {
            int paidEmployee = 0;

            for(int i = 0; i < dataTable.Rows.Count; i++)
            {
                DateTime salaryDue = (DateTime)dataTable.Rows[i].ItemArray[7];

                if (DateTime.Compare(salaryDue.Subtract(TimeSpan.FromDays(7)), DateTime.Now) >= 0)
                    paidEmployee++;
            }

            return paidEmployee;
        }

        public bool EditEmployee(Employee employee, string newName, decimal newSalary, string newJob, string newPhone, string newEmail, DateTime newEntryDateTime, DateTime newSalaryDueDate, EmployeeStatus newStatus)
        {
            string oldName = employee.GetName();
            string status = (newStatus == EmployeeStatus.Active) ? "Active" : "Inactive";
            DateTime entryDate = employee.GetEntryDate();

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Linkup_Finance.Properties.Settings.LinkupDBConfig"].ConnectionString))
            {
                try
                {
                    string updateQuery = "UPDATE Employees " +
                                     "SET Name = @Name, " +
                                         "Salary = @Salary, " +
                                         "Job = @Job, " +
                                         "Phone = @Phone, " +
                                         "Email = @Email, " +
                                         "SalaryDue = @SalaryDue, " +
                                         "Status = @Status " +
                                     "WHERE Name = @OldName and " +
                                           "EntryDate = @EntryDate";
                    string updateEmployeeLogQuery = "UPDATE EmployeeLogs " +
                                                    "SET Name=@Name " +
                                                    "WHERE Name=@OldName"; 
                    SqlCommand command = new SqlCommand(updateQuery, con);
                    con.Open();
                    command.Parameters.AddWithValue("@Name", newName);
                    command.Parameters.AddWithValue("@Salary", newSalary);
                    command.Parameters.AddWithValue("@Job", newJob);
                    command.Parameters.AddWithValue("@Phone", newPhone);
                    command.Parameters.AddWithValue("@Email", newEmail);
                    command.Parameters.AddWithValue("@SalaryDue", newSalaryDueDate);
                    command.Parameters.AddWithValue("@Status", status);
                    command.Parameters.AddWithValue("@OldName", oldName);
                    command.Parameters.AddWithValue("@EntryDate", entryDate);

                    command.ExecuteNonQuery();

                    command = new SqlCommand(updateEmployeeLogQuery, con);
                    command.Parameters.AddWithValue("@Name", newName);
                    command.Parameters.AddWithValue("@OldName", oldName);

                    command.ExecuteNonQuery();

                    employee.SetName(newName);
                    employee.SetSalary(newSalary);
                    employee.SetJob(newJob);
                    employee.SetPhone(newPhone);
                    employee.SetEmail(newEmail);
                    employee.SetSalaryDueDate(newSalaryDueDate);
                    employee.SetStatus(newStatus);

                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;
                    //return false;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public decimal GetTotalBonus(DataTable dataTable)
        {
            decimal total = 0m;

            for(int i = 0; i < dataTable.Rows.Count; i++)
                total += (decimal)dataTable.Rows[i].ItemArray[3];

            return total;
        }

        public decimal GetTotalIncomeTax(DataTable dataTable)
        {
            decimal total = 0m;

            for (int i = 0; i < dataTable.Rows.Count; i++)
                total += (decimal)dataTable.Rows[i].ItemArray[4];

            return total;
        }

        public decimal GetTotalNet(DataTable dataTable)
        {
            decimal total = 0m;

            for (int i = 0; i < dataTable.Rows.Count; i++)
                total += (decimal)dataTable.Rows[i].ItemArray[5];

            return total;
        }

        public decimal GetTotalPension(DataTable dataTable)
        {
            decimal total = 0m;

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                total += (decimal)dataTable.Rows[i].ItemArray[7];
                total += (decimal)dataTable.Rows[i].ItemArray[8];
            }

            return total;
        }
    }

    public class User
    {
        private string Name { get; set; }
        private AccountType Type { get; set; }
        private string Password { get; set; }
        private string Job { get; set; }

        public User(string name, AccountType type, string password, string job)
        {
            this.Name = name;
            this.Type = type;
            this.Password = password;
            this.Job = job;
        }

        public string GetName()
        {
            return this.Name;
        }

        public string GetPassword()
        {
            return this.Password;
        }

        public string GetJob()
        {
            return this.Job;
        }

        public AccountType GetAccountType()
        {
            return this.Type;
        }

        public void SetName(string name)
        {
            this.Name = name;
        }

        public void SetPassword(string newPassword)
        {
            this.Password = newPassword;
        }

        public void SetType(AccountType newType)
        {
            this.Type = newType;
        }

        public void SetJob(string newJob)
        {
            this.Job = newJob;
        }
    }

    public class Employee
    {
        private string Name { get; set; }
        private EmployeeStatus Status { get; set; }
        private string Job { get; set; }
        private string Phone { get; set; }
        private string Email { get; set; }
        private DateTime EntryDate { get; set; }
        private DateTime SalaryDue { get; set; }
        private decimal Salary { get; set; }
        private bool IsPaid { get; set; }

        public Employee(string name, decimal salary, string job, string phone, string email, DateTime entryDateTime, DateTime salaryDueDate, EmployeeStatus status)
        {
            this.Name = name;
            this.Salary = salary;
            this.Job = job;
            this.Phone = phone;
            this.Email = email;
            this.EntryDate = entryDateTime;
            this.SalaryDue = salaryDueDate;
            this.Status = status;

            if (DateTime.Compare(this.SalaryDue.Subtract(TimeSpan.FromDays(7)), DateTime.Now) >= 0)
                this.IsPaid = true;
            else
                this.IsPaid = false;
        }

        public string GetName()
        {
            return this.Name;
        }

        public string GetJob()
        {
            return this.Job;
        }

        public decimal GetSalary()
        {
            return this.Salary;
        }

        public string GetPhone()
        {
            return this.Phone;
        }

        public EmployeeStatus GetStatus()
        {
            return this.Status;
        }

        public string GetEmail()
        {
            return this.Email;
        }

        public DateTime GetEntryDate()
        {
            return this.EntryDate;
        }

        public DateTime GetSalaryDueDate()
        {
            return this.SalaryDue;
        }

        public decimal GetNetTotal(decimal bonus)
        {
            decimal incomeRate;
            decimal deductible;
            decimal salary = this.Salary + bonus;
            decimal net;

            if (this.Salary >= 0.00m && this.Salary <= 600.00m)
            {
                incomeRate = 0m;
                deductible = 0m;
            }
            else if (this.Salary >= 601.00m && this.Salary <= 1650.00m)
            {
                incomeRate = 0.1m;
                deductible = 60.00m;
            }
            else if (this.Salary >= 1651.00m && this.Salary <= 3200.00m)
            {
                incomeRate = 0.15m;
                deductible = 142.50m;
            }
            else if (this.Salary >= 3201.00m && this.Salary <= 5250.00m)
            {
                incomeRate = 0.2m;
                deductible = 302.5m;
            }
            else if (this.Salary >= 5251.00m && this.Salary <= 7800.00m)
            {
                incomeRate = 0.25m;
                deductible = 565.00m;
            }
            else if (this.Salary >= 7801.00m && this.Salary <= 10900.00m)
            {
                incomeRate = 0.3m;
                deductible = 955.00m;
            }
            else
            {
                incomeRate = 0.35m;
                deductible = 1500.00m;
            }

            net = salary - (salary * incomeRate) + deductible;

            return net;
        }

        public bool GetIsPaid()
        {
            return IsPaid;
        }

        public void SetName(string newName)
        {
            this.Name = newName;
        }

        public void SetJob(string newJob)
        {
            this.Job = newJob;
        }

        public void SetSalary(decimal newSalary)
        {
            this.Salary = newSalary;
        }

        public void SetPhone(string newPhone)
        {
            this.Phone = newPhone;
        }

        public void SetStatus(EmployeeStatus newStatus)
        {
            this.Status = newStatus;
        }

        public void SetEmail(string newEmail)
        {
            this.Email = newEmail;
        }

        public void SetSalaryDueDate(DateTime newDate)
        {
            this.SalaryDue = newDate;
        }

        public bool Pay(decimal bonus)
        {
            decimal incomeRate;
            decimal deductible;
            decimal salary = this.Salary + bonus;
            decimal pension7 = this.Salary * 0.07m;
            decimal pension11 = this.Salary * 0.11m;
            decimal tax, net;
            DateTime oldDate = this.SalaryDue;

            if (this.Salary >= 0.00m && this.Salary <= 600.00m)
            {
                incomeRate = 0m;
                deductible = 0m;
            }
            else if (this.Salary >= 601.00m && this.Salary <= 1650.00m)
            {
                incomeRate = 0.1m;
                deductible = 60.00m;
            }
            else if(this.Salary >= 1651.00m && this.Salary <= 3200.00m)
            {
                incomeRate = 0.15m;
                deductible = 142.50m;
            }
            else if(this.Salary >= 3201.00m && this.Salary <= 5250.00m)
            {
                incomeRate = 0.2m;
                deductible = 302.5m;
            }
            else if (this.Salary >= 5251.00m && this.Salary <= 7800.00m)
            {
                incomeRate = 0.25m;
                deductible = 565.00m;
            }
            else if (this.Salary >= 7801.00m && this.Salary <= 10900.00m)
            {
                incomeRate = 0.3m;
                deductible = 955.00m;
            }
            else
            {
                incomeRate = 0.35m;
                deductible = 1500.00m;
            }

            net = salary - (salary * incomeRate) + deductible;
            tax = salary * incomeRate;
            this.IsPaid = true;
            this.SalaryDue = oldDate.AddDays(30);

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Linkup_Finance.Properties.Settings.LinkupDBConfig"].ConnectionString))
            {
                try
                {
                    string insertQuery = "INSERT INTO EmployeeLogs(Name, Salary, Bonus, Pension7, Pension11, Tax, Net, Date) " +
                                         "VALUES(@Name, @Salary, @Bonus, @Pension7, @Pension11, @Tax, @Net, @Date)";
                    string updateQuery = "UPDATE Employees " +
                                         "SET SalaryDue=@SalaryDue " +
                                         "WHERE Name=@Name and EntryDate=@EntryDate";

                    SqlCommand command = new SqlCommand(insertQuery, con);
                    con.Open();

                    command.Parameters.AddWithValue("@Name", this.Name);
                    command.Parameters.AddWithValue("@Salary", this.Salary);
                    command.Parameters.AddWithValue("@Bonus", bonus);
                    command.Parameters.AddWithValue("@Pension7", pension7);
                    command.Parameters.AddWithValue("@Pension11", pension11);
                    command.Parameters.AddWithValue("@Tax", tax);
                    command.Parameters.AddWithValue("@Net", net);
                    command.Parameters.AddWithValue("@Date", DateTime.Now);

                    command.ExecuteNonQuery();

                    command = new SqlCommand(updateQuery, con);

                    command.Parameters.AddWithValue("@SalaryDue", this.SalaryDue);
                    command.Parameters.AddWithValue("@Name", this.Name);
                    command.Parameters.AddWithValue("@EntryDate", this.EntryDate);

                    command.ExecuteNonQuery();

                    return true;
                }
                catch (Exception)
                {
                    this.IsPaid = false;
                    this.SalaryDue = oldDate;
                    return false;
                }
                finally
                {
                    con.Close();
                }
            }
        }
    }
}
