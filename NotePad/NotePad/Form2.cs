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
    public partial class Form2 : Form
    {
        public Form1 f1;
        public int start = 0;
        

        public Form2(Form1 form1, int ss)
        {
            InitializeComponent();
            f1 = form1;
            start = ss;
        }

        private void searchbutton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0)
            {
                //f1.FindRichTextBoxString(textBox1.Text);
                //向下查找
                if (h2)
                {
                    //不区分大小写
                    if (!h3)
                    {
                        start = f1.richTextBox1.Text.IndexOf(textBox1.Text, start, StringComparison.CurrentCultureIgnoreCase);
                    }
                    else
                    {
                        start = f1.richTextBox1.Text.IndexOf(textBox1.Text, start);
                    }

                    //查找到
                    if (start != -1)
                    {
                        /*f1.richTextBox1.Focus();
                        f1.richTextBox1.Select(start, textBox1.Text.Length);*/
                        f1.richTextBox1.Select(start, textBox1.Text.Length);
                        f1.richTextBox1.Focus();
                        start = start + textBox1.Text.Length;
                    }
                    else
                    {
                        MessageBox.Show("找不到" + textBox1.Text);
                        start = f1.richTextBox1.SelectionStart + textBox1.Text.Length;
                    }
                }
                else
                {
                    //进行向上查找
                    if (h3)
                    {
                        if (start >= 0)
                        {
                            //区分大小写
                            int i = f1.richTextBox1.Find(textBox1.Text, 0, start, RichTextBoxFinds.Reverse | RichTextBoxFinds.MatchCase);
                            f1.richTextBox1.Focus();

                            if (i == -1 || start == 0)
                            {
                                MessageBox.Show("找不到" + textBox1.Text);
                                i = start;
                            }
                            else
                            {
                                start = i;
                            }               
                        }
                    }
                    else
                    {
                        if (start >= 0)
                        {
                            int i = f1.richTextBox1.Find(textBox1.Text, 0, start, RichTextBoxFinds.Reverse);
                            f1.richTextBox1.Focus();

                            if (i == -1 || start == 0)
                            {
                                MessageBox.Show("找不到" + textBox1.Text);
                                i = start;
                            }
                            else
                            {
                                start = i;
                            }
                        }
                    }
                            
                }
            }
            else
            {
                MessageBox.Show("查找的字符串不能为空", "提示", MessageBoxButtons.OK);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
        //代表查找方向
        private bool h2 = false;
        //判断是否区分大小写
        private bool h3 = false;
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            h2 = !h2;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            h3 = !h3;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            radioButton2.Checked = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }
    }
}
