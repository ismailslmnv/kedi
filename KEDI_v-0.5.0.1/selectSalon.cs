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
            editSalonTextbox.Text = selectedSalonTile.Text;
        }

        private void salonEdit_Click(object sender, EventArgs e)
        {
            editPanel.Visible = true;
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

        private void kaydetButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (KEDIDBEntities db = new KEDIDBEntities())
                {
                    var result = (from salon in db.Salonlars where salon.SalonID.Equals(selectedSalonTile.TabIndex) select salon).First();
                    if (!String.IsNullOrEmpty(editSalonTextbox.Text))
                    {
                        result.SalonAdi = editSalonTextbox.Text;
                        db.SaveChanges();
                        editPanel.Visible = false;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(selectSalon.ActiveForm, "Bir İsim vermelisiniz", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        editPanel.Visible = false;
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
    }
}
