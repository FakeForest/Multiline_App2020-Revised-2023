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
    public partial class Promo : Form
    {
        public static String RptType5 = "";
        public static string status = "";
        public static DateTime from;
        public static DateTime to;
        public static string salesid = "";

        public Promo()
        {
            InitializeComponent();
        }

        public static bool IsDate(string tempDate)
        {
            DateTime fromDateValue;
            var formats = new[] { "dd/MM/yyyy", "yyyy-MM-dd" };
            if (DateTime.TryParseExact(tempDate, formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out fromDateValue))
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            txtDate1.Text = dateTimePicker1.Value.ToShortDateString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            txtDate2.Text = dateTimePicker2.Value.ToShortDateString();
        }

        private void dateTimePicker1_DropDown(object sender, EventArgs e)
        {
            dateTimePicker1.ValueChanged -= dateTimePicker1_ValueChanged;

        }

        private void dateTimePicker2_DropDown(object sender, EventArgs e)
        {
            dateTimePicker2.ValueChanged -= dateTimePicker2_ValueChanged;
        }

        private void dateTimePicker1_CloseUp(object sender, EventArgs e)
        {
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            dateTimePicker1_ValueChanged(sender, e);
        }

        private void dateTimePicker2_CloseUp(object sender, EventArgs e)
        {
            dateTimePicker2.ValueChanged += dateTimePicker2_ValueChanged;
            dateTimePicker2_ValueChanged(sender, e);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //Test Empty String in txtDate1 for Start Date
            if (string.IsNullOrEmpty(txtDate1.Text))
            {
                MessageBox.Show("Please input Start Date");
                txtDate1.Focus();
                return;
            }

            //Test Empty String in txtDate2 for End Date
            if (string.IsNullOrEmpty(txtDate2.Text))
            {
                MessageBox.Show("Please input End Date");
                txtDate2.Focus();
                return;
            }

            //Test validity of start date
            if (IsDate(txtDate1.Text))
            {

            }
            else
            {
                MessageBox.Show("Please input a valid Start Date");
                txtDate1.Clear();
                txtDate1.Focus();
                return;
            }


            //Test validity of end date
            if (IsDate(txtDate2.Text))
            {

            }
            else
            {
                MessageBox.Show("Please input a valid End Date");
                txtDate2.Clear();
                txtDate2.Focus();
                return;
            }

            //Test Empty String in txtSalesId 
            if (string.IsNullOrEmpty(txtSalesId.Text))
            {
                MessageBox.Show("Please input Sales Id");
                txtSalesId.Focus();
                return;
            }




            from = DateTime.Parse(txtDate1.Text);
            to = DateTime.Parse(txtDate2.Text);
            salesid = txtSalesId.Text;




            string cs = ConfigurationManager.ConnectionStrings["Multiline_db"].ConnectionString;


            try
            {
                using (SqlConnection conn = new SqlConnection(cs))
                {

                    //calling stored procedure sp_SalesHistoryPerCustAllItemSum in Multiline_db
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_Promo", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@startDate", from);
                    cmd.Parameters.AddWithValue("@endDate", to);
                    cmd.Parameters.AddWithValue("@salesid", salesid);

                    cmd.ExecuteNonQuery();





                }
            }


            catch (Exception ex)
            {
                MessageBox.Show("Error info:" + ex.Message);
            }


            RptType5 = "Promo";
            status = "Promo";
            OutputReport fmPromo = new OutputReport();
            fmPromo.ShowDialog();
            status = "";
            //this.Hide();
            return;


        }


    }
}


