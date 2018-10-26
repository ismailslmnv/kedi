using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;

namespace KEDI_v_0._5._0._1
{
    public partial class AddPermission : MetroForm
    {
        public AddPermission()
        {
            InitializeComponent();
        }

        private void EditPermissions_Load(object sender, EventArgs e)
        {

        }

        private void metroPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void OK_Click(object sender, EventArgs e)
        {
            OK_Clicked();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            _formClosing();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            reset();
        }
        private void OK_Clicked()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                using (KEDIDBEntities KEDIDB = new KEDIDBEntities())
                {
                    Yetkiler yetkiler = new Yetkiler()
                    {
                        YetkiAdi = yetkiAdi.Text,
                        MasaAcma = masaAcma.Checked,
                        MasaBirlestirme = masaTasima.Checked,
                        MasaTasima = masaTasima.Checked,
                        HesapAlma = this.HesapAlma.Checked,
                        HesapIptal = this.SipIptal.Checked,
                        UrunAyarlari = this.UrunAyari.Checked,
                        MasaAyarlari = this.MasaAyari.Checked,
                        PersonelAyarlari = this.PersAyari.Checked,
                        Raporlama = this.Rapor.Checked

                    };
                    KEDIDB.Yetkilers.Add(yetkiler);
                    KEDIDB.SaveChanges();
                    MessageBox.Show("Yetki Başarıyla Eklendi.");                    
                }
            } catch(Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            _formClosing();
            Cursor.Current = Cursors.Default;
        }
        private  void reset()
        {
            AddPermission add = new AddPermission();
            add.Show();
            this.Dispose();
         //   _formClosing();            
        }
        private void _formClosing()
        {
            var PermissionsReloader = Application.OpenForms.Cast<Form>()
              .FirstOrDefault(c => c is Permissions);
            if (PermissionsReloader != null)
            {
                PermissionsReloader.Visible = false;
                PermissionsReloader.Visible = true;
                //MessageBox.Show("Test");
                //  PermissionsReloader.Invalidate();
                //Application.DoEvents();
            }
            this.Dispose();
        }
    }
}
