namespace KEDI
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ustMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.urun = new System.Windows.Forms.ToolStripMenuItem();
            this.indirimler = new System.Windows.Forms.ToolStripMenuItem();
            this.urunListele = new System.Windows.Forms.ToolStripMenuItem();
            this.kullanici = new System.Windows.Forms.ToolStripMenuItem();
            this.yetkilerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kullanıcıAyarlarıToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.raporlar = new System.Windows.Forms.ToolStripMenuItem();
            this.düzenlenecekToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu = new System.Windows.Forms.Panel();
            this.menubuttons = new System.Windows.Forms.Panel();
            this.refreshButton = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.Edit = new System.Windows.Forms.Button();
            this.add = new System.Windows.Forms.Button();
            this.lists = new System.Windows.Forms.DataGridView();
            this.masalarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salonlarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.menu.SuspendLayout();
            this.menubuttons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lists)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ustMenu,
            this.urun,
            this.kullanici,
            this.raporlar,
            this.masalarToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // ustMenu
            // 
            this.ustMenu.CheckOnClick = true;
            this.ustMenu.Name = "ustMenu";
            this.ustMenu.Size = new System.Drawing.Size(101, 20);
            this.ustMenu.Text = "Ürün Üst Grubu";
            this.ustMenu.Click += new System.EventHandler(this.ustMenu_Click);
            // 
            // urun
            // 
            this.urun.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.indirimler,
            this.urunListele});
            this.urun.Name = "urun";
            this.urun.Size = new System.Drawing.Size(58, 20);
            this.urun.Text = "Ürünler";
            // 
            // indirimler
            // 
            this.indirimler.Name = "indirimler";
            this.indirimler.Size = new System.Drawing.Size(180, 22);
            this.indirimler.Text = "İndirimler";
            this.indirimler.Click += new System.EventHandler(this.indirimler_Click);
            // 
            // urunListele
            // 
            this.urunListele.CheckOnClick = true;
            this.urunListele.Name = "urunListele";
            this.urunListele.Size = new System.Drawing.Size(180, 22);
            this.urunListele.Text = "Ürünler";
            this.urunListele.Click += new System.EventHandler(this.ürünlerToolStripMenuItem_Click);
            // 
            // kullanici
            // 
            this.kullanici.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yetkilerToolStripMenuItem,
            this.kullanıcıAyarlarıToolStripMenuItem});
            this.kullanici.Name = "kullanici";
            this.kullanici.Size = new System.Drawing.Size(77, 20);
            this.kullanici.Text = "Kullanıcılar";
            // 
            // yetkilerToolStripMenuItem
            // 
            this.yetkilerToolStripMenuItem.Name = "yetkilerToolStripMenuItem";
            this.yetkilerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.yetkilerToolStripMenuItem.Text = "Yetkiler";
            // 
            // kullanıcıAyarlarıToolStripMenuItem
            // 
            this.kullanıcıAyarlarıToolStripMenuItem.Name = "kullanıcıAyarlarıToolStripMenuItem";
            this.kullanıcıAyarlarıToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.kullanıcıAyarlarıToolStripMenuItem.Text = "Kullanıcı Ayarları";
            // 
            // raporlar
            // 
            this.raporlar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.düzenlenecekToolStripMenuItem});
            this.raporlar.Name = "raporlar";
            this.raporlar.Size = new System.Drawing.Size(63, 20);
            this.raporlar.Text = "Raporlar";
            // 
            // düzenlenecekToolStripMenuItem
            // 
            this.düzenlenecekToolStripMenuItem.Name = "düzenlenecekToolStripMenuItem";
            this.düzenlenecekToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.düzenlenecekToolStripMenuItem.Text = "Düzenlenecek";
            // 
            // menu
            // 
            this.menu.AutoScroll = true;
            this.menu.AutoSize = true;
            this.menu.Controls.Add(this.menubuttons);
            this.menu.Controls.Add(this.lists);
            this.menu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menu.Location = new System.Drawing.Point(0, 24);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(800, 426);
            this.menu.TabIndex = 9;
            this.menu.Visible = false;
            // 
            // menubuttons
            // 
            this.menubuttons.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonMenu;
            this.menubuttons.BackColor = System.Drawing.Color.Transparent;
            this.menubuttons.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.menubuttons.Controls.Add(this.refreshButton);
            this.menubuttons.Controls.Add(this.Delete);
            this.menubuttons.Controls.Add(this.Edit);
            this.menubuttons.Controls.Add(this.add);
            this.menubuttons.Dock = System.Windows.Forms.DockStyle.Top;
            this.menubuttons.Location = new System.Drawing.Point(0, 423);
            this.menubuttons.Name = "menubuttons";
            this.menubuttons.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.menubuttons.Size = new System.Drawing.Size(783, 48);
            this.menubuttons.TabIndex = 9;
            this.menubuttons.Paint += new System.Windows.Forms.PaintEventHandler(this.menubuttons_Paint);
            // 
            // refreshButton
            // 
            this.refreshButton.BackColor = System.Drawing.Color.White;
            this.refreshButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("refreshButton.BackgroundImage")));
            this.refreshButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.refreshButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.refreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.refreshButton.ForeColor = System.Drawing.Color.Transparent;
            this.refreshButton.Location = new System.Drawing.Point(733, 0);
            this.refreshButton.Margin = new System.Windows.Forms.Padding(20, 0, 10, 0);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(50, 48);
            this.refreshButton.TabIndex = 9;
            this.refreshButton.UseVisualStyleBackColor = false;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // Delete
            // 
            this.Delete.Dock = System.Windows.Forms.DockStyle.Left;
            this.Delete.Location = new System.Drawing.Point(216, 0);
            this.Delete.Margin = new System.Windows.Forms.Padding(20, 0, 10, 0);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(86, 48);
            this.Delete.TabIndex = 8;
            this.Delete.Text = "Sil";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Edit
            // 
            this.Edit.Dock = System.Windows.Forms.DockStyle.Left;
            this.Edit.Location = new System.Drawing.Point(126, 0);
            this.Edit.Margin = new System.Windows.Forms.Padding(20, 0, 10, 0);
            this.Edit.Name = "Edit";
            this.Edit.Size = new System.Drawing.Size(90, 48);
            this.Edit.TabIndex = 7;
            this.Edit.Text = "Düzenle";
            this.Edit.UseVisualStyleBackColor = true;
            this.Edit.Click += new System.EventHandler(this.Edit_Click);
            // 
            // add
            // 
            this.add.Dock = System.Windows.Forms.DockStyle.Left;
            this.add.Location = new System.Drawing.Point(20, 0);
            this.add.Margin = new System.Windows.Forms.Padding(20, 0, 10, 0);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(106, 48);
            this.add.TabIndex = 6;
            this.add.Text = "Ekle";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // lists
            // 
            this.lists.AllowUserToAddRows = false;
            this.lists.AllowUserToDeleteRows = false;
            this.lists.AllowUserToOrderColumns = true;
            this.lists.AllowUserToResizeColumns = false;
            this.lists.AllowUserToResizeRows = false;
            this.lists.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lists.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lists.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lists.Dock = System.Windows.Forms.DockStyle.Top;
            this.lists.Location = new System.Drawing.Point(0, 0);
            this.lists.Name = "lists";
            this.lists.ReadOnly = true;
            this.lists.Size = new System.Drawing.Size(783, 423);
            this.lists.TabIndex = 8;
            // 
            // masalarToolStripMenuItem
            // 
            this.masalarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salonlarToolStripMenuItem});
            this.masalarToolStripMenuItem.Name = "masalarToolStripMenuItem";
            this.masalarToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.masalarToolStripMenuItem.Text = "Masalar";
            // 
            // salonlarToolStripMenuItem
            // 
            this.salonlarToolStripMenuItem.Name = "salonlarToolStripMenuItem";
            this.salonlarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.salonlarToolStripMenuItem.Text = "Salonlar";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yönetim Arayüzü";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.menu.ResumeLayout(false);
            this.menubuttons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lists)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ustMenu;
        private System.Windows.Forms.ToolStripMenuItem urun;
        private System.Windows.Forms.ToolStripMenuItem kullanici;
        private System.Windows.Forms.ToolStripMenuItem raporlar;
        private System.Windows.Forms.ToolStripMenuItem düzenlenecekToolStripMenuItem;
        private System.Windows.Forms.Panel menu;
        private System.Windows.Forms.Panel menubuttons;
        private System.Windows.Forms.DataGridView lists;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Button Edit;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.ToolStripMenuItem indirimler;
        private System.Windows.Forms.ToolStripMenuItem urunListele;
        private System.Windows.Forms.ToolStripMenuItem yetkilerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kullanıcıAyarlarıToolStripMenuItem;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.ToolStripMenuItem masalarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salonlarToolStripMenuItem;
    }
}

