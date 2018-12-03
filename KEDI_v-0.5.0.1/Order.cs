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

namespace KEDI_v_0._5._0._1
{
    public partial class Order : MetroForm
    {
        public static int PersonalID;
        public static int persCount;
        private double _countPrice=0.0;
        List<Salonlar> _salon = new List<Salonlar>();
        List<List<string>> _productToShow = new List<List<string>>();        
        private List<MetroTile> masalar = new List<MetroTile>();
        private int oldProds=0;
        int salonPanelType = 0; // 1 - Salon
        int tablePanelType = 0; // 1 - Masa
        int selectedSalonID = 0;
        int selectedTableID = 0;
        int selectedMenuID = 0;
        string selectedTableName = String.Empty;
        public Order()
        {
            InitializeComponent();
            salonLoader();                        
        }

        private void save_Click(object sender, EventArgs e)
        {
            masaLoader(selectedSalonID.ToString());
        }
        private void tileCreator(string tileText, string tileID, int Type,int isMasaFull)//Type -- 1=Salon 2=Masa 3=Menu 4=Urun 5=SubProd
        {
    
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
                tableLayoutPanel1.Controls.Add(_tile);
                masalar.Add(_tile);
            }
            else if (Type==3)// Menu
            {
                tableLayoutPanel1.Controls.Clear();
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
                tableLayoutPanel1.Controls.Add(_tile);
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
                tableLayoutPanel1.Controls.Add(_tile);

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
                    int _urunMiktari;
                    if (!string.IsNullOrEmpty(urunMiktari.Text))
                    {
                        _urunMiktari = Convert.ToInt32(urunMiktari.Text.Trim());
                    }
                    else
                    {
                        _urunMiktari = 1;
                    }
                    double toplamFiyat = _urunMiktari * (double)result.Fiyat;
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
                        int _urunMiktari;
                        if (!string.IsNullOrEmpty(urunMiktari.Text))
                        {
                            _urunMiktari = Convert.ToInt32(urunMiktari.Text.Trim());                            
                        }
                        else
                        {
                            _urunMiktari = 1;
                        }
                        double toplamFiyat = _urunMiktari * (double)result.Fiyat;
                        if (oldProds != 0)
                        {
                            if (oldProds != urunList.Items.Count)
                            {
                                for (int j = oldProds; j < urunList.Items.Count; j++)
                                {
                                    if (urunList.Items[j].Text.Equals(result.UrunAdi))
                                    {                                        
                                        urunList.Items[j].SubItems[1].Text = (Convert.ToInt32(urunList.Items[j].SubItems[1].Text.Trim()) + _urunMiktari).ToString();
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
                                    urunList.Items[j].SubItems[1].Text = (Convert.ToInt32(urunList.Items[j].SubItems[1].Text.Trim()) + _urunMiktari).ToString();
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
                        tableLayoutPanel1.Controls.Clear();

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
                        tableLayoutPanel1.Controls.Add(_tile);

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
            tableLayoutPanel1.Controls.Clear();
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
            if (tablePanelType == 1)
            {
                try
                {
                    MetroTile table = (MetroTile)sender;
                    selectedTableID = Convert.ToInt32(table.Name.Trim());
                    selectedTableName = table.Text;
                    activateMasa(selectedTableID);
                    bool full = isMasaFull(selectedTableID);
                    if (full)
                    {
                        productLoader();
                    }
                    else
                    {
                        PersonCount.TableID = selectedTableID;
                        PersonCount count = new PersonCount();
                        DialogResult res= count.ShowDialog();                                                
                        if (res!=DialogResult.Cancel)
                        {
                            productLoader();
                        }
                    }                    
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }
                
            }
        }
        private bool isMasaFull(int masaID)
        {
            try
            {
                using (KEDIDBEntities kEDIDB=new KEDIDBEntities())
                {
                    var result = (from adisyon in kEDIDB.Siparislers
                                  where adisyon.MasaID == masaID select adisyon).FirstOrDefault();
                    if (result != null)
                    {
                        var _result = (from odeme in kEDIDB.Odemes
                                       where odeme.SiparisID == result.SiparisID select odeme).FirstOrDefault();
                        if (_result==null)
                        {
                            return true;
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
                tableLayoutPanel1.Controls.Clear();
                masalar.Clear();
                selectedSalonID =Convert.ToInt32(clicker.Name.Trim());
                masaLoader(clicker.Name);
            }            
        }
        private void salonLoader()
        {
            try
            {
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
            tableLayoutPanel1.Controls.Clear();
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
                        tableLayoutPanel1.ColumnCount = 10;
                        tableLayoutPanel1.RowCount = 9;                        
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
            tableLayoutPanel1.Controls.Clear();
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
                        foreach (var item in result)
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
                                                        urun.Fiyat
                                                    }).FirstOrDefault();
                                    if (__result != null)
                                    {
                                        _countPrice += ((double)__result.Fiyat) * item.UrunSayi;
                                        List<string> prod = new List<string>();
                                        prod.Add(__result.UrunAdi);
                                        prod.Add(item.UrunSayi.ToString());
                                        prod.Add((((double)__result.Fiyat) * item.UrunSayi).ToString());
                                        _productToShow.Add(prod);                                       
                                    }
                                }
                                AdisyonName.Text = result.ToList()[0].SiparisAdi;
                                stringParser(result.ToList()[0].SiparisAdi);
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
            persCount = Convert.ToInt32(PersonCount.Trim());
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
    }
}
