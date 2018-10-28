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
    public partial class AddProperty : MetroForm
    {
        public AddProperty()
        {
            InitializeComponent();
            PermissionsLoader();
        }
        private void PermissionsLoader()
        {
            List<Yetkiler> yetkilers = new List<Yetkiler>();
            try
            {
                using (KEDIDBEntities kEDIDB = new KEDIDBEntities())
                {
                    var result = (from yetkiler in kEDIDB.Yetkilers
                                  select yetkiler.YetkiAdi).DefaultIfEmpty().ToList();
                    if (result != null)
                    {
                        foreach(var item in result)
                        {
                            permSelect.Items.Add(item);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }     
        private void EditPermissions_Load(object sender, EventArgs e)
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
        private int _comboboxSolver()
        {
            try
            {
                string selectedItem = permSelect.SelectedItem.ToString();
                using (KEDIDBEntities kEDIDB = new KEDIDBEntities())
                {
                    var result = (from yetki in kEDIDB.Yetkilers where yetki.YetkiAdi.Equals(selectedItem) select yetki.YetkiID).FirstOrDefault();
                    if (result > 0)
                        return result;
                }          
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return -1;
        }
        private void OK_Clicked()
        {            
            if (intChecker(telNum.Text))
            {
                int permID = _comboboxSolver();
                if (permID >= 0)
                {
                    try
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        using (KEDIDBEntities KEDIDB = new KEDIDBEntities())
                        {
                            Personel personel = new Personel()
                            {
                                KullaniciAdi = personelAdi.Text,
                                Sifre = passw.Text,
                                TelefonNum = telNum.Text,
                                YetkiID = permID,
                                Tarih = DateTime.Now,
                                Enabled=true
                                
                            };
                            KEDIDB.Personels.Add(personel);
                            KEDIDB.SaveChanges();
                            MessageBox.Show("Kullanıcı Başarıyla Eklendi.");
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Birşeyler Yanlış Gitti. İşlem Tamamlanamadı..");
                }
                _formClosing();
                Cursor.Current = Cursors.Default;
            }            
        }
        private  void reset()
        {
            AddPermission add = new AddPermission();
            add.Show();
            this.Dispose();         
        }
        private void _formClosing()
        {
            var PermissionsReloader = Application.OpenForms.Cast<Form>()
              .FirstOrDefault(c => c is Permissions);
            if (PermissionsReloader != null)
            {
                PermissionsReloader.Visible = false;
                PermissionsReloader.Visible = true;
            }
            this.Dispose();
        }
        private bool intChecker(string text)
        {
            try
            {
                if (text != null && personelAdi.Text != null && passw.Text != null && permSelect.SelectedItem != null)
                {
                    foreach (char item in text)
                    {
                        if (item != ' ' || item != '\t' || item != '\n')
                        {
                            switch (item)
                            {
                                case '0': break;
                                case '1': break;
                                case '2': break;
                                case '3': break;
                                case '4': break;
                                case '5': break;
                                case '6': break;
                                case '7': break;
                                case '8': break;
                                case '9': break;
                                default: return false;
                            }
                        }
                    }
                    return true;
                }
                else
                    MessageBox.Show("Bütün Alanların Doldurulması Zorunludur.s");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
               
            }
            return false;
        }
    }
}
