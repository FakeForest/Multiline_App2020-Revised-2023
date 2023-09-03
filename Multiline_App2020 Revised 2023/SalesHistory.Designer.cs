namespace Multiline_App2020_Revised_2023
{
    partial class SalesHistory
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
            this.txtDate1 = new System.Windows.Forms.TextBox();
            this.txtDate2 = new System.Windows.Forms.TextBox();
            this.panelCustId = new System.Windows.Forms.Panel();
            this.btnCustId = new System.Windows.Forms.Button();
            this.txtCustId = new System.Windows.Forms.TextBox();
            this.radioCustId = new System.Windows.Forms.RadioButton();
            this.radioCustAll = new System.Windows.Forms.RadioButton();
            this.lblCustPan = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioItemId = new System.Windows.Forms.RadioButton();
            this.radioItemAll = new System.Windows.Forms.RadioButton();
            this.lblItemPanel = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.lblItemId = new System.Windows.Forms.Label();
            this.btnItem = new System.Windows.Forms.Button();
            this.txtItemId = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cBoxSum = new System.Windows.Forms.CheckBox();
            this.panelCustId.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDate1
            // 
            this.lblDate1.AutoSize = true;
            this.lblDate1.Location = new System.Drawing.Point(54, 32);
            this.lblDate1.Name = "lblDate1";
            this.lblDate1.Size = new System.Drawing.Size(58, 13);
            this.lblDate1.TabIndex = 0;
            this.lblDate1.Text = "Start Date:";
            // 
            // lblDate2
            // 
            this.lblDate2.AutoSize = true;
            this.lblDate2.Location = new System.Drawing.Point(292, 32);
            this.lblDate2.Name = "lblDate2";
            this.lblDate2.Size = new System.Drawing.Size(55, 13);
            this.lblDate2.TabIndex = 1;
            this.lblDate2.Text = "End Date:";
            // 
            // txtDate1
            // 
            this.txtDate1.Location = new System.Drawing.Point(118, 29);
            this.txtDate1.Name = "txtDate1";
            this.txtDate1.Size = new System.Drawing.Size(100, 20);
            this.txtDate1.TabIndex = 2;
            // 
            // txtDate2
            // 
            this.txtDate2.Location = new System.Drawing.Point(353, 29);
            this.txtDate2.Name = "txtDate2";
            this.txtDate2.Size = new System.Drawing.Size(100, 20);
            this.txtDate2.TabIndex = 3;
            // 
            // panelCustId
            // 
            this.panelCustId.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelCustId.Controls.Add(this.btnCustId);
            this.panelCustId.Controls.Add(this.txtCustId);
            this.panelCustId.Controls.Add(this.radioCustId);
            this.panelCustId.Controls.Add(this.radioCustAll);
            this.panelCustId.Location = new System.Drawing.Point(156, 112);
            this.panelCustId.Name = "panelCustId";
            this.panelCustId.Size = new System.Drawing.Size(229, 141);
            this.panelCustId.TabIndex = 4;
            this.panelCustId.Tag = "Cust Id";
            // 
            // btnCustId
            // 
            this.btnCustId.Location = new System.Drawing.Point(151, 99);
            this.btnCustId.Name = "btnCustId";
            this.btnCustId.Size = new System.Drawing.Size(55, 23);
            this.btnCustId.TabIndex = 3;
            this.btnCustId.Text = "...";
            this.btnCustId.UseVisualStyleBackColor = true;
            this.btnCustId.Click += new System.EventHandler(this.btnCustId_Click);
            // 
            // txtCustId
            // 
            this.txtCustId.Location = new System.Drawing.Point(23, 101);
            this.txtCustId.Name = "txtCustId";
            this.txtCustId.Size = new System.Drawing.Size(136, 20);
            this.txtCustId.TabIndex = 2;
            // 
            // radioCustId
            // 
            this.radioCustId.AutoSize = true;
            this.radioCustId.Checked = true;
            this.radioCustId.Location = new System.Drawing.Point(43, 66);
            this.radioCustId.Name = "radioCustId";
            this.radioCustId.Size = new System.Drawing.Size(131, 17);
            this.radioCustId.TabIndex = 1;
            this.radioCustId.TabStop = true;
            this.radioCustId.Text = "Select Customer By ID";
            this.radioCustId.UseVisualStyleBackColor = true;
            this.radioCustId.CheckedChanged += new System.EventHandler(this.radioCustId_CheckedChanged);
            // 
            // radioCustAll
            // 
            this.radioCustAll.AutoSize = true;
            this.radioCustAll.Location = new System.Drawing.Point(43, 27);
            this.radioCustAll.Name = "radioCustAll";
            this.radioCustAll.Size = new System.Drawing.Size(116, 17);
            this.radioCustAll.TabIndex = 0;
            this.radioCustAll.TabStop = true;
            this.radioCustAll.Text = "Select Customer-All";
            this.radioCustAll.UseVisualStyleBackColor = true;
            this.radioCustAll.CheckedChanged += new System.EventHandler(this.radioCustAll_CheckedChanged);
            // 
            // lblCustPan
            // 
            this.lblCustPan.AutoSize = true;
            this.lblCustPan.Location = new System.Drawing.Point(153, 96);
            this.lblCustPan.Name = "lblCustPan";
            this.lblCustPan.Size = new System.Drawing.Size(84, 13);
            this.lblCustPan.TabIndex = 6;
            this.lblCustPan.Text = "Select Customer";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.radioItemId);
            this.panel1.Controls.Add(this.radioItemAll);
            this.panel1.Location = new System.Drawing.Point(78, 295);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(403, 65);
            this.panel1.TabIndex = 5;
            this.panel1.Tag = "Cust Id";
            // 
            // radioItemId
            // 
            this.radioItemId.AutoSize = true;
            this.radioItemId.Location = new System.Drawing.Point(229, 22);
            this.radioItemId.Name = "radioItemId";
            this.radioItemId.Size = new System.Drawing.Size(107, 17);
            this.radioItemId.TabIndex = 3;
            this.radioItemId.TabStop = true;
            this.radioItemId.Text = "Select Item By ID";
            this.radioItemId.UseVisualStyleBackColor = true;
            this.radioItemId.CheckedChanged += new System.EventHandler(this.radioItemId_CheckedChanged);
            // 
            // radioItemAll
            // 
            this.radioItemAll.AutoSize = true;
            this.radioItemAll.Checked = true;
            this.radioItemAll.Location = new System.Drawing.Point(60, 22);
            this.radioItemAll.Name = "radioItemAll";
            this.radioItemAll.Size = new System.Drawing.Size(97, 17);
            this.radioItemAll.TabIndex = 2;
            this.radioItemAll.TabStop = true;
            this.radioItemAll.Text = "Select All Items";
            this.radioItemAll.UseVisualStyleBackColor = true;
            this.radioItemAll.CheckedChanged += new System.EventHandler(this.radioItemAll_CheckedChanged);
            // 
            // lblItemPanel
            // 
            this.lblItemPanel.AutoSize = true;
            this.lblItemPanel.Location = new System.Drawing.Point(75, 279);
            this.lblItemPanel.Name = "lblItemPanel";
            this.lblItemPanel.Size = new System.Drawing.Size(60, 13);
            this.lblItemPanel.TabIndex = 7;
            this.lblItemPanel.Text = "Select Item";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(225, 29);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(32, 20);
            this.dateTimePicker1.TabIndex = 8;
            this.dateTimePicker1.CloseUp += new System.EventHandler(this.dateTimePicker1_CloseUp);
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            this.dateTimePicker1.DropDown += new System.EventHandler(this.dateTimePicker1_DropDown);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(459, 29);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(32, 20);
            this.dateTimePicker2.TabIndex = 9;
            this.dateTimePicker2.CloseUp += new System.EventHandler(this.dateTimePicker2_CloseUp);
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            this.dateTimePicker2.DropDown += new System.EventHandler(this.dateTimePicker2_DropDown);
            // 
            // lblItemId
            // 
            this.lblItemId.AutoSize = true;
            this.lblItemId.Location = new System.Drawing.Point(75, 374);
            this.lblItemId.Name = "lblItemId";
            this.lblItemId.Size = new System.Drawing.Size(41, 13);
            this.lblItemId.TabIndex = 10;
            this.lblItemId.Text = "Item ID";
            // 
            // btnItem
            // 
            this.btnItem.Location = new System.Drawing.Point(283, 373);
            this.btnItem.Name = "btnItem";
            this.btnItem.Size = new System.Drawing.Size(49, 23);
            this.btnItem.TabIndex = 12;
            this.btnItem.Text = "..";
            this.btnItem.UseVisualStyleBackColor = true;
            this.btnItem.Click += new System.EventHandler(this.btnItem_Click);
            // 
            // txtItemId
            // 
            this.txtItemId.Location = new System.Drawing.Point(140, 374);
            this.txtItemId.Name = "txtItemId";
            this.txtItemId.Size = new System.Drawing.Size(143, 20);
            this.txtItemId.TabIndex = 11;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(105, 420);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(113, 23);
            this.btnOk.TabIndex = 14;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(307, 420);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(109, 23);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cBoxSum
            // 
            this.cBoxSum.AutoSize = true;
            this.cBoxSum.Location = new System.Drawing.Point(385, 377);
            this.cBoxSum.Name = "cBoxSum";
            this.cBoxSum.Size = new System.Drawing.Size(69, 17);
            this.cBoxSum.TabIndex = 16;
            this.cBoxSum.Text = "Summary";
            this.cBoxSum.UseVisualStyleBackColor = true;
            // 
            // SalesHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 477);
            this.Controls.Add(this.cBoxSum);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnItem);
            this.Controls.Add(this.txtItemId);
            this.Controls.Add(this.lblItemId);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.lblItemPanel);
            this.Controls.Add(this.lblCustPan);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelCustId);
            this.Controls.Add(this.txtDate2);
            this.Controls.Add(this.txtDate1);
            this.Controls.Add(this.lblDate2);
            this.Controls.Add(this.lblDate1);
            this.Name = "SalesHistory";
            this.Text = "SalesHistory";
            this.Load += new System.EventHandler(this.SalesHistory_Load);
            this.panelCustId.ResumeLayout(false);
            this.panelCustId.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDate1;
        private System.Windows.Forms.Label lblDate2;
        private System.Windows.Forms.TextBox txtDate1;
        private System.Windows.Forms.TextBox txtDate2;
        private System.Windows.Forms.Panel panelCustId;
        private System.Windows.Forms.RadioButton radioCustId;
        private System.Windows.Forms.RadioButton radioCustAll;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblCustPan;
        private System.Windows.Forms.RadioButton radioItemId;
        private System.Windows.Forms.RadioButton radioItemAll;
        private System.Windows.Forms.Label lblItemPanel;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label lblItemId;
        private System.Windows.Forms.Button btnItem;
        private System.Windows.Forms.TextBox txtItemId;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox cBoxSum;
        private System.Windows.Forms.Button btnCustId;
        public System.Windows.Forms.TextBox txtCustId;
    }
}