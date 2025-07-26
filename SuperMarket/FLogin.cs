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
using SuperMarket;


namespace WindowsFormsApp1
{
    public partial class FLogin : Form
    {
        Boolean isUsernameExist = false;
        SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=SuperMarket;Integrated Security=True;Encrypt=False");
        string username;
        string password;
        string usertype;
        public FLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
                textBox1.Focus();
            else if(textBox2.Text=="")
                btnOut.Focus();
            else
            {
                try
                {
                    // استفاده از using برای اتصال و دستور.
                    using (SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=SuperMarket;Integrated Security=True;Encrypt=False"))
                    {
                        conn.Open();

                        // چک کردن وجودیوزرنیم در پایگاه داده و سپس انتخاب
                        //SELECT  where
                        SqlDataAdapter da = new SqlDataAdapter("SELECT   username, pass, userType FROM  TUser WHERE username = @username", conn);
                        da.SelectCommand.Parameters.AddWithValue("@username", textBox1.Text);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        //نام کاربری موجود 
                        if (dt.Rows.Count > 0)
                        {
                            //MessageBox.Show("یوزرنیم موجود است");
                            Memory.usernameMem  = dt.Rows[0].ItemArray[0].ToString(); //bayad ersal she be form factor
                            //رمز درست
                            if (dt.Rows[0].ItemArray[1].ToString() == textBox2.Text)
                            {
                                //سیو یوزرنیم برای بعدا در ثبت فاکتور مهمه
                                Memory.passwordMem = dt.Rows[0].ItemArray[1].ToString(); //bayad ersal she be form factor
                                Memory.usertypeMem = Convert.ToInt32(dt.Rows[0].ItemArray[2]); //bayad ersal she be form factor

                                if (Memory.usertypeMem == 1) //نقش مدیر
                                {
                                    MessageBox.Show("ورود مدیر موفقیت آمیز - در حال هدایت به صفحه ی اصلی");
                                }
                                else if (Memory.usertypeMem == 0)
                                {
                                    MessageBox.Show("ورود کاربر عادی موفقیت آمیز - در حال هدایت به صفحه ی اصلی");
                                }
                                //ورود به صفحه اصلی و خروج از صفحه لاگین
                                //FMain fMain = new FMain();
                                //fMain.ShowDialog();
                                this.Close();
                                //this.Close();

                            }
                            //رمز غلط
                            else if (!(dt.Rows[0].ItemArray[1].ToString() == textBox2.Text))
                            {
                                //پیام رمز غلط است و فوکوس روی رمز
                                MessageBox.Show("یوزرنیم درست پسورد غلط");
                                textBox2.Focus();
                            }
                            //isUsernameExist = true;
                        }
                        //نام کاربری ناموجود
                        else
                        {
                            //پیام نام کاربری ناموجود و فوکوس روی نام کاربری

                            MessageBox.Show("چنین نام کاربری ای وجود ندارد لطفا دوباره تلاش کنید", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            textBox1.Focus() ;
                            //isUsernameExist = false;
                        }


                        //FMoshtariEdit_Load(sender, e);
                    }

                }
                catch (Exception ex)
                {
                    
                    MessageBox.Show($"خطا: {ex.Message}", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
        }

        private void FLogin_Load(object sender, EventArgs e)
        {
            isUsernameExist = false ;
            textBox1.Text = textBox2.Text = "";
            textBox1.Focus();
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
