using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddressBook
{
    public partial class AddUserForm : Form
    {
        public MainForm mainform1;
        //定义属性
        public string UserName
        {
            get { return this.textBox1.Text; }
            set { this.textBox1.Text = value; }
        }
        public string PassWord
        {
            get { return this.textBox2.Text; }
            set { this.textBox2.Text = value; }
        }

        public AddUserForm()
        {
            InitializeComponent();
        }

        private void AddDataSet_Click(object sender, EventArgs e)
        {
            //进行密码加密
            byte[] result = Encoding.Default.GetBytes(this.textBox2.Text.Trim());  //输入密码的文本框
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);//加密后的登陆明文密码
            this.textBox2.Text = BitConverter.ToString(output).Replace("-", ""); //为输出加密文本的文本框
            //插入信息
            mainform1.InsertUserinfo(this.textBox1.Text.ToString(), this.textBox2.Text.ToString());
            this.textBox1.Clear();
            this.textBox2.Clear();
        }
    }
}
