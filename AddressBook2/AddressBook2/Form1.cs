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
    public partial class MainForm : Form
    {
        int fieldlength;
        int fieldlength2;
        DataSet dataSet = new DataSet();
        DataTable dataTable = new DataTable("userinfo");
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
        public MainForm()
        {
            InitializeComponent();
            //设置初始值
            this.toolStripStatusLabel1.Text = "欢迎使用通讯录";
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //设置计时器
            timer1.Interval = 1000;
            timer1.Start();
            //定义列宽
            fieldlength = this.listView1.Width / 3;
            fieldlength2 = this.listView2.Width / 6;
            bind();
        }


        private void bind()
        {
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.GridLines = true;
            this.listView1.FullRowSelect = true;

            this.listView2.View = System.Windows.Forms.View.Details;
            this.listView2.GridLines = true;
            this.listView2.FullRowSelect = true;

            listView1.Columns.Add("序号", fieldlength, HorizontalAlignment.Left);
            listView1.Columns.Add("用户名", fieldlength, HorizontalAlignment.Left);
            listView1.Columns.Add("密码", fieldlength, HorizontalAlignment.Left);

            listView2.Columns.Add("编号", fieldlength2, HorizontalAlignment.Left);
            listView2.Columns.Add("姓名", fieldlength2, HorizontalAlignment.Left);
            listView2.Columns.Add("性别", fieldlength2, HorizontalAlignment.Left);
            listView2.Columns.Add("办公电话", fieldlength2, HorizontalAlignment.Left);
            listView2.Columns.Add("家庭电话", fieldlength2, HorizontalAlignment.Left);
            listView2.Columns.Add("备注", fieldlength2, HorizontalAlignment.Left);

            //listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            //listView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            string str = "Server=localhost;Database=telephone;UID=sa;PWD=123456";
            SqlConnection conn = new SqlConnection(str);

            string query = "select * from userinfo";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            string query2 = "select * from telephoneinfomation";
            SqlCommand sqlCommand2 = new SqlCommand(query2, conn);

            try
            {
                conn.Open();
                /*sqlDataAdapter.SelectCommand = sqlCommand;
                sqlDataAdapter.Fill(dataSet, "userinfo");
                dataTable = dataSet.Tables["userinfo"];*/
                SqlDataReader rd = sqlCommand.ExecuteReader();
                
                //在ListView中添加数据
                this.listView1.BeginUpdate();
                //foreach (DataRow dataRow in dataTable.Rows)
                while(rd.Read())
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = rd["UserID"].ToString().Trim();
                    lvi.SubItems.Add(rd["UserName"].ToString().Trim());
                    lvi.SubItems.Add(rd["PassWord"].ToString().Trim());
                    this.listView1.Items.Insert(this.listView1.Items.Count, lvi);
                }
                this.listView1.EndUpdate();
                rd.Close();
                SqlDataReader rd2 = sqlCommand2.ExecuteReader();
                //rd = sqlCommand2.ExecuteReader();
                this.listView2.BeginUpdate();
                while (rd2.Read())
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = rd2["PersonID"].ToString();
                    lvi.SubItems.Add(rd2["Name"].ToString().Trim());
                    lvi.SubItems.Add(rd2["Sex"].ToString().Trim());
                    lvi.SubItems.Add(rd2["OfficeTel"].ToString().Trim());
                    lvi.SubItems.Add(rd2["HomeTel"].ToString().Trim());
                    lvi.SubItems.Add(rd2["Mark"].ToString().Trim());
                    this.listView2.Items.Insert(this.listView2.Items.Count, lvi);
                }
                this.listView2.EndUpdate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        
        private void listView1_Resize(object sender, EventArgs e)
        {
            fieldlength = 0;
            if (WindowState == FormWindowState.Maximized)
            {
                this.listView1.Clear();
                this.listView2.Clear();
                fieldlength = this.Size.Width / 3;
                fieldlength2 = this.Size.Width / 6;
                bind();
               
            }
            /*else if (WindowState == FormWindowState.Normal)
            {
                if(listView1!=null)
                    this.listView1.Clear();
                fieldlength = this.listView1.Width / 3;
                bind();
            }*/
            else
            {
                return;
            }
        }

        private void 插入用户信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.form1 = this;
            form2.ShowDialog();
        }

        public void Insert(ListViewItem lvi)
        {
            int count = this.listView1.Items.Count;
            listView1.Items.Insert(this.listView1.Items.Count, lvi);
            listView1.Items[count].BackColor = Color.Red;

            listView1.Refresh();
        }
        public void Insert2(ListViewItem lvi)
        {
            int count = this.listView2.Items.Count;
            listView2.Items.Insert(this.listView2.Items.Count, lvi);
            listView2.Items[count].BackColor = Color.Red;

            listView2.Refresh();
        }

        private void 删除用户信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选中要删除的行!");
                return;
            }
            DialogResult result = MessageBox.Show("确认要删除吗?", "提示", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                string str = "Server=localhost;Database=telephone;UID=sa;PWD=123456";
                SqlConnection conn = new SqlConnection(str);
                string query;
                //string query = "delete from userinfo where UserID=" + Convert.ToInt32(listView1.SelectedItems[0].Text) + "";
                conn.Open();
                SqlCommand comm;
                this.listView1.BeginUpdate();
                foreach (ListViewItem lvi in listView1.SelectedItems)
                {
                    listView1.Items.RemoveAt(lvi.Index);
                    query = "delete from userinfo where UserID=" + Convert.ToInt32(lvi.Text.Trim()) + "";
                    comm = new SqlCommand(query, conn);
                    comm.ExecuteNonQuery();
                }
                this.listView1.EndUpdate();
                conn.Close();
            }
        }

        private void 修改用户信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选择需要修改的行!");
                return;
            }
            listView1.SelectedItems[0].BackColor = Color.Red;
            Form3 form3 = new Form3();
            form3.form1 = this;
            ListViewItem lvi = listView1.SelectedItems[0];
            {
                form3.UserName = lvi.SubItems[1].Text;
                form3.PassWord = lvi.SubItems[2].Text;
                form3.UserID = Convert.ToInt32(lvi.Text);
            }
            form3.ShowDialog();
        }

        public void Modify(ListViewItem lvi)
        {
            ListViewItem foundItem = listView1.FindItemWithText(lvi.Text, true, 0);
            if (foundItem != null)
            {
                this.listView1.BeginUpdate();
                int index = foundItem.Index;
                this.listView1.Items.RemoveAt(index);
                this.listView1.Items.Insert(index,lvi);
                this.listView1.EndUpdate();
            }
        }
        public void Modify2(ListViewItem lvi)
        {
            ListViewItem foundItem = listView2.FindItemWithText(lvi.Text, true, 0);
            if (foundItem != null)
            {
                this.listView2.BeginUpdate();
                int index = foundItem.Index;
                this.listView2.Items.RemoveAt(index);
                this.listView2.Items.Insert(index, lvi);
                this.listView2.EndUpdate();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = this.textBox1.Text;
            Find(query);
        }

        public void Find(string query)
        {
            ListViewItem foundItem = listView1.FindItemWithText(query, true, 0);
            if (foundItem != null)
            {
                this.listView1.TopItem = foundItem;
                foundItem.ForeColor = Color.Red;
            }
        }

        public void Find2(string query)
        {
            ListViewItem foundItem = listView2.FindItemWithText(query, true, 0);
            if (foundItem != null)
            {
                this.listView2.TopItem = foundItem;
                foundItem.ForeColor = Color.Red;
            }
        }
        private void 添加通讯信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.form1 = this;
            form4.ShowDialog();
        }

        private void 修改通讯信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选中要修改的行!");
                return;
            }
            listView2.SelectedItems[0].BackColor = Color.Red;
            Form5 form5 = new Form5();
            form5.form1 = this;
            ListViewItem lvi = this.listView2.SelectedItems[0];
            {
                form5.PersonID = Convert.ToInt32(lvi.Text);
                form5.Name = lvi.SubItems[1].Text;
                form5.Sex = lvi.SubItems[2].Text;
                form5.OfficeTel = lvi.SubItems[3].Text;
                form5.HomeTel = lvi.SubItems[4].Text;
                form5.Mark = lvi.SubItems[5].Text;
            }
            form5.ShowDialog();
        }

        private void 删除通讯信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listView2.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选中要删除的行!");
                return;
            }
            DialogResult result = MessageBox.Show("是否确认删除?", "提示", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                string str = "Server=localhost;Database=telephone;UID=sa;PWD=123456";
                SqlConnection conn = new SqlConnection(str);
                string query;
                //string query = "delete from userinfo where UserID=" + Convert.ToInt32(listView1.SelectedItems[0].Text) + "";
                conn.Open();
                SqlCommand comm;
                this.listView2.BeginUpdate();
                foreach (ListViewItem lvi in listView2.SelectedItems)
                {
                    listView2.Items.RemoveAt(lvi.Index);
                    query = "delete from telephoneinfomation where UserID=" + Convert.ToInt32(lvi.Text.Trim()) + "";
                    comm = new SqlCommand(query, conn);
                    comm.ExecuteNonQuery();
                }
                this.listView2.EndUpdate();
                conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = this.textBox2.Text;
            Find2(query);
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选择需要修改的行!");
                return;
            }
            listView1.SelectedItems[0].BackColor = Color.Red;
            Form3 form3 = new Form3();
            form3.form1 = this;
            ListViewItem lvi = listView1.SelectedItems[0];
            {
                form3.UserName = lvi.SubItems[1].Text;
                form3.PassWord = lvi.SubItems[2].Text;
                form3.UserID = Convert.ToInt32(lvi.Text);
            }
            form3.ShowDialog();
        }

        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (this.listView1.SelectedItems.Count == 0)
                {
                    MessageBox.Show("请选中要删除的行!");
                    return;
                }
                DialogResult result = MessageBox.Show("确认要删除吗?", "提示", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    string str = "Server=localhost;Database=telephone;UID=sa;PWD=123456";
                    SqlConnection conn = new SqlConnection(str);
                    string query;
                    //string query = "delete from userinfo where UserID=" + Convert.ToInt32(listView1.SelectedItems[0].Text) + "";
                    conn.Open();
                    SqlCommand comm;
                    this.listView1.BeginUpdate();
                    foreach (ListViewItem lvi in listView1.SelectedItems)
                    {
                        listView1.Items.RemoveAt(lvi.Index);
                        query = "delete from userinfo where UserID=" + Convert.ToInt32(lvi.Text.Trim()) + "";
                        comm = new SqlCommand(query, conn);
                        comm.ExecuteNonQuery();
                    }
                    this.listView1.EndUpdate();
                    conn.Close();
                }
            }
        }

        //用户显示时间、日期
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.toolStripStatusLabel2.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
            this.toolStripStatusLabel3.Text = System.DateTime.Now.ToString("hh:mm:ss");
        }

        //双击事件
        private void listView2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView2.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选中要修改的行!");
                return;
            }
            listView2.SelectedItems[0].BackColor = Color.Red;
            Form5 form5 = new Form5();
            form5.form1 = this;
            ListViewItem lvi = this.listView2.SelectedItems[0];
            {
                form5.PersonID = Convert.ToInt32(lvi.Text);
                form5.Name = lvi.SubItems[1].Text;
                form5.Sex = lvi.SubItems[2].Text;
                form5.OfficeTel = lvi.SubItems[3].Text;
                form5.HomeTel = lvi.SubItems[4].Text;
                form5.Mark = lvi.SubItems[5].Text;
            }
            form5.ShowDialog();
        }

        //单击事件
        private void listView2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (this.listView2.SelectedItems.Count == 0)
                {
                    MessageBox.Show("请选中要删除的行!");
                    return;
                }
                DialogResult result = MessageBox.Show("是否确认删除?", "提示", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    string str = "Server=localhost;Database=telephone;UID=sa;PWD=123456";
                    SqlConnection conn = new SqlConnection(str);
                    string query;
                    //string query = "delete from userinfo where UserID=" + Convert.ToInt32(listView1.SelectedItems[0].Text) + "";
                    conn.Open();
                    SqlCommand comm;
                    this.listView2.BeginUpdate();
                    foreach (ListViewItem lvi in listView2.SelectedItems)
                    {
                        listView2.Items.RemoveAt(lvi.Index);
                        query = "delete from telephoneinfomation where UserID=" + Convert.ToInt32(lvi.Text.Trim()) + "";
                        comm = new SqlCommand(query, conn);
                        comm.ExecuteNonQuery();
                    }
                    this.listView2.EndUpdate();
                    conn.Close();
                }
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = "xls";
            sfd.Filter = "Excel文件(*.xls)|*.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                DoExport(this.listView1, sfd.FileName);
            }
        }

        private void DoExport(ListView listView, string strFileName)
        {
            int rowNum = listView.Items.Count;
            int columnNum = listView.Items[0].SubItems.Count;
            int rowIndex = 1;
            int columnIndex = 0;
            if (rowNum == 0 || string.IsNullOrEmpty(strFileName))
            {
                return;
            }
            if (rowNum > 0)
            {

                Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.ApplicationClass();
                if (xlApp == null)
                {
                    MessageBox.Show("无法创建excel对象，可能您的系统没有安装excel");
                    return;
                }
                xlApp.DefaultFilePath = "";
                xlApp.DisplayAlerts = true;
                xlApp.SheetsInNewWorkbook = 1;
                Microsoft.Office.Interop.Excel.Workbook xlBook = xlApp.Workbooks.Add(true);
                //将ListView的列名导入Excel表第一行
                foreach (ColumnHeader dc in listView.Columns)
                {
                    columnIndex++;
                    xlApp.Cells[rowIndex, columnIndex] = dc.Text;
                }
                //将ListView中的数据导入Excel中
                for (int i = 0; i < rowNum; i++)
                {
                    rowIndex++;
                    columnIndex = 0;
                    for (int j = 0; j < columnNum; j++)
                    {
                        columnIndex++;
                        //注意这个在导出的时候加了“\t” 的目的就是避免导出的数据显示为科学计数法。可以放在每行的首尾。
                        xlApp.Cells[rowIndex, columnIndex] = Convert.ToString(listView.Items[i].SubItems[j].Text) + "\t";
                    }
                }
                //例外需要说明的是用strFileName,Excel.XlFileFormat.xlExcel9795保存方式时 当你的Excel版本不是95、97 而是2003、2007 时导出的时候会报一个错误：异常来自 HRESULT:0x800A03EC。 解决办法就是换成strFileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal。
                xlBook.SaveAs(strFileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                xlApp = null;
                xlBook = null;
                MessageBox.Show("导出成功!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = "xls";
            sfd.Filter = "Excel文件(*.xls)|*.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                DoExport(this.listView2, sfd.FileName);
            }
        }
    }
}
