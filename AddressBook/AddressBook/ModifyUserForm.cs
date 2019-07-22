using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddressBook
{
    public partial class ModifyUserForm : Form
    {
        public MainForm mainform3;
        //定义属性，用于显示
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
        public int UserID
        {
            get { return Convert.ToInt32(this.textBox3.Text.ToString()); }
            set { this.textBox3.Text = value.ToString(); }
        }
        public ModifyUserForm()
        {
            InitializeComponent();
        }

        private void modifyuser_Click(object sender, EventArgs e)
        {
            mainform3.modifyuserform = this;
            //mainform3.modifyuserform.textBox3.ReadOnly = true;
            mainform3.ModifyUserInfo(this.textBox3.Text, this.textBox1.Text, this.textBox2.Text);
        }

        private void cancelmodifyuser_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
