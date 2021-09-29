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

                    employee.SetName(newName);
                    employee.SetSalary(newSalary);
                    employee.SetJob(newJob);
                    employee.SetPhone(newPhone);
                    employee.SetEmail(newEmail);
                    employee.SetSalaryDueDate(newSalaryDueDate);
                    employee.SetStatus(newStatus);

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

        public decimal GetNetTotal()
        {
            return this.Salary - (this.Salary * 0.35m) - (this.Salary * 0.3m);
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


    }
}
