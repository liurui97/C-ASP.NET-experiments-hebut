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
    public partial class ModifyForm : Form
    {
        public MainForm mainform4;
        public int PersonID
        {
            get { return Convert.ToInt32(this.textBox6.Text.ToString()); }
            set { this.textBox6.Text = value.ToString(); }
        }
        public string Name{
            get{ return this.textBox1.Text;}
            set{ this.textBox1.Text=value;}
        }
        public string Sex{
            get{ return this.textBox2.Text;}
            set{ this.textBox2.Text=value;}
        }
        public string OfficeTel{
            get{return this.textBox3.Text;}
            set{this.textBox3.Text=value;}
        }
        public string HomeTel{
            get{ return this.textBox4.Text;}
            set{this.textBox4.Text=value;}
        }
        public string Mark{
            get{return this.textBox5.Text;}
            set{this.textBox5.Text=value;}
        }
            
        
        public ModifyForm()
        {
            InitializeComponent();
            this.textBox6.ReadOnly = true;
        }

        private void modifytelephoneinfo_Click(object sender, EventArgs e)
        {
            mainform4.modifyform = this;
            //mainform4.modifyform.ReadOn
            mainform4.ModifyTelephoneInfo(this.textBox6.Text, this.textBox1.Text, this.textBox2.Text, this.textBox3.Text, this.textBox4.Text, this.textBox5.Text);
        }

        private void cancelmodifytelephone_Click(object sender, EventArgs e)
        {

        }
    }
}
