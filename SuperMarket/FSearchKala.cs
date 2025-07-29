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
    public partial class FSearchKala : Form
    {
        //create a connection to our interested DB:
        SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=SuperMarket;Integrated Security=True;Encrypt=False");

        public FSearchKala()
        {
            InitializeComponent();
        }

        private void FSearchKala_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=SuperMarket;Integrated Security=True;Encrypt=False"))
            {
                conn.Open();
                //SELECT
                SqlDataAdapter da = new SqlDataAdapter("SELECT   kkey AS [کد کالا], kname AS [نام کالا], price AS قیمت, mojodi AS موجودی FROM   TKala Order by kkey DESC", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;


            }

            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 100;


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=SuperMarket;Integrated Security=True;Encrypt=False"))
                {
                    conn.Open();
                    //SELECT
                    SqlDataAdapter da = new SqlDataAdapter("SELECT   kkey AS [کد کالا], kname AS [نام کالا], price AS قیمت, mojodi AS موجودی FROM  TKala WHERE kkey LIKE @kkey + '%' Order by kkey DESC", conn); //ASC baraye صعودی
                    da.SelectCommand.Parameters.AddWithValue("@kkey", textBox1.Text); //چون بالا از لایک استفاده کردی و یه بعلاوه درصد گذاشتی دیگه اینجا نباید به اینت 64 کانورتش کنی

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;


                }
                dataGridView1.Columns[0].Width = 100;
                dataGridView1.Columns[1].Width = 200;
                dataGridView1.Columns[2].Width = 100;
                dataGridView1.Columns[3].Width = 100;



            }

            catch (Exception ex)
            {
                MessageBox.Show($"خطا: {ex.Message}", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=SuperMarket;Integrated Security=True;Encrypt=False"))
                {
                    conn.Open();
                    //SELECT
                    //دوتا درصد اول و اخر نام برای اینه که مثلا علی سرچ کردیم علی هرجای اسم بود بیاره معلی محمد یا امیرعلی یا محمدعلی
                    SqlDataAdapter da = new SqlDataAdapter("SELECT   kkey AS [کد کالا], kname AS [نام کالا], price AS قیمت, mojodi AS موجودی FROM  TKala WHERE kname LIKE N'%' + @kname + '%' Order by kname ASC", conn); //ASC baraye صعودی    LIKE N چون عبارت فارسی داریم عدد نیست   
                    //SqlDataAdapter da = new SqlDataAdapter("SELECT   mkey AS [کد مشتری], name AS [نام مشتری], phone AS [تلفن] ,  address AS [آدرس] FROM   TMoshtari WHERE name LIKE N @name + '%' Order by name ASC", conn); //ASC baraye صعودی    LIKE N چون عبارت فارسی داریم عدد نیست   

                    da.SelectCommand.Parameters.AddWithValue("@kname", textBox2.Text.ToString());

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;


                }

                dataGridView1.Columns[0].Width = 100;
                dataGridView1.Columns[1].Width = 200;
                dataGridView1.Columns[2].Width = 100;
                dataGridView1.Columns[3].Width = 100;



            }

            catch (Exception ex)
            {
                MessageBox.Show($"خطا: {ex.Message}", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
}
