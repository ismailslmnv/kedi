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
using MetroFramework.Forms;

namespace KEDI_v_0._5._0._1
{
    public partial class select : MetroForm
    {
        public static int UrunID;
        public select()
        {
            InitializeComponent();
        }

        private void select_Load(object sender, EventArgs e)
        {

        }

        private void urunEdit_Click(object sender, EventArgs e)
        {
            EditProduct.UrunID = UrunID;
            EditProduct edit = new EditProduct();        
            edit.Show();
            this.Close();
        }

        private void ozellikEkle_Click(object sender, EventArgs e)
        {
            AddProperty add = new AddProperty();
            add.Show();
            this.Close();
        }
    }
}
