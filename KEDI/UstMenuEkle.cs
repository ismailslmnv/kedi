using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KEDI
{
    public partial class UstMenuEkle : Form
    {
        public UstMenuEkle()
        {
            InitializeComponent();
        }

        // Ust Menu Ekleme 
        private void Onayla_Click(object sender, EventArgs e)
        {
            using (var context = new KEDIDBEntities())
            {
                var inserter = context.Set<Urunler>();
                inserter.Add(new Urunler { UrunAdi = ustMenuAdi.Text.Trim(), Notlar = Not.Text.Trim(), Tarih = DateTime.Now });
                context.SaveChanges();
            }
            MessageBox.Show("Menü Ekleme İşlemi Başarıyla Gerçekleşti...");
        }

        private void Vazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
