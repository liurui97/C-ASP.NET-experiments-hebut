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

namespace AddressBook2
{
    public partial class Form2 : Form
    {
        public MainForm form1;
        
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = "Server=localhost;Database=telephone;UID=sa;PWD=123456";
            SqlConnection conn = new SqlConnection(str);
            string query = "select * from userinfo where UserName='" + this.textBox1.Text + "'";
            SqlCommand cmd = new SqlCommand(query,conn);
            conn.Open();
            if (null != cmd.ExecuteScalar())
            {
                MessageBox.Show("该用户已存在!");
            }
            else
            {
                //使用参数化
                string sqlInsert = "insert into userinfo(UserName,PassWord) values(@UserName,@PassWord)";
                cmd.CommandText = sqlInsert;
                byte[] result = Encoding.Default.GetBytes(this.textBox2.Text.Trim());  //输入密码的文本框
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] output = md5.ComputeHash(result);//加密后的登陆明文密码
                this.textBox2.Text = BitConverter.ToString(output).Replace("-", ""); //为输出加密文本的文本框
                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 20).Value = this.textBox1.Text;
                cmd.Parameters.Add("@PassWord", SqlDbType.NVarChar, 32).Value = this.textBox2.Text;
                cmd.ExecuteNonQuery();

                ListViewItem lvi = new ListViewItem();
                lvi.Text = (this.form1.listView1.Items.Count+1).ToString();
                lvi.SubItems.Add(this.textBox1.Text);
                lvi.SubItems.Add(this.textBox2.Text);

                this.form1.Insert(lvi);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
