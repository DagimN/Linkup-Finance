using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
namespace Linkup_Finance.Managers
{
    public enum AccountType { Admin, Accountant, Other }
    
    public class UserManager
    {
        private List<User> usersList;

        public UserManager()
        {
            usersList = new List<User>();
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

            using(SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Linkup_Finance.Properties.Settings.LinkupDBConfig"].ConnectionString))
            {
                try
                {
                    string accType;
                    string insertQuery = "INSERT INTO Users(Name, Type, Password, JobTitle)" +
                                        " VALUES(@Name, @Type, @Password, @JobTitle)";
                    SqlCommand command = new SqlCommand(insertQuery, con);
                    con.Open();

                    if(type == AccountType.Admin)
                        accType = "Admin";
                    else if(type == AccountType.Accountant)
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

            using(SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Linkup_Finance.Properties.Settings.LinkupDBConfig"].ConnectionString))
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

    }
}
