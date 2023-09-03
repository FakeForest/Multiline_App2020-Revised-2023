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
    public partial class ReportPreview : Form
    {
        public ReportPreview()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ConnectionString = "Server=192.168.1.190,1435;User ID=Office; Password=BCpr001!;Initial Catalog=multiline_db";

            SqlConnection con = new SqlConnection(ConnectionString);

            string query1 = "select * from TempReport";
                           //$" where Timein between '{dateTimePicker1.Value}' and '{dateTimePicker2.Value}'";
            string query2 = "update TimeReport" +
                            " set TimeSpan = datediff(MINUTE, Timein, Timeout)" +
                           $" where Timein between '{dateTimePicker1.Value}' and '{dateTimePicker2.Value}'";

            //con.Open();
            //SqlCommand cmd1 = new SqlCommand(query1, con);
            //cmd1.ExecuteNonQuery();
            //con.Close();

            //con.Open();
            //SqlCommand cmd2 = new SqlCommand(query2, con);
            //cmd2.ExecuteNonQuery();
            //con.Close();

            DateTime from = DateTime.Parse(dateTimePicker1.Value.ToShortDateString() + " 05:00:00 AM");
            DateTime to = DateTime.Parse(dateTimePicker2.Value.ToShortDateString() + " 11:59:00 PM");
            MessageBox.Show(string.Format("{0}", from));
            MessageBox.Show(string.Format("{0}", to));



            string cs = ConfigurationManager.ConnectionStrings["Multiline_db"].ConnectionString;


            try
            {
                using (SqlConnection conn = new SqlConnection(cs))
                {

                    //calling stored procedure sp_SalesHistoryPerCustAllItemSum in Multiline_db
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("reportcalc", conn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.AddWithValue("@startdate", from);
                    cmd.Parameters.AddWithValue("@endate", to);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error info:" + ex.Message);
            }

            //SqlCommand cmd3 = new SqlCommand("select * from TimeReport", con);
            SqlCommand cmd3 = new SqlCommand(query1, con);
            cmd3.CommandType = CommandType.Text;
            con.Open();
            DataTable dt = new DataTable();
            dt.Load(cmd3.ExecuteReader());
            dataGridView1.DataSource = dt;
            con.Close();

            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CReportViewer rv = new CReportViewer();
            rv.Show();
        }

        private void ReportPreview_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
        }
    }
}
