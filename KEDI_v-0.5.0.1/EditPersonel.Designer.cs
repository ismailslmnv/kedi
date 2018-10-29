namespace KEDI_v_0._5._0._1
{
    partial class EditPersonel
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
            this.metroPanel3 = new MetroFramework.Controls.MetroPanel();
            this.personelAdi = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.OK = new MetroFramework.Controls.MetroTile();
            this.Delete = new MetroFramework.Controls.MetroTile();
            this.Cancel = new MetroFramework.Controls.MetroTile();
            this.permSelect = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.telNum = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.passw = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroPanel1.SuspendLayout();
            this.metroPanel3.SuspendLayout();
            this.metroPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.BackColor = System.Drawing.Color.White;
            this.metroPanel1.Controls.Add(this.metroPanel3);
            this.metroPanel1.Controls.Add(this.metroPanel2);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(0, 60);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(419, 449);
            this.metroPanel1.TabIndex = 0;
            this.metroPanel1.UseCustomBackColor = true;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // metroPanel3
            // 
            this.metroPanel3.Controls.Add(this.permSelect);
            this.metroPanel3.Controls.Add(this.metroLabel4);
            this.metroPanel3.Controls.Add(this.telNum);
            this.metroPanel3.Controls.Add(this.metroLabel2);
            this.metroPanel3.Controls.Add(this.passw);
            this.metroPanel3.Controls.Add(this.metroLabel3);
            this.metroPanel3.Controls.Add(this.personelAdi);
            this.metroPanel3.Controls.Add(this.metroLabel1);
            this.metroPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel3.HorizontalScrollbarBarColor = true;
            this.metroPanel3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel3.HorizontalScrollbarSize = 10;
            this.metroPanel3.Location = new System.Drawing.Point(0, 0);
            this.metroPanel3.Name = "metroPanel3";
            this.metroPanel3.Size = new System.Drawing.Size(419, 387);
            this.metroPanel3.TabIndex = 3;
            this.metroPanel3.VerticalScrollbarBarColor = true;
            this.metroPanel3.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel3.VerticalScrollbarSize = 10;
            // 
            // personelAdi
            // 
            // 
            // 
            // 
            this.personelAdi.CustomButton.Image = null;
            this.personelAdi.CustomButton.Location = new System.Drawing.Point(383, 2);
            this.personelAdi.CustomButton.Name = "";
            this.personelAdi.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.personelAdi.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.personelAdi.CustomButton.TabIndex = 1;
            this.personelAdi.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.personelAdi.CustomButton.UseSelectable = true;
            this.personelAdi.CustomButton.Visible = false;
            this.personelAdi.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.personelAdi.Lines = new string[0];
            this.personelAdi.Location = new System.Drawing.Point(4, 32);
            this.personelAdi.MaxLength = 32767;
            this.personelAdi.Name = "personelAdi";
            this.personelAdi.PasswordChar = '\0';
            this.personelAdi.PromptText = "Personel İsmini Giriniz";
            this.personelAdi.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.personelAdi.SelectedText = "";
            this.personelAdi.SelectionLength = 0;
            this.personelAdi.SelectionStart = 0;
            this.personelAdi.ShortcutsEnabled = true;
            this.personelAdi.Size = new System.Drawing.Size(411, 30);
            this.personelAdi.TabIndex = 3;
            this.personelAdi.UseSelectable = true;
            this.personelAdi.WaterMark = "Personel İsmini Giriniz";
            this.personelAdi.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.personelAdi.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.personelAdi.Click += new System.EventHandler(this.personelAdi_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(3, 9);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(145, 19);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "Personel Adı ve Soyadı:";
            // 
            // metroPanel2
            // 
            this.metroPanel2.Controls.Add(this.OK);
            this.metroPanel2.Controls.Add(this.Delete);
            this.metroPanel2.Controls.Add(this.Cancel);
            this.metroPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(0, 387);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(419, 62);
            this.metroPanel2.TabIndex = 2;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // OK
            // 
            this.OK.ActiveControl = null;
            this.OK.Location = new System.Drawing.Point(282, 11);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(133, 48);
            this.OK.Style = MetroFramework.MetroColorStyle.Green;
            this.OK.TabIndex = 4;
            this.OK.Text = "Onayla";
            this.OK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.OK.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.OK.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.OK.UseSelectable = true;
            this.OK.UseStyleColors = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // Delete
            // 
            this.Delete.ActiveControl = null;
            this.Delete.Location = new System.Drawing.Point(142, 11);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(133, 48);
            this.Delete.Style = MetroFramework.MetroColorStyle.Red;
            this.Delete.TabIndex = 3;
            this.Delete.Text = "Sil";
            this.Delete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Delete.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.Delete.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.Delete.UseSelectable = true;
            this.Delete.UseStyleColors = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Cancel
            // 
            this.Cancel.ActiveControl = null;
            this.Cancel.Location = new System.Drawing.Point(3, 11);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(133, 48);
            this.Cancel.Style = MetroFramework.MetroColorStyle.Yellow;
            this.Cancel.TabIndex = 2;
            this.Cancel.Text = "Vazgeç";
            this.Cancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Cancel.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.Cancel.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.Cancel.UseSelectable = true;
            this.Cancel.UseStyleColors = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // permSelect
            // 
            this.permSelect.FormattingEnabled = true;
            this.permSelect.ItemHeight = 23;
            this.permSelect.Location = new System.Drawing.Point(3, 198);
            this.permSelect.Name = "permSelect";
            this.permSelect.PromptText = "Yetkiler";
            this.permSelect.Size = new System.Drawing.Size(410, 29);
            this.permSelect.TabIndex = 18;
            this.permSelect.UseSelectable = true;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(3, 176);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(81, 19);
            this.metroLabel4.TabIndex = 17;
            this.metroLabel4.Text = "Yetki Seçiniz:";
            // 
            // telNum
            // 
            // 
            // 
            // 
            this.telNum.CustomButton.Image = null;
            this.telNum.CustomButton.Location = new System.Drawing.Point(383, 2);
            this.telNum.CustomButton.Name = "";
            this.telNum.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.telNum.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.telNum.CustomButton.TabIndex = 1;
            this.telNum.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.telNum.CustomButton.UseSelectable = true;
            this.telNum.CustomButton.Visible = false;
            this.telNum.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.telNum.Lines = new string[0];
            this.telNum.Location = new System.Drawing.Point(3, 143);
            this.telNum.MaxLength = 11;
            this.telNum.Name = "telNum";
            this.telNum.PasswordChar = '\0';
            this.telNum.PromptText = "Telefon Numarası Giriniz";
            this.telNum.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.telNum.SelectedText = "";
            this.telNum.SelectionLength = 0;
            this.telNum.SelectionStart = 0;
            this.telNum.ShortcutsEnabled = true;
            this.telNum.Size = new System.Drawing.Size(411, 30);
            this.telNum.TabIndex = 16;
            this.telNum.UseSelectable = true;
            this.telNum.WaterMark = "Telefon Numarası Giriniz";
            this.telNum.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.telNum.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(2, 120);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(113, 19);
            this.metroLabel2.TabIndex = 15;
            this.metroLabel2.Text = "Telefon Numarası:";
            // 
            // passw
            // 
            // 
            // 
            // 
            this.passw.CustomButton.Image = null;
            this.passw.CustomButton.Location = new System.Drawing.Point(383, 2);
            this.passw.CustomButton.Name = "";
            this.passw.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.passw.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.passw.CustomButton.TabIndex = 1;
            this.passw.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.passw.CustomButton.UseSelectable = true;
            this.passw.CustomButton.Visible = false;
            this.passw.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.passw.Lines = new string[0];
            this.passw.Location = new System.Drawing.Point(2, 87);
            this.passw.MaxLength = 32767;
            this.passw.Name = "passw";
            this.passw.PasswordChar = '\0';
            this.passw.PromptText = "Şifre Giriniz";
            this.passw.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.passw.SelectedText = "";
            this.passw.SelectionLength = 0;
            this.passw.SelectionStart = 0;
            this.passw.ShortcutsEnabled = true;
            this.passw.Size = new System.Drawing.Size(411, 30);
            this.passw.TabIndex = 14;
            this.passw.UseSelectable = true;
            this.passw.WaterMark = "Şifre Giriniz";
            this.passw.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.passw.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.passw.Click += new System.EventHandler(this.passw_Click);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(3, 65);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(46, 19);
            this.metroLabel3.TabIndex = 13;
            this.metroLabel3.Text = "Şifresi:";
            // 
            // EditPersonel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 509);
            this.ControlBox = false;
            this.Controls.Add(this.metroPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditPersonel";
            this.Padding = new System.Windows.Forms.Padding(0, 60, 0, 0);
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.DropShadow;
            this.ShowIcon = false;
            this.Style = MetroFramework.MetroColorStyle.Yellow;
            this.Text = "Personel Bilgileri Düzenleme";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditPermission_FormClosing);
            this.Load += new System.EventHandler(this.EditPersonel_Load);
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel3.ResumeLayout(false);
            this.metroPanel3.PerformLayout();
            this.metroPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroPanel metroPanel3;
        private MetroFramework.Controls.MetroTextBox personelAdi;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private MetroFramework.Controls.MetroTile OK;
        private MetroFramework.Controls.MetroTile Delete;
        private MetroFramework.Controls.MetroTile Cancel;
        private MetroFramework.Controls.MetroComboBox permSelect;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroTextBox telNum;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox passw;
        private MetroFramework.Controls.MetroLabel metroLabel3;
    }
}