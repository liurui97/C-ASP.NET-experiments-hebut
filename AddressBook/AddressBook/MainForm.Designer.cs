namespace AddressBook
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.informationLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.dateLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.timeLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.用户管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加用户ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.浏览用户ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改用户ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除用户ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.通讯信息管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加通讯信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.浏览通讯信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改通讯信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除通讯信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出系统ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.userIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.passWordDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userinfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.telephoneDataSet2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.telephoneDataSet2 = new AddressBook.telephoneDataSet2();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.personIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sexDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.officeTelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.homeTelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.markDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telephoneinfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.telephoneDataSet1 = new AddressBook.telephoneDataSet1();
            this.userinfoTableAdapter = new AddressBook.telephoneDataSet2TableAdapters.userinfoTableAdapter();
            this.telephoneDataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.telephoneinfoTableAdapter = new AddressBook.telephoneDataSet1TableAdapters.telephoneinfoTableAdapter();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userinfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.telephoneDataSet2BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.telephoneDataSet2)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.telephoneinfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.telephoneDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.telephoneDataSet1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.informationLabel,
            this.dateLabel,
            this.timeLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 475);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(931, 25);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // informationLabel
            // 
            this.informationLabel.Name = "informationLabel";
            this.informationLabel.Size = new System.Drawing.Size(167, 20);
            this.informationLabel.Text = "toolStripStatusLabel1";
            // 
            // dateLabel
            // 
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(167, 20);
            this.dateLabel.Text = "toolStripStatusLabel2";
            // 
            // timeLabel
            // 
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(167, 20);
            this.timeLabel.Text = "toolStripStatusLabel3";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.用户管理ToolStripMenuItem,
            this.通讯信息管理ToolStripMenuItem,
            this.帮助ToolStripMenuItem,
            this.退出系统ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(931, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 用户管理ToolStripMenuItem
            // 
            this.用户管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加用户ToolStripMenuItem,
            this.浏览用户ToolStripMenuItem,
            this.修改用户ToolStripMenuItem,
            this.删除用户ToolStripMenuItem});
            this.用户管理ToolStripMenuItem.Name = "用户管理ToolStripMenuItem";
            this.用户管理ToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.用户管理ToolStripMenuItem.Text = "用户管理";
            // 
            // 添加用户ToolStripMenuItem
            // 
            this.添加用户ToolStripMenuItem.Name = "添加用户ToolStripMenuItem";
            this.添加用户ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.添加用户ToolStripMenuItem.Text = "添加用户";
            this.添加用户ToolStripMenuItem.Click += new System.EventHandler(this.添加用户ToolStripMenuItem_Click);
            // 
            // 浏览用户ToolStripMenuItem
            // 
            this.浏览用户ToolStripMenuItem.Name = "浏览用户ToolStripMenuItem";
            this.浏览用户ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.浏览用户ToolStripMenuItem.Text = "浏览用户";
            this.浏览用户ToolStripMenuItem.Click += new System.EventHandler(this.浏览用户ToolStripMenuItem_Click_1);
            // 
            // 修改用户ToolStripMenuItem
            // 
            this.修改用户ToolStripMenuItem.Name = "修改用户ToolStripMenuItem";
            this.修改用户ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.修改用户ToolStripMenuItem.Text = "修改用户";
            this.修改用户ToolStripMenuItem.Click += new System.EventHandler(this.修改用户ToolStripMenuItem_Click);
            // 
            // 删除用户ToolStripMenuItem
            // 
            this.删除用户ToolStripMenuItem.Name = "删除用户ToolStripMenuItem";
            this.删除用户ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.删除用户ToolStripMenuItem.Text = "删除用户";
            this.删除用户ToolStripMenuItem.Click += new System.EventHandler(this.删除用户ToolStripMenuItem_Click);
            // 
            // 通讯信息管理ToolStripMenuItem
            // 
            this.通讯信息管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加通讯信息ToolStripMenuItem,
            this.浏览通讯信息ToolStripMenuItem,
            this.修改通讯信息ToolStripMenuItem,
            this.删除通讯信息ToolStripMenuItem});
            this.通讯信息管理ToolStripMenuItem.Name = "通讯信息管理ToolStripMenuItem";
            this.通讯信息管理ToolStripMenuItem.Size = new System.Drawing.Size(111, 24);
            this.通讯信息管理ToolStripMenuItem.Text = "通讯信息管理";
            // 
            // 添加通讯信息ToolStripMenuItem
            // 
            this.添加通讯信息ToolStripMenuItem.Name = "添加通讯信息ToolStripMenuItem";
            this.添加通讯信息ToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.添加通讯信息ToolStripMenuItem.Text = "添加通讯信息";
            this.添加通讯信息ToolStripMenuItem.Click += new System.EventHandler(this.添加通讯信息ToolStripMenuItem_Click);
            // 
            // 浏览通讯信息ToolStripMenuItem
            // 
            this.浏览通讯信息ToolStripMenuItem.Name = "浏览通讯信息ToolStripMenuItem";
            this.浏览通讯信息ToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.浏览通讯信息ToolStripMenuItem.Text = "浏览通讯信息";
            this.浏览通讯信息ToolStripMenuItem.Click += new System.EventHandler(this.浏览通讯信息ToolStripMenuItem_Click);
            // 
            // 修改通讯信息ToolStripMenuItem
            // 
            this.修改通讯信息ToolStripMenuItem.Name = "修改通讯信息ToolStripMenuItem";
            this.修改通讯信息ToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.修改通讯信息ToolStripMenuItem.Text = "修改通讯信息";
            this.修改通讯信息ToolStripMenuItem.Click += new System.EventHandler(this.修改通讯信息ToolStripMenuItem_Click);
            // 
            // 删除通讯信息ToolStripMenuItem
            // 
            this.删除通讯信息ToolStripMenuItem.Name = "删除通讯信息ToolStripMenuItem";
            this.删除通讯信息ToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.删除通讯信息ToolStripMenuItem.Text = "删除通讯信息";
            this.删除通讯信息ToolStripMenuItem.Click += new System.EventHandler(this.删除通讯信息ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.帮助ToolStripMenuItem.Text = "帮助";
            this.帮助ToolStripMenuItem.Click += new System.EventHandler(this.帮助ToolStripMenuItem_Click);
            // 
            // 退出系统ToolStripMenuItem
            // 
            this.退出系统ToolStripMenuItem.Name = "退出系统ToolStripMenuItem";
            this.退出系统ToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
            this.退出系统ToolStripMenuItem.Text = "退出系统 ";
            this.退出系统ToolStripMenuItem.Click += new System.EventHandler(this.退出系统ToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 32);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(931, 440);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textBox3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(923, 411);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "用户信息";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(381, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "查找";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(51, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 25);
            this.textBox1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.userIDDataGridViewTextBoxColumn,
            this.userNameDataGridViewTextBoxColumn,
            this.passWordDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.userinfoBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(3, 31);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(917, 377);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDown);
            // 
            // userIDDataGridViewTextBoxColumn
            // 
            this.userIDDataGridViewTextBoxColumn.DataPropertyName = "UserID";
            this.userIDDataGridViewTextBoxColumn.HeaderText = "UserID";
            this.userIDDataGridViewTextBoxColumn.Name = "userIDDataGridViewTextBoxColumn";
            this.userIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // userNameDataGridViewTextBoxColumn
            // 
            this.userNameDataGridViewTextBoxColumn.DataPropertyName = "UserName";
            this.userNameDataGridViewTextBoxColumn.HeaderText = "UserName";
            this.userNameDataGridViewTextBoxColumn.Name = "userNameDataGridViewTextBoxColumn";
            // 
            // passWordDataGridViewTextBoxColumn
            // 
            this.passWordDataGridViewTextBoxColumn.DataPropertyName = "PassWord";
            this.passWordDataGridViewTextBoxColumn.HeaderText = "PassWord";
            this.passWordDataGridViewTextBoxColumn.Name = "passWordDataGridViewTextBoxColumn";
            // 
            // userinfoBindingSource
            // 
            this.userinfoBindingSource.DataMember = "userinfo";
            this.userinfoBindingSource.DataSource = this.telephoneDataSet2BindingSource;
            // 
            // telephoneDataSet2BindingSource
            // 
            this.telephoneDataSet2BindingSource.DataSource = this.telephoneDataSet2;
            this.telephoneDataSet2BindingSource.Position = 0;
            // 
            // telephoneDataSet2
            // 
            this.telephoneDataSet2.DataSetName = "telephoneDataSet2";
            this.telephoneDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.textBox5);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.textBox4);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.button4);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.textBox2);
            this.tabPage2.Controls.Add(this.dataGridView2);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(923, 411);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "通讯信息";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(614, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "查找";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(51, 4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 25);
            this.textBox2.TabIndex = 1;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.personIDDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.sexDataGridViewTextBoxColumn,
            this.officeTelDataGridViewTextBoxColumn,
            this.homeTelDataGridViewTextBoxColumn,
            this.markDataGridViewTextBoxColumn});
            this.dataGridView2.DataSource = this.telephoneinfoBindingSource;
            this.dataGridView2.Location = new System.Drawing.Point(3, 34);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 27;
            this.dataGridView2.Size = new System.Drawing.Size(917, 374);
            this.dataGridView2.TabIndex = 0;
            this.dataGridView2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridView2_MouseDown);
            // 
            // personIDDataGridViewTextBoxColumn
            // 
            this.personIDDataGridViewTextBoxColumn.DataPropertyName = "PersonID";
            this.personIDDataGridViewTextBoxColumn.HeaderText = "PersonID";
            this.personIDDataGridViewTextBoxColumn.Name = "personIDDataGridViewTextBoxColumn";
            this.personIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // sexDataGridViewTextBoxColumn
            // 
            this.sexDataGridViewTextBoxColumn.DataPropertyName = "Sex";
            this.sexDataGridViewTextBoxColumn.HeaderText = "Sex";
            this.sexDataGridViewTextBoxColumn.Name = "sexDataGridViewTextBoxColumn";
            // 
            // officeTelDataGridViewTextBoxColumn
            // 
            this.officeTelDataGridViewTextBoxColumn.DataPropertyName = "OfficeTel";
            this.officeTelDataGridViewTextBoxColumn.HeaderText = "OfficeTel";
            this.officeTelDataGridViewTextBoxColumn.Name = "officeTelDataGridViewTextBoxColumn";
            // 
            // homeTelDataGridViewTextBoxColumn
            // 
            this.homeTelDataGridViewTextBoxColumn.DataPropertyName = "HomeTel";
            this.homeTelDataGridViewTextBoxColumn.HeaderText = "HomeTel";
            this.homeTelDataGridViewTextBoxColumn.Name = "homeTelDataGridViewTextBoxColumn";
            // 
            // markDataGridViewTextBoxColumn
            // 
            this.markDataGridViewTextBoxColumn.DataPropertyName = "Mark";
            this.markDataGridViewTextBoxColumn.HeaderText = "Mark";
            this.markDataGridViewTextBoxColumn.Name = "markDataGridViewTextBoxColumn";
            // 
            // telephoneinfoBindingSource
            // 
            this.telephoneinfoBindingSource.DataMember = "telephoneinfo";
            this.telephoneinfoBindingSource.DataSource = this.telephoneDataSet1;
            // 
            // telephoneDataSet1
            // 
            this.telephoneDataSet1.DataSetName = "telephoneDataSet1";
            this.telephoneDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // userinfoTableAdapter
            // 
            this.userinfoTableAdapter.ClearBeforeFill = true;
            // 
            // telephoneDataSet1BindingSource
            // 
            this.telephoneDataSet1BindingSource.DataSource = this.telephoneDataSet1;
            this.telephoneDataSet1BindingSource.Position = 0;
            // 
            // telephoneinfoTableAdapter
            // 
            this.telephoneinfoTableAdapter.ClearBeforeFill = true;
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(462, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "导出";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(705, 7);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "导出";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "序号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(170, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "用户名";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(243, 3);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 25);
            this.textBox3.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "序号";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(186, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "姓名";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(264, 4);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 25);
            this.textBox4.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(396, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "性别";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(481, 4);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 25);
            this.textBox5.TabIndex = 8;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 500);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "MainForm";
            this.Text = "通讯录管理系统";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userinfoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.telephoneDataSet2BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.telephoneDataSet2)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.telephoneinfoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.telephoneDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.telephoneDataSet1BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel informationLabel;
        private System.Windows.Forms.ToolStripStatusLabel dateLabel;
        private System.Windows.Forms.ToolStripStatusLabel timeLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 用户管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 通讯信息管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加通讯信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 浏览通讯信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出系统ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加用户ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 浏览用户ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改用户ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除用户ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改通讯信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除通讯信息ToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource telephoneDataSet2BindingSource;
        private telephoneDataSet2 telephoneDataSet2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.BindingSource userinfoBindingSource;
        private telephoneDataSet2TableAdapters.userinfoTableAdapter userinfoTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn userIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn passWordDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.BindingSource telephoneDataSet1BindingSource;
        private telephoneDataSet1 telephoneDataSet1;
        private System.Windows.Forms.BindingSource telephoneinfoBindingSource;
        private telephoneDataSet1TableAdapters.telephoneinfoTableAdapter telephoneinfoTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn personIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sexDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn officeTelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn homeTelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn markDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;

    }
}