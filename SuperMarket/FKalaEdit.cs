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
    public partial class FKalaEdit : Form
    {
        //-- تشخیص درستی کد کالا --
        Boolean checkCode = false;
        //create a connection to our interested DB:
        SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=SuperMarket;Integrated Security=True;Encrypt=False");

        public FKalaEdit()
        {
            InitializeComponent();
        }

        private void btnEditKala_Click(object sender, EventArgs e)
        {
            //--
            if (checkCode == false)
            {
                textBox1.Focus();
                MessageBox.Show("چنین کد کالا در سیستم ثبت نشده است.", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (textBox1.Text == "")
                textBox1.Focus();
            else if (textBox2.Text == "")
                textBox2.Focus();
            else if (textBox3.Text == "")
                textBox3.Focus();
            else if (textBox4.Text == "")
                textBox4.Focus();

            else
            {
                try
                {
                    // استفاده از using برای اتصال و دستور
                    using (SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=SuperMarket;Integrated Security=True;Encrypt=False"))
                    {
                        conn.Open();

                        if (checkCode == true)
                        {
                            // آپدیت کالا 
                            SqlCommand updateCmd = new SqlCommand("UPDATE TKala SET kname = @kname, price = @price, mojodi = @mojodi WHERE  (kkey = @kkey) ", conn);
                            updateCmd.Parameters.AddWithValue("@kkey", Convert.ToInt64(textBox1.Text));
                            updateCmd.Parameters.AddWithValue("@kname", textBox2.Text);
                            updateCmd.Parameters.AddWithValue("@price", Convert.ToInt64(textBox3.Text));
                            updateCmd.Parameters.AddWithValue("@mojodi", Convert.ToInt32(textBox4.Text));
                            updateCmd.ExecuteNonQuery();

                            //یازی به
                            //conn.Close();
                            //نداری، چون از
                            //using
                            //استفاده کردی.

                            //textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
                            //textBox1.Focus();
                            MessageBox.Show("کالای جدید با موفقیت بروزرسانی شد", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //checkCode = false;
                            FKalaEdit_Load(sender, e);

                        }
                        else
                        {
                            MessageBox.Show("چنین کد کالایی در سیستم ثبت نشده است.", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"خطا: {ex.Message}", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void FKalaEdit_Load(object sender, EventArgs e)
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
            textBox1.Focus();

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out int code))
            {
                textBox2.Text = textBox3.Text = textBox4.Text = "";
                return;
            }
            try
            {
                // استفاده از using برای اتصال و دستور
                using (SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=SuperMarket;Integrated Security=True;Encrypt=False"))
                {
                    conn.Open();

                    // چک کردن وجود کالا در پایگاه داده و سپس انتخاب
                    //SELECT  where
                    SqlDataAdapter da = new SqlDataAdapter("SELECT kname, price, mojodi FROM TKala WHERE kkey = @code", conn);
                    da.SelectCommand.Parameters.AddWithValue("@code", code);
                    //SqlDataAdapter da = new SqlDataAdapter("SELECT    name, address, tell FROM  TMoshtari  where mkey='"+ Convert.ToInt32(textBox1.Text) +"'", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    //کد کالا وجود دارد
                    if (dt.Rows.Count > 0)
                    {
                        textBox2.Text = dt.Rows[0].ItemArray[0].ToString(); // kname
                        textBox3.Text = dt.Rows[0].ItemArray[1].ToString(); // price
                        textBox4.Text = dt.Rows[0].ItemArray[2].ToString(); // mojodi

                        checkCode = true;
                    }
                    else
                    {
                        textBox2.Text = textBox3.Text = textBox4.Text = "";
                        checkCode = false;
                    }


                    //FMoshtariEdit_Load(sender, e);
                }

            }
            catch (Exception ex)
            {
                //کد کالا اشتباهه وجود نداره
                textBox2.Text = textBox3.Text = textBox4.Text = "";
                checkCode = false;
            }

        }

        private void btnDeleteKala_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                textBox1.Focus();
            else if (checkCode == false)
            {
                textBox1.Focus();
                MessageBox.Show("چنین کد کالایی در سیستم ثبت نشده است.", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                //DELET FROM TMoshtari

                if (!int.TryParse(textBox1.Text, out int code))
                {
                    textBox2.Text = textBox3.Text = textBox4.Text = "";
                    return;
                }
                try
                {
                    // استفاده از using برای اتصال و دستور
                    using (SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=SuperMarket;Integrated Security=True;Encrypt=False"))
                    {
                        conn.Open();

                        //delete
                        SqlCommand com = new SqlCommand("DELETE FROM TKala WHERE  (kkey = @kkey)", conn);
                        com.Parameters.AddWithValue("@kkey", Convert.ToInt64(textBox1.Text));
                        com.ExecuteNonQuery();

                        //after delete:

                        //textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
                        //textBox1.Focus();
                        MessageBox.Show("اطلاعات کالای مورد نظر حذف شد", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        FKalaEdit_Load(sender, e);

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"خطا: {ex.Message}", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
    }
}
