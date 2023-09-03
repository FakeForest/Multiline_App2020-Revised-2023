namespace Multiline_App2020_Revised_2023
{
    partial class OnHoldList
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
            this.Cancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.txtSalesId = new System.Windows.Forms.TextBox();
            this.radioSalesId = new System.Windows.Forms.RadioButton();
            this.radioAll = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Cancel);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Controls.Add(this.txtSalesId);
            this.panel1.Controls.Add(this.radioSalesId);
            this.panel1.Controls.Add(this.radioAll);
            this.panel1.Location = new System.Drawing.Point(23, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(249, 197);
            this.panel1.TabIndex = 0;
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(140, 137);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 4;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(41, 137);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "Print";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtSalesId
            // 
            this.txtSalesId.Location = new System.Drawing.Point(40, 96);
            this.txtSalesId.Name = "txtSalesId";
            this.txtSalesId.Size = new System.Drawing.Size(100, 20);
            this.txtSalesId.TabIndex = 1;
            // 
            // radioSalesId
            // 
            this.radioSalesId.AutoSize = true;
            this.radioSalesId.Location = new System.Drawing.Point(40, 73);
            this.radioSalesId.Name = "radioSalesId";
            this.radioSalesId.Size = new System.Drawing.Size(110, 17);
            this.radioSalesId.TabIndex = 2;
            this.radioSalesId.TabStop = true;
            this.radioSalesId.Text = "Select by Sales Id";
            this.radioSalesId.UseVisualStyleBackColor = true;
            // 
            // radioAll
            // 
            this.radioAll.AutoSize = true;
            this.radioAll.Location = new System.Drawing.Point(40, 34);
            this.radioAll.Name = "radioAll";
            this.radioAll.Size = new System.Drawing.Size(36, 17);
            this.radioAll.TabIndex = 1;
            this.radioAll.TabStop = true;
            this.radioAll.Text = "All";
            this.radioAll.UseVisualStyleBackColor = true;
            // 
            // OnHoldList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 301);
            this.Controls.Add(this.panel1);
            this.Name = "OnHoldList";
            this.Text = "OnHoldList";
            this.Load += new System.EventHandler(this.OnHoldList_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox txtSalesId;
        private System.Windows.Forms.RadioButton radioSalesId;
        private System.Windows.Forms.RadioButton radioAll;
    }
}