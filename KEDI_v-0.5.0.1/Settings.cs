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
    public partial class Settings : MetroForm
    {
        int selectedSetting = 0; // 1-Printers
        public Settings()
        {
            InitializeComponent();
            Add.Visible = false;
        }

        private void printerSettings_Click(object sender, EventArgs e)
        {
            selectedSetting = 1;
            Add.Visible = true;           
            loadAddedPrinters();           
        }

        private void metroTile1_Click(object sender, EventArgs e)// Add Button
        {
            if (selectedSetting==1)
            {
                addPrinter add = new addPrinter();
                add.ShowDialog();
            }                        
        }
        private void loadAddedPrinters()
        {
            try
            {
                using (KEDIDBEntities kEDIDB = new KEDIDBEntities())
                {
                    var result = (from printer in kEDIDB.Printers select printer).DefaultIfEmpty();
                    if (result!=null)
                    {
                        foreach (var item in result.ToList())
                        {
                            tileCreator(item.PrinterName, item.PrinterID.ToString());
                        }
                    }
                    else MetroMessageBox.Show(this,"Tanımlı Yazıcı Bulunamadı. Lütfen Önce Yazıcı Ekleyin!");
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void tileCreator(string tileText, string tileID)
        {            
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
            fillPanel.Controls.Add(_tile);
            fillPanel.Controls.Add(breaker(tileID + 1));
        }

        private void _tile_Click(object sender, EventArgs e)
        {
            MetroTile printer = (MetroTile)sender;
            EditPrinter.PrinterID = (Convert.ToInt32(printer.Name.ToString().Trim()));
            EditPrinter edit = new EditPrinter();
            edit.ShowDialog();
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
    }
}
