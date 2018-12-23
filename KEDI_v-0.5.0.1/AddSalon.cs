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
    public partial class AddSalon : MetroForm
    {
        public AddSalon()
        {
            InitializeComponent();
        }

        private void AddSalon_Load(object sender, EventArgs e)
        {

        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            this.salonAdi.Clear();
        }
        private bool ValidateControl()
        {
            if (!String.IsNullOrEmpty(salonAdi.Text))
                return true;
            else
            {
                MessageBox.Show(AddSalon.ActiveForm, "Tüm Bilgileri Doldurmalısınız", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        private void OK_Click(object sender, EventArgs e)
        {
            try{
                using (KEDIDBEntities context = new KEDIDBEntities())
                {
                    var result = (from salon in context.Salonlars select salon).ToList();
                    short ayniDurumSayac = 0;

                    foreach (Salonlar salon in result)
                        if(salon.SalonAdi.Equals(this.salonAdi.Text))
                            ayniDurumSayac++;

                    if (ayniDurumSayac.Equals(0))
                    {
                        if (ValidateControl())
                        {
                            Salonlar salonlar = new Salonlar()
                            {
                                SalonAdi = this.salonAdi.Text,
                                Tarih = DateTime.Now
                            };
                            context.Salonlars.Add(salonlar);
                            context.SaveChanges();
                            MessageBox.Show(AddSalon.ActiveForm, "Yeni Salon Başarılı Bir Şekilde Kaydedildi", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show(AddSalon.ActiveForm, "Aynı isimde bir salon mevcuttur", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show(AddSalon.ActiveForm, "Bir Hata Meydana Geldi Tekrar Deneyiniz","HATA",MessageBoxButtons.OK,MessageBoxIcon.Error);
                this.Close();
            }
        }
    }
}
