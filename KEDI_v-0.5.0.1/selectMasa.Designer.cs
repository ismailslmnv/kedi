namespace KEDI_v_0._5._0._1
{
    partial class selectMasa
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
            this.masaSil = new MetroFramework.Controls.MetroTile();
            this.masaEdit = new MetroFramework.Controls.MetroTile();
            this.editPanel = new MetroFramework.Controls.MetroPanel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.kaydetButton = new MetroFramework.Controls.MetroButton();
            this.editMasaTextbox = new MetroFramework.Controls.MetroTextBox();
            this.secenekMenuPanel.SuspendLayout();
            this.editPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // secenekMenuPanel
            // 
            this.secenekMenuPanel.Controls.Add(this.masaSil);
            this.secenekMenuPanel.Controls.Add(this.masaEdit);
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
            // masaSil
            // 
            this.masaSil.ActiveControl = null;
            this.masaSil.AutoSize = true;
            this.masaSil.Dock = System.Windows.Forms.DockStyle.Right;
            this.masaSil.Location = new System.Drawing.Point(166, 0);
            this.masaSil.Name = "masaSil";
            this.masaSil.Size = new System.Drawing.Size(166, 99);
            this.masaSil.Style = MetroFramework.MetroColorStyle.Red;
            this.masaSil.TabIndex = 3;
            this.masaSil.Text = "Masa Sil";
            this.masaSil.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.masaSil.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.masaSil.UseSelectable = true;
            this.masaSil.Click += new System.EventHandler(this.masaSil_Click);
            // 
            // masaEdit
            // 
            this.masaEdit.ActiveControl = null;
            this.masaEdit.AutoSize = true;
            this.masaEdit.Dock = System.Windows.Forms.DockStyle.Left;
            this.masaEdit.Location = new System.Drawing.Point(0, 0);
            this.masaEdit.Name = "masaEdit";
            this.masaEdit.Size = new System.Drawing.Size(166, 99);
            this.masaEdit.Style = MetroFramework.MetroColorStyle.Green;
            this.masaEdit.TabIndex = 2;
            this.masaEdit.Text = "Masa Düzenle";
            this.masaEdit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.masaEdit.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.masaEdit.UseSelectable = true;
            this.masaEdit.Click += new System.EventHandler(this.masaEdit_Click);
            // 
            // editPanel
            // 
            this.editPanel.BackColor = System.Drawing.Color.White;
            this.editPanel.Controls.Add(this.metroLabel1);
            this.editPanel.Controls.Add(this.kaydetButton);
            this.editPanel.Controls.Add(this.editMasaTextbox);
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
            this.metroLabel1.Size = new System.Drawing.Size(117, 19);
            this.metroLabel1.TabIndex = 4;
            this.metroLabel1.Text = "Masa İsim Düzenle";
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
            // editMasaTextbox
            // 
            // 
            // 
            // 
            this.editMasaTextbox.CustomButton.Image = null;
            this.editMasaTextbox.CustomButton.Location = new System.Drawing.Point(175, 1);
            this.editMasaTextbox.CustomButton.Name = "";
            this.editMasaTextbox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.editMasaTextbox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.editMasaTextbox.CustomButton.TabIndex = 1;
            this.editMasaTextbox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.editMasaTextbox.CustomButton.UseSelectable = true;
            this.editMasaTextbox.CustomButton.Visible = false;
            this.editMasaTextbox.Lines = new string[0];
            this.editMasaTextbox.Location = new System.Drawing.Point(60, 33);
            this.editMasaTextbox.MaxLength = 32767;
            this.editMasaTextbox.Name = "editMasaTextbox";
            this.editMasaTextbox.PasswordChar = '\0';
            this.editMasaTextbox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.editMasaTextbox.SelectedText = "";
            this.editMasaTextbox.SelectionLength = 0;
            this.editMasaTextbox.SelectionStart = 0;
            this.editMasaTextbox.ShortcutsEnabled = true;
            this.editMasaTextbox.Size = new System.Drawing.Size(197, 23);
            this.editMasaTextbox.TabIndex = 2;
            this.editMasaTextbox.UseSelectable = true;
            this.editMasaTextbox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.editMasaTextbox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // selectMasa
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
            this.Name = "selectMasa";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.Resizable = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Deactivate += new System.EventHandler(this.selectMasa_Deactivate);
            this.secenekMenuPanel.ResumeLayout(false);
            this.secenekMenuPanel.PerformLayout();
            this.editPanel.ResumeLayout(false);
            this.editPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel secenekMenuPanel;
        private MetroFramework.Controls.MetroTile masaSil;
        private MetroFramework.Controls.MetroTile masaEdit;
        private MetroFramework.Controls.MetroPanel editPanel;
        private MetroFramework.Controls.MetroButton kaydetButton;
        private MetroFramework.Controls.MetroTextBox editMasaTextbox;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        
    }
}