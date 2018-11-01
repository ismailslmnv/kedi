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
    public partial class AddTable : MetroForm
    {
        public AddTable()
        {
            InitializeComponent();
            addSalonlarToSelect();
        }

        private void AddTable_Load(object sender, EventArgs e)
        {

        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            this.Refresh();//+++++++++++ sılme yaptırılacak
        }

        private void OK_Click(object sender, EventArgs e)
        {
            try
            {
                using (KEDIDBEntities context = new KEDIDBEntities())
                {
                    Salonlar salonlar = (from salon in context.Salonlars where salon.SalonAdi.Equals(this.SalonlarSelect.Text) select salon).First();

                    Masalar masalar = new Masalar()
                    {
                        MasaAdi = this.masaAdi.Text,
                        Tarih = DateTime.Now,
                        SalonID = salonlar.SalonID,
                    };
                    context.Masalars.Add(masalar);
                    context.SaveChanges();
                    MessageBox.Show(AddSalon.ActiveForm, "Yeni Masa Başarılı Bir Şekilde Kaydedildi", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(AddSalon.ActiveForm, "Bir Hata Meydana Geldi Tekrar Deneyiniz", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
        private void addSalonlarToSelect()
        {
            try
            {
                using (KEDIDBEntities context = new KEDIDBEntities())
                {
                    var result = (from salon in context.Salonlars
                                  where salon.SalonID != 0
                                  select salon).DefaultIfEmpty().ToList();
                    if (result != null)
                    {
                        foreach (var item in result)
                        {
                            SalonlarSelect.Items.Add(item.SalonAdi);
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "Hiç Bir Kayıtlı Salon Bulunmamaktadır.\n Lütfen Bir Salon Oluşturun", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch(Exception)
            {
                MessageBox.Show(AddSalon.ActiveForm, "Bir Hata Meydana Geldi Tekrar Deneyiniz", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
    }
}
