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

namespace WindowsFormsApp1
{
    public partial class FKala : Form
    {
        //create a connection to our interested DB:
        SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=SuperMarket;Integrated Security=True;Encrypt=False");
        Boolean checkcode;
        public FKala()
        {
            InitializeComponent();
        }

        private void FKala_Load(object sender, EventArgs e)
        {
            newKalaCode(); //هرسری که فرم لود شد کد اشتراک برای ثبت مشتی جدید نمایش داده شه 
            //SELECT
            SqlDataAdapter da = new SqlDataAdapter("SELECT   kkey AS [کد کالا], kname AS [ نام کالا], price AS [قیمت کالا], mojodi AS [موجودی کالا] FROM  TKala Order by kkey DESC", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;



            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 100;

        }
        public void newKalaCode()
        {
            try
            {
                //SELECT
                SqlDataAdapter da = new SqlDataAdapter("SELECT   MAX(kkey)  FROM  TKala", conn);
                DataTable dt = new DataTable(); //a virtual table
                da.Fill(dt);
                textBox1.Text = (Convert.ToInt64(dt.Rows[0].ItemArray[0]) + 1).ToString();//radif 0 soton 0

            }
            //برای اینه که اگه جدول دیتابیسم خالی بود خطا نده و کد مشتری رو از 1000 در نظر بگیره
            catch
            {
                textBox1.Text = "100";
            }
        }

        private void btnSaveKala_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                textBox1.Focus();
            //چک تکراری بودن کد کالا 
            //2 تا ره دیگه هم توی ترای هست که کامنت شده
            else if(checkcode)
            {
                MessageBox.Show("قبلا این کد کالا ثبت شده است.", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Focus();
            }
            else if (textBox2.Text == "")
                textBox2.Focus();
            else if (textBox3.Text == "")
                textBox3.Focus();
            else if (textBox4.Text == "")
                textBox4.Focus();
            //sabte kala
            else
            {
                try
                {
                    // پارس کردن مقدارها به‌صورت جداگانه با بررسی خطا
                    long kkey;
                    if (!long.TryParse(textBox1.Text, out kkey))
                    {
                        MessageBox.Show("کد کالا باید عدد صحیح باشد.", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBox1.Focus();
                        return;
                    }

                    long price;
                    if (!long.TryParse(textBox3.Text, out price))
                    {
                        MessageBox.Show("قیمت باید عدد صحیح باشد.", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBox3.Focus();
                        return;
                    }

                    int mojodi;
                    if (!int.TryParse(textBox4.Text, out mojodi))
                    {
                        MessageBox.Show("موجودی  باید عدد صحیح باشد.", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBox4.Focus();
                        return;
                    }
                    // استفاده از using برای اتصال و دستور
                    using (SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=SuperMarket;Integrated Security=True;Encrypt=False"))
                    {
                        conn.Open();

                        // چک کردن تکراری نبودن کالا یک راهشم پایینتر توی تکست چنج هست برای تکست باکس 1
                        //SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM TKala WHERE kkey = @kkey", conn);
                        //checkCmd.Parameters.AddWithValue("@kkey", textBox1.Text);
                        //int kalaCount = (int)checkCmd.ExecuteScalar();

                        //if (kalaCount > 0)
                        //{
                        //    MessageBox.Show("قبلا این کد کالا ثبت شده است.", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //    return; // خروج از متد اگر کالا تکراری باشد
                        //}

                        //روش 2 چک تکراری بودن کد کالا 
                        //if (checkcode)
                        //{
                        //    MessageBox.Show("قبلا این کد کالا ثبت شده است.", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //    return; // خروج از متد اگر کالا تکراری باشد
                        //}

                        // درج کالای جدید
                        SqlCommand insertCmd = new SqlCommand("INSERT INTO TKala (kkey, kname, price, mojodi) VALUES (@kkey,@kname,@price,@mojodi)", conn);
                        insertCmd.Parameters.AddWithValue("@kkey", Convert.ToInt64(textBox1.Text));
                        insertCmd.Parameters.AddWithValue("@kname", textBox2.Text);
                        insertCmd.Parameters.AddWithValue("@price", Convert.ToInt64(textBox3.Text));
                        insertCmd.Parameters.AddWithValue("@mojodi", Convert.ToInt32(textBox4.Text));
                        insertCmd.ExecuteNonQuery();


                        //بعد از درج کالای جدید
                        textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
                        textBox2.Focus();
                        MessageBox.Show("کالای جدید با موفقیت اضافه شد", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FKala_Load(sender, e);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"خطا: {ex.Message}", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=SuperMarket;Integrated Security=True;Encrypt=False"))
                {
                    conn.Open();
                    using (SqlCommand com = new SqlCommand("SELECT * FROM TKala WHERE kkey = @kkey", conn))
                    {
                        com.Parameters.AddWithValue("@kkey", Convert.ToInt64(textBox1.Text));
                        checkcode = com.ExecuteReader().HasRows;
                    }
                }
            }
            catch(Exception ex)
            {
                //MessageBox.Show($"خطا: {ex.Message}", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
