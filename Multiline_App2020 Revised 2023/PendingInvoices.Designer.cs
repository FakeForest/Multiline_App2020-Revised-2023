namespace Multiline_App2020_Revised_2023
{
    partial class PendingInvoices
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
            this.crp_PendingInvoices = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crp_PendingInvoices
            // 
            this.crp_PendingInvoices.ActiveViewIndex = -1;
            this.crp_PendingInvoices.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crp_PendingInvoices.Cursor = System.Windows.Forms.Cursors.Default;
            this.crp_PendingInvoices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crp_PendingInvoices.Location = new System.Drawing.Point(0, 0);
            this.crp_PendingInvoices.Name = "crp_PendingInvoices";
            this.crp_PendingInvoices.Size = new System.Drawing.Size(480, 261);
            this.crp_PendingInvoices.TabIndex = 0;
            this.crp_PendingInvoices.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // PendingInvoices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 261);
            this.Controls.Add(this.crp_PendingInvoices);
            this.Name = "PendingInvoices";
            this.Text = "PendingInvoices";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PendingInvoices_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crp_PendingInvoices;
    }
}