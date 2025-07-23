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

        //create a connection to our interested DB:
        SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=SuperMarket;Integrated Security=True;Encrypt=False");

        public FFaktor()
        {
            InitializeComponent();
        }

        //another personal functions that I wanna write by myself!
        public void newCustomerCode()
        {
            try
            {
                //SELECT
                SqlDataAdapter da = new SqlDataAdapter("SELECT   MAX(fkey)  FROM  TFaktor", conn);
                DataTable dt = new DataTable(); //a virtual table
                da.Fill(dt);
                lblFactorNumber.Text = (Convert.ToInt32(dt.Rows[0].ItemArray[0]) + 1).ToString();//radif 0 soton 0

            }
            //برای اینه که اگه جدول دیتابیسم خالی بود خطا نده و کد مشتری رو از 1000 در نظر بگیره
            catch
            {
                lblFactorNumber.Text = "5000";
            }
        }

        private void btnSabtFactor_Click(object sender, EventArgs e)
        {

        }

        private void FFaktor_Load(object sender, EventArgs e)
        {
            newCustomerCode();
            textBoxMkey.Focus();
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
                        lblMoshtariPhone.Text = dt.Rows[0].ItemArray[2].ToString(); // phone

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
