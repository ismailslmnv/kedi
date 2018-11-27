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
        }

        private void _masa_Click(object sender, EventArgs e)
        {
            if (tablePanelType == 1)
            {
                MetroTile table = (MetroTile)sender;
                selectedTableID = Convert.ToInt32(table.Name.Trim());
                MessageBox.Show(selectedTableID.ToString());
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
        private void showTables()
        {
            int counter = 0;
            for (int i=0; i<masalar.Count;i++)
            {
                if (++counter % 3 == 0)
                {
                    MetroPanel breaker = new MetroPanel();
                    breaker.Dock = System.Windows.Forms.DockStyle.Top;
                    breaker.HorizontalScrollbarBarColor = false;
                    breaker.HorizontalScrollbarHighlightOnWheel = false;
                    breaker.Size = new System.Drawing.Size(900, 61);
                    breaker.TabIndex = 3;
                    breaker.VerticalScrollbarBarColor = false;
                    breaker.VerticalScrollbarHighlightOnWheel = false;
                    breaker.Controls.Add(masalar[i]);
                }
                else
                {

                }                
            }            
        }
        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
