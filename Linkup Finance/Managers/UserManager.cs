﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
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

        public bool RemoveUser(User user, int id)
        {
            usersList.Remove(user);

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Linkup_Finance.Properties.Settings.LinkupDBConfig"].ConnectionString))
            {
                try
                {
                    string deleteQuery = "DELETE FROM Users" +
                                        " WHERE Id = @Id";
                    SqlCommand command = new SqlCommand(deleteQuery, con);

                    con.Open();

                    command.Parameters.AddWithValue("@Id", id);
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

        public bool AddEmployee(string name, decimal salary, string job, string phone, string email, DateTime entryDateTime, DateTime salaryDueDate, EmployeeStatus status)
        {
            string empStatus;
            Employee employee = new Employee(name, salary, job, phone, email, entryDateTime, salaryDueDate);
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

        public bool RemoveEmployee(Employee employee, int id)
        {
            employeesList.Remove(employee);

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Linkup_Finance.Properties.Settings.LinkupDBConfig"].ConnectionString))
            {
                try
                {
                    string deleteQuery = "DELETE FROM Employees" +
                                        " WHERE Id = @Id";
                    SqlCommand command = new SqlCommand(deleteQuery, con);

                    con.Open();

                    command.Parameters.AddWithValue("@Id", id);
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
            Employee employee = new Employee(name, salary, job, phone, email, entryDateTime, salaryDueDate);
            employeesList.Add(employee);
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

        public Employee(string name, decimal salary, string job, string phone, string email, DateTime entryDateTime, DateTime salaryDueDate)
        {
            this.Name = name;
            this.Salary = salary;
            this.Job = job;
            this.Phone = phone;
            this.Email = email;
            this.EntryDate = entryDateTime;
            this.SalaryDue = salaryDueDate;
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
    }
}
