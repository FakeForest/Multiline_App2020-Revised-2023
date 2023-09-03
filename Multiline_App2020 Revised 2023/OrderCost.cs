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
    public partial class OrderCost : Form
    {
        public OrderCost()
        {
            InitializeComponent();
        }

        //private void label2_Click(object sender, EventArgs e)
        //{

        //}

        private void OrderCost_Load(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {

            //Test Empty String in TxtOrderNo
            if (string.IsNullOrEmpty(txtOrderNo.Text))
            {
                MessageBox.Show("Please enter an order number");
                txtOrderNo.Focus();
                return;
            }

            //Test if order number enter is a valid numeric number
            int num = -1;
            if (!int.TryParse(txtOrderNo.Text, out num))
            {
                MessageBox.Show("Order Number  must be numeric, please input again");
                txtOrderNo.Clear();
                txtOrderNo.Focus();
                return;
            }


            //Test Empty String in txtRevision
            if (string.IsNullOrEmpty(txtRevision.Text))
            {
                MessageBox.Show("Please enter a Revision No");
                txtRevision.Focus();
                return;
            }


            //Test if revision number enter is a valid numeric number
            int num1 = -1;
            if (!int.TryParse(txtRevision.Text, out num1))
            {
                MessageBox.Show("Revision Number  must be numeric, please input again");
                txtRevision.Clear();
                txtRevision.Focus();
                return;
            }


            //Data Connection, calling stored procedure sp_OrderCost

            string cs = ConfigurationManager.ConnectionStrings["Multiline_db"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(cs))
            {
                using (SqlCommand cmd = new SqlCommand("sp_OrderCost", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OrderNum", Int32.Parse(txtOrderNo.Text));
                    cmd.Parameters.AddWithValue("@RevNum", Int32.Parse(txtRevision.Text));


                    conn.Open();
                    cmd.ExecuteNonQuery();

                    SqlCommand cmd1 = new SqlCommand("SELECT * FROM qry_order_cost", conn);

                    using (SqlDataReader rdr = cmd1.ExecuteReader())

                    {
                        if (rdr.Read())
                        {
                            MessageBox.Show(rdr[0].ToString(), "Order Cost");
                        }

                        else
                        {

                            MessageBox.Show("The order number is invalid");
                            txtOrderNo.Clear();
                            txtOrderNo.Focus();
                            return;

                        }

                    }
                }




            }




        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
