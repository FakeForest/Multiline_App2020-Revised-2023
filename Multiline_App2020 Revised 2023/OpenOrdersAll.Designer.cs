namespace Multiline_App2020_Revised_2023
{
    partial class OpenOrdersAll
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
            this.crp_OpenOrdersAll = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crp_OpenOrdersAll
            // 
            this.crp_OpenOrdersAll.ActiveViewIndex = -1;
            this.crp_OpenOrdersAll.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crp_OpenOrdersAll.Cursor = System.Windows.Forms.Cursors.Default;
            this.crp_OpenOrdersAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crp_OpenOrdersAll.Location = new System.Drawing.Point(0, 0);
            this.crp_OpenOrdersAll.Name = "crp_OpenOrdersAll";
            this.crp_OpenOrdersAll.Size = new System.Drawing.Size(284, 261);
            this.crp_OpenOrdersAll.TabIndex = 0;
            this.crp_OpenOrdersAll.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // FormOpenOrdersAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.crp_OpenOrdersAll);
            this.Name = "FormOpenOrdersAll";
            this.Text = "FormOpenOrdersAll";
            this.Load += new System.EventHandler(this.FormOpenOrdersAll_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crp_OpenOrdersAll;
    }
}