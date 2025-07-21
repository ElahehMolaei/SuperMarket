using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SuperMarket
{
    public partial class FUser : Form
    {
        //create a connection to our interested DB:
        SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=SuperMarket;Integrated Security=True;Encrypt=False");
        public FUser()
        {
            InitializeComponent();
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    if(textBox1.Text=="")
        //        textBox1.Focus();
        //    else if(textBox2.Text=="")
        //        textBox2.Focus();
        //    else
        //    {
        //        //sabte etelatae karbari

        //        ////create a connection to our interested DB:
        //        //SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=SuperMarket;Integrated Security=True;Encrypt=False");

        //        // 1.chek tekrari nabudan username ya 2. try catch 

        //        try
        //        {
        //            conn.Open();

        //            //INSERT INTO table
        //            SqlCommand com = new SqlCommand("INSERT INTO TUser (username, pass, userType) VALUES (@username,@pass,@userType)", conn);
        //            com.Parameters.AddWithValue("@username", textBox1.Text);
        //            com.Parameters.AddWithValue("@pass", textBox2.Text);
        //            com.Parameters.AddWithValue("@userType", radioButton1.Checked ? 0 : 1);
        //            com.ExecuteNonQuery();
        //            conn.Close();

        //            //after adding a new user , the texboxes should be empty for adding another user
        //            textBox1.Text = textBox2.Text = "";
        //            radioButton1.Checked = true;
        //            textBox1.Focus();
        //            MessageBox.Show("کاربر جدید با موفقیت اضافه شد", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            FUser_Load(sender, e);
        //        }
        //        catch (Exception ex) 
        //        {
        //            MessageBox.Show("قبلا این نام کاربری ثبت شده است.", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //        }

        //    }
        //}
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                textBox1.Focus();
            else if (textBox2.Text == "")
                textBox2.Focus();
            else
            {
                try
                {
                    // استفاده از using برای اتصال و دستور
                    using (SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=SuperMarket;Integrated Security=True;Encrypt=False"))
                    {
                        conn.Open();

                        // چک کردن تکراری نبودن کاربر
                        SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM TUser WHERE username = @username", conn);
                        checkCmd.Parameters.AddWithValue("@username", textBox1.Text);
                        int userCount = (int)checkCmd.ExecuteScalar();

                        if (userCount > 0)
                        {
                            MessageBox.Show("قبلا این نام کاربری ثبت شده است.", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return; // خروج از متد اگر کاربر تکراری باشد
                        }

                        // درج کاربر جدید
                        SqlCommand insertCmd = new SqlCommand("INSERT INTO TUser (username, pass, userType) VALUES (@username, @pass, @userType)", conn);
                        insertCmd.Parameters.AddWithValue("@username", textBox1.Text);
                        insertCmd.Parameters.AddWithValue("@pass", textBox2.Text);
                        insertCmd.Parameters.AddWithValue("@userType", radioButton1.Checked ? 0 : 1);
                        insertCmd.ExecuteNonQuery();

                        textBox1.Text = textBox2.Text = "";
                        radioButton1.Checked = true;
                        textBox1.Focus();
                        MessageBox.Show("کاربر جدید با موفقیت اضافه شد", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FUser_Load(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"خطا: {ex.Message}", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        // dastoorati ke mikhahim hamzaman ba load safhe ejra beshan 
        private void FUser_Load(object sender, EventArgs e)
        {
            //SELECT
            SqlDataAdapter da = new SqlDataAdapter("SELECT   username AS [نام کاربری], pass AS [رمز عبور], userType AS [سطح دسترسی]\r\nFROM         TUser", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
