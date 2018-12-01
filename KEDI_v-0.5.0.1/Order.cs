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
        List<Salonlar> _salon = new List<Salonlar>();
        private List<MetroTile> masalar = new List<MetroTile>();
        int salonPanelType = 0; // 1 - Salon
        int tablePanelType = 0; // 1 - Masa
        int selectedSalonID = 0;
        int selectedTableID = 0;
        public Order()
        {
            InitializeComponent();
            salonLoader();
        }

        private void save_Click(object sender, EventArgs e)
        {
            masaLoader(selectedSalonID.ToString());
        }
        private void tileCreator(string tileText, string tileID, int Type)//Type -- 1=Salon 2=Masa 3=Menu 4=Urun
        {
    
            //     _tile.UseTileImage = true;
 
            if (Type == 1)
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
                //_tile.TileImage = Image.FromFile(@"D:\projects\KEDI\Icons\Icons-20180611T000513Z-001\Icons\edit11.png");               
                //       _tile.TileImageAlign = System.Drawing.ContentAlignment.MiddleRight;
                _tile.TileTextFontSize = MetroTileTextSize.Tall;
                _tile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
                _tile.UseSelectable = true;
                _tile.Click += _tile_Click;
                sidePanel.Controls.Add(_tile);
                sidePanel.Controls.Add(breaker(tileID + 1));

            }
            else if(Type==2)
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(Order));
                MetroTile _tile = new MetroTile();
                _tile.Dock = System.Windows.Forms.DockStyle.Left;
                _tile.Location = new System.Drawing.Point(100, 10);
                _tile.Name = tileID;
                _tile.Size = new System.Drawing.Size(100, 60);
                _tile.Style = MetroFramework.MetroColorStyle.Brown;
                _tile.Text = tileText;
                _tile.TextAlign = ContentAlignment.MiddleLeft;
                //_tile.TileImage = Image.FromFile(@"D:\projects\KEDI\Icons\Icons-20180611T000513Z-001\Icons\edit11.png");               
                //       _tile.TileImageAlign = System.Drawing.ContentAlignment.MiddleRight;
                _tile.TileTextFontSize = MetroTileTextSize.Tall;
                _tile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
                _tile.UseSelectable = true;
                //     _tile.UseTileImage = true;
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
                //_tile.TileImage = Image.FromFile(@"D:\projects\KEDI\Icons\Icons-20180611T000513Z-001\Icons\edit11.png");               
                //       _tile.TileImageAlign = System.Drawing.ContentAlignment.MiddleRight;
                _tile.TileTextFontSize = MetroTileTextSize.Small;
                _tile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
                _tile.UseSelectable = true;
                //     _tile.UseTileImage = true;
                _tile.Click += _menu_Click;
                MenuTable.Controls.Add(_tile);
            }
            else if (Type==4)
            {
                MetroTile _tile = new MetroTile();
                _tile.Dock = System.Windows.Forms.DockStyle.Left;
                _tile.Location = new System.Drawing.Point(100, 10);
                _tile.Name = tileID;
                _tile.Size = new System.Drawing.Size(100, 60);
                _tile.Style = MetroFramework.MetroColorStyle.Blue;
                _tile.Text = tileText;
                _tile.TextAlign = ContentAlignment.MiddleLeft;
                //_tile.TileImage = Image.FromFile(@"D:\projects\KEDI\Icons\Icons-20180611T000513Z-001\Icons\edit11.png");               
                //       _tile.TileImageAlign = System.Drawing.ContentAlignment.MiddleRight;
                _tile.TileTextFontSize = MetroTileTextSize.Small;
                _tile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Light;
                _tile.UseSelectable = true;
                //     _tile.UseTileImage = true;
                _tile.Click += _urun_Click;
                tableLayoutPanel1.Controls.Add(_tile);
            }
        }

        private void _urun_Click(object sender, EventArgs e)
        {

        }

        private void _menu_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Clear();
            MetroTile menu = (MetroTile)sender;
            getProd(Convert.ToInt32(menu.Name.Trim()));
        }
        private void getProd(int menuID)
        {
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
                            tileCreator(item.UrunAdi + "\n" + ((double)item.Fiyat).ToString(), item.UrunID.ToString(), 4);
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
                    PersonCount.TableID = selectedTableID;
                    PersonCount count = new PersonCount();
                    count.ShowDialog();
                    productLoader();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }
                
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
                                tileCreator(item.SalonAdi, item.SalonID.ToString(), 1);
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
                        tableLayoutPanel1.ColumnCount = 10;
                        tableLayoutPanel1.RowCount = 9;
                        foreach (var _item in result.ToList())
                        {
                            tileCreator(_item.MasaAdi, _item.MasaID.ToString(), 2);
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
            MenuTable.Controls.Clear();
            tableLayoutPanel1.Controls.Clear();
            NumbersPanel.Controls.Clear();
            numGenerator();
            getMenu();
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
                            tileCreator(item.UrunAdi, item.UrunID.ToString(), 3);
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
    }
}
