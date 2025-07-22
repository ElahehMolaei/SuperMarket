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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace WindowsFormsApp1
{

    public partial class FMoshtari : Form
    {
        //create a connection to our interested DB:
        SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=SuperMarket;Integrated Security=True;Encrypt=False");
        public FMoshtari()
        {
            InitializeComponent();
        }
        //another personal functions that I wanna write by myself!
        public void newCustomerCode()
        {
            try
            {
                //SELECT
                SqlDataAdapter da = new SqlDataAdapter("SELECT   MAX(mkey)  FROM  TMoshtari", conn);
                DataTable dt = new DataTable(); //a virtual table
                da.Fill(dt);
                textBox1.Text = (Convert.ToInt32(dt.Rows[0].ItemArray[0]) + 1).ToString();//radif 0 soton 0

            }
            //برای اینه که اگه جدول دیتابیسم خالی بود خطا نده و کد مشتری رو از 1000 در نظر بگیره
            catch
            {
                textBox1.Text = "1000";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                textBox1.Focus();
            else if (textBox2.Text == "")
                textBox2.Focus();
            else if(textBox3.Text =="")
                textBox3.Focus();
            else if(textBox4.Text =="")
                textBox4.Focus();
            else
            {
                try
                {
                    // استفاده از using برای اتصال و دستور
                    using (SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=SuperMarket;Integrated Security=True;Encrypt=False"))
                    {
                        conn.Open();

                        // چک کردن تکراری نبودن مشتری
                        SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM TMoshtari WHERE mkey = @mkey", conn);
                        checkCmd.Parameters.AddWithValue("@mkey", textBox1.Text);
                        int moshtariCount = (int)checkCmd.ExecuteScalar();

                        if (moshtariCount > 0)
                        {
                            MessageBox.Show("قبلا این کد مشتری ثبت شده است.", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return; // خروج از متد اگر کاربر تکراری باشد
                        }

                        // درج مشتری جدید
                        SqlCommand insertCmd = new SqlCommand("INSERT INTO TMoshtari  (mkey, name, address, phone) VALUES   (@mkey,@name,@address,@phone)", conn);
                        insertCmd.Parameters.AddWithValue("@mkey", Convert.ToInt32(textBox1.Text));
                        insertCmd.Parameters.AddWithValue("@name", textBox2.Text);
                        insertCmd.Parameters.AddWithValue("@address", textBox3.Text);
                        insertCmd.Parameters.AddWithValue("@phone", Convert.ToInt64(textBox4.Text));
                        insertCmd.ExecuteNonQuery();

                        textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text =  "";
                        textBox2.Focus();
                        MessageBox.Show("مشتری جدید با موفقیت اضافه شد", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FMoshtari_Load(sender, e);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"خطا: {ex.Message}", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FMoshtari_Load(object sender, EventArgs e)
        {
            newCustomerCode();
            //SELECT
            SqlDataAdapter da = new SqlDataAdapter("SELECT   mkey AS [کد مشتری], name AS [نام], address AS [آدرس], phone AS [تلفن] FROM  TMoshtari", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }
    }
}
