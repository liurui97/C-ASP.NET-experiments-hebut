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

namespace AddressBook
{
    public partial class MainForm : Form
    {
        /*捕捉鼠标的双击事件*/
        private bool isFirstClick = true;
        private bool isDoubleClick = false;
        private int milliseconds = 0;
        private Rectangle hitTestRectangle = new Rectangle();
        private Rectangle doubleClickRectangle = new Rectangle();

        /*第二个表格的双击事件中使用*/
        private bool isFirstClick1 = true;
        private bool isDoubleClick1 = false;
        private int milliseconds1 = 0;
        private Rectangle hitTestRectangle1 = new Rectangle();
        private Rectangle doubleClickRectangle1 = new Rectangle();

        public AddUserForm auf;
        public ModifyUserForm modifyuserform;
        public ModifyForm modifyform;

        DataSet dataSet = new DataSet();
        DataTable dataTable = new DataTable();
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();

        string sqlString = "Server=localhost;Database=telephone;UID=sa;PWD=123456";

        public MainForm()
        {
            InitializeComponent();
            this.informationLabel.Text = "欢迎使用通讯录";

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // TODO:  这行代码将数据加载到表“telephoneDataSet1.telephoneinfo”中。您可以根据需要移动或删除它。
            //this.telephoneinfoTableAdapter.Fill(this.telephoneDataSet1.telephoneinfo);
            // TODO:  这行代码将数据加载到表“telephoneDataSet2.userinfo”中。您可以根据需要移动或删除它。
            //this.userinfoTableAdapter.Fill(this.telephoneDataSet2.userinfo);

            //第一个表
            SqlConnection conn = new SqlConnection(sqlString);
            string query = "select * from userinfo";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            //第二个表
            string query2 = "select * from telephoneinfo";
            SqlCommand sqlCommand2 = new SqlCommand(query2, conn);

            try
            {
                conn.Open();
                sqlDataAdapter.SelectCommand = sqlCommand;
                sqlDataAdapter.Fill(dataSet, "userinfo");

                sqlDataAdapter.SelectCommand = sqlCommand2;
                sqlDataAdapter.Fill(dataSet, "telephoneinfo");

                //dataSet.Tables["userinfo"].PrimaryKey = dataSet.Tables["userinfo"].Column["UerID"];
                //填充dataGridView1
                this.dataGridView1.DataSource = dataSet.Tables[0];
                this.dataGridView1.AutoGenerateColumns = true;
                this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                this.dataGridView1.MultiSelect = false;
                this.dataGridView1.BackgroundColor = Color.Honeydew;
                this.dataGridView1.Dock = DockStyle.Fill;
                this.dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
                this.dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
                this.dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
                this.dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.GridColor = SystemColors.ActiveBorder;

                //填充到2
                this.dataGridView2.DataSource = dataSet.Tables[1];
                this.dataGridView2.AutoGenerateColumns = true;
                this.dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                this.dataGridView2.MultiSelect = false;
                this.dataGridView2.BackgroundColor = Color.Honeydew;
                this.dataGridView2.Dock = DockStyle.Fill;
                this.dataGridView2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
                this.dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
                this.dataGridView2.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
                this.dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView2.GridColor = SystemColors.ActiveBorder;

                //设置宽度自适应1
                int width = 0;
                for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
                {
                    this.dataGridView1.AutoResizeColumn(i, DataGridViewAutoSizeColumnMode.AllCells);
                    width += this.dataGridView1.Columns[i].Width;
                    //dataGridView1.Columns[i].DefaultCellStyle.Font=new Font(MyDataGridView.)
                    dataGridView1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                if (width > this.dataGridView1.Size.Width)
                {
                    this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                }
                else
                {
                    this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }

                //设置宽度自适应2
                width = 0;
                for (int i = 0; i < this.dataGridView2.Columns.Count; i++)
                {
                    this.dataGridView2.AutoResizeColumn(i, DataGridViewAutoSizeColumnMode.AllCells);
                    width += this.dataGridView2.Columns[i].Width;
                    //dataGridView1.Columns[i].DefaultCellStyle.Font=new Font(MyDataGridView.)
                    dataGridView2.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                if (width > this.dataGridView2.Size.Width)
                {
                    this.dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                }
                else
                {
                    this.dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }



            timer1.Interval = 1000;
            timer1.Start();
            Load load = new Load();
            load.ShowDialog();
            if ((int)load.Tag == 0)
            {
                this.Close();
            }
        }

        //在状态栏中显示时间
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            this.dateLabel.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
            this.timeLabel.Text = System.DateTime.Now.ToString("hh:mm:ss");
        }

        private void 添加用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            auf = new AddUserForm();
            auf.mainform1 = this;
            auf.ShowDialog();
        }
        private void 浏览用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*ViewUserForm vuf = new ViewUserForm();
            vuf.ShowDialog();*/
        }

        private void 帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpForm hf = new HelpForm();
            hf.ShowDialog();
        }

        private void 退出系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 添加通讯信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddForm af = new AddForm();
            af.mainform2 = this;
            af.ShowDialog();
        }

        private void 浏览通讯信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*ViewInfoForm vif = new ViewInfoForm();
            vif.ShowDialog();*/
        }

        private void 浏览用户ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
        public void InsertTelephoneinfo(string Name, string Sex, string OfficeTel, string HomeTel, string Mark)
        {
            int rowcount = this.dataGridView2.Rows.Count;
            //连接数据库
            string str = "Server=localhost;Database=telephone;UID=sa;PWD=123456";
            SqlConnection conn = new SqlConnection(str);
            string query = "select * from telephoneinfo";
            SqlDataAdapter da = new SqlDataAdapter(query, conn); 
            conn.Open();
            //执行插入语句
            string str1 = "insert into telephoneinfo(Name, Sex, OfficeTel,HomeTel,Mark) values ('" + Name + "','" + Sex + "','" + OfficeTel + "','" + HomeTel + "','" + Mark + "')";
            da.InsertCommand = new SqlCommand(str1, conn);
            //新增一行
            DataRow row = dataSet.Tables["telephoneinfo"].NewRow();
            //将内容放入DataSet中
            row["PersonID"] = rowcount + 1;
            row["Name"] = Name;
            row["Sex"] = Sex;
            row["OfficeTel"] = OfficeTel;
            row["HomeTel"] = HomeTel;
            row["Mark"] = Mark;

            //更新显示内容
            dataSet.Tables["telephoneinfo"].Rows.Add(row);
            da.Update(dataSet, "telephoneinfo");
            dataSet.Tables["telephoneinfo"].AcceptChanges();

            this.dataGridView2.Rows[this.dataGridView1.Rows.Count - 2].Selected = true;
            this.dataGridView2.FirstDisplayedScrollingRowIndex = this.dataGridView1.Rows.Count - 2;
            conn.Close();
        }

        public void InsertUserinfo(string UserName, string PassWord)
        {
            int rowcount = this.dataGridView1.Rows.Count;
            //连接数据库
            string str = "Server=localhost;Database=telephone;UID=sa;PWD=123456";
            SqlConnection conn = new SqlConnection(str);
            string query = "select * from userinfo";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            conn.Open();
            //执行插入语句
            string str1 = "insert into userinfo(UserName,PassWord) values ('" + UserName + "','" + PassWord +  "')";
            da.InsertCommand = new SqlCommand(str1, conn);
            //新增一行
            DataRow row = dataSet.Tables["userinfo"].NewRow();
            //将内容放入DataSet中
            row["UserID"] = rowcount + 1;
            row["UserName"] = UserName;
            row["PassWord"] = PassWord;

            //更新显示内容
            dataSet.Tables["userinfo"].Rows.Add(row);
            da.Update(dataSet, "userinfo");
            dataSet.Tables["userinfo"].AcceptChanges();

            this.dataGridView1.Rows[this.dataGridView1.Rows.Count - 2].Selected = true;
            this.dataGridView1.FirstDisplayedScrollingRowIndex = this.dataGridView1.Rows.Count - 2;
            conn.Close();
        }

        public void ModifyUserInfo(string UserID,string UserName,string PassWord)
        {
            //连接数据库
            string str="Server=localhost;Database=telephone;UID=sa;PWD=123456";
            SqlConnection conn=new SqlConnection(str);
            string query = "select * from userinfo";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            conn.Open();
            string str1 = "update userinfo set UserName='" + UserName + "',PassWord='" + PassWord + "' where UserID='" + UserID + "'";
            da.UpdateCommand = new SqlCommand(str1, conn);

            for (int i = 0; i < dataSet.Tables["userinfo"].Rows.Count; i++)
            {
                if (dataSet.Tables["userinfo"].Rows[i][0].ToString().Equals(UserID))
                {
                    dataSet.Tables["userinfo"].Rows[i][1] = UserName;
                    dataSet.Tables["userinfo"].Rows[i][2] = PassWord;
                }
            }
            da.Update(dataSet, "userinfo");
            dataSet.Tables["userinfo"].AcceptChanges();
            conn.Close();
        }

        public void ModifyTelephoneInfo(string PersonID, string Name, string Sex, string OfficeTel, string HomeTel, string Mark)
        {
            string str = "Server=localhost;Database=telephone;UID=sa;PWD=123456";
            SqlConnection conn = new SqlConnection(str);
            string query = "select * from telephoneinfo";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            conn.Open();
            string str1 = "update telephoneinfo set Name='" + Name + "',Sex='" + Sex + "',OfficeTel='"+OfficeTel+"' ,HomeTel='"+HomeTel+"',Mark='"+Mark+"' where PersonID='" + PersonID + "'";
            da.UpdateCommand = new SqlCommand(str1, conn);

            for (int i = 0; i < dataSet.Tables["telephoneinfo"].Rows.Count; i++)
            {
                if (dataSet.Tables["telephoneinfo"].Rows[i][0].ToString().Equals(PersonID))
                {
                    dataSet.Tables["telephoneinfo"].Rows[i][1] = Name;
                    dataSet.Tables["telephoneinfo"].Rows[i][2] = Sex;
                    dataSet.Tables["telephoneinfo"].Rows[i][3] = OfficeTel;
                    dataSet.Tables["telephoneinfo"].Rows[i][4] = HomeTel;
                    dataSet.Tables["telephoneinfo"].Rows[i][5] = Mark;
                }
            }
            da.Update(dataSet, "telephoneinfo");
            dataSet.Tables["telephoneinfo"].AcceptChanges();
            conn.Close();
        }
        private void 修改用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            modifyuserform = new ModifyUserForm();
            modifyuserform.mainform3 = this;
            {
                modifyuserform.UserID = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                modifyuserform.UserName = (dataGridView1.SelectedRows[0].Cells[1].Value as string);
                modifyuserform.PassWord= (dataGridView1.SelectedRows[0].Cells[2].Value as string);
            }
            this.dataGridView1.Rows[this.dataGridView1.Rows.Count - 2].Selected = true;
            this.dataGridView1.FirstDisplayedScrollingRowIndex = this.dataGridView1.Rows.Count - 2;
            modifyuserform.ShowDialog();
        }

        private void 修改通讯信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            modifyform = new ModifyForm();
            modifyform.mainform4 = this;
            {
                modifyform.PersonID = (int)dataGridView2.SelectedRows[0].Cells[0].Value;
                modifyform.Name = (dataGridView2.SelectedRows[0].Cells[1].Value as string);
                modifyform.Sex = (dataGridView2.SelectedRows[0].Cells[2].Value as string);
                modifyform.OfficeTel = (dataGridView2.SelectedRows[0].Cells[3].Value as string);
                modifyform.HomeTel = (dataGridView2.SelectedRows[0].Cells[4].Value as string);
                modifyform.Mark = (dataGridView2.SelectedRows[0].Cells[5].Value as string);
            }
            this.dataGridView2.Rows[this.dataGridView2.Rows.Count - 2].Selected = true;
            this.dataGridView2.FirstDisplayedScrollingRowIndex = this.dataGridView1.Rows.Count - 2;
            modifyform.ShowDialog();
        }

        private void 删除用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID=0;
            int iCount = dataGridView1.SelectedRows.Count;
            if (iCount < 1)
            {
                MessageBox.Show("删除失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (DialogResult.Yes == MessageBox.Show("是否删除选中数据？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
            {
                for (int i = 0; i < this.dataGridView1.Rows.Count - 1; i++)
                {
                    if (true == this.dataGridView1.Rows[i].Selected)
                    {
                        UserID = (int)dataGridView1.Rows[i].Cells[0].Value;
                        this.dataGridView1.Rows.RemoveAt(i);
                    }
                }
                string str = "Server=localhost;Database=telephone;UID=sa;PWD=123456";
                SqlConnection conn = new SqlConnection(str);
                string query = "select * from userinfo";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                conn.Open();
                string str1 = "delete from userinfo where UserID=" + UserID + "";
                da.DeleteCommand = new SqlCommand(str1, conn);
                da.Update(dataSet, "userinfo");
            }
        }

        private void 删除通讯信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = 0;
            int iCount = dataGridView2.SelectedRows.Count;
            if (iCount < 1)
            {
                MessageBox.Show("删除失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (DialogResult.Yes == MessageBox.Show("是否删除选中数据？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
            {
                for (int i = 0; i < this.dataGridView2.Rows.Count - 1; i++)
                {
                    if (true == this.dataGridView2.Rows[i].Selected)
                    {
                        PersonID = (int)dataGridView2.Rows[i].Cells[0].Value;
                        this.dataGridView2.Rows.RemoveAt(i);
                    }
                }
                string str = "Server=localhost;Database=telephone;UID=sa;PWD=123456";
                SqlConnection conn = new SqlConnection(str);
                string query = "select * from telephoneinfo";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                conn.Open();
                string str1 = "delete from telephoneinfo where PersonID=" + PersonID + "";
                da.DeleteCommand = new SqlCommand(str1, conn);
                da.Update(dataSet, "telephoneinfo");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {          
            if (this.textBox1.Text != "")
            {
                //第一个表
                SqlConnection conn = new SqlConnection(sqlString);
                string query = "select * from userinfo where UserID=" + Convert.ToInt32(this.textBox1.Text.ToString());
                SqlCommand sqlCommand = new SqlCommand(query, conn);

                conn.Open();
                sqlDataAdapter.SelectCommand = sqlCommand;
                sqlDataAdapter.Fill(dataSet, "userinfosearch");

                this.dataGridView1.DataSource = dataSet.Tables["userinfosearch"];
                conn.Close();
            }
            else if (this.textBox3.Text != "")
            {
                //第一个表
                SqlConnection conn = new SqlConnection(sqlString);
                string query = "select * from userinfo where UserName='" + this.textBox3.Text.ToString()+"'";
                SqlCommand sqlCommand = new SqlCommand(query, conn);

                conn.Open();
                sqlDataAdapter.SelectCommand = sqlCommand;
                sqlDataAdapter.Fill(dataSet, "userinfosearch");

                this.dataGridView1.DataSource = dataSet.Tables["userinfosearch"];
                conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(sqlString);
            if (this.textBox2.Text != "")
            {
                string query = "select * from telephoneinfo where PersonID=" + Convert.ToInt32(this.textBox2.Text.ToString());
                SqlCommand sqlCommand = new SqlCommand(query, conn);

                conn.Open();
                sqlDataAdapter.SelectCommand = sqlCommand;
                sqlDataAdapter.Fill(dataSet, "telephoneinfosearch");

                this.dataGridView2.DataSource = dataSet.Tables["telephoneinfosearch"];
                conn.Close();
            }
            else if (this.textBox4.Text != "")
            {
                //string query = "select * from telephoneinfo where Name='" + this.textBox4.Text.ToString()+"'";
                string query = "select * from telephoneinfo where cast(Name as varchar(255))='" + this.textBox4.Text.ToString() + "'";
                SqlCommand sqlCommand = new SqlCommand(query, conn);

                conn.Open();
                sqlDataAdapter.SelectCommand = sqlCommand;
                sqlDataAdapter.Fill(dataSet, "telephoneinfosearch");

                this.dataGridView2.DataSource = dataSet.Tables["telephoneinfosearch"];
                conn.Close();
            }
            else if (this.textBox5.Text != "")
            {
                string query = "select * from telephoneinfo where cast(Sex as varchar(255))='" + this.textBox5.Text.ToString() + "'";
                SqlCommand sqlCommand = new SqlCommand(query, conn);

                conn.Open();
                sqlDataAdapter.SelectCommand = sqlCommand;
                sqlDataAdapter.Fill(dataSet, "telephoneinfosearch");

                this.dataGridView2.DataSource = dataSet.Tables["telephoneinfosearch"];
                conn.Close();
            }
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int UserID = 0;
                int iCount = dataGridView1.SelectedRows.Count;
                if (iCount < 1)
                {
                    MessageBox.Show("删除失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (DialogResult.Yes == MessageBox.Show("是否删除选中数据？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                {
                    for (int i = 0; i < this.dataGridView1.Rows.Count - 1; i++)
                    {
                        if (true == this.dataGridView1.Rows[i].Selected)
                        {
                            UserID = (int)dataGridView1.Rows[i].Cells[0].Value;
                            this.dataGridView1.Rows.RemoveAt(i);
                        }
                    }
                    string str = "Server=localhost;Database=telephone;UID=sa;PWD=123456";
                    SqlConnection conn = new SqlConnection(str);
                    string query = "select * from userinfo";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    conn.Open();
                    string str1 = "delete from userinfo where UserID=" + UserID + "";
                    da.DeleteCommand = new SqlCommand(str1, conn);
                    da.Update(dataSet, "userinfo");
                }
            }
            else if (e.Button == MouseButtons.Left)
            {
                if (isFirstClick)
                {
                    isFirstClick = false;

                    // Determine the location and size of the double click 
                    // rectangle area to draw around the cursor point.
                    doubleClickRectangle = new Rectangle(
                        e.X - (SystemInformation.DoubleClickSize.Width / 2),
                        e.Y - (SystemInformation.DoubleClickSize.Height / 2),
                        SystemInformation.DoubleClickSize.Width,
                        SystemInformation.DoubleClickSize.Height);
                    Invalidate();

                    // Start the double click timer.
                    timer2.Start();
                }

            // This is the second mouse click.
                else
                {
                    // Verify that the mouse click is within the double click
                    // rectangle and is within the system-defined double 
                    // click period.
                    if (doubleClickRectangle.Contains(e.Location) &&
                        milliseconds < SystemInformation.DoubleClickTime)
                    {
                        isDoubleClick = true;
                    }
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
             milliseconds += 100;           
 
            // The timer has reached the double click time limit.
            if (milliseconds >= SystemInformation.DoubleClickTime)
            {
                timer2.Stop();
                if (isDoubleClick)
                {
                    //textBox1.AppendText("Perform double click action");
                    //textBox1.AppendText(Environment.NewLine);
                    //MessageBox.Show("double click action ", "message:", MessageBoxButtons.OK);
                    modifyuserform = new ModifyUserForm();
                    modifyuserform.mainform3 = this;
                    {
                        modifyuserform.UserID = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                        modifyuserform.UserName = (dataGridView1.SelectedRows[0].Cells[1].Value as string);
                        modifyuserform.PassWord = (dataGridView1.SelectedRows[0].Cells[2].Value as string);
                    }
                    this.dataGridView1.Rows[this.dataGridView1.Rows.Count - 2].Selected = true;
                    this.dataGridView1.FirstDisplayedScrollingRowIndex = this.dataGridView1.Rows.Count - 2;
                    modifyuserform.ShowDialog();
                }
                else
                {
                    //textBox1.AppendText("Perform single click action");
                    //textBox1.AppendText(Environment.NewLine);
                    //MessageBox.Show( "single click action ", "message:",MessageBoxButtons.OK);
                }
 
                // Allow the MouseDown event handler to process clicks again.
                isFirstClick = true;
                isDoubleClick = false;
                milliseconds = 0;
                
            }
        }

        private void dataGridView2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int PersonID = 0;
                int iCount = dataGridView2.SelectedRows.Count;
                if (iCount < 1)
                {
                    MessageBox.Show("删除失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (DialogResult.Yes == MessageBox.Show("是否删除选中数据？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                {
                    for (int i = 0; i < this.dataGridView2.Rows.Count - 1; i++)
                    {
                        if (true == this.dataGridView2.Rows[i].Selected)
                        {
                            PersonID = (int)dataGridView2.Rows[i].Cells[0].Value;
                            this.dataGridView2.Rows.RemoveAt(i);
                        }
                    }
                    string str = "Server=localhost;Database=telephone;UID=sa;PWD=123456";
                    SqlConnection conn = new SqlConnection(str);
                    string query = "select * from telephoneinfo";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    conn.Open();
                    string str1 = "delete from telephoneinfo where PersonID=" + PersonID + "";
                    da.DeleteCommand = new SqlCommand(str1, conn);
                    da.Update(dataSet, "telephoneinfo");
                }
            }
            else if (e.Button == MouseButtons.Left)
            {
                if (isFirstClick)
                {
                    isFirstClick = false;

                    // Determine the location and size of the double click 
                    // rectangle area to draw around the cursor point.
                    doubleClickRectangle = new Rectangle(
                        e.X - (SystemInformation.DoubleClickSize.Width / 2),
                        e.Y - (SystemInformation.DoubleClickSize.Height / 2),
                        SystemInformation.DoubleClickSize.Width,
                        SystemInformation.DoubleClickSize.Height);
                    Invalidate();

                    // Start the double click timer.
                    timer3.Start();
                }

            // This is the second mouse click.
                else
                {
                    // Verify that the mouse click is within the double click
                    // rectangle and is within the system-defined double 
                    // click period.
                    if (doubleClickRectangle.Contains(e.Location) &&
                        milliseconds < SystemInformation.DoubleClickTime)
                    {
                        isDoubleClick = true;
                    }
                }
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            milliseconds += 100;

            // The timer has reached the double click time limit.
            if (milliseconds >= SystemInformation.DoubleClickTime)
            {
                timer3.Stop();
                if (isDoubleClick)
                {
                    //textBox1.AppendText("Perform double click action");
                    //textBox1.AppendText(Environment.NewLine);
                    //MessageBox.Show("double click action ", "message:", MessageBoxButtons.OK);
                    modifyform = new ModifyForm();
                    modifyform.mainform4 = this;
                    {
                        modifyform.PersonID = (int)dataGridView2.SelectedRows[0].Cells[0].Value;
                        modifyform.Name = (dataGridView2.SelectedRows[0].Cells[1].Value as string);
                        modifyform.Sex = (dataGridView2.SelectedRows[0].Cells[2].Value as string);
                        modifyform.OfficeTel = (dataGridView2.SelectedRows[0].Cells[3].Value as string);
                        modifyform.HomeTel = (dataGridView2.SelectedRows[0].Cells[4].Value as string);
                        modifyform.Mark = (dataGridView2.SelectedRows[0].Cells[5].Value as string);
                    }
                    this.dataGridView2.Rows[this.dataGridView2.Rows.Count - 2].Selected = true;
                    this.dataGridView2.FirstDisplayedScrollingRowIndex = this.dataGridView1.Rows.Count - 2;
                    modifyform.ShowDialog();
                }
                else
                {
                    //textBox1.AppendText("Perform single click action");
                    //textBox1.AppendText(Environment.NewLine);
                    //MessageBox.Show( "single click action ", "message:",MessageBoxButtons.OK);
                }

                // Allow the MouseDown event handler to process clicks again.
                isFirstClick = true;
                isDoubleClick = false;
                milliseconds = 0;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ExportToExcel d = new ExportToExcel();
            d.OutputAsExcelFile(dataGridView1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ExportToExcel d = new ExportToExcel();
            d.OutputAsExcelFile(dataGridView2);
        }
    }
}
