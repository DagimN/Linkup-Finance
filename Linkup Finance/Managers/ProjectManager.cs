using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

namespace Linkup_Finance.Managers
{
    public class ProjectManager
    {
        private List<Project> projects = new List<Project>();

        public ProjectManager()
        {
            projects = new List<Project>();
        }

        public Project AddProject(string name)
        {
            using(SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Linkup_Finance.Properties.Settings.LinkupDBConfig"].ConnectionString))
            {
                try
                {
                    con.Open();
                    Random rand = new Random();
                    int id = rand.Next(999999);
                    string insertQuery = "INSERT INTO Projects(Name)" +
                                        "VALUES (@Name)";
                    SqlCommand command = new SqlCommand(insertQuery, con);
                    command.Parameters.AddWithValue("@Name", name);

                    if (!Exists(name))
                    {
                        Project project = new Project(name);
                        projects.Add(project);
                        command.ExecuteNonQuery();
                        return project;
                    }
                }
                catch (Exception)
                {
                    return null;
                }
                finally
                {
                    con.Close();
                }
            }
            
            return null;
        }

        public bool Exists(string name)
        {
            foreach (Project project in projects)
                if (project.GetProjectName().ToLower() == name.ToLower())
                    return true;

            return false;
        }

        public Project Exists(string name, bool returnProject)
        {
            foreach (Project project in projects)
                if (project.GetProjectName().ToLower() == name.ToLower())
                    return project;

            return null;
        }

        public List<Project> RetrieveProjects(Linkup_Finance.LinkupDatabaseDataSetTableAdapters.ProjectsTableAdapter adapter)
        {
            int bound = adapter.GetData().Rows.Count;
            
            for (int i = 0; i < bound; i++)
            {
                string name = adapter.GetData().Rows[i].ItemArray[1].ToString();

                if(!Exists(name))
                    projects.Add(new Project(name));
            }

            return projects;
        }

        public void RemoveProject(string name)
        {
            Project project = new Project("");

            foreach(Project pro in projects)
            {
                if(pro.GetProjectName().ToLower() == name.ToLower())
                {
                    project = pro;
                    break;
                }
            }

            if (project != null)
            {
                using(SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Linkup_Finance.Properties.Settings.LinkupDBConfig"].ConnectionString))
                {
                    projects.Remove(project);

                    try
                    {
                        con.Open();
                        string deleteQuery = "DELETE FROM Projects" +
                                            " WHERE Name=@Name";
                        string deleteIncome = "DELETE FROM Income " +
                                              "WHERE Project=@Project";
                        string deleteExpense = "DELETE FROM Expense " +
                                               "WHERE Project=@Project";
                       
                        SqlCommand command = new SqlCommand(deleteQuery, con);

                        command.Parameters.AddWithValue("@Name", name);
                        command.ExecuteNonQuery();

                        command = new SqlCommand(deleteIncome, con);

                        command.Parameters.AddWithValue("@Project", name);
                        command.ExecuteNonQuery();

                        command = new SqlCommand(deleteExpense, con);

                        command.Parameters.AddWithValue("@Project", name);
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
        }
    }

    public class Project
    {
        private string projectName;
        public Project(string name)
        {
            projectName = name;
        }

        public string GetProjectName()
        {
            return projectName;
        }

        public bool AddIncome(string name, string reason, string bank, bool hasReceipt, decimal gross, string project, DateTime date, int tin, string type = null, string attachement = null)
        {
            decimal vat = gross * 0.15m;
            decimal withholding = 0m;
            decimal net;

            if (type == "Goods")
            {
                if (gross >= 10000.00m)
                    withholding = gross * 0.02m;
            }
            else if (type == "Service")
            {
                if (gross >= 3000.00m)
                    withholding = gross * 0.02m;
            }
           
            net = gross + vat - withholding;

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Linkup_Finance.Properties.Settings.LinkupDBConfig"].ConnectionString))
            {
                try
                {
                    string insertQuery = "INSERT INTO Income(Payer, Reason, Bank, Gross, VAT, Withholding, Net, Receipt, Date, Attachement, Project, Tin, Type)" +
                                         $" VALUES(@Payer, @Reason, @Bank, @Gross, @VAT, @Withholding, @Net, @Receipt, @Date, \'{attachement}\', @Project, @Tin, \'{type}\')";
                    
                    SqlCommand command = new SqlCommand(insertQuery, con);
                    command.Parameters.AddWithValue("@Payer", name);
                    command.Parameters.AddWithValue("@Reason", reason);
                    command.Parameters.AddWithValue("@Bank", bank);
                    command.Parameters.AddWithValue("@Gross", gross);
                    command.Parameters.AddWithValue("@VAT", vat);
                    command.Parameters.AddWithValue("@Withholding", withholding);
                    command.Parameters.AddWithValue("@Net", net);
                    command.Parameters.AddWithValue("@Receipt", hasReceipt);
                    command.Parameters.AddWithValue("@Date", date);
                    command.Parameters.AddWithValue("@Project", project);
                    command.Parameters.AddWithValue("@Tin", tin);
                    con.Open();
                    command.ExecuteNonQuery();
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

            return true;
        }

        public bool AddExpense(string name, string reason, string product, string bank, bool hasReceipt, decimal amount, string project, DateTime date, int tin, string type, string attachement = null)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Linkup_Finance.Properties.Settings.LinkupDBConfig"].ConnectionString))
            {
                try
                {
                    con.Open();
                    decimal vat = amount * 0.15m;
                    decimal withholding = 0m;
                    decimal total;

                    if(type == "Goods")
                    {
                        if (amount >= 10000.00m)
                            withholding = amount * 0.02m;
                    }
                    else if (type == "Service")
                    {
                        if (amount >= 3000.00m)
                            withholding = amount * 0.02m;
                    }
                    else
                    {
                        if (amount <= 1000)
                            type = "Petty";
                        else
                            type = "Normal";
                    }
                     
                    total = amount + vat - withholding;

                    string insertQuery = "INSERT INTO Expense(ExpName, Product, Amount, Type, VAT, Withholding, Bank, Reason, Date, Attachement, Total, Project, Receipt, Tin)" +
                                         $" VALUES(@ExpName,@Product,@Amount,@Type,@VAT,@Withholding,@Bank,@Reason,@Date,\'{attachement}\',@Total,@Project,@Receipt,@Tin)";
                    SqlCommand command = new SqlCommand(insertQuery, con);
                    command.Parameters.AddWithValue("@ExpName", name);
                    command.Parameters.AddWithValue("@Product", product);
                    command.Parameters.AddWithValue("@Amount", amount);
                    command.Parameters.AddWithValue("@Type", type);
                    command.Parameters.AddWithValue("@VAT", vat);
                    command.Parameters.AddWithValue("@Withholding", withholding);
                    command.Parameters.AddWithValue("@Bank", bank);
                    command.Parameters.AddWithValue("@Reason", reason);
                    command.Parameters.AddWithValue("@Date", date);
                    command.Parameters.AddWithValue("@Total", total);
                    command.Parameters.AddWithValue("@Project", project);
                    command.Parameters.AddWithValue("@Receipt", hasReceipt);
                    command.Parameters.AddWithValue("@Tin", tin);
                    command.ExecuteNonQuery();
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

            return true;
        }
    }
}
