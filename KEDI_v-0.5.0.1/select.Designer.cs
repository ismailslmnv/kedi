﻿namespace KEDI_v_0._5._0._1
{
    partial class select
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
            this.urunEdit = new MetroFramework.Controls.MetroTile();
            this.ozellikEkle = new MetroFramework.Controls.MetroTile();
            this.metroPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.ozellikEkle);
            this.metroPanel1.Controls.Add(this.urunEdit);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(0, 3);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(332, 99);
            this.metroPanel1.TabIndex = 0;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // urunEdit
            // 
            this.urunEdit.ActiveControl = null;
            this.urunEdit.AutoSize = true;
            this.urunEdit.Dock = System.Windows.Forms.DockStyle.Left;
            this.urunEdit.Location = new System.Drawing.Point(0, 0);
            this.urunEdit.Name = "urunEdit";
            this.urunEdit.Size = new System.Drawing.Size(166, 99);
            this.urunEdit.Style = MetroFramework.MetroColorStyle.Green;
            this.urunEdit.TabIndex = 2;
            this.urunEdit.Text = "Ürün Düzenle";
            this.urunEdit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.urunEdit.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.urunEdit.UseSelectable = true;
            this.urunEdit.Click += new System.EventHandler(this.urunEdit_Click);
            // 
            // ozellikEkle
            // 
            this.ozellikEkle.ActiveControl = null;
            this.ozellikEkle.AutoSize = true;
            this.ozellikEkle.Dock = System.Windows.Forms.DockStyle.Right;
            this.ozellikEkle.Location = new System.Drawing.Point(166, 0);
            this.ozellikEkle.Name = "ozellikEkle";
            this.ozellikEkle.Size = new System.Drawing.Size(166, 99);
            this.ozellikEkle.Style = MetroFramework.MetroColorStyle.Red;
            this.ozellikEkle.TabIndex = 3;
            this.ozellikEkle.Text = "Alt Özellik Düzenle";
            this.ozellikEkle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ozellikEkle.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.ozellikEkle.UseSelectable = true;
            this.ozellikEkle.Click += new System.EventHandler(this.ozellikEkle_Click);
            // 
            // select
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 97);
            this.ControlBox = false;
            this.Controls.Add(this.metroPanel1);
            this.DisplayHeader = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "select";
            this.Padding = new System.Windows.Forms.Padding(0, 30, 0, 0);
            this.Resizable = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Style = MetroFramework.MetroColorStyle.Yellow;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.select_Load);
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroTile ozellikEkle;
        private MetroFramework.Controls.MetroTile urunEdit;
    }
}