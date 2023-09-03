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
    public partial class SalesBooking : Form
    {
        public static String RptType6 = "";
        public static string status = "";
        public static string salesid;
        public static string custid;

        public SalesBooking()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SalesBooking_Load(object sender, EventArgs e)
        {
            radioAllSalesAllCust.Enabled = true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (radioPerSales.Checked == true && string.IsNullOrEmpty(txtSalesId.Text))
            {

                MessageBox.Show("Please input Sales Id");
                txtSalesId.Focus();
                return;
            }

            if (radioPerCust.Checked == true && string.IsNullOrEmpty(txtCustId.Text))
            {

                MessageBox.Show("Please input Customer Account Id");
                txtCustId.Focus();
                return;
            }

            if (radioAllSalesAllCust.Checked == true)
            {

                string cs = ConfigurationManager.ConnectionStrings["Multiline_db"].ConnectionString;
                try
                {
                    using (SqlConnection conn = new SqlConnection(cs))
                    {

                        //calling stored procedure sp_BookingAllSalesAllCust in Multiline_db
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("sp_BookingAllSalesAllCust", conn);

                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.ExecuteNonQuery();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error info:" + ex.Message);
                }
                RptType6 = "BookingAllSalesAllCust";
                status = "SalesBooking";
                OutputReport fmBookingAllSalesAllCust = new OutputReport();
                fmBookingAllSalesAllCust.ShowDialog();
                status = "";
                //this.Hide();
                return;

            }


            if (radioPerSales.Checked == true)
            {
                salesid = txtSalesId.Text;
                string cs = ConfigurationManager.ConnectionStrings["Multiline_db"].ConnectionString;
                try
                {
                    using (SqlConnection conn = new SqlConnection(cs))
                    {

                        //calling stored procedure sp_BookingAllSalesAllCust in Multiline_db
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("sp_BookingPerSalesAllCust", conn);


                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@salesid", salesid);
                        cmd.ExecuteNonQuery();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error info:" + ex.Message);
                }
                RptType6 = "BookingPerSalesAllCust";
                status = "SalesBooking";
                OutputReport fmBookingPerSalesAllCust = new OutputReport();
                fmBookingPerSalesAllCust.ShowDialog();
                status = "";
                //this.Hide();
                return;

            }


            if (radioPerCust.Checked == true)
            {
                custid = txtCustId.Text;
                string cs = ConfigurationManager.ConnectionStrings["Multiline_db"].ConnectionString;
                try
                {
                    using (SqlConnection conn = new SqlConnection(cs))
                    {

                        //calling stored procedure sp_BookingAllSalesAllCust in Multiline_db
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("sp_BookingAllSalesPerCust", conn);


                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@custid", custid);
                        cmd.ExecuteNonQuery();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error info:" + ex.Message);
                }
                RptType6 = "BookingAllSalesPerCust";
                status = "SalesBooking";
                OutputReport fmBookingAllSalesPerCust = new OutputReport();
                fmBookingAllSalesPerCust.ShowDialog();
                status = "";
                //this.Hide();
                return;

            }




        }


    }

}




