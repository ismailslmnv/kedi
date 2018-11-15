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
    public partial class ShowSubProducts : MetroForm
    {
        public static int ProductID;
        public ShowSubProducts()
        {
            InitializeComponent();
            //takeProduct();
            //createSubProducts();
        }
        private void showSubProducts(string tileID, string tileText)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(Products));
            MetroTile permission = new MetroTile();
            permission.Dock = System.Windows.Forms.DockStyle.Top;
            permission.Location = new System.Drawing.Point(100, 10);
            permission.Name = tileID;
            permission.Size = new System.Drawing.Size(902, 60);
            permission.Style = MetroFramework.MetroColorStyle.Green;
            permission.Text = tileText;
            permission.TextAlign = ContentAlignment.MiddleLeft;
            permission.TileTextFontSize = MetroTileTextSize.Tall;
            permission.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            permission.UseSelectable = true;            
            permission.Click += Permission_Click;         
            ozellikPanel.Controls.Add(permission);
            ozellikPanel.Controls.Add(breaker(tileID + 1));
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
        private void Permission_Click(object sender, EventArgs e)
        {
            MetroTile tile = (MetroTile)sender;

            edit(tile.Name);
        }
        private void createSubProducts()
        {
            try
            {
                using (KEDIDBEntities kEDIDB = new KEDIDBEntities())
                {
                    var result = (from altozellik in kEDIDB.Urunlers
                                  where altozellik.UstUrunID == ProductID
                                  select new
                                  {
                                      altozellik.UrunAdi,
                                      altozellik.UrunID
                                  }).DefaultIfEmpty().ToList();
                    if (result.Count != 0)
                    {
                        foreach (var item in result)
                        {
                            showSubProducts(item.UrunID.ToString(), item.UrunAdi);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void edit(string ID)
        {
            EditSubProduct.UrunID = Convert.ToInt32(ID.Trim());
            EditSubProduct product = new EditSubProduct();
            product.Show();
            //if (pressedControlButton == 1)
            //    foreach (var item in Menuler)
            //    {
            //        if (item.UrunID.ToString().Equals(ID))
            //        {
            //            EditPermission.YetkiID = item.UrunID;
            //            EditPermission edit = new EditPermission();
            //            edit.Show();
            //        }
            //    }
            //else if (pressedControlButton == 2)
            //{
            //    foreach (var item in Urun)
            //    {
            //        if (item.UrunID.ToString().Equals(ID))
            //        {
            //            select.UrunID = item.UrunID;
            //            select sel = new select();
            //            sel.Show();
            //        }
            //    }
            //}
        }
        private void takeProduct()
        {
            try
            {
                ozellikPanel.Controls.Clear();
                using (KEDIDBEntities kEDIDB=new KEDIDBEntities())
                {
                    var result = (from urun in kEDIDB.Urunlers
                                  where urun.UrunID == ProductID
                                  select urun.UrunAdi).DefaultIfEmpty().ToList();
                    if (result.Count > 0)
                    {
                        this.Text = "Alt Özellikler - " + result[0].TrimStart();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            try
            {
                //using (KEDIDBEntities kEDIDB = new KEDIDBEntities()) 
                //{
                //    var result = (from urun in kEDIDB.Urunlers
                //                  where urun.UrunID == ProductID
                //                  select urun.UstUrunID).FirstOrDefault();
                //    if (result != null)
                //    {
                AddProperty.ProductID = ProductID;
                AddProperty property = new AddProperty();
                        property.Show();
                //    }
                //    else
                //    {
                //        MessageBox.Show("İç Hata Oluştu. İşlem Gerçekleştirilemedi.");
                //    }
                //}
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void ShowSubProducts_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                takeProduct();
                createSubProducts();
            }
        }
    }
}
