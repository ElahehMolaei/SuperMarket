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
        public FUser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
                textBox1.Focus();
            else if(textBox2.Text=="")
                textBox2.Focus();
            else
            {
                //sabte etelatae karbari

                //create a connection to our interested DB:
                SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=SuperMarket;Integrated Security=True;Encrypt=False");
                conn.Open();

                // 1.chek tekrari nabudan username ya 2. try catch 

                try
                {
                    //insert into user table
                    SqlCommand com = new SqlCommand("INSERT INTO TUser (username, pass, userType) VALUES (@username,@pass,@userType)", conn);
                    com.Parameters.AddWithValue("@username", textBox1.Text);
                    com.Parameters.AddWithValue("@pass", textBox2.Text);
                    com.Parameters.AddWithValue("@userType", radioButton1.Checked ? 0 : 1);
                    com.ExecuteNonQuery();
                    conn.Close();

                    //after adding a new user , the texboxes should be empty for adding another user
                    textBox1.Text = textBox2.Text = "";
                    radioButton1.Checked = true;
                    textBox1.Focus();
                    MessageBox.Show("کاربر جدید با موفقیت اضافه شد", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex) 
                {
                    MessageBox.Show("قبلا این نام کاربری ثبت شده است.", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

            }
        }
    }
}
