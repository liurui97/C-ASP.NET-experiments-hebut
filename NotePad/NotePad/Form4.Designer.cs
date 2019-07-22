namespace NotePad
{
    partial class Form4
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cancel = new System.Windows.Forms.Button();
            this.changeto = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "行号(L)";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(51, 67);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(352, 25);
            this.textBox1.TabIndex = 1;
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(309, 123);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(93, 23);
            this.cancel.TabIndex = 2;
            this.cancel.Text = "取消";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // changeto
            // 
            this.changeto.Location = new System.Drawing.Point(219, 123);
            this.changeto.Name = "changeto";
            this.changeto.Size = new System.Drawing.Size(75, 23);
            this.changeto.TabIndex = 3;
            this.changeto.Text = "转到";
            this.changeto.UseVisualStyleBackColor = true;
            this.changeto.Click += new System.EventHandler(this.changeto_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 198);
            this.Controls.Add(this.changeto);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "Form4";
            this.Text = "Form4";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button changeto;
    }
}