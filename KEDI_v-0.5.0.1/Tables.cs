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
    public partial class Tables : MetroForm
    {
        private List<Salonlar> salon = new List<Salonlar>();
        private List<Masalar> masa = new List<Masalar>();

        public Tables()
        {
            InitializeComponent();

            //Default Olarak Salon Kismi Acilir ilk olarak ekran Boş Kalmasın
            username.Text = Enterance.usernameText;
            add.Text = "Salon Ekle";
            getSalonFromDB();
            salonPanel.Visible = true;
            tableDraggingPanel.Visible = false;
            masaDuzenle.Visible = false;
        }
        
        private void TableQuery(int salonId)
        {
            this.masa.Clear();//Önceki Verilerin Temizlenmesi Gerek
            try
            {
                using (KEDIDBEntities context = new KEDIDBEntities())
                {
                    var resultMasa = (from Masalar in context.Masalars select Masalar).DefaultIfEmpty().ToList();

                    if (resultMasa != null)
                    {
                        foreach (var masa in resultMasa)
                        {
                            if (masa.Salonlar.SalonID.Equals(salonId))
                                this.masa.Add(masa);
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show(AddSalon.ActiveForm, "Bir Hata Meydana Geldi Tekrar Deneyiniz", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Tables_Load(object sender, EventArgs e)
        {
            //------ Gerek olmaya Bilir
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
            TableSaveLocation(c);//Drag Drop Ta tekrardan Yerleri Kayit Ediliyor DB te
            //++++++++ Daha sonradan cizilecek duvar yerine masanin gelmesi yasak olacak
        }

        private void tableDraggingPanel_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
        private void TableSaveLocation(Control sender)
        {
            try
            {
                using (KEDIDBEntities context = new KEDIDBEntities())
                { 
                    var masalar = (from masa in context.Masalars where masa.MasaID.Equals(sender.TabIndex) select masa).ToList();
                    foreach (Masalar masa in masalar)
                    {
                        if (masa.SalonID.Equals(this.masa.First().Salonlar.SalonID))
                        {
                            masa.KonumX = sender.Location.X;
                            masa.KonumY = sender.Location.Y;
                            context.SaveChanges();
                        }
                    }

                }
            }
            catch (Exception)
            {
                MessageBox.Show(AddSalon.ActiveForm, "Bir Hata Meydana Geldi Tekrar Deneyiniz", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void salonlarMenu_Click(object sender, EventArgs e)
        {
            add.Text = "Salon Ekle";
            salonPanel.Visible = true;
            tableDraggingPanel.Visible = false;
            MasaAltMenu.Visible = false;
            masaDuzenle.Visible = false;
            getSalonFromDB();
            this.salonPanel.Controls.Clear();//Onceki olusanlari Yok Etmek Icin

            foreach (Salonlar salonlar in this.salon)
                CreateSalonTile(salonlar);
        }

        private void getSalonFromDB()
        {
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
                        MessageBox.Show(this, "Hiç Bir Kayıtlı Salon Bulunmamaktadır.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(AddSalon.ActiveForm, "Bir Hata Meydana Geldi Tekrar Deneyiniz", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CreateSalonTile(Salonlar salonlar)
        {
            MetroTile salon = new MetroTile();
            this.salonPanel.Controls.Add(salon);
            salon.Dock = System.Windows.Forms.DockStyle.Top;
            salon.Location = new System.Drawing.Point(100, 10);
            salon.Size = new System.Drawing.Size(902, 60);
            salon.Style = MetroFramework.MetroColorStyle.Orange;
            salon.Text = salonlar.SalonAdi;
            salon.TabIndex = salonlar.SalonID;
            salon.TextAlign = ContentAlignment.MiddleLeft;
            salon.TileTextFontSize = MetroTileTextSize.Tall;
            salon.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            salon.UseSelectable = true;
            salon.Click += new EventHandler(Salon_Click);
        }
        private void Salon_Click(object sender, EventArgs e)
        {
            selectSalon select = new selectSalon();
            selectSalon.selectedSalonTile = sender as MetroTile;
            selectSalon.salonlar = this.salon;
            select.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SelectSalon_Closing);
            select.Show();
        }
        private void SelectSalon_Closing(object sender, EventArgs e)
        {
            getSalonFromDB();
            this.salonPanel.Controls.Clear();
            foreach(Salonlar salonlar in this.salon)
                CreateSalonTile(salonlar);
        }

        private void masalarMenu_Click(object sender, EventArgs e)
        {
            add.Text = "Masa Ekle";
            tableDraggingPanel.Visible = true;
            salonPanel.Visible = false;
            MasaAltMenu.Visible = true;
            masaDuzenle.Visible = true;
            MasaAltMenuOlustur();
        }

        private void MasaAltMenuOlustur()
        {
            MasaAltMenu.Controls.Clear();//Kalan Controllerin Tekrarini Engellemek
            foreach (Salonlar s in salon)
                MasaAltMenu_TileCreator(s.SalonAdi, s.SalonID);
        }

        private void MasaAltMenu_TileCreator(string salonAdi,int salonId)
        {
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
            tableDraggingPanel.Controls.Clear();
            MetroTile tile = sender as MetroTile;
            TableQuery(tile.TabIndex);
            foreach (Masalar mas in this.masa)
                MasaCreate(mas);
            TableDraggingEvent();//Masa Olustuktan Sonra Cagiriliyor Ki sonradan Eklenenler Dragg Yapilsin
        }
        private void MasaCreate(Masalar masalar)
        {
            Button masa = new Button();
            masa.Location = new System.Drawing.Point(Convert.ToInt32(masalar.KonumX), Convert.ToInt32(masalar.KonumY));//?????? Decimal Kabul Etmiyor
            masa.Size = new System.Drawing.Size(50, 50);
            masa.TabIndex = masalar.MasaID;
            masa.Text = masalar.MasaAdi;
            masa.UseVisualStyleBackColor = true;
            this.tableDraggingPanel.Controls.Add(masa);
        }
        private void TableDraggingEvent()
        {
            this.tableDraggingPanel.AllowDrop = true;
            foreach (Control c in this.tableDraggingPanel.Controls)
            {
                c.MouseDown += new MouseEventHandler(tableDraggingPanel_MouseDown);
            }
            this.tableDraggingPanel.DragOver += new DragEventHandler(tableDraggingPanel_DragOver);
            this.tableDraggingPanel.DragDrop += new DragEventHandler(tableDraggingPanel_DragDrop);
        }
        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();// ????????????? Gerek Varmidir Bu Form Elemanina 
        }
    }
}
