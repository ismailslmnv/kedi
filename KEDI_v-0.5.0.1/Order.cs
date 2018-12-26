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
using MetroFramework.Controls;
using System.Drawing.Printing;

namespace KEDI_v_0._5._0._1
{
    public partial class Order : MetroForm
    {
        public static int PersonalID;
        public static int persCount;
        private double _countPrice=0.0;
        List<Salonlar> _salon = new List<Salonlar>();
        List<List<string>> _productToShow = new List<List<string>>();
        List<Siparisler> toPrint = new List<Siparisler>();
        private List<MetroTile> masalar = new List<MetroTile>();
        List<Urunler> urunler = new List<Urunler>();
        List<int> selectedProdIDs = new List<int>();
        private int oldProds=0;
        int salonPanelType = 0; // 1 - Salon
        int tablePanelType = 0; // 1 - Masa
        int selectedSalonID = 0;
        int selectedTableID = 0;
        int selectedMenuID = 0;
        int selectedPaymentMethod = 0;
        bool printClicked = false;
        bool moveClicked = false;
        bool sourceSelected = false;
        bool destinationSelected = false;
        int sourceTable = 0;
        bool combineClicked = false;
        string selectedTableName = String.Empty;
        public Order()
        {
            InitializeComponent();
            move.Enabled = false;
            combine.Enabled = false;
            UserActivater();
            salonLoader();                        
        }
        private void UserActivater()
        {
            try
            {
                using (KEDIDBEntities context = new KEDIDBEntities())
                {
                    var result = (from user in context.Personels
                                  where user.KullaniciID == PersonalID
                                  select user).FirstOrDefault();
                    if (result != null)
                    {
                        var yetkiAdi = (from yetki in context.Yetkilers
                                        where yetki.YetkiID == result.YetkiID
                                        select yetki).FirstOrDefault();
                        if (yetkiAdi!=null)
                        {
                            username.Text = result.KullaniciAdi + " - " + yetkiAdi.YetkiAdi;
                            PermissionController(yetkiAdi);
                        }
                        else
                        {                            
                            throw new Exception();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Veritabanında Kullanıcı Bilgilerine Ulaşılamadı - Enterance 102");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void PermissionController(Yetkiler yetki)
        {
            move.Visible = yetki.MasaTasima;
            combine.Visible = yetki.MasaBirlestirme;
            payment.Visible = yetki.HesapAlma & yetki.HesapIptal;
        }
        private void save_Click(object sender, EventArgs e)
        {
            for (int i = oldProds; i < urunList.Items.Count; i++)
            {
                int urunID = getUrunID(urunList.Items[i].Text);
                if (urunID!=-1)
                {
                    DbSaver(urunID, Convert.ToDecimal(urunList.Items[i].SubItems[1].Text));                                        
                }                
            }
            if (oldProds!=urunList.Items.Count)
            {
                printNewOrder();
            }
            masaLoader(selectedSalonID.ToString());
        }
        private void printNewOrder()
        {
           // PrintDialog dialog = new PrintDialog();
            PrintDocument print = new PrintDocument();
            //dialog.Document = print;
            print.DocumentName = "Yeni Ürün Adisyonu";
            print.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(newOrderDocument);
            print.PrintController = new StandardPrintController();
           // DialogResult res = dialog.ShowDialog();

            PrinterSettings ps = new PrinterSettings();
            ps.PrinterName = "KediPosYazici1";
            //ps.PrintToFile = true;
            print.PrinterSettings = ps;

            //if (res==DialogResult.OK)
            //{
                print.Print();
           // }
        }

        private void newOrderDocument(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Font font = new Font("Arial", 10);
            float fontHeight = font.Height;
            int startX = 10;
            int startY = 10;
            int offset = 30;
            graphics.DrawString("NANA Cafe & Restaurant", new Font("Arial", 15), new SolidBrush(Color.Green), startX, startY);

            string _top = "Masa:" + pickTable();
            graphics.DrawString(_top, font, new SolidBrush(Color.Black), startX, startY + offset);

            offset += 5 + (int)fontHeight;
            string __top = "Garson:" + pickUser();
            graphics.DrawString(__top, font, new SolidBrush(Color.Black), startX, startY + offset);

            offset += 5 + (int)fontHeight;
            string ___top = "Sipariş Tarihi:" + DateTime.Now;
            graphics.DrawString(___top, font, new SolidBrush(Color.Black), startX, startY + offset);

            offset += 5 + (int)fontHeight;
            string ____top = "Kişi Sayısı:" + persCount;
            graphics.DrawString(____top, font, new SolidBrush(Color.Black), startX, startY + offset);

            offset += 5 + (int)fontHeight;
            string _____top = "Adisyon Numarası:" + AdisyonName.Text;
            graphics.DrawString(_____top, font, new SolidBrush(Color.Black), startX, startY + offset);

            offset += 10 + (int)fontHeight;
            string top = "Ürün Adı".PadRight(40) + "Adet";
            graphics.DrawString(top, font, new SolidBrush(Color.Black), startX, startY + offset);

            offset += (int)fontHeight;
            graphics.DrawString("--------------------------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
            offset += 5 + (int)fontHeight;

            StringFormat drawFormatCenter = new StringFormat();
            drawFormatCenter.Alignment = StringAlignment.Center;
            StringFormat drawFormatLeft = new StringFormat();
            drawFormatLeft.Alignment = StringAlignment.Near;
            StringFormat drawFormatRight = new StringFormat();
            drawFormatRight.Alignment = StringAlignment.Far;

            string _line;
            for (int i = oldProds; i < urunList.Items.Count; i++)
            {
                //int space = top.Length - (urunList.Items[i].Text.Length + urunList.Items[i].SubItems[1].Text.Length);                     ;
                _line = urunList.Items[i].Text;
                graphics.DrawString(_line, font, new SolidBrush(Color.Black), new RectangleF(startX,startY+offset, 270,0),drawFormatLeft);
                _line = urunList.Items[i].SubItems[1].Text;
                graphics.DrawString(_line, font, new SolidBrush(Color.Black), new RectangleF(startX, startY + offset, 270, 0), drawFormatRight);
                offset += 5+(int)fontHeight;
            }
        }       
        private string pickUser()
        {
            try
            {
                using (KEDIDBEntities kEDIDB = new KEDIDBEntities())
                {
                    var result = (from kullanici in kEDIDB.Personels where kullanici.KullaniciID == PersonalID select kullanici.KullaniciAdi).FirstOrDefault();
                    return result;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            return String.Empty;
        }
        private string pickTable()
        {
            try
            {
                using (KEDIDBEntities kEDIDB = new KEDIDBEntities())
                {
                    var result = (from masa in kEDIDB.Masalars where masa.MasaID == selectedTableID select masa.MasaAdi).FirstOrDefault();
                    return result;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            return string.Empty;
        }
        private void DbSaver(int urunID, decimal count)
        {
            try
            {
                string generatedAdisyon = AdisyonName.Text;
                
                if (string.IsNullOrEmpty(generatedAdisyon))
                {
                    generatedAdisyon = getToday();
                    AdisyonName.Text = generatedAdisyon;

                }                
                using (KEDIDBEntities kEDIDB = new KEDIDBEntities())
                {                    
                    Siparisler yeniSiparis = new Siparisler()
                    {
                        MasaID = selectedTableID,
                        KullaniciID = PersonalID,
                        SiparisAdi = generatedAdisyon,                      
                        UrunID = urunID,
                        UrunSayi = count,
                        Tarih = DateTime.Now
                    };
                    kEDIDB.Siparislers.Add(yeniSiparis);
                    kEDIDB.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private int getUrunID(string urunAdi)
        {
            try
            {
                if (urunAdi[0]=='*')
                {
                    urunAdi = urunAdi.Substring(3);
                }
                using (KEDIDBEntities kEDIDB=new KEDIDBEntities())
                {
                    var result = (from urun in kEDIDB.Urunlers where urun.UrunAdi.Equals(urunAdi) select urun.UrunID).First();
                    return result;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return -1;
            }
        }
        private string getToday()
        {
            return DateTime.Today.Day + "" + DateTime.Today.Month + "" + DateTime.Today.Year + "" + DateTime.Now.Hour + "" + DateTime.Now.Minute + "" + selectedTableName + "p" + persCount;
        }
        private void tileCreator(string tileText, string tileID, int Type,int isMasaFull)//Type -- 1=Salon 2=Masa 3=Menu 4=Urun 5=SubProd
        {
            urunTABLE.Visible = true;
            //     _tile.UseTileImage = true;
 
            if (Type == 1)//salon
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(Order));
                MetroTile _tile = new MetroTile();
                _tile.Dock = System.Windows.Forms.DockStyle.Top;
                _tile.Location = new System.Drawing.Point(100, 10);
                _tile.Name = tileID;
                _tile.Size = new System.Drawing.Size(902, 60);
                _tile.Style = MetroFramework.MetroColorStyle.Yellow;
                _tile.Text = tileText;
                _tile.TextAlign = ContentAlignment.MiddleLeft;
                _tile.TileTextFontSize = MetroTileTextSize.Tall;
                _tile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
                _tile.UseSelectable = true;
                _tile.Click += _tile_Click;
                sidePanel.Controls.Add(_tile);
                sidePanel.Controls.Add(breaker(tileID + 1));
            }
            else if(Type==2)//masa
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(Order));
                MetroTile _tile = new MetroTile();
                _tile.Dock = System.Windows.Forms.DockStyle.Left;
                _tile.Location = new System.Drawing.Point(100, 10);
                _tile.Name = tileID;
                _tile.Size = new System.Drawing.Size(100, 60);
                if (isMasaFull==1)
                    _tile.Style = MetroFramework.MetroColorStyle.Teal;
                else
                    _tile.Style = MetroFramework.MetroColorStyle.Brown;
                _tile.Text = tileText;
                _tile.TextAlign = ContentAlignment.MiddleLeft;
                _tile.TileTextFontSize = MetroTileTextSize.Small;
                _tile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
                _tile.UseSelectable = true;               
                _tile.Click += _masa_Click;
                urunTABLE.Controls.Add(_tile);
                masalar.Add(_tile);
            }
            else if (Type==3)// Menu
            {
                urunTABLE.Controls.Clear();
                MetroTile _tile = new MetroTile();
                _tile.Dock = System.Windows.Forms.DockStyle.Left;
                _tile.Location = new System.Drawing.Point(100, 10);
                _tile.Name = tileID;
                _tile.Size = new System.Drawing.Size(150, 60);
                _tile.Style = MetroFramework.MetroColorStyle.Lime;
                _tile.Text = tileText;
                _tile.TextAlign = ContentAlignment.MiddleCenter;
                _tile.TileTextFontSize = MetroTileTextSize.Small;
                _tile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
                _tile.UseSelectable = true;              
                _tile.Click += _menu_Click;
                MenuTable.Controls.Add(_tile);
            }
            else if (Type==4)//urun
            {
                MetroTile _tile = new MetroTile();
                _tile.Dock = System.Windows.Forms.DockStyle.Left;
                _tile.Location = new System.Drawing.Point(100, 10);
                _tile.Name = tileID;
                _tile.Size = new System.Drawing.Size(100, 60);
                _tile.Style = MetroFramework.MetroColorStyle.Blue;
                _tile.Text = tileText;
                _tile.TextAlign = ContentAlignment.MiddleLeft;
                _tile.TileTextFontSize = MetroTileTextSize.Small;
                _tile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Light;
                _tile.UseSelectable = true;                
                _tile.Click += _urun_Click;
                urunTABLE.Controls.Add(_tile);
            }
            else if (Type==5)
            {
                MetroTile _tile = new MetroTile();
                _tile.Dock = System.Windows.Forms.DockStyle.Left;
                _tile.Location = new System.Drawing.Point(100, 10);
                _tile.Name = tileID;
                _tile.Size = new System.Drawing.Size(100, 60);
                _tile.Style = MetroFramework.MetroColorStyle.Blue;
                _tile.Text = tileText;
                _tile.TextAlign = ContentAlignment.MiddleLeft;
                _tile.TileTextFontSize = MetroTileTextSize.Small;
                _tile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Light;
                _tile.UseSelectable = true;
                _tile.Click += subProdClick;
                urunTABLE.Controls.Add(_tile);

            }
        }
        private void subProdClick(object sender, EventArgs e)
        {
            try
            {
                MetroTile subProd = (MetroTile)sender;
                int subProdID = Convert.ToInt32(subProd.Name.Trim());
                using (KEDIDBEntities kEDIDB = new KEDIDBEntities())
                {
                    var result = (from products in kEDIDB.Urunlers where products.UrunID == subProdID select products).FirstOrDefault();
                    var _result = (from products in kEDIDB.Urunlers where products.UrunID == result.UstUrunID select products.UrunAdi).FirstOrDefault();
                    decimal _urunMiktari=0;
                    if (!string.IsNullOrEmpty(urunMiktari.Text))
                    {
                        _urunMiktari = Convert.ToDecimal(urunMiktari.Text.Trim());
                    }
                    else
                    {
                        _urunMiktari = 1;
                    }
                    double toplamFiyat = (double)(_urunMiktari * (decimal)result.Fiyat);
                    if (oldProds != 0)
                    {
                        if (oldProds != urunList.Items.Count)
                        {
                            for (int j = oldProds; j < urunList.Items.Count; j++)
                            {
                                if (urunList.Items[j].Text.Equals(_result))
                                {                                       
                                    urunList.Items.Insert(j + 1, ("***"+result.UrunAdi));
                                    urunList.Items[j+1].SubItems.Add( _urunMiktari.ToString());
                                    urunList.Items[j+1].SubItems.Add(toplamFiyat.ToString());
                                    urunList.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                                    break;
                                }
                                else if (j == (urunList.Items.Count - 1))
                                {
                                    urunList.Items.Add(("***" + result.UrunAdi));
                                    urunList.Items[urunList.Items.Count - 1].SubItems.Add(_urunMiktari.ToString());
                                    urunList.Items[urunList.Items.Count - 1].SubItems.Add(toplamFiyat.ToString());
                                    urunList.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                                    break;
                                }
                            }
                        }
                        else
                        {
                            urunList.Items.Add(("***" + result.UrunAdi));
                            urunList.Items[urunList.Items.Count - 1].SubItems.Add(_urunMiktari.ToString());
                            urunList.Items[urunList.Items.Count - 1].SubItems.Add(toplamFiyat.ToString());
                            urunList.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                        }
                    }
                    else
                    {
                        urunList.Items.Add(("***" + result.UrunAdi));
                        urunList.Items[urunList.Items.Count - 1].SubItems.Add(_urunMiktari.ToString());
                        urunList.Items[urunList.Items.Count - 1].SubItems.Add(toplamFiyat.ToString());
                        urunList.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                    }
                    double _tFiyat = Convert.ToDouble(countPrice.Text.Trim()) + (toplamFiyat);
                    countPrice.Text = _tFiyat.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }   
        }
        private void _urun_Click(object sender, EventArgs e)
        {            
            MetroTile product = (MetroTile)sender;
            addProdToOrder(product.Name);                
        }
        private void addProdToOrder(string productID)
        {
            try
            {
                int _productID = Convert.ToInt32(productID);
                using (KEDIDBEntities kEDIDB=new KEDIDBEntities())
                {
                    var result = (from urun in kEDIDB.Urunlers
                                  where urun.UrunID == _productID select urun).FirstOrDefault();
                    if (result!=null)
                    {
                        double _urunMiktari=0;
                        if (!string.IsNullOrEmpty(urunMiktari.Text))
                        {
                            _urunMiktari = Convert.ToDouble(urunMiktari.Text.Trim());                            
                        }
                        else
                        {
                            _urunMiktari = 1;
                        }
                        double toplamFiyat = (_urunMiktari * (double)result.Fiyat);
                        if (oldProds != 0)
                        {
                            if (oldProds != urunList.Items.Count)
                            {
                                for (int j = oldProds; j < urunList.Items.Count; j++)
                                {
                                    if (urunList.Items[j].Text.Equals(result.UrunAdi))
                                    {                                        
                                        urunList.Items[j].SubItems[1].Text = (Convert.ToDouble(urunList.Items[j].SubItems[1].Text.Trim()) + _urunMiktari).ToString();
                                        urunList.Items[j].SubItems[2].Text = (Convert.ToDouble(urunList.Items[j].SubItems[2].Text.Trim()) + toplamFiyat).ToString();
                                        break;
                                    }
                                    else if (j == (urunList.Items.Count - 1))
                                    {                                        
                                        urunList.Items.Add(result.UrunAdi);
                                        urunList.Items[urunList.Items.Count - 1].SubItems.Add(_urunMiktari.ToString());
                                        urunList.Items[urunList.Items.Count - 1].SubItems.Add(toplamFiyat.ToString());
                                        urunList.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                                        break;
                                    }
                                }
                            }
                            else
                            {                                
                                urunList.Items.Add(result.UrunAdi);
                                urunList.Items[urunList.Items.Count - 1].SubItems.Add(_urunMiktari.ToString());
                                urunList.Items[urunList.Items.Count - 1].SubItems.Add(toplamFiyat.ToString());
                                urunList.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                            }
                        }
                        else if (urunList.Items.Count == 0)
                        {                            
                            urunList.Items.Add(result.UrunAdi);
                            urunList.Items[urunList.Items.Count - 1].SubItems.Add(_urunMiktari.ToString());
                            urunList.Items[urunList.Items.Count - 1].SubItems.Add(toplamFiyat.ToString());
                            urunList.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                        }
                        else
                        {
                            for (int j = 0; j < urunList.Items.Count; j++)
                            {
                                if (urunList.Items[j].Text.Equals(result.UrunAdi))
                                {                            
                                    urunList.Items[j].SubItems[1].Text = (Convert.ToDouble(urunList.Items[j].SubItems[1].Text.Trim()) + _urunMiktari).ToString();
                                    urunList.Items[j].SubItems[2].Text = (Convert.ToDouble(urunList.Items[j].SubItems[2].Text.Trim()) + toplamFiyat).ToString();
                                    break;
                                }
                                else if (j == (urunList.Items.Count - 1))
                                {                            
                                    urunList.Items.Add(result.UrunAdi);
                                    urunList.Items[urunList.Items.Count - 1].SubItems.Add(_urunMiktari.ToString());
                                    urunList.Items[urunList.Items.Count - 1].SubItems.Add(toplamFiyat.ToString());
                                    urunList.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                                    break;
                                }
                            }
                        }
                        double _tFiyat = Convert.ToDouble(countPrice.Text.Trim()) + (toplamFiyat);
                        countPrice.Text = _tFiyat.ToString();
                    }
                    loadSubProducts(result.UrunID);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void loadSubProducts(int ProdID)
        {
            try
            {
                using (KEDIDBEntities kEDIDB=new KEDIDBEntities())
                {
                    var result = (from altozellik in kEDIDB.Urunlers
                                  where altozellik.UstUrunID == ProdID
                                  where altozellik.AltOzellik == true
                                  select altozellik).DefaultIfEmpty().ToList();
                    if (result.Count>0)
                    {
                        urunTABLE.Controls.Clear();

                        MetroTile _tile = new MetroTile();
                        _tile.Dock = System.Windows.Forms.DockStyle.Top;
                        _tile.Location = new System.Drawing.Point(100, 10);
                        _tile.Name = "Proceed";
                        _tile.Size = new System.Drawing.Size(100, 60);
                        _tile.Style = MetroFramework.MetroColorStyle.Green;
                        _tile.Text = "Devam Et";
                        _tile.TextAlign = ContentAlignment.MiddleLeft;
                        _tile.TileTextFontSize = MetroTileTextSize.Tall;
                        _tile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
                        _tile.UseSelectable = true;
                        _tile.Click += proceedClicked;
                        urunTABLE.Controls.Add(_tile);

                        foreach (var item in result)
                        {
                            tileCreator(item.UrunAdi + "\n" + ((double)item.Fiyat).ToString(), item.UrunID.ToString(), 5, 0);
                        }                        
                    }
                }
            }
            catch (NullReferenceException ex)
            {
                getProd(selectedMenuID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void proceedClicked(object sender, EventArgs e)
        {
            getProd(selectedMenuID);
        }

        private void _menu_Click(object sender, EventArgs e)
        {            
            MetroTile menu = (MetroTile)sender;
            selectedMenuID = Convert.ToInt32(menu.Name.Trim());
            getProd(selectedMenuID);
        }
        private void getProd(int menuID)
        {
            urunTABLE.Controls.Clear();
            try
            {
                using (KEDIDBEntities kEDIDB = new KEDIDBEntities())
                {
                    var results = (from urun in kEDIDB.Urunlers
                                   where urun.UstUrunID == menuID
                                   select new
                                   {
                                       urun.UrunAdi,
                                       urun.Fiyat,
                                       urun.UrunID
                                   }).DefaultIfEmpty();
                    if (results!=null)
                    {
                        foreach (var item in results)
                        {
                            tileCreator(item.UrunAdi + "\n" + ((double)item.Fiyat).ToString(), item.UrunID.ToString(), 4,0);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
        private void _masa_Click(object sender, EventArgs e)
        {

            MetroTile table = (MetroTile)sender;
            selectedTableID = Convert.ToInt32(table.Name.Trim());
            if (tablePanelType == 1)
            {
                try
                {
                    if (printClicked)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        printTable();                        
                    }
                    else if (moveClicked)
                    {
                        sourceSelected = true;
                        moveClicked = false;
                        Cursor.Current = Cursors.WaitCursor;
                        sourceTable = selectedTableID;
                        moveTable(true);                        
                    }
                    else if (combineClicked)
                    {
                        sourceSelected = true;
                        combineClicked = false;
                        Cursor.Current = Cursors.WaitCursor;
                        sourceTable = selectedTableID;
                        moveTable(false);                        
                    }
                    else
                    {
                        selectedTableName = table.Text;
                        activateMasa(selectedTableID);
                        payment.Enabled = true;
                        if (isMasaFull(selectedTableID))
                        {
                            productLoader();
                        }
                        else
                        {
                            PersonCount.TableID = selectedTableID;
                            PersonCount count = new PersonCount();
                            DialogResult res = count.ShowDialog();
                            if (res != DialogResult.Cancel)
                            {
                                productLoader();
                            }
                        }
                    }
                    tablePanelType = 0;
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }
            }
            else if (sourceSelected)
            {
                sourceSelected = false;                
                completeMoving();
                masaLoader(selectedSalonID.ToString());
            }
        }
        private bool isMasaFull(int masaID)
        {
            try
            {
                using (KEDIDBEntities kEDIDB=new KEDIDBEntities())
                {
                    var result = (from adisyon in kEDIDB.Siparislers
                                  where adisyon.MasaID == masaID select adisyon).DefaultIfEmpty();
                    if (result != null)
                    {
                        foreach (var item in result)
                        {
                            if (item != null)
                            {
                                var _result = (from odeme in kEDIDB.Odemes
                                               where odeme.SiparisID == item.SiparisID
                                               select odeme).FirstOrDefault();
                                if (_result == null)
                                {
                                    return true;
                                }
                            }
                        }
                      
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return false;

        }
        private void activateMasa(int masaID)
        {
            try
            {
                using (KEDIDBEntities kEDIDB = new KEDIDBEntities())
                {
                    var result = (from masa in kEDIDB.Masalars where masa.MasaID == masaID select masa).FirstOrDefault();
                    if (result!=null)
                    {
                        result.Aktif = true;
                    }
                    kEDIDB.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
        private MetroPanel breaker(string panelName)
        {
            MetroPanel breaker = new MetroPanel();
            breaker.Dock = System.Windows.Forms.DockStyle.Top;
            breaker.HorizontalScrollbarBarColor = true;
            breaker.HorizontalScrollbarHighlightOnWheel = false;
            breaker.HorizontalScrollbarSize = 10;
            breaker.Location = new System.Drawing.Point(100, 70);
            breaker.Name = panelName + "p";
            breaker.Size = new System.Drawing.Size(900, 3);
            breaker.TabIndex = 3;
            breaker.VerticalScrollbarBarColor = true;
            breaker.VerticalScrollbarHighlightOnWheel = false;
            breaker.VerticalScrollbarSize = 10;
            return breaker;
        }
        private void _tile_Click(object sender, EventArgs e)
        {
            MetroTile clicker = (MetroTile)sender;
            if (salonPanelType==1)
            {
                urunTABLE.Controls.Clear();
                masalar.Clear();
                selectedSalonID =Convert.ToInt32(clicker.Name.Trim());
                masaLoader(clicker.Name);
                //clicker.Style = MetroColorStyle.Orange;
            }            
        }
        private void salonLoader()
        {
            try
            {
                sidePanel.Controls.Clear();
                using (KEDIDBEntities kediDB = new KEDIDBEntities())
                {
                    var result = (from salon in kediDB.Salonlars select salon).DefaultIfEmpty().ToList();
                    if (result.Count>0)
                    {
                        foreach (var item in result)
                        {
                            if (item != null)
                            {
                                tileCreator(item.SalonAdi, item.SalonID.ToString(), 1,0);
                            }
                        }
                        _salon = result;
                        salonPanelType = 1;
                    }
                }
            }            
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        private void masaLoader(string salonID)
        {
            processPanel.Visible = false;
            MenuPanel.Visible = false;
            sidePanel.Visible = true;
            save.Enabled = false;
            cancel.Enabled = false;
            printClicked = false;
            confirm.Visible = false;
            payment.Enabled = false;            
            //combineClicked = false;
            move.Enabled = true;
            combine.Enabled = true;
            sourceTable = 0;
            destinationSelected = false;
            urunTABLE.ColumnCount = 10;
            urunTABLE.Controls.Clear();
            try
            {
                int _salonID = Convert.ToInt32(salonID.Trim());
                using (KEDIDBEntities kediDB = new KEDIDBEntities())
                {
                    var result = (from masa in kediDB.Masalars
                            where masa.SalonID == _salonID
                            select masa).DefaultIfEmpty();                    
                    if (result!=null)
                    {
                        DateTime controlTime = DateTime.Parse("1990-01-01 01:01:01.001");
                        DateTime siparisTime = DateTime.Parse("1990-01-01 01:01:01.001");
                        urunTABLE.ColumnCount = 10;
                        urunTABLE.RowCount = 9;                        
                        foreach (var _item in result.ToList())
                        {                            
                            var _result = (from siparis in kediDB.Siparislers where siparis.MasaID == _item.MasaID select siparis).DefaultIfEmpty();
                            if (_result!=null)
                            {
                                foreach (var item in _result)
                                {
                                    if (item!=null)
                                    {
                                        var __result = (from odeme in kediDB.Odemes
                                                        where odeme.SiparisID == item.SiparisID
                                                        select odeme).FirstOrDefault();
                                        if (__result == null)
                                        {
                                            siparisTime = item.Tarih;
                                            break;
                                        }
                                    }                                    
                                }
                            }                            
                            if (!siparisTime.Equals(controlTime))
                            {
                                TimeSpan minutes =DateTime.Now-siparisTime;
                                tileCreator(_item.MasaAdi+"\n"+((int)minutes.TotalMinutes).ToString()+"dk", _item.MasaID.ToString(), 2,1);
                                siparisTime = controlTime;
                            }
                            else
                                tileCreator(_item.MasaAdi, _item.MasaID.ToString(), 2,0);
                        }
                        tablePanelType = 1;
                    }
                    else MessageBox.Show("Salon Boş");
                }
            }catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        private void productLoader()
        {
            processPanel.Visible = true;
            MenuPanel.Visible = true;
            sidePanel.Visible = false;
            save.Enabled = true;
            cancel.Enabled = true;
            _countPrice = 0.0;
            MenuTable.Controls.Clear();
            urunTABLE.Controls.Clear();
            NumbersPanel.Controls.Clear();
            AdisyonName.Text = String.Empty;
            _productToShow.Clear();
            oldProds = 0;

            numGenerator();
            getMenu();
            getOrder();
            urunList.Items.Clear();            
            MasaShow.Text = selectedTableName;
            PersonCountShow.Text = persCount.ToString();

            for (int i = 0; i < _productToShow.Count; i++)
            {
                urunList.Items.Add(_productToShow[i][0]);
                urunList.Items[i].SubItems.Add(_productToShow[i][1]);
                urunList.Items[i].SubItems.Add(_productToShow[i][2]);
                oldProds++;
            }
            urunList.View = View.Details;
            urunList.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            countPrice.Text = _countPrice.ToString();
        }
        // NUMbers Panel Generator//
        private void numGenerator()
        {
            for (int i = 1; i < 10; i++)
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(Order));
                MetroTile _tile = new MetroTile();
                _tile.Dock = System.Windows.Forms.DockStyle.Left;
                _tile.Location = new System.Drawing.Point(100, 10);
                _tile.Name = i.ToString();
                _tile.Size = new System.Drawing.Size(100, 50);
                _tile.Style = MetroFramework.MetroColorStyle.Lime;
                _tile.Text = i.ToString();
                _tile.TextAlign = ContentAlignment.MiddleCenter;
                _tile.TileTextFontSize = MetroTileTextSize.Tall;
                _tile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
                _tile.UseSelectable = true;
                _tile.Click += _numClick;
                NumbersPanel.Controls.Add(_tile);
            }
            MetroTile _zerotile = new MetroTile();
            _zerotile.Dock = System.Windows.Forms.DockStyle.Left;
            _zerotile.Location = new System.Drawing.Point(100, 10);
            _zerotile.Name = "0";
            _zerotile.Size = new System.Drawing.Size(100, 50);
            _zerotile.Style = MetroFramework.MetroColorStyle.Lime;
            _zerotile.Text = "0";
            _zerotile.TextAlign = ContentAlignment.MiddleCenter;
            _zerotile.TileTextFontSize = MetroTileTextSize.Tall;
            _zerotile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            _zerotile.UseSelectable = true;
            _zerotile.Click += _numClick;
            NumbersPanel.Controls.Add(_zerotile);

            MetroTile _commatile = new MetroTile();
           _commatile.Dock = System.Windows.Forms.DockStyle.Left;
           _commatile.Location = new System.Drawing.Point(100, 10);
           _commatile.Name = ",";
           _commatile.Size = new System.Drawing.Size(100, 50);
           _commatile.Style = MetroFramework.MetroColorStyle.Lime;
           _commatile.Text = ",";
           _commatile.TextAlign = ContentAlignment.MiddleCenter;
           _commatile.TileTextFontSize = MetroTileTextSize.Tall;
           _commatile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
           _commatile.UseSelectable = true;
           _commatile.Click += _numClick;
            NumbersPanel.Controls.Add(_commatile);

            MetroTile _clear = new MetroTile();
            _clear.Dock = System.Windows.Forms.DockStyle.Left;
            _clear.Location = new System.Drawing.Point(100, 10);
            _clear.Name = "CLEAR";
            _clear.Size = new System.Drawing.Size(100, 50);
            _clear.Style = MetroFramework.MetroColorStyle.Red;
            _clear.Text = "SİL";
            _clear.TextAlign = ContentAlignment.MiddleCenter;
            _clear.TileTextFontSize = MetroTileTextSize.Tall;
            _clear.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            _clear.UseSelectable = true;
            _clear.Click += _ClearClick;
            NumbersPanel.Controls.Add(_clear);
        }
        private void getOrder()
        {
            try
            {
                using (KEDIDBEntities kEDIDB = new KEDIDBEntities())
                {
                    var result = (from siparis in kEDIDB.Siparislers
                                  where siparis.MasaID == selectedTableID select siparis).DefaultIfEmpty();
                    if (result!=null)
                    {
                        foreach (var item in result.ToList())
                        {
                            if (item != null)
                            {
                                var _result = (from odeme in kEDIDB.Odemes
                                               where odeme.SiparisID == item.SiparisID
                                               select odeme).FirstOrDefault();
                                if (_result == null)
                                {
                                    var __result = (from urun in kEDIDB.Urunlers
                                                    where urun.UrunID == item.UrunID
                                                    select new
                                                    {
                                                        urun.UrunAdi,
                                                        urun.Fiyat,
                                                        urun.AltOzellik
                                                    }).FirstOrDefault();
                                    if (__result != null)
                                    {
                                        _countPrice += ((double)__result.Fiyat) *(double) item.UrunSayi;
                                        List<string> prod = new List<string>();
                                        if (__result.AltOzellik == true)
                                        {
                                            prod.Add("***" + __result.UrunAdi);
                                        }
                                        else
                                            prod.Add(__result.UrunAdi);
                                        prod.Add(item.UrunSayi.ToString());
                                        prod.Add((((double)__result.Fiyat) * (double)item.UrunSayi).ToString());
                                        _productToShow.Add(prod);
                                    }
                                    AdisyonName.Text = item.SiparisAdi;
                                    stringParser(item.SiparisAdi);
                                }
                            }                            
                        }                        
                    }
                }
            }
            catch (Exception ex)
            { 
                MessageBox.Show(ex.ToString());
            }
        }
        private void stringParser(string text)
        {
            char[] arr = text.ToCharArray();
            Array.Reverse(arr);
            string PersonCount = new string(arr);            
            PersonCount=PersonCount.Substring(0, PersonCount.IndexOf('p'));
            char[] revArr = PersonCount.ToCharArray();
            Array.Reverse(revArr);
            string _persC = new string(revArr);
            persCount = Convert.ToInt32(_persC.Trim());
        }
        private void getMenu()
        {
            try
            {
                using (KEDIDBEntities kEDIDB=new KEDIDBEntities())
                {
                    var results = (from menu in kEDIDB.Urunlers
                                   where menu.UstUrunID == 0
                                   select new
                                   {
                                       menu.UrunAdi,
                                       menu.UrunID
                                   }).DefaultIfEmpty();
                    if (results!=null)
                    {
                        foreach (var item in results.ToList())
                        {
                            tileCreator(item.UrunAdi, item.UrunID.ToString(), 3,0);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
        private void _ClearClick(object sender, EventArgs e)
        {
            urunMiktari.Text=String.Empty;
        }

        private void _numClick(object sender, EventArgs e)
        {
            MetroTile num = (MetroTile)sender;
            urunMiktari.Text += num.Text;
        }

        private void metroLabel2_Click(object sender, EventArgs e)
        {

        }

        private void cancel_Click(object sender, EventArgs e)
        {
            masaLoader(selectedSalonID.ToString());
        }        

        private void urunList_ItemActivate(object sender, EventArgs e)
        {
            foreach (var item in urunList.SelectedIndices)
            {                 
               // int selectedIndex = urunList.Items.Count - ((int)item);              
                if ((int)item < oldProds)
                {
                    MessageBox.Show(this, "Adisyona Eklenmiş Ürünleri Silemezsiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    DialogResult deleteOrNot = MessageBox.Show(this, "Bu Ürünü Silmek İstediğinize Emin Misiniz?", "Ürün Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (deleteOrNot == DialogResult.Yes)
                    {
                        urunList.Items.RemoveAt((int)item);                     
                    }
                }                
                break;
            }
        }

        private void OrderPrinter_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }

        private void print_Click(object sender, EventArgs e)
        {
            getAllTables();
        }
        private void getAllTables()
        {
            try
            {
                if (tablePanelType==1)
                {
                    using (KEDIDBEntities kEDIDB = new KEDIDBEntities())
                    {
                        var result = (from masalar in kEDIDB.Masalars select masalar).DefaultIfEmpty();
                        if (result != null)
                        {
                            urunTABLE.Controls.Clear();
                            foreach (var item in result.ToList())
                            {
                                if (item != null)
                                {                                   
                                    if (isMasaFull(item.MasaID))
                                    {
                                        tileCreator(item.MasaAdi, item.MasaID.ToString(), 2, 1);
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    Cursor.Current = Cursors.WaitCursor;
                    printTable();                  
                }
                printClicked = true;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
        private void printTable()
        {
            try
            {
                
                using (KEDIDBEntities kEDIDB = new KEDIDBEntities())
                {
                    var result = (from siparis in kEDIDB.Siparislers
                                  where siparis.MasaID == selectedTableID select siparis).DefaultIfEmpty();
                    if (result != null)
                    {
                        foreach (var item in result.ToList())
                        {
                            var _result = (from odemeler in kEDIDB.Odemes
                                           where odemeler.SiparisID == item.SiparisID
                                           select odemeler).FirstOrDefault();                          
                            if (_result == null)
                            {
                                var __result = (from adisyon in kEDIDB.Siparislers
                                                where adisyon.SiparisAdi.Equals(item.SiparisAdi)
                                                select adisyon).DefaultIfEmpty();
                                if (__result != null)
                                {
                                    toPrint = __result.ToList();
                                    finalPrinter();
                                    printClicked = false;
                                    masaLoader(selectedSalonID.ToString());
                                    break;
                                }                              
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
        private void finalPrinter()
        {
            try
            {                
                PrintDocument print = new PrintDocument();             
                print.DocumentName = "Hesap Yazdirma";
                print.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(prepareFinalDocument);
                print.PrintController = new StandardPrintController();                

                PrinterSettings ps = new PrinterSettings();
                ps.PrinterName = "KediPosYazici1";                
                print.PrinterSettings = ps;
                
                print.Print();
                Cursor.Current = Cursors.Default;                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void prepareFinalDocument(object sender, PrintPageEventArgs e)
        {
            try
            {
                Graphics graphics = e.Graphics;
                Font font = new Font("Arial", 10);
                Font bold = new Font("Arial", 10, FontStyle.Bold);
                Font italic = new Font("Arial", 10, FontStyle.Italic);
                float fontHeight = font.Height;
                int startX = 10;
                int startY = 10;
                int offset = 30;
                graphics.DrawString("NANA Cafe & Restaurant", new Font("Arial", 15, FontStyle.Bold), new SolidBrush(Color.Green), startX, startY);

                string _top = "Masa:" + pickTable();
                graphics.DrawString(_top, font, new SolidBrush(Color.Black), startX, startY + offset);

                offset += 5 + (int)fontHeight;
                string __top = "Garson:" + pickUser(toPrint[0].KullaniciID);
                graphics.DrawString(__top, font, new SolidBrush(Color.Black), startX, startY + offset);

                offset += 5 + (int)fontHeight;
                string _____top = "Tarih:" + DateTime.Now;
                graphics.DrawString(_____top, font, new SolidBrush(Color.Black), startX, startY + offset);

                offset += 10 + (int)fontHeight;
                string top = "Ürün Adı".PadRight(20) + "Adet".PadRight(20) + "Fiyat";
                graphics.DrawString(top, bold, new SolidBrush(Color.Black), startX, startY + offset);

                offset += (int)fontHeight;
                graphics.DrawString("----------------------------------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
                offset += 5 + (int)fontHeight;

                StringFormat drawFormatCenter = new StringFormat();
                drawFormatCenter.Alignment = StringAlignment.Center;
                StringFormat drawFormatLeft = new StringFormat();
                drawFormatLeft.Alignment = StringAlignment.Near;
                StringFormat drawFormatRight = new StringFormat();
                drawFormatRight.Alignment = StringAlignment.Far;

                string _line;
                double fullPrice = 0;
                foreach (var item in toPrint)
                {                 
                    string[] vs = getProdNameAndPrice(item.UrunID);
                    if (vs[2].Equals(false.ToString()))
                    {
                        _line = vs[0];
                        graphics.DrawString(_line, font, new SolidBrush(Color.Black), new RectangleF(startX, startY + offset, 200, 0), drawFormatLeft);
                    }
                    else
                    {
                        _line = "***"+vs[0];
                        graphics.DrawString(_line, font, new SolidBrush(Color.Black), new RectangleF(startX, startY + offset, 200, 0), drawFormatLeft);
                    }
                    _line = item.UrunSayi.ToString();
                    graphics.DrawString(_line, font, new SolidBrush(Color.Black), new RectangleF(startX, startY + offset, 200, 0), drawFormatRight);
                    fullPrice += (Convert.ToDouble(vs[1]) * (double)item.UrunSayi);
                    _line = (Convert.ToDouble(vs[1]) * (double)item.UrunSayi).ToString();
                    graphics.DrawString(_line, bold, new SolidBrush(Color.Black), new RectangleF(startX, startY + offset, 270, 0), drawFormatRight);

                    offset += 5 + (int)fontHeight; 
                    
                }
                offset += 10 + (int)fontHeight;
                string price = "Yekün Toplam:".PadRight(40) + fullPrice.ToString()+"₺";
                graphics.DrawString(price, bold, new SolidBrush(Color.Black), startX, startY + offset);

                offset += 10 + (int)fontHeight;
                string thx = "Bizi Tercih Ettiğiniz İçin Teşekkür Ederiz! \nAfiyet Olsun!";
                graphics.DrawString(thx, italic, new SolidBrush(Color.Black), startX, startY + offset);

                offset += 22 + (int)fontHeight;
                string vers = "KediPos_v0.5.0.1";
                graphics.DrawString(vers, new Font("Arial",6,FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + offset);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private string[] getProdNameAndPrice(int prodID)
        {
            try
            {
                using (KEDIDBEntities kEDIDB = new KEDIDBEntities())
                {
                    var result = (from urun in kEDIDB.Urunlers
                                  where urun.UrunID == prodID

                                  select new
                                  {
                                      urun.UrunAdi,
                                      urun.AltOzellik,
                                      urun.Fiyat
                                  }).FirstOrDefault();
                    if (result != null)
                    {
                        string[] vs = new string[] { result.UrunAdi, ((double)result.Fiyat).ToString(), result.AltOzellik.ToString()};
                        return vs;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return null;
        }
        private string pickUser(int userID)
        {
            try
            {
                using (KEDIDBEntities kEDIDB = new KEDIDBEntities())
                {
                    var result = (from users in kEDIDB.Personels
                                  where users.KullaniciID == userID select users.KullaniciAdi).FirstOrDefault();
                    return result;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return string.Empty;
        }

        private void payment_Click(object sender, EventArgs e) 
            // 0 - ALL CASH 1 - ALL CREDIT 2 - SELECTED CASH 3 - SELECTED CREDIT 4 - CANCEL ALL 5 - CANCEL SELECTED
        {
            MenuTable.Controls.Clear();
            urunTABLE.Controls.Clear();
            //processPanel.Visible = false;

            MetroTile _cash = new MetroTile();
            _cash.Dock = System.Windows.Forms.DockStyle.Top;
            _cash.Location = new System.Drawing.Point(100, 10);
            _cash.Name = "0";
            _cash.Size = new System.Drawing.Size(100, 60);
            _cash.Style = MetroFramework.MetroColorStyle.Green;
            _cash.Text = "Nakit";
            _cash.TextAlign = ContentAlignment.MiddleLeft;
            _cash.TileTextFontSize = MetroTileTextSize.Tall;
            _cash.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            _cash.UseSelectable = true;
            _cash.Click += PaymentTypeSelected;
            MenuTable.Controls.Add(_cash);

            MetroTile _card = new MetroTile();
            _card.Dock = System.Windows.Forms.DockStyle.Top;
            _card.Location = new System.Drawing.Point(100, 10);
            _card.Name = "1";
            _card.Size = new System.Drawing.Size(100, 60);
            _card.Style = MetroFramework.MetroColorStyle.Blue;
            _card.Text = "Kart";
            _card.TextAlign = ContentAlignment.MiddleLeft;
            _card.TileTextFontSize = MetroTileTextSize.Tall;
            _card.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            _card.UseSelectable = true;
            _card.Click += PaymentTypeSelected;
            MenuTable.Controls.Add(_card);

            MetroTile _cashSelected = new MetroTile();
            _cashSelected.Dock = System.Windows.Forms.DockStyle.Top;
            _cashSelected.Location = new System.Drawing.Point(100, 10);
            _cashSelected.Name = "2";
            _cashSelected.Size = new System.Drawing.Size(100, 60);
            _cashSelected.Style = MetroFramework.MetroColorStyle.Green;
            _cashSelected.Text = "Nakit-Seçili Ürün";
            _cashSelected.TextAlign = ContentAlignment.MiddleLeft;
            _cashSelected.TileTextFontSize = MetroTileTextSize.Small;
            _cashSelected.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            _cashSelected.UseSelectable = true;
            _cashSelected.Click += PaymentTypeSelected;
            MenuTable.Controls.Add(_cashSelected);

            MetroTile _cardSelected = new MetroTile();
            _cardSelected.Dock = System.Windows.Forms.DockStyle.Top;
            _cardSelected.Location = new System.Drawing.Point(100, 10);
            _cardSelected.Name = "3";
            _cardSelected.Size = new System.Drawing.Size(100, 60);
            _cardSelected.Style = MetroFramework.MetroColorStyle.Blue;
            _cardSelected.Text = "Kart-Seçili Ürün";
            _cardSelected.TextAlign = ContentAlignment.MiddleLeft;
            _cardSelected.TileTextFontSize = MetroTileTextSize.Small;
            _cardSelected.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            _cardSelected.UseSelectable = true;
            _cardSelected.Click += PaymentTypeSelected;
            MenuTable.Controls.Add(_cardSelected);

            MetroTile _cancel = new MetroTile();
            _cancel.Dock = System.Windows.Forms.DockStyle.Top;
            _cancel.Location = new System.Drawing.Point(100, 10);
            _cancel.Name = "4";
            _cancel.Size = new System.Drawing.Size(100, 60);
            _cancel.Style = MetroFramework.MetroColorStyle.Red;
            _cancel.Text = "Hesap İptal";
            _cancel.TextAlign = ContentAlignment.MiddleLeft;
            _cancel.TileTextFontSize = MetroTileTextSize.Medium;
            _cancel.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            _cancel.UseSelectable = true;
            _cancel.Click += PaymentTypeSelected;
            MenuTable.Controls.Add(_cancel);

            MetroTile _cancelSelected = new MetroTile();
            _cancelSelected.Dock = System.Windows.Forms.DockStyle.Top;
            _cancelSelected.Location = new System.Drawing.Point(100, 10);
            _cancelSelected.Name = "5";
            _cancelSelected.Size = new System.Drawing.Size(100, 60);
            _cancelSelected.Style = MetroFramework.MetroColorStyle.Red;
            _cancelSelected.Text = "Ürün İptal";
            _cancelSelected.TextAlign = ContentAlignment.MiddleLeft;
            _cancelSelected.TileTextFontSize = MetroTileTextSize.Medium;
            _cancelSelected.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            _cancelSelected.UseSelectable = true;
            _cancelSelected.Click += PaymentTypeSelected;
            MenuTable.Controls.Add(_cancelSelected);
           
        }

        private void PaymentTypeSelected(object sender, EventArgs e)
        {
            MetroTile tile = (MetroTile)sender;
            int selectedMethod = Convert.ToInt32(tile.Name.Trim());
            switch (selectedMethod)
            {
                case 0: // All Cash
                    {
                        selectedPaymentMethod = 1;
                        payForAll();

                        confirm.Visible = false;
                        selectedPaymentMethod = 0;
                        cancel_Click(sender, e);
                        break;
                    }
                case 1: // All Card
                    {
                        selectedPaymentMethod = 2;
                        payForAll();

                        confirm.Visible = false;
                        selectedPaymentMethod = 0;
                        cancel_Click(sender, e);
                        break;
                    }
                case 2: // Selected Cash
                    {
                        selectedPaymentMethod = 1;
                        getOrderToPayment();                        
                        break;
                    }
                case 3: // Selected Card
                    {
                        selectedPaymentMethod = 2;
                        getOrderToPayment();
                        break;
                    }
                case 4: // Cancel All
                    {
                        selectedPaymentMethod = 3;
                        payForAll();                        
                        break;
                    }
                case 5: // Cancel Selected
                    {
                        selectedPaymentMethod = 3;
                        getOrderToPayment();                        
                        break;
                    }
                default:
                    break;
            }            
            odenecek.Text = "0";
            odenecekPanel.Visible = false;
            
            // selectedPaymentMethod = 0;
        }
        private void payForAll()
        {
            try
            {
                using (KEDIDBEntities kEDIDB = new KEDIDBEntities())
                {
                    var result = (from adisyon in kEDIDB.Siparislers
                                  where adisyon.SiparisAdi.Equals(AdisyonName.Text) select adisyon).DefaultIfEmpty();
                    if (result!=null)
                    {
                        foreach (var item in result.ToList())
                        {
                            var Result = (from odeme in kEDIDB.Odemes
                                          where odeme.SiparisID == item.SiparisID select odeme).FirstOrDefault();
                            if (Result==null)
                            {                                
                                Odeme yeniOdeme = new Odeme() {
                                    SiparisID=item.SiparisID,
                                    OdemeYontemi=selectedPaymentMethod,
                                    Tarih = DateTime.Now
                                };
                                kEDIDB.Odemes.Add(yeniOdeme);
                            }
                        }
                        kEDIDB.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void getOrderToPayment()
        {
            urunler.Clear();
            urunTABLE.Controls.Clear();
            try
            {              
                using (KEDIDBEntities kEDIDB = new KEDIDBEntities())
                {
                    var result = (from orders in kEDIDB.Siparislers
                                  where orders.SiparisAdi.Equals(AdisyonName.Text)
                                  select orders).DefaultIfEmpty();
                    List<Siparisler> siparislers = result.ToList();
                    if (result!=null)
                    {
                        
                        foreach (var item in siparislers)
                        {
                            var _result = (from odeme in kEDIDB.Odemes
                                           where odeme.SiparisID == item.SiparisID
                                           select odeme).FirstOrDefault();
                            if (_result==null)
                            {
                                var __result = (from urun in kEDIDB.Urunlers
                                                where urun.UrunID == item.UrunID
                                                select urun).FirstOrDefault();
                                if (__result!=null)
                                {
                                    urunler.Add(__result);
                                }
                            }
                        }
                        foreach (var item in urunler)
                        {
                            if (((bool)item.AltOzellik) == false)
                            {
                                foreach (var _item in urunler)
                                {
                                    if (_item.UstUrunID == item.UrunID)
                                    {
                                        item.Fiyat += _item.Fiyat;
                                        break;
                                    }
                                }
                            }
                        }
                        foreach (var item in siparislers)
                        {                            
                            foreach (var _item in urunler)
                            {
                                if (item.UrunID==_item.UrunID)//&&_item.AltOzellik!=true) /// Burasi Duzenlenebilir Ama Sonra!!!!!!!!!!
                                {
                                    for (int i = 0; i < item.UrunSayi; i++)
                                    {
                                        MetroTile _urun = new MetroTile();
                                        _urun.Dock = System.Windows.Forms.DockStyle.Top;
                                        _urun.Location = new System.Drawing.Point(100, 10);
                                        _urun.Name = item.SiparisID.ToString();
                                        _urun.Size = new System.Drawing.Size(900, 60);
                                        _urun.Style = MetroFramework.MetroColorStyle.Purple;
                                        _urun.Text = _item.UrunAdi.PadRight(100) +_item.Fiyat.ToString();
                                        _urun.TextAlign = ContentAlignment.MiddleLeft;
                                        _urun.TileTextFontSize = MetroTileTextSize.Tall;
                                        _urun.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
                                        _urun.UseSelectable = true;
                                        _urun.Click += prodSelectedToPay;
                                        urunTABLE.ColumnCount = 1;
                                        urunTABLE.Controls.Add(_urun);    
                                        
                                    }
                                    break;
                                }                                
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }       
        private void prodSelectedToPay(object sender, EventArgs e)
        {
            MetroTile selected = (MetroTile)sender;
            if (selected.Style == MetroColorStyle.Pink)
            {
                selected.Style = MetroColorStyle.Purple;
                selectedProdIDs.Remove(Convert.ToInt32(selected.Name));
                foreach (var item in urunler)
                {
                    if (item.UrunID == Convert.ToInt32(selected.Name))
                    {
                        double onc = Convert.ToDouble(odenecek.Text);
                        onc -= (double)item.Fiyat;
                        odenecek.Text = onc.ToString();
                        break;
                    }
                }
            }
            else
            {
                selected.Style = MetroColorStyle.Pink;
                selectedProdIDs.Add(Convert.ToInt32(selected.Name));
                odenecekPanel.Visible = true;
                foreach (var item in urunler)
                {
                    if (item.UrunID== Convert.ToInt32(selected.Name))
                    {
                        double onc = Convert.ToDouble(odenecek.Text);
                        onc += (double)item.Fiyat;
                        odenecek.Text = onc.ToString();
                        break;
                    }
                }
                confirm.Visible = true;
            }            
        }
        private void confirm_Click(object sender, EventArgs e)
        {
            if (selectedProdIDs.Count>0)
            {
                try
                {
                    using (KEDIDBEntities kEDIDB = new KEDIDBEntities())
                    {
                        var result = (from adisyon in kEDIDB.Siparislers
                                      where adisyon.SiparisAdi.Equals(AdisyonName.Text)
                                      select adisyon).DefaultIfEmpty();
                        if (result!=null)
                        {
                            foreach (var item in result)
                            {
                                var res = (from odeme in kEDIDB.Odemes
                                           where odeme.SiparisID == item.SiparisID
                                           select odeme).FirstOrDefault();
                                if (res==null)
                                {                                    
                                    if (getSubProdToPay(item.UrunID)!=null)
                                    {
                                        List<int> subProds = new List<int>();
                                        subProds = getSubProdToPay(item.UrunID);
                                        foreach  (int __item in subProds)
                                        {
                                            Odeme yeniOdeme = new Odeme()
                                            {
                                                OdemeYontemi=selectedPaymentMethod,
                                                SiparisID=__item,
                                                Tarih=DateTime.Now
                                            };
                                        }
                                    }
                                    foreach (int _item in selectedProdIDs)
                                    {
                                        if (_item==item.SiparisID)
                                        {
                                            Odeme yeniOdeme = new Odeme()
                                            {
                                                OdemeYontemi=selectedPaymentMethod,
                                                SiparisID=item.SiparisID,
                                                Tarih=DateTime.Now,                                                
                                            };
                                            kEDIDB.Odemes.Add(yeniOdeme);
                                            break;                                          
                                        }
                                    }
                                }
                            }                            
                        }
                        kEDIDB.SaveChanges();
                        payment_Click(sender,e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        private List<int> getSubProdToPay(int prodID)
        {
            try
            {
                using (KEDIDBEntities kEDIDB = new KEDIDBEntities())
                {
                    var result = (from urun in kEDIDB.Urunlers where urun.UstUrunID == prodID select urun).DefaultIfEmpty();
                    if (result!=null)
                    {
                        List<int> siparisID = new List<int>();
                        foreach (var item in result.ToList())
                        {
                            if (item != null)
                            {
                                var res = (from siparis in kEDIDB.Siparislers where siparis.UrunID == item.UrunID select siparis).FirstOrDefault();
                                if (res != null)
                                {
                                    siparisID.Add(res.SiparisID);
                                }
                            }
                        }
                        return siparisID;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return null;
        }

        private void fullback_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void move_Click(object sender, EventArgs e)
        {
            try
            {
                if (tablePanelType == 1)
                {
                    using (KEDIDBEntities kEDIDB = new KEDIDBEntities())
                    {
                        var result = (from masalar in kEDIDB.Masalars select masalar).DefaultIfEmpty();
                        if (result != null)
                        {
                            urunTABLE.Controls.Clear();
                            foreach (var item in result.ToList())
                            {
                                if (item != null)
                                {
                                    if (isMasaFull(item.MasaID))
                                    {
                                        tileCreator(item.MasaAdi, item.MasaID.ToString(), 2, 1);
                                    }
                                }
                            }
                        }
                    }
                }               
                moveClicked = true;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
        private void moveTable(bool status) // 0-combine 1-move 
        {
            try
            {
                using (KEDIDBEntities kEDIDB = new KEDIDBEntities())
                {
                    var result = (from masalar in kEDIDB.Masalars select masalar).DefaultIfEmpty();
                    if (result != null)
                    {
                        urunTABLE.Controls.Clear();
                        foreach (var item in result.ToList())
                        {
                            if (item != null)
                            {
                                if (status)
                                {
                                    if (!isMasaFull(item.MasaID))
                                    {
                                        tileCreator(item.MasaAdi, item.MasaID.ToString(), 2, 0);
                                    }
                                }
                                else if (item.MasaID!=sourceTable)
                                {
                                    if(isMasaFull(item.MasaID))
                                        tileCreator(item.MasaAdi, item.MasaID.ToString(), 2, 0);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void completeMoving()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                using (KEDIDBEntities kEDIDB = new KEDIDBEntities())
                {
                    var result = (from siparisler in kEDIDB.Siparislers
                                  where siparisler.MasaID == sourceTable
                                  select siparisler).DefaultIfEmpty();
                    if (result!=null)
                    {
                        foreach (var item in result.ToList())
                        {
                            if (item!=null)
                            {
                                //Odeme odeme = item.Odemes.FirstOrDefault();
                                var _result = (from odeme in kEDIDB.Odemes
                                               where odeme.SiparisID == item.SiparisID
                                               select odeme).FirstOrDefault();
                                if (_result==null)
                                {
                                    // changeTableComplete(item.SiparisID);
                                    var res = (from sip in kEDIDB.Siparislers
                                               where sip.SiparisID == item.SiparisID
                                               select sip).FirstOrDefault();
                                    if (res != null)
                                    {
                                        res.MasaID = selectedTableID;
                                    }
                                }
                            }                            
                        }
                        kEDIDB.SaveChanges();
                    }                    
                    Cursor.Current = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void combine_Click(object sender, EventArgs e)
        {
            move_Click(sender, e);
            moveClicked = false;
            combineClicked = true;
        }
    }
}
