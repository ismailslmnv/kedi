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
namespace KEDI_v_0._5._0._1
{
    public partial class Tables : MetroForm
    {
        List<Salonlar> salonlar = new List<Salonlar>();
        public Tables()
        {
            InitializeComponent();
            username.Text = Enterance.usernameText;
            //Default Olarak Salon Kismi Acilir ilk olarak
            add.Text = "Salon Ekle";
        }

        //Kullanicidan istendigi zaman salonun tum masalarini ekrana oldugu yerde yazdirilacak.
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
                            TableQuery(5);// burada ekrana yazdirma fonksiyonu cagirilmasi gerekir
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
                //AddMasa addmasa = new AddMasa();
                //addmasa.ShowDialog();
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
            add.Visible = true;
            getSalonFromDB();
        }
        private void getSalonFromDB()
        {
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
                        {
                            listBox1.Items.Clear();//Tekrar Çağırılması Sonucu Verı Tekrarı
                            listBox1.Items.Add(item.SalonAdi);
                        }
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
            add.Visible = true;
            //Db Okuma
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
