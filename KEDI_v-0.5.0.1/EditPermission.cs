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
    public partial class EditPermission : MetroForm
    {
        public EditPermission()
        {
            InitializeComponent();
           // MessageBox.Show(YetkiID.ToString());
            _loader();
        }
        public static int YetkiID;
        private void EditPermission_Load(object sender, EventArgs e)
        {

        }
        private void _loader()
        {
            try
            {
                int _yetkiID = YetkiID;
                using (KEDIDBEntities KEDIDB = new KEDIDBEntities())
                {
                    var result = (from y in KEDIDB.Yetkilers where y.YetkiID == _yetkiID
                                  select y).FirstOrDefault();
                    if (result != null)
                    {
                        this.yetkiAdi.Text = result.YetkiAdi;
                        this.masaAcma.Checked = result.MasaAcma;
                        this.masaTasima.Checked = result.MasaTasima;
                        this.HesapAlma.Checked = result.HesapAlma;
                        this.SipIptal.Checked = result.HesapIptal;
                        this.UrunAyari.Checked = result.UrunAyarlari;
                        this.MasaAyari.Checked = result.MasaAyarlari;
                        this.PersAyari.Checked = result.PersonelAyarlari;
                        this.Rapor.Checked = result.Raporlama;
                    }
                    else
                    {
                        MessageBox.Show("İstenen Veri VeriTabanında Bulunamadı. Lütfen Daha Sonra Tekrar Deneyiniz");
                        this.Dispose();
                    }
                }

            } catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                this.Dispose();
            }
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
            this.Dispose();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            reset();
        }
        private void OK_Clicked()
        {
            try
            {
                int _yetkiID = YetkiID;
                Cursor.Current = Cursors.WaitCursor;
                using (KEDIDBEntities KEDIDB = new KEDIDBEntities())
                {
                    var result = (from y in KEDIDB.Yetkilers where y.YetkiID == _yetkiID select y).FirstOrDefault();
                    if (result != null)
                    {
                        result.YetkiAdi = yetkiAdi.Text;
                        result.MasaAcma = masaAcma.Checked;
                        result.MasaBirlestirme = masaTasima.Checked;
                        result.MasaTasima = masaTasima.Checked;
                        result.HesapAlma = this.HesapAlma.Checked;
                        result.HesapIptal = this.SipIptal.Checked;
                        result.UrunAyarlari = this.UrunAyari.Checked;
                        result.MasaAyarlari = this.MasaAyari.Checked;
                        result.PersonelAyarlari = this.PersAyari.Checked;
                        result.Raporlama = this.Rapor.Checked;
                    }
                    KEDIDB.SaveChanges();
                    MessageBox.Show("Güncelleme Başarılı..");
                }
            } catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            Cursor.Current = Cursors.Default;
            _formClosing();
            this.Dispose();
        }
        private void reset()
        {
            try
            {
                int _yetkiID = YetkiID;
                using (KEDIDBEntities KEDIDB = new KEDIDBEntities())
                {
                    var result = (from y in KEDIDB.Yetkilers where y.YetkiID == _yetkiID
                                  select y).FirstOrDefault();
                    if (result != null)
                    {
                        KEDIDB.Yetkilers.Remove(result);
                        MessageBox.Show("Yetki Başarıyla Silindi.");
                    }
                    else MessageBox.Show("Beklenmedik Bir Hata Oluştu.");
                    KEDIDB.SaveChanges();
                    this.Dispose();
                }

            } catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            _formClosing();
            this.Dispose();
        }

        private void EditPermission_FormClosing(object sender, FormClosingEventArgs e)
        {

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

        }
    }
}
