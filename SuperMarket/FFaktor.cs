using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace WindowsFormsApp1
{
    public partial class FFaktor : Form
    {
        //-- تشخیص درستی کد اشتراک --
        Boolean checkMCode = false;

        //-- تشخیص درستی کد کالا --
        Boolean checkKCode = false;


        Boolean checkFactor = false; //factor sabt nashode

        //--هنگام ثبت فاکتور برای مشتری باید کد مشتری سیو شه تا برای مشتری دیگه در همون فاکتور نشه ثبت کرد
        int savedMkeyFactor;
        //create a connection to our interested DB:
        SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=SuperMarket;Integrated Security=True;Encrypt=False");

        public FFaktor()
        {
            InitializeComponent();
        }

        //another personal functions that I wanna write by myself!
        public void newFactorCode()
        {
            try
            {
                //SELECT
                SqlDataAdapter da = new SqlDataAdapter("SELECT   MAX(fkey)  FROM  TFactor", conn);
                DataTable dt = new DataTable(); //a virtual table
                da.Fill(dt);
                lblFactorNumber.Text = (Convert.ToInt32(dt.Rows[0].ItemArray[0]) + 1).ToString();//radif 0 soton 0

            }
            //برای اینه که اگه جدول دیتابیسم خالی بود خطا نده و کد فاکتور  رو از 5000 در نظر بگیره
            catch
            {
                lblFactorNumber.Text = "5000";
            }
        }
        


        //ثبت فاکتور
        private void btnSabtFactor_Click(object sender, EventArgs e)
        {
            if (textBoxMkey.Text == "")
            {
                textBoxMkey.Focus();

            }
            else if (checkMCode == false)
            {
                textBoxMkey.Focus();
                MessageBox.Show("چنین کد مشتری در سیستم ثبت نشده است.", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (textBoxKkey.Text == "")
            {
                textBoxKkey.Focus();

            }
            else if (checkKCode == false)
            {
                textBoxKkey.Focus();
                MessageBox.Show("چنین کد کالایی در سیستم ثبت نشده است.", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if(textBoxTedadKala.Text=="")
            {
                textBoxTedadKala.Focus();
                MessageBox.Show("لطفا تعداد را وارد کنید !", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //else
            //{
            //    if (!int.TryParse(textBoxTedadKala.Text, out int code))
            //    {
            //        textBoxTedadKala.Focus();
            //        MessageBox.Show("تعداد باید عددی صحیح باشد", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        return;
            //    }
            //try
            //{
            //    // استفاده از using برای اتصال و دستور
            //    using (SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=SuperMarket;Integrated Security=True;Encrypt=False"))
            //    {
            //        conn.Open();

            //        SqlDataAdapter da = new SqlDataAdapter("SELECT   mojodi FROM   TKala WHERE kkey = @kkey", conn);
            //        da.SelectCommand.Parameters.AddWithValue("@kkey", Convert.ToInt64(textBoxKkey.Text));
            //        DataTable dt = new DataTable();
            //        da.Fill(dt);
            //        if (code > Convert.ToInt32(dt.Rows[0].ItemArray[0]))
            //        {
            //            MessageBox.Show("تعداد وارد شده بیش از اندازه ی موجودی است", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        }


            //    }

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"خطا: {ex.Message}", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //}
            else if (Convert.ToInt32(textBoxTedadKala.Text) > Convert.ToInt32(lablKalamojodi.Text))
            {
                MessageBox.Show("تعداد وارد شده بیش از اندازه ی موجودی است", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {

                try
                {
                    // استفاده از using برای اتصال و دستور
                    using (SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=SuperMarket;Integrated Security=True;Encrypt=False"))
                    {
                        conn.Open();
                        //-- INSERT INTO TFaktor table
                        // ثبت فاکتور فقط در اولین بار
                        if (checkFactor == false)
                        {
                            //-- باید کد مشتری سیو شه که در همین فاکتور فقط برای همین مشتری بشه ثبت کرد
                            savedMkeyFactor = Convert.ToInt32(textBoxMkey.Text);
                            //MessageBox.Show(savedMkeyFactor.ToString());

                            SqlCommand insertCmd = new SqlCommand("INSERT INTO TFactor (fkey, username, mkey, datex, timex) VALUES (@fkey,@username,@mkey,@datex,@timex)", conn);
                            insertCmd.Parameters.AddWithValue("@fkey", Convert.ToInt32(lblFactorNumber.Text));
                            insertCmd.Parameters.AddWithValue("@mkey", Convert.ToInt32(textBoxMkey.Text));
                            insertCmd.Parameters.AddWithValue("@username", "الهه"); //name useri ke login karde o dre factor sabt mikne
                            insertCmd.Parameters.AddWithValue("@datex", labelDate.Text);
                            insertCmd.Parameters.AddWithValue("@timex", DateTime.Now.ToLongTimeString());
                            insertCmd.ExecuteNonQuery();
                            //-- INSERT INTO TAghlam table

                            //conn.Open();

                            SqlCommand insertCmd1 = new SqlCommand("INSERT INTO TAghlam (fkey, kkey, tedad) VALUES  (@fkey,@kkey,@tedad)", conn);
                            insertCmd1.Parameters.AddWithValue("@fkey", Convert.ToInt32(lblFactorNumber.Text));
                            insertCmd1.Parameters.AddWithValue("@kkey", Convert.ToInt64(textBoxKkey.Text));
                            insertCmd1.Parameters.AddWithValue("@tedad", Convert.ToInt64(textBoxTedadKala.Text));

                            insertCmd1.ExecuteNonQuery();

                            // کم کردن موجودی کالا
                            SqlCommand updateMojodiCmd = new SqlCommand("UPDATE TKala SET mojodi = mojodi - @tedad WHERE kkey = @kkey", conn);
                            updateMojodiCmd.Parameters.AddWithValue("@tedad", Convert.ToInt64(textBoxTedadKala.Text));
                            updateMojodiCmd.Parameters.AddWithValue("@kkey", Convert.ToInt64(textBoxKkey.Text));
                            updateMojodiCmd.ExecuteNonQuery();

                            checkFactor = true;

                        }
                        else if (checkFactor == true)
                        {

                            if (Convert.ToInt32(textBoxMkey.Text) == savedMkeyFactor)
                            {
                                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM TAghlam WHERE fkey = @fkey AND kkey = @kkey", conn);
                                cmd.Parameters.AddWithValue("@fkey", Convert.ToInt32(lblFactorNumber.Text));
                                cmd.Parameters.AddWithValue("@kkey", Convert.ToInt64(textBoxKkey.Text));
                                int count = (int)cmd.ExecuteScalar();
                                //update TAghlam
                                if (count > 0)
                                {


                                    //select tedad ghabli 
                                    SqlDataAdapter da = new SqlDataAdapter("SELECT tedad FROM TAghlam WHERE fkey = @fkey AND kkey = @kkey", conn);
                                    da.SelectCommand.Parameters.AddWithValue("@fkey", Convert.ToInt32(lblFactorNumber.Text));
                                    da.SelectCommand.Parameters.AddWithValue("@kkey", Convert.ToInt64(textBoxKkey.Text));
                                    DataTable dt = new DataTable();
                                    da.Fill(dt);

                                    MessageBox.Show(dt.Rows[0].ItemArray[0].ToString()); //prev Tedad

                                    SqlCommand updateCmd = new SqlCommand("UPDATE TAghlam SET    tedad = @tedad WHERE  fkey = @fkey AND kkey = @kkey", conn);
                                    updateCmd.Parameters.AddWithValue("@fkey", Convert.ToInt32(lblFactorNumber.Text));
                                    updateCmd.Parameters.AddWithValue("@kkey", Convert.ToInt64(textBoxKkey.Text));
                                    updateCmd.Parameters.AddWithValue("@tedad", Convert.ToInt64(textBoxTedadKala.Text));
                                    updateCmd.ExecuteNonQuery();

                                    // آپدیت موجودی کالا
                                    SqlCommand updateMojodiCmd = new SqlCommand("UPDATE TKala SET mojodi = mojodi + @tedadeghabli - @tedad WHERE kkey = @kkey", conn);
                                    updateMojodiCmd.Parameters.AddWithValue("@tedadeghabli", Convert.ToInt64(dt.Rows[0].ItemArray[0].ToString()));
                                    updateMojodiCmd.Parameters.AddWithValue("@tedad", Convert.ToInt64(textBoxTedadKala.Text));
                                    updateMojodiCmd.Parameters.AddWithValue("@kkey", Convert.ToInt64(textBoxKkey.Text));
                                    updateMojodiCmd.ExecuteNonQuery();


                                }


                                //insert TAghlam
                                else if (count <= 0)
                                {
                                    SqlCommand insertCmd1 = new SqlCommand("INSERT INTO TAghlam (fkey, kkey, tedad) VALUES  (@fkey,@kkey,@tedad)", conn);
                                    insertCmd1.Parameters.AddWithValue("@fkey", Convert.ToInt32(lblFactorNumber.Text));
                                    insertCmd1.Parameters.AddWithValue("@kkey", Convert.ToInt64(textBoxKkey.Text));
                                    insertCmd1.Parameters.AddWithValue("@tedad", Convert.ToInt64(textBoxTedadKala.Text));

                                    insertCmd1.ExecuteNonQuery();

                                    // کم کردن موجودی کالا
                                    SqlCommand updateMojodiCmd = new SqlCommand("UPDATE TKala SET mojodi = mojodi - @tedad WHERE kkey = @kkey", conn);
                                    updateMojodiCmd.Parameters.AddWithValue("@tedad", Convert.ToInt64(textBoxTedadKala.Text));
                                    updateMojodiCmd.Parameters.AddWithValue("@kkey", Convert.ToInt64(textBoxKkey.Text));
                                    updateMojodiCmd.ExecuteNonQuery();

                                }
                            }
                            else  if (Convert.ToInt32(textBoxMkey.Text) != savedMkeyFactor)
                            {
                                MessageBox.Show($"شما فقط مجاز هستید اطلاعات کالا را برای مشتری با کد {savedMkeyFactor} ثبت کنید. زیرا در ابتدای ایجاد این فاکتور ، این کد مشتری را انتخاب کردید . برای ایجاد فاکتور جدید صفحه را بسته و مجددا بر روی تب فاکتور کلیک کنید !", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                textBoxMkey.Focus();
                                return;
                            }

                        }


                    }

                MessageBox.Show("فاکتور جدید با موفقیت ثبت شد", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //FFaktor_Load(sender, e);

                textBoxKkey.Text = textBoxTedadKala.Text = "";
                textBoxMkey.Text = savedMkeyFactor.ToString();


                    //-- نمایش داده ها
                    showData();
                textBoxMkey.Focus();
                    

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"خطا: {ex.Message}", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }



                //-- INSERT INTO TAghlam table

                //try
                //{
                //    // استفاده از using برای اتصال و دستور
                //    using (SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=SuperMarket;Integrated Security=True;Encrypt=False"))
                //    {
                //        conn.Open();

                //        SqlCommand insertCmd = new SqlCommand("INSERT INTO TAghlam (fkey, kkey, tedad) VALUES  (@fkey,@kkey,@tedad)", conn);
                //        insertCmd.Parameters.AddWithValue("@fkey", Convert.ToInt32(lblFactorNumber.Text));
                //        insertCmd.Parameters.AddWithValue("@kkey", Convert.ToInt64(textBoxKkey.Text));
                //        insertCmd.Parameters.AddWithValue("@tedad", Convert.ToInt64(textBoxTedadKala.Text));

                //        insertCmd.ExecuteNonQuery();

                //        textBoxMkey.Text = textBoxKkey.Text = textBoxTedadKala.Text = "";
                //        MessageBox.Show("فاکتور جدید با موفقیت ثبت شد", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        FFaktor_Load(sender, e);

                //    }

                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show($"خطا: {ex.Message}", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}


            }
        }


        public void showData()
        {
            try
            {
                // استفاده از using برای اتصال و دستور
                using (SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=SuperMarket;Integrated Security=True;Encrypt=False"))
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT TAghlam.kkey AS [کد کالا], TKala.kname AS [نام کالا], TKala.price AS [قیمت واحد], TAghlam.tedad AS تعداد, TAghlam.tedad * TKala.price AS [قیمت کل] FROM  TKala INNER JOIN   TAghlam ON TKala.kkey = TAghlam.kkey WHERE TAghlam.fkey=@fkey", conn);
                    da.SelectCommand.Parameters.AddWithValue("@fkey", Convert.ToInt32(lblFactorNumber.Text));
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;


                    dataGridView1.Columns[0].Width = 70;// کد کالا
                    dataGridView1.Columns[1].Width = 160;//نام کالا
                    dataGridView1.Columns[2].Width = 80;//قیمت واحد
                    dataGridView1.Columns[3].Width = 60; //تعداد
                    dataGridView1.Columns[3].Width = 80; // قیمت کل



                    //محاسبه مبلغ کل فاکتور
                    SqlDataAdapter da2 = new SqlDataAdapter("SELECT  SUM ( TAghlam.tedad * TKala.price ) FROM  TKala INNER JOIN TAghlam ON TKala.kkey = TAghlam.kkey  WHERE TAghlam.fkey=@fkey ", conn);
                    da2.SelectCommand.Parameters.AddWithValue("@fkey", Convert.ToInt32(lblFactorNumber.Text));
                    DataTable dt2 = new DataTable();

                    da2.Fill(dt2);

                   lblSumPrice.Text =  dt2.Rows[0].ItemArray[0].ToString() + " تومان ";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطا: {ex.Message}", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void FFaktor_Load(object sender, EventArgs e)
        {
            checkFactor = false;
            newFactorCode();
            textBoxMkey.Focus();
            textBoxMkey.Text = textBoxKkey.Text = textBoxTedadKala.Text = "";

            //تاریخ شمسی
            labelDate.Text =ShamsiDate.m2shamsi(DateTime.Now);




        }

        private void textBoxMkey_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(textBoxMkey.Text, out int code))
            {
                lblMoshtariName.Text = lblMoshtariAddr.Text = lblMoshtariPhone.Text = "0";
                return;
            }
            try
            {
                // استفاده از using برای اتصال و دستور.
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
                        lblMoshtariName.Text = dt.Rows[0].ItemArray[0].ToString(); // name
                        lblMoshtariAddr.Text = dt.Rows[0].ItemArray[1].ToString(); // address
                        lblMoshtariPhone.Text = "0"+dt.Rows[0].ItemArray[2].ToString(); // phone

                        checkMCode = true;
                    }
                    else
                    {
                        lblMoshtariName.Text = lblMoshtariAddr.Text = lblMoshtariPhone.Text = "0";
                        checkMCode = false;
                    }


                    //FMoshtariEdit_Load(sender, e);
                }

            }
            catch (Exception ex)
            {
                //کد اشتراک اشتباهه وجود نداره
                lblMoshtariName.Text = lblMoshtariAddr.Text = lblMoshtariPhone.Text = "0";
                checkMCode = false;
            }



        }

        private void textBoxKkey_TextChanged(object sender, EventArgs e)
        {
            if (!long.TryParse(textBoxKkey.Text, out long code))
            {
                lblKalaname.Text = lablKalaprice.Text = lablKalamojodi.Text = "0";
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
                        lblKalaname.Text = dt.Rows[0].ItemArray[0].ToString(); // kname
                        lablKalaprice.Text = dt.Rows[0].ItemArray[1].ToString(); // price
                        lablKalamojodi.Text = dt.Rows[0].ItemArray[2].ToString(); // mojodi

                        textBoxTedadKala.Text = dt.Rows[0].ItemArray[2].ToString();
                        textBoxTedadKala.Focus();
                        checkKCode = true;
                    }
                    else
                    {
                        lblKalaname.Text = lablKalaprice.Text = lablKalamojodi.Text = "0";
                        checkKCode = false;
                    }


                    //FMoshtariEdit_Load(sender, e);
                }

            }
            catch (Exception ex)
            {
                //کد کالا اشتباهه وجود نداره
                lblKalaname.Text = lablKalaprice.Text = lablKalamojodi.Text = "";
                checkKCode = false;
            }

        }
    }
}
