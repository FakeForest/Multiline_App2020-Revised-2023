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
    public partial class MainMenu : Form

    {
        public static string RptType = "";
        public static string status = "";
        public static string objects = "";
        public static string soq = "";

        public MainMenu()
        {
            InitializeComponent();
        }

        private void itemLocationByPOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //call POInput form
            POInput fmPOInput = new POInput();
            fmPOInput.ShowDialog();
        }

        private void salesHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SalesHistory fmSalesHistory = new SalesHistory();
            fmSalesHistory.ShowDialog();
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendEMail_11125 formEmail = new SendEMail_11125();
            formEmail.ShowDialog();



        }

        private void pendingInvoicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //create qry_Pending_Invoices in multiline_db by calling stored procedure sp_PendingInvoices
            string cs = ConfigurationManager.ConnectionStrings["Multiline_db"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(cs))

            {
                //calling stored procedure sp_PendingInvoices in Multiline_db
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_PendingInvoices", conn);


                cmd.ExecuteNonQuery();
            }

            //Open OutputReport form
            RptType = "PendingInvoices";
            status = "MainMenu";
            OutputReport fmPendingInvoices = new OutputReport();
            fmPendingInvoices.ShowDialog();
            status = "";
            //this.Hide();


        }

        private void openOrderListAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //create qry_Open_Order_List in multiline_db by calling stored procedure sp_OpenOrderAll
            string cs = ConfigurationManager.ConnectionStrings["Multiline_db"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(cs))

            {
                //calling stored procedure sp_PendingInvoices in Multiline_db
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_OpenOrderAll", conn);

                cmd.ExecuteNonQuery();
            }

            //Open OutputReport form
            RptType = "OpenOrderAll";
            status = "MainMenu";
            OutputReport fmOpenOrderAll = new OutputReport();
            fmOpenOrderAll.ShowDialog();
            status = "";
            //this.Hide();


        }
        private void salesBIllingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //call SalesBilling form
            SalesBilling fmSalesBilling = new SalesBilling();
            fmSalesBilling.ShowDialog();

        }

        private void openOrderListBatchPrintedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // call OpenOrderBatch form
            OpenOrdersBatch fmOpenOrderBatch = new OpenOrdersBatch();
            fmOpenOrderBatch.ShowDialog();
        }

        //private void quoteCostToolStripMenuItem_Click(object sender, EventArgs e)
        //{

        //}

        private void costOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //call OrderCost form
            OrderCost fmOrderCost = new OrderCost();
            fmOrderCost.ShowDialog();

        }

        private void costQuoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //call QuoteCost form
            QuoteCost fmQuoteCost = new QuoteCost();
            fmQuoteCost.ShowDialog();

        }

        private void epaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // call Epayment_11125 form
            Epayment_11125 fmEpayment_11125 = new Epayment_11125();
            fmEpayment_11125.ShowDialog();
        }

        private void test2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Test2 fmTest2 = new Test2();
            fmTest2.ShowDialog();
            //this.Hide();

        }

        private void test1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Test1 fmTest1 = new Test1();
            fmTest1.ShowDialog();
            //this.Hide();
        }

        private void itemNegativeQuantityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //string cs = ConfigurationManager.ConnectionStrings["Multiline_db"].ConnectionString;
            //using (SqlConnection conn = new SqlConnection(cs))
            //{
            //    conn.Open();
            //    SqlCommand cmd = new SqlCommand("sp_ItemNegQty", conn);
            //    cmd.CommandType = CommandType.StoredProcedure;

            //    cmd.ExecuteNonQuery();
            //}
            //RptType = "ItemNegQty";
            //OutputReport fmItemNegQty = new OutputReport();
            //    fmItemNegQty.Show();
            //     this.Hide();
        }

        private void itemNoLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string cs = ConfigurationManager.ConnectionStrings["Multiline_db"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_Item_NoLocation", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.ExecuteNonQuery();
            }
            RptType = "ItemNoLocation";
            status = "MainMenu";
            OutputReport fmItemNoLocation = new OutputReport();
            fmItemNoLocation.ShowDialog();
            status = "";
            //this.Hide();
        }

        private void oToolStripMenuItem_Click(object sender, EventArgs e)
        {

            OnHoldList fmOnHoldList = new OnHoldList();
            fmOnHoldList.ShowDialog();
            //this.Hide();
        }

        private void cOMMCALCULATIONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommissionCalculation fmCommissionCalculation = new CommissionCalculation();
            fmCommissionCalculation.ShowDialog();
            //this.Hide();
        }

        private void pROMOCALCULATIONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Promo fmPromo = new Promo();
            fmPromo.ShowDialog();
            //this.Hide();
        }

        private void salesBookingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SalesBooking fmSalesBooking = new SalesBooking();
            fmSalesBooking.ShowDialog();
            //this.Hide();
        }

        private void sortByItemIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["Multiline_db"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_ItemNegQty", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.ExecuteNonQuery();
            }
            RptType = "ItemNegQty";
            status = "MainMenu";
            OutputReport fmItemNegQty = new OutputReport();
            fmItemNegQty.ShowDialog();
            status = "";
            //this.Hide();

        }

        private void sortByLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string cs = ConfigurationManager.ConnectionStrings["Multiline_db"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_ItemNegQtyByLoc", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.ExecuteNonQuery();
            }
            RptType = "ItemNegQty";
            status = "MainMenu";
            OutputReport fmItemNegQty = new OutputReport();
            fmItemNegQty.ShowDialog();
            status = "";
            //this.Hide();??????????????????


        }
        private void MainMenu_Load(object sender, EventArgs e)
        {
            if (Login.pos == "3")
            {
                eMPLOYEEToolStripMenuItem.Enabled = false;
                salesToolStripMenuItem.Enabled = false;
                eFTToolStripMenuItem.Enabled = false;
                cOMMISSIONToolStripMenuItem.Enabled = false;
                aCCTRECEIVABLEToolStripMenuItem.Enabled = false;
                eMAILStripMenuItem.Enabled = false;
                dATAUPDATEToolStripMenuItem.Enabled = false;
            }
            else if (Login.pos == "2")
            {
                eMPLOYEEToolStripMenuItem.Enabled = false;
                //salesToolStripMenuItem.Enabled = false;
                eFTToolStripMenuItem.Enabled = false;
                cOMMISSIONToolStripMenuItem.Enabled = false;
                //aCCTRECEIVABLEToolStripMenuItem.Enabled = false;
                eMAILStripMenuItem.Enabled = false;
                dATAUPDATEToolStripMenuItem.Enabled = false;
            }
        }

        public static string opt = "";

        public static string rts = "";

        private void addEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rts = "add";
            AddEmp ae = new AddEmp();
            ae.ShowDialog();
        }

        private void deleteEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            opt = "del";
            DelEmp de = new DelEmp();
            de.ShowDialog();
        }

        private void editEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            opt = "upt";
            rts = "upt";
            EditEmp ee = new EditEmp();
            ee.ShowDialog();
        }

        private void editRightsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rts = "edt";
            RightsEdit re = new RightsEdit();
            re.ShowDialog();
        }

        private void punchClockReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportPreview rp = new ReportPreview();
            rp.ShowDialog();
        }

        private void updateClockTimeAndStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateTimeStatus uts = new UpdateTimeStatus();
            uts.ShowDialog();
        }

        private void VenderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Masemail me = new Masemail();
            objects = "vendor";
            me.ShowDialog();
            objects = "";
        }

        private void forCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Masemail me = new Masemail();
            objects = "customer";
            me.ShowDialog();
            objects = "";
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chooseprter cp = new chooseprter();
            soq = "single";
            cp.ShowDialog();
            soq = "";
        }

        private void ptestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chooseprter cp = new chooseprter();
            soq = "OorQ";
            cp.ShowDialog();
            soq = "";
        }

        private void typedListLabelPrintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chooseprter cp = new chooseprter();
            soq = "tlp";
            cp.ShowDialog();
            soq = "";
        }

        private void dATAUPDATEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            productupt pu = new productupt();
            pu.ShowDialog();
        }

        private void searchCompanyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchComp sc = new SearchComp();
            sc.ShowDialog();
        }
    }
}
