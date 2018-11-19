using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace KEDI_v_0._5._0._1
{
    public partial class selectSalon : MetroForm
    {
        public static MetroFramework.Controls.MetroTile selectedSalonTile;
        public static IEnumerable<Salonlar> salonlar;

        public selectSalon()
        {
            InitializeComponent();
        }

        private void selectSalon_Load(object sender, EventArgs e)
        {
            salonAdi.Text = selectedSalonTile.Text;
        }

        private void salonEdit_Click(object sender, EventArgs e)
        {
            this.Size = new Size(450, 388);
            this.salonEdit.Visible = false;
            this.salonSil.Visible = false;
            metroPanel3.Visible = true;
            metroPanel2.Visible = true;
        }

        private void salonSil_Click(object sender, EventArgs e)
        {
            try
            {
                using (KEDIDBEntities db = new KEDIDBEntities())
                {
                    var result = (from salon in db.Salonlars where salon.SalonID.Equals(selectedSalonTile.TabIndex) select salon).First();
                    if (result.Masalars.Count.Equals(0))
                    {
                        db.Salonlars.Remove(result);
                        db.SaveChanges();
                        this.Close();
                    }
                    else
                    {
                        this.Close();
                        MessageBox.Show(selectSalon.ActiveForm, "Salonda Masa Bulunmaktadır", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception)
            {
                this.Close();
                MessageBox.Show(selectSalon.ActiveForm, "Bir Hata Meydana Geldi Tekrar Deneyiniz", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void selectSalon_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void OK_Click(object sender, EventArgs e)
        {
            try
            {
                using (KEDIDBEntities db = new KEDIDBEntities())
                {
                    var result = (from salon in db.Salonlars where salon.SalonID.Equals(selectedSalonTile.TabIndex) select salon).First();
                    if (!String.IsNullOrEmpty(salonAdi.Text))
                    {
                        result.SalonAdi = salonAdi.Text;
                        result.BoyutX = float.Parse(this.boyutX.Text);
                        result.BoyutY = float.Parse(this.boyutY.Text);
                        db.SaveChanges();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(selectSalon.ActiveForm, "Bir İsim vermelisiniz", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Close();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show(selectSalon.ActiveForm, "Bir Hata Meydana Geldi Tekrar Deneyiniz", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
