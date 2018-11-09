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
            ProductLoader();
        }
        public static int ProductID;
        private void ProductLoader()
        {           
            try
            {
                using (KEDIDBEntities kEDIDB = new KEDIDBEntities())
                {
                    var result = (from urun in kEDIDB.Urunlers
                                  where urun.UstUrunID>0
                                  where urun.AltOzellik==false                               
                                  select urun.UrunAdi).DefaultIfEmpty().ToList();
                    if (result != null)
                    {
                        foreach(var item in result)
                        {
                            prodSelect.Items.Add(item);
                        }
                        _comboboxCreator();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }     
        private void _comboboxCreator()
        {
            int _productID = ProductID;
            try
            {
                using (KEDIDBEntities kEDIDB = new KEDIDBEntities())
                {
                    var result = (from urun in kEDIDB.Urunlers
                                  where urun.UrunID == _productID
                                  select urun.UstUrunID).FirstOrDefault();
                    var _result = (from urun in kEDIDB.Urunlers
                                   where urun.UrunID == result.Value
                                   select urun.UrunAdi).FirstOrDefault();
                    if (_result != null)
                    {
                        prodSelect.SelectedItem = _result;
                    }
                }

            }catch(Exception ex)
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
            this.Close();
            //_formClosing();
        }
        private void Delete_Click(object sender, EventArgs e)
        {
            reset();
        }
        private int _comboboxSolver()
        {
            try
            {
                string selectedItem = prodSelect.SelectedItem.ToString();
                using (KEDIDBEntities kEDIDB = new KEDIDBEntities())
                {
                    var result = (from urun in kEDIDB.Urunlers where urun.UrunAdi.Equals(selectedItem) select urun.UrunID).FirstOrDefault();
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
            decimal price = intChecker(fiyat.Text);
            if (price>-1)
            {
                int prodID = _comboboxSolver();
                if (prodID >= 0)
                {
                    try
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        using (KEDIDBEntities KEDIDB = new KEDIDBEntities())
                        {
                            Urunler urunler = new Urunler()
                            {
                                UrunAdi = ozellikAdi.Text,
                                Fiyat = price,
                                UstUrunID = prodID,
                                AltOzellik =true,
                                Tarih = DateTime.Now,
                                Notlar=not.Text                                
                            };
                            KEDIDB.Urunlers.Add(urunler);
                            KEDIDB.SaveChanges();
                            MessageBox.Show("Alt Özellik Başarıyla Eklendi.");
                            _formClosing();
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
                Cursor.Current = Cursors.Default;
            }            
        }
        private  void reset()
        {
            AddProperty add = new AddProperty();
            add.Show();
            this.Dispose();         
        }

        private void _formClosing()
        {
            var PermissionsReloader = Application.OpenForms.Cast<Form>()
              .FirstOrDefault(c => c is ShowSubProducts);
            if (PermissionsReloader != null)
            {
                PermissionsReloader.Visible = false;
                PermissionsReloader.Visible = true;
            }
            this.Dispose();
        }

        private decimal intChecker(string text)
        {
            try
            {
                if (ozellikAdi.Text != null && prodSelect.SelectedItem != null)
                {
                    if (text != null || !text.Equals(String.Empty)||!text.Equals(" ")||!text.Equals("\t")||!text.Equals("\n"))
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
                    {
                        return 0;
                    }                    
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
