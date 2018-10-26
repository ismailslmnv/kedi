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
        public Tables()
        {
            InitializeComponent();
        }
        private void metroTile1_Click(object sender, EventArgs e)
        {

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
    }
}
