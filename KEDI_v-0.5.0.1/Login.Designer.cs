namespace KEDI_v_0._5._0._1
{
    partial class Login
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
            this.enter = new MetroFramework.Controls.MetroButton();
            this.password = new MetroFramework.Controls.MetroTextBox();
            this.username = new MetroFramework.Controls.MetroTextBox();
            this.metroPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.metroPanel1.Controls.Add(this.enter);
            this.metroPanel1.Controls.Add(this.password);
            this.metroPanel1.Controls.Add(this.username);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(0, 60);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(375, 266);
            this.metroPanel1.Style = MetroFramework.MetroColorStyle.Silver;
            this.metroPanel1.TabIndex = 0;
            this.metroPanel1.UseCustomBackColor = true;
            this.metroPanel1.UseStyleColors = true;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // enter
            // 
            this.enter.BackColor = System.Drawing.Color.White;
            this.enter.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.enter.Highlight = true;
            this.enter.Location = new System.Drawing.Point(4, 187);
            this.enter.Name = "enter";
            this.enter.Size = new System.Drawing.Size(368, 56);
            this.enter.Style = MetroFramework.MetroColorStyle.Yellow;
            this.enter.TabIndex = 4;
            this.enter.Text = "Giriş Yap";
            this.enter.Theme = MetroFramework.MetroThemeStyle.Light;
            this.enter.UseCustomBackColor = true;
            this.enter.UseSelectable = true;
            this.enter.UseStyleColors = true;
            this.enter.Click += new System.EventHandler(this.enter_Click);
            // 
            // password
            // 
            // 
            // 
            // 
            this.password.CustomButton.Image = null;
            this.password.CustomButton.Location = new System.Drawing.Point(340, 2);
            this.password.CustomButton.Name = "";
            this.password.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.password.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.password.CustomButton.TabIndex = 1;
            this.password.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.password.CustomButton.UseSelectable = true;
            this.password.CustomButton.Visible = false;
            this.password.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.password.Lines = new string[0];
            this.password.Location = new System.Drawing.Point(4, 114);
            this.password.MaxLength = 32767;
            this.password.Name = "password";
            this.password.PasswordChar = 'x';
            this.password.PromptText = "Kullanıcı Şifresi";
            this.password.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.password.SelectedText = "";
            this.password.SelectionLength = 0;
            this.password.SelectionStart = 0;
            this.password.ShortcutsEnabled = true;
            this.password.ShowClearButton = true;
            this.password.Size = new System.Drawing.Size(368, 30);
            this.password.Style = MetroFramework.MetroColorStyle.Yellow;
            this.password.TabIndex = 3;
            this.password.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.password.UseSelectable = true;
            this.password.WaterMark = "Kullanıcı Şifresi";
            this.password.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.password.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.password.KeyDown += new System.Windows.Forms.KeyEventHandler(this.password_KeyDown);
            // 
            // username
            // 
            this.username.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            // 
            // 
            // 
            this.username.CustomButton.Image = null;
            this.username.CustomButton.Location = new System.Drawing.Point(340, 2);
            this.username.CustomButton.Name = "";
            this.username.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.username.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.username.CustomButton.TabIndex = 1;
            this.username.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.username.CustomButton.UseSelectable = true;
            this.username.CustomButton.Visible = false;
            this.username.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.username.Lines = new string[0];
            this.username.Location = new System.Drawing.Point(4, 46);
            this.username.MaxLength = 32767;
            this.username.Name = "username";
            this.username.PasswordChar = '\0';
            this.username.PromptText = "Kullanıcı Telefon Numarası";
            this.username.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.username.SelectedText = "";
            this.username.SelectionLength = 0;
            this.username.SelectionStart = 0;
            this.username.ShortcutsEnabled = true;
            this.username.Size = new System.Drawing.Size(368, 30);
            this.username.Style = MetroFramework.MetroColorStyle.Yellow;
            this.username.TabIndex = 2;
            this.username.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.username.UseSelectable = true;
            this.username.WaterMark = "Kullanıcı Telefon Numarası";
            this.username.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.username.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.username.Click += new System.EventHandler(this.username_Click);
            this.username.KeyDown += new System.Windows.Forms.KeyEventHandler(this.username_KeyDown);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 326);
            this.ControlBox = false;
            this.Controls.Add(this.metroPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.Padding = new System.Windows.Forms.Padding(0, 60, 0, 0);
            this.ShowIcon = false;
            this.Style = MetroFramework.MetroColorStyle.Yellow;
            this.Text = "Kedi POS - Giriş Sayfası";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Login_Load);
            this.metroPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroTextBox username;
        private MetroFramework.Controls.MetroButton enter;
        private MetroFramework.Controls.MetroTextBox password;
    }
}