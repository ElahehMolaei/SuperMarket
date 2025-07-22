using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace SuperMarket
{
    public partial class FMain : Form
    {
        public FMain()
        {
            InitializeComponent();
        }

        private void افزودنکاربرجدیدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FUser fUser = new FUser();
            fUser.ShowDialog();

        }

        private void افزودنمشتریجدیدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FMoshtari fMoshtari = new FMoshtari();
            fMoshtari.ShowDialog();
        }

        private void ویرایشاطلاعاتمشتریانToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FMoshtariEdit fMoshtariEdit = new FMoshtariEdit();
            fMoshtariEdit.ShowDialog();
        }
    }
}
