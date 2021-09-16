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
        public List<Project> projects = new List<Project>();
        public SqlConnection con;

        public ProjectManager()
        {
            projects = new List<Project>();

            con = new SqlConnection(ConfigurationManager.ConnectionStrings["Linkup_Finance.Properties.Settings.LinkupDBConfig"].ConnectionString);
        }

        public void AddProject(string name)
        {
            try
            {
                con.Open();
                Random rand = new Random();
                int id = rand.Next(999999);
                string insertQuery = "INSERT INTO Projects(Id, Name)" +
                                    "VALUES (\'" + id + "\', \'" + name + "\')";
                SqlCommand command = new SqlCommand(insertQuery, con);

                if (!Exists(name))
                {
                    Project project = new Project(name);
                    projects.Add(project);
                    command.ExecuteNonQuery();
                }
            }
            finally
            {
                con.Close();
            }
        }

        public bool Exists(string name)
        {
            foreach (Project project in projects)
                if (project.GetProjectName().ToLower() == name.ToLower())
                    return true;

            return false;
        }

        public void RetrieveProjects(Linkup_Finance.LinkupDatabaseDataSetTableAdapters.ProjectsTableAdapter adapter)
        {
            int bound = adapter.GetData().Rows.Count;
            
            for (int i = 0; i < bound; i++)
            {
                projects.Add(new Project(adapter.GetData().Rows[i].ItemArray[1].ToString()));
            }
        }

        public void RemoveProject(string name)
        {
            Project project = null;

            foreach(Project pro in projects)
            {
                if(pro.GetProjectName() == name)
                {
                    project = pro;
                    break;
                }
            }

            if (project != null)
            {
                projects.Remove(project);

                try
                {
                    con.Open();
                    string deleteQuery = "DELETE FROM Projects" +
                                        " WHERE Name=\'" + name +"\'";
                    SqlCommand command = new SqlCommand(deleteQuery, con);
                    command.ExecuteNonQuery();
                }
                finally
                {
                    con.Close();
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
    }
}
