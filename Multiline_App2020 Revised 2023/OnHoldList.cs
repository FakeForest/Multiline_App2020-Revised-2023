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
    public partial class OnHoldList : Form
    {
        public static string RptType1 = "";
        public static string status = "";

        public OnHoldList()
        {
            InitializeComponent();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OnHoldList_Load(object sender, EventArgs e)
        {
            radioAll.Checked = true;


        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (radioAll.Checked == true)
            {


                try
                {
                    //create table AR_Onhold in multiline_db by calling stored procedure sp_AR_Onhold
                    string cs = ConfigurationManager.ConnectionStrings["Multiline_db"].ConnectionString;
                    using (SqlConnection conn = new SqlConnection(cs))

                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("sp_AR_Onhold", conn);
                        cmd.ExecuteNonQuery();
                    }

                    //Open OutputReport form
                    RptType1 = "OnHoldAll";
                    status = "OnHoldList";
                    OutputReport fmOnHold = new OutputReport();
                    fmOnHold.ShowDialog();
                    status = "";
                    //this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Outer Exception: " + ex.Message);
                }


            }

            if (radioSalesId.Checked == true)
            {

                //Test Empty String in Textbox name txtSalesId
                if (string.IsNullOrEmpty(txtSalesId.Text))
                {
                    MessageBox.Show("Please enter Sales Id");
                    txtSalesId.Focus();
                    return;
                }


                //Test if user has entered a valid Sales Id
                try
                {
                    string cs = ConfigurationManager.ConnectionStrings["Multiline_db"].ConnectionString;

                    using (SqlConnection conn = new SqlConnection(cs))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("sp_SalesRep_Pick", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@salesrep", txtSalesId.Text);

                        cmd.ExecuteNonQuery();

                        SqlCommand cmd1 = new SqlCommand("SELECT * FROM dbo.Sales_reps", conn);

                        using (SqlDataReader rdr = cmd1.ExecuteReader())

                        {
                            if (rdr.HasRows)
                            {

                            }
                            else
                            {

                                MessageBox.Show("Sales rep not found, please re-enter");
                                txtSalesId.Clear();
                                txtSalesId.Focus();
                                return;
                            }
                        }
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Outer Exception: " + ex.Message);
                }



                //create table AR_OnHold_BySales in multiline_db by calling stored procedure sp_AR_Onhold_BySales
                try
                {
                    string cs = ConfigurationManager.ConnectionStrings["Multiline_db"].ConnectionString;
                    using (SqlConnection conn = new SqlConnection(cs))

                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("sp_AR_Onhold_BySales", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@salesid", txtSalesId.Text);
                        cmd.ExecuteNonQuery();
                    }


                    //Open OutputReport form
                    RptType1 = "OnHoldAll_BySales";
                    status = "OnHoldList";
                    OutputReport fmOnHold_BySales = new OutputReport();
                    fmOnHold_BySales.ShowDialog();
                    status = "";
                    //this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Outer Exception: " + ex.Message);
                }


            }

        }

        //private void radioSalesId_EnabledChanged(object sender, EventArgs e)
        //{
        //    txtSalesId.Enabled = true;
        //}
    }
}
