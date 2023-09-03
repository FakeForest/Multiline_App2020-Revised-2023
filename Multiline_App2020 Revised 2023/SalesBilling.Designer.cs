namespace Multiline_App2020_Revised_2023
{
    partial class SalesBilling
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
            this.lblDate1 = new System.Windows.Forms.Label();
            this.lblDate2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSalesId = new System.Windows.Forms.TextBox();
            this.radioSalesId = new System.Windows.Forms.RadioButton();
            this.lblSales = new System.Windows.Forms.Label();
            this.radioSalesAll = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtCustId = new System.Windows.Forms.TextBox();
            this.radioCustId = new System.Windows.Forms.RadioButton();
            this.lblCust = new System.Windows.Forms.Label();
            this.radioCustAll = new System.Windows.Forms.RadioButton();
            this.txtDate1 = new System.Windows.Forms.TextBox();
            this.txtDate2 = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDate1
            // 
            this.lblDate1.AutoSize = true;
            this.lblDate1.Location = new System.Drawing.Point(34, 54);
            this.lblDate1.Name = "lblDate1";
            this.lblDate1.Size = new System.Drawing.Size(55, 13);
            this.lblDate1.TabIndex = 0;
            this.lblDate1.Text = "Start Date";
            // 
            // lblDate2
            // 
            this.lblDate2.AutoSize = true;
            this.lblDate2.Location = new System.Drawing.Point(257, 54);
            this.lblDate2.Name = "lblDate2";
            this.lblDate2.Size = new System.Drawing.Size(52, 13);
            this.lblDate2.TabIndex = 1;
            this.lblDate2.Text = "End Date";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtSalesId);
            this.panel1.Controls.Add(this.radioSalesId);
            this.panel1.Controls.Add(this.lblSales);
            this.panel1.Controls.Add(this.radioSalesAll);
            this.panel1.Location = new System.Drawing.Point(37, 91);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(208, 139);
            this.panel1.TabIndex = 2;
            // 
            // txtSalesId
            // 
            this.txtSalesId.Location = new System.Drawing.Point(41, 99);
            this.txtSalesId.Name = "txtSalesId";
            this.txtSalesId.Size = new System.Drawing.Size(127, 20);
            this.txtSalesId.TabIndex = 3;
            // 
            // radioSalesId
            // 
            this.radioSalesId.AutoSize = true;
            this.radioSalesId.Location = new System.Drawing.Point(41, 66);
            this.radioSalesId.Name = "radioSalesId";
            this.radioSalesId.Size = new System.Drawing.Size(134, 17);
            this.radioSalesId.TabIndex = 2;
            this.radioSalesId.TabStop = true;
            this.radioSalesId.Text = "Select Sales Rep By Id";
            this.radioSalesId.UseVisualStyleBackColor = true;
            this.radioSalesId.CheckedChanged += new System.EventHandler(this.radioSalesId_CheckedChanged);
            // 
            // lblSales
            // 
            this.lblSales.AutoSize = true;
            this.lblSales.Location = new System.Drawing.Point(3, 0);
            this.lblSales.Name = "lblSales";
            this.lblSales.Size = new System.Drawing.Size(101, 13);
            this.lblSales.TabIndex = 1;
            this.lblSales.Text = "Billing By Sales Rep";
            // 
            // radioSalesAll
            // 
            this.radioSalesAll.AutoSize = true;
            this.radioSalesAll.Location = new System.Drawing.Point(41, 32);
            this.radioSalesAll.Name = "radioSalesAll";
            this.radioSalesAll.Size = new System.Drawing.Size(127, 17);
            this.radioSalesAll.TabIndex = 0;
            this.radioSalesAll.TabStop = true;
            this.radioSalesAll.Text = "Select Sales Rep - All";
            this.radioSalesAll.UseVisualStyleBackColor = true;
            this.radioSalesAll.CheckedChanged += new System.EventHandler(this.radioSalesAll_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(260, 91);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(215, 135);
            this.panel2.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtCustId);
            this.panel3.Controls.Add(this.radioCustId);
            this.panel3.Controls.Add(this.lblCust);
            this.panel3.Controls.Add(this.radioCustAll);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(215, 137);
            this.panel3.TabIndex = 3;
            // 
            // txtCustId
            // 
            this.txtCustId.Location = new System.Drawing.Point(41, 99);
            this.txtCustId.Name = "txtCustId";
            this.txtCustId.Size = new System.Drawing.Size(127, 20);
            this.txtCustId.TabIndex = 3;
            // 
            // radioCustId
            // 
            this.radioCustId.AutoSize = true;
            this.radioCustId.Location = new System.Drawing.Point(41, 68);
            this.radioCustId.Name = "radioCustId";
            this.radioCustId.Size = new System.Drawing.Size(129, 17);
            this.radioCustId.TabIndex = 2;
            this.radioCustId.TabStop = true;
            this.radioCustId.Text = "Select Customer By Id";
            this.radioCustId.UseVisualStyleBackColor = true;
            this.radioCustId.CheckedChanged += new System.EventHandler(this.radioCustId_CheckedChanged);
            // 
            // lblCust
            // 
            this.lblCust.AutoSize = true;
            this.lblCust.Location = new System.Drawing.Point(3, 0);
            this.lblCust.Name = "lblCust";
            this.lblCust.Size = new System.Drawing.Size(96, 13);
            this.lblCust.TabIndex = 1;
            this.lblCust.Text = "Billing By Customer";
            // 
            // radioCustAll
            // 
            this.radioCustAll.AutoSize = true;
            this.radioCustAll.Location = new System.Drawing.Point(41, 32);
            this.radioCustAll.Name = "radioCustAll";
            this.radioCustAll.Size = new System.Drawing.Size(119, 17);
            this.radioCustAll.TabIndex = 0;
            this.radioCustAll.TabStop = true;
            this.radioCustAll.Text = "Select Customer -All";
            this.radioCustAll.UseVisualStyleBackColor = true;
            this.radioCustAll.CheckedChanged += new System.EventHandler(this.radioCustAll_CheckedChanged);
            // 
            // txtDate1
            // 
            this.txtDate1.Location = new System.Drawing.Point(95, 46);
            this.txtDate1.Name = "txtDate1";
            this.txtDate1.Size = new System.Drawing.Size(117, 20);
            this.txtDate1.TabIndex = 4;
            // 
            // txtDate2
            // 
            this.txtDate2.Location = new System.Drawing.Point(315, 47);
            this.txtDate2.Name = "txtDate2";
            this.txtDate2.Size = new System.Drawing.Size(124, 20);
            this.txtDate2.TabIndex = 5;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(217, 47);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(28, 20);
            this.dateTimePicker1.TabIndex = 6;
            this.dateTimePicker1.CloseUp += new System.EventHandler(this.dateTimePicker1_CloseUp);
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            this.dateTimePicker1.DropDown += new System.EventHandler(this.dateTimePicker1_DropDown);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(445, 48);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(30, 20);
            this.dateTimePicker2.TabIndex = 7;
            this.dateTimePicker2.CloseUp += new System.EventHandler(this.dateTimePicker2_CloseUp);
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            this.dateTimePicker2.DropDown += new System.EventHandler(this.dateTimePicker2_DropDown);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(93, 257);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(103, 23);
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(315, 257);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(105, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // SalesBilling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 316);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.txtDate2);
            this.Controls.Add(this.txtDate1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblDate2);
            this.Controls.Add(this.lblDate1);
            this.Name = "SalesBilling";
            this.Text = "SalesBilling";
            this.Load += new System.EventHandler(this.SalesBilling_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDate1;
        private System.Windows.Forms.Label lblDate2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtDate1;
        private System.Windows.Forms.TextBox txtDate2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.TextBox txtSalesId;
        private System.Windows.Forms.RadioButton radioSalesId;
        private System.Windows.Forms.Label lblSales;
        private System.Windows.Forms.RadioButton radioSalesAll;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtCustId;
        private System.Windows.Forms.RadioButton radioCustId;
        private System.Windows.Forms.Label lblCust;
        private System.Windows.Forms.RadioButton radioCustAll;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}