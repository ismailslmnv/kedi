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
using MetroFramework.Controls;
using System.Resources;

namespace KEDI_v_0._5._0._1
{
    public partial class Products : MetroForm
    {        
        private List<Urunler> Menuler= new List<Urunler>();
        private List<Urunler> Urun = new List<Urunler>();
        private List<Indirimler> Indirim = new List<Indirimler>();
        private short pressedControlButton = 0; // 0 - none // 1 - menuler // 2 - urunler // 3 - indirimler     
        public Products()
        {
            InitializeComponent();
            username.Text = Enterance.usernameText;
            add.Text = "";
            add.Visible = false;
        }
        private void Products_Load(object sender, EventArgs e)
        {

        }           
        private void tileCreator(string tileText, string tileID)
        {            
            ComponentResourceManager resources = new ComponentResourceManager(typeof(Permissions));
            MetroTile permission = new MetroTile();
            permission.Dock = System.Windows.Forms.DockStyle.Top;
            permission.Location = new System.Drawing.Point(100, 10);
            permission.Name = tileID;
            permission.Size = new System.Drawing.Size(902, 60);
            permission.Style = MetroFramework.MetroColorStyle.Green;
            permission.Text = tileText;
            permission.TextAlign = ContentAlignment.MiddleLeft;
            //permission.TileImage = Image.FromFile(@"D:\projects\KEDI\Icons\Icons-20180611T000513Z-001\Icons\edit11.png");               
     //       permission.TileImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            permission.TileTextFontSize = MetroTileTextSize.Tall;
            permission.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            permission.UseSelectable = true;
       //     permission.UseTileImage = true;
            permission.Click += Permission_Click;            
            tilePanel.Controls.Add(permission);
            tilePanel.Controls.Add(breaker(tileID + 1));                
        }

        private void Permission_Click(object sender, EventArgs e)
        {
            MetroTile tile = (MetroTile)sender;
            edit(tile.Name);                                    
        }
        private MetroPanel breaker(string panelName)
        {
            MetroPanel breaker = new MetroPanel();
            breaker.Dock = System.Windows.Forms.DockStyle.Top;
            breaker.HorizontalScrollbarBarColor = true;
            breaker.HorizontalScrollbarHighlightOnWheel = false;
            breaker.HorizontalScrollbarSize = 10;
            breaker.Location = new System.Drawing.Point(100, 70);
            breaker.Name = panelName+"p";
            breaker.Size = new System.Drawing.Size(900, 3);
            breaker.TabIndex = 3;
            breaker.VerticalScrollbarBarColor = true;
            breaker.VerticalScrollbarHighlightOnWheel = false;
            breaker.VerticalScrollbarSize = 10;
            return breaker;
        }
        private void getMenuFromDb()
        {
            add.Text = "Menü Ekle";
            add.Visible = true;
            tilePanel.Controls.Clear();            
            try
            {
                using (KEDIDBEntities context = new KEDIDBEntities())
                {
                    var result = (from menu in context.Urunlers where menu.UstUrunID==0 select menu).DefaultIfEmpty().ToList();
                    if (result != null)
                    {
                        foreach (var item in result)
                        {
                            tileCreator(item.UrunAdi, item.UrunID.ToString());
                        }
                        Menuler = result;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void menu_Click(object sender, EventArgs e)
        {
            pressedControlButton = 1;
            getMenuFromDb();
        }
        private void edit (string ID)
        {
            if (pressedControlButton == 1)
                foreach (var item in Menuler)
                {
                    if (item.UrunID.ToString().Equals(ID))
                    {
                        EditMenu.UrunID = item.UrunID;
                        EditMenu edit = new EditMenu();
                        edit.Show();
                    }
                }
            else if (pressedControlButton == 2)
            {             
                foreach (var item in Urun)
                {
                    if (item.UrunID.ToString().Equals(ID))
                    {
                        select.UrunID = item.UrunID;
                        select sel = new select();
                        sel.Show();
                    }
                }
            }
            else if (pressedControlButton == 3)
            {
                foreach(var item in Indirim)
                {
                    if (item.IndirimID.ToString().Equals(ID))
                    {
                        EditDiscount.IndirimID = item.IndirimID;
                        EditDiscount discount = new EditDiscount();
                        discount.Show();
                    }
                }
            }
        }

        private void metroPanel5_Paint(object sender, PaintEventArgs e)
        {

        }
        private void metroTile1_Click(object sender, EventArgs e)
        {
            if(pressedControlButton==1)
            {

                AddMenu add = new AddMenu();
                add.Show();
            }
            else if (pressedControlButton == 2)
            {
                AddProduct _add = new AddProduct();
                _add.Show();
            }
            else if (pressedControlButton == 3)
            {
                add.Visible = false;
            }            
        }

        private void exit_Click(object sender, EventArgs e)
        {

        }
        private void Back_Click(object sender, EventArgs e)
        {
            _thisClose();
        }
        private void _thisClose()
        {
          //  Enterance.enterance.Show();
            this.Dispose();
        }
        private void Products_FormClosing(object sender, FormClosingEventArgs e)
        {
            _thisClose();
        }
        private void Products_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                if (pressedControlButton == 1)
                    getMenuFromDb();
                else if (pressedControlButton == 2)
                {                                        
                    getUrunFromDb();
                }
                else if (pressedControlButton == 3)
                {
                    getIndirimFromDb();
                }
            }
        }
        private void getUrunFromDb()
        {
            add.Text = "Ürün Ekle";
            add.Visible = true;
            tilePanel.Controls.Clear();           
            try
            {
                using (KEDIDBEntities context = new KEDIDBEntities())
                {
                    var result = (from urun in context.Urunlers
                                  where urun.UstUrunID!=0
                                  where urun.AltOzellik==false
                                  select urun).DefaultIfEmpty().ToList();
                    if (result != null)
                    {
                        foreach (var item in result)
                        {
                            tileCreator(item.UrunAdi, item.UrunID.ToString());
                        }
                        Urun = result;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void product_Click(object sender, EventArgs e)
        {
            pressedControlButton = 2;
            getUrunFromDb();
        }
        private void indirimler_Click(object sender, EventArgs e)
        {
            pressedControlButton = 3;
            getIndirimFromDb();
        }
        private void getIndirimFromDb()
        {
            try
            {
                add.Visible = false;
                tilePanel.Controls.Clear();
                using (KEDIDBEntities kEDIDB = new KEDIDBEntities())
                {
                    var result = (from i in kEDIDB.Indirimlers select i).DefaultIfEmpty().ToList();
                    if (result.Count!=0)
                    {
                        foreach (var item in result)
                        {
                            tileCreator(item.IndirimAdi, item.IndirimID.ToString());
                        }
                        Indirim = result;
                    }
                }
            } catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
