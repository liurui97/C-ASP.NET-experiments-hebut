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
    public partial class Form4 : Form
    {
        public MainForm form1;
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = "Server=localhost;Database=telephone;UID=sa;PWD=123456";
            SqlConnection conn = new SqlConnection(str);
            string query = "select * from telephoneinfomation where Name='" + this.textBox1.Text + "'";
            SqlCommand comm=new SqlCommand(query,conn);
            conn.Open();
            if (null != comm.ExecuteScalar())
            {
                MessageBox.Show("该用户以存在!");
            }
            else
            {
                string sqlInsert="insert into telephoneinfomation(Name,Sex,OfficeTel,HomeTel,Mark) values ('"+this.textBox1.Text+"','"+this.textBox2.Text+"','"+this.textBox3.Text+"','"+this.textBox4.Text+"','"+this.textBox5.Text+"')";
                comm.CommandText = sqlInsert;
                comm.Parameters.Add("@Name", SqlDbType.Text).Value = this.textBox1.Text;
                comm.Parameters.Add("@Sex", SqlDbType.Text).Value = this.textBox2.Text;
                comm.Parameters.Add("@OfficeTel", SqlDbType.Text).Value = this.textBox3.Text;
                comm.Parameters.Add("@HomeTel", SqlDbType.Text).Value = this.textBox4.Text;
                comm.Parameters.Add("@Mark", SqlDbType.Text).Value = this.textBox5.Text;
                comm.ExecuteNonQuery();

                ListViewItem lvi = new ListViewItem();
                lvi.Text = this.form1.listView1.Items.Count.ToString();
                lvi.SubItems.Add(this.textBox1.Text);
                lvi.SubItems.Add(this.textBox2.Text);
                lvi.SubItems.Add(this.textBox3.Text);
                lvi.SubItems.Add(this.textBox4.Text);
                lvi.SubItems.Add(this.textBox5.Text);

                this.form1.Insert2(lvi);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
