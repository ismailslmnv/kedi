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
    public partial class EditMenu : MetroForm
    {
        public EditMenu()
        {
            InitializeComponent();
           // MessageBox.Show(YetkiID.ToString());
            _loader();
        }
        public static int UrunID;
        private void EditPermission_Load(object sender, EventArgs e)
        {

        }
        private void _loader()
        {
            try
            {
                int _menuID = UrunID;
                using (KEDIDBEntities KEDIDB = new KEDIDBEntities())
                {
                    var result = (from m in KEDIDB.Urunlers where m.UrunID==_menuID
                                  select m).FirstOrDefault();
                    if (result != null)
                    {
                        this.menuAdi.Text = result.UrunAdi;
                        this.not.Text = result.Notlar;
                        this.tarih.Text = result.Tarih.Value.ToString();
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
                int _menuID = UrunID;
                Cursor.Current = Cursors.WaitCursor;
                using (KEDIDBEntities KEDIDB = new KEDIDBEntities())
                {
                    var result = (from m in KEDIDB.Urunlers where m.UrunID==_menuID select m).FirstOrDefault();
                    if (result != null)
                    {
                        result.UrunAdi= menuAdi.Text;
                        result.Notlar = not.Text;
                        result.Tarih = DateTime.Now;
                        result.AltOzellik = false;
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
                int _menuID = UrunID;
                using (KEDIDBEntities KEDIDB = new KEDIDBEntities())
                {
                    var result = (from m in KEDIDB.Urunlers where m.UrunID==_menuID
                                  select m).FirstOrDefault();
                    if (result != null)
                    {
                        KEDIDB.Urunlers.Remove(result);
                        MessageBox.Show("Menü Başarıyla Silindi.");
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
                .FirstOrDefault(c => c is Products);
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
