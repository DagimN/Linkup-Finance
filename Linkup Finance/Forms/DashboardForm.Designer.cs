
namespace Linkup_Finance.Forms
{
    partial class DashboardForm
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
            this.ledgerDashboardPanel = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.bankGradientPanel = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.pettyCashSolidGauge = new LiveCharts.WinForms.SolidGauge();
            this.bankTotalLabel = new System.Windows.Forms.Label();
            this.pettyCashLabel = new System.Windows.Forms.Label();
            this.numBanksLabel = new System.Windows.Forms.Label();
            this.balanceLabel = new System.Windows.Forms.Label();
            this.bankPieChart = new LiveCharts.WinForms.PieChart();
            this.zoomTrackBar = new Guna.UI2.WinForms.Guna2TrackBar();
            this.transactionDateSelection = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.transactionChart = new LiveCharts.WinForms.CartesianChart();
            this.employeeDashboardPanel = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.guna2GradientPanel2 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.totalBonusLabel = new System.Windows.Forms.Label();
            this.totalPensionLabel = new System.Windows.Forms.Label();
            this.totalTaxLabel = new System.Windows.Forms.Label();
            this.totalNetLabel = new System.Windows.Forms.Label();
            this.payrollDateSelection = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.paidEmployeesCountLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.employeeAmountLabel = new System.Windows.Forms.Label();
            this.profilePictureBox = new System.Windows.Forms.PictureBox();
            this.payrollChart = new LiveCharts.WinForms.CartesianChart();
            this.loginDashboardPanel = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.welcomeNameLabel = new System.Windows.Forms.Label();
            this.logoutButton = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.employeeToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.ledgerDashboardPanel.SuspendLayout();
            this.bankGradientPanel.SuspendLayout();
            this.employeeDashboardPanel.SuspendLayout();
            this.guna2GradientPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.profilePictureBox)).BeginInit();
            this.loginDashboardPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ledgerDashboardPanel
            // 
            this.ledgerDashboardPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ledgerDashboardPanel.BackColor = System.Drawing.Color.Transparent;
            this.ledgerDashboardPanel.Controls.Add(this.bankGradientPanel);
            this.ledgerDashboardPanel.Controls.Add(this.zoomTrackBar);
            this.ledgerDashboardPanel.Controls.Add(this.transactionDateSelection);
            this.ledgerDashboardPanel.Controls.Add(this.transactionChart);
            this.ledgerDashboardPanel.FillColor = System.Drawing.Color.White;
            this.ledgerDashboardPanel.Location = new System.Drawing.Point(12, 12);
            this.ledgerDashboardPanel.Name = "ledgerDashboardPanel";
            this.ledgerDashboardPanel.ShadowColor = System.Drawing.Color.Black;
            this.ledgerDashboardPanel.Size = new System.Drawing.Size(1176, 241);
            this.ledgerDashboardPanel.TabIndex = 0;
            // 
            // bankGradientPanel
            // 
            this.bankGradientPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bankGradientPanel.BorderRadius = 10;
            this.bankGradientPanel.Controls.Add(this.pettyCashSolidGauge);
            this.bankGradientPanel.Controls.Add(this.bankTotalLabel);
            this.bankGradientPanel.Controls.Add(this.pettyCashLabel);
            this.bankGradientPanel.Controls.Add(this.numBanksLabel);
            this.bankGradientPanel.Controls.Add(this.balanceLabel);
            this.bankGradientPanel.Controls.Add(this.bankPieChart);
            this.bankGradientPanel.CustomizableEdges.BottomLeft = false;
            this.bankGradientPanel.CustomizableEdges.TopLeft = false;
            this.bankGradientPanel.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(100)))), ((int)(((byte)(115)))));
            this.bankGradientPanel.ForeColor = System.Drawing.Color.White;
            this.bankGradientPanel.Location = new System.Drawing.Point(558, 3);
            this.bankGradientPanel.Name = "bankGradientPanel";
            this.bankGradientPanel.ShadowDecoration.Parent = this.bankGradientPanel;
            this.bankGradientPanel.Size = new System.Drawing.Size(618, 235);
            this.bankGradientPanel.TabIndex = 0;
            // 
            // pettyCashSolidGauge
            // 
            this.pettyCashSolidGauge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pettyCashSolidGauge.Font = new System.Drawing.Font("Microsoft JhengHei UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pettyCashSolidGauge.Location = new System.Drawing.Point(431, 91);
            this.pettyCashSolidGauge.Name = "pettyCashSolidGauge";
            this.pettyCashSolidGauge.Size = new System.Drawing.Size(117, 71);
            this.pettyCashSolidGauge.TabIndex = 5;
            this.pettyCashSolidGauge.Text = "solidGauge1";
            // 
            // bankTotalLabel
            // 
            this.bankTotalLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bankTotalLabel.AutoSize = true;
            this.bankTotalLabel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bankTotalLabel.ForeColor = System.Drawing.Color.White;
            this.bankTotalLabel.Location = new System.Drawing.Point(389, 206);
            this.bankTotalLabel.Name = "bankTotalLabel";
            this.bankTotalLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bankTotalLabel.Size = new System.Drawing.Size(170, 18);
            this.bankTotalLabel.TabIndex = 4;
            this.bankTotalLabel.Text = "Total   1000000000 ETB";
            // 
            // pettyCashLabel
            // 
            this.pettyCashLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pettyCashLabel.AutoSize = true;
            this.pettyCashLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pettyCashLabel.ForeColor = System.Drawing.Color.White;
            this.pettyCashLabel.Location = new System.Drawing.Point(389, 73);
            this.pettyCashLabel.Name = "pettyCashLabel";
            this.pettyCashLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.pettyCashLabel.Size = new System.Drawing.Size(168, 15);
            this.pettyCashLabel.TabIndex = 3;
            this.pettyCashLabel.Text = "Petty Cash Remaining   5000";
            // 
            // numBanksLabel
            // 
            this.numBanksLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numBanksLabel.AutoSize = true;
            this.numBanksLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numBanksLabel.ForeColor = System.Drawing.Color.White;
            this.numBanksLabel.Location = new System.Drawing.Point(389, 48);
            this.numBanksLabel.Name = "numBanksLabel";
            this.numBanksLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.numBanksLabel.Size = new System.Drawing.Size(158, 15);
            this.numBanksLabel.TabIndex = 2;
            this.numBanksLabel.Text = "Bank Accounts Owned   11";
            // 
            // balanceLabel
            // 
            this.balanceLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.balanceLabel.AutoSize = true;
            this.balanceLabel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.balanceLabel.ForeColor = System.Drawing.Color.White;
            this.balanceLabel.Location = new System.Drawing.Point(370, 15);
            this.balanceLabel.Name = "balanceLabel";
            this.balanceLabel.Size = new System.Drawing.Size(65, 18);
            this.balanceLabel.TabIndex = 1;
            this.balanceLabel.Text = "Balance";
            // 
            // bankPieChart
            // 
            this.bankPieChart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bankPieChart.BackColorTransparent = true;
            this.bankPieChart.Location = new System.Drawing.Point(3, 15);
            this.bankPieChart.Name = "bankPieChart";
            this.bankPieChart.Size = new System.Drawing.Size(360, 209);
            this.bankPieChart.TabIndex = 0;
            this.bankPieChart.Text = "pieChart1";
            // 
            // zoomTrackBar
            // 
            this.zoomTrackBar.HoverState.Parent = this.zoomTrackBar;
            this.zoomTrackBar.Location = new System.Drawing.Point(310, 25);
            this.zoomTrackBar.Name = "zoomTrackBar";
            this.zoomTrackBar.Size = new System.Drawing.Size(242, 23);
            this.zoomTrackBar.TabIndex = 22;
            this.zoomTrackBar.ThumbColor = System.Drawing.Color.DodgerBlue;
            this.zoomTrackBar.Value = 99;
            this.zoomTrackBar.ValueChanged += new System.EventHandler(this.zoomTrackBar_ValueChanged);
            // 
            // transactionDateSelection
            // 
            this.transactionDateSelection.BorderRadius = 5;
            this.transactionDateSelection.CheckedState.Parent = this.transactionDateSelection;
            this.transactionDateSelection.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(220)))), ((int)(((byte)(230)))));
            this.transactionDateSelection.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.transactionDateSelection.ForeColor = System.Drawing.Color.Black;
            this.transactionDateSelection.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.transactionDateSelection.HoverState.Parent = this.transactionDateSelection;
            this.transactionDateSelection.Location = new System.Drawing.Point(19, 18);
            this.transactionDateSelection.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.transactionDateSelection.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.transactionDateSelection.Name = "transactionDateSelection";
            this.transactionDateSelection.ShadowDecoration.Parent = this.transactionDateSelection;
            this.transactionDateSelection.Size = new System.Drawing.Size(222, 36);
            this.transactionDateSelection.TabIndex = 21;
            this.transactionDateSelection.Value = new System.DateTime(2021, 9, 19, 20, 28, 51, 470);
            this.transactionDateSelection.ValueChanged += new System.EventHandler(this.transactionDateSelection_ValueChanged);
            // 
            // transactionChart
            // 
            this.transactionChart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.transactionChart.Location = new System.Drawing.Point(19, 60);
            this.transactionChart.Name = "transactionChart";
            this.transactionChart.Size = new System.Drawing.Size(533, 167);
            this.transactionChart.TabIndex = 0;
            this.transactionChart.Text = "cartesianChart1";
            // 
            // employeeDashboardPanel
            // 
            this.employeeDashboardPanel.BackColor = System.Drawing.Color.Transparent;
            this.employeeDashboardPanel.Controls.Add(this.guna2GradientPanel2);
            this.employeeDashboardPanel.Controls.Add(this.payrollDateSelection);
            this.employeeDashboardPanel.Controls.Add(this.paidEmployeesCountLabel);
            this.employeeDashboardPanel.Controls.Add(this.pictureBox1);
            this.employeeDashboardPanel.Controls.Add(this.employeeAmountLabel);
            this.employeeDashboardPanel.Controls.Add(this.profilePictureBox);
            this.employeeDashboardPanel.Controls.Add(this.payrollChart);
            this.employeeDashboardPanel.FillColor = System.Drawing.Color.White;
            this.employeeDashboardPanel.Location = new System.Drawing.Point(12, 259);
            this.employeeDashboardPanel.Name = "employeeDashboardPanel";
            this.employeeDashboardPanel.ShadowColor = System.Drawing.Color.Black;
            this.employeeDashboardPanel.Size = new System.Drawing.Size(623, 241);
            this.employeeDashboardPanel.TabIndex = 1;
            // 
            // guna2GradientPanel2
            // 
            this.guna2GradientPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2GradientPanel2.BorderRadius = 5;
            this.guna2GradientPanel2.Controls.Add(this.totalBonusLabel);
            this.guna2GradientPanel2.Controls.Add(this.totalPensionLabel);
            this.guna2GradientPanel2.Controls.Add(this.totalTaxLabel);
            this.guna2GradientPanel2.Controls.Add(this.totalNetLabel);
            this.guna2GradientPanel2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(70)))), ((int)(((byte)(115)))));
            this.guna2GradientPanel2.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(100)))), ((int)(((byte)(115)))));
            this.guna2GradientPanel2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.guna2GradientPanel2.Location = new System.Drawing.Point(19, 96);
            this.guna2GradientPanel2.Name = "guna2GradientPanel2";
            this.guna2GradientPanel2.ShadowDecoration.Parent = this.guna2GradientPanel2;
            this.guna2GradientPanel2.Size = new System.Drawing.Size(589, 29);
            this.guna2GradientPanel2.TabIndex = 0;
            // 
            // totalBonusLabel
            // 
            this.totalBonusLabel.AutoSize = true;
            this.totalBonusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalBonusLabel.ForeColor = System.Drawing.Color.White;
            this.totalBonusLabel.Location = new System.Drawing.Point(3, 10);
            this.totalBonusLabel.Name = "totalBonusLabel";
            this.totalBonusLabel.Size = new System.Drawing.Size(128, 13);
            this.totalBonusLabel.TabIndex = 6;
            this.totalBonusLabel.Text = "Total Bonus: 1000000000";
            // 
            // totalPensionLabel
            // 
            this.totalPensionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.totalPensionLabel.AutoSize = true;
            this.totalPensionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalPensionLabel.ForeColor = System.Drawing.Color.White;
            this.totalPensionLabel.Location = new System.Drawing.Point(435, 10);
            this.totalPensionLabel.Name = "totalPensionLabel";
            this.totalPensionLabel.Size = new System.Drawing.Size(136, 13);
            this.totalPensionLabel.TabIndex = 3;
            this.totalPensionLabel.Text = "Total Pension: 1000000000";
            // 
            // totalTaxLabel
            // 
            this.totalTaxLabel.AutoSize = true;
            this.totalTaxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalTaxLabel.ForeColor = System.Drawing.Color.White;
            this.totalTaxLabel.Location = new System.Drawing.Point(137, 10);
            this.totalTaxLabel.Name = "totalTaxLabel";
            this.totalTaxLabel.Size = new System.Drawing.Size(151, 13);
            this.totalTaxLabel.TabIndex = 5;
            this.totalTaxLabel.Text = "Total Income Tax: 1000000000";
            // 
            // totalNetLabel
            // 
            this.totalNetLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.totalNetLabel.AutoSize = true;
            this.totalNetLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalNetLabel.ForeColor = System.Drawing.Color.White;
            this.totalNetLabel.Location = new System.Drawing.Point(294, 10);
            this.totalNetLabel.Name = "totalNetLabel";
            this.totalNetLabel.Size = new System.Drawing.Size(135, 13);
            this.totalNetLabel.TabIndex = 4;
            this.totalNetLabel.Text = "Total Net Pay: 1000000000";
            // 
            // payrollDateSelection
            // 
            this.payrollDateSelection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.payrollDateSelection.BorderRadius = 5;
            this.payrollDateSelection.CheckedState.Parent = this.payrollDateSelection;
            this.payrollDateSelection.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(220)))), ((int)(((byte)(230)))));
            this.payrollDateSelection.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.payrollDateSelection.ForeColor = System.Drawing.Color.Black;
            this.payrollDateSelection.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.payrollDateSelection.HoverState.Parent = this.payrollDateSelection;
            this.payrollDateSelection.Location = new System.Drawing.Point(183, 13);
            this.payrollDateSelection.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.payrollDateSelection.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.payrollDateSelection.Name = "payrollDateSelection";
            this.payrollDateSelection.ShadowDecoration.Parent = this.payrollDateSelection;
            this.payrollDateSelection.Size = new System.Drawing.Size(222, 36);
            this.payrollDateSelection.TabIndex = 22;
            this.payrollDateSelection.Value = new System.DateTime(2021, 9, 19, 20, 28, 51, 470);
            this.payrollDateSelection.ValueChanged += new System.EventHandler(this.payrollDateSelection_ValueChanged);
            // 
            // paidEmployeesCountLabel
            // 
            this.paidEmployeesCountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.paidEmployeesCountLabel.AutoSize = true;
            this.paidEmployeesCountLabel.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paidEmployeesCountLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(70)))), ((int)(((byte)(115)))));
            this.paidEmployeesCountLabel.Location = new System.Drawing.Point(537, 39);
            this.paidEmployeesCountLabel.Name = "paidEmployeesCountLabel";
            this.paidEmployeesCountLabel.Size = new System.Drawing.Size(53, 28);
            this.paidEmployeesCountLabel.TabIndex = 7;
            this.paidEmployeesCountLabel.Text = "7/11";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::Linkup_Finance.Properties.Resources.Salary_Icon;
            this.pictureBox1.Location = new System.Drawing.Point(428, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(124, 77);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            this.employeeToolTip.SetToolTip(this.pictureBox1, "Number of Employees Salary Paid");
            // 
            // employeeAmountLabel
            // 
            this.employeeAmountLabel.AutoSize = true;
            this.employeeAmountLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employeeAmountLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(70)))), ((int)(((byte)(115)))));
            this.employeeAmountLabel.Location = new System.Drawing.Point(101, 32);
            this.employeeAmountLabel.Name = "employeeAmountLabel";
            this.employeeAmountLabel.Size = new System.Drawing.Size(62, 37);
            this.employeeAmountLabel.TabIndex = 2;
            this.employeeAmountLabel.Text = "259";
            // 
            // profilePictureBox
            // 
            this.profilePictureBox.Image = global::Linkup_Finance.Properties.Resources.Profile_Icon;
            this.profilePictureBox.Location = new System.Drawing.Point(19, 13);
            this.profilePictureBox.Name = "profilePictureBox";
            this.profilePictureBox.Size = new System.Drawing.Size(76, 77);
            this.profilePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.profilePictureBox.TabIndex = 1;
            this.profilePictureBox.TabStop = false;
            this.employeeToolTip.SetToolTip(this.profilePictureBox, "Number of Employees");
            // 
            // payrollChart
            // 
            this.payrollChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.payrollChart.Location = new System.Drawing.Point(19, 131);
            this.payrollChart.Name = "payrollChart";
            this.payrollChart.Size = new System.Drawing.Size(589, 98);
            this.payrollChart.TabIndex = 0;
            this.payrollChart.Text = "cartesianChart1";
            // 
            // loginDashboardPanel
            // 
            this.loginDashboardPanel.BackColor = System.Drawing.Color.Transparent;
            this.loginDashboardPanel.Controls.Add(this.welcomeNameLabel);
            this.loginDashboardPanel.Controls.Add(this.logoutButton);
            this.loginDashboardPanel.Controls.Add(this.guna2Button2);
            this.loginDashboardPanel.Controls.Add(this.guna2Button1);
            this.loginDashboardPanel.Controls.Add(this.welcomeLabel);
            this.loginDashboardPanel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(100)))), ((int)(((byte)(115)))));
            this.loginDashboardPanel.Location = new System.Drawing.Point(641, 259);
            this.loginDashboardPanel.Name = "loginDashboardPanel";
            this.loginDashboardPanel.ShadowColor = System.Drawing.Color.Black;
            this.loginDashboardPanel.Size = new System.Drawing.Size(547, 241);
            this.loginDashboardPanel.TabIndex = 2;
            // 
            // welcomeNameLabel
            // 
            this.welcomeNameLabel.AutoSize = true;
            this.welcomeNameLabel.Font = new System.Drawing.Font("Microsoft JhengHei UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeNameLabel.ForeColor = System.Drawing.Color.White;
            this.welcomeNameLabel.Location = new System.Drawing.Point(20, 96);
            this.welcomeNameLabel.Name = "welcomeNameLabel";
            this.welcomeNameLabel.Size = new System.Drawing.Size(0, 35);
            this.welcomeNameLabel.TabIndex = 4;
            // 
            // logoutButton
            // 
            this.logoutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.logoutButton.BorderRadius = 10;
            this.logoutButton.CheckedState.Parent = this.logoutButton;
            this.logoutButton.CustomImages.Parent = this.logoutButton;
            this.logoutButton.CustomizableEdges.BottomRight = false;
            this.logoutButton.CustomizableEdges.TopRight = false;
            this.logoutButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.logoutButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.logoutButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.logoutButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.logoutButton.DisabledState.Parent = this.logoutButton;
            this.logoutButton.FillColor = System.Drawing.Color.White;
            this.logoutButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.logoutButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(80)))), ((int)(((byte)(85)))));
            this.logoutButton.HoverState.Parent = this.logoutButton;
            this.logoutButton.Location = new System.Drawing.Point(413, 164);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.ShadowDecoration.Parent = this.logoutButton;
            this.logoutButton.Size = new System.Drawing.Size(128, 36);
            this.logoutButton.TabIndex = 3;
            this.logoutButton.Text = "Logout";
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // guna2Button2
            // 
            this.guna2Button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Button2.BorderRadius = 10;
            this.guna2Button2.CheckedState.Parent = this.guna2Button2;
            this.guna2Button2.CustomImages.Parent = this.guna2Button2;
            this.guna2Button2.CustomizableEdges.BottomRight = false;
            this.guna2Button2.CustomizableEdges.TopRight = false;
            this.guna2Button2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button2.DisabledState.Parent = this.guna2Button2;
            this.guna2Button2.FillColor = System.Drawing.Color.White;
            this.guna2Button2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(80)))), ((int)(((byte)(85)))));
            this.guna2Button2.HoverState.Parent = this.guna2Button2;
            this.guna2Button2.Location = new System.Drawing.Point(413, 64);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.ShadowDecoration.Parent = this.guna2Button2;
            this.guna2Button2.Size = new System.Drawing.Size(128, 36);
            this.guna2Button2.TabIndex = 2;
            this.guna2Button2.Text = "Export PDF";
            // 
            // guna2Button1
            // 
            this.guna2Button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Button1.BorderRadius = 10;
            this.guna2Button1.CheckedState.Parent = this.guna2Button1;
            this.guna2Button1.CustomImages.Parent = this.guna2Button1;
            this.guna2Button1.CustomizableEdges.BottomRight = false;
            this.guna2Button1.CustomizableEdges.TopRight = false;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.DisabledState.Parent = this.guna2Button1;
            this.guna2Button1.FillColor = System.Drawing.Color.White;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(80)))), ((int)(((byte)(85)))));
            this.guna2Button1.HoverState.Parent = this.guna2Button1;
            this.guna2Button1.Location = new System.Drawing.Point(413, 114);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
            this.guna2Button1.Size = new System.Drawing.Size(128, 36);
            this.guna2Button1.TabIndex = 1;
            this.guna2Button1.Text = "Export Excel";
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.AutoSize = true;
            this.welcomeLabel.Font = new System.Drawing.Font("Microsoft JhengHei UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeLabel.ForeColor = System.Drawing.Color.White;
            this.welcomeLabel.Location = new System.Drawing.Point(20, 55);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(137, 35);
            this.welcomeLabel.TabIndex = 0;
            this.welcomeLabel.Text = "Welcome";
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 516);
            this.Controls.Add(this.loginDashboardPanel);
            this.Controls.Add(this.employeeDashboardPanel);
            this.Controls.Add(this.ledgerDashboardPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DashboardForm";
            this.Text = "DashboardForm";
            this.Load += new System.EventHandler(this.DashboardForm_Load);
            this.ledgerDashboardPanel.ResumeLayout(false);
            this.bankGradientPanel.ResumeLayout(false);
            this.bankGradientPanel.PerformLayout();
            this.employeeDashboardPanel.ResumeLayout(false);
            this.employeeDashboardPanel.PerformLayout();
            this.guna2GradientPanel2.ResumeLayout(false);
            this.guna2GradientPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.profilePictureBox)).EndInit();
            this.loginDashboardPanel.ResumeLayout(false);
            this.loginDashboardPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ShadowPanel ledgerDashboardPanel;
        private Guna.UI2.WinForms.Guna2ShadowPanel employeeDashboardPanel;
        private Guna.UI2.WinForms.Guna2ShadowPanel loginDashboardPanel;
        private LiveCharts.WinForms.CartesianChart transactionChart;
        private Guna.UI2.WinForms.Guna2DateTimePicker transactionDateSelection;
        private Guna.UI2.WinForms.Guna2TrackBar zoomTrackBar;
        private Guna.UI2.WinForms.Guna2GradientPanel bankGradientPanel;
        private LiveCharts.WinForms.PieChart bankPieChart;
        private System.Windows.Forms.Label balanceLabel;
        private LiveCharts.WinForms.SolidGauge pettyCashSolidGauge;
        private System.Windows.Forms.Label bankTotalLabel;
        private System.Windows.Forms.Label pettyCashLabel;
        private System.Windows.Forms.Label numBanksLabel;
        private LiveCharts.WinForms.CartesianChart payrollChart;
        private System.Windows.Forms.Label totalPensionLabel;
        private System.Windows.Forms.Label employeeAmountLabel;
        private System.Windows.Forms.PictureBox profilePictureBox;
        private System.Windows.Forms.Label paidEmployeesCountLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label totalBonusLabel;
        private System.Windows.Forms.Label totalTaxLabel;
        private System.Windows.Forms.Label totalNetLabel;
        private System.Windows.Forms.ToolTip employeeToolTip;
        private Guna.UI2.WinForms.Guna2DateTimePicker payrollDateSelection;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel2;
        private Guna.UI2.WinForms.Guna2Button logoutButton;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        public System.Windows.Forms.Label welcomeNameLabel;
        private System.Windows.Forms.Label welcomeLabel;
    }
}