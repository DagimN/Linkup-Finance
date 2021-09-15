
namespace Linkup_Finance.Forms
{
    partial class ProjectForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.newProjectButton = new Guna.UI2.WinForms.Guna2Button();
            this.projectOption = new Guna.UI2.WinForms.Guna2ComboBox();
            this.newProjectLabel = new System.Windows.Forms.Label();
            this.submitButton = new Guna.UI2.WinForms.Guna2Button();
            this.projectNameTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.projectsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.linkupDatabaseDataSet = new Linkup_Finance.LinkupDatabaseDataSet();
            this.projectsTableAdapter = new Linkup_Finance.LinkupDatabaseDataSetTableAdapters.ProjectsTableAdapter();
            this.ledgerTabControl = new Guna.UI2.WinForms.Guna2TabControl();
            this.incomeTabPage = new System.Windows.Forms.TabPage();
            this.guna2Button6 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button5 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button4 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button3 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2TextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            this.cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            this.guna2DataGridView1 = new Guna.UI2.WinForms.Guna2DataGridView();
            this.expenseTabPage = new System.Windows.Forms.TabPage();
            this.guna2Button12 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button7 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button8 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button9 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button10 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button11 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2TextBox2 = new Guna.UI2.WinForms.Guna2TextBox();
            this.cartesianChart2 = new LiveCharts.WinForms.CartesianChart();
            this.guna2DataGridView2 = new Guna.UI2.WinForms.Guna2DataGridView();
            this.balanceTabPage = new System.Windows.Forms.TabPage();
            this.payrollTabPage = new System.Windows.Forms.TabPage();
            this.exitSubmissionButton = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.projectsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linkupDatabaseDataSet)).BeginInit();
            this.ledgerTabControl.SuspendLayout();
            this.incomeTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridView1)).BeginInit();
            this.expenseTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // newProjectButton
            // 
            this.newProjectButton.BorderRadius = 10;
            this.newProjectButton.CheckedState.Parent = this.newProjectButton;
            this.newProjectButton.CustomImages.Parent = this.newProjectButton;
            this.newProjectButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.newProjectButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.newProjectButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.newProjectButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.newProjectButton.DisabledState.Parent = this.newProjectButton;
            this.newProjectButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(185)))), ((int)(((byte)(185)))));
            this.newProjectButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.newProjectButton.ForeColor = System.Drawing.Color.DimGray;
            this.newProjectButton.HoverState.Parent = this.newProjectButton;
            this.newProjectButton.Location = new System.Drawing.Point(12, 12);
            this.newProjectButton.Name = "newProjectButton";
            this.newProjectButton.ShadowDecoration.Parent = this.newProjectButton;
            this.newProjectButton.Size = new System.Drawing.Size(128, 33);
            this.newProjectButton.TabIndex = 0;
            this.newProjectButton.Text = "New Project";
            this.newProjectButton.Click += new System.EventHandler(this.newProjectButton_Click);
            // 
            // projectOption
            // 
            this.projectOption.BackColor = System.Drawing.Color.Transparent;
            this.projectOption.BorderRadius = 10;
            this.projectOption.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.projectOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.projectOption.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.projectOption.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.projectOption.FocusedState.Parent = this.projectOption;
            this.projectOption.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.projectOption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.projectOption.HoverState.Parent = this.projectOption;
            this.projectOption.ItemHeight = 30;
            this.projectOption.ItemsAppearance.Parent = this.projectOption;
            this.projectOption.Location = new System.Drawing.Point(146, 12);
            this.projectOption.Name = "projectOption";
            this.projectOption.ShadowDecoration.Parent = this.projectOption;
            this.projectOption.Size = new System.Drawing.Size(323, 36);
            this.projectOption.TabIndex = 1;
            // 
            // newProjectLabel
            // 
            this.newProjectLabel.AutoSize = true;
            this.newProjectLabel.BackColor = System.Drawing.Color.Transparent;
            this.newProjectLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newProjectLabel.ForeColor = System.Drawing.Color.Black;
            this.newProjectLabel.Location = new System.Drawing.Point(488, 21);
            this.newProjectLabel.Name = "newProjectLabel";
            this.newProjectLabel.Size = new System.Drawing.Size(101, 17);
            this.newProjectLabel.TabIndex = 4;
            this.newProjectLabel.Text = "Project Name: ";
            this.newProjectLabel.Visible = false;
            // 
            // submitButton
            // 
            this.submitButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.submitButton.BorderRadius = 15;
            this.submitButton.CheckedState.Parent = this.submitButton;
            this.submitButton.CustomImages.Parent = this.submitButton;
            this.submitButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.submitButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.submitButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.submitButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.submitButton.DisabledState.Parent = this.submitButton;
            this.submitButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.submitButton.ForeColor = System.Drawing.Color.White;
            this.submitButton.HoverState.Parent = this.submitButton;
            this.submitButton.Location = new System.Drawing.Point(920, 14);
            this.submitButton.Name = "submitButton";
            this.submitButton.ShadowDecoration.Parent = this.submitButton;
            this.submitButton.Size = new System.Drawing.Size(74, 34);
            this.submitButton.TabIndex = 3;
            this.submitButton.Text = "Submit";
            this.submitButton.Visible = false;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // projectNameTextBox
            // 
            this.projectNameTextBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.projectNameTextBox.BorderRadius = 10;
            this.projectNameTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.projectNameTextBox.DefaultText = "";
            this.projectNameTextBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.projectNameTextBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.projectNameTextBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.projectNameTextBox.DisabledState.Parent = this.projectNameTextBox;
            this.projectNameTextBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.projectNameTextBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.projectNameTextBox.FocusedState.Parent = this.projectNameTextBox;
            this.projectNameTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.projectNameTextBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.projectNameTextBox.HoverState.Parent = this.projectNameTextBox;
            this.projectNameTextBox.Location = new System.Drawing.Point(595, 14);
            this.projectNameTextBox.Name = "projectNameTextBox";
            this.projectNameTextBox.PasswordChar = '\0';
            this.projectNameTextBox.PlaceholderText = "";
            this.projectNameTextBox.SelectedText = "";
            this.projectNameTextBox.ShadowDecoration.Parent = this.projectNameTextBox;
            this.projectNameTextBox.Size = new System.Drawing.Size(319, 36);
            this.projectNameTextBox.TabIndex = 1;
            this.projectNameTextBox.Visible = false;
            this.projectNameTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.projectNameTextBox_MouseClick);
            // 
            // projectsBindingSource
            // 
            this.projectsBindingSource.DataMember = "Projects";
            this.projectsBindingSource.DataSource = this.linkupDatabaseDataSet;
            // 
            // linkupDatabaseDataSet
            // 
            this.linkupDatabaseDataSet.DataSetName = "LinkupDatabaseDataSet";
            this.linkupDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // projectsTableAdapter
            // 
            this.projectsTableAdapter.ClearBeforeFill = true;
            // 
            // ledgerTabControl
            // 
            this.ledgerTabControl.Controls.Add(this.incomeTabPage);
            this.ledgerTabControl.Controls.Add(this.expenseTabPage);
            this.ledgerTabControl.Controls.Add(this.balanceTabPage);
            this.ledgerTabControl.Controls.Add(this.payrollTabPage);
            this.ledgerTabControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ledgerTabControl.ItemSize = new System.Drawing.Size(180, 40);
            this.ledgerTabControl.Location = new System.Drawing.Point(0, 54);
            this.ledgerTabControl.Name = "ledgerTabControl";
            this.ledgerTabControl.SelectedIndex = 0;
            this.ledgerTabControl.Size = new System.Drawing.Size(1200, 462);
            this.ledgerTabControl.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty;
            this.ledgerTabControl.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.ledgerTabControl.TabButtonHoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.ledgerTabControl.TabButtonHoverState.ForeColor = System.Drawing.Color.White;
            this.ledgerTabControl.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.ledgerTabControl.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty;
            this.ledgerTabControl.TabButtonIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.ledgerTabControl.TabButtonIdleState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.ledgerTabControl.TabButtonIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(160)))), ((int)(((byte)(167)))));
            this.ledgerTabControl.TabButtonIdleState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.ledgerTabControl.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty;
            this.ledgerTabControl.TabButtonSelectedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.ledgerTabControl.TabButtonSelectedState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.ledgerTabControl.TabButtonSelectedState.ForeColor = System.Drawing.Color.White;
            this.ledgerTabControl.TabButtonSelectedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(132)))), ((int)(((byte)(255)))));
            this.ledgerTabControl.TabButtonSize = new System.Drawing.Size(180, 40);
            this.ledgerTabControl.TabIndex = 3;
            this.ledgerTabControl.TabMenuBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.ledgerTabControl.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalTop;
            // 
            // incomeTabPage
            // 
            this.incomeTabPage.Controls.Add(this.guna2Button6);
            this.incomeTabPage.Controls.Add(this.guna2Button5);
            this.incomeTabPage.Controls.Add(this.guna2Button4);
            this.incomeTabPage.Controls.Add(this.guna2Button3);
            this.incomeTabPage.Controls.Add(this.guna2Button2);
            this.incomeTabPage.Controls.Add(this.guna2Button1);
            this.incomeTabPage.Controls.Add(this.guna2TextBox1);
            this.incomeTabPage.Controls.Add(this.cartesianChart1);
            this.incomeTabPage.Controls.Add(this.guna2DataGridView1);
            this.incomeTabPage.Location = new System.Drawing.Point(4, 44);
            this.incomeTabPage.Name = "incomeTabPage";
            this.incomeTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.incomeTabPage.Size = new System.Drawing.Size(1192, 414);
            this.incomeTabPage.TabIndex = 0;
            this.incomeTabPage.Text = "Income";
            this.incomeTabPage.UseVisualStyleBackColor = true;
            // 
            // guna2Button6
            // 
            this.guna2Button6.CheckedState.Parent = this.guna2Button6;
            this.guna2Button6.CustomImages.Parent = this.guna2Button6;
            this.guna2Button6.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button6.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button6.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button6.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button6.DisabledState.Parent = this.guna2Button6;
            this.guna2Button6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button6.ForeColor = System.Drawing.Color.White;
            this.guna2Button6.HoverState.Parent = this.guna2Button6;
            this.guna2Button6.Location = new System.Drawing.Point(480, 96);
            this.guna2Button6.Name = "guna2Button6";
            this.guna2Button6.ShadowDecoration.Parent = this.guna2Button6;
            this.guna2Button6.Size = new System.Drawing.Size(95, 36);
            this.guna2Button6.TabIndex = 8;
            this.guna2Button6.Text = "guna2Button6";
            // 
            // guna2Button5
            // 
            this.guna2Button5.CheckedState.Parent = this.guna2Button5;
            this.guna2Button5.CustomImages.Parent = this.guna2Button5;
            this.guna2Button5.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button5.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button5.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button5.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button5.DisabledState.Parent = this.guna2Button5;
            this.guna2Button5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button5.ForeColor = System.Drawing.Color.White;
            this.guna2Button5.HoverState.Parent = this.guna2Button5;
            this.guna2Button5.Location = new System.Drawing.Point(292, 347);
            this.guna2Button5.Name = "guna2Button5";
            this.guna2Button5.ShadowDecoration.Parent = this.guna2Button5;
            this.guna2Button5.Size = new System.Drawing.Size(44, 36);
            this.guna2Button5.TabIndex = 7;
            this.guna2Button5.Text = "guna2Button5";
            // 
            // guna2Button4
            // 
            this.guna2Button4.CheckedState.Parent = this.guna2Button4;
            this.guna2Button4.CustomImages.Parent = this.guna2Button4;
            this.guna2Button4.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button4.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button4.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button4.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button4.DisabledState.Parent = this.guna2Button4;
            this.guna2Button4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button4.ForeColor = System.Drawing.Color.White;
            this.guna2Button4.HoverState.Parent = this.guna2Button4;
            this.guna2Button4.Location = new System.Drawing.Point(214, 347);
            this.guna2Button4.Name = "guna2Button4";
            this.guna2Button4.ShadowDecoration.Parent = this.guna2Button4;
            this.guna2Button4.Size = new System.Drawing.Size(44, 36);
            this.guna2Button4.TabIndex = 6;
            this.guna2Button4.Text = "guna2Button4";
            // 
            // guna2Button3
            // 
            this.guna2Button3.CheckedState.Parent = this.guna2Button3;
            this.guna2Button3.CustomImages.Parent = this.guna2Button3;
            this.guna2Button3.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button3.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button3.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button3.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button3.DisabledState.Parent = this.guna2Button3;
            this.guna2Button3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button3.ForeColor = System.Drawing.Color.White;
            this.guna2Button3.HoverState.Parent = this.guna2Button3;
            this.guna2Button3.Location = new System.Drawing.Point(58, 347);
            this.guna2Button3.Name = "guna2Button3";
            this.guna2Button3.ShadowDecoration.Parent = this.guna2Button3;
            this.guna2Button3.Size = new System.Drawing.Size(44, 36);
            this.guna2Button3.TabIndex = 5;
            this.guna2Button3.Text = "guna2Button3";
            // 
            // guna2Button2
            // 
            this.guna2Button2.CheckedState.Parent = this.guna2Button2;
            this.guna2Button2.CustomImages.Parent = this.guna2Button2;
            this.guna2Button2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button2.DisabledState.Parent = this.guna2Button2;
            this.guna2Button2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button2.ForeColor = System.Drawing.Color.White;
            this.guna2Button2.HoverState.Parent = this.guna2Button2;
            this.guna2Button2.Location = new System.Drawing.Point(136, 347);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.ShadowDecoration.Parent = this.guna2Button2;
            this.guna2Button2.Size = new System.Drawing.Size(44, 36);
            this.guna2Button2.TabIndex = 4;
            this.guna2Button2.Text = "guna2Button2";
            // 
            // guna2Button1
            // 
            this.guna2Button1.CheckedState.Parent = this.guna2Button1;
            this.guna2Button1.CustomImages.Parent = this.guna2Button1;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.DisabledState.Parent = this.guna2Button1;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.HoverState.Parent = this.guna2Button1;
            this.guna2Button1.Location = new System.Drawing.Point(1140, 10);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
            this.guna2Button1.Size = new System.Drawing.Size(44, 36);
            this.guna2Button1.TabIndex = 3;
            this.guna2Button1.Text = "guna2Button1";
            // 
            // guna2TextBox1
            // 
            this.guna2TextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox1.DefaultText = "";
            this.guna2TextBox1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBox1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBox1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox1.DisabledState.Parent = this.guna2TextBox1;
            this.guna2TextBox1.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox1.FocusedState.Parent = this.guna2TextBox1;
            this.guna2TextBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2TextBox1.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox1.HoverState.Parent = this.guna2TextBox1;
            this.guna2TextBox1.Location = new System.Drawing.Point(845, 10);
            this.guna2TextBox1.Name = "guna2TextBox1";
            this.guna2TextBox1.PasswordChar = '\0';
            this.guna2TextBox1.PlaceholderText = "";
            this.guna2TextBox1.SelectedText = "";
            this.guna2TextBox1.ShadowDecoration.Parent = this.guna2TextBox1;
            this.guna2TextBox1.Size = new System.Drawing.Size(289, 36);
            this.guna2TextBox1.TabIndex = 2;
            // 
            // cartesianChart1
            // 
            this.cartesianChart1.Location = new System.Drawing.Point(8, 10);
            this.cartesianChart1.Name = "cartesianChart1";
            this.cartesianChart1.Size = new System.Drawing.Size(376, 331);
            this.cartesianChart1.TabIndex = 1;
            this.cartesianChart1.Text = "cartesianChart1";
            this.cartesianChart1.ChildChanged += new System.EventHandler<System.Windows.Forms.Integration.ChildChangedEventArgs>(this.cartesianChart1_ChildChanged);
            // 
            // guna2DataGridView1
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.guna2DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.guna2DataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.guna2DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.guna2DataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.guna2DataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.guna2DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.guna2DataGridView1.ColumnHeadersHeight = 4;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.guna2DataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.guna2DataGridView1.EnableHeadersVisualStyles = false;
            this.guna2DataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guna2DataGridView1.Location = new System.Drawing.Point(596, 52);
            this.guna2DataGridView1.Name = "guna2DataGridView1";
            this.guna2DataGridView1.RowHeadersVisible = false;
            this.guna2DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.guna2DataGridView1.Size = new System.Drawing.Size(588, 334);
            this.guna2DataGridView1.TabIndex = 0;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.guna2DataGridView1.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.Height = 4;
            this.guna2DataGridView1.ThemeStyle.ReadOnly = false;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.guna2DataGridView1.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Height = 22;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // expenseTabPage
            // 
            this.expenseTabPage.Controls.Add(this.guna2Button12);
            this.expenseTabPage.Controls.Add(this.guna2Button7);
            this.expenseTabPage.Controls.Add(this.guna2Button8);
            this.expenseTabPage.Controls.Add(this.guna2Button9);
            this.expenseTabPage.Controls.Add(this.guna2Button10);
            this.expenseTabPage.Controls.Add(this.guna2Button11);
            this.expenseTabPage.Controls.Add(this.guna2TextBox2);
            this.expenseTabPage.Controls.Add(this.cartesianChart2);
            this.expenseTabPage.Controls.Add(this.guna2DataGridView2);
            this.expenseTabPage.Location = new System.Drawing.Point(4, 44);
            this.expenseTabPage.Name = "expenseTabPage";
            this.expenseTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.expenseTabPage.Size = new System.Drawing.Size(1192, 414);
            this.expenseTabPage.TabIndex = 1;
            this.expenseTabPage.Text = "Expense";
            this.expenseTabPage.UseVisualStyleBackColor = true;
            // 
            // guna2Button12
            // 
            this.guna2Button12.CheckedState.Parent = this.guna2Button12;
            this.guna2Button12.CustomImages.Parent = this.guna2Button12;
            this.guna2Button12.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button12.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button12.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button12.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button12.DisabledState.Parent = this.guna2Button12;
            this.guna2Button12.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button12.ForeColor = System.Drawing.Color.White;
            this.guna2Button12.HoverState.Parent = this.guna2Button12;
            this.guna2Button12.Location = new System.Drawing.Point(1140, 19);
            this.guna2Button12.Name = "guna2Button12";
            this.guna2Button12.ShadowDecoration.Parent = this.guna2Button12;
            this.guna2Button12.Size = new System.Drawing.Size(44, 36);
            this.guna2Button12.TabIndex = 17;
            this.guna2Button12.Text = "guna2Button12";
            // 
            // guna2Button7
            // 
            this.guna2Button7.CheckedState.Parent = this.guna2Button7;
            this.guna2Button7.CustomImages.Parent = this.guna2Button7;
            this.guna2Button7.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button7.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button7.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button7.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button7.DisabledState.Parent = this.guna2Button7;
            this.guna2Button7.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button7.ForeColor = System.Drawing.Color.White;
            this.guna2Button7.HoverState.Parent = this.guna2Button7;
            this.guna2Button7.Location = new System.Drawing.Point(480, 105);
            this.guna2Button7.Name = "guna2Button7";
            this.guna2Button7.ShadowDecoration.Parent = this.guna2Button7;
            this.guna2Button7.Size = new System.Drawing.Size(95, 36);
            this.guna2Button7.TabIndex = 16;
            this.guna2Button7.Text = "guna2Button7";
            // 
            // guna2Button8
            // 
            this.guna2Button8.CheckedState.Parent = this.guna2Button8;
            this.guna2Button8.CustomImages.Parent = this.guna2Button8;
            this.guna2Button8.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button8.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button8.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button8.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button8.DisabledState.Parent = this.guna2Button8;
            this.guna2Button8.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button8.ForeColor = System.Drawing.Color.White;
            this.guna2Button8.HoverState.Parent = this.guna2Button8;
            this.guna2Button8.Location = new System.Drawing.Point(292, 356);
            this.guna2Button8.Name = "guna2Button8";
            this.guna2Button8.ShadowDecoration.Parent = this.guna2Button8;
            this.guna2Button8.Size = new System.Drawing.Size(44, 36);
            this.guna2Button8.TabIndex = 15;
            this.guna2Button8.Text = "guna2Button8";
            // 
            // guna2Button9
            // 
            this.guna2Button9.CheckedState.Parent = this.guna2Button9;
            this.guna2Button9.CustomImages.Parent = this.guna2Button9;
            this.guna2Button9.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button9.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button9.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button9.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button9.DisabledState.Parent = this.guna2Button9;
            this.guna2Button9.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button9.ForeColor = System.Drawing.Color.White;
            this.guna2Button9.HoverState.Parent = this.guna2Button9;
            this.guna2Button9.Location = new System.Drawing.Point(214, 356);
            this.guna2Button9.Name = "guna2Button9";
            this.guna2Button9.ShadowDecoration.Parent = this.guna2Button9;
            this.guna2Button9.Size = new System.Drawing.Size(44, 36);
            this.guna2Button9.TabIndex = 14;
            this.guna2Button9.Text = "guna2Button9";
            // 
            // guna2Button10
            // 
            this.guna2Button10.CheckedState.Parent = this.guna2Button10;
            this.guna2Button10.CustomImages.Parent = this.guna2Button10;
            this.guna2Button10.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button10.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button10.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button10.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button10.DisabledState.Parent = this.guna2Button10;
            this.guna2Button10.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button10.ForeColor = System.Drawing.Color.White;
            this.guna2Button10.HoverState.Parent = this.guna2Button10;
            this.guna2Button10.Location = new System.Drawing.Point(58, 356);
            this.guna2Button10.Name = "guna2Button10";
            this.guna2Button10.ShadowDecoration.Parent = this.guna2Button10;
            this.guna2Button10.Size = new System.Drawing.Size(44, 36);
            this.guna2Button10.TabIndex = 13;
            this.guna2Button10.Text = "guna2Button10";
            // 
            // guna2Button11
            // 
            this.guna2Button11.CheckedState.Parent = this.guna2Button11;
            this.guna2Button11.CustomImages.Parent = this.guna2Button11;
            this.guna2Button11.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button11.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button11.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button11.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button11.DisabledState.Parent = this.guna2Button11;
            this.guna2Button11.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button11.ForeColor = System.Drawing.Color.White;
            this.guna2Button11.HoverState.Parent = this.guna2Button11;
            this.guna2Button11.Location = new System.Drawing.Point(136, 356);
            this.guna2Button11.Name = "guna2Button11";
            this.guna2Button11.ShadowDecoration.Parent = this.guna2Button11;
            this.guna2Button11.Size = new System.Drawing.Size(44, 36);
            this.guna2Button11.TabIndex = 12;
            this.guna2Button11.Text = "guna2Button11";
            // 
            // guna2TextBox2
            // 
            this.guna2TextBox2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox2.DefaultText = "";
            this.guna2TextBox2.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBox2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBox2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox2.DisabledState.Parent = this.guna2TextBox2;
            this.guna2TextBox2.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox2.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox2.FocusedState.Parent = this.guna2TextBox2;
            this.guna2TextBox2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2TextBox2.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox2.HoverState.Parent = this.guna2TextBox2;
            this.guna2TextBox2.Location = new System.Drawing.Point(845, 19);
            this.guna2TextBox2.Name = "guna2TextBox2";
            this.guna2TextBox2.PasswordChar = '\0';
            this.guna2TextBox2.PlaceholderText = "";
            this.guna2TextBox2.SelectedText = "";
            this.guna2TextBox2.ShadowDecoration.Parent = this.guna2TextBox2;
            this.guna2TextBox2.Size = new System.Drawing.Size(289, 36);
            this.guna2TextBox2.TabIndex = 11;
            // 
            // cartesianChart2
            // 
            this.cartesianChart2.Location = new System.Drawing.Point(8, 19);
            this.cartesianChart2.Name = "cartesianChart2";
            this.cartesianChart2.Size = new System.Drawing.Size(376, 331);
            this.cartesianChart2.TabIndex = 10;
            this.cartesianChart2.Text = "cartesianChart2";
            // 
            // guna2DataGridView2
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.guna2DataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.guna2DataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.guna2DataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.guna2DataGridView2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.guna2DataGridView2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.guna2DataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.guna2DataGridView2.ColumnHeadersHeight = 4;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.guna2DataGridView2.DefaultCellStyle = dataGridViewCellStyle6;
            this.guna2DataGridView2.EnableHeadersVisualStyles = false;
            this.guna2DataGridView2.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guna2DataGridView2.Location = new System.Drawing.Point(596, 61);
            this.guna2DataGridView2.Name = "guna2DataGridView2";
            this.guna2DataGridView2.RowHeadersVisible = false;
            this.guna2DataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.guna2DataGridView2.Size = new System.Drawing.Size(588, 334);
            this.guna2DataGridView2.TabIndex = 9;
            this.guna2DataGridView2.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView2.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.guna2DataGridView2.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.guna2DataGridView2.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.guna2DataGridView2.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.guna2DataGridView2.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView2.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guna2DataGridView2.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.guna2DataGridView2.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.guna2DataGridView2.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.guna2DataGridView2.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.guna2DataGridView2.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.guna2DataGridView2.ThemeStyle.HeaderStyle.Height = 4;
            this.guna2DataGridView2.ThemeStyle.ReadOnly = false;
            this.guna2DataGridView2.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView2.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.guna2DataGridView2.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.guna2DataGridView2.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.guna2DataGridView2.ThemeStyle.RowsStyle.Height = 22;
            this.guna2DataGridView2.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guna2DataGridView2.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // balanceTabPage
            // 
            this.balanceTabPage.Location = new System.Drawing.Point(4, 44);
            this.balanceTabPage.Name = "balanceTabPage";
            this.balanceTabPage.Size = new System.Drawing.Size(1192, 414);
            this.balanceTabPage.TabIndex = 2;
            this.balanceTabPage.Text = "Balance";
            this.balanceTabPage.UseVisualStyleBackColor = true;
            // 
            // payrollTabPage
            // 
            this.payrollTabPage.Location = new System.Drawing.Point(4, 44);
            this.payrollTabPage.Name = "payrollTabPage";
            this.payrollTabPage.Size = new System.Drawing.Size(1192, 414);
            this.payrollTabPage.TabIndex = 3;
            this.payrollTabPage.Text = "Payroll";
            this.payrollTabPage.UseVisualStyleBackColor = true;
            // 
            // exitSubmissionButton
            // 
            this.exitSubmissionButton.BorderRadius = 15;
            this.exitSubmissionButton.CheckedState.Parent = this.exitSubmissionButton;
            this.exitSubmissionButton.CustomImages.Parent = this.exitSubmissionButton;
            this.exitSubmissionButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.exitSubmissionButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.exitSubmissionButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.exitSubmissionButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.exitSubmissionButton.DisabledState.Parent = this.exitSubmissionButton;
            this.exitSubmissionButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.exitSubmissionButton.ForeColor = System.Drawing.Color.White;
            this.exitSubmissionButton.HoverState.Parent = this.exitSubmissionButton;
            this.exitSubmissionButton.Location = new System.Drawing.Point(1000, 14);
            this.exitSubmissionButton.Name = "exitSubmissionButton";
            this.exitSubmissionButton.ShadowDecoration.Parent = this.exitSubmissionButton;
            this.exitSubmissionButton.Size = new System.Drawing.Size(35, 34);
            this.exitSubmissionButton.TabIndex = 5;
            this.exitSubmissionButton.Text = "X";
            this.exitSubmissionButton.Visible = false;
            this.exitSubmissionButton.Click += new System.EventHandler(this.exitSubmissionButton_Click);
            // 
            // ProjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1200, 516);
            this.Controls.Add(this.exitSubmissionButton);
            this.Controls.Add(this.newProjectLabel);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.ledgerTabControl);
            this.Controls.Add(this.projectNameTextBox);
            this.Controls.Add(this.projectOption);
            this.Controls.Add(this.newProjectButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProjectForm";
            this.Text = "ProjectForm";
            this.Load += new System.EventHandler(this.ProjectForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.projectsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linkupDatabaseDataSet)).EndInit();
            this.ledgerTabControl.ResumeLayout(false);
            this.incomeTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridView1)).EndInit();
            this.expenseTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button newProjectButton;
        private Guna.UI2.WinForms.Guna2ComboBox projectOption;
        private Guna.UI2.WinForms.Guna2TextBox projectNameTextBox;
        private Guna.UI2.WinForms.Guna2Button submitButton;
        private System.Windows.Forms.Label newProjectLabel;
        private LinkupDatabaseDataSet linkupDatabaseDataSet;
        private System.Windows.Forms.BindingSource projectsBindingSource;
        public LinkupDatabaseDataSetTableAdapters.ProjectsTableAdapter projectsTableAdapter;
        private System.Windows.Forms.TabPage incomeTabPage;
        private System.Windows.Forms.TabPage expenseTabPage;
        private System.Windows.Forms.TabPage balanceTabPage;
        private System.Windows.Forms.TabPage payrollTabPage;
        private Guna.UI2.WinForms.Guna2Button guna2Button6;
        private Guna.UI2.WinForms.Guna2Button guna2Button5;
        private Guna.UI2.WinForms.Guna2Button guna2Button4;
        private Guna.UI2.WinForms.Guna2Button guna2Button3;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;
        private LiveCharts.WinForms.CartesianChart cartesianChart1;
        private Guna.UI2.WinForms.Guna2DataGridView guna2DataGridView1;
        private Guna.UI2.WinForms.Guna2Button guna2Button12;
        private Guna.UI2.WinForms.Guna2Button guna2Button7;
        private Guna.UI2.WinForms.Guna2Button guna2Button8;
        private Guna.UI2.WinForms.Guna2Button guna2Button9;
        private Guna.UI2.WinForms.Guna2Button guna2Button10;
        private Guna.UI2.WinForms.Guna2Button guna2Button11;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox2;
        private LiveCharts.WinForms.CartesianChart cartesianChart2;
        private Guna.UI2.WinForms.Guna2DataGridView guna2DataGridView2;
        private Guna.UI2.WinForms.Guna2Button exitSubmissionButton;
        public Guna.UI2.WinForms.Guna2TabControl ledgerTabControl;
    }
}