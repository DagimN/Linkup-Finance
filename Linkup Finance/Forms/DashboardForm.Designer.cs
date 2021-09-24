
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
            this.guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.transactionChart = new LiveCharts.WinForms.CartesianChart();
            this.guna2ShadowPanel2 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.guna2ShadowPanel3 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.transactionDateSelection = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.zoomTrackBar = new Guna.UI2.WinForms.Guna2TrackBar();
            this.bankPieChart = new LiveCharts.WinForms.PieChart();
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.guna2ShadowPanel1.SuspendLayout();
            this.guna2GradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2ShadowPanel1
            // 
            this.guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel1.Controls.Add(this.guna2GradientPanel1);
            this.guna2ShadowPanel1.Controls.Add(this.zoomTrackBar);
            this.guna2ShadowPanel1.Controls.Add(this.transactionDateSelection);
            this.guna2ShadowPanel1.Controls.Add(this.transactionChart);
            this.guna2ShadowPanel1.FillColor = System.Drawing.Color.White;
            this.guna2ShadowPanel1.Location = new System.Drawing.Point(12, 12);
            this.guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            this.guna2ShadowPanel1.ShadowColor = System.Drawing.Color.Black;
            this.guna2ShadowPanel1.Size = new System.Drawing.Size(1176, 241);
            this.guna2ShadowPanel1.TabIndex = 0;
            // 
            // transactionChart
            // 
            this.transactionChart.Location = new System.Drawing.Point(19, 60);
            this.transactionChart.Name = "transactionChart";
            this.transactionChart.Size = new System.Drawing.Size(533, 167);
            this.transactionChart.TabIndex = 0;
            this.transactionChart.Text = "cartesianChart1";
            // 
            // guna2ShadowPanel2
            // 
            this.guna2ShadowPanel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel2.FillColor = System.Drawing.Color.White;
            this.guna2ShadowPanel2.Location = new System.Drawing.Point(12, 259);
            this.guna2ShadowPanel2.Name = "guna2ShadowPanel2";
            this.guna2ShadowPanel2.ShadowColor = System.Drawing.Color.Black;
            this.guna2ShadowPanel2.Size = new System.Drawing.Size(552, 241);
            this.guna2ShadowPanel2.TabIndex = 1;
            // 
            // guna2ShadowPanel3
            // 
            this.guna2ShadowPanel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel3.FillColor = System.Drawing.Color.White;
            this.guna2ShadowPanel3.Location = new System.Drawing.Point(570, 259);
            this.guna2ShadowPanel3.Name = "guna2ShadowPanel3";
            this.guna2ShadowPanel3.ShadowColor = System.Drawing.Color.Black;
            this.guna2ShadowPanel3.Size = new System.Drawing.Size(618, 241);
            this.guna2ShadowPanel3.TabIndex = 2;
            // 
            // transactionDateSelection
            // 
            this.transactionDateSelection.BorderRadius = 5;
            this.transactionDateSelection.CheckedState.Parent = this.transactionDateSelection;
            this.transactionDateSelection.Font = new System.Drawing.Font("Segoe UI", 9F);
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
            // zoomTrackBar
            // 
            this.zoomTrackBar.HoverState.Parent = this.zoomTrackBar;
            this.zoomTrackBar.Location = new System.Drawing.Point(310, 25);
            this.zoomTrackBar.Name = "zoomTrackBar";
            this.zoomTrackBar.Size = new System.Drawing.Size(242, 23);
            this.zoomTrackBar.TabIndex = 22;
            this.zoomTrackBar.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(113)))), ((int)(((byte)(255)))));
            this.zoomTrackBar.Value = 99;
            this.zoomTrackBar.ValueChanged += new System.EventHandler(this.zoomTrackBar_ValueChanged);
            // 
            // bankPieChart
            // 
            this.bankPieChart.BackColorTransparent = true;
            this.bankPieChart.Location = new System.Drawing.Point(3, 15);
            this.bankPieChart.Name = "bankPieChart";
            this.bankPieChart.Size = new System.Drawing.Size(360, 209);
            this.bankPieChart.TabIndex = 0;
            this.bankPieChart.Text = "pieChart1";
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.BorderRadius = 10;
            this.guna2GradientPanel1.Controls.Add(this.bankPieChart);
            this.guna2GradientPanel1.CustomizableEdges.BottomLeft = false;
            this.guna2GradientPanel1.CustomizableEdges.TopLeft = false;
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(100)))), ((int)(((byte)(115)))));
            this.guna2GradientPanel1.Location = new System.Drawing.Point(558, 3);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.ShadowDecoration.Parent = this.guna2GradientPanel1;
            this.guna2GradientPanel1.Size = new System.Drawing.Size(618, 235);
            this.guna2GradientPanel1.TabIndex = 0;
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 516);
            this.Controls.Add(this.guna2ShadowPanel3);
            this.Controls.Add(this.guna2ShadowPanel2);
            this.Controls.Add(this.guna2ShadowPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DashboardForm";
            this.Text = "DashboardForm";
            this.Load += new System.EventHandler(this.DashboardForm_Load);
            this.guna2ShadowPanel1.ResumeLayout(false);
            this.guna2GradientPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel2;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel3;
        private LiveCharts.WinForms.CartesianChart transactionChart;
        private Guna.UI2.WinForms.Guna2DateTimePicker transactionDateSelection;
        private Guna.UI2.WinForms.Guna2TrackBar zoomTrackBar;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private LiveCharts.WinForms.PieChart bankPieChart;
    }
}