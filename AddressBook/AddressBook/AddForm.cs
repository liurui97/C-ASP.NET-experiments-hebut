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
    public partial class AddForm : Form
    {
        public MainForm mainform2;
        
        public AddForm()
        {
            InitializeComponent();
        }

        private void InsertDataSet_Click(object sender, EventArgs e)
        {
            mainform2.InsertTelephoneinfo(this.textBox1.Text.ToString(), this.textBox2.Text.ToString(), this.textBox3.Text.ToString(), this.textBox4.Text.ToString(), this.textBox5.Text.ToString());
            this.textBox1.Clear();
            this.textBox2.Clear();
            this.textBox3.Clear();
            this.textBox4.Clear();
            this.textBox5.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
