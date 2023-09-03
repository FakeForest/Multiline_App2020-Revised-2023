using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Multiline_App2020_Revised_2023
{
    public partial class Search : Form
    {
        public string result { get; set; }
        public String RptType2_R = "";

        public Search()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Search_Load(object sender, EventArgs e)

        {
            RptType2_R = SalesHistory.RptType2;
            if (RptType2_R == "SearchCustId")
            {
                string cs = ConfigurationManager.ConnectionStrings["Multiline_db"].ConnectionString;

                try
                {
                    using (SqlConnection conn = new SqlConnection(cs))

                    {
                        using (SqlCommand cmd = new SqlCommand("select * from qry_custhist_customers", conn))
                        {
                            cmd.CommandType = CommandType.Text;
                            conn.Open();
                            DataTable dt = new DataTable();
                            dt.Load(cmd.ExecuteReader());
                            dgvSearch.DataSource = dt;
                            conn.Close();

                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error info:" + ex.Message);
                }

                dgvSearch.Columns[0].Width = 80;

            }

            if (RptType2_R == "SearchItemId")
            {
                string cs = ConfigurationManager.ConnectionStrings["Multiline_db"].ConnectionString;

                try
                {
                    using (SqlConnection conn = new SqlConnection(cs))

                    {
                        using (SqlCommand cmd = new SqlCommand("select * from qry_items", conn))
                        {
                            cmd.CommandType = CommandType.Text;
                            conn.Open();
                            DataTable dt = new DataTable();
                            dt.Load(cmd.ExecuteReader());
                            dgvSearch.DataSource = dt;
                            conn.Close();

                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error info:" + ex.Message);
                }

                dgvSearch.Columns[0].Width = 80;
                dgvSearch.Columns[1].Width = 60;






            }
        }
        private void dgvSearch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            result = dgvSearch.CurrentRow.Cells[0].Value.ToString();

            this.DialogResult = DialogResult.OK;

        }

        private void btnOk_Click(object sender, EventArgs e)
        {

            result = dgvSearch.CurrentRow.Cells[0].Value.ToString();

            this.DialogResult = DialogResult.OK;


        }
    }
}
