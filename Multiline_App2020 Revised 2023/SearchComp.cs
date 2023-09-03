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
    public partial class SearchComp : Form
    {
        public SearchComp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["Multiline_db"].ConnectionString;
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please enter an email for checking!");
                textBox1.Focus();
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(cs))
                {

                    //calling stored procedure sp_SalesHistoryPerCustAllItemSum in Multiline_db
                    conn.Open();
                    //SqlCommand cmdx = new SqlCommand("", conn);
                    //cmdx.CommandType = CommandType.Text;
                    //cmdx.CommandTimeout = 180;
                    //cmdx.ExecuteNonQuery();

                    //SqlCommand cmdy = new SqlCommand("", conn);
                    //cmdy.CommandType = CommandType.Text;
                    //cmdy.CommandTimeout = 180;
                    //cmdy.ExecuteNonQuery();

                    string query1 = "select cu_cust_id, cu_name, cu_email_attention from sisl_data01.dbo.customers where cu_email_attention LIKE ('"+ "%"+textBox1.Text+"%" +"')";
                    string query2 = "select cuco_cust_id, cuco_contact_name, cuco_email from sisl_data01.dbo.cust_contacts where cuco_email LIKE ('"+ "%"+textBox1.Text+"%" + "')";

                    SqlCommand cmd1 = new SqlCommand(query1, conn);
                    cmd1.CommandType = CommandType.Text;
                    DataTable dt1 = new DataTable();
                    dt1.Load(cmd1.ExecuteReader());
                    dataGridView1.DataSource = dt1;

                    SqlCommand cmd2 = new SqlCommand(query2, conn);
                    cmd2.CommandType = CommandType.Text;
                    DataTable dt2 = new DataTable();
                    dt2.Load(cmd2.ExecuteReader());
                    dataGridView2.DataSource = dt2;
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
