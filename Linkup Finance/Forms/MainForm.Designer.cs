
namespace Linkup_Finance
{
    partial class MainForm
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
            this.titleBarPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.maximizeButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.minimizeButton = new System.Windows.Forms.Button();
            this.settingsButton = new Guna.UI2.WinForms.Guna2Button();
            this.projectButton = new Guna.UI2.WinForms.Guna2Button();
            this.dashboardButton = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.workPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.titleBarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // titleBarPanel
            // 
            this.titleBarPanel.BackColor = System.Drawing.SystemColors.Control;
            this.titleBarPanel.BorderRadius = 10;
            this.titleBarPanel.Controls.Add(this.maximizeButton);
            this.titleBarPanel.Controls.Add(this.closeButton);
            this.titleBarPanel.Controls.Add(this.minimizeButton);
            this.titleBarPanel.Controls.Add(this.settingsButton);
            this.titleBarPanel.Controls.Add(this.projectButton);
            this.titleBarPanel.Controls.Add(this.dashboardButton);
            this.titleBarPanel.Controls.Add(this.label1);
            this.titleBarPanel.Controls.Add(this.pictureBox1);
            this.titleBarPanel.CustomizableEdges.TopLeft = false;
            this.titleBarPanel.CustomizableEdges.TopRight = false;
            this.titleBarPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleBarPanel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(100)))), ((int)(((byte)(115)))));
            this.titleBarPanel.Location = new System.Drawing.Point(0, 0);
            this.titleBarPanel.Name = "titleBarPanel";
            this.titleBarPanel.ShadowDecoration.Parent = this.titleBarPanel;
            this.titleBarPanel.Size = new System.Drawing.Size(1200, 70);
            this.titleBarPanel.TabIndex = 0;
            this.titleBarPanel.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.titleBarPanel_MouseDoubleClick);
            this.titleBarPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titleBarPanel_MouseDown);
            this.titleBarPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.titleBarPanel_MouseMove);
            this.titleBarPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.titleBarPanel_MouseUp);
            // 
            // maximizeButton
            // 
            this.maximizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.maximizeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(100)))), ((int)(((byte)(115)))));
            this.maximizeButton.FlatAppearance.BorderSize = 0;
            this.maximizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.maximizeButton.Image = global::Linkup_Finance.Properties.Resources.Maximize_Icon;
            this.maximizeButton.Location = new System.Drawing.Point(1101, 3);
            this.maximizeButton.Name = "maximizeButton";
            this.maximizeButton.Size = new System.Drawing.Size(45, 30);
            this.maximizeButton.TabIndex = 11;
            this.maximizeButton.UseVisualStyleBackColor = false;
            this.maximizeButton.Click += new System.EventHandler(this.maximizeButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(100)))), ((int)(((byte)(115)))));
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(75)))), ((int)(((byte)(70)))));
            this.closeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(50)))), ((int)(((byte)(40)))));
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Image = global::Linkup_Finance.Properties.Resources.Close_Icon;
            this.closeButton.Location = new System.Drawing.Point(1152, 3);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(45, 30);
            this.closeButton.TabIndex = 10;
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // minimizeButton
            // 
            this.minimizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minimizeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(100)))), ((int)(((byte)(115)))));
            this.minimizeButton.FlatAppearance.BorderSize = 0;
            this.minimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimizeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minimizeButton.Image = global::Linkup_Finance.Properties.Resources.Minimize_Icon;
            this.minimizeButton.Location = new System.Drawing.Point(1050, 3);
            this.minimizeButton.Name = "minimizeButton";
            this.minimizeButton.Size = new System.Drawing.Size(45, 30);
            this.minimizeButton.TabIndex = 9;
            this.minimizeButton.UseVisualStyleBackColor = false;
            this.minimizeButton.Click += new System.EventHandler(this.minimizeButton_Click);
            // 
            // settingsButton
            // 
            this.settingsButton.AutoRoundedCorners = true;
            this.settingsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(100)))), ((int)(((byte)(115)))));
            this.settingsButton.BorderRadius = 15;
            this.settingsButton.CheckedState.Parent = this.settingsButton;
            this.settingsButton.CustomImages.Parent = this.settingsButton;
            this.settingsButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.settingsButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.settingsButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.settingsButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.settingsButton.DisabledState.Parent = this.settingsButton;
            this.settingsButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(80)))), ((int)(((byte)(85)))));
            this.settingsButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.settingsButton.ForeColor = System.Drawing.Color.White;
            this.settingsButton.HoverState.Parent = this.settingsButton;
            this.settingsButton.Location = new System.Drawing.Point(468, 21);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.ShadowDecoration.Parent = this.settingsButton;
            this.settingsButton.Size = new System.Drawing.Size(143, 32);
            this.settingsButton.TabIndex = 8;
            this.settingsButton.Text = "Settings";
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // projectButton
            // 
            this.projectButton.AutoRoundedCorners = true;
            this.projectButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(100)))), ((int)(((byte)(115)))));
            this.projectButton.BorderRadius = 15;
            this.projectButton.CheckedState.Parent = this.projectButton;
            this.projectButton.CustomImages.Parent = this.projectButton;
            this.projectButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.projectButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.projectButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.projectButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.projectButton.DisabledState.Parent = this.projectButton;
            this.projectButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(80)))), ((int)(((byte)(85)))));
            this.projectButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.projectButton.ForeColor = System.Drawing.Color.White;
            this.projectButton.HoverState.Parent = this.projectButton;
            this.projectButton.Location = new System.Drawing.Point(319, 21);
            this.projectButton.Name = "projectButton";
            this.projectButton.ShadowDecoration.Parent = this.projectButton;
            this.projectButton.Size = new System.Drawing.Size(143, 32);
            this.projectButton.TabIndex = 7;
            this.projectButton.Text = "Projects";
            this.projectButton.Click += new System.EventHandler(this.projectButton_Click);
            // 
            // dashboardButton
            // 
            this.dashboardButton.AutoRoundedCorners = true;
            this.dashboardButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(100)))), ((int)(((byte)(115)))));
            this.dashboardButton.BorderRadius = 15;
            this.dashboardButton.CheckedState.Parent = this.dashboardButton;
            this.dashboardButton.CustomImages.Parent = this.dashboardButton;
            this.dashboardButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.dashboardButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.dashboardButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.dashboardButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.dashboardButton.DisabledState.Parent = this.dashboardButton;
            this.dashboardButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(80)))), ((int)(((byte)(85)))));
            this.dashboardButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dashboardButton.ForeColor = System.Drawing.Color.White;
            this.dashboardButton.HoverState.Parent = this.dashboardButton;
            this.dashboardButton.Location = new System.Drawing.Point(170, 21);
            this.dashboardButton.Name = "dashboardButton";
            this.dashboardButton.ShadowDecoration.Parent = this.dashboardButton;
            this.dashboardButton.Size = new System.Drawing.Size(143, 32);
            this.dashboardButton.TabIndex = 6;
            this.dashboardButton.Text = "Dashboard";
            this.dashboardButton.Click += new System.EventHandler(this.dashboardButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(100)))), ((int)(((byte)(115)))));
            this.label1.Location = new System.Drawing.Point(93, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "FINANCE";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Linkup_Finance.Properties.Resources.Linkup_Logo;
            this.pictureBox1.Location = new System.Drawing.Point(22, -13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(124, 106);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // workPanel
            // 
            this.workPanel.BackColor = System.Drawing.Color.Silver;
            this.workPanel.Location = new System.Drawing.Point(0, 71);
            this.workPanel.Name = "workPanel";
            this.workPanel.ShadowDecoration.Parent = this.workPanel;
            this.workPanel.Size = new System.Drawing.Size(1200, 516);
            this.workPanel.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 586);
            this.Controls.Add(this.workPanel);
            this.Controls.Add(this.titleBarPanel);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.Info;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.titleBarPanel.ResumeLayout(false);
            this.titleBarPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel titleBarPanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2Button settingsButton;
        private Guna.UI2.WinForms.Guna2Button projectButton;
        private Guna.UI2.WinForms.Guna2Button dashboardButton;
        private System.Windows.Forms.Button minimizeButton;
        private System.Windows.Forms.Button maximizeButton;
        private System.Windows.Forms.Button closeButton;
        private Guna.UI2.WinForms.Guna2Panel workPanel;
        private System.Windows.Forms.Label label1;
    }
}

