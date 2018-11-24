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
    public partial class EditDiscount: MetroForm
    {
        public EditDiscount()
        {
            InitializeComponent();           
            _loader();
        }
        public static int IndirimID;       
        private void _loader()
        {
            try
            {                
                int _IndirimID =IndirimID;
                using (KEDIDBEntities KEDIDB = new KEDIDBEntities())
                {
                    var result = (from indirim in KEDIDB.Indirimlers where indirim.IndirimID==_IndirimID
                                  select indirim).FirstOrDefault();                   
                    if (result != null)
                    {
                        var _result = (from urun in KEDIDB.Urunlers
                                       where urun.UrunID == result.UrunID
                                       select urun).FirstOrDefault();
                        if (_result != null)
                        {
                            this.urunAdi.Text = result.IndirimAdi;                           
                            this.orgPrice.Text = _result.Fiyat.ToString();
                            this.discPrice.Text = (_result.Fiyat-(_result.Fiyat * result.Oran / 100)).ToString();
                            this.price.Text = result.Oran.ToString();
                            _comboboxCreator(Convert.ToInt32(result.UrunID));
                        }                        
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
                decimal _price = intChecker(price.Text);
                if (_price > -1)
                {
                    int menuID = _comboboxSolver();
                    if (menuID >= 0)
                    {                        
                        int _indirimID = IndirimID;
                        Cursor.Current = Cursors.WaitCursor;
                        using (KEDIDBEntities KEDIDB = new KEDIDBEntities())
                        {
                            var result = (from indirim in KEDIDB.Indirimlers
                                          where indirim.IndirimID == _indirimID
                                          select indirim).FirstOrDefault();
                            if (result != null)
                            {
                                result.IndirimAdi = urunAdi.Text;
                                result.UrunID = menuID;
                                result.Oran = _price;
                                //result.Notlar = not.Text;
                                //result.AltOzellik = false;
                            }
                            KEDIDB.SaveChanges();
                            MessageBox.Show("Güncelleme Başarılı..");
                        }
                        _formClosing();
                        this.Dispose();
                    }
                    else MessageBox.Show("Birşeyler Yanlış Gitti..");
                }
                else MessageBox.Show("Lütfen Fiyat Alanına Sadece rakam ve \",\" giriniz.");
            } catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            Cursor.Current = Cursors.Default;
        }
        private void reset()
        {
            try
            {
                int _indirimID =IndirimID;
                using (KEDIDBEntities KEDIDB = new KEDIDBEntities())
                {
                    var result = (from indirim in KEDIDB.Indirimlers where indirim.IndirimID==_indirimID
                                  select indirim).FirstOrDefault();                                        
                    if (result != null)
                    {
                        KEDIDB.Indirimlers.Remove(result);
                        MessageBox.Show("İndirim Başarıyla Silindi Başarıyla Silindi.");
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
            }

        }

        private void EditPersonel_Load(object sender, EventArgs e)
        {

        }

        private void personelAdi_Click(object sender, EventArgs e)
        {

        }

        private void passw_Click(object sender, EventArgs e)
        {

        }
        private decimal intChecker(string text)
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
        private int _comboboxSolver()
        {
            try
            {
                string selectedItem = menuSelect.SelectedItem.ToString();
                using (KEDIDBEntities kEDIDB = new KEDIDBEntities())
                {
                    var result = (from urun in kEDIDB.Urunlers
                                  where urun.UrunAdi.Equals(selectedItem)
                                  select urun.UrunID).FirstOrDefault();
                    if (result > 0)
                        return result;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return -1;
        }
        private void  _comboboxCreator(int _urunID)
        {
            try
            {
                using (KEDIDBEntities kEDIDB = new KEDIDBEntities())
                {
                    var result = (from urun in kEDIDB.Urunlers where urun.UrunID== _urunID
                                  select urun.UrunAdi).FirstOrDefault();
                    var _result = (from urun in kEDIDB.Urunlers
                                   where urun.UstUrunID!=0
                                   where urun.AltOzellik==false
                                   select urun.UrunAdi).DefaultIfEmpty().ToList();
                    if(_result != null)
                    {
                        foreach(var item in _result)
                        {
                            this.menuSelect.Items.Add(item);                            
                        }
                        this.menuSelect.SelectedItem = result;
                    }                                       
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }            
        }

        private void price_TextChanged(object sender, EventArgs e)
        {
            if(price.Text!=null && orgPrice.Text!=null && discPrice.Text != null)
            {
                this.discPrice.Text = (Convert.ToDecimal(this.orgPrice.Text.Trim()) -
                    (Convert.ToDecimal(this.orgPrice.Text.Trim()) * 
                    Convert.ToDecimal(this.price.Text.Trim()) / 100)).ToString();
            }
        }
    }
}
