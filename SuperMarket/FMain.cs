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
            if (Memory.usertypeMem == 1) //فقط مدیر میتونه اد کنه
            {
                FUser fUser = new FUser();
                fUser.ShowDialog();
            }
            else if (Memory.usertypeMem == 0) //کاربر عادی نمی تونه کاربر اد بزنه
            {
                MessageBox.Show("فقط مدیر می تواند به این بخش دسترسی داشته باشد");
            }


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


        private void افزودنکالایجدیدToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FKala fKala = new FKala();
            fKala.ShowDialog();
        }

        private void ویرایشحذفاطلاعاتکالاهاToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FKalaEdit fKalaEdit = new FKalaEdit();
            fKalaEdit.ShowDialog();
        }

        private void فاکتورToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FFaktor fFaktor = new FFaktor();
            fFaktor.ShowDialog();
        }

        private void FMain_Load(object sender, EventArgs e)
        {
            //یعنی اگه کسی لاگین نکرده  اما من راه حل بهتر ارائه دادم و توی پروگرم سی مستقیم هندلش کردم
            if (Memory.usernameMem == "")
            {
                FLogin fLogin = new FLogin();
                fLogin.ShowDialog();
            }
            if (Memory.usertypeMem == 0)//کاربر عادی تب گزارسات براش غیر فعال شه 
            {
                menuReport.Enabled = false;
            }
            else
            {
                menuReport.Enabled = true;
            }


        }

        private void menuReport_Click(object sender, EventArgs e)
        {
           
        }

        private void جستوجویاطلاعاتمشتریانToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FMoshtariSearch fMoshtariSearch = new FMoshtariSearch();
            fMoshtariSearch.ShowDialog();
        }
    }
}
