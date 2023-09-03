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
    public partial class OpenOrdersAll : Form
    {
        public OpenOrdersAll()
        {
            InitializeComponent();
        }

        private void FormOpenOrdersAll_Load(object sender, EventArgs e)
        {
            ReportDocument cryRpt = new ReportDocument();
            TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
            TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            Tables CrTables;

            cryRpt.Load(@"E:\Data\Multiline_App2020_Revised_2023\Multiline_App2020_Revised_2023\ReportGenerator\CrystalReports\crp_OpenOrderAll.rpt");

            crConnectionInfo.ServerName = "192.168.1.190";
            crConnectionInfo.DatabaseName = "multiline_db";
            crConnectionInfo.UserID = "BrendaChu";
            crConnectionInfo.Password = "198HBTrail#";

            CrTables = cryRpt.Database.Tables;
            foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
            {
                crtableLogoninfo = CrTable.LogOnInfo;
                crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                CrTable.ApplyLogOnInfo(crtableLogoninfo);
            }



            //ReportDocument cryRpt = new ReportDocument();
            //cryRpt.Load(@"E:\Data\Multiline_App2020_Revised_2023\Multiline_App2020_Revised_2023\ReportGenerator\CrystalReports\crp_OpenOrderAll.rpt");


            crp_OpenOrdersAll.ReportSource = cryRpt;
            crp_OpenOrdersAll.Refresh();

        }
    }
}
