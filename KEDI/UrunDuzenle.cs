using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KEDI
{    
    public partial class UrunDuzenle : Form
    {
        public static int urunIDPassed = -1;
        private bool yeniOzellik = false;
        private int altozellikID;
        public UrunDuzenle()
        {            
            InitializeComponent();
            if (urunIDPassed != -1)
            {
                firstcreator();
            }
        }

        private void ok_Click(object sender, EventArgs e)
        {
            try
            {
                string ustMenuIDToCast = ustMenu.SelectedItem.ToString().Trim();
               // ustMenuIDToCast = ustMenuIDToCast.Substring(0, ustMenuIDToCast.IndexOf('-')).Trim();
                //int ustMenuID = Convert.ToInt32(ustMenuIDToCast);
               // MessageBox.Show(ustMenuIDToCast);
                using (var context = new KEDIDBEntities())
                {
                    var result = (from c in context.Urunlers where c.UrunID == urunIDPassed select c).First();
                    var usturunResult = (from d in context.Urunlers
                                        where d.UrunAdi.Equals(ustMenuIDToCast)
                                        select d.UrunID).First();
                    result.UrunAdi = urunAdi.Text.Trim();
                    result.UstUrunID = usturunResult;
                    result.Notlar = notlar.Text.Trim();
                    result.Fiyat = Convert.ToDecimal(fiyat.Text.Trim());
                    result.Tarih = DateTime.Now;
                    context.SaveChanges();                   
                }
                MessageBox.Show("Ürün Düzenleme İşlemi Başarıyla Gerçekleşti...");
                this.Close();
            } catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void firstcreator()
        {   
            altozellikler.Items.Clear();
            ustMenu.Items.Clear();
            altozellikAdi.Text = string.Empty;
            fiyatFarki.Text = "0";
            using (var context = new KEDIDBEntities())
            {
                var query = from c in context.Urunlers
                            where c.UrunID ==urunIDPassed // buraya diger sayfadan gelen urunID gelecek
                                join d in context.Urunlers
                                on c.UstUrunID equals d.UrunID
                            where c.UstUrunID == d.UrunID
                            select new
                            {
                                c.UrunID,
                                c.UrunAdi,
                                UstUrunAdi = d.UrunAdi,
                                c.Notlar,
                                c.Fiyat
                            };
                    var urunler = query.ToList();
                urunAdi.Text = urunler[0].UrunAdi;
                usturunlerList();
                ustMenu.SelectedItem = urunler[0].UstUrunAdi;
                altOzellikList(urunler[0].UrunID);
                fiyat.Text = urunler[0].Fiyat.ToString();
                notlar.Text = urunler[0].Notlar;
            }
        }
        private void usturunlerList()
        {
            try
            {
                using (var context = new KEDIDBEntities())
                {
                    var result = from c in context.Urunlers
                                 where c.UstUrunID.HasValue == false
                                 select new { c.UrunID,c.UrunAdi};
                    var elements = result.ToList();
                    foreach (var item in elements)
                    {
                        ustMenu.Items.Add(item.UrunAdi);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void altOzellikList(int urunID)
        {
            try
            {
                using (var context = new KEDIDBEntities())
                {
                    var result = from c in context.Urunlers
                                 where c.AltOzellik == true
                                 where c.UstUrunID == urunID
                                 select new { c.UrunID, c.UrunAdi, c.Fiyat };
                    var elements = result.ToList();
                    foreach (var item in elements)
                    {
                        altozellikler.Items.Add(item.UrunID+"-"+item.UrunAdi + " - " + item.Fiyat);
                    }
                    altozellikler.Items.Add("Yeni Ekle");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void altozellikler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!altozellikler.SelectedItem.ToString().Trim().Equals("Yeni Ekle"))
            {
                yeniOzellik = false;
                try
                {
                    string valueToCast = altozellikler.SelectedItem.ToString();                   
                    string valueToCastID = valueToCast.Trim().Substring(0, valueToCast.IndexOf('-'));
                    valueToCast = valueToCast.Trim().Substring(valueToCast.IndexOf('-') + 1);
                    int outed = -1;
                    if (Int32.TryParse(valueToCastID.Trim(), out outed))
                    {
                        altozellikID = Convert.ToInt32(valueToCastID);
                        string altOzellikAdi = valueToCast.Trim().Substring(0, valueToCast.IndexOf('-'));
                        string altOzellikFiyat = valueToCast.Trim().Substring(valueToCast.IndexOf('-') + 1);
                        altozellikAdi.Text = altOzellikAdi;
                        fiyatFarki.Text = altOzellikFiyat;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                yeniOzellik = true;
            }
        }

        private void UrunDuzenle_Load(object sender, EventArgs e)
        {

        }

        private void add_Click(object sender, EventArgs e)
        {
            try
            {
                // yeni ozellik eklenecekse 
                if (yeniOzellik)
                {
                    using (var context = new KEDIDBEntities())
                    {
                        var inserter = context.Set<Urunler>();
                        inserter.Add(new Urunler
                        {
                            UrunAdi = altozellikAdi.Text.Trim(),
                            AltOzellik = true,
                            Fiyat = Convert.ToDecimal(fiyatFarki.Text.Trim()),
                            UstUrunID = urunIDPassed,
                            Tarih = DateTime.Now
                        });
                        context.SaveChanges();
                    }
                }
                else
                {
                    using (var context = new KEDIDBEntities())
                    {
                        var result = (from c in context.Urunlers where c.UrunID == altozellikID select c).First();
                        result.UrunAdi = altozellikAdi.Text.Trim();
                        result.Fiyat = Convert.ToDecimal(fiyatFarki.Text.Trim());
                        context.SaveChanges();
                    }
                }
                MessageBox.Show("Alt Özellik Başarıyla Eklendi/Düzenlendi..");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            firstcreator();
        }

        private void remove_Click(object sender, EventArgs e)
        {
            if (!yeniOzellik)
            {
                DialogResult res = MessageBox.Show(this, "Silme İşlemini Onaylıyor musunuz?", "Ürün Silme", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (res == DialogResult.OK)
                {
                    try
                    {
                        using (var context = new KEDIDBEntities())
                        {
                            var result = (from d in context.Urunlers where d.UrunID == altozellikID select d).First();
                            var deleter = context.Set<Urunler>();
                            deleter.Remove(result);
                            context.SaveChanges();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            firstcreator();
        }
    }
}
