using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;
//using Outlook = Microsoft.Office.Interop.Outlook;
using System.Data.SqlClient;
using System.Configuration;



namespace Multiline_App2020_Revised_2023
{
    public partial class SendEMail_11125 : Form
    {
        public SendEMail_11125()
        {
            InitializeComponent();
        }

        public Boolean create_checkemail_checkdetail_flg;

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSendMail_Click(object sender, EventArgs e)
        {

            //try
            //{
            //    Outlook.Application app = new Outlook.Application();
            //    Outlook.MailItem mail = (Outlook.MailItem)app.CreateItem(Outlook.OlItemType.olMailItem);
            //    mail.To = "b_z_chu@yahoo.com";
            //    mail.Subject = "Testing sending by Outlook";
            //    mail.Body = "This is a new test on Wed morning";
            //    mail.Importance = Outlook.OlImportance.olImportanceNormal;
            //    ((Outlook.MailItem)mail).Send();
            //    MessageBox.Show("e-mail sent successfully");
            //}

            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //}

            //    Email();

            //}
            //        public static void Email(string htmlString)
            //{
            //    try
            //    {
            //        MailMessage message = new MailMessage();
            //        SmtpClient smtp = new SmtpClient();
            //        message.From = new MailAddress("brendachu@multilinefasteners.com");
            //        message.To.Add(new MailAddress("b_z_chu@yahoo.com"));
            //        message.Subject = "Test";
            //        message.IsBodyHtml = true; //to make message body as html 
            //        string htmlString=@"<html>
            //        <body>
            //                <p>HelloWorld</p>
            //        </body>
            //        </html>";
            //        message.Body =htmlString;
            //        smtp.Port = 25;
            //        smtp.Host ="192.168.1.1";

            //        smtp.EnableSsl = false;
            //        smtp.UseDefaultCredentials = true;



            //                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            //        smtp.Send(message);
            //    }
            //    catch (Exception) { }
            //}


        }

        private void btnSendMail_Click_1(object sender, EventArgs e)
        {

            //Data Connection

            //string cs = ConfigurationManager.ConnectionStrings["Multiline_db"].ConnectionString;

            //using (SqlConnection conn = new SqlConnection(cs))
            //{
            //    conn.Open();
            //    SqlCommand cmd = new SqlCommand("SELECT * FROM checkmail where emailstate='OPEN' and emailcheck='1'", conn);
            //    cmd.ExecuteNonQuery();

            //    using (SqlDataReader rdr = cmd.ExecuteReader())
            //    {
            //        if (rdr.Read())

            //        {

            //            try
            //            {

            //                //Setup and send E-mail

            //                //    Outlook.Application app = new Outlook.Application();
            //                //    Outlook.MailItem mail = (Outlook.MailItem)app.CreateItem(Outlook.OlItemType.olMailItem);

            //                //    while (rdr != null)
            //                //    {
            //                //        string checkNo = rdr["CHECK_NO"].ToString();
            //                //        string eMail = rdr["SUPPLIER_EMAIL"].ToString();
            //                //        float checkAmt = (float)Math.Round(float.Parse(rdr["CHECK_AMT"].ToString()), 2);


            //                //        //e-mail info
            //                //        mail.To = eMail;
            //                //        mail.Subject = "Direct Deposit Notification";
            //                //        mail.BodyFormat = Outlook.OlBodyFormat.olFormatHTML;


            //                //        string bodyText = null;
            //                //        string bodyTextHeader = null;
            //                //        bodyTextHeader = @"   
            //                //            <html>
            //                //                <body>
            //                //                    <p> Payee Name: Multil-Line Fastener Supply Co. Ltd.</p>
            //                //                    <br>
            //                //                    <p> Payee Account Num: & {rdr[PAYEE_ACCOUNT].ToString()} </p>
            //                //                    <br>
            //                //                    <p> Supplier: {rdr[SUPPLIER_NAME].ToString()} </p>
            //                //                    <br>
            //                //                    <p> Supplier ID: {rdr[SUPPLIER_ID].ToStriing()}</p>
            //                //                    <br>
            //                //                    <p> Deposit Date: {rdr[CHECK_DATE].ToString()}</p>
            //                //                    <br>
            //                //                    <p> Reference No: {rdr[CHECK_NO].ToString()}</p>
            //                //                    <br>
            //                //                    <table width='600' border='1' style='margin-top:40px'>
            //                //                     <tr>
            //                //                        <td>
            //                //                           <b>Invoice No<b>
            //                //                        </td>
            //                //                        <td>
            //                //                            <b> Invoice Date</b>
            //                //                        </td>
            //                //                        <td>
            //                //                            <b> Invoice Amount</b>
            //                //                        </td>
            //                //                     </tr>  
            //                //                   </body>  
            //                //                </html> ";


            //                //        SqlCommand cmd1 = new SqlCommand("Select * from checkdetail where CHECK_NO=checkNo", conn);
            //                //        cmd1.ExecuteNonQuery();
            //                //        using (SqlDataReader rdr1 = cmd.ExecuteReader())
            //                //        {
            //                //            while (rdr1 != null)
            //                //            {

            //                //                string BodyTextDetail = null;
            //                //                BodyTextDetail = @"
            //                //                    <html>
            //                //                        <body>
            //                //                    <tr>
            //                //                        <td>
            //                //                           {rdr1.[INV_NO].ToString()};
            //                //                        </td>
            //                //                        <td>
            //                //                            {rdr1.[INV_DATE].ToString()};
            //                //                        </td>
            //                //                         <td>
            //                //                            {rdr1[INV_AMT_DISCOUNT]};
            //                //                        </td>
            //                //                        <td>
            //                //                            {(-1)*rdr1.[INV_AMT]+(-1)*rdr1[INV_AMT_DISCOUNT]};
            //                //                        </td>
            //                //                        <td>
            //                //                            {(-1)*rdr1.[INV_AMT]}
            //                //                        </td>
            //                //                    </tr>
            //                //                    rdr1.MoveNext();
            //                //                    Loop();
            //                //                bodyText=BodyTextHeader+bodyTextDetail &<tr><td colspan='4' align='right'>
            //                //                <p>Total:</p></td>
            //                //                <td>
            //                //                    {checkAmt};
            //                //                </td>
            //                //                </tr>
            //                //                </table>
            //                //               </ body >
            //                //            </ html >
            //                //            ";




            //                //                mail.HTMLBody = bodyText;
            //                //            }
            //                //        }

            //                //        mail.Importance = Outlook.OlImportance.olImportanceNormal;
            //                //        ((Outlook.MailItem)mail).Send();
            //                //        MessageBox.Show("e-mail sent successfully");
            //                //    }
            //                //}


            //                //catch (Exception ex)
            //                //{
            //                //    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //                //}


            //            }





            //            }
            //    }




            //}


            string erem = "";

            if (create_checkemail_checkdetail_flg == false)
            {
                MessageBox.Show("Please create table checkmail and checkdetail first!");
                btnGetMail.Focus();
                return;
            }
            else
            {
                string ConnectionString = "Server=192.168.1.190,1435;User ID=Office; Password=BCpr001!;Initial Catalog=multiline_db";

                SqlConnection con = new SqlConnection(ConnectionString);

                con.Open();

                string query1 = "Select * from checkemail  where emailstate='OPEN' and emailcheck=1";

                SqlCommand cmd1 = new SqlCommand(query1, con);
                cmd1.CommandType = CommandType.Text;
                cmd1.ExecuteNonQuery();
                SqlDataReader rdr = cmd1.ExecuteReader();

                while (rdr.Read())
                {
                    string checkno;
                    string email;
                    string checkamt;
                    checkno = rdr["check_no"].ToString();
                    try
                    {
                        if (rdr["supplier_email"].ToString().Contains(";"))
                        {
                            string[] emails = rdr["supplier_email"].ToString().Split(';');
                            for (int i = 0; i < emails.Length; i++)
                            {
                                checkamt = Math.Round(float.Parse(rdr["check_amt"].ToString()), 2).ToString();
                                erem = emails[i];
                                MailMessage mail1 = new MailMessage();
                                SmtpClient smtp1 = new SmtpClient("smtp.bellnet.ca");
                                mail1.From = new MailAddress("eft@multilinefasteners.com");
                                mail1.To.Add(emails[i]);
                                mail1.Bcc.Add("eft.r@multilinefasteners.com");
                                mail1.Subject = "Direct Deposit Notification";
                                mail1.IsBodyHtml = true;

                                string bodytxt1 = "<html><body>Payee Name : Multi-Line Fastener Supply Co. Ltd." +
                                                 "<br>Payee Account Num : " + rdr["payee_account"] +
                                                 "<br>Supplier : " + rdr["supplier_name"] +
                                                 "<br>Supplier ID : " + rdr["supplier_id"] +
                                                 "<br>Deposit Date : " + DateTime.Parse(rdr["check_date"].ToString()).ToString("yyyy-MM-dd") +
                                                 "<br>Reference NO : " + checkno +
                                                 "<br><table width='600' border='1' style='margin-top:40px'><tr><td><b>Invoice No</b></td><td><b>Invoice Date</b></td><td><b>Invoice Amount</b></td><td><b>Discount Amount</b></td><td><b>Amount</b></td></tr>";
                                string query0 = "select * from checkdetail where check_no=('" + checkno + "')";



                                string csn = ConfigurationManager.ConnectionStrings["Multiline_db"].ConnectionString;

                                using (SqlConnection conn12 = new SqlConnection(csn))
                                {
                                    conn12.Open();
                                    SqlCommand cmd0 = new SqlCommand(query0, conn12);
                                    cmd0.CommandType = CommandType.Text;
                                    cmd0.ExecuteNonQuery();
                                    //SqlDataReader rdr2 = cmd2.ExecuteReader();

                                    using (SqlDataReader rdr0 = cmd0.ExecuteReader())
                                    {
                                        while (rdr0.Read())
                                        {
                                            bodytxt1 = bodytxt1 + "<tr><td>" + rdr0["INV_NO"] + "</td><td>" + DateTime.Parse(rdr0["INV_DATE"].ToString()).ToString("yyyy-MM-dd") + "</td><td>" + ((-1) * float.Parse(rdr0["INV_AMT"].ToString()) + (-1) * float.Parse(rdr0["INV_AMT_DISCOUNT"].ToString())) + "</td><td>" + ((-1) * float.Parse(rdr0["INV_AMT_DISCOUNT"].ToString())) + "</td><td>" + ((-1) * float.Parse(rdr0["INV_AMT"].ToString())) + "</td></tr>";
                                        }
                                    }
                                    conn12.Close();
                                }

                                bodytxt1 = bodytxt1 + "<tr><td colspan='4' align='right'><b>Total :</b></td><td>" + checkamt + "</td></tr></table></body></html>";

                                mail1.Body = bodytxt1;
                                smtp1.Port = 25;
                                smtp1.EnableSsl = false;

                                smtp1.Send(mail1);
                            }
                            string cs2 = ConfigurationManager.ConnectionStrings["Multiline_db"].ConnectionString;

                            using (SqlConnection conn1 = new SqlConnection(cs2))
                            {
                                conn1.Open();
                                string queryx1 = "update checkmain set emailstate='SENT' where checkno=('" + checkno + "')";
                                string queryy1 = "update checkemail set emailstate='SENT' where check_no=('" + checkno + "')";
                                SqlCommand cmdx1 = new SqlCommand(queryx1, conn1);
                                cmdx1.ExecuteNonQuery();
                                SqlCommand cmdy1 = new SqlCommand(queryy1, conn1);
                                cmdy1.ExecuteNonQuery();
                                conn1.Close();
                            }
                        }
                        else 
                        {
                            email = rdr["supplier_email"].ToString();
                            checkamt = Math.Round(float.Parse(rdr["check_amt"].ToString()), 2).ToString();

                            MailMessage mail = new MailMessage();
                            SmtpClient smtp = new SmtpClient("smtp.bellnet.ca");
                            mail.From = new MailAddress("eft@multilinefasteners.com");
                            mail.To.Add(email);
                            mail.Bcc.Add("eft.r@multilinefasteners.com");
                            mail.Subject = "Direct Deposit Notification";
                            mail.IsBodyHtml = true;

                            string bodytxt = "<html><body>Payee Name : Multi-Line Fastener Supply Co. Ltd." +
                                             "<br>Payee Account Num : " + rdr["payee_account"] +
                                             "<br>Supplier : " + rdr["supplier_name"] +
                                             "<br>Supplier ID : " + rdr["supplier_id"] +
                                             "<br>Deposit Date : " + DateTime.Parse(rdr["check_date"].ToString()).ToString("yyyy-MM-dd") +
                                             "<br>Reference NO : " + checkno +
                                             "<br><table width='600' border='1' style='margin-top:40px'><tr><td><b>Invoice No</b></td><td><b>Invoice Date</b></td><td><b>Invoice Amount</b></td><td><b>Discount Amount</b></td><td><b>Amount</b></td></tr>";

                            string query2 = "select * from checkdetail where check_no=('" + checkno + "')";



                            string cs = ConfigurationManager.ConnectionStrings["Multiline_db"].ConnectionString;

                            using (SqlConnection conn = new SqlConnection(cs))
                            {
                                conn.Open();
                                SqlCommand cmd2 = new SqlCommand(query2, conn);
                                cmd2.CommandType = CommandType.Text;
                                cmd2.ExecuteNonQuery();
                                //SqlDataReader rdr2 = cmd2.ExecuteReader();

                                using (SqlDataReader rdr2 = cmd2.ExecuteReader())
                                {
                                    while (rdr2.Read())
                                    {
                                        bodytxt = bodytxt + "<tr><td>" + rdr2["INV_NO"] + "</td><td>" + DateTime.Parse(rdr2["INV_DATE"].ToString()).ToString("yyyy-MM-dd") + "</td><td>" + ((-1) * float.Parse(rdr2["INV_AMT"].ToString()) + (-1) * float.Parse(rdr2["INV_AMT_DISCOUNT"].ToString())) + "</td><td>" + ((-1) * float.Parse(rdr2["INV_AMT_DISCOUNT"].ToString())) + "</td><td>" + ((-1) * float.Parse(rdr2["INV_AMT"].ToString())) + "</td></tr>";
                                    }
                                }
                                conn.Close();
                            }

                            bodytxt = bodytxt + "<tr><td colspan='4' align='right'><b>Total :</b></td><td>" + checkamt + "</td></tr></table></body></html>";

                            mail.Body = bodytxt;
                            smtp.Port = 25;
                            smtp.EnableSsl = false;

                            smtp.Send(mail);

                            string cs1 = ConfigurationManager.ConnectionStrings["Multiline_db"].ConnectionString;

                            using (SqlConnection conn1 = new SqlConnection(cs1))
                            {
                                conn1.Open();
                                string queryx = "update checkmain set emailstate='SENT' where checkno=('" + checkno + "')";
                                string queryy = "update checkemail set emailstate='SENT' where check_no=('" + checkno + "')";
                                SqlCommand cmdx = new SqlCommand(queryx, conn1);
                                cmdx.ExecuteNonQuery();
                                SqlCommand cmdy = new SqlCommand(queryy, conn1);
                                cmdy.ExecuteNonQuery();
                                conn1.Close();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        string senderem;
                        if (rdr["supplier_email"].ToString().Contains(";"))
                        {
                            senderem = erem;
                        }
                        senderem = rdr["supplier_email"].ToString();
                        MessageBox.Show(ex.ToString());
                        MailMessage mail2 = new MailMessage();
                        SmtpClient smtp2 = new SmtpClient("smtp.bellnet.ca");

                        mail2.From = new MailAddress("eft@multilinefasteners.com");
                        mail2.To.Add("error@multilinefasteners.com");
                        mail2.Subject = "Email sent Fail";
                        mail2.Body = string.Format("This email does not exist: {0}", senderem) + "\n" + ex.ToString();

                        smtp2.Port = 25;
                        smtp2.EnableSsl = false;

                        smtp2.Send(mail2);
                    }
                    
                }
                MessageBox.Show("All Emails had sent!");
            }
        }


        private void btnGetMail_Click(object sender, EventArgs e)
        {
            string ConnectionString = "Server=192.168.1.190,1435;User ID=Office; Password=BCpr001!;Initial Catalog=multiline_db";

            SqlConnection con = new SqlConnection(ConnectionString);

            string query1 = "select max(checkmain.fileno) as maxoffileno from checkmain";

            string query2 = " IF OBJECT_ID ('dbo.checkemail_temp', 'U') IS NOT NULL DROP TABLE dbo.checkemail_temp";

            string query3 = "select ci.CHECK_NO,CI.VENDOR_ID AS SUPPLIER_ID,CI.EMAIL AS SUPPLIER_EMAIL,CI.COMPANY AS SUPPLIER_NAME,CI.PAYEE_ACCOUNT,CI.CHECK_AMT,ci.CHECK_DATE,cm.emailcheck, cm.emailstate,cm.fileno"
                          + " into checkemail_temp from dbo.checkinfo  as ci inner join dbo.checkmain as cm on ci.CHECK_NO=cm.CheckNo ";

            string query4 = " IF OBJECT_ID ('dbo.checkemail', 'U') IS NOT NULL DROP TABLE dbo.checkemail";

            con.Open();
            SqlCommand cmd1 = new SqlCommand(query1, con);
            string mxn = (string)cmd1.ExecuteScalar();

            SqlCommand cmd2 = new SqlCommand(query2, con);
            cmd2.ExecuteNonQuery();

            SqlCommand cmd3 = new SqlCommand(query3, con);
            cmd3.ExecuteNonQuery();

            SqlCommand cmd4 = new SqlCommand(query4, con);
            cmd4.ExecuteNonQuery();

            string query5 = "select * into checkemail from dbo.checkemail_temp where fileno = ('" + mxn + "')";

            SqlCommand cmd5 = new SqlCommand(query5, con);
            cmd5.ExecuteNonQuery();

            string query6 = " IF OBJECT_ID ('dbo.checkdetail_temp', 'U') IS NOT NULL DROP TABLE dbo.checkdetail_temp";

            string query7 = " IF OBJECT_ID ('dbo.checkdetail', 'U') IS NOT NULL DROP TABLE dbo.checkdetail";

            string query8 = "CREATE TABLE dbo.checkdetail_temp(CHECK_NO varchar(10) null, REF_NO varchar(14) null,INV_NO varchar(14)null,INV_AMT float null, PAYEE_ACCOUNT VARCHAR(250) NULL,COMPANY VARCHAR(40) NULL,EMAIL NVARCHAR(255) NULL,INV_AMT_DISCOUNT float null,VENDOR_ID VARCHAR(9) NULL )";

            string query9 = "insert into dbo.checkdetail_temp(CHECK_NO,REF_NO,INV_NO,INV_AMT,PAYEE_ACCOUNT,VENDOR_ID,COMPANY,EMAIL,INV_AMT_DISCOUNT )" +
                            " select  CI.CHECK_NO,ad.apid_ref_num,ad.apid_invoice_num ,ad.apid_total_amt,ci.PAYEE_ACCOUNT,ci.VENDOR_ID,ci.COMPANY,ci.EMAIL,ad.apid_discount_amt" +
                            " from [MLAPPSVR\\STREAMLINE].sisl_data01.dbo.ap_invoices_details  as ad" +
                            " inner join checkinfo as ci on ad.apid_ref_num= ci.check_no" + 
                            " where ad.apid_transtype_flg='p'";

            string query10 = " ALTER TABLE dbo.checkdetail_temp ALTER COLUMN inv_NO varchar(14) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL";

            string query11 = "ALTER TABLE dbo.checkdetail_temp ALTER COLUMN vendor_id varchar(9) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL";

            string query12 = "use multiline_db";

            string query13 = " select cd.CHECK_NO,cd.REF_NO,cd.INV_NO,ai.apih_invoice_date as INV_DATE,cd.INV_AMT,cd.payee_account,cd.VENDOR_ID,cd.COMPANY,cd.EMAIL,cd.INV_AMT_DISCOUNT" +
                             " into dbo.checkdetail from dbo.checkdetail_temp as cd" +
                             " inner join [MLAPPSVR\\STREAMLINE].sisl_data01.dbo.ap_invoices  as ai" +
                             " on cd.inv_NO= ai.apih_invoice_num and CD.VENDOR_ID=ai.apih_supplier_id";

            string query14 = " IF OBJECT_ID ('dbo.checkdetail_temp', 'U') IS NOT NULL DROP TABLE dbo.checkdetail_temp";

            SqlCommand cmd6 = new SqlCommand(query6, con);
            cmd6.ExecuteNonQuery();
            SqlCommand cmd7 = new SqlCommand(query7, con);
            cmd7.ExecuteNonQuery();
            SqlCommand cmd8 = new SqlCommand(query8, con);
            cmd8.ExecuteNonQuery();
            SqlCommand cmd9 = new SqlCommand(query9, con);
            cmd9.ExecuteNonQuery();
            SqlCommand cmd10 = new SqlCommand(query10, con);
            cmd10.ExecuteNonQuery();
            SqlCommand cmd11 = new SqlCommand(query11, con);
            cmd11.ExecuteNonQuery();
            SqlCommand cmd12 = new SqlCommand(query12, con);
            cmd12.ExecuteNonQuery();
            SqlCommand cmd13 = new SqlCommand(query13, con);
            cmd13.ExecuteNonQuery();
            SqlCommand cmd14 = new SqlCommand(query14, con);
            cmd14.ExecuteNonQuery();


            string total_checkamt;
            string total_invamt;

            string query15 = "select sum(check_amt) from checkemail";
            SqlCommand cmd15 = new SqlCommand(query15, con);
            string sm = cmd15.ExecuteScalar().ToString();
            total_checkamt = sm;

            string query16 = "select sum(inv_amt) from checkdetail";
            SqlCommand cmd16 = new SqlCommand(query16, con);
            double im = (double)cmd16.ExecuteScalar();
            total_invamt = (Math.Round((im * (-1)), 2)).ToString();

            string query17 = "select * from  checkemail where emailstate='OPEN'";
            SqlCommand cmd17 = new SqlCommand(query17, con);
            string tm = (string)cmd17.ExecuteScalar();

            string query18 = "SELECT COUNT(*) from checkemail";
            SqlCommand cmd18 = new SqlCommand(query18, con);
            int c = (int)cmd18.ExecuteScalar();
            string total_count = c.ToString();
            con.Close();

            if (tm != null)
            {
                MessageBox.Show(string.Format("Total Check Amt is {0}, Total Invoice Amt is {1}, Total check count is {2}", total_checkamt, total_invamt, total_count));
                create_checkemail_checkdetail_flg = true;
            }
            else
            {
                MessageBox.Show("Total Check Amt is 0, Total Invoice Amt is 0, Total check count is 0,These checks had sent!");
            }
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

