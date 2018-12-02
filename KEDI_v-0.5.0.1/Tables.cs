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
        private List<Salonlar> salonLIST = new List<Salonlar>();
        private List<Masalar> masaLIST = new List<Masalar>();
        private bool IsEditModeActive = false;
        private Point[,] squares;
        private int salonBoyutx, salonBoyuty;
        private string walls;//   i-j i-j i-j formatinda

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
        

        //Veri tabanından masaları çeker listeye 
        private void getMasaFromDB(int salonId)
        {
            this.masaLIST.Clear();//Önceki Verilerin Temizlenmesi Gerek
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
                                this.masaLIST.Add(masa);
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show(AddSalon.ActiveForm, "Bir Hata Meydana Geldi Tekrar Deneyiniz", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //Masa veya Salon Ekleme butonu işlemleri
        private void add_Click(object sender, EventArgs e)
        {
            if (tableDraggingPanel.Visible == false)
            {
                AddSalon addsalon = new AddSalon();
                addsalon.ShowDialog();
            }
            if (tableDraggingPanel.Visible == true)
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
            //++++++++ Daha sonradan cizilecek duvar yerine masanin gelmesi yasak olacak
        }

        private void tableDraggingPanel_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        //Kaydet Butonuna Basıldıktan Sonra Tüm masalar Kaydolur
        private void TableSaveLocation(Control sender)
        {
            try
            {
                using (KEDIDBEntities context = new KEDIDBEntities())
                { 
                    var masalar = (from masa in context.Masalars where masa.MasaID.Equals(sender.TabIndex) select masa).ToList();
                    foreach (Masalar masa in masalar)
                    {
                        if (masa.SalonID.Equals(this.masaLIST.First().Salonlar.SalonID))
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


        //Salonlar Menü Tıklaması 
        private void salonlarMenu_Click(object sender, EventArgs e)
        {
            add.Text = "Salon Ekle";
            salonPanel.Visible = true;
            tableDraggingPanel.Visible = false;
            MasaAltMenu.Visible = false;
            masaDuzenle.Visible = false;
            getSalonFromDB();
            this.salonPanel.Controls.Clear();//Onceki olusanlari Yok Etmek Icin

            foreach (Salonlar salonlar in this.salonLIST)
                CreateSalonTile(salonlar);
        }

        private void getSalonFromDB()
        {
            salonLIST.Clear();
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
                            salonLIST.Add(item);
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
            selectSalon.salonlar = this.salonLIST;
            select.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SelectSalon_Closing);
            select.Show();
        }
        private void SelectSalon_Closing(object sender, EventArgs e)
        {
            getSalonFromDB();
            this.salonPanel.Controls.Clear();
            foreach(Salonlar salonlar in this.salonLIST)
                CreateSalonTile(salonlar);
        }

        private void masalarMenu_Click(object sender, EventArgs e)
        {
            add.Text = "Masa Ekle";
            tableDraggingPanel.Visible = true;
            salonPanel.Visible = false;
            MasaAltMenu.Visible = true;
            MasaAltMenuOlustur();
        }

        private void MasaAltMenuOlustur()
        {
            MasaAltMenu.Controls.Clear();//Kalan Controllerin Tekrarini Engellemek
            foreach (Salonlar s in salonLIST)
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
        //Paneli Parcaliyor matris e atiyor
        private void CreatePanelMatrix()
        {
            int satir = tableDraggingPanel.Size.Height / salonBoyuty, stun = tableDraggingPanel.Size.Width / salonBoyutx;
            squares = new Point[satir, stun];
            for (int i = 0; i < satir; i++)
            {
                for (int j = 0; j < stun; j++)
                {
                    squares[i,j] = new Point(j * (salonBoyutx), i * (salonBoyuty));
                }
            }
        }
        // kare kare boluyor ekrani
        private void makeSquare()
        {
            int x = tableDraggingPanel.Size.Height / salonBoyuty, y = tableDraggingPanel.Size.Width / salonBoyutx;
            Graphics g = tableDraggingPanel.CreateGraphics();
            Pen p = new Pen(Color.Black);
            for (int i = 1; i <= x; i++)
                g.DrawLine(p,0,i*(salonBoyuty),tableDraggingPanel.Size.Width, i *(salonBoyuty));
            for (int i = 1; i <=  y; i++)
                g.DrawLine(p, i * (salonBoyutx), 0, i * (salonBoyutx), tableDraggingPanel.Size.Height);
        }

        private void MasaAltMenu_MouseClick(object sender, MouseEventArgs e)
        {
            tableDraggingPanel.Controls.Clear();
            MetroTile tile = sender as MetroTile;
            tableDraggingPanel.TabIndex = tile.TabIndex;//Hangi Salon Aktif Ise onun Indexsini tutmasi gerekiyor
            getMasaFromDB(tile.TabIndex);

            foreach (Masalar mas in this.masaLIST)
                MasaCreate(mas);

            RemoveTableDraggingEvent();
            masaDuzenle.Visible = true;

            foreach(Salonlar sal in this.salonLIST)
            {
                salonBoyutx = (sal.SalonID == tile.TabIndex) ? Convert.ToInt32(sal.BoyutX) : 0;
                salonBoyuty = (sal.SalonID == tile.TabIndex) ? Convert.ToInt32(sal.BoyutY) : 0;
                if (salonBoyutx != 0 && salonBoyuty != 0) break;
            }

            GetWallFromDB();
            CreatePanelMatrix();
            CreateWalls();
        }
        private void MasaCreate(Masalar masalar)
        {
            Button masa = new Button();
            masa.Location = new System.Drawing.Point(Convert.ToInt32(masalar.KonumX), Convert.ToInt32(masalar.KonumY));
            masa.Size = new System.Drawing.Size(Convert.ToInt32(masalar.BoyutX) + 10 , Convert.ToInt32(masalar.BoyutY) + 10);
            masa.TabIndex = masalar.MasaID;
            masa.Text = masalar.MasaAdi;
            masa.UseVisualStyleBackColor = true;
            this.tableDraggingPanel.Controls.Add(masa);
        }
        private void AddTableDraggingEvent()
        {
            this.tableDraggingPanel.AllowDrop = true;
            foreach (Control c in this.tableDraggingPanel.Controls)
            {
                c.MouseDown += new MouseEventHandler(tableDraggingPanel_MouseDown);
                c.Click -= new EventHandler(Masa_Click);
            }
            this.tableDraggingPanel.DragOver += new DragEventHandler(tableDraggingPanel_DragOver);
            this.tableDraggingPanel.DragDrop += new DragEventHandler(tableDraggingPanel_DragDrop);
        }
        private void screenGrapher(object sender,MouseEventArgs e)
        {
            makeSquare();
        }
        private void RemoveTableDraggingEvent()
        {
            this.tableDraggingPanel.DragOver -= new DragEventHandler(tableDraggingPanel_DragOver);
            this.tableDraggingPanel.DragDrop -= new DragEventHandler(tableDraggingPanel_DragDrop);
            foreach (Control c in this.tableDraggingPanel.Controls)
            {
                c.MouseDown -= new MouseEventHandler(tableDraggingPanel_MouseDown);
                c.Click += new EventHandler(Masa_Click);
            }
        }
        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void masaDuzenle_Click(object sender, EventArgs e)
        {
            AddTableDraggingEvent();
            masaDuzenlemeModu.Text = "Salon Düzenleme Modu Aktif";
            this.tableDraggingPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tableDraggingPanel_MouseClick);
            add.Visible = false;
            masaDuzenle.Visible = false;
            masaDuzenlemeModu.Visible = true;
            saveChanges.Visible = true;
            cancelChanges.Visible = true;
            addWalls.Visible = true;
        }
        private void Masa_Click(object sender, EventArgs e)
        {
            selectMasa select = new selectMasa();
            selectMasa.selectedMasaButton = sender as Button;
            selectMasa.masalar = this.masaLIST;
            select.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SelectMasa_Closing);
            select.Show();
        }
        private void SelectMasa_Closing(object sender, EventArgs e)
        {
            getMasaFromDB(this.masaLIST.First().SalonID);
            this.tableDraggingPanel.Controls.Clear();
            foreach (Masalar mas in this.masaLIST)
                MasaCreate(mas);
           AddTableDraggingEvent(); // Bu bir ara silinecekti 
        }

        private void saveChanges_Click(object sender, EventArgs e)
        {
            foreach (Button c in this.tableDraggingPanel.Controls)
            {
                TableSaveLocation(c);
            }
            SaveWalls();
            RemoveTableDraggingEvent();
            tableDraggingPanel.BackColor = Color.White;
            this.tableDraggingPanel.MouseClick -= new System.Windows.Forms.MouseEventHandler(this.tableDraggingPanel_MouseClick);
            add.Visible = true;
            masaDuzenle.Visible = true;
            masaDuzenlemeModu.Visible = false;
            saveChanges.Visible = false;
            cancelChanges.Visible = false;
            addWalls.Visible = false;
        }

        //
        private void cancelChanges_Click(object sender, EventArgs e)
        {
            tableDraggingPanel.Controls.Clear();
            tableDraggingPanel.Invalidate();
            tableDraggingPanel.BackColor = Color.White;
            add.Visible = true;
            masaDuzenle.Visible = true;
            masaDuzenlemeModu.Visible = false;
            saveChanges.Visible = false;
            cancelChanges.Visible = false;
            addWalls.Visible = false;

            foreach (Masalar mas in this.masaLIST)
                MasaCreate(mas);

            RemoveTableDraggingEvent();
            foreach (Control c in this.tableDraggingPanel.Controls)
                c.MouseMove -= new MouseEventHandler(screenGrapher);

        }

        //DB den çekılen strıng walls a aktarıldıktan sonra burada okunur ve boyanır
        private void CreateWalls()
        {
            string tmp = "";
            Graphics g = tableDraggingPanel.CreateGraphics();
            for (int i = 0; i < walls.Length; i++)
            {
                if (walls[i] == ' ')
                {
                    g.FillRectangle(Brushes.Aqua, squares[Convert.ToInt32(tmp.Split('-')[0]), Convert.ToInt32(tmp.Split('-')[1])].X, squares[Convert.ToInt32(tmp.Split('-')[0]), Convert.ToInt32(tmp.Split('-')[1])].Y, salonBoyutx, salonBoyuty);
                    tmp = "";
                }
                tmp += walls[i];
            }
        }

        //Seçilen Duvarları walls değişkenini kaydeder
        private void SaveWalls()
        {
            try
            {
                using (KEDIDBEntities context = new KEDIDBEntities())
                {
                    var result = (from salon in context.Salonlars where salon.SalonID.Equals(tableDraggingPanel.TabIndex) select salon).First();
                    if (result != null)
                    {
                        result.Duvarlar = walls;
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show(AddSalon.ActiveForm, "Bir Hata Meydana Geldi Tekrar Deneyiniz", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Veri Tabanından İşaretlenmiş Duvarları Çeker
        private void GetWallFromDB()
        {
            try
            {
                using (KEDIDBEntities context = new KEDIDBEntities())
                {
                    string result = context.Salonlars.Where(x => x.SalonID.Equals(tableDraggingPanel.TabIndex)).Select(x => x.Duvarlar).First();
                    this.walls = result;
                }
            }
            catch (Exception)
            {
                MessageBox.Show(AddSalon.ActiveForm, "Bir Hata Meydana Geldi Tekrar Deneyiniz", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Duvar Ekle Butonu Tıklanırsa Ekranı parçalıyor
        private void addWalls_Click(object sender, EventArgs e)
        {
            makeSquare();

            foreach (Control c in this.tableDraggingPanel.Controls)
                c.MouseMove += new MouseEventHandler(screenGrapher);
        }
        
        // Basilan Kareyi Boyuyor
        private void tableDraggingPanel_MouseClick(object sender, MouseEventArgs e)
        {
            Graphics g = tableDraggingPanel.CreateGraphics();
            for (int i = 0; i < squares.GetLength(0); i++)
            {
                for (int j = 0; j < squares.GetLength(1); j++)
                {
                    if (squares[i, j].X + salonBoyutx + 1 > e.Location.X && squares[i, j].X < e.Location.X && squares[i, j].Y + salonBoyuty > e.Location.Y && squares[i, j].Y < e.Location.Y)
                    {
                        g.FillRectangle(Brushes.Aqua, squares[i, j].X, squares[i, j].Y, salonBoyutx, salonBoyuty);
                        walls += i.ToString() + "-" + j.ToString() + " ";
                    }
                }
            }
        }
    }
}
