namespace KEDI
{
    partial class IndirimEkle
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.indirimAdi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.oran = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.uygulanacaklar = new System.Windows.Forms.TreeView();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cancel = new System.Windows.Forms.Button();
            this.ok = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.indirimAdi);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(354, 49);
            this.panel1.TabIndex = 0;
            // 
            // indirimAdi
            // 
            this.indirimAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.indirimAdi.Location = new System.Drawing.Point(131, 17);
            this.indirimAdi.Name = "indirimAdi";
            this.indirimAdi.Size = new System.Drawing.Size(154, 29);
            this.indirimAdi.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label1.Location = new System.Drawing.Point(3, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "İndirim Adı:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.oran);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 49);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(354, 51);
            this.panel2.TabIndex = 2;
            // 
            // oran
            // 
            this.oran.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.oran.Location = new System.Drawing.Point(131, 19);
            this.oran.Name = "oran";
            this.oran.Size = new System.Drawing.Size(154, 29);
            this.oran.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label2.Location = new System.Drawing.Point(3, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "İndirim Oranı:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.uygulanacaklar);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 100);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(354, 156);
            this.panel3.TabIndex = 3;
            // 
            // uygulanacaklar
            // 
            this.uygulanacaklar.CheckBoxes = true;
            this.uygulanacaklar.Location = new System.Drawing.Point(133, 46);
            this.uygulanacaklar.Name = "uygulanacaklar";
            this.uygulanacaklar.ShowNodeToolTips = true;
            this.uygulanacaklar.Size = new System.Drawing.Size(209, 97);
            this.uygulanacaklar.TabIndex = 4;
            this.uygulanacaklar.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.uygulanacaklar_AfterCheck);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label3.Location = new System.Drawing.Point(3, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(251, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Uygulanan Menü ve Ürünler:";
            // 
            // panel4
            // 
            this.panel4.AutoSize = true;
            this.panel4.Controls.Add(this.cancel);
            this.panel4.Controls.Add(this.ok);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 256);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(354, 70);
            this.panel4.TabIndex = 4;
            // 
            // cancel
            // 
            this.cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.cancel.Location = new System.Drawing.Point(265, 6);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(86, 61);
            this.cancel.TabIndex = 1;
            this.cancel.Text = "Vazgeç";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // ok
            // 
            this.ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.ok.Location = new System.Drawing.Point(3, 6);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(86, 61);
            this.ok.TabIndex = 0;
            this.ok.Text = "Onayla";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // IndirimEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 328);
            this.ControlBox = false;
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IndirimEkle";
            this.ShowIcon = false;
            this.Text = "Indirim Ekle";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox indirimAdi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox oran;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.TreeView uygulanacaklar;
    }
}