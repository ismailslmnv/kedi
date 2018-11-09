namespace KEDI_v_0._5._0._1
{
    partial class ShowSubProducts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowSubProducts));
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.add = new MetroFramework.Controls.MetroTile();
            this.ozellikPanel = new MetroFramework.Controls.MetroPanel();
            this.metroPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.add);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(20, 60);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Padding = new System.Windows.Forms.Padding(10, 10, 0, 10);
            this.metroPanel1.Size = new System.Drawing.Size(760, 62);
            this.metroPanel1.TabIndex = 2;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // add
            // 
            this.add.ActiveControl = null;
            this.add.AutoSize = true;
            this.add.Dock = System.Windows.Forms.DockStyle.Right;
            this.add.Location = new System.Drawing.Point(604, 10);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(156, 42);
            this.add.TabIndex = 3;
            this.add.Text = "Alt Özellik Ekle";
            this.add.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.add.TileImage = ((System.Drawing.Image)(resources.GetObject("add.TileImage")));
            this.add.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.add.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.add.UseSelectable = true;
            this.add.UseTileImage = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // ozellikPanel
            // 
            this.ozellikPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ozellikPanel.HorizontalScrollbarBarColor = true;
            this.ozellikPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.ozellikPanel.HorizontalScrollbarSize = 10;
            this.ozellikPanel.Location = new System.Drawing.Point(20, 122);
            this.ozellikPanel.Name = "ozellikPanel";
            this.ozellikPanel.Size = new System.Drawing.Size(760, 308);
            this.ozellikPanel.TabIndex = 3;
            this.ozellikPanel.VerticalScrollbarBarColor = true;
            this.ozellikPanel.VerticalScrollbarHighlightOnWheel = false;
            this.ozellikPanel.VerticalScrollbarSize = 10;
            // 
            // ShowSubProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ozellikPanel);
            this.Controls.Add(this.metroPanel1);
            this.Name = "ShowSubProducts";
            this.Text = "Alt Özellikler - ";
            this.VisibleChanged += new System.EventHandler(this.ShowSubProducts_VisibleChanged);
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroTile add;
        private MetroFramework.Controls.MetroPanel ozellikPanel;
    }
}