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
    public partial class AddMenu : MetroForm
    {
        public AddMenu()
        {
            InitializeComponent();                       
        }        
        private void EditPermission_Load(object sender, EventArgs e)
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
                Cursor.Current = Cursors.WaitCursor;
                using (KEDIDBEntities KEDIDB = new KEDIDBEntities())
                {
                    Urunler menu = new Urunler()
                    {
                        UrunAdi = menuAdi.Text,
                        Notlar = not.Text,
                        AltOzellik = false,
                        Tarih = DateTime.Now,
                        Fiyat = 0,                        
                        UstUrunID = 0
                    };
                    KEDIDB.Urunlers.Add(menu);
                    KEDIDB.SaveChanges();
                    MessageBox.Show("Menü Ekleme Başarılı..");
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
            AddMenu refresh = new AddMenu();
            refresh.Show();
            this.Close();
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
            }

        }
    }
}
