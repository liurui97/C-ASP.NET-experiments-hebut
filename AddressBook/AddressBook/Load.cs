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
    public partial class Load : Form
    {
        public Load()
        {
            InitializeComponent();
        }
        DBClass db1 = new DBClass();
        private void login_Click(object sender, EventArgs e)
        {
            if (name.Text.Trim() == "" || PWD.Text.Trim() == "")
            {
                MessageBox.Show("请完整填写用户信息", "提示");
            }
            else
            {
                byte[] result = Encoding.Default.GetBytes(this.PWD.Text.Trim());  //输入密码的文本框
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] output = md5.ComputeHash(result);//加密后的登陆明文密码
                this.PWD.Text = BitConverter.ToString(output).Replace("-", ""); //为输出加密文本的文本框
                //MessageBox.Show(this.PWD.Text);
                //建立连接对象
                SqlConnection conn = new SqlConnection(db1.strConn);
                //SQL语句
                string str = "select * from userinfo where UserName='" + name.Text.ToString().Trim() + "'and PassWord='" + PWD.Text.ToString().Trim() + "'";
                //建立数据库命令对象
                SqlCommand comm = new SqlCommand(str, conn);
                try
                {
                    //打开连接
                    conn.Open();
                    //执行命令，影响返回的行数
                    SqlDataReader rd = comm.ExecuteReader();
                    if (rd.HasRows)
                    {
                        conn.Close();
                        Tag = 1;
                        //this.Close();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("用户信息错误，请重新登陆！");
                        conn.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void tuichu_Click(object sender, EventArgs e)
        {
            Tag = 0;
            this.Close();
        }
    }
}
