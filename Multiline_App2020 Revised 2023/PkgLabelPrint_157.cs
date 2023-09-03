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
    public partial class PkgLabelPrint_157 : Form
    {
        public PkgLabelPrint_157()
        {
            InitializeComponent();
            //User name initial,  i.e. MB for Martis Boyce
            comboUserId.Text = "MB";

        }


        private void btnPrint_Click(object sender, EventArgs e)
        {

            //Test if Item Id is missing
            if (string.IsNullOrEmpty(txtItemId.Text))
            {
                MessageBox.Show("ItemId can not be empty, please input Item Id");
                txtItemId.Focus();
                return;
            }

            //Test if Package Size Quantity is missing
            if (string.IsNullOrEmpty(txtPackSize.Text))
            {
                MessageBox.Show("Unit of Package must be numeric, please input again");
                txtPackSize.Focus();
                return;

            }
            int num = -1;
            if (!int.TryParse(txtPackSize.Text, out num))
            {


                MessageBox.Show("Package size must be numeric, please input again");
                txtPackSize.Focus();
                return;

            }




            //Test if number of print is missing
            if (string.IsNullOrEmpty(txtNumofPrint.Text))
            {
                MessageBox.Show("Print quantity cannot be empty");
                txtNumofPrint.Focus();
                return;
            }

            int num1 = -1;
            if (!int.TryParse(txtNumofPrint.Text, out num1))
            {

                MessageBox.Show("Print quantity must be numeric, please input again");
                txtNumofPrint.Focus();
                return;

            }


            if (string.IsNullOrEmpty(txtTotalPackage.Text))
            {
                txtTotalPackage.Text = "";
            }

            if (string.IsNullOrEmpty(txtPO.Text))
            {
                txtPO.Text = "";

            }


            string userId = comboUserId.Text;


            Select();
            //**********************************************//
        }

        //private void Select()
        //{

        //    string cs = ConfigurationManager.ConnectionStrings["Multiline_db"].ConnectionString;
        //    //SqlConnection conn = new SqlConnection(cs);


        //    //string cmdStr = "SELECT pl.prlkp_prod_id as itemId, pl.prlkp_lang1_2_desc  as size, pl.prlkp_lang1_upper_desc as DESCRIPTION, pw.pw_bin_location1 as LOCATION1, pw.pw_bin_location2 as LOCATION2, pw.pw_bin_location3 as LOCATION3 from [MLWEBSVR\\STREAMLINE].sisl_data01.dbo.product_lookup as pl inner join sisl_data01.dbo. prod_warehouse as pw on pl.prlkp_prod_id=pw.pw_prod_id where pw.pw_whs_id='00'and pl.prlkp_prod_id=@ItemId";


        //    using (SqlConnection conn = new SqlConnection(cs))
        //    {

        //        string cmdStr = "SELECT pl.prlkp_prod_id as itemId, pl.prlkp_lang1_2_desc  as size, pl.prlkp_lang1_upper_desc as DESCRIPTION, pw.pw_bin_location1 as LOCATION1, pw.pw_bin_location2 as LOCATION2, pw.pw_bin_location3 as LOCATION3 from [MLWEBSVR\\STREAMLINE].sisl_data01.dbo.product_lookup as pl inner join sisl_data01.dbo. prod_warehouse as pw on pl.prlkp_prod_id=pw.pw_prod_id where pw.pw_whs_id='00'and pl.prlkp_prod_id=@ItemId";


        //        using (SqlCommand command = new SqlCommand(cmdStr, conn))
        //        {

        //            command.Parameters.AddWithValue("@ItemId", txtItemId.Text);

        //            //conn.Open();
        //            MessageBox.Show("success");

        //            //Test for Connection

        //            if (conn != null && conn.State == ConnectionState.Open)
        //            {
        //                //{
        //                //    // do something
        //                //    MessageBox.Show("success");
        //                //    // ...
        //                MessageBox.Show("success");
        //            }
        //            SqlDataReader reader = command.ExecuteReader();

        //            while (reader.Read())
        //            //{

        //            //    string output = "Item id: {0} Size: {1} Description : {2}";

        //            //    txtResult.Text = output;
        //            txtResult.Text = reader["ItemId"].ToString();

        //            //var dataTable = new DataTable();
        //            //dataTable.Load(reader);

        //            }

        //        }

        //    }







        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtItemId.Text = "";
            txtPackSize.Text = "";
            txtNumofPrint.Text = "";
            txtTotalPackage.Text = "";
            txtPO.Text = "";

        }
    }
}
