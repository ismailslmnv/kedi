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
    public partial class AddProduct : MetroForm
    {
        public AddProduct()
        {
            InitializeComponent();
            menuLoader();
        }
        private void menuLoader()
        {
            List<Urunler> urun = new List<Urunler>();
            try
            {
                using (KEDIDBEntities kEDIDB = new KEDIDBEntities())
                {
                    var result = (from urunler in kEDIDB.Urunlers
                                  where urunler.UstUrunID==null
                                  select urunler.UrunAdi).DefaultIfEmpty().ToList();
                    if (result != null)
                    {
                        foreach(var item in result)
                        {
                            menuSelect.Items.Add(item);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }     
        private void AddProduct_Load(object sender, EventArgs e)
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
                string selectedItem = menuSelect.SelectedItem.ToString();
                using (KEDIDBEntities kEDIDB = new KEDIDBEntities())
                {
                    var result = (from menu in kEDIDB.Urunlers
                                  where menu.UrunAdi.Equals(selectedItem)
                                  select menu.UrunID).FirstOrDefault();
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
            decimal _price = intChecker(price.Text);
            if (_price>-1)
            {
                int menuID = _comboboxSolver();
                if (menuID >= 0)
                {
                    try
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        using (KEDIDBEntities KEDIDB = new KEDIDBEntities())
                        {
                            Urunler urun = new Urunler()
                            {
                                UrunAdi = urunAdi.Text,
                                UstUrunID = menuID,
                                Fiyat = _price,
                                Notlar = not.Text,
                                Tarih = DateTime.Now,
                                AltOzellik = false
                                
                            };
                            KEDIDB.Urunlers.Add(urun);
                            KEDIDB.SaveChanges();
                            MessageBox.Show("Ürün Başarıyla Eklendi.");
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
            else MessageBox.Show("Lütfen Fiyat Alanına Sadece rakam ve \",\" giriniz.");
        }
        private  void reset()
        {
            AddProduct add = new AddProduct();
            add.Show();
            this.Close();         
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
            this.Dispose();
        }
        private decimal  intChecker(string text)
        {
            try
            {
                if (text != null && urunAdi.Text != null && menuSelect.SelectedItem != null)
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
                                case ',': break;
                                default: return -1;
                            }
                        }
                    }
                    return Convert.ToDecimal(text.Trim());
                }
                else
                    MessageBox.Show("Lütfen Zorunlu Alanları Doldurunuz.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
               
            }
            return -1;
        }
    }
}
