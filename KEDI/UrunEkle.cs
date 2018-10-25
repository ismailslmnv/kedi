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
    
    public partial class UrunEkle : Form
    {
        private int altOzellikSayisi = 0;
        List<AltOzellikler> altOzellikler = new List<AltOzellikler>();
        public UrunEkle()
        {
            InitializeComponent();
            using (var context = new KEDIDBEntities())
            {
                var result = from c in context.Urunlers where c.UstUrunID.HasValue == false select c.UrunAdi;
                var menuler = result.ToList();
                UstMenu.DataSource = menuler;
            }
            if (UstMenu.Items.Count == 0)
            {
                MessageBox.Show(this, "Üst Menü Eklenmemiş. Lütfen İlk Önce Üst Menü Sekmesinden Üst Menü Ekleyiniz!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(UstMenu.SelectedValue.ToString().Trim());
            try
            {
                // Urunleri Ekleme Butonu
                // Ilk basta ana urun eklenecek// daha sonra ise alt ozellikleri eklenecek
                using (var context = new KEDIDBEntities())
                {
                    var inserter = context.Set<Urunler>();
                    inserter.Add(new Urunler { UrunAdi = UrunAdi.Text.Trim(), Fiyat = Convert.ToDecimal(UrunFiyat.Text.Trim()), UstUrunID = getUsturunID(UstMenu.SelectedValue.ToString().Trim()), Notlar = Notlar.Text.Trim(), Tarih = DateTime.Now, AltOzellik=false});
                    context.SaveChanges();
                }
                int UsturunID = getUsturunID(UrunAdi.Text.Trim());
                for (int i = 0; i < altOzellikler.Count; i++)
                {                   
                    using (var context = new KEDIDBEntities())
                    {
                        var inserter = context.Set<Urunler>();
                        inserter.Add(new Urunler { UrunAdi = altOzellikler[i].AltOzellikAdi.Trim(), Fiyat = altOzellikler[i].Fiyat, UstUrunID = UsturunID, Tarih=DateTime.Now, AltOzellik=true });                        
                        context.SaveChanges();
                    }
                }
                MessageBox.Show("Ürün Ekleme İşlemi Başarıyla Gerçekleşti...");
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString());
            }
        }
        private int getUsturunID(string urunAdi)
        {
            int returnCase =-1;
            using (var context = new KEDIDBEntities())
            {
                var returned = (from c in context.Urunlers where urunAdi.Trim().Equals(c.UrunAdi) select c.UrunID).First();
                var data = returned;
                if (true)
                {
                    returnCase = Convert.ToInt32(data);
                }
            }
            return returnCase;
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void AltOzellikSayisi_ValueChanged(object sender, EventArgs e)
        {
            if (AltOzellikSayisi.Value != 0)
            {
                AltOzellikler.Visible = true;
                altOzellikSayisi = (int)AltOzellikSayisi.Value;
            }
            else AltOzellikler.Visible = false;
        }

        private void add_Click(object sender, EventArgs e)
        {
            double outed = 0;
            if (altOzellikSayisi !=0 && Double.TryParse(altozellikfiyati.Text.Trim(), out outed))
            {
                altOzellikler.Add(new AltOzellikler { AltOzellikAdi = altozellikadi.Text, Fiyat = Convert.ToDecimal(altozellikfiyati.Text.Trim())});
                altozellikadi.Text = String.Empty;
                altozellikfiyati.Text = "0";
                int eklendi = Convert.ToInt32(eklenen.Text);
                eklenen.Text = (++eklendi).ToString();
                AltOzellikSayisi.Value--;
            }
            else
            {
                MessageBox.Show("Hatalı İşlem!", "Hata",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //string elements = string.Empty;
            //foreach (AltOzellikler element in altOzellikler)
            //{
            //    elements += element.AltOzellikAdi + element.Fiyat + "\n";
            //}
            //MessageBox.Show(elements);
            this.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void UrunEkle_Load(object sender, EventArgs e)
        {

        }
    }
    class AltOzellikler
    {
        string altOzellikAdi;
        decimal fiyat;
        public string AltOzellikAdi
        {
            get
            {
                return altOzellikAdi;
            }
            set
            {
                altOzellikAdi = value;
            }
        }
        public decimal Fiyat
        {
            get
            {
                return fiyat;
            }
            set
            {
                fiyat = value;
            }
        }
    }
}
