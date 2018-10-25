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
    public partial class Form1 : Form
    {
        KEDIDBEntities context;
        private int checkState = -1;
        public Form1()
        {
            InitializeComponent();         
        }

        private void menubuttons_Paint(object sender, PaintEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }

        private void ustMenu_Click(object sender, EventArgs e)
        {
            this.Text = "Yönetim Arayüzü - Üst Menü";
            checkState = 0;
            refresher();

        }

        private void ürünlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "Yönetim Arayüzü - Ürünler";
            checkState = 1;
            refresher();
        }
        // Ekle Butonu // Var olan Sekmeye Göre Çalışır
        private void add_Click(object sender, EventArgs e)
        {
            try
            {
                // Urun Listele Menusu acik
                if (checkState == 1)
                {
                    UrunEkle urunEkle = new UrunEkle();
                    urunEkle.Show();
                }
                // Ust Menu Listele acik
                else if (checkState == 0)
                {
                    UstMenuEkle ustMenuEkle = new UstMenuEkle();
                    ustMenuEkle.Show();
                }
                else if (checkState == 2)
                {
                    IndirimEkle indirimEkle = new IndirimEkle();
                    indirimEkle.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void refresher()
        {
            try
            {
                menu.Visible = true;
                // Urun Listele Menusu Acik
                if (checkState == 1)
                {
                    // listele
                    /*
                     * Burada Büyük
                     * hatalar var
                     * query gözden geçirilecek
                     * yoruldum
                     * sinirlerim bozuldu.......
                     * 03.06.2018   22.34...........................
                     * 
                     * 
                     * 
                     * 
                     * 
                     * 
                     * 
                     * */
                    using (context = new KEDIDBEntities())
                    {
                        var query = (from urun in context.Urunlers
                                    where urun.UstUrunID.HasValue == true
                                    where urun.AltOzellik == false
                                    from ustmenu in context.Urunlers.Where(b=>urun.UstUrunID==b.UrunID)
                                    from indirim in context.Indirimlers.Where(c=>urun.UrunID==c.UrunID).DefaultIfEmpty()
                                    select new
                                    {
                                        urun.UrunID,
                                        urun.UrunAdi,
                                        urun.Fiyat,
                                        urun.Tarih,
                                        UstUrunAdi = ustmenu.UrunAdi,
                                        urun.Notlar,
                                        //indirimID=(int?)indirim.IndirimID??0,
                                        indirimAdi = indirim.IndirimAdi ?? null,
                                        indirimOrani =(decimal?)indirim.Oran??0,                                        
                                    }).ToList();
                        var urunler = query;
                        //var query1= from e in context.Indirimlers                            
                        lists.DataSource = urunler;
                        lists.Columns[1].HeaderText = "Ürün Adı";
                        lists.Columns[4].HeaderText = "Üst Menü Adı";
                        lists.Columns[3].HeaderText = "Eklenme Tarihi";
                        lists.Columns[6].HeaderText = "İndirim Adı";
                        lists.Columns[7].HeaderText = "İndirim Oranı (%)";
                    }
                    urunListele.CheckState = CheckState.Unchecked;
                }
                // Ust Menu Listele Menusu Acik
                else if (checkState == 0)
                {
                    using (context = new KEDIDBEntities())
                    {
                        var query = from c in context.Urunlers
                                    where c.UstUrunID.HasValue == false
                                    select new { c.UrunID, c.UrunAdi, c.Tarih, c.Notlar };
                        var urunler = query.ToList();
                        lists.DataSource = urunler;
                        lists.Columns[1].HeaderText = "Üst Menü Adı";
                        lists.Columns[2].HeaderText = "Eklenme Tarihi";
                    }
                    ustMenu.CheckState = CheckState.Unchecked;
                }
                // Indirimler
                else if (checkState == 2)
                {
                    using (context = new KEDIDBEntities())
                    {
                        var query = (from indirim in context.Indirimlers
                                     from urun in context.Urunlers.Where(u=>indirim.UrunID==u.UrunID).DefaultIfEmpty()
                                     select new
                                     {
                                         indirim.IndirimID,
                                         indirim.IndirimAdi,
                                         indirim.Oran,
                                         indirim.Tarih,
                                         urunID = (int?)urun.UrunID??-1,
                                         urun.UrunAdi
                                     }).ToList();
                        lists.DataSource = query;
                        lists.Columns[0].HeaderText = "İndirim ID";
                        lists.Columns[1].HeaderText = "İndirim Adı";
                        lists.Columns[4].HeaderText = "Ürün ID";
                        lists.Columns[5].HeaderText = "Ürün Adı";
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show(this, "Silme İşlemini Onaylıyor musunuz?", "Ürün Silme", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (res == DialogResult.OK)
            {
                try
                {
                    int silmeID = Convert.ToInt32(lists.SelectedRows[0].Cells[0].Value);
                    if (checkState == 0 || checkState == 1)
                    {                        
                        using (var context = new KEDIDBEntities())
                        {
                            var result = (from d in context.Urunlers where d.UrunID == silmeID select d).First();
                            var deleter = context.Set<Urunler>();
                            deleter.Remove(result);
                            context.SaveChanges();
                        }
                    }
                    // Idirim 
                    else if (checkState == 2)
                    {
                        using (var context = new KEDIDBEntities())
                        {
                            var result = (from d in context.Indirimlers where d.IndirimID == silmeID select d).First();
                            var deleter = context.Set<Indirimler>();
                            deleter.Remove(result);
                            context.SaveChanges();
                        }
                    }
                    refresher();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            refresher();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Edit_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkState==1)
                {
                    UrunDuzenle.urunIDPassed = Convert.ToInt32(lists.SelectedRows[0].Cells[0].Value);
                    UrunDuzenle urunDuzenle = new UrunDuzenle();
                    urunDuzenle.Show();
                }
                else if (checkState==0)
                {
                    UstMenuEdit.urunIDPassed = Convert.ToInt32(lists.SelectedRows[0].Cells[0].Value);
                    UstMenuEdit ustMenuEdit = new UstMenuEdit();
                    ustMenuEdit.Show();
                }
                // indirim
                else if (checkState==2)
                {

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void indirimler_Click(object sender, EventArgs e)
        {
            this.Text = "Yönetim Arayüzü - Ürünler - İndirimler";
            checkState = 2;
            refresher();
        }
    }
}
