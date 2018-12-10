namespace KEDI_v_0._5._0._1
{
    partial class Settings
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
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.sidePanel = new MetroFramework.Controls.MetroPanel();
            this.topPanel = new MetroFramework.Controls.MetroPanel();
            this.fillPanel = new MetroFramework.Controls.MetroPanel();
            this.printerSettings = new MetroFramework.Controls.MetroTile();
            this.Add = new MetroFramework.Controls.MetroTile();
            this.metroPanel1.SuspendLayout();
            this.sidePanel.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.fillPanel);
            this.metroPanel1.Controls.Add(this.topPanel);
            this.metroPanel1.Controls.Add(this.sidePanel);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(0, 60);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(800, 390);
            this.metroPanel1.TabIndex = 0;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // sidePanel
            // 
            this.sidePanel.Controls.Add(this.printerSettings);
            this.sidePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidePanel.HorizontalScrollbarBarColor = true;
            this.sidePanel.HorizontalScrollbarHighlightOnWheel = false;
            this.sidePanel.HorizontalScrollbarSize = 10;
            this.sidePanel.Location = new System.Drawing.Point(0, 0);
            this.sidePanel.Name = "sidePanel";
            this.sidePanel.Size = new System.Drawing.Size(125, 390);
            this.sidePanel.TabIndex = 2;
            this.sidePanel.VerticalScrollbarBarColor = true;
            this.sidePanel.VerticalScrollbarHighlightOnWheel = false;
            this.sidePanel.VerticalScrollbarSize = 10;
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.Add);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.HorizontalScrollbarBarColor = true;
            this.topPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.topPanel.HorizontalScrollbarSize = 10;
            this.topPanel.Location = new System.Drawing.Point(125, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(675, 39);
            this.topPanel.TabIndex = 3;
            this.topPanel.VerticalScrollbarBarColor = true;
            this.topPanel.VerticalScrollbarHighlightOnWheel = false;
            this.topPanel.VerticalScrollbarSize = 10;
            // 
            // fillPanel
            // 
            this.fillPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fillPanel.HorizontalScrollbarBarColor = true;
            this.fillPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.fillPanel.HorizontalScrollbarSize = 10;
            this.fillPanel.Location = new System.Drawing.Point(125, 39);
            this.fillPanel.Name = "fillPanel";
            this.fillPanel.Size = new System.Drawing.Size(675, 351);
            this.fillPanel.TabIndex = 4;
            this.fillPanel.VerticalScrollbarBarColor = true;
            this.fillPanel.VerticalScrollbarHighlightOnWheel = false;
            this.fillPanel.VerticalScrollbarSize = 10;
            // 
            // printerSettings
            // 
            this.printerSettings.ActiveControl = null;
            this.printerSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.printerSettings.Location = new System.Drawing.Point(0, 0);
            this.printerSettings.Name = "printerSettings";
            this.printerSettings.Size = new System.Drawing.Size(125, 39);
            this.printerSettings.Style = MetroFramework.MetroColorStyle.Orange;
            this.printerSettings.TabIndex = 2;
            this.printerSettings.Text = "Yazıcı Ayarları";
            this.printerSettings.UseSelectable = true;
            this.printerSettings.UseStyleColors = true;
            this.printerSettings.Click += new System.EventHandler(this.printerSettings_Click);
            // 
            // Add
            // 
            this.Add.ActiveControl = null;
            this.Add.Dock = System.Windows.Forms.DockStyle.Right;
            this.Add.Location = new System.Drawing.Point(564, 0);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(111, 39);
            this.Add.Style = MetroFramework.MetroColorStyle.Green;
            this.Add.TabIndex = 2;
            this.Add.Text = "Ekle";
            this.Add.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Add.UseSelectable = true;
            this.Add.UseStyleColors = true;
            this.Add.Visible = false;
            this.Add.Click += new System.EventHandler(this.metroTile1_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.metroPanel1);
            this.Name = "Settings";
            this.Padding = new System.Windows.Forms.Padding(0, 60, 0, 0);
            this.Text = "Ayarlar";
            this.metroPanel1.ResumeLayout(false);
            this.sidePanel.ResumeLayout(false);
            this.topPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroPanel fillPanel;
        private MetroFramework.Controls.MetroPanel topPanel;
        private MetroFramework.Controls.MetroTile Add;
        private MetroFramework.Controls.MetroPanel sidePanel;
        private MetroFramework.Controls.MetroTile printerSettings;
    }
}