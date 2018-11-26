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
using MetroFramework;

namespace KEDI_v_0._5._0._1
{
    public partial class Enterance : MetroForm
    {
        public static int yetkiID;
        public static int userID;
        public static string usernameText = String.Empty;
        public Enterance()
        {
            InitializeComponent();
            permissionController();
        }
        private void Enterance_Load(object sender, EventArgs e)
        {

        }
        private void metroTile2_Click(object sender, EventArgs e)
        {
            Tables tables = new Tables();
            tables.Show();
            this.Hide();
            
        }
        private void metroPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void permissionController()
        {       
            try
            {
                using (KEDIDBEntities context = new KEDIDBEntities())
                {
                    var result = (from yetkiler in context.Yetkilers
                                 where yetkiler.YetkiID == yetkiID
                                 select yetkiler).FirstOrDefault();
                    if (result != null)
                    {
                        userEnabler(result.YetkiAdi);
                        menuEnabler(result);
                    }
                }

            } catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void menuEnabler (Yetkiler yetkiler)
        {
            if (yetkiler.HesapAlma || yetkiler.HesapIptal || yetkiler.MasaAcma || yetkiler.MasaBirlestirme || yetkiler.MasaTasima)
                siparis.Enabled = true;
            else siparis.Enabled = false;
            if (yetkiler.MasaAyarlari)
                masa.Enabled = true;
            else masa.Enabled = false;
            if (yetkiler.PersonelAyarlari)
                personel.Enabled = true;
            else personel.Enabled = false;
            if (yetkiler.UrunAyarlari)
                urun.Enabled = true;
            else urun.Enabled = false;
            if (yetkiler.Raporlama)
                rapor.Enabled = true;
            else rapor.Enabled = false;         
        }
        private void userEnabler(string yetkiAdi)
        {
            try
            {
                using (KEDIDBEntities context = new KEDIDBEntities())
                {
                    var result = (from user in context.Personels
                                 where user.KullaniciID == userID
                                 select user.KullaniciAdi).FirstOrDefault();
                    if (result != null)
                    {
                        username.Text = result + " - " + yetkiAdi;
                        usernameText = username.Text;
                    }
                    else
                    {
                        MessageBox.Show("Problem");                        
                    }
                }
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.ToString());
            }
        }
        private void siparis_Click(object sender, EventArgs e)
        {
            Order order = new Order();
            order.Show();
        }
        private void username_Click(object sender, EventArgs e)
        {

        }
        private void exit_Click(object sender, EventArgs e)
        {
            //var formToShow = Application.OpenForms.Cast<Form>()
            //.FirstOrDefault(c => c is Login);
            //if (formToShow != null)
            //{
            //    formToShow.Show();
            //}
            Login.login.Show();
            this.Dispose();
        }
        private void Enterance_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
        private void personel_Click(object sender, EventArgs e)
        {
            Permissions permissions = new Permissions();
            permissions.Show();
            ///this.Hide();
        }
        private void Enterance_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!e.Cancel)
            {
                DialogResult result = MessageBox.Show(this, "Uygulamayı Kapatmak İstediğinizden Emin Misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    e.Cancel = false;
                    Application.Exit();
                }                    
                else e.Cancel = true;
            }            
        }
        private void Enterance_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                permissionController();
            }
        }
        public static Enterance enterance
        {
            get
            {
                if (_enterance == null)
                {
                    _enterance = new Enterance();
                }
                return _enterance;
            }
        }
        private static Enterance _enterance;

        private void refresh_Click(object sender, EventArgs e)
        {
            permissionController();
        }

        private void urun_Click(object sender, EventArgs e)
        {
            Products products = new Products();
            products.Show();
        }
    }
}
