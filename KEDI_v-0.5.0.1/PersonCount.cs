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
using MetroFramework.Controls;
using MetroFramework.Forms;

namespace KEDI_v_0._5._0._1
{
    public partial class PersonCount : MetroForm
    {
        public static int TableID;
        private static string PROCEED = "PROCEED";
        private static string CANCEL = "CANCEL";
        public PersonCount()
        {
            InitializeComponent();
            numGenerator();
        }
        private void numGenerator()
        {
            for (int i = 1; i < 10; i++)
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(Order));
                MetroTile _tile = new MetroTile();
                _tile.Dock = System.Windows.Forms.DockStyle.Left;
                _tile.Location = new System.Drawing.Point(100, 10);
                _tile.Name = i.ToString();
                _tile.Size = new System.Drawing.Size(100, 60);
                _tile.Style = MetroFramework.MetroColorStyle.Lime;
                _tile.Text = i.ToString();
                _tile.TextAlign = ContentAlignment.MiddleCenter;
                _tile.TileTextFontSize = MetroTileTextSize.Tall;
                _tile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
                _tile.UseSelectable = true;                
                _tile.Click += _numClick;
                tableLayoutPanel1.Controls.Add(_tile);
            }
            MetroTile _zerotile = new MetroTile();
            _zerotile.Dock = System.Windows.Forms.DockStyle.Left;
            _zerotile.Location = new System.Drawing.Point(100, 10);
            _zerotile.Name = "0";
            _zerotile.Size = new System.Drawing.Size(100, 60);
            _zerotile.Style = MetroFramework.MetroColorStyle.Lime;
            _zerotile.Text = "0";
            _zerotile.TextAlign = ContentAlignment.MiddleCenter;
            _zerotile.TileTextFontSize = MetroTileTextSize.Tall;
            _zerotile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            _zerotile.UseSelectable = true;
            _zerotile.Click += _numClick;
            tableLayoutPanel1.Controls.Add( _zerotile);
            for (int i = 0; i < 2; i++)
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(Order));
                MetroTile _tile = new MetroTile();
                _tile.Dock = System.Windows.Forms.DockStyle.Left;
                _tile.Location = new System.Drawing.Point(100, 10);
                
                _tile.Size = new System.Drawing.Size(100, 60);                
                if (i == 0)
                {
                    _tile.Style = MetroFramework.MetroColorStyle.Red;
                    _tile.Name = CANCEL;
                    _tile.Text = "Vazgeç";
                }
                else
                {
                    _tile.Style = MetroFramework.MetroColorStyle.Green;
                    _tile.Name = PROCEED;
                    _tile.Text = "Devam Et";
                }
                _tile.TextAlign = ContentAlignment.MiddleCenter;
                _tile.TileTextFontSize = MetroTileTextSize.Tall;
                _tile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
                _tile.UseSelectable = true;
                _tile.Click += _butClick;
                tableLayoutPanel1.Controls.Add(_tile);

            }
        }

        private void _butClick(object sender, EventArgs e)
        {
            MetroTile button = (MetroTile)sender;
            if (button.Name.Equals(PROCEED))
            {
                numChecker();
            }
            else this.Close();
        }

        private void _numClick(object sender, EventArgs e)
        {
            MetroTile clickedNum = (MetroTile)sender;
            persCount.Text += clickedNum.Name;
        }
        private bool numChecker()
        {

            try
            {
                int txt = Convert.ToInt32(persCount.Text.Trim());
                Order.persCount = txt;
                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
           
            return false;
        }
    }
}
