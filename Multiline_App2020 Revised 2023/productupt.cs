using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multiline_App2020_Revised_2023
{
    public partial class productupt : Form
    {
        public productupt()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["Multiline2016_local"].ConnectionString;


            try
            {
                using (SqlConnection conn = new SqlConnection(cs))
                {

                    //calling stored procedure sp_SalesHistoryPerCustAllItemSum in Multiline_db
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("spSearchCatalog_tableupdate", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 3600;
                    cmd.ExecuteNonQuery();

                    SqlCommand cmd1 = new SqlCommand("select * from producttemp", conn);
                    cmd1.CommandType = CommandType.Text;
                    DataTable dt = new DataTable();
                    dt.Load(cmd1.ExecuteReader());
                    dataGridView1.DataSource = dt;
                    conn.Close();
                }
            }


            catch (Exception ex)
            {
                MessageBox.Show("Error info:" + ex.Message);
            }
        }
    }
}
