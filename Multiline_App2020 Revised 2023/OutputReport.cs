using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace Multiline_App2020_Revised_2023
{
    public partial class OutputReport : Form
    {
        public string RptType = "";
        public string RptType_R = "";
        public string RptType1_R = "";
        public string RptType2_R = "";
        public string RptType3_R = "";
        public string RptType4_R = "";
        public string RptType5_R = "";
        public string RptType6_R = "";

        public OutputReport()
        {
            InitializeComponent();
        }

        private void OutputReport_Load(object sender, EventArgs e)
        {
            if (MainMenu.status != "")
            {
                RptType = MainMenu.RptType;
            }

            if (OnHoldList.status != "")
            {
                RptType = OnHoldList.RptType1;
            }

            if (SalesHistory.status != "")
            {
                RptType = SalesHistory.RptType2;
            }

            if (SalesBilling.status != "")
            {
                RptType = SalesBilling.RptType3;
            }

            if (CommissionCalculation.status != "")
            {
                RptType = CommissionCalculation.RptType4;
            }

            if (Promo.status != "")
            {
                RptType = Promo.RptType5;
            }

            if (SalesBooking.status != "")
            {
                RptType = SalesBooking.RptType6;
            }

            /*RptType_R = MainMenu.RptType;
            RptType1_R = OnHoldList.RptType1;
            RptType2_R = SalesHistory.RptType2;
            RptType3_R = SalesBilling.RptType3;
            RptType4_R = CommissionCalculation.RptType4;
            RptType5_R = Promo.RptType5;
            RptType6_R = SalesBooking.RptType6;
            */

            if (RptType == "PendingInvoices")
            {
                //Create Crystal Report 
                ReportDocument crystalReport = new ReportDocument();
                crystalReport.Load(@"E:\Data\Multiline_App2020\Multiline_App2020\ReportGenerator\CrystalReports\crp_PendingInvoices.rpt");
                crystalReport.SetDatabaseLogon("BrendaChu", "198HBTrail#", @"MLAPPSVR\STREAMLINE", "multiline_db");
                crpvOutputReport.ReportSource = crystalReport;
                crpvOutputReport.Refresh();
            }

            if (RptType == "OpenOrderAll")
            {
                //Create Crystal Report 
                ReportDocument crystalReport = new ReportDocument();
                crystalReport.Load(@"E:\Data\Multiline_App2020\Multiline_App2020\ReportGenerator\CrystalReports\crp_OpenOrderAll.rpt");
                crystalReport.SetDatabaseLogon("BrendaChu", "198HBTrail#", @"MLAPPSVR\STREAMLINE", "multiline_db");
                crpvOutputReport.ReportSource = crystalReport;
                crpvOutputReport.Refresh();

            }



            if (RptType == "ItemNegQty")
            {
                //Create Crystal Report 
                ReportDocument crystalReport = new ReportDocument();
                crystalReport.Load(@"E:\Data\Multiline_App2020\Multiline_App2020\ReportGenerator\CrystalReports\crp_ItemNegQty.rpt");
                crystalReport.SetDatabaseLogon("BrendaChu", "198HBTrail#", @"MLAPPSVR\STREAMLINE", "multiline_db");
                crpvOutputReport.ReportSource = crystalReport;
                crpvOutputReport.Refresh();

            }

            if (RptType == "ItemNoLocation")

            {
                //Create Crystal Report 
                ReportDocument crystalReport = new ReportDocument();
                crystalReport.Load(@"E:\Data\Multiline_App2020\Multiline_App2020\ReportGenerator\CrystalReports\crp_ItemNoLocation.rpt");
                crystalReport.SetDatabaseLogon("BrendaChu", "198HBTrail#", @"MLAPPSVR\STREAMLINE", "multiline_db");
                crpvOutputReport.ReportSource = crystalReport;
                crpvOutputReport.Refresh();

            }


            if (RptType == "OnHoldAll")
            {
                //Create Crystal Report 
                ReportDocument crystalReport = new ReportDocument();
                crystalReport.Load(@"E:\Data\Multiline_App2020\Multiline_App2020\ReportGenerator\CrystalReports\crp_AROnHold.rpt");
                crystalReport.SetDatabaseLogon("BrendaChu", "198HBTrail#", @"MLAPPSVR\STREAMLINE", "multiline_db");
                crpvOutputReport.ReportSource = crystalReport;
                crpvOutputReport.Refresh();

            }


            if (RptType == "OnHoldAll_BySales")
            {
                //Create Crystal Report 
                ReportDocument crystalReport = new ReportDocument();
                crystalReport.Load(@"E:\Data\Multiline_App2020\Multiline_App2020\ReportGenerator\CrystalReports\crp_AROnHold_BySales.rpt");
                crystalReport.SetDatabaseLogon("BrendaChu", "198HBTrail#", @"MLAPPSVR\STREAMLINE", "multiline_db");
                crpvOutputReport.ReportSource = crystalReport;
                crpvOutputReport.Refresh();

            }



            if (RptType == "AllCustAllItemSum")
            {
                //Create Crystal Report 
                ReportDocument crystalReport = new ReportDocument();
                crystalReport.Load(@"E:\Data\Multiline_App2020\Multiline_App2020\ReportGenerator\CrystalReports\crp_SalesHistoryAllCustAllItemSum.rpt");

                crystalReport.SetParameterValue("from", SalesHistory.from);
                crystalReport.SetParameterValue("to", SalesHistory.to);
                crystalReport.SetDatabaseLogon("BrendaChu", "198HBTrail#", @"MLAPPSVR\STREAMLINE", "multiline_db");
                crpvOutputReport.ReportSource = crystalReport;
                crpvOutputReport.Refresh();

            }

            if (RptType == "AllCustAllItemDetail")
            {
                //Create Crystal Report 
                ReportDocument crystalReport = new ReportDocument();
                crystalReport.Load(@"E:\Data\Multiline_App2020\Multiline_App2020\ReportGenerator\CrystalReports\crp_SalesHistoryAllCustAllItemDetail.rpt");

                crystalReport.SetParameterValue("from", SalesHistory.from);
                crystalReport.SetParameterValue("to", SalesHistory.to);
                crystalReport.SetDatabaseLogon("BrendaChu", "198HBTrail#", @"MLAPPSVR\STREAMLINE", "multiline_db");
                crpvOutputReport.ReportSource = crystalReport;
                crpvOutputReport.Refresh();

            }


            if (RptType == "AllCustPerItemSum")
            {
                //Create Crystal Report 
                ReportDocument crystalReport = new ReportDocument();
                crystalReport.Load(@"E:\Data\Multiline_App2020\Multiline_App2020\ReportGenerator\CrystalReports\crp_SalesHistoryAllCustPerItemSum.rpt");

                crystalReport.SetParameterValue("from", SalesHistory.from);
                crystalReport.SetParameterValue("to", SalesHistory.to);
                crystalReport.SetParameterValue("item", SalesHistory.item);
                crystalReport.SetDatabaseLogon("BrendaChu", "198HBTrail#", @"MLAPPSVR\STREAMLINE", "multiline_db");
                crpvOutputReport.ReportSource = crystalReport;
                crpvOutputReport.Refresh();

            }


            if (RptType == "AllCustPerItemDetail")
            {
                //Create Crystal Report 
                ReportDocument crystalReport = new ReportDocument();
                crystalReport.Load(@"E:\Data\Multiline_App2020\Multiline_App2020\ReportGenerator\CrystalReports\crp_SalesHistoryAllCustPerItemDetail.rpt");

                crystalReport.SetParameterValue("from", SalesHistory.from);
                crystalReport.SetParameterValue("to", SalesHistory.to);
                crystalReport.SetParameterValue("item", SalesHistory.item);
                crystalReport.SetDatabaseLogon("BrendaChu", "198HBTrail#", @"MLAPPSVR\STREAMLINE", "multiline_db");
                crpvOutputReport.ReportSource = crystalReport;
                crpvOutputReport.Refresh();

            }


            if (RptType == "PerCustAllItemSum")
            {
                //Create Crystal Report 
                ReportDocument crystalReport = new ReportDocument();
                crystalReport.Load(@"E:\Data\Multiline_App2020\Multiline_App2020\ReportGenerator\CrystalReports\crp_SalesHistoryPerCustAllItemSum.rpt");

                crystalReport.SetParameterValue("from", SalesHistory.from);
                crystalReport.SetParameterValue("to", SalesHistory.to);
                crystalReport.SetParameterValue("custid", SalesHistory.custid);
                crystalReport.SetDatabaseLogon("BrendaChu", "198HBTrail#", @"MLAPPSVR\STREAMLINE", "multiline_db");
                crpvOutputReport.ReportSource = crystalReport;
                crpvOutputReport.Refresh();




            }


            if (RptType == "PerCustAllItemDetail")
            {
                //Create Crystal Report 
                ReportDocument crystalReport = new ReportDocument();
                crystalReport.Load(@"E:\Data\Multiline_App2020\Multiline_App2020\ReportGenerator\CrystalReports\crp_SalesHistoryPerCustAllItemDetail.rpt");

                crystalReport.SetParameterValue("from", SalesHistory.from);
                crystalReport.SetParameterValue("to", SalesHistory.to);
                crystalReport.SetParameterValue("custid", SalesHistory.custid);
                crystalReport.SetDatabaseLogon("BrendaChu", "198HBTrail#", @"MLAPPSVR\STREAMLINE", "multiline_db");
                crpvOutputReport.ReportSource = crystalReport;
                crpvOutputReport.Refresh();

            }


            if (RptType == "PerCustPerItemSum")
            {
                //Create Crystal Report 
                ReportDocument crystalReport = new ReportDocument();
                crystalReport.Load(@"E:\Data\Multiline_App2020\Multiline_App2020\ReportGenerator\CrystalReports\crp_SalesHistoryPerCustPerItemSum.rpt");

                crystalReport.SetParameterValue("from", SalesHistory.from);
                crystalReport.SetParameterValue("to", SalesHistory.to);
                crystalReport.SetParameterValue("custid", SalesHistory.custid);
                crystalReport.SetParameterValue("itemid", SalesHistory.item);

                crystalReport.SetDatabaseLogon("BrendaChu", "198HBTrail#", @"MLAPPSVR\STREAMLINE", "multiline_db");
                crpvOutputReport.ReportSource = crystalReport;
                crpvOutputReport.Refresh();

            }
            if (RptType == "PerCustPerItemDetail")
            {
                //Create Crystal Report 
                ReportDocument crystalReport = new ReportDocument();
                crystalReport.Load(@"E:\Data\Multiline_App2020\Multiline_App2020\ReportGenerator\CrystalReports\crp_SalesHistoryPerCustPerItemDetail.rpt");

                crystalReport.SetParameterValue("from", SalesHistory.from);
                crystalReport.SetParameterValue("to", SalesHistory.to);
                crystalReport.SetParameterValue("custid", SalesHistory.custid);
                crystalReport.SetParameterValue("itemid", SalesHistory.item);

                crystalReport.SetDatabaseLogon("BrendaChu", "198HBTrail#", @"MLAPPSVR\STREAMLINE", "multiline_db");
                crpvOutputReport.ReportSource = crystalReport;
                crpvOutputReport.Refresh();

            }

            if (RptType == "AllSalesAllCust")
            {
                //Create Crystal Report 
                ReportDocument crystalReport = new ReportDocument();
                crystalReport.Load(@"E:\Data\Multiline_App2020\Multiline_App2020\ReportGenerator\CrystalReports\crp_BillingAllSalesAllCust.rpt");

                crystalReport.SetParameterValue("from", SalesBilling.from);
                crystalReport.SetParameterValue("to", SalesBilling.to);


                crystalReport.SetDatabaseLogon("BrendaChu", "198HBTrail#", @"MLAPPSVR\STREAMLINE", "multiline_db");
                crpvOutputReport.ReportSource = crystalReport;
                crpvOutputReport.Refresh();

            }

            if (RptType == "AllSalesPerCust")
            {
                //Create Crystal Report 
                ReportDocument crystalReport = new ReportDocument();
                crystalReport.Load(@"E:\Data\Multiline_App2020\Multiline_App2020\ReportGenerator\CrystalReports\crp_BillingAllSalesPerCust.rpt");

                crystalReport.SetParameterValue("from", SalesBilling.from);
                crystalReport.SetParameterValue("to", SalesBilling.to);
                crystalReport.SetParameterValue("custid", SalesBilling.custid);

                crystalReport.SetDatabaseLogon("BrendaChu", "198HBTrail#", @"MLAPPSVR\STREAMLINE", "multiline_db");
                crpvOutputReport.ReportSource = crystalReport;
                crpvOutputReport.Refresh();

            }

            if (RptType == "PerSalesAllCust")
            {
                //Create Crystal Report 
                ReportDocument crystalReport = new ReportDocument();
                crystalReport.Load(@"E:\Data\Multiline_App2020\Multiline_App2020\ReportGenerator\CrystalReports\crp_BillingPerSalesAllCust.rpt");

                crystalReport.SetParameterValue("from", SalesBilling.from);
                crystalReport.SetParameterValue("to", SalesBilling.to);
                crystalReport.SetParameterValue("salesid", SalesBilling.salesid);

                crystalReport.SetDatabaseLogon("BrendaChu", "198HBTrail#", @"MLAPPSVR\STREAMLINE", "multiline_db");
                crpvOutputReport.ReportSource = crystalReport;
                crpvOutputReport.Refresh();

            }

            if (RptType == "PerSalesPerCust")
            {
                //Create Crystal Report 
                ReportDocument crystalReport = new ReportDocument();
                crystalReport.Load(@"E:\Data\Multiline_App2020\Multiline_App2020\ReportGenerator\CrystalReports\crp_BillingPerSalesPerCust.rpt");

                crystalReport.SetParameterValue("from", SalesBilling.from);
                crystalReport.SetParameterValue("to", SalesBilling.to);
                crystalReport.SetParameterValue("salesid", SalesBilling.salesid);
                crystalReport.SetParameterValue("custid", SalesBilling.custid);

                crystalReport.SetDatabaseLogon("BrendaChu", "198HBTrail#", @"MLAPPSVR\STREAMLINE", "multiline_db");
                crpvOutputReport.ReportSource = crystalReport;
                crpvOutputReport.Refresh();

            }

            if (RptType == "CommissionCalculation")
            {
                //Create Crystal Report 
                ReportDocument crystalReport = new ReportDocument();
                crystalReport.Load(@"E:\Data\Multiline_App2020\Multiline_App2020\ReportGenerator\CrystalReports\crp_CommissionCalculation.rpt");

                crystalReport.SetParameterValue("from", CommissionCalculation.from);
                crystalReport.SetParameterValue("to", CommissionCalculation.to);
                crystalReport.SetParameterValue("sales", CommissionCalculation.salesid);


                crystalReport.SetDatabaseLogon("BrendaChu", "198HBTrail#", @"MLAPPSVR\STREAMLINE", "multiline_db");
                crpvOutputReport.ReportSource = crystalReport;
                crpvOutputReport.Refresh();

            }

            if (RptType == "Promo")
            {
                //Create Crystal Report 
                ReportDocument crystalReport = new ReportDocument();
                crystalReport.Load(@"E:\Data\Multiline_App2020\Multiline_App2020\ReportGenerator\CrystalReports\crp_Promo.rpt");

                crystalReport.SetParameterValue("from", Promo.from);
                crystalReport.SetParameterValue("to", Promo.to);
                crystalReport.SetParameterValue("sales", Promo.salesid);


                crystalReport.SetDatabaseLogon("BrendaChu", "198HBTrail#", @"MLAPPSVR\STREAMLINE", "multiline_db");
                crpvOutputReport.ReportSource = crystalReport;
                crpvOutputReport.Refresh();

            }

            if (RptType == "BookingAllSalesAllCust")
            {
                //Create Crystal Report 
                ReportDocument crystalReport = new ReportDocument();
                crystalReport.Load(@"E:\Data\Multiline_App2020\Multiline_App2020\ReportGenerator\CrystalReports\crp_BookingAllSalesAllCust.rpt");

                crystalReport.SetDatabaseLogon("BrendaChu", "198HBTrail#", @"MLAPPSVR\STREAMLINE", "multiline_db");
                crpvOutputReport.ReportSource = crystalReport;
                crpvOutputReport.Refresh();

            }

            if (RptType == "BookingPerSalesAllCust")
            {
                //Create Crystal Report 
                ReportDocument crystalReport = new ReportDocument();
                crystalReport.Load(@"E:\Data\Multiline_App2020\Multiline_App2020\ReportGenerator\CrystalReports\cry_BookingPerSalesAllCust.rpt");

                crystalReport.SetParameterValue("sales", SalesBooking.salesid);

                crystalReport.SetDatabaseLogon("BrendaChu", "198HBTrail#", @"MLAPPSVR\STREAMLINE", "multiline_db");
                crpvOutputReport.ReportSource = crystalReport;
                crpvOutputReport.Refresh();

            }

            if (RptType == "BookingAllSalesPerCust")
            {
                //Create Crystal Report 
                ReportDocument crystalReport = new ReportDocument();
                crystalReport.Load(@"E:\Data\Multiline_App2020\Multiline_App2020\ReportGenerator\CrystalReports\cry_BookingAllSalesPerCust.rpt");

                crystalReport.SetParameterValue("custid", SalesBooking.custid);

                crystalReport.SetDatabaseLogon("BrendaChu", "198HBTrail#", @"MLAPPSVR\STREAMLINE", "multiline_db");
                crpvOutputReport.ReportSource = crystalReport;
                crpvOutputReport.Refresh();

            }


        }








    }
}