using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddressBook
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }
        DBClass db1 = new DBClass();

        //清空输入
        public void c()
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void registerbtn_Click(object sender, EventArgs e)
        {
            byte[] result = Encoding.Default.GetBytes(this.textBox2.Text.Trim());  //输入密码的文本框
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);//加密后的登陆明文密码
            this.textBox2.Text = BitConverter.ToString(output).Replace("-", ""); //为输出加密文本的文本框
            MessageBox.Show(this.textBox2.Text);
            /*if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("请输入完整信息！");
                return;
            }

            //建立连接对象
            SqlConnection conn = new SqlConnection(db1.strConn);
            string sqlSelect = "select * from Test where UserName='" + textBox1.Text.ToString() + "'";
            SqlCommand cmd = new SqlCommand(sqlSelect, conn);
            conn.Open();
            if (cmd.ExecuteScalar() != null)
            {
                MessageBox.Show("该账户已被注册");
                conn.Close();
                return;
            }
            else
            {
                string sql = "insert into Test(UserName,PassWord) values('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "')";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                c();
                MessageBox.Show("注册成功");
                this.Close();
            }*/
        }
    }
}
