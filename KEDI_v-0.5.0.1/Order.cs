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
        public Order()
        {
            InitializeComponent();
        }

        private void save_Click(object sender, EventArgs e)
        {

        }
        private void tileCreator(string tileText, string tileID, int Type)//Type -- 1=Salon 2=Masa 3=Menu 4=Urun
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(Order));
            MetroTile _tile = new MetroTile();
            _tile.Dock = System.Windows.Forms.DockStyle.Top;
            _tile.Location = new System.Drawing.Point(100, 10);
            _tile.Name = tileID;
            _tile.Size = new System.Drawing.Size(902, 60);
            _tile.Style = MetroFramework.MetroColorStyle.Green;
            _tile.Text = tileText;
            _tile.TextAlign = ContentAlignment.MiddleLeft;
            //_tile.TileImage = Image.FromFile(@"D:\projects\KEDI\Icons\Icons-20180611T000513Z-001\Icons\edit11.png");               
            //       _tile.TileImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            _tile.TileTextFontSize = MetroTileTextSize.Tall;
            _tile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            _tile.UseSelectable = true;
            //     _tile.UseTileImage = true;
            _tile.Click += _tile_Click;
            if (Type == 1)
            {
                sidePanel.Controls.Add(_tile);
                sidePanel.Controls.Add(breaker(tileID + 1));
            }
            else
            {
                mainPanel.Controls.Add(_tile);
                mainPanel.Controls.Add(breaker(tileID + 1));
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
            
        }
    }
}
