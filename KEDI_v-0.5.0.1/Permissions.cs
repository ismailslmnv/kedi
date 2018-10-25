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
    public partial class Permissions : MetroForm
    {        
        private List<Yetkiler> Yetkiler = new List<Yetkiler>();
        public Permissions()
        {
            InitializeComponent();
            username.Text = Enterance.usernameText;
            getPermissionsFromDb();
        }
        private void Permissions_Load(object sender, EventArgs e)
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
            permission.TileImage = Image.FromFile(@"D:\projects\KEDI\Icons\Icons-20180611T000513Z-001\Icons\edit11.png");               
            permission.TileImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            permission.TileTextFontSize = MetroTileTextSize.Tall;
            permission.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            permission.UseSelectable = true;
            permission.UseTileImage = true;
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
            breaker.Size = new System.Drawing.Size(902, 3);
            breaker.TabIndex = 3;
            breaker.VerticalScrollbarBarColor = true;
            breaker.VerticalScrollbarHighlightOnWheel = false;
            breaker.VerticalScrollbarSize = 10;
            return breaker;
        }
        private void getPermissionsFromDb()
        {
            try
            {
                using (KEDIDBEntities context = new KEDIDBEntities())
                {
                    var result = (from yetkiler in context.Yetkilers select yetkiler).DefaultIfEmpty().ToList();
                    if (result != null)
                    {
                        foreach (var item in result)
                        {
                            tileCreator(item.YetkiAdi, item.YetkiID.ToString());
                        }
                        Yetkiler = result;
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void yetkiMenu_Click(object sender, EventArgs e)
        {

        }
        private void edit (string ID)
        {
            foreach (var item in Yetkiler)
            {
                if (item.YetkiID.ToString().Equals(ID))
                {
                    MessageBox.Show(item.YetkiAdi);
                    EditPermissions edit = new EditPermissions();
                    edit.Show();
                }
            }
        }
    }
}
