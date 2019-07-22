namespace AddressBook
{
    partial class Load
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.TextBox();
            this.PWD = new System.Windows.Forms.TextBox();
            this.login = new System.Windows.Forms.Button();
            this.tuichu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(118, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(118, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "密码";
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(269, 80);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(100, 25);
            this.name.TabIndex = 2;
            // 
            // PWD
            // 
            this.PWD.Location = new System.Drawing.Point(269, 146);
            this.PWD.Name = "PWD";
            this.PWD.Size = new System.Drawing.Size(100, 25);
            this.PWD.TabIndex = 3;
            // 
            // login
            // 
            this.login.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.login.Location = new System.Drawing.Point(124, 232);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(80, 43);
            this.login.TabIndex = 4;
            this.login.Text = "登陆";
            this.login.UseVisualStyleBackColor = true;
            this.login.Click += new System.EventHandler(this.login_Click);
            // 
            // tuichu
            // 
            this.tuichu.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tuichu.Location = new System.Drawing.Point(288, 232);
            this.tuichu.Name = "tuichu";
            this.tuichu.Size = new System.Drawing.Size(81, 43);
            this.tuichu.TabIndex = 5;
            this.tuichu.Text = "退出";
            this.tuichu.UseVisualStyleBackColor = true;
            this.tuichu.Click += new System.EventHandler(this.tuichu_Click);
            // 
            // Load
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 370);
            this.Controls.Add(this.tuichu);
            this.Controls.Add(this.login);
            this.Controls.Add(this.PWD);
            this.Controls.Add(this.name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Load";
            this.Text = "登陆";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.TextBox PWD;
        private System.Windows.Forms.Button login;
        private System.Windows.Forms.Button tuichu;
    }
}

