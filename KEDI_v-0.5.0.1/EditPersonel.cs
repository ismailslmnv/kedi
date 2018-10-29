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
    public partial class EditPersonel: MetroForm
    {
        public EditPersonel()
        {
            InitializeComponent();           
            _loader();
        }
        public static int PersonelID;       
        private void _loader()
        {
            try
            {
                
                int _PersonelID =PersonelID;
                using (KEDIDBEntities KEDIDB = new KEDIDBEntities())
                {
                    var result = (from pers in KEDIDB.Personels where pers.KullaniciID == _PersonelID
                                  select pers).FirstOrDefault();
                    if (result != null)
                    {
                        this.personelAdi.Text = result.KullaniciAdi;
                        this.passw.Text = result.Sifre;
                        this.telNum.Text = result.TelefonNum;
                        _comboboxCreator(result.YetkiID);                        
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
                if (intChecker(telNum.Text))
                {
                    int permID = _comboboxSolver();
                    int _PersonelID = PersonelID;
                    Cursor.Current = Cursors.WaitCursor;
                    using (KEDIDBEntities KEDIDB = new KEDIDBEntities())
                    {
                        var result = (from pers in KEDIDB.Personels where pers.KullaniciID == _PersonelID select pers).FirstOrDefault();
                        if (result != null)
                        {
                            result.KullaniciAdi = personelAdi.Text;
                            result.Sifre = passw.Text;
                            result.TelefonNum = telNum.Text;
                            result.YetkiID = permID;
                        }
                        KEDIDB.SaveChanges();
                        MessageBox.Show("Güncelleme Başarılı..");
                    }
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
                int _PersonelID =PersonelID;
                using (KEDIDBEntities KEDIDB = new KEDIDBEntities())
                {
                    var result = (from pers in KEDIDB.Personels where pers.KullaniciID == _PersonelID
                                  select pers).FirstOrDefault();
                    if (result != null)
                    {
                        result.Enabled = false;
                        result.DisableTarih = DateTime.Now;
                        KEDIDB.SaveChanges();
                        MessageBox.Show("Kullanıcı Başarıyla Silindi.");
                    }
                    else MessageBox.Show("Beklenmedik Bir Hata Oluştu.");                    
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return -1;
        }
        private void  _comboboxCreator(int permID)
        {
            try
            {
                using (KEDIDBEntities kEDIDB = new KEDIDBEntities())
                {
                    var result = (from yetki in kEDIDB.Yetkilers where yetki.YetkiID == permID
                                  select yetki.YetkiAdi).FirstOrDefault();
                    var _result = (from yetki in kEDIDB.Yetkilers
                                   select yetki.YetkiAdi).DefaultIfEmpty().ToList();
                    if(_result != null)
                    {
                        foreach(var item in _result)
                        {
                            this.permSelect.Items.Add(item);
                            this.permSelect.SelectedItem = result;
                        }
                    }                                       
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }            
        }
    }
}
