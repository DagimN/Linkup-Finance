
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
            this.newProjectButton = new Guna.UI2.WinForms.Guna2Button();
            this.projectOption = new Guna.UI2.WinForms.Guna2ComboBox();
            this.newProjectPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.closeProjectPanelButton = new Guna.UI2.WinForms.Guna2Button();
            this.projectPanelLabel = new System.Windows.Forms.Label();
            this.submitButton = new Guna.UI2.WinForms.Guna2Button();
            this.projectNameLabel = new System.Windows.Forms.Label();
            this.projectNameTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.ledgerPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Button3 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2DataGridView1 = new Guna.UI2.WinForms.Guna2DataGridView();
            this.linkupDatabaseDataSet = new Linkup_Finance.LinkupDatabaseDataSet();
            this.projectsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.projectsTableAdapter = new Linkup_Finance.LinkupDatabaseDataSetTableAdapters.ProjectsTableAdapter();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.newProjectPanel.SuspendLayout();
            this.ledgerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linkupDatabaseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectsBindingSource)).BeginInit();
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
            // newProjectPanel
            // 
            this.newProjectPanel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.newProjectPanel.AutoScroll = true;
            this.newProjectPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.newProjectPanel.BorderRadius = 15;
            this.newProjectPanel.Controls.Add(this.closeProjectPanelButton);
            this.newProjectPanel.Controls.Add(this.projectPanelLabel);
            this.newProjectPanel.Controls.Add(this.submitButton);
            this.newProjectPanel.Controls.Add(this.projectNameLabel);
            this.newProjectPanel.Controls.Add(this.projectNameTextBox);
            this.newProjectPanel.CustomizableEdges.BottomRight = false;
            this.newProjectPanel.CustomizableEdges.TopRight = false;
            this.newProjectPanel.FillColor = System.Drawing.Color.White;
            this.newProjectPanel.Location = new System.Drawing.Point(822, 12);
            this.newProjectPanel.Name = "newProjectPanel";
            this.newProjectPanel.ShadowDecoration.Parent = this.newProjectPanel;
            this.newProjectPanel.Size = new System.Drawing.Size(378, 288);
            this.newProjectPanel.TabIndex = 2;
            this.newProjectPanel.Visible = false;
            // 
            // closeProjectPanelButton
            // 
            this.closeProjectPanelButton.CheckedState.Parent = this.closeProjectPanelButton;
            this.closeProjectPanelButton.CustomImages.Parent = this.closeProjectPanelButton;
            this.closeProjectPanelButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.closeProjectPanelButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.closeProjectPanelButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.closeProjectPanelButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.closeProjectPanelButton.DisabledState.Parent = this.closeProjectPanelButton;
            this.closeProjectPanelButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.closeProjectPanelButton.ForeColor = System.Drawing.Color.White;
            this.closeProjectPanelButton.HoverState.Parent = this.closeProjectPanelButton;
            this.closeProjectPanelButton.Location = new System.Drawing.Point(348, 0);
            this.closeProjectPanelButton.Name = "closeProjectPanelButton";
            this.closeProjectPanelButton.ShadowDecoration.Parent = this.closeProjectPanelButton;
            this.closeProjectPanelButton.Size = new System.Drawing.Size(30, 30);
            this.closeProjectPanelButton.TabIndex = 5;
            this.closeProjectPanelButton.Text = "X";
            this.closeProjectPanelButton.Click += new System.EventHandler(this.closeProjectPanelButton_Click);
            // 
            // projectPanelLabel
            // 
            this.projectPanelLabel.AutoSize = true;
            this.projectPanelLabel.BackColor = System.Drawing.Color.Transparent;
            this.projectPanelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projectPanelLabel.ForeColor = System.Drawing.Color.Black;
            this.projectPanelLabel.Location = new System.Drawing.Point(108, 25);
            this.projectPanelLabel.Name = "projectPanelLabel";
            this.projectPanelLabel.Size = new System.Drawing.Size(161, 31);
            this.projectPanelLabel.TabIndex = 4;
            this.projectPanelLabel.Text = "New Project";
            // 
            // submitButton
            // 
            this.submitButton.BackColor = System.Drawing.Color.White;
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
            this.submitButton.Location = new System.Drawing.Point(114, 251);
            this.submitButton.Name = "submitButton";
            this.submitButton.ShadowDecoration.Parent = this.submitButton;
            this.submitButton.Size = new System.Drawing.Size(162, 34);
            this.submitButton.TabIndex = 3;
            this.submitButton.Text = "Submit";
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // projectNameLabel
            // 
            this.projectNameLabel.AutoSize = true;
            this.projectNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.projectNameLabel.ForeColor = System.Drawing.Color.Black;
            this.projectNameLabel.Location = new System.Drawing.Point(3, 96);
            this.projectNameLabel.Name = "projectNameLabel";
            this.projectNameLabel.Size = new System.Drawing.Size(38, 13);
            this.projectNameLabel.TabIndex = 2;
            this.projectNameLabel.Text = "Name:";
            // 
            // projectNameTextBox
            // 
            this.projectNameTextBox.BackColor = System.Drawing.Color.White;
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
            this.projectNameTextBox.Location = new System.Drawing.Point(47, 84);
            this.projectNameTextBox.Name = "projectNameTextBox";
            this.projectNameTextBox.PasswordChar = '\0';
            this.projectNameTextBox.PlaceholderText = "";
            this.projectNameTextBox.SelectedText = "";
            this.projectNameTextBox.ShadowDecoration.Parent = this.projectNameTextBox;
            this.projectNameTextBox.Size = new System.Drawing.Size(319, 36);
            this.projectNameTextBox.TabIndex = 1;
            // 
            // ledgerPanel
            // 
            this.ledgerPanel.BackColor = System.Drawing.Color.Transparent;
            this.ledgerPanel.BorderRadius = 20;
            this.ledgerPanel.Controls.Add(this.guna2DataGridView1);
            this.ledgerPanel.Controls.Add(this.guna2Button3);
            this.ledgerPanel.Controls.Add(this.guna2Button2);
            this.ledgerPanel.Controls.Add(this.guna2Button1);
            this.ledgerPanel.FillColor = System.Drawing.Color.White;
            this.ledgerPanel.Location = new System.Drawing.Point(12, 54);
            this.ledgerPanel.Name = "ledgerPanel";
            this.ledgerPanel.ShadowDecoration.BorderRadius = 20;
            this.ledgerPanel.ShadowDecoration.Depth = 5;
            this.ledgerPanel.ShadowDecoration.Enabled = true;
            this.ledgerPanel.ShadowDecoration.Parent = this.ledgerPanel;
            this.ledgerPanel.Size = new System.Drawing.Size(804, 450);
            this.ledgerPanel.TabIndex = 3;
            // 
            // guna2Button3
            // 
            this.guna2Button3.BackColor = System.Drawing.Color.White;
            this.guna2Button3.BorderRadius = 10;
            this.guna2Button3.CheckedState.Parent = this.guna2Button3;
            this.guna2Button3.CustomImages.Parent = this.guna2Button3;
            this.guna2Button3.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button3.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button3.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button3.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button3.DisabledState.Parent = this.guna2Button3;
            this.guna2Button3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(185)))), ((int)(((byte)(185)))));
            this.guna2Button3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button3.ForeColor = System.Drawing.Color.White;
            this.guna2Button3.HoverState.Parent = this.guna2Button3;
            this.guna2Button3.Location = new System.Drawing.Point(158, 12);
            this.guna2Button3.Name = "guna2Button3";
            this.guna2Button3.ShadowDecoration.Parent = this.guna2Button3;
            this.guna2Button3.Size = new System.Drawing.Size(135, 31);
            this.guna2Button3.TabIndex = 2;
            this.guna2Button3.Text = "Expense";
            // 
            // guna2Button2
            // 
            this.guna2Button2.BackColor = System.Drawing.Color.White;
            this.guna2Button2.BorderRadius = 10;
            this.guna2Button2.CheckedState.Parent = this.guna2Button2;
            this.guna2Button2.CustomImages.Parent = this.guna2Button2;
            this.guna2Button2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button2.DisabledState.Parent = this.guna2Button2;
            this.guna2Button2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(185)))), ((int)(((byte)(185)))));
            this.guna2Button2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button2.ForeColor = System.Drawing.Color.White;
            this.guna2Button2.HoverState.Parent = this.guna2Button2;
            this.guna2Button2.Location = new System.Drawing.Point(299, 12);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.ShadowDecoration.Parent = this.guna2Button2;
            this.guna2Button2.Size = new System.Drawing.Size(135, 31);
            this.guna2Button2.TabIndex = 1;
            this.guna2Button2.Text = "Balance";
            // 
            // guna2Button1
            // 
            this.guna2Button1.BackColor = System.Drawing.Color.White;
            this.guna2Button1.BorderRadius = 10;
            this.guna2Button1.CheckedState.Parent = this.guna2Button1;
            this.guna2Button1.CustomImages.Parent = this.guna2Button1;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.DisabledState.Parent = this.guna2Button1;
            this.guna2Button1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(185)))), ((int)(((byte)(185)))));
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.HoverState.Parent = this.guna2Button1;
            this.guna2Button1.Location = new System.Drawing.Point(17, 12);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
            this.guna2Button1.Size = new System.Drawing.Size(135, 31);
            this.guna2Button1.TabIndex = 0;
            this.guna2Button1.Text = "Income";
            // 
            // guna2DataGridView1
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.guna2DataGridView1.AutoGenerateColumns = false;
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
            this.guna2DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.guna2DataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn});
            this.guna2DataGridView1.DataSource = this.projectsBindingSource;
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
            this.guna2DataGridView1.Location = new System.Drawing.Point(17, 63);
            this.guna2DataGridView1.Name = "guna2DataGridView1";
            this.guna2DataGridView1.RowHeadersVisible = false;
            this.guna2DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.guna2DataGridView1.Size = new System.Drawing.Size(767, 372);
            this.guna2DataGridView1.TabIndex = 3;
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
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.Height = 21;
            this.guna2DataGridView1.ThemeStyle.ReadOnly = false;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.guna2DataGridView1.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Height = 22;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // linkupDatabaseDataSet
            // 
            this.linkupDatabaseDataSet.DataSetName = "LinkupDatabaseDataSet";
            this.linkupDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // projectsBindingSource
            // 
            this.projectsBindingSource.DataMember = "Projects";
            this.projectsBindingSource.DataSource = this.linkupDatabaseDataSet;
            // 
            // projectsTableAdapter
            // 
            this.projectsTableAdapter.ClearBeforeFill = true;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // ProjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1200, 516);
            this.Controls.Add(this.newProjectPanel);
            this.Controls.Add(this.ledgerPanel);
            this.Controls.Add(this.projectOption);
            this.Controls.Add(this.newProjectButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProjectForm";
            this.Text = "ProjectForm";
            this.Load += new System.EventHandler(this.ProjectForm_Load);
            this.newProjectPanel.ResumeLayout(false);
            this.newProjectPanel.PerformLayout();
            this.ledgerPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linkupDatabaseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button newProjectButton;
        private Guna.UI2.WinForms.Guna2ComboBox projectOption;
        private Guna.UI2.WinForms.Guna2TextBox projectNameTextBox;
        private System.Windows.Forms.Label projectNameLabel;
        private Guna.UI2.WinForms.Guna2Button submitButton;
        private System.Windows.Forms.Label projectPanelLabel;
        private Guna.UI2.WinForms.Guna2Button closeProjectPanelButton;
        public Guna.UI2.WinForms.Guna2Panel newProjectPanel;
        private Guna.UI2.WinForms.Guna2Panel ledgerPanel;
        private Guna.UI2.WinForms.Guna2Button guna2Button3;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2DataGridView guna2DataGridView1;
        private LinkupDatabaseDataSet linkupDatabaseDataSet;
        private System.Windows.Forms.BindingSource projectsBindingSource;
        private LinkupDatabaseDataSetTableAdapters.ProjectsTableAdapter projectsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
    }
}