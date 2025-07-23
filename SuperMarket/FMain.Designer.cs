using System.Drawing;
using System.Windows.Forms;

namespace SuperMarket
{
    partial class FMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.اطلاعاتکاربرانToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.افزودنکاربرجدیدToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.اطلاعاتمشتریانToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.افزودنمشتریجدیدToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.ویرایشاطلاعاتمشتریانToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.اطلاعاتکالاToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.افزودنکالایجدیدToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.ویرایشحذفاطلاعاتکالاهاToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.اطلاعاتکاربرانToolStripMenuItem,
            this.اطلاعاتمشتریانToolStripMenuItem,
            this.اطلاعاتکالاToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(686, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // اطلاعاتکاربرانToolStripMenuItem
            // 
            this.اطلاعاتکاربرانToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.افزودنکاربرجدیدToolStripMenuItem});
            this.اطلاعاتکاربرانToolStripMenuItem.Name = "اطلاعاتکاربرانToolStripMenuItem";
            this.اطلاعاتکاربرانToolStripMenuItem.Size = new System.Drawing.Size(122, 24);
            this.اطلاعاتکاربرانToolStripMenuItem.Text = "اطلاعات کاربران";
            // 
            // افزودنکاربرجدیدToolStripMenuItem
            // 
            this.افزودنکاربرجدیدToolStripMenuItem.Name = "افزودنکاربرجدیدToolStripMenuItem";
            this.افزودنکاربرجدیدToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.افزودنکاربرجدیدToolStripMenuItem.Text = "افزودن کاربر جدید";
            this.افزودنکاربرجدیدToolStripMenuItem.Click += new System.EventHandler(this.افزودنکاربرجدیدToolStripMenuItem_Click);
            // 
            // اطلاعاتمشتریانToolStripMenuItem
            // 
            this.اطلاعاتمشتریانToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.افزودنمشتریجدیدToolStripMenuItem,
            this.toolStripMenuItem1,
            this.ویرایشاطلاعاتمشتریانToolStripMenuItem});
            this.اطلاعاتمشتریانToolStripMenuItem.Name = "اطلاعاتمشتریانToolStripMenuItem";
            this.اطلاعاتمشتریانToolStripMenuItem.Size = new System.Drawing.Size(133, 24);
            this.اطلاعاتمشتریانToolStripMenuItem.Text = "اطلاعات مشتریان";
            // 
            // افزودنمشتریجدیدToolStripMenuItem
            // 
            this.افزودنمشتریجدیدToolStripMenuItem.Name = "افزودنمشتریجدیدToolStripMenuItem";
            this.افزودنمشتریجدیدToolStripMenuItem.Size = new System.Drawing.Size(298, 26);
            this.افزودنمشتریجدیدToolStripMenuItem.Text = "افزودن مشتری جدید";
            this.افزودنمشتریجدیدToolStripMenuItem.Click += new System.EventHandler(this.افزودنمشتریجدیدToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(295, 6);
            // 
            // ویرایشاطلاعاتمشتریانToolStripMenuItem
            // 
            this.ویرایشاطلاعاتمشتریانToolStripMenuItem.Name = "ویرایشاطلاعاتمشتریانToolStripMenuItem";
            this.ویرایشاطلاعاتمشتریانToolStripMenuItem.Size = new System.Drawing.Size(298, 26);
            this.ویرایشاطلاعاتمشتریانToolStripMenuItem.Text = "ویرایش / حذف اطلاعات مشتریان";
            this.ویرایشاطلاعاتمشتریانToolStripMenuItem.Click += new System.EventHandler(this.ویرایشاطلاعاتمشتریانToolStripMenuItem_Click);
            // 
            // اطلاعاتکالاToolStripMenuItem
            // 
            this.اطلاعاتکالاToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.افزودنکالایجدیدToolStripMenuItem,
            this.toolStripMenuItem2,
            this.ویرایشحذفاطلاعاتکالاهاToolStripMenuItem});
            this.اطلاعاتکالاToolStripMenuItem.Name = "اطلاعاتکالاToolStripMenuItem";
            this.اطلاعاتکالاToolStripMenuItem.Size = new System.Drawing.Size(101, 24);
            this.اطلاعاتکالاToolStripMenuItem.Text = "اطلاعات کالا";
            // 
            // افزودنکالایجدیدToolStripMenuItem
            // 
            this.افزودنکالایجدیدToolStripMenuItem.Name = "افزودنکالایجدیدToolStripMenuItem";
            this.افزودنکالایجدیدToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.افزودنکالایجدیدToolStripMenuItem.Text = "افزودن کالای جدید";
            this.افزودنکالایجدیدToolStripMenuItem.Click += new System.EventHandler(this.افزودنکالایجدیدToolStripMenuItem_Click_1);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(221, 6);
            // 
            // ویرایشحذفاطلاعاتکالاهاToolStripMenuItem
            // 
            this.ویرایشحذفاطلاعاتکالاهاToolStripMenuItem.Name = "ویرایشحذفاطلاعاتکالاهاToolStripMenuItem";
            this.ویرایشحذفاطلاعاتکالاهاToolStripMenuItem.Size = new System.Drawing.Size(280, 26);
            this.ویرایشحذفاطلاعاتکالاهاToolStripMenuItem.Text = "ویرایش / حذف اطلاعات کالاها";
            this.ویرایشحذفاطلاعاتکالاهاToolStripMenuItem.Click += new System.EventHandler(this.ویرایشحذفاطلاعاتکالاهاToolStripMenuItem_Click);
            // 
            // FMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 390);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FMain";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "فرم اصلی - سیستم مدیریت فروشگاه";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem اطلاعاتکاربرانToolStripMenuItem;
        private ToolStripMenuItem افزودنکاربرجدیدToolStripMenuItem;
        private ToolStripMenuItem اطلاعاتمشتریانToolStripMenuItem;
        private ToolStripMenuItem افزودنمشتریجدیدToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem ویرایشاطلاعاتمشتریانToolStripMenuItem;
        private ToolStripMenuItem اطلاعاتکالاToolStripMenuItem;
        private ToolStripMenuItem افزودنکالایجدیدToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripMenuItem ویرایشحذفاطلاعاتکالاهاToolStripMenuItem;
    }
}
