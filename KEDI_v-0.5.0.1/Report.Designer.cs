namespace KEDI_v_0._5._0._1
{
    partial class Report
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
            this.topPanel = new MetroFramework.Controls.MetroPanel();
            this.back = new MetroFramework.Controls.MetroTile();
            this.username = new MetroFramework.Controls.MetroTile();
            this.selectionPanel = new MetroFramework.Controls.MetroPanel();
            this.monthlyReport = new MetroFramework.Controls.MetroTile();
            this.weeklyReport = new MetroFramework.Controls.MetroTile();
            this.dailyReport = new MetroFramework.Controls.MetroTile();
            this.dataPanel = new MetroFramework.Controls.MetroPanel();
            this.listPanel = new MetroFramework.Controls.MetroPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.printPanel = new MetroFramework.Controls.MetroPanel();
            this.pdfPrint = new MetroFramework.Controls.MetroTile();
            this.metroPanel7 = new MetroFramework.Controls.MetroPanel();
            this.excelPrint = new MetroFramework.Controls.MetroTile();
            this.metroPanel6 = new MetroFramework.Controls.MetroPanel();
            this.print = new MetroFramework.Controls.MetroTile();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.timespanSelection = new MetroFramework.Controls.MetroTile();
            this.timespanPanel = new MetroFramework.Controls.MetroPanel();
            this.startTimeSpan = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.endTimeSpan = new System.Windows.Forms.DateTimePicker();
            this.topPanel.SuspendLayout();
            this.selectionPanel.SuspendLayout();
            this.dataPanel.SuspendLayout();
            this.listPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.printPanel.SuspendLayout();
            this.metroPanel1.SuspendLayout();
            this.timespanPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.back);
            this.topPanel.Controls.Add(this.username);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.HorizontalScrollbarBarColor = true;
            this.topPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.topPanel.HorizontalScrollbarSize = 10;
            this.topPanel.Location = new System.Drawing.Point(0, 60);
            this.topPanel.Name = "topPanel";
            this.topPanel.Padding = new System.Windows.Forms.Padding(0, 3, 10, 3);
            this.topPanel.Size = new System.Drawing.Size(800, 44);
            this.topPanel.TabIndex = 0;
            this.topPanel.VerticalScrollbarBarColor = true;
            this.topPanel.VerticalScrollbarHighlightOnWheel = false;
            this.topPanel.VerticalScrollbarSize = 10;
            // 
            // back
            // 
            this.back.ActiveControl = null;
            this.back.Dock = System.Windows.Forms.DockStyle.Left;
            this.back.Location = new System.Drawing.Point(0, 3);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(75, 38);
            this.back.Style = MetroFramework.MetroColorStyle.Red;
            this.back.TabIndex = 3;
            this.back.Text = "Geri";
            this.back.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.back.UseSelectable = true;
            this.back.UseStyleColors = true;
            // 
            // username
            // 
            this.username.ActiveControl = null;
            this.username.Dock = System.Windows.Forms.DockStyle.Right;
            this.username.Location = new System.Drawing.Point(630, 3);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(160, 38);
            this.username.TabIndex = 2;
            this.username.Text = "Kullanici Adi";
            this.username.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.username.UseSelectable = true;
            // 
            // selectionPanel
            // 
            this.selectionPanel.BackColor = System.Drawing.Color.Silver;
            this.selectionPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.selectionPanel.Controls.Add(this.metroPanel1);
            this.selectionPanel.Controls.Add(this.monthlyReport);
            this.selectionPanel.Controls.Add(this.weeklyReport);
            this.selectionPanel.Controls.Add(this.dailyReport);
            this.selectionPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.selectionPanel.HorizontalScrollbarBarColor = true;
            this.selectionPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.selectionPanel.HorizontalScrollbarSize = 10;
            this.selectionPanel.Location = new System.Drawing.Point(0, 104);
            this.selectionPanel.Name = "selectionPanel";
            this.selectionPanel.Size = new System.Drawing.Size(163, 346);
            this.selectionPanel.TabIndex = 1;
            this.selectionPanel.VerticalScrollbarBarColor = true;
            this.selectionPanel.VerticalScrollbarHighlightOnWheel = false;
            this.selectionPanel.VerticalScrollbarSize = 10;
            // 
            // monthlyReport
            // 
            this.monthlyReport.ActiveControl = null;
            this.monthlyReport.Dock = System.Windows.Forms.DockStyle.Top;
            this.monthlyReport.Location = new System.Drawing.Point(0, 82);
            this.monthlyReport.Name = "monthlyReport";
            this.monthlyReport.Size = new System.Drawing.Size(161, 41);
            this.monthlyReport.Style = MetroFramework.MetroColorStyle.Purple;
            this.monthlyReport.TabIndex = 4;
            this.monthlyReport.Text = "Aylık Rapor";
            this.monthlyReport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.monthlyReport.UseSelectable = true;
            this.monthlyReport.UseStyleColors = true;
            this.monthlyReport.Click += new System.EventHandler(this.Report_Click);
            // 
            // weeklyReport
            // 
            this.weeklyReport.ActiveControl = null;
            this.weeklyReport.Dock = System.Windows.Forms.DockStyle.Top;
            this.weeklyReport.Location = new System.Drawing.Point(0, 41);
            this.weeklyReport.Name = "weeklyReport";
            this.weeklyReport.Size = new System.Drawing.Size(161, 41);
            this.weeklyReport.Style = MetroFramework.MetroColorStyle.Orange;
            this.weeklyReport.TabIndex = 3;
            this.weeklyReport.Text = "Haftalık Rapor";
            this.weeklyReport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.weeklyReport.UseSelectable = true;
            this.weeklyReport.UseStyleColors = true;
            this.weeklyReport.Click += new System.EventHandler(this.Report_Click);
            // 
            // dailyReport
            // 
            this.dailyReport.ActiveControl = null;
            this.dailyReport.Dock = System.Windows.Forms.DockStyle.Top;
            this.dailyReport.Location = new System.Drawing.Point(0, 0);
            this.dailyReport.Name = "dailyReport";
            this.dailyReport.Size = new System.Drawing.Size(161, 41);
            this.dailyReport.Style = MetroFramework.MetroColorStyle.Green;
            this.dailyReport.TabIndex = 2;
            this.dailyReport.Text = "Günsonu Raporu";
            this.dailyReport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.dailyReport.UseSelectable = true;
            this.dailyReport.UseStyleColors = true;
            this.dailyReport.Click += new System.EventHandler(this.Report_Click);
            // 
            // dataPanel
            // 
            this.dataPanel.Controls.Add(this.listPanel);
            this.dataPanel.Controls.Add(this.printPanel);
            this.dataPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataPanel.HorizontalScrollbarBarColor = true;
            this.dataPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.dataPanel.HorizontalScrollbarSize = 10;
            this.dataPanel.Location = new System.Drawing.Point(163, 104);
            this.dataPanel.Name = "dataPanel";
            this.dataPanel.Size = new System.Drawing.Size(637, 346);
            this.dataPanel.TabIndex = 2;
            this.dataPanel.VerticalScrollbarBarColor = true;
            this.dataPanel.VerticalScrollbarHighlightOnWheel = false;
            this.dataPanel.VerticalScrollbarSize = 10;
            // 
            // listPanel
            // 
            this.listPanel.Controls.Add(this.dataGridView1);
            this.listPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listPanel.HorizontalScrollbarBarColor = true;
            this.listPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.listPanel.HorizontalScrollbarSize = 10;
            this.listPanel.Location = new System.Drawing.Point(0, 52);
            this.listPanel.Name = "listPanel";
            this.listPanel.Size = new System.Drawing.Size(637, 294);
            this.listPanel.TabIndex = 3;
            this.listPanel.VerticalScrollbarBarColor = true;
            this.listPanel.VerticalScrollbarHighlightOnWheel = false;
            this.listPanel.VerticalScrollbarSize = 10;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(637, 294);
            this.dataGridView1.TabIndex = 2;
            // 
            // printPanel
            // 
            this.printPanel.BackColor = System.Drawing.Color.Silver;
            this.printPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.printPanel.Controls.Add(this.pdfPrint);
            this.printPanel.Controls.Add(this.metroPanel7);
            this.printPanel.Controls.Add(this.excelPrint);
            this.printPanel.Controls.Add(this.metroPanel6);
            this.printPanel.Controls.Add(this.print);
            this.printPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.printPanel.HorizontalScrollbarBarColor = true;
            this.printPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.printPanel.HorizontalScrollbarSize = 10;
            this.printPanel.Location = new System.Drawing.Point(0, 0);
            this.printPanel.Name = "printPanel";
            this.printPanel.Padding = new System.Windows.Forms.Padding(3, 3, 22, 3);
            this.printPanel.Size = new System.Drawing.Size(637, 52);
            this.printPanel.TabIndex = 2;
            this.printPanel.VerticalScrollbarBarColor = true;
            this.printPanel.VerticalScrollbarHighlightOnWheel = false;
            this.printPanel.VerticalScrollbarSize = 10;
            // 
            // pdfPrint
            // 
            this.pdfPrint.ActiveControl = null;
            this.pdfPrint.Dock = System.Windows.Forms.DockStyle.Right;
            this.pdfPrint.Location = new System.Drawing.Point(305, 3);
            this.pdfPrint.Name = "pdfPrint";
            this.pdfPrint.Size = new System.Drawing.Size(75, 44);
            this.pdfPrint.Style = MetroFramework.MetroColorStyle.Red;
            this.pdfPrint.TabIndex = 7;
            this.pdfPrint.Text = "PDF";
            this.pdfPrint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.pdfPrint.UseSelectable = true;
            this.pdfPrint.UseStyleColors = true;
            // 
            // metroPanel7
            // 
            this.metroPanel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.metroPanel7.HorizontalScrollbarBarColor = true;
            this.metroPanel7.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel7.HorizontalScrollbarSize = 10;
            this.metroPanel7.Location = new System.Drawing.Point(380, 3);
            this.metroPanel7.Name = "metroPanel7";
            this.metroPanel7.Size = new System.Drawing.Size(22, 44);
            this.metroPanel7.TabIndex = 6;
            this.metroPanel7.VerticalScrollbarBarColor = true;
            this.metroPanel7.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel7.VerticalScrollbarSize = 10;
            // 
            // excelPrint
            // 
            this.excelPrint.ActiveControl = null;
            this.excelPrint.Dock = System.Windows.Forms.DockStyle.Right;
            this.excelPrint.Location = new System.Drawing.Point(402, 3);
            this.excelPrint.Name = "excelPrint";
            this.excelPrint.Size = new System.Drawing.Size(75, 44);
            this.excelPrint.Style = MetroFramework.MetroColorStyle.Green;
            this.excelPrint.TabIndex = 5;
            this.excelPrint.Text = "Excel";
            this.excelPrint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.excelPrint.UseSelectable = true;
            this.excelPrint.UseStyleColors = true;
            // 
            // metroPanel6
            // 
            this.metroPanel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.metroPanel6.HorizontalScrollbarBarColor = true;
            this.metroPanel6.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel6.HorizontalScrollbarSize = 10;
            this.metroPanel6.Location = new System.Drawing.Point(477, 3);
            this.metroPanel6.Name = "metroPanel6";
            this.metroPanel6.Size = new System.Drawing.Size(22, 44);
            this.metroPanel6.TabIndex = 3;
            this.metroPanel6.VerticalScrollbarBarColor = true;
            this.metroPanel6.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel6.VerticalScrollbarSize = 10;
            // 
            // print
            // 
            this.print.ActiveControl = null;
            this.print.Dock = System.Windows.Forms.DockStyle.Right;
            this.print.Location = new System.Drawing.Point(499, 3);
            this.print.Name = "print";
            this.print.Size = new System.Drawing.Size(114, 44);
            this.print.Style = MetroFramework.MetroColorStyle.Yellow;
            this.print.TabIndex = 2;
            this.print.Text = "Yazdır";
            this.print.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.print.UseSelectable = true;
            this.print.UseStyleColors = true;
            // 
            // metroPanel1
            // 
            this.metroPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroPanel1.Controls.Add(this.timespanPanel);
            this.metroPanel1.Controls.Add(this.timespanSelection);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(0, 123);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(161, 75);
            this.metroPanel1.TabIndex = 6;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // timespanSelection
            // 
            this.timespanSelection.ActiveControl = null;
            this.timespanSelection.Dock = System.Windows.Forms.DockStyle.Top;
            this.timespanSelection.Location = new System.Drawing.Point(0, 0);
            this.timespanSelection.Name = "timespanSelection";
            this.timespanSelection.Size = new System.Drawing.Size(159, 41);
            this.timespanSelection.Style = MetroFramework.MetroColorStyle.Teal;
            this.timespanSelection.TabIndex = 6;
            this.timespanSelection.Text = "Zaman Aralığı Seçimi";
            this.timespanSelection.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.timespanSelection.UseSelectable = true;
            this.timespanSelection.UseStyleColors = true;
            // 
            // timespanPanel
            // 
            this.timespanPanel.Controls.Add(this.endTimeSpan);
            this.timespanPanel.Controls.Add(this.label1);
            this.timespanPanel.Controls.Add(this.startTimeSpan);
            this.timespanPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.timespanPanel.HorizontalScrollbarBarColor = true;
            this.timespanPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.timespanPanel.HorizontalScrollbarSize = 10;
            this.timespanPanel.Location = new System.Drawing.Point(0, 41);
            this.timespanPanel.Name = "timespanPanel";
            this.timespanPanel.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.timespanPanel.Size = new System.Drawing.Size(159, 30);
            this.timespanPanel.TabIndex = 7;
            this.timespanPanel.VerticalScrollbarBarColor = true;
            this.timespanPanel.VerticalScrollbarHighlightOnWheel = false;
            this.timespanPanel.VerticalScrollbarSize = 10;
            this.timespanPanel.Visible = false;
            // 
            // startTimeSpan
            // 
            this.startTimeSpan.Dock = System.Windows.Forms.DockStyle.Left;
            this.startTimeSpan.Location = new System.Drawing.Point(0, 5);
            this.startTimeSpan.MaxDate = new System.DateTime(2100, 12, 25, 0, 0, 0, 0);
            this.startTimeSpan.Name = "startTimeSpan";
            this.startTimeSpan.Size = new System.Drawing.Size(74, 20);
            this.startTimeSpan.TabIndex = 2;
            this.startTimeSpan.Value = new System.DateTime(2018, 12, 25, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Location = new System.Drawing.Point(74, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "-";
            // 
            // endTimeSpan
            // 
            this.endTimeSpan.Dock = System.Windows.Forms.DockStyle.Right;
            this.endTimeSpan.Location = new System.Drawing.Point(88, 5);
            this.endTimeSpan.MaxDate = new System.DateTime(2100, 12, 25, 0, 0, 0, 0);
            this.endTimeSpan.Name = "endTimeSpan";
            this.endTimeSpan.Size = new System.Drawing.Size(71, 20);
            this.endTimeSpan.TabIndex = 5;
            this.endTimeSpan.Value = new System.DateTime(2018, 12, 25, 0, 0, 0, 0);
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.dataPanel);
            this.Controls.Add(this.selectionPanel);
            this.Controls.Add(this.topPanel);
            this.Movable = false;
            this.Name = "Report";
            this.Padding = new System.Windows.Forms.Padding(0, 60, 0, 0);
            this.Resizable = false;
            this.ShowIcon = false;
            this.Text = "Kedi Pos - Raporlar";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.topPanel.ResumeLayout(false);
            this.selectionPanel.ResumeLayout(false);
            this.dataPanel.ResumeLayout(false);
            this.listPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.printPanel.ResumeLayout(false);
            this.metroPanel1.ResumeLayout(false);
            this.timespanPanel.ResumeLayout(false);
            this.timespanPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel topPanel;
        private MetroFramework.Controls.MetroTile back;
        private MetroFramework.Controls.MetroTile username;
        private MetroFramework.Controls.MetroPanel selectionPanel;
        private MetroFramework.Controls.MetroTile monthlyReport;
        private MetroFramework.Controls.MetroTile weeklyReport;
        private MetroFramework.Controls.MetroTile dailyReport;
        private MetroFramework.Controls.MetroPanel dataPanel;
        private MetroFramework.Controls.MetroPanel listPanel;
        private MetroFramework.Controls.MetroPanel printPanel;
        private MetroFramework.Controls.MetroTile print;
        private MetroFramework.Controls.MetroTile pdfPrint;
        private MetroFramework.Controls.MetroPanel metroPanel7;
        private MetroFramework.Controls.MetroTile excelPrint;
        private MetroFramework.Controls.MetroPanel metroPanel6;
        private System.Windows.Forms.DataGridView dataGridView1;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroPanel timespanPanel;
        private System.Windows.Forms.DateTimePicker startTimeSpan;
        private MetroFramework.Controls.MetroTile timespanSelection;
        private System.Windows.Forms.DateTimePicker endTimeSpan;
        private System.Windows.Forms.Label label1;
    }
}