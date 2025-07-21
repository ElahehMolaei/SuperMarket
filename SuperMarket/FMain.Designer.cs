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
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.اطلاعاتکاربرانToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(686, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // اطلاعاتکاربرانToolStripMenuItem
            // 
            this.اطلاعاتکاربرانToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.افزودنکاربرجدیدToolStripMenuItem});
            this.اطلاعاتکاربرانToolStripMenuItem.Name = "اطلاعاتکاربرانToolStripMenuItem";
            this.اطلاعاتکاربرانToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.اطلاعاتکاربرانToolStripMenuItem.Text = "اطلاعات کاربران";
            // 
            // افزودنکاربرجدیدToolStripMenuItem
            // 
            this.افزودنکاربرجدیدToolStripMenuItem.Name = "افزودنکاربرجدیدToolStripMenuItem";
            this.افزودنکاربرجدیدToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.افزودنکاربرجدیدToolStripMenuItem.Text = "افزودن کاربر جدید";
            this.افزودنکاربرجدیدToolStripMenuItem.Click += new System.EventHandler(this.افزودنکاربرجدیدToolStripMenuItem_Click);
            // 
            // FMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
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
    }
}
