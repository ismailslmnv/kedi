﻿using System;
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
    public partial class Tables : MetroForm
    {
        private List<Salonlar> salon = new List<Salonlar>();

        public Tables()
        {
            InitializeComponent();

            //Default Olarak Salon Kismi Acilir ilk olarak ekran Boş Kalmasın
            username.Text = Enterance.usernameText;
            add.Text = "Salon Ekle";
            getSalonFromDB();
            salonPanel.Visible = true;
            tableDraggingPanel.Visible = false;
        }
        
        private void TableQuery(short salonId)
        {
            using (KEDIDBEntities context = new KEDIDBEntities())
            {
                var resultSalon = (from salon in context.Salonlars where salon.SalonID.Equals(salonId) select salon).First();
                var resultMasa = (from Masalar in context.Masalars select Masalar).DefaultIfEmpty().ToList();

                if (resultMasa != null && resultSalon != null)
                {
                    foreach (var masa in resultMasa)
                    {
                        if (masa.SalonID.Equals(resultSalon.SalonID))
                            TableQuery(5);//+++++++++ Ekrana Yazdirma Cagirilacak
                    }
                }
            }
        }
        private void Tables_Load(object sender, EventArgs e)
        {
            this.tableDraggingPanel.AllowDrop = true;
            foreach (Control c in this.tableDraggingPanel.Controls)
            {
                c.MouseDown += new MouseEventHandler(tableDraggingPanel_MouseDown);
            }
            this.tableDraggingPanel.DragOver += new DragEventHandler(tableDraggingPanel_DragOver);
            this.tableDraggingPanel.DragDrop += new DragEventHandler(tableDraggingPanel_DragDrop);
        }

        private void add_Click(object sender, EventArgs e)
        {
            if (add.Text.Equals("Salon Ekle"))
            {
                AddSalon addsalon = new AddSalon();
                addsalon.ShowDialog();
            }
            if (add.Text.Equals("Masa Ekle"))
            {
                AddTable addtable = new AddTable();
                addtable.ShowDialog();
            }
        }
        private void Back_Click(object sender, EventArgs e)
        {
            _thisClose();
        }
        private void _thisClose()
        {
            Enterance.enterance.Show();
            this.Dispose();
        }

        private void Tables_FormClosing(object sender, FormClosingEventArgs e)
        {
            _thisClose();
        }


        private void tableDraggingPanel_MouseDown(object sender, MouseEventArgs e)
        {
            Control c = sender as Control;
            c.DoDragDrop(c, DragDropEffects.Move);
        }

        private void tableDraggingPanel_DragDrop(object sender, DragEventArgs e)
        {
            Control c = e.Data.GetData(e.Data.GetFormats()[0]) as Control;
            if (c != null)
            {
                c.Location = this.tableDraggingPanel.PointToClient(new Point(e.X, e.Y));
                this.tableDraggingPanel.Controls.Add(c);
            }
        }

        private void tableDraggingPanel_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void salonlarMenu_Click(object sender, EventArgs e)
        {
            add.Text = "Salon Ekle";
            salonPanel.Visible = true;
            tableDraggingPanel.Visible = false;
            MasaAltMenu.Visible = false;
            getSalonFromDB();

            foreach(var s in salon)
            {
                listBox1.Items.Add(s.SalonAdi);
            }
        }

        private void getSalonFromDB()
        {
            listBox1.Items.Clear();//Tekrar Çağırılması Sonucu Veri Tekrarını Engellemek İçin
            salon.Clear();
            try
            {
                using (KEDIDBEntities context = new KEDIDBEntities())
                {
                    var result = (from salon in context.Salonlars
                                  where salon.SalonID != 0
                                  select salon).DefaultIfEmpty().ToList();
                    if (result != null)
                    {
                        foreach (var item in result)
                            salon.Add(item);
                    }
                    else
                    {
                        MessageBox.Show(this, "Hiç Bir Kayıtlı Salon Bulunmamaktadır.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show(AddSalon.ActiveForm, "Bir Hata Meydana Geldi Tekrar Deneyiniz", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void masalarMenu_Click(object sender, EventArgs e)
        {
            add.Text = "Masa Ekle";
            tableDraggingPanel.Visible = true;
            salonPanel.Visible = false;
            MasaAltMenu.Visible = true;
            MasaAltMenuOlustur();
            //++++++++ Db Okuma ve Eklenmemiş Masa Kotrolü
        }

        private void MasaAltMenuOlustur()
        {

            MasaAltMenu.Controls.Clear();//Kalan Controllerin Tekrarini Engellemek
            foreach (Salonlar s in salon)
                MasaAltMenu_TileCreator(s.SalonAdi, s.SalonID);

        }

        private void MasaAltMenu_TileCreator(string salonAdi,int salonId)
        {
            //++++++++++ Belli bir yerden sonra ekrandan tasiyor eklenecek
            MetroTile metroTile = new MetroTile();
            this.MasaAltMenu.Controls.Add(metroTile);
            metroTile.ActiveControl = null;
            metroTile.Name = salonAdi.Trim(' ');
            metroTile.Dock = System.Windows.Forms.DockStyle.Top;
            metroTile.Location = new System.Drawing.Point(17, 0);
            metroTile.Margin = new System.Windows.Forms.Padding(10);
            metroTile.Size = new System.Drawing.Size(211, 64);
            metroTile.TabIndex = salonId;
            metroTile.Text = salonAdi;
            metroTile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            metroTile.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            metroTile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            metroTile.UseSelectable = true;
            metroTile.MouseClick += new System.Windows.Forms.MouseEventHandler(MasaAltMenu_MouseClick);
        }

        private void MasaAltMenu_MouseClick(object sender, MouseEventArgs e)
        {
            MetroTile tile = sender as MetroTile;
            //+++++++ Secilen Salona Gore ekrana salonda bulunan masalari yazdiracak 
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();// ????????????? Gerek Varmidir Bu Form Elemanina 
        }
    }
}
