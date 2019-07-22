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
    public partial class Form5 : Form
    {
        public MainForm form1;
        public int PersonID
        {
            get
            {
                return Convert.ToInt32(this.textBox1.Text);
            }
            set
            {
                this.textBox1.Text = value.ToString();
            }
        }

        public string Name
        {
            get
            {
                return this.textBox2.Text;
            }
            set
            {
                this.textBox2.Text = value.ToString();
            }
        }
        public string Sex
        {
            get
            {
                return this.textBox3.Text;
            }
            set
            {
                this.textBox3.Text = value.ToString();
            }
        }
        public string OfficeTel
        {
            get
            {
                return this.textBox4.Text;
            }
            set
            {
                this.textBox4.Text = value.ToString();
            }
        }
        public string HomeTel
        {
            get
            {
                return this.textBox5.Text;
            }
            set
            {
                this.textBox5.Text = value.ToString();
            }
        }
        public string Mark
        {
            get
            {
                return this.textBox6.Text;
            }
            set
            {
                this.textBox6.Text = value.ToString();
            }
        }
        public Form5()
        {
            InitializeComponent();
            this.textBox1.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = "Server=localhost;Database=telephone;UID=sa;PWD=123456";
            SqlConnection conn = new SqlConnection(str);
            string query = "update telephoneinfomation set Name='" + this.textBox2.Text + "',Sex='" + this.textBox3.Text + "',OfficeTel='" + this.textBox4.Text + "',HomeTel='" + this.textBox5.Text + "',Mark='" + this.textBox6.Text + "' where PersonID=" + Convert.ToInt32(this.textBox1.Text);
            SqlCommand comm = new SqlCommand(query, conn);
            conn.Open();
            comm.CommandText = query;
            comm.ExecuteNonQuery();

            ListViewItem lvi = new ListViewItem();
            lvi.Text = this.textBox1.Text;
            lvi.SubItems.Add(this.textBox2.Text);
            lvi.SubItems.Add(this.textBox3.Text);
            lvi.SubItems.Add(this.textBox4.Text);
            lvi.SubItems.Add(this.textBox5.Text);
            lvi.SubItems.Add(this.textBox6.Text);

            this.form1.Modify2(lvi);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
