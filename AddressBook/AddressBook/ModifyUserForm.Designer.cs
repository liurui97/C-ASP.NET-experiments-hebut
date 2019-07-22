namespace AddressBook
{
    partial class ModifyUserForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.modifyuser = new System.Windows.Forms.Button();
            this.cancelmodifyuser = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "密码";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(200, 87);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(136, 25);
            this.textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(200, 141);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(136, 25);
            this.textBox2.TabIndex = 3;
            // 
            // modifyuser
            // 
            this.modifyuser.Location = new System.Drawing.Point(87, 228);
            this.modifyuser.Name = "modifyuser";
            this.modifyuser.Size = new System.Drawing.Size(75, 23);
            this.modifyuser.TabIndex = 4;
            this.modifyuser.Text = "修改";
            this.modifyuser.UseVisualStyleBackColor = true;
            this.modifyuser.Click += new System.EventHandler(this.modifyuser_Click);
            // 
            // cancelmodifyuser
            // 
            this.cancelmodifyuser.Location = new System.Drawing.Point(261, 228);
            this.cancelmodifyuser.Name = "cancelmodifyuser";
            this.cancelmodifyuser.Size = new System.Drawing.Size(75, 23);
            this.cancelmodifyuser.TabIndex = 5;
            this.cancelmodifyuser.Text = "取消";
            this.cancelmodifyuser.UseVisualStyleBackColor = true;
            this.cancelmodifyuser.Click += new System.EventHandler(this.cancelmodifyuser_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(87, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "用户ID";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(200, 32);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(136, 25);
            this.textBox3.TabIndex = 7;
            // 
            // ModifyUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 301);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cancelmodifyuser);
            this.Controls.Add(this.modifyuser);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ModifyUserForm";
            this.Text = "修改用户信息";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button modifyuser;
        private System.Windows.Forms.Button cancelmodifyuser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
    }
}