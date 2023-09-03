namespace Multiline_App2020_Revised_2023
{
    partial class POInputResult
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
            this.components = new System.ComponentModel.Container();
            this.multilinedbDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.multiline_dbDataSet = new Multiline_App2020_Revised_2023.multiline_dbDataSet();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.multilinedbDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.multiline_dbDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // multilinedbDataSetBindingSource
            // 
            this.multilinedbDataSetBindingSource.DataSource = this.multiline_dbDataSet;
            this.multilinedbDataSetBindingSource.Position = 0;
            // 
            // multiline_dbDataSet
            // 
            this.multiline_dbDataSet.DataSetName = "multiline_dbDataSet";
            this.multiline_dbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1070, 538);
            this.dataGridView1.TabIndex = 0;
            // 
            // POInputResult
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 538);
            this.Controls.Add(this.dataGridView1);
            this.Name = "POInputResult";
            this.Text = "POInputResult";
            //this.Load += new System.EventHandler(this.POInputResult_Load);
            ((System.ComponentModel.ISupportInitialize)(this.multilinedbDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.multiline_dbDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource multilinedbDataSetBindingSource;
        private multiline_dbDataSet multiline_dbDataSet;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}