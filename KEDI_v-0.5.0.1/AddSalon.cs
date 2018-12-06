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
            this.boyutX.Clear();
            this.boyutY.Clear();
        }
        private bool ValidateControl()
        {
            if (!String.IsNullOrEmpty(salonAdi.Text) && !String.IsNullOrEmpty(boyutX.Text) && !String.IsNullOrEmpty(boyutY.Text))
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
                                BoyutX = float.Parse(this.boyutX.Text),
                                BoyutY = float.Parse(this.boyutY.Text),
                                Tarih = DateTime.Now
                            };
                            context.Salonlars.Add(salonlar);
                            context.SaveChanges();
                            MessageBox.Show(AddSalon.ActiveForm, "Yeni Salon Başarılı Bir Şekilde Kaydedildi", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
