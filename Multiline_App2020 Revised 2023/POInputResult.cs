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
    public partial class POInputResult : Form
    {
        public POInputResult(string PONum)
        {
            InitializeComponent();

            //Data Connection
            string cs = ConfigurationManager.ConnectionStrings["Multiline_db"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(cs))
            {
                //calling stored procedure sp_ItemLocationByPO in Multiline_db
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_ItemLocationByPO", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PO", Int32.Parse(PONum));
                cmd.ExecuteNonQuery();

                SqlCommand cmd1 = new SqlCommand("SELECT * FROM po_rev_pw_pl", conn);



                using (SqlDataReader rdr = cmd1.ExecuteReader())

                {

                    DataTable table = new DataTable();
                    table.Columns.Add("PO#");
                    table.Columns.Add("Line#");
                    table.Columns.Add("Item ID");
                    table.Columns.Add("Size");
                    table.Columns.Add("Description");
                    table.Columns.Add("Received_Qty");
                    table.Columns.Add("Qty_Onhand");
                    table.Columns.Add("Committed_Qty");
                    table.Columns.Add("Bin_Location1");
                    table.Columns.Add("Bin_Location2");

                    while (rdr.Read())
                    {
                        DataRow dataRow = table.NewRow();

                        dataRow["PO#"] = rdr["PO#"];
                        dataRow["Line#"] = rdr["LINE#"];
                        dataRow["Item ID"] = rdr["PART#"];
                        dataRow["Size"] = rdr["SIZE"];
                        dataRow["Description"] = rdr["DESCRIPTION"];
                        dataRow["Received_Qty"] = rdr["RECEIVED_QTY"];
                        dataRow["Qty_Onhand"] = rdr["ON_HAND"];
                        dataRow["Committed_Qty"] = rdr["COMMIT_QTY"];
                        dataRow["Bin_Location1"] = rdr["BIN_LOCATION1"];
                        dataRow["Bin_Location2"] = rdr["BIN_LOCATION2"];



                        table.Rows.Add(dataRow);
                    }


                    dataGridView1.DataSource = table;






                }

            }


        }


    }
}