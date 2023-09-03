namespace Multiline_App2020_Revised_2023
{
    partial class OutputReport
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
            this.crpvOutputReport = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crpvOutputReport
            // 
            this.crpvOutputReport.ActiveViewIndex = -1;
            this.crpvOutputReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crpvOutputReport.Cursor = System.Windows.Forms.Cursors.Default;
            this.crpvOutputReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crpvOutputReport.Location = new System.Drawing.Point(0, 0);
            this.crpvOutputReport.Name = "crpvOutputReport";
            this.crpvOutputReport.Size = new System.Drawing.Size(284, 261);
            this.crpvOutputReport.TabIndex = 0;
            this.crpvOutputReport.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // OutputReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.crpvOutputReport);
            this.Name = "OutputReport";
            this.Text = "OutputReport";
            this.Load += new System.EventHandler(this.OutputReport_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crpvOutputReport;
    }
}