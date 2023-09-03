namespace Multiline_App2020_Revised_2023
{
    partial class SendEMail_11125
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
            this.btnGetMail = new System.Windows.Forms.Button();
            this.btnSendMail = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGetMail
            // 
            this.btnGetMail.Location = new System.Drawing.Point(90, 73);
            this.btnGetMail.Margin = new System.Windows.Forms.Padding(6);
            this.btnGetMail.Name = "btnGetMail";
            this.btnGetMail.Size = new System.Drawing.Size(390, 77);
            this.btnGetMail.TabIndex = 0;
            this.btnGetMail.Text = "Step 1: Generate E-mails";
            this.btnGetMail.UseVisualStyleBackColor = true;
            this.btnGetMail.Click += new System.EventHandler(this.btnGetMail_Click);
            // 
            // btnSendMail
            // 
            this.btnSendMail.Location = new System.Drawing.Point(90, 212);
            this.btnSendMail.Margin = new System.Windows.Forms.Padding(6);
            this.btnSendMail.Name = "btnSendMail";
            this.btnSendMail.Size = new System.Drawing.Size(390, 77);
            this.btnSendMail.TabIndex = 1;
            this.btnSendMail.Text = "Step 2: Send E-mails";
            this.btnSendMail.UseVisualStyleBackColor = true;
            this.btnSendMail.Click += new System.EventHandler(this.btnSendMail_Click_1);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(90, 348);
            this.btnExit.Margin = new System.Windows.Forms.Padding(6);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(390, 77);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click_1);
            // 
            // SendEMail_11125
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 523);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSendMail);
            this.Controls.Add(this.btnGetMail);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "SendEMail_11125";
            this.Text = "SendEMail_11125";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGetMail;
        private System.Windows.Forms.Button btnSendMail;
        private System.Windows.Forms.Button btnExit;
    }
}