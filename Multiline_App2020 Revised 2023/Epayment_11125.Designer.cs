namespace Multiline_App2020_Revised_2023
{
    partial class Epayment_11125
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
            this.lblDate = new System.Windows.Forms.Label();
            this.lblFileNum = new System.Windows.Forms.Label();
            this.lblStep1 = new System.Windows.Forms.Label();
            this.lblStep2 = new System.Windows.Forms.Label();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.txtFileNum = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.btnCheckInfo = new System.Windows.Forms.Button();
            this.btnFile = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(76, 75);
            this.lblDate.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(57, 25);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "Date";
            // 
            // lblFileNum
            // 
            this.lblFileNum.AutoSize = true;
            this.lblFileNum.Location = new System.Drawing.Point(454, 75);
            this.lblFileNum.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblFileNum.Name = "lblFileNum";
            this.lblFileNum.Size = new System.Drawing.Size(86, 25);
            this.lblFileNum.TabIndex = 1;
            this.lblFileNum.Text = "File No.";
            // 
            // lblStep1
            // 
            this.lblStep1.AutoSize = true;
            this.lblStep1.Location = new System.Drawing.Point(76, 162);
            this.lblStep1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblStep1.Name = "lblStep1";
            this.lblStep1.Size = new System.Drawing.Size(349, 25);
            this.lblStep1.TabIndex = 2;
            this.lblStep1.Text = "Step 1:  Create Table for CheckInfo";
            // 
            // lblStep2
            // 
            this.lblStep2.AutoSize = true;
            this.lblStep2.Location = new System.Drawing.Point(76, 288);
            this.lblStep2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblStep2.Name = "lblStep2";
            this.lblStep2.Size = new System.Drawing.Size(339, 25);
            this.lblStep2.TabIndex = 3;
            this.lblStep2.Text = "Step 2: Create File for Submission";
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(148, 62);
            this.txtDate.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(196, 31);
            this.txtDate.TabIndex = 4;
            // 
            // txtFileNum
            // 
            this.txtFileNum.Location = new System.Drawing.Point(552, 62);
            this.txtFileNum.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtFileNum.Name = "txtFileNum";
            this.txtFileNum.Size = new System.Drawing.Size(196, 31);
            this.txtFileNum.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 375);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "File Name:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(206, 362);
            this.txtFileName.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(196, 31);
            this.txtFileName.TabIndex = 7;
            // 
            // btnCheckInfo
            // 
            this.btnCheckInfo.Location = new System.Drawing.Point(468, 162);
            this.btnCheckInfo.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnCheckInfo.Name = "btnCheckInfo";
            this.btnCheckInfo.Size = new System.Drawing.Size(284, 44);
            this.btnCheckInfo.TabIndex = 8;
            this.btnCheckInfo.Text = "Create Check Info";
            this.btnCheckInfo.UseVisualStyleBackColor = true;
            this.btnCheckInfo.Click += new System.EventHandler(this.btnCheckInfo_Click);
            // 
            // btnFile
            // 
            this.btnFile.Location = new System.Drawing.Point(468, 356);
            this.btnFile.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(284, 44);
            this.btnFile.TabIndex = 9;
            this.btnFile.Text = "Create Submission File";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(122, 488);
            this.btnExit.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(284, 44);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Epayment_11125
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 579);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnFile);
            this.Controls.Add(this.btnCheckInfo);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFileNum);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.lblStep2);
            this.Controls.Add(this.lblStep1);
            this.Controls.Add(this.lblFileNum);
            this.Controls.Add(this.lblDate);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Epayment_11125";
            this.Text = "Create File For Submission";
            this.Load += new System.EventHandler(this.Epayment_11125_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblFileNum;
        private System.Windows.Forms.Label lblStep1;
        private System.Windows.Forms.Label lblStep2;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.TextBox txtFileNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Button btnCheckInfo;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.Button btnExit;
    }
}