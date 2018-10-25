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

namespace KEDI_v_0._5._0._1
{
    public partial class YonetimPaneli : MetroForm
    {
        private int selectedMenu = -1;// Hicbir menu secili degil
        public YonetimPaneli()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void menu_Click(object sender, EventArgs e)
        {
            selectedMenu = 0;// Menu/Urun Secildi..
            subMenuPanelTextChanger();
        }
        private void subMenuPanelTextChanger()
        {
            switch (selectedMenu)
            {
                case 0:
                    {
                        subMenu0.Text = "Menü Ekle";
                        subMenu1.Text = "Ürün Ekle";
                        subMenu2.Text = "Menüleri Sırala";
                        subMenu3.Text = "Ürünleri Sırala";
                        break;
                    }
                case 1:
                    {
                        subMenu0.Text = "Salon Ekle";
                        subMenu1.Text = "Masa Ekle";
                        subMenu2.Text = "Salonları Sırala";
                        subMenu3.Text = "Masaları Sırala";
                        break;
                    }
                case 2:
                    {
                        subMenu0.Text = "Yetki Ekle";
                        subMenu1.Text = "Kullanıcı Ekle";
                        subMenu2.Text = "Yetkileri Sırala";
                        subMenu3.Text = "Kullanıcıları Sırala";
                        break;
                    }
                case 3:
                    {
                        //subMenu0.Text = "Yetki Ekle";
                        //subMenu1.Text = "Kullanıcı Ekle";
                        //subMenu2.Text = "Yetkileri Sırala";
                        //subMenu3.Text = "Kullanıcıları Sırala";    
                        MetroMessageBox.Show(this, "Bu Özellik Henüz Kullanımdışıdır.","Uyarı");
                        break;
                    }
            }
            submenuPanel.Visible = true;
        }
        private void salon_Click(object sender, EventArgs e)
        {
            selectedMenu = 1; // Salon/Masa Secildi..
            subMenuPanelTextChanger();
        }

        private void user_Click(object sender, EventArgs e)
        {
            selectedMenu = 2;// Yetki/Kullanici secildi..
            subMenuPanelTextChanger();
        }

        private void raport_Click(object sender, EventArgs e)
        {
            selectedMenu = 3;
            subMenuPanelTextChanger();
            submenuPanel.Visible = false;
        }

        private void YonetimPaneli_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!sender.ToString().Equals("geri besleme"))
            {
                DialogResult res = MetroMessageBox.Show(this, "Çıkış Yapmak İstediğinizden Emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    YonetimPaneli_FormClosing("geri besleme", e);
                }
                else
                {
                    e.Cancel=true;
                }
            }
        }

        private void subMenu0_Click(object sender, EventArgs e)
        {
            Enterance enterance = new Enterance();
            enterance.Show();
            
        }
    }
}
