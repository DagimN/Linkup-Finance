using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linkup_Finance.Managers
{
    public class ProjectManager
    {
        private List<Project> projects = new List<Project>();
        public SqlConnection con;

        public ProjectManager()
        {
            projects = new List<Project>();

            con = new SqlConnection(ConfigurationManager.ConnectionStrings["Linkup_Finance.Properties.Settings.LinkupDBConfig"].ConnectionString);
            con.Open();
        }

        public void AddProject(string name)
        {
            Random rand = new Random();
            int id = rand.Next(999999);
            string insertQuery = "INSERT INTO Projects(Id, Name)" +
                                "VALUES ('" + id + "', '" + name + "')";
            SqlCommand command = new SqlCommand(insertQuery, con);

            if (!Exists(name))
            {
                projects.Add(new Project(name));
                command.ExecuteNonQuery();
            }
        }

        public bool Exists(string name)
        {
            foreach (Project project in projects)
                if (project.GetProjectName().ToLower() == name.ToLower())
                    return true;

            return false;
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
    }
}
