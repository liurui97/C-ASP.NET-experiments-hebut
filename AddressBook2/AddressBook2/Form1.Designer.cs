namespace AddressBook2
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.用户管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.插入用户信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除用户信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改用户信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.通讯信息管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加通讯信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改通讯信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除通讯信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出系统ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listView2 = new System.Windows.Forms.ListView();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
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
            this.menuStrip1.Size = new System.Drawing.Size(622, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 用户管理ToolStripMenuItem
            // 
            this.用户管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.插入用户信息ToolStripMenuItem,
            this.删除用户信息ToolStripMenuItem,
            this.修改用户信息ToolStripMenuItem});
            this.用户管理ToolStripMenuItem.Name = "用户管理ToolStripMenuItem";
            this.用户管理ToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.用户管理ToolStripMenuItem.Text = "用户管理";
            // 
            // 插入用户信息ToolStripMenuItem
            // 
            this.插入用户信息ToolStripMenuItem.Name = "插入用户信息ToolStripMenuItem";
            this.插入用户信息ToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.插入用户信息ToolStripMenuItem.Text = "插入用户信息";
            this.插入用户信息ToolStripMenuItem.Click += new System.EventHandler(this.插入用户信息ToolStripMenuItem_Click);
            // 
            // 删除用户信息ToolStripMenuItem
            // 
            this.删除用户信息ToolStripMenuItem.Name = "删除用户信息ToolStripMenuItem";
            this.删除用户信息ToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.删除用户信息ToolStripMenuItem.Text = "删除用户信息";
            this.删除用户信息ToolStripMenuItem.Click += new System.EventHandler(this.删除用户信息ToolStripMenuItem_Click);
            // 
            // 修改用户信息ToolStripMenuItem
            // 
            this.修改用户信息ToolStripMenuItem.Name = "修改用户信息ToolStripMenuItem";
            this.修改用户信息ToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.修改用户信息ToolStripMenuItem.Text = "修改用户信息";
            this.修改用户信息ToolStripMenuItem.Click += new System.EventHandler(this.修改用户信息ToolStripMenuItem_Click);
            // 
            // 通讯信息管理ToolStripMenuItem
            // 
            this.通讯信息管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加通讯信息ToolStripMenuItem,
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
            // 
            // 退出系统ToolStripMenuItem
            // 
            this.退出系统ToolStripMenuItem.Name = "退出系统ToolStripMenuItem";
            this.退出系统ToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.退出系统ToolStripMenuItem.Text = "退出系统";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(622, 414);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.listView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(614, 385);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "用户信息";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(109, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "查询";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 25);
            this.textBox1.TabIndex = 1;
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(3, 29);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(608, 353);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            this.listView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDown);
            this.listView1.Resize += new System.EventHandler(this.listView1_Resize);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button4);
            this.tabPage2.Controls.Add(this.listView2);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.textBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(614, 385);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "通讯信息";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // listView2
            // 
            this.listView2.Location = new System.Drawing.Point(0, 34);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(614, 327);
            this.listView2.TabIndex = 2;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView2_MouseDoubleClick);
            this.listView2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listView2_MouseDown);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(111, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "查询";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(4, 4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 25);
            this.textBox2.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3});
            this.statusStrip1.Location = new System.Drawing.Point(0, 417);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(622, 25);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(167, 20);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(167, 20);
            this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(167, 20);
            this.toolStripStatusLabel3.Text = "toolStripStatusLabel3";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(199, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "导出";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(192, 6);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "查询";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 442);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "通讯信息管理系统";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 用户管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 通讯信息管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出系统ToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripMenuItem 插入用户信息ToolStripMenuItem;
        public System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ToolStripMenuItem 删除用户信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改用户信息ToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ToolStripMenuItem 添加通讯信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改通讯信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除通讯信息ToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}

