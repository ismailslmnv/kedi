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
    public partial class selectMasa : MetroForm
    {
        public static System.Windows.Forms.Button selectedMasaButton;
        public static IEnumerable<Masalar> masalar;
        public selectMasa()
        {
            InitializeComponent();
        }

        private void selectMasa_Load(object sender, EventArgs e)
        {
            editMasaTextbox.Text = selectedMasaButton.Text;
        }

        private void masaSil_Click(object sender, EventArgs e)
        {
            try
            {
                using (KEDIDBEntities db = new KEDIDBEntities())
                {
                    var result = (from masa in db.Masalars where masa.MasaID.Equals(selectedMasaButton.TabIndex) select masa).First();
                    if (result != null)
                    {
                        db.Masalars.Remove(result);
                        db.SaveChanges();
                        this.Close();
                    }
                }
            }
            catch (Exception)
            {
                this.Close();
                MessageBox.Show(selectSalon.ActiveForm, "Bir Hata Meydana Geldi Tekrar Deneyiniz", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void kaydetButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (KEDIDBEntities db = new KEDIDBEntities())
                {
                    var result = (from masa in db.Masalars where masa.MasaID.Equals(selectedMasaButton.TabIndex) select masa).First();
                    if (!String.IsNullOrEmpty(editMasaTextbox.Text))
                    {
                        result.MasaAdi = editMasaTextbox.Text;
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

        private void masaEdit_Click(object sender, EventArgs e)
        {
            editPanel.Visible = true;
        }

        private void selectMasa_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
