using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotePad
{
    public partial class Form4 : Form
    {
        public Form1 f111;
        public Form4()
        {
            InitializeComponent();
        }

        private void changeto_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0)
            {
                try
                {
                    int i = Convert.ToInt32(textBox1.Text);
                    f111.TranformToLine(i);
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("输入内容格式不正确", "提示", MessageBoxButtons.OK);
                }
                finally
                {
                   this.Close();
                }
            }
            else
            {
                MessageBox.Show("输入内容不能为空！", "提示", MessageBoxButtons.OK);
            }            
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}
