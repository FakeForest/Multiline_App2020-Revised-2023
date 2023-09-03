namespace Multiline_App2020_Revised_2023
{
    partial class SalesBooking
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
            this.lblSummary = new System.Windows.Forms.Label();
            this.lblDetail = new System.Windows.Forms.Label();
            this.radioAllSalesAllCust = new System.Windows.Forms.RadioButton();
            this.radioPerSales = new System.Windows.Forms.RadioButton();
            this.radioPerCust = new System.Windows.Forms.RadioButton();
            this.txtSalesId = new System.Windows.Forms.TextBox();
            this.txtCustId = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtCustId);
            this.panel1.Controls.Add(this.txtSalesId);
            this.panel1.Controls.Add(this.radioPerCust);
            this.panel1.Controls.Add(this.radioPerSales);
            this.panel1.Controls.Add(this.radioAllSalesAllCust);
            this.panel1.Controls.Add(this.lblDetail);
            this.panel1.Controls.Add(this.lblSummary);
            this.panel1.Location = new System.Drawing.Point(43, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(279, 169);
            this.panel1.TabIndex = 0;
            // 
            // lblSummary
            // 
            this.lblSummary.AutoSize = true;
            this.lblSummary.Location = new System.Drawing.Point(16, 19);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(50, 13);
            this.lblSummary.TabIndex = 0;
            this.lblSummary.Text = "Summary";
            // 
            // lblDetail
            // 
            this.lblDetail.AutoSize = true;
            this.lblDetail.Location = new System.Drawing.Point(16, 69);
            this.lblDetail.Name = "lblDetail";
            this.lblDetail.Size = new System.Drawing.Size(34, 13);
            this.lblDetail.TabIndex = 1;
            this.lblDetail.Text = "Detail";
            // 
            // radioAllSalesAllCust
            // 
            this.radioAllSalesAllCust.AutoSize = true;
            this.radioAllSalesAllCust.Location = new System.Drawing.Point(35, 35);
            this.radioAllSalesAllCust.Name = "radioAllSalesAllCust";
            this.radioAllSalesAllCust.Size = new System.Drawing.Size(134, 17);
            this.radioAllSalesAllCust.TabIndex = 2;
            this.radioAllSalesAllCust.TabStop = true;
            this.radioAllSalesAllCust.Text = "All Sales, All Customers";
            this.radioAllSalesAllCust.UseVisualStyleBackColor = true;
            // 
            // radioPerSales
            // 
            this.radioPerSales.AutoSize = true;
            this.radioPerSales.Location = new System.Drawing.Point(35, 85);
            this.radioPerSales.Name = "radioPerSales";
            this.radioPerSales.Size = new System.Drawing.Size(89, 17);
            this.radioPerSales.TabIndex = 3;
            this.radioPerSales.TabStop = true;
            this.radioPerSales.Text = "By Sales Rep";
            this.radioPerSales.UseVisualStyleBackColor = true;
            // 
            // radioPerCust
            // 
            this.radioPerCust.AutoSize = true;
            this.radioPerCust.Location = new System.Drawing.Point(35, 125);
            this.radioPerCust.Name = "radioPerCust";
            this.radioPerCust.Size = new System.Drawing.Size(84, 17);
            this.radioPerCust.TabIndex = 4;
            this.radioPerCust.TabStop = true;
            this.radioPerCust.Text = "By Customer";
            this.radioPerCust.UseVisualStyleBackColor = true;
            // 
            // txtSalesId
            // 
            this.txtSalesId.Location = new System.Drawing.Point(131, 85);
            this.txtSalesId.Name = "txtSalesId";
            this.txtSalesId.Size = new System.Drawing.Size(100, 20);
            this.txtSalesId.TabIndex = 5;
            // 
            // txtCustId
            // 
            this.txtCustId.Location = new System.Drawing.Point(131, 125);
            this.txtCustId.Name = "txtCustId";
            this.txtCustId.Size = new System.Drawing.Size(100, 20);
            this.txtCustId.TabIndex = 6;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(62, 214);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(101, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(216, 214);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(106, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // SalesBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 261);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.panel1);
            this.Name = "SalesBooking";
            this.Text = "SalesBooking";
            this.Load += new System.EventHandler(this.SalesBooking_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtCustId;
        private System.Windows.Forms.TextBox txtSalesId;
        private System.Windows.Forms.RadioButton radioPerCust;
        private System.Windows.Forms.RadioButton radioPerSales;
        private System.Windows.Forms.RadioButton radioAllSalesAllCust;
        private System.Windows.Forms.Label lblDetail;
        private System.Windows.Forms.Label lblSummary;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}