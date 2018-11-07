namespace KEDI_v_0._5._0._1
{
    partial class selectSalon
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
            this.secenekMenuPanel = new MetroFramework.Controls.MetroPanel();
            this.salonSil = new MetroFramework.Controls.MetroTile();
            this.salonEdit = new MetroFramework.Controls.MetroTile();
            this.editPanel = new MetroFramework.Controls.MetroPanel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.kaydetButton = new MetroFramework.Controls.MetroButton();
            this.editSalonTextbox = new MetroFramework.Controls.MetroTextBox();
            this.secenekMenuPanel.SuspendLayout();
            this.editPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // secenekMenuPanel
            // 
            this.secenekMenuPanel.Controls.Add(this.salonSil);
            this.secenekMenuPanel.Controls.Add(this.salonEdit);
            this.secenekMenuPanel.HorizontalScrollbarBarColor = true;
            this.secenekMenuPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.secenekMenuPanel.HorizontalScrollbarSize = 10;
            this.secenekMenuPanel.Location = new System.Drawing.Point(0, 5);
            this.secenekMenuPanel.Name = "secenekMenuPanel";
            this.secenekMenuPanel.Size = new System.Drawing.Size(332, 99);
            this.secenekMenuPanel.TabIndex = 3;
            this.secenekMenuPanel.VerticalScrollbarBarColor = true;
            this.secenekMenuPanel.VerticalScrollbarHighlightOnWheel = false;
            this.secenekMenuPanel.VerticalScrollbarSize = 10;
            // 
            // salonSil
            // 
            this.salonSil.ActiveControl = null;
            this.salonSil.AutoSize = true;
            this.salonSil.Dock = System.Windows.Forms.DockStyle.Right;
            this.salonSil.Location = new System.Drawing.Point(166, 0);
            this.salonSil.Name = "salonSil";
            this.salonSil.Size = new System.Drawing.Size(166, 99);
            this.salonSil.Style = MetroFramework.MetroColorStyle.Red;
            this.salonSil.TabIndex = 3;
            this.salonSil.Text = "Salon Sil";
            this.salonSil.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.salonSil.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.salonSil.UseSelectable = true;
            this.salonSil.Click += new System.EventHandler(this.salonSil_Click);
            // 
            // salonEdit
            // 
            this.salonEdit.ActiveControl = null;
            this.salonEdit.AutoSize = true;
            this.salonEdit.Dock = System.Windows.Forms.DockStyle.Left;
            this.salonEdit.Location = new System.Drawing.Point(0, 0);
            this.salonEdit.Name = "salonEdit";
            this.salonEdit.Size = new System.Drawing.Size(166, 99);
            this.salonEdit.Style = MetroFramework.MetroColorStyle.Green;
            this.salonEdit.TabIndex = 2;
            this.salonEdit.Text = "Salon Düzenle";
            this.salonEdit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.salonEdit.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.salonEdit.UseSelectable = true;
            this.salonEdit.Click += new System.EventHandler(this.salonEdit_Click);
            // 
            // editPanel
            // 
            this.editPanel.BackColor = System.Drawing.Color.White;
            this.editPanel.Controls.Add(this.metroLabel1);
            this.editPanel.Controls.Add(this.kaydetButton);
            this.editPanel.Controls.Add(this.editSalonTextbox);
            this.editPanel.HorizontalScrollbarBarColor = true;
            this.editPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.editPanel.HorizontalScrollbarSize = 10;
            this.editPanel.Location = new System.Drawing.Point(0, 2);
            this.editPanel.Name = "editPanel";
            this.editPanel.Size = new System.Drawing.Size(332, 99);
            this.editPanel.TabIndex = 4;
            this.editPanel.VerticalScrollbarBarColor = true;
            this.editPanel.VerticalScrollbarHighlightOnWheel = false;
            this.editPanel.VerticalScrollbarSize = 10;
            this.editPanel.Visible = false;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(96, 11);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(118, 19);
            this.metroLabel1.TabIndex = 4;
            this.metroLabel1.Text = "Salon İsim Düzenle";
            // 
            // kaydetButton
            // 
            this.kaydetButton.Location = new System.Drawing.Point(114, 62);
            this.kaydetButton.Name = "kaydetButton";
            this.kaydetButton.Size = new System.Drawing.Size(75, 23);
            this.kaydetButton.TabIndex = 3;
            this.kaydetButton.Text = "Kaydet";
            this.kaydetButton.UseSelectable = true;
            this.kaydetButton.Click += new System.EventHandler(this.kaydetButton_Click);
            // 
            // editSalonTextbox
            // 
            // 
            // 
            // 
            this.editSalonTextbox.CustomButton.Image = null;
            this.editSalonTextbox.CustomButton.Location = new System.Drawing.Point(175, 1);
            this.editSalonTextbox.CustomButton.Name = "";
            this.editSalonTextbox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.editSalonTextbox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.editSalonTextbox.CustomButton.TabIndex = 1;
            this.editSalonTextbox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.editSalonTextbox.CustomButton.UseSelectable = true;
            this.editSalonTextbox.CustomButton.Visible = false;
            this.editSalonTextbox.Lines = new string[0];
            this.editSalonTextbox.Location = new System.Drawing.Point(60, 33);
            this.editSalonTextbox.MaxLength = 32767;
            this.editSalonTextbox.Name = "editSalonTextbox";
            this.editSalonTextbox.PasswordChar = '\0';
            this.editSalonTextbox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.editSalonTextbox.SelectedText = "";
            this.editSalonTextbox.SelectionLength = 0;
            this.editSalonTextbox.SelectionStart = 0;
            this.editSalonTextbox.ShortcutsEnabled = true;
            this.editSalonTextbox.Size = new System.Drawing.Size(197, 23);
            this.editSalonTextbox.TabIndex = 2;
            this.editSalonTextbox.UseSelectable = true;
            this.editSalonTextbox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.editSalonTextbox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // selectSalon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 103);
            this.ControlBox = false;
            this.Controls.Add(this.editPanel);
            this.Controls.Add(this.secenekMenuPanel);
            this.DisplayHeader = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "selectSalon";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.Resizable = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Deactivate += new System.EventHandler(this.selectSalon_Deactivate);
            this.Load += new System.EventHandler(this.selectSalon_Load);
            this.secenekMenuPanel.ResumeLayout(false);
            this.secenekMenuPanel.PerformLayout();
            this.editPanel.ResumeLayout(false);
            this.editPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel secenekMenuPanel;
        private MetroFramework.Controls.MetroTile salonSil;
        private MetroFramework.Controls.MetroTile salonEdit;
        private MetroFramework.Controls.MetroPanel editPanel;
        private MetroFramework.Controls.MetroButton kaydetButton;
        private MetroFramework.Controls.MetroTextBox editSalonTextbox;
        private MetroFramework.Controls.MetroLabel metroLabel1;
    }
}