namespace KEDI
{
    partial class UstMenuEkle
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
            this.label1 = new System.Windows.Forms.Label();
            this.ustMenuAdi = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Not = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Onayla = new System.Windows.Forms.Button();
            this.Vazgec = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.ustMenuAdi);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(465, 45);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Üst Menü İsmi: ";
            // 
            // ustMenuAdi
            // 
            this.ustMenuAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ustMenuAdi.Location = new System.Drawing.Point(156, 16);
            this.ustMenuAdi.Name = "ustMenuAdi";
            this.ustMenuAdi.Size = new System.Drawing.Size(301, 26);
            this.ustMenuAdi.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.BackColor = System.Drawing.Color.Aqua;
            this.panel2.Controls.Add(this.Not);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 45);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(465, 94);
            this.panel2.TabIndex = 2;
            // 
            // Not
            // 
            this.Not.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Not.Location = new System.Drawing.Point(156, 16);
            this.Not.Multiline = true;
            this.Not.Name = "Not";
            this.Not.Size = new System.Drawing.Size(301, 75);
            this.Not.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "Not:";
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.Vazgec);
            this.panel3.Controls.Add(this.Onayla);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 139);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(465, 65);
            this.panel3.TabIndex = 3;
            // 
            // Onayla
            // 
            this.Onayla.AutoSize = true;
            this.Onayla.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Onayla.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Onayla.Location = new System.Drawing.Point(12, 6);
            this.Onayla.Name = "Onayla";
            this.Onayla.Size = new System.Drawing.Size(98, 56);
            this.Onayla.TabIndex = 2;
            this.Onayla.Text = "Onayla";
            this.Onayla.UseVisualStyleBackColor = false;
            this.Onayla.Click += new System.EventHandler(this.Onayla_Click);
            // 
            // Vazgec
            // 
            this.Vazgec.AutoSize = true;
            this.Vazgec.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.Vazgec.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Vazgec.Location = new System.Drawing.Point(364, 6);
            this.Vazgec.Name = "Vazgec";
            this.Vazgec.Size = new System.Drawing.Size(98, 56);
            this.Vazgec.TabIndex = 3;
            this.Vazgec.Text = "Vazgeç";
            this.Vazgec.UseVisualStyleBackColor = false;
            this.Vazgec.Click += new System.EventHandler(this.Vazgec_Click);
            // 
            // UstMenuEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(465, 208);
            this.ControlBox = false;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UstMenuEkle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UstMenuEkle";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox ustMenuAdi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox Not;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button Vazgec;
        private System.Windows.Forms.Button Onayla;
    }
}