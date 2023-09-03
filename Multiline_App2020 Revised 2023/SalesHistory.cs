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
using System.Globalization;



namespace Multiline_App2020_Revised_2023
{
    public partial class SalesHistory : Form
    {
        public static String RptType2 = "";
        public static string status = "";
        public static DateTime from;
        public static DateTime to;
        public static string item = "";
        public static string custid = "";

        public SalesHistory()
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


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {



        }

        //private void comboCustList_Click(object sender, EventArgs e)
        //{


        //    string cs = ConfigurationManager.ConnectionStrings["Multiline_db"].ConnectionString;
        //    using (SqlConnection conn = new SqlConnection(cs))

        //    {
        //        //calling stored procedure sp_CustList_SaleHistory in Multiline_db
        //        SqlCommand cmd = new SqlCommand("sp_CustList_SaleHistory", conn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        conn.Open();
        //        cmd.ExecuteNonQuery();
        //        SqlDataAdapter da = new SqlDataAdapter("SELECT{fn CONCAT(c.cu_cust_id, {fn CONCAT('  ',c.cu_name)})} AS Customer,c.* FROM qry_custhis_customers c; ", conn);

        //        DataSet ds = new DataSet();
        //        da.Fill(ds);

        //        DataTable table = new DataTable();
        //        table.Columns.Add("Customer");


        //        ds.Tables.Add(table);
        //        foreach (DataColumn dc in table.Columns)
        //        {
        //            dc.ColumnMapping = MappingType.Attribute;
        //        }

        //        comboCustList.DataBindings.Clear();
        //        comboCustList.DataSource = ds.Tables[0];

        //        comboCustList.DisplayMember = "Customer";


        //    }



        //}

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void dateTimePicker1_Leave(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {


        }

        private void dateTimePicker1_EnabledChanged(object sender, EventArgs e)
        {



            txtDate1.Text = dateTimePicker1.Value.ToShortDateString();


        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            txtDate1.Text = dateTimePicker1.Value.ToShortDateString();

        }

        private void dateTimePicker1_DropDown(object sender, EventArgs e)
        {
            dateTimePicker1.ValueChanged -= dateTimePicker1_ValueChanged;

        }

        private void dateTimePicker1_CloseUp(object sender, EventArgs e)
        {
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            dateTimePicker1_ValueChanged(sender, e);
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            txtDate2.Text = dateTimePicker2.Value.ToShortDateString();
        }

        private void dateTimePicker2_DropDown(object sender, EventArgs e)
        {
            dateTimePicker2.ValueChanged -= dateTimePicker1_ValueChanged;
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


            //Test the validity of Date in txtDated1

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


            //Test the validity of Date in txtDated2

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



            //case #1 sales history for all customers, all items and Summary

            if (radioCustAll.Checked == true && radioItemAll.Checked == true && cBoxSum.Checked == true)



            {

                from = DateTime.Parse(txtDate1.Text);
                to = DateTime.Parse(txtDate2.Text);


                string cs = ConfigurationManager.ConnectionStrings["Multiline_db"].ConnectionString;

                try
                {
                    using (SqlConnection conn = new SqlConnection(cs))
                    {

                        //calling stored procedure sp_SalesHistoryAllCustAllItemSum in Multiline_db
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("sp_SalesHistoryAllCustAllItemSum", conn);

                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@startDate", from);
                        cmd.Parameters.AddWithValue("@endDate", to);

                        cmd.ExecuteNonQuery();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error info:" + ex.Message);
                }

                RptType2 = "AllCustAllItemSum";
                status = "SalesHistory";
                OutputReport fmSalesHistoryAllCustAllItemSum = new OutputReport();
                fmSalesHistoryAllCustAllItemSum.ShowDialog();
                status = "";
                //this.Hide();
                return;
            }

            //case #2 sales history for all customers, all items and detail

            else if (radioCustAll.Checked == true && radioItemAll.Checked == true && cBoxSum.Checked == false)
            {
                from = DateTime.Parse(txtDate1.Text);
                to = DateTime.Parse(txtDate2.Text);


                string cs = ConfigurationManager.ConnectionStrings["Multiline_db"].ConnectionString;
                try
                {
                    using (SqlConnection conn = new SqlConnection(cs))
                    {

                        //calling stored procedure sp_SalesHistoryAllCustAllItemDetail in Multiline_db
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("sp_SalesHistoryAllCustAllItemDetail", conn);

                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@startDate", from);
                        cmd.Parameters.AddWithValue("@endDate", to);

                        cmd.ExecuteNonQuery();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error info:" + ex.Message);
                }
                RptType2 = "AllCustAllItemDetail";
                status = "SalesHistory";
                OutputReport fmSalesHistoryAllCustAllItemDetail = new OutputReport();
                fmSalesHistoryAllCustAllItemDetail.ShowDialog();
                status = "";
                //this.Hide();
                return;
            }




            //case #3 sales history for all customers, one item and summary
            else if (radioCustAll.Checked == true && radioItemId.Checked == true && cBoxSum.Checked == true)
            {

                //Test Empty String in Textbox name txtItemId
                if (string.IsNullOrEmpty(txtItemId.Text))
                {
                    MessageBox.Show("ItemId can not be empty, please input Item Id");
                    txtItemId.Focus();
                    return;
                }

                from = DateTime.Parse(txtDate1.Text);
                to = DateTime.Parse(txtDate2.Text);
                item = txtItemId.Text;

                string cs = ConfigurationManager.ConnectionStrings["Multiline_db"].ConnectionString;
                try
                {
                    using (SqlConnection conn = new SqlConnection(cs))
                    {

                        //calling stored procedure sp_SalesHistoryAllCustPerItemDetail in Multiline_db
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("sp_SalesHistoryAllCustPerItemSum", conn);

                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@startDate", from);
                        cmd.Parameters.AddWithValue("@endDate", to);
                        cmd.Parameters.AddWithValue("@item", item);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error info:" + ex.Message);
                }



                RptType2 = "AllCustPerItemSum";
                status = "SalesHistory";
                OutputReport fmSalesHistoryAllCustPerItemSum = new OutputReport();
                fmSalesHistoryAllCustPerItemSum.ShowDialog();
                status = "";
                //this.Hide();
                return;



            }

            //case #4 sales history for all customers, one item and detail
            else if (radioCustAll.Checked == true && radioItemId.Checked == true && cBoxSum.Checked == false)
            {

                //Test Empty String in Textbox name txtItemId
                if (string.IsNullOrEmpty(txtItemId.Text))
                {
                    MessageBox.Show("ItemId can not be empty, please input Item Id");
                    txtItemId.Focus();
                    return;
                }

                from = DateTime.Parse(txtDate1.Text);
                to = DateTime.Parse(txtDate2.Text);
                item = txtItemId.Text;

                string cs = ConfigurationManager.ConnectionStrings["Multiline_db"].ConnectionString;
                try
                {
                    using (SqlConnection conn = new SqlConnection(cs))
                    {

                        //calling stored procedure sp_SalesHistoryAllCustPerItemDetail in Multiline_db
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("sp_SalesHistoryAllCustPerItemDetail", conn);

                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@startDate", from);
                        cmd.Parameters.AddWithValue("@endDate", to);
                        cmd.Parameters.AddWithValue("@item", item);

                        cmd.ExecuteNonQuery();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error info:" + ex.Message);
                }
                RptType2 = "AllCustPerItemDetail";
                status = "SalesHistory";
                OutputReport fmSalesHistoryAllCustPerItemDetail = new OutputReport();
                fmSalesHistoryAllCustPerItemDetail.ShowDialog();
                status = "";
                //this.Hide();
                return;

            }

            //case #5 sales history for one customer, all items and summary
            else if (radioCustId.Checked == true && radioItemAll.Checked == true && cBoxSum.Checked == true)

            {
                //Test Empty String in Textbox name txtCustId
                if (string.IsNullOrEmpty(txtCustId.Text))
                {
                    MessageBox.Show("Please select a customer");
                    txtCustId.Focus();
                    return;
                }

                from = DateTime.Parse(txtDate1.Text);
                to = DateTime.Parse(txtDate2.Text);
                custid = txtCustId.Text;


                string cs = ConfigurationManager.ConnectionStrings["Multiline_db"].ConnectionString;


                try
                {
                    using (SqlConnection conn = new SqlConnection(cs))
                    {

                        //calling stored procedure sp_SalesHistoryPerCustAllItemSum in Multiline_db
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("sp_SalesHistoryPerCustAllItemSum", conn);

                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@startDate", from);
                        cmd.Parameters.AddWithValue("@endDate", to);
                        cmd.Parameters.AddWithValue("@custid", custid);

                        cmd.ExecuteNonQuery();

                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error info:" + ex.Message);
                }

                RptType2 = "PerCustAllItemSum";
                status = "SalesHistory";
                OutputReport fmSalesHistoryPerCustAllItemSum = new OutputReport();
                fmSalesHistoryPerCustAllItemSum.ShowDialog();
                status = "";
                //this.Hide();
                return;

            }
            //Case #6 sales history for one customer, all items and detail
            else if (radioCustId.Checked == true && radioItemAll.Checked == true && cBoxSum.Checked == false)

            { //Test Empty String in Textbox name txtCustId
                if (string.IsNullOrEmpty(txtCustId.Text))
                {
                    MessageBox.Show("Please select a customer");
                    txtCustId.Focus();
                    return;
                }

                from = DateTime.Parse(txtDate1.Text);
                to = DateTime.Parse(txtDate2.Text);
                custid = txtCustId.Text;


                string cs = ConfigurationManager.ConnectionStrings["Multiline_db"].ConnectionString;


                try
                {
                    using (SqlConnection conn = new SqlConnection(cs))
                    {

                        //calling stored procedure sp_SalesHistoryPerCustAllItemSum in Multiline_db
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("sp_SalesHistoryPerCustAllItemDetail", conn);

                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@startDate", from);
                        cmd.Parameters.AddWithValue("@endDate", to);
                        cmd.Parameters.AddWithValue("@custid", custid);

                        cmd.ExecuteNonQuery();

                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error info:" + ex.Message);
                }

                RptType2 = "PerCustAllItemDetail";
                status = "SalesHistory";
                OutputReport fmSalesHistoryPerCustAllItemDetail = new OutputReport();
                fmSalesHistoryPerCustAllItemDetail.ShowDialog();
                status = "";
                //this.Hide();
                return;

            }

            //case #7  sales history for one customer, one item and summary
            else if (radioCustId.Checked == true && radioItemId.Checked == true && cBoxSum.Checked == true)

            {//Test Empty String in Textbox name txtCustId
                if (string.IsNullOrEmpty(txtCustId.Text))
                {
                    MessageBox.Show("Please select a customer");
                    txtCustId.Focus();
                    return;
                }

                // Test Empty String in Textbox name txtItemId
                if (string.IsNullOrEmpty(txtItemId.Text))
                {
                    MessageBox.Show("Please enter an Item Id");
                    txtItemId.Focus();
                    return;
                }



                from = DateTime.Parse(txtDate1.Text);
                to = DateTime.Parse(txtDate2.Text);
                custid = txtCustId.Text;
                item = txtItemId.Text;

                string cs = ConfigurationManager.ConnectionStrings["Multiline_db"].ConnectionString;


                try
                {
                    using (SqlConnection conn = new SqlConnection(cs))
                    {

                        //calling stored procedure sp_SalesHistoryPerCustAllItemSum in Multiline_db
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("sp_SalesHistoryPerCustPerItemSum", conn);

                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@startDate", from);
                        cmd.Parameters.AddWithValue("@endDate", to);
                        cmd.Parameters.AddWithValue("@custid", custid);
                        cmd.Parameters.AddWithValue("@itemid", item);

                        cmd.ExecuteNonQuery();

                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error info:" + ex.Message);
                }

                RptType2 = "PerCustPerItemSum";
                status = "SalesHistory";
                OutputReport fmSalesHistoryPerCustPerItemSum = new OutputReport();
                fmSalesHistoryPerCustPerItemSum.ShowDialog();
                status = "";
                //this.Hide();
                return;





            }


            //case #8  sales history for one customer, one item and detail
            else if (radioCustId.Checked == true && radioItemId.Checked == true && cBoxSum.Checked == false)

            {
                //Test Empty String in Textbox name txtCustId
                if (string.IsNullOrEmpty(txtCustId.Text))
                {
                    MessageBox.Show("Please select a customer");
                    txtCustId.Focus();
                    return;
                }

                // Test Empty String in Textbox name txtItemId
                if (string.IsNullOrEmpty(txtItemId.Text))
                {
                    MessageBox.Show("Please enter an Item Id");
                    txtItemId.Focus();
                    return;
                }



                from = DateTime.Parse(txtDate1.Text);
                to = DateTime.Parse(txtDate2.Text);
                custid = txtCustId.Text;
                item = txtItemId.Text;

                string cs = ConfigurationManager.ConnectionStrings["Multiline_db"].ConnectionString;


                try
                {
                    using (SqlConnection conn = new SqlConnection(cs))
                    {

                        //calling stored procedure sp_SalesHistoryPerCustAllItemSum in Multiline_db
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("sp_SalesHistoryPerCustPerItemDetail", conn);

                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@startDate", from);
                        cmd.Parameters.AddWithValue("@endDate", to);
                        cmd.Parameters.AddWithValue("@custid", custid);
                        cmd.Parameters.AddWithValue("@itemid", item);

                        cmd.ExecuteNonQuery();

                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error info:" + ex.Message);
                }

                RptType2 = "PerCustPerItemDetail";
                status = "SalesHistory";
                OutputReport fmSalesHistoryPerCustPerItemDetail = new OutputReport();
                fmSalesHistoryPerCustPerItemDetail.ShowDialog();
                status = "";
                //this.Hide();
                return;







            }


        }



        private void SalesHistory_Load(object sender, EventArgs e)
        {
            cBoxSum.Checked = true;
            txtItemId.Enabled = false;
            btnItem.Enabled = false;
        }





        private void btnCustId_Click(object sender, EventArgs e)
        {
            RptType2 = "SearchCustId";

            string cs = ConfigurationManager.ConnectionStrings["Multiline_db"].ConnectionString;

            try
            {
                using (SqlConnection conn = new SqlConnection(cs))

                {
                    //calling stored procedure sp_CustList_SaleHistory in Multiline_db
                    SqlCommand cmd = new SqlCommand("sp_CustList", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error info:" + ex.Message);
            }
            Search fmSearch = new Search();
            fmSearch.ShowDialog();
            txtCustId.Text = fmSearch.result;
        }

        private void radioCustAll_CheckedChanged(object sender, EventArgs e)
        {
            if (radioCustAll.Checked == true)
            {
                txtCustId.Text = "";
                txtCustId.Enabled = false;
                btnCustId.Enabled = false;

            }
        }

        private void radioCustId_CheckedChanged(object sender, EventArgs e)
        {
            if (radioCustId.Checked == true)
            {
                txtCustId.Enabled = true;
                btnCustId.Enabled = true;

            }
        }

        private void radioItemAll_CheckedChanged(object sender, EventArgs e)
        {
            if (radioItemAll.Checked == true)
            {
                txtItemId.Text = "";
                txtItemId.Enabled = false;
                btnItem.Enabled = false;

            }
        }

        private void radioItemId_CheckedChanged(object sender, EventArgs e)
        {
            if (radioItemId.Checked == true)
            {
                txtItemId.Enabled = true;
                btnItem.Enabled = true;

            }


        }

        private void btnItem_Click(object sender, EventArgs e)
        {
            RptType2 = "SearchItemId";
            string cs = ConfigurationManager.ConnectionStrings["Multiline_db"].ConnectionString;

            try
            {
                using (SqlConnection conn = new SqlConnection(cs))

                {
                    //calling stored procedure sp_CustList_SaleHistory in Multiline_db
                    SqlCommand cmd = new SqlCommand("sp_Items", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error info:" + ex.Message);
            }
            Search fmSearch = new Search();
            fmSearch.ShowDialog();
            txtItemId.Text = fmSearch.result;
        }
    }
}