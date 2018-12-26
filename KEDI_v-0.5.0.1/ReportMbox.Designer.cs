namespace KEDI_v_0._5._0._1
{
    partial class ReportMbox
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
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.NO = new MetroFramework.Controls.MetroTile();
            this.YES = new MetroFramework.Controls.MetroTile();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.metroLabel1.Location = new System.Drawing.Point(0, 5);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(277, 19);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Lütfen Görmek İstediğiniz Rapor Tipini Seçiniz:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.NO);
            this.panel1.Controls.Add(this.YES);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.panel1.Size = new System.Drawing.Size(460, 84);
            this.panel1.TabIndex = 1;
            // 
            // NO
            // 
            this.NO.ActiveControl = null;
            this.NO.Dock = System.Windows.Forms.DockStyle.Right;
            this.NO.Location = new System.Drawing.Point(233, 10);
            this.NO.Name = "NO";
            this.NO.Size = new System.Drawing.Size(227, 74);
            this.NO.Style = MetroFramework.MetroColorStyle.Orange;
            this.NO.TabIndex = 1;
            this.NO.Text = "Detaylı";
            this.NO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.NO.UseSelectable = true;
            this.NO.UseStyleColors = true;
            this.NO.Click += new System.EventHandler(this.NO_Click);
            // 
            // YES
            // 
            this.YES.ActiveControl = null;
            this.YES.Dock = System.Windows.Forms.DockStyle.Left;
            this.YES.Location = new System.Drawing.Point(0, 10);
            this.YES.Name = "YES";
            this.YES.Size = new System.Drawing.Size(227, 74);
            this.YES.Style = MetroFramework.MetroColorStyle.Green;
            this.YES.TabIndex = 0;
            this.YES.Text = "Basit";
            this.YES.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.YES.UseSelectable = true;
            this.YES.UseStyleColors = true;
            this.YES.Click += new System.EventHandler(this.YES_Click);
            // 
            // ReportMbox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(460, 109);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.metroLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReportMbox";
            this.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rapor Tipi";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.Panel panel1;
        private MetroFramework.Controls.MetroTile NO;
        private MetroFramework.Controls.MetroTile YES;
    }
}