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
            this.ozellikPanel = new MetroFramework.Controls.MetroPanel();
            this.SuspendLayout();
            // 
            // ozellikPanel
            // 
            this.ozellikPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ozellikPanel.HorizontalScrollbarBarColor = true;
            this.ozellikPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.ozellikPanel.HorizontalScrollbarSize = 10;
            this.ozellikPanel.Location = new System.Drawing.Point(20, 60);
            this.ozellikPanel.Name = "ozellikPanel";
            this.ozellikPanel.Size = new System.Drawing.Size(760, 370);
            this.ozellikPanel.TabIndex = 0;
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
            this.Name = "ShowSubProducts";
            this.Text = "Alt Özellikler - ";
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel ozellikPanel;
    }
}