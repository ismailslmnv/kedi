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
    public partial class UstMenuEdit : Form
    {
        public static int urunIDPassed = -1;
        public UstMenuEdit()
        {
            InitializeComponent();
            if (urunIDPassed != -1)
            {
                firstCreating();
            }
        }

        private void ok_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new KEDIDBEntities())
                {
                    var inserter = (from i in context.Urunlers where i.UrunID == urunIDPassed select i).FirstOrDefault();
                    inserter.UrunAdi = ustMenuAdi.Text.Trim();
                    inserter.Notlar = Not.Text.Trim();
                    inserter.Tarih = DateTime.Now;
                    context.SaveChanges();
                }
                MessageBox.Show("Üst Menü Düzenleme İşlemi Başarıyla Gerçekleşti..");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void firstCreating()
        {
            ustMenuAdi.Text = string.Empty;
            Not.Text = string.Empty;
            try
            {
                using (var context = new KEDIDBEntities())
                {
                    var result = (from c in context.Urunlers where c.UrunID == urunIDPassed select new { c.UrunID, c.UrunAdi, c.Notlar }).FirstOrDefault();
                    ustMenuAdi.Text = result.UrunAdi;
                    Not.Text = result.Notlar;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }    
    }
}
