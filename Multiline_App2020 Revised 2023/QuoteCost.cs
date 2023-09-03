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
    public partial class QuoteCost : Form
    {
        public QuoteCost()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

            //Test for empty String in txtQuoteNo

            if (string.IsNullOrEmpty(txtQuoteNo.Text))
            {
                MessageBox.Show("Please enter a quote number");
                txtQuoteNo.Focus();
                return;
            }

            //Test if quote number is a valid numeric number
            int num = -1;
            if (!int.TryParse(txtQuoteNo.Text, out num))
            {
                MessageBox.Show("Quote number  must be numeric, please input again");
                txtQuoteNo.Clear();
                txtQuoteNo.Focus();
                return;
            }



            //Data Connection, calling stored procedure sp_OrderCost

            string cs = ConfigurationManager.ConnectionStrings["Multiline_db"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(cs))
            {
                using (SqlCommand cmd = new SqlCommand("sp_QuoteCost", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@QuoteNum", Int32.Parse(txtQuoteNo.Text));

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    SqlCommand cmd1 = new SqlCommand("SELECT * FROM qry_quote_cost", conn);

                    using (SqlDataReader rdr = cmd1.ExecuteReader())

                    {
                        if (rdr.Read())
                        {
                            MessageBox.Show(rdr[0].ToString(), "Quote Cost");
                        }

                        else
                        {

                            MessageBox.Show("The order number is invalid");
                            txtQuoteNo.Clear();
                            txtQuoteNo.Focus();
                            return;

                        }

                    }
                }




            }



















        }
    }
}
