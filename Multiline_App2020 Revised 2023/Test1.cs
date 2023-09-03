using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace Multiline_App2020_Revised_2023
{


    public partial class Test1 : Form
    {

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

        public Test1()
        {
            InitializeComponent();
        }




        private void Test1_Load(object sender, EventArgs e)
        {

            //string cs = ConfigurationManager.ConnectionStrings["Multiline_db"].ConnectionString;
            //using (SqlConnection conn = new SqlConnection(cs))
            //{
            //    conn.Open();
            //    SqlCommand cmd = new SqlCommand("sp_PendingInvoices", conn);
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.ExecuteNonQuery();

            //    using (SqlDataReader rdr = cmd.ExecuteReader())

            //    {

            //        DataTable table = new DataTable();

            //        table.Columns.Add("ORDER_NO");
            //        table.Columns.Add("REVISION");
            //        table.Columns.Add("DATE");
            //        table.Columns.Add("CUST_ID");
            //        table.Columns.Add("CUST_NAME");
            //        table.Columns.Add("SALES_ID");


            //        while (rdr.Read())
            //        {
            //            DataRow dr = table.NewRow();

            //            dr["ORDER_NO"] = rdr["BOL_NUM"];
            //            dr["REVISION"] = rdr["REVISION"];
            //            dr["DATE"] = rdr["SHP_PRT_DATE"];
            //            dr["CUST_ID"] = rdr["CUST_ID"];
            //            dr["CUST_NAME"] = rdr["CUST_NAME"];
            //            dr["SALES_ID"] = rdr["SALE_ID"];


            //            table.Rows.Add(dr);
            //        }






        }




        private void button1_Click(object sender, EventArgs e)
        {

            string cs = ConfigurationManager.ConnectionStrings["Multiline_db"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_SalesHistoryAllCustAllItemSum", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@startdate", txtStart.Text);
                cmd.Parameters.AddWithValue("@enddate", txtEnd.Text);

                //cmd.Parameters.AddWithValue("@startdate",Text);

                cmd.ExecuteNonQuery();

                using (SqlDataReader rdr = cmd.ExecuteReader())

                {

                    DataTable table = new DataTable();

                    table.Columns.Add("ITEM_ID");
                    table.Columns.Add("SIZE");
                    table.Columns.Add("DESCRIPTION");
                    table.Columns.Add("SHIP_QTY");
                    table.Columns.Add("UNIT_PRICE");
                    table.Columns.Add("TOTAL_AMT");


                    while (rdr.Read())
                    {
                        DataRow dr = table.NewRow();

                        dr["ITEM_ID"] = rdr["ITEM_ID"];
                        dr["SIZE"] = rdr["SIZE"];
                        dr["DESCRIPTION"] = rdr["DESCRIPTION"];
                        dr["SHIP_QTY"] = rdr["SHIP_QTY"];
                        dr["UNIT_PRICE"] = rdr["UNIT_PRICE"];
                        dr["TOTAL_AMT"] = rdr["SELL_AMT"];


                        table.Rows.Add(dr);
                    }


                    dataGridView1.DataSource = table;






                }
            }


        }

    }
}