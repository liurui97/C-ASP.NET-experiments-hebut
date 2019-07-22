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

namespace AddressBook2
{
    public partial class Form3 : Form
    {
        public MainForm form1;
        //设置属性，为了在新的界面中获取信息
        public string UserName
        {
            get
            {
                return this.textBox1.Text.ToString();
            }
            set
            {
                this.textBox1.Text = value.ToString();
            }
        }

        public string PassWord
        {
            get
            {
                return this.textBox2.Text.ToString();
            }
            set
            {
                this.textBox2.Text = value.ToString();
            }
        }

        public int UserID
        {
            get
            {
                return Convert.ToInt32(this.textBox3.Text.ToString());
            }
            set
            {
                this.textBox3.Text = value.ToString();
            }
        }
        public Form3()
        {
            InitializeComponent();
            this.textBox3.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = "Server=localhost;Database=telephone;UID=sa;PWD=123456";
            SqlConnection conn = new SqlConnection(str);
            string query = "update userinfo set PassWord='" + textBox2.Text + "' ,UserName='" + textBox1.Text + "' where UserID="+Convert.ToInt32(textBox3.Text);
            SqlCommand comm = new SqlCommand(query, conn);
            conn.Open();
            comm.CommandText = query;
            comm.ExecuteNonQuery();

            ListViewItem lvi = new ListViewItem();
            lvi.Text = this.textBox3.Text;
            lvi.SubItems.Add(this.textBox1.Text);
            lvi.SubItems.Add(this.textBox2.Text);

            this.form1.Modify(lvi);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
