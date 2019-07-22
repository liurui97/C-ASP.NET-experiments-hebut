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
    public partial class Form3 : Form
    {
        public Form1 f11;
        private int start;
        private bool h3 = true;
        public Form3()
        {
            InitializeComponent();
        }

        public Form3(Form1 f1,int ss)
        {
            InitializeComponent();
            f11 = f1;
            start = ss;
        }
        private void searchbutton_Click(object sender, EventArgs e)
        {
            /*if (textBox1.Text.Length != 0)
            {
                f11.FindRichTextBoxString(textBox1.Text);
            }
            else
            {
                MessageBox.Show("查找的字符串不能为空", "提示", MessageBoxButtons.OK);
            }*/
            if (h3)
            {
                start = f11.richTextBox1.Text.IndexOf(Text, start, StringComparison.CurrentCultureIgnoreCase);//不区分大小写

            }
            else
            {
                start = f11.richTextBox1.Text.IndexOf(textBox1.Text, start);//区分大小写

            }//查找te2.Text，从光标处开始,找到时返回从0开始的索引号，找不到时返回-1

            if (start!= -1)
            {
                f11.richTextBox1.Select(start, textBox1.Text.Length);
                f11.richTextBox1.Focus();
                start = start + textBox1.Text.Length;
            }
            else
            {
                MessageBox.Show("找不到" + textBox1.Text);

                start = f11.richTextBox1.SelectionStart + textBox1.Text.Length;
            }
        }

        private void replacebutton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0)
            {
                f11.FindRichTextBoxString(textBox1.Text);
                f11.ReplaceRichTextBoxString(textBox1.Text, textBox2.Text);
            }
            else
            {
                MessageBox.Show("替换的字符串不能为空", "提示", MessageBoxButtons.OK);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            f11.richTextBox1.Text = f11.richTextBox1.Text.Replace(textBox1.Text, textBox2.Text);
            MessageBox.Show("替换成功!");
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            h3 = !h3;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
