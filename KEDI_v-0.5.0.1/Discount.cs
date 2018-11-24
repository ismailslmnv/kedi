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
    public partial class Discount : MetroForm
    {
        public Discount()
        {
            InitializeComponent();
            _loader();
        }
        public static int UrunID;       
        private void _loader()
        {
            try
            {
                int _urunID = UrunID;
                using (KEDIDBEntities kEDIDB = new KEDIDBEntities())
                {
                    var result = (from u in kEDIDB.Urunlers where u.UrunID == _urunID select u).FirstOrDefault();
                    if (result != null)
                    {
                        this.productName.Text = result.UrunAdi;
                        this.price.Text = result.Fiyat.ToString();
                    }
                }

            }catch(Exception ex)
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
        private void OK_Clicked()
        {
            decimal _price = intChecker(discountValue.Text);
            if (_price>-1)
            {
                int _urunID = UrunID;
                    try
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        using (KEDIDBEntities KEDIDB = new KEDIDBEntities())
                        {
                            Indirimler indirim = new Indirimler()
                            {
                                IndirimAdi = dicountName.Text,
                                UrunID = _urunID,
                                Oran = _price,                                
                                Tarih = DateTime.Now                                                             
                            };
                            KEDIDB.Indirimlers.Add(indirim);
                            KEDIDB.SaveChanges();
                            MessageBox.Show("Indirim Başarıyla Eklendi.");
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
                if (text != null && dicountName.Text != null)
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
        private void calcDiscount()
        {
            decimal value = intChecker(discountValue.Text.Trim());
            decimal firstValue = Convert.ToDecimal(price.Text.Trim());
            finalPrice.Text = (firstValue-(firstValue * value / 100)).ToString();
        }

        private void discountValue_TextChanged_1(object sender, EventArgs e)
        {
            if(discountValue.Text!=null)
                calcDiscount();
        }
    }
}
