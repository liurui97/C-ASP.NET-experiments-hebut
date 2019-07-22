using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace NotePad
{
    public partial class Form1 : Form
    {
        public int a = 0;
        public int b = 0;
        public int d = 0;
        public int k = 0;
        public int j = 0;
        public int findposition = 0;
        public string rtb = "";
        public Form1()
        {
            InitializeComponent();
            this.Text = "无标题-记事本";
            if (this.richTextBox1.Text == "")
            {
                撤销ToolStripMenuItem.Enabled = false;
                剪切ToolStripMenuItem.Enabled = false;
                复制ToolStripMenuItem.Enabled = false;
                删除ToolStripMenuItem.Enabled = false;
                查找ToolStripMenuItem.Enabled = false;
            }
        }
        [System.Runtime.InteropServices.DllImport("User32.DLL")]
        public static extern int SendMessage(IntPtr hWnd, uint Msg,int wParam, int iParam);
        private const int EM_LINEFROMCHAR = 0xC9;
        private const int EM_LINEINDEX = 0xBB;

        //获得当前的行和列的位置
        private Point GetCursorPos(int p)
        {
            Point cursorPos = new Point(0, 0);
            int x, y;
            y = SendMessage(richTextBox1.Handle, EM_LINEFROMCHAR, richTextBox1.SelectionStart, 0);
            x = richTextBox1.SelectionStart - SendMessage(richTextBox1.Handle, EM_LINEINDEX, y, 0);
            cursorPos.Y = ++y;
            cursorPos.X = ++x;
            return cursorPos;
        }

        //加载函数
        private void Form1_Load(object sender, EventArgs e)
        {
            自动换行ToolStripMenuItem.Checked = false;
            d = 1;
            openFileDialog1.FileName = "*.txt";
            saveFileDialog1.FileName = "*.txt";
            toolStripStatusLabel1.Text = "第0行，第0列";
        }

        //窗口关闭事件
        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result;
            try
            {
                if (rtb != richTextBox1.Text)
                {
                    result = MessageBox.Show("文件 " + this.Text + " 的文字已经改变。\r\n\r\n想保存文件吗？", "记事本", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                    if (result == DialogResult.Yes)
                    {
                        saveFileDialog1.Filter = @"文本文档(*.txt)|*.txt|所有格式|*.txt;*.doc;*.cs;*.rtf;*.sln";
                        if (saveFileDialog1.ShowDialog() == DialogResult.Yes)
                        {
                            richTextBox1.SaveFile(saveFileDialog1.FileName.ToString(), RichTextBoxStreamType.PlainText);
                            richTextBox1.Text = "";
                        }
                        else
                        {
                            e.Cancel = true;
                        }
                    }
                    else if (result == DialogResult.No)
                    {
                        this.Dispose();
                    }
                    else
                        e.Cancel = true;
                }
            }
            catch { }
        }
        
        
        private void 文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        //首先判断文档是否改变，改变先保存，未改变新建
        private void 新建ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "*.txt";
            openFileDialog1.FileName = "*.txt";
            DialogResult result;
            try
            {
                if (rtb != richTextBox1.Text)
                {
                    result=MessageBox.Show("文件"+this.Text+"的文字已经改变。\n\r\r\n想保存文件吗？","记事本",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Exclamation);
                    if (result == DialogResult.Yes)
                    {
                        saveFileDialog1.Filter = @"文本文档(*.txt)|*.txt|所有格式|*.doc;*.txt;*.cs;*.rtf;*.sln";
                        saveFileDialog1.ShowDialog();
                        richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                        richTextBox1.Text = "";
                        rtb = richTextBox1.Text;
                    }
                    else if (result == DialogResult.No)
                    {
                        richTextBox1.Text = "";
                        this.Text = "无标题-记事本";
                        rtb = richTextBox1.Text;
                    }
                }
                else
                {
                    richTextBox1.Text = "";
                    rtb = richTextBox1.Text;
                    this.Text = "无标题-记事本";
                    剪切ToolStripMenuItem.Enabled = false;
                    复制ToolStripMenuItem.Enabled = false;
                    删除ToolStripMenuItem.Enabled = false;
                    查找ToolStripMenuItem.Enabled = false;
                    //查找下一个ToolStripMenuItem.Enabled = false;
                }                
            }
            catch{}
        }
        
        //判断文档内容是否修改，若修改先保存，否则可以进行打开
        private void 打开OCtrlOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result;
            try
            {
                if (rtb != richTextBox1.Text)
                {
                    result = MessageBox.Show("文件" + this.Text + "的文字已经改变。\r\n\r\n想保存文件吗？", "记事本", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                    if (result == DialogResult.Yes)
                    {
                        //进行文档的保存
                        saveFileDialog1.Filter = @"文本文档(*.txt)|*.txt|所有格式|*.txt;*.doc;*.cs;*.rtf;*.sln";
                        saveFileDialog1.ShowDialog();
                        richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                        //进行文档的打开
                        openFileDialog1.Filter = @"文本文档(*.txt)|*.txt|所有格式|*.txt;*.doc;*.cs;*.rtf;*.sln";
                        openFileDialog1.ShowDialog();
                        richTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                        rtb = richTextBox1.Text;
                    }
                    else if (result == DialogResult.No)
                    {
                        openFileDialog1.Filter = @"文本文档(*.txt)|*.txt|所有格式|*.txt;*.doc;*.cs;*.rtf;*.sln";
                        openFileDialog1.ShowDialog();
                        richTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                        rtb = richTextBox1.Text;
                    }
                }
                else
                {
                    openFileDialog1.Filter = @"文本文档(*.txt)|*.txt|所有格式|*.txt;*.doc;*.cs;*.rtf;*.sln";
                    openFileDialog1.ShowDialog();
                    richTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                    rtb = richTextBox1.Text;
                }
                this.Text = Path.GetFileName(openFileDialog1.FileName) + "- 记事本";

                saveFileDialog1.FileName = openFileDialog1.FileName;
                撤销UToolStripMenuItem.Enabled = false;
            }
            catch { }
        }

        //进行文档内容保存
        private void 保存SCtrlSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Text == "无标题-记事本")
                {
                    if (d == 1)
                    {
                        saveFileDialog1.Filter = @"文本文档(*.txt)|*.txt|所有格式|*.txt;*.doc;*.cs;*.rtf;*.sln";
                        saveFileDialog1.ShowDialog();
                        richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                        this.Text = Path.GetFileName(saveFileDialog1.FileName) + "-记事本";
                    }
                }
                else
                {
                    saveFileDialog1.Filter = @"|*.txt;*.cs";
                    if (this.Text == Path.GetFileName(openFileDialog1.FileName) + "-记事本")
                        richTextBox1.SaveFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                    else
                        richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                }
                rtb = richTextBox1.Text;
            }
            catch { }
        }
        //进行另存为
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (d == 1)
                {
                    saveFileDialog1.Filter = @"文本文档(*.txt)|*.txt|所有格式|*.txt;*.doc;*.cs;*.rtf;*.sln";
                    saveFileDialog1.ShowDialog();
                    richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                    this.Text = Path.GetFileName(saveFileDialog1.FileName) + "- 记事本";
                    rtb = richTextBox1.Text;
                }
            }
            catch { }
        }
        //进行页面设置
        private void 页面设置UCtrlPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                pageSetupDialog1.Document = printDocument1;
                pageSetupDialog1.Document.DefaultPageSettings.Color = false;
                this.pageSetupDialog1.ShowDialog();
                if (pageSetupDialog1.ShowDialog() == DialogResult.OK)
                    printDocument1.DefaultPageSettings =
                                         pageSetupDialog1.PageSettings;
            }
            catch { }           
        }

        //进行打印输出
        private void 打印PCtrlPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                printDialog1.Document = printDocument1;
                if (printDialog1.ShowDialog() == DialogResult.OK)
                {
                    printDocument1.Print();
                }
            }
            catch
            {
                MessageBox.Show("尚未安装打印机！");
            }
        }
        //退出
        private void 退出XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result;
            try
            {
                if (rtb != richTextBox1.Text)
                {
                    result = MessageBox.Show("文件 " + this.Text + " 的文字已经改变。\r\n\r\n想保存文件吗？", "记事本", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                    if (result == DialogResult.Yes)
                    {
                        saveFileDialog1.Filter = @"文本文档(*.txt)|*.txt|所有格式|*.txt;*.doc;*.cs;*.rtf;*.sln";
                        if (saveFileDialog1.ShowDialog() == DialogResult.Yes)
                        {
                            richTextBox1.SaveFile(saveFileDialog1.FileName.ToString(), RichTextBoxStreamType.PlainText);
                            richTextBox1.Text = "";
                        }
                        else
                        {
                            Application.Exit();
                        }
                    }
                    else if (result == DialogResult.No)
                    {
                        this.Dispose();
                    }
                    else
                        this.Close();
                }
            }
            catch { }
        }
        //进行撤销操作
        private void 撤销UToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (a == 0)
            {
                richTextBox1.Undo();
                a = 1;
            }
            else if (a == 1)
            {
                richTextBox1.Undo();
                a = 0;
            }
        }

        //进行剪切操作
        private void 剪切ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        //粘贴
        private void 粘贴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        //删除
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }
        //查找,这个功能有待改正
        private void 查找ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*findposition = 0;
            Form2 f2 = new Form2();
            f2.f1 = this;
            f2.Show();*/
            Form2 f2= new Form2(this, richTextBox1.SelectionStart);
            f2.Show();
        }

        public void FindRichTextBoxString(string findString)
        {
            //查询语句
            if (findposition>=richTextBox1.Text.Length)
            {
                //查询到文档底部
                MessageBox.Show("已到文档底部，再次查找将回到顶部","提示",MessageBoxButtons.OK);
                findposition = 0;
                return;
            }
            //查找并返回查找位置，没找到返回-1
            findposition = richTextBox1.Find(findString, findposition, RichTextBoxFinds.MatchCase);
            if (findposition == -1){
                MessageBox.Show("已到文档底部，再次查找将回到顶部", "提示", MessageBoxButtons.OK);
                findposition = 0;
            }
            else
            {
                richTextBox1.Focus(); ;//主窗体获得字符串焦点
                findposition += findString.Length;//更新查找位置
            }
        }
        private void 替换ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*findposition = 0;
            Form3 f3 = new Form3();
            f3.f11 = this;
            f3.Show();*/
            Form3 f3 = new Form3(this, richTextBox1.SelectionStart);
            f3.Show();
        }
        public void ReplaceRichTextBoxString(string findString, string replaceString)
        {
            if (richTextBox1.SelectedText.Length != 0)
            {
                richTextBox1.SelectedText = replaceString;
                MessageBox.Show("替换成功！", "提示", MessageBoxButtons.OK);
            }
        }
        private void 转到ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.f111 = this;
            f4.Show();
        }
        public void TranformToLine(int i)
        {
            richTextBox1.SelectionStart = i;
            richTextBox1.SelectionLength = 0;
            richTextBox1.Focus();
        }

        private void 全选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }
       private void 时间日期ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = richTextBox1.Text + DateTime.Now.ToString();
        }
        private void 自动换行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (j == 0)
            {
                转到ToolStripMenuItem.Enabled = false;
                if (状态栏ToolStripMenuItem.Checked == true)
                {
                    statusStrip1.Hide();
                    状态栏ToolStripMenuItem.Checked = false;
                    自动换行ToolStripMenuItem.Checked = true;
                    状态栏ToolStripMenuItem.Enabled = false;
                    richTextBox1.WordWrap = true;
                    b = 1;
                }
                else
                {
                    richTextBox1.WordWrap = true;
                    自动换行ToolStripMenuItem.Checked = true;
                    状态栏ToolStripMenuItem.Enabled = false;
                }
                j = -1;
            }
            else
            {
                转到ToolStripMenuItem.Enabled = true;
                if (b == 1)
                {
                    statusStrip1.Show();
                    状态栏ToolStripMenuItem.Checked = false;
                    richTextBox1.WordWrap = false;
                    状态栏ToolStripMenuItem.Enabled = true;
                    自动换行ToolStripMenuItem.Checked = false;
                    b = 0;
                }
                else
                {
                    自动换行ToolStripMenuItem.Checked = false;
                    状态栏ToolStripMenuItem.Enabled = true;
                    richTextBox1.WordWrap = false;
                }
                j = 0;
            }
        }
        private void 字体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionLength > 0)
            {
                if (fontDialog1.ShowDialog() == DialogResult.OK)
                {
                    richTextBox1.SelectionFont = fontDialog1.Font;
                }
            }
        }
        private void 状态栏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (k == -1)
            {
                statusStrip1.Show();
                状态栏ToolStripMenuItem.Checked = true;
                k = 0;
            }
            else
            {
                statusStrip1.Hide();
                状态栏ToolStripMenuItem.Checked = false;
                k = -1;
            }
        }
      

        private void 关于记事本ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
        }

        private void 颜色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionLength > 0)
            {
                if (colorDialog1.ShowDialog() == DialogResult.OK)
                {
                    richTextBox1.ForeColor = colorDialog1.Color;
                }
            }
        }

        private void 背景颜色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.BackColor = colorDialog1.Color;
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            撤销ToolStripMenuItem.Enabled = true;
            剪切ToolStripMenuItem.Enabled = true;
            复制ToolStripMenuItem.Enabled = true;
            删除ToolStripMenuItem.Enabled = true;
            查找ToolStripMenuItem.Enabled = true;
        }

        private void richTextBox1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.contextMenuStrip1.Show(MousePosition);
            }
        }

        private void 撤销ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (a == 0)
            {
                richTextBox1.Undo();
                a = 1;
            }
            else if (a == 1)
            {
                richTextBox1.Redo();
                a = 0;
            }
        }

        private void 剪切ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //richTextBox1.Cut();
            剪切ToolStripMenuItem_Click(sender, e);
        }

        private void 复制ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //richTextBox1.Copy();
            复制ToolStripMenuItem_Click(sender, e);
        }

        private void 粘贴ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //richTextBox1.Paste();
            粘贴ToolStripMenuItem_Click(sender, e);
        }

        private void 删除ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        private void richTextBox1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            Point p = GetCursorPos(this.richTextBox1.Handle.ToInt32());
            this.toolStripStatusLabel1.Text = "第" + p.Y + "行，第" + p.X + "列";
            if (e.KeyCode == Keys.Z && e.Control)
            {
                if (a == 0)
                {
                    richTextBox1.Undo();
                    a = 1;
                }
                else if (a == 1)
                {
                    richTextBox1.Redo();
                    a = 0;
                }
            }
            else if (e.KeyCode == Keys.X && e.Control)
            {
                richTextBox1.Cut();
            }
            else if (e.Control&&e.KeyCode == Keys.C)
            {
                richTextBox1.Copy();
            }
            else if (e.Control&&e.KeyCode == Keys.V)
            {
                richTextBox1.Paste();
            }
            else if (e.KeyCode == Keys.Delete)
            {
                richTextBox1.Text = "";
            }
            else if (e.KeyCode == Keys.F && e.Modifiers == Keys.Control)
            {
                Form2 f2 = new Form2(this, richTextBox1.SelectionStart);
                f2.Show();
            }
            else if (e.KeyCode == Keys.H && e.Modifiers == Keys.Control)
            {
                Form3 f3 = new Form3(this, richTextBox1.SelectionStart);
                f3.Show();
            }
            else if (e.KeyCode == Keys.G && e.Modifiers == Keys.Control)
            {
                Form4 f4 = new Form4();
                f4.f111 = this;
                f4.Show();
            }
            else if (e.Control&&e.KeyCode == Keys.A)
            {
                richTextBox1.SelectAll();
            }
            else if (e.KeyCode == Keys.F5)
            {
                richTextBox1.Text = richTextBox1.Text + DateTime.Now.ToString();
            }
            else if (e.KeyCode == Keys.N && e.Modifiers == Keys.Control)
            {
                saveFileDialog1.FileName = "*.txt";
                openFileDialog1.FileName = "*.txt";
                DialogResult result;
                try
                {
                    if (rtb != richTextBox1.Text)
                    {
                        result = MessageBox.Show("文件" + this.Text + "的文字已经改变。\n\r\r\n想保存文件吗？", "记事本", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                        if (result == DialogResult.Yes)
                        {
                            saveFileDialog1.Filter = @"文本文档(*.txt)|*.txt|所有格式|*.doc;*.txt;*.cs;*.rtf;*.sln";
                            saveFileDialog1.ShowDialog();
                            richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                            richTextBox1.Text = "";
                            rtb = richTextBox1.Text;
                        }
                        else if (result == DialogResult.No)
                        {
                            richTextBox1.Text = "";
                            this.Text = "无标题-记事本";
                            rtb = richTextBox1.Text;
                        }
                    }
                    else
                    {
                        richTextBox1.Text = "";
                        rtb = richTextBox1.Text;
                        this.Text = "无标题-记事本";
                        剪切ToolStripMenuItem.Enabled = false;
                        复制ToolStripMenuItem.Enabled = false;
                        删除ToolStripMenuItem.Enabled = false;
                        查找ToolStripMenuItem.Enabled = false;
                        //查找下一个ToolStripMenuItem.Enabled = false;
                    }
                }
                catch { }
            }
            else if (e.KeyCode == Keys.O && e.Modifiers == Keys.Control)
            {
                DialogResult result;
                try
                {
                    if (rtb != richTextBox1.Text)
                    {
                        result = MessageBox.Show("文件" + this.Text + "的文字已经改变。\r\n\r\n想保存文件吗？", "记事本", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                        if (result == DialogResult.Yes)
                        {
                            //进行文档的保存
                            saveFileDialog1.Filter = @"文本文档(*.txt)|*.txt|所有格式|*.txt;*.doc;*.cs;*.rtf;*.sln";
                            saveFileDialog1.ShowDialog();
                            richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                            //进行文档的打开
                            openFileDialog1.Filter = @"文本文档(*.txt)|*.txt|所有格式|*.txt;*.doc;*.cs;*.rtf;*.sln";
                            openFileDialog1.ShowDialog();
                            richTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                            rtb = richTextBox1.Text;
                        }
                        else if (result == DialogResult.No)
                        {
                            openFileDialog1.Filter = @"文本文档(*.txt)|*.txt|所有格式|*.txt;*.doc;*.cs;*.rtf;*.sln";
                            openFileDialog1.ShowDialog();
                            richTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                            rtb = richTextBox1.Text;
                        }
                    }
                    else
                    {
                        openFileDialog1.Filter = @"文本文档(*.txt)|*.txt|所有格式|*.txt;*.doc;*.cs;*.rtf;*.sln";
                        openFileDialog1.ShowDialog();
                        richTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                        rtb = richTextBox1.Text;
                    }
                    this.Text = Path.GetFileName(openFileDialog1.FileName) + "- 记事本";

                    saveFileDialog1.FileName = openFileDialog1.FileName;
                    撤销UToolStripMenuItem.Enabled = false;
                }
                catch { }
            }
            else if (e.KeyCode == Keys.S && e.Modifiers == Keys.Control)
            {
                try
                {
                    if (this.Text == "无标题-记事本")
                    {
                        if (d == 1)
                        {
                            saveFileDialog1.Filter = @"文本文档(*.txt)|*.txt|所有格式|*.txt;*.doc;*.cs;*.rtf;*.sln";
                            saveFileDialog1.ShowDialog();
                            richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                            this.Text = Path.GetFileName(saveFileDialog1.FileName) + "-记事本";
                        }
                    }
                    else
                    {
                        saveFileDialog1.Filter = @"|*.txt;*.cs";
                        if (this.Text == Path.GetFileName(openFileDialog1.FileName) + "-记事本")
                            richTextBox1.SaveFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                        else
                            richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                    }
                    rtb = richTextBox1.Text;
                }
                catch { }
            }
            else if (e.KeyCode == Keys.P && e.Modifiers == Keys.Control)
            {
                try
                {
                    printDialog1.Document = printDocument1;
                    if (printDialog1.ShowDialog() == DialogResult.OK)
                    {
                        printDocument1.Print();
                    }
                }
                catch
                {
                    MessageBox.Show("尚未安装打印机！");
                }
            }
        }

        private void richTextBox1_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            Point p = GetCursorPos(this.richTextBox1.Handle.ToInt32());
            this.toolStripStatusLabel1.Text = "第" + p.Y + "行，第" + p.X + "列";
        }

        private void 插入图片ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();   //清空剪贴板  
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "JPG文件(*.jpg)|*.jpg";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fName = openFileDialog1.FileName;
                Bitmap bmp = new Bitmap(fName);  //创建Bitmap类对象
                Clipboard.SetImage(bmp);  //将Bitmap类对象写入剪贴板  
                richTextBox1.Paste();   //将剪贴板中的对象粘贴到RichTextBox1 
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void 全选ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }      
    }
}
