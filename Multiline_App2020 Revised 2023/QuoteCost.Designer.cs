namespace Multiline_App2020_Revised_2023
{
    partial class QuoteCost
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblQuoteNo = new System.Windows.Forms.Label();
            this.txtQuoteNo = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Controls.Add(this.txtQuoteNo);
            this.panel1.Controls.Add(this.lblQuoteNo);
            this.panel1.Location = new System.Drawing.Point(35, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(224, 206);
            this.panel1.TabIndex = 0;
            // 
            // lblQuoteNo
            // 
            this.lblQuoteNo.AutoSize = true;
            this.lblQuoteNo.Location = new System.Drawing.Point(21, 52);
            this.lblQuoteNo.Name = "lblQuoteNo";
            this.lblQuoteNo.Size = new System.Drawing.Size(56, 13);
            this.lblQuoteNo.TabIndex = 1;
            this.lblQuoteNo.Text = "Quote No.";
            // 
            // txtQuoteNo
            // 
            this.txtQuoteNo.Location = new System.Drawing.Point(83, 49);
            this.txtQuoteNo.Name = "txtQuoteNo";
            this.txtQuoteNo.Size = new System.Drawing.Size(100, 20);
            this.txtQuoteNo.TabIndex = 2;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(24, 120);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(131, 120);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // QuoteCost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.panel1);
            this.Name = "QuoteCost";
            this.Text = "QuoteCost";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox txtQuoteNo;
        private System.Windows.Forms.Label lblQuoteNo;
    }
}