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

    public partial class FMoshtariEdit : Form
    {
        //-- تشخیص درستی کد اشتراک --
        Boolean checkCode = false;
        //create a connection to our interested DB:
        SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=SuperMarket;Integrated Security=True;Encrypt=False");
        public FMoshtariEdit()
        {
            InitializeComponent();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //--
            if (checkCode==false)
            {
                textBox1.Focus();
                MessageBox.Show("چنین کد مشتری در سیستم ثبت نشده است.", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

                        //// چک وجود داشتن مشتری
                        //SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM TMoshtari WHERE mkey = @mkey", conn);
                        //checkCmd.Parameters.AddWithValue("@mkey", textBox1.Text);
                        //int moshtariCount = (int)checkCmd.ExecuteScalar();

                        if (checkCode == true)
                        {
                            //MessageBox.Show("قبلا این کد مشتری ثبت شده است.", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // آپدیت مشتری 
                            SqlCommand updateCmd = new SqlCommand("UPDATE TMoshtari SET name = @name, address = @address, phone = @phone WHERE  (mkey = @mkey) ", conn);
                            updateCmd.Parameters.AddWithValue("@mkey", Convert.ToInt32(textBox1.Text));
                            updateCmd.Parameters.AddWithValue("@name", textBox2.Text);
                            updateCmd.Parameters.AddWithValue("@address", textBox3.Text);
                            updateCmd.Parameters.AddWithValue("@phone", Convert.ToInt64(textBox4.Text));
                            updateCmd.ExecuteNonQuery();

                            //یازی به
                            //conn.Close();
                            //نداری، چون از
                            //using
                            //استفاده کردی.

                            //textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
                            //textBox1.Focus();
                            MessageBox.Show("مشتری جدید با موفقیت بروزرسانی شد", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //checkCode = false;
                            FMoshtariEdit_Load(sender, e);

                        }
                        else
                        {
                            MessageBox.Show("چنین کد مشتری در سیستم ثبت نشده است.", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }

                        //FMoshtari_Load(sender, e);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"خطا: {ex.Message}", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void FMoshtariEdit_Load(object sender, EventArgs e)
        {
            //try
            //  {
            //      conn.Open();
            //      MessageBox.Show("اتصال برقرار شد");
            //      conn.Close();
            //  }
            //catch (Exception ex)
            //  {
            //      MessageBox.Show("خطای اتصال: " + ex.Message);
            //  }

            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
            textBox1.Focus();
            //SELECT
            SqlDataAdapter da = new SqlDataAdapter("SELECT   mkey AS [کد مشتری], name AS [نام], address AS [آدرس], phone AS [تلفن] FROM  TMoshtari Order by mkey DESC", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;


            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 250;
            dataGridView1.Columns[3].Width = 100;

        }


        //ba vared kardane code eshterak sayere etelate moshtari ba oon code ro neshun bede ke edit rahat bahse
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

                    // چک کردن وجود مشتری در پایگاه داده و سپس انتخاب
                    //SELECT  where
                    SqlDataAdapter da = new SqlDataAdapter("SELECT name, address, phone FROM TMoshtari WHERE mkey = @code", conn);
                    da.SelectCommand.Parameters.AddWithValue("@code", code);
                    //SqlDataAdapter da = new SqlDataAdapter("SELECT    name, address, tell FROM  TMoshtari  where mkey='"+ Convert.ToInt32(textBox1.Text) +"'", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    //کد اشتراک وجود دارد
                    if (dt.Rows.Count > 0)
                    {
                        textBox2.Text = dt.Rows[0].ItemArray[0].ToString(); // name
                        textBox3.Text = dt.Rows[0].ItemArray[1].ToString(); // address
                        textBox4.Text = dt.Rows[0].ItemArray[2].ToString(); // phone

                        checkCode=true;
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
                //کد اشتراک اشتباهه وجود نداره
                textBox2.Text = textBox3.Text = textBox4.Text = "";
                checkCode = false;
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
                textBox1.Focus();
            else if (checkCode == false)
            {
                textBox1.Focus();
                MessageBox.Show("چنین کد مشتری در سیستم ثبت نشده است.", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                        SqlCommand com = new SqlCommand("DELETE FROM TMoshtari WHERE  (mkey = @mkey)", conn);
                        com.Parameters.AddWithValue("@mkey", Convert.ToInt32(textBox1.Text));
                        com.ExecuteNonQuery();

                        //after delete:

                        //textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
                        //textBox1.Focus();
                        MessageBox.Show("اطلاعات مشتری مورد نظر حذف شد", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        FMoshtariEdit_Load(sender, e);

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
