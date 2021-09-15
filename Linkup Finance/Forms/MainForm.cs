﻿using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Linkup_Finance.Forms;

namespace Linkup_Finance
{
    public partial class MainForm : Form
    {
        private bool isViewing = false;

        private Form activeForm;
        private DashboardForm dashboardForm;
        public ProjectForm projectForm;
        private UsersForm userForm;

        private Point startPoint = new Point(0, 0);
        private bool drag = false;

        private FormWindowState state = FormWindowState.Normal;

        public MainForm()
        {
            InitializeComponent();

            dashboardForm = new DashboardForm();
            projectForm = new ProjectForm();
            userForm = new UsersForm();

            openChildForm(dashboardForm);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MaximumSize = Screen.FromHandle(this.Handle).WorkingArea.Size;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (isViewing)
            {
                //TransitionPanel(titleBarPanel.Size, new Size(1200, 100), guna2Button1.Location);

                isViewing = false;
            }
            else
            {
                //TransitionPanel(titleBarPanel.Size, new Size(1200, 480), guna2Button1.Location);
                
                isViewing = true;
            }
        }

        //Load Pages to the work panel
        private void openChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Visible = false;

            workPanel.Controls.Remove(activeForm);
            activeForm = childForm;
            activeForm.TopLevel = false;
            workPanel.SuspendLayout();
            workPanel.Controls.Add(activeForm);
            activeForm.Visible = true;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            projectForm.projectManager.con.Close();
            Application.Exit();
        }

        private void titleBarPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.drag)
            {
                Point p1 = new Point(e.X, e.Y);
                Point p2 = this.PointToScreen(p1);
                Point p3 = new Point(p2.X - this.startPoint.X,
                                     p2.Y - this.startPoint.Y);

                this.Location = p3;
            }
        }

        private void titleBarPanel_MouseDown(object sender, MouseEventArgs e)
        {
            startPoint = e.Location;
            drag = true;
        }

        private void titleBarPanel_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void maximizeButton_Click(object sender, EventArgs e)
        {
            if (state == FormWindowState.Normal)
            {
                for (int i = 0; i < Application.OpenForms.Count; i++)
                    if (Application.OpenForms[i].TopLevel)
                    {
                        Application.OpenForms[i].WindowState = FormWindowState.Maximized;
                        maximizeButton.Image = Linkup_Finance.Properties.Resources.Maximized_Icon;
                    }

                ResizeControls();

                state = FormWindowState.Maximized;
            }
                
            else
            {
                for (int i = 0; i < Application.OpenForms.Count; i++)
                    if (Application.OpenForms[i].TopLevel)
                    {
                        Application.OpenForms[i].WindowState = FormWindowState.Normal;
                        Application.OpenForms[i].Size = new Size(1200, 586);
                        maximizeButton.Image = Linkup_Finance.Properties.Resources.Maximize_Icon;
                    }

                ResizeControls();

                state = FormWindowState.Normal;
            }
        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            if (state == FormWindowState.Normal || state == FormWindowState.Maximized)
                for (int i = 0; i < Application.OpenForms.Count; i++)
                    if (Application.OpenForms[i].TopLevel) Application.OpenForms[i].WindowState = FormWindowState.Minimized;
        }

        private void dashboardButton_Click(object sender, EventArgs e)
        {
            openChildForm(dashboardForm);
        }

        private void projectButton_Click(object sender, EventArgs e)
        {
            openChildForm(projectForm);
        }

        //Custom Functions

        public static void TransitionPanel(Size oldSize, Size newsize, Point oldPoint)
        {
            Size oldP = oldSize;
            Size newP = newsize;
            Point oldB = oldPoint;

            if (oldP.Height < newP.Height)
            {
                for (int i = oldP.Height; oldP.Height < newP.Height; i += 5)
                {
                    Thread.Sleep(TimeSpan.FromMilliseconds(0.01));
                }
            }
            else
            {
                for (int i = newP.Height; oldP.Height > newP.Height; i -= 5)
                {
                    Thread.Sleep(TimeSpan.FromMilliseconds(0.01));
                }
            }
        }

        private void ResizeControls()
        {
            Size resizeValue = new Size(this.Width, this.Height - titleBarPanel.Height);
            workPanel.Size = resizeValue;
            projectForm.Size = resizeValue;
            dashboardForm.Size = resizeValue;
            userForm.Size = resizeValue;

            if(state == FormWindowState.Maximized)
            {
                projectForm.newProjectPanel.Location = new Point(this.Width - projectForm.newProjectPanel.Width, 12);
            }
            else
            {
                projectForm.newProjectPanel.Location = new Point(this.Width - projectForm.newProjectPanel.Width, 12);
            }
        }

        private void userButton_Click(object sender, EventArgs e)
        {
            openChildForm(userForm);
        }
    }
}
