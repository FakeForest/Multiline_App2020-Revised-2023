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
using System.IO;



namespace Multiline_App2020_Revised_2023
{
    public partial class Epayment_11125 : Form
    {   //declare variables
        DateTime today = DateTime.Today;
        string fileNo = "";
        bool checkInfo_flg = false;
        string orgid = "";
        string destcode = "";
        int recno;
        string transcount = "";
        int checktotal;
        decimal checkamount;

        SqlDataReader checkdr;


        public Epayment_11125()
        {
            InitializeComponent();
        }

        public string getJulianDate(DateTime date)
        {
            string twoDigitYear = date.ToString("yy");
            int julian = Convert.ToInt32(twoDigitYear) * 1000 + date.DayOfYear;
            string julianResult = "0" + julian.ToString();
            return julianResult;
        }



        private void NewLineHeader()
        {
            recno = recno + 1;
            transcount = transcount + "C";
            string recnoInString = recno.ToString().PadLeft(9, '0');
            transcount = transcount + recnoInString;
            transcount = transcount + orgid;
            transcount = transcount + fileNo;
            //MessageBox.Show(transcount);
        }



        private void PutCheck(string check)
        {
            DateTime n = DateTime.Now;
            //Data Connection 
            string cs = ConfigurationManager.ConnectionStrings["Multiline_db"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("select * from dbo.checkmain", conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn("CheckNo", typeof(string)));
                dt.Columns.Add(new DataColumn("fileno", typeof(string)));
                dt.Columns.Add(new DataColumn("createDate", typeof(DateTime)));
                dt.Columns.Add(new DataColumn("emailcheck", typeof(string)));
                dt.Columns.Add(new DataColumn("emailstate", typeof(string)));
                DataRow dr = dt.NewRow();
                dr["CheckNo"] = check;
                dr["fileno"] = fileNo;
                dr["createDate"] = today;
                dr["emailcheck"] = 1;
                dr["emailstate"] = "OPEN";
                dt.Rows.Add(dr);
                ds.Tables.Add(dt);
                SqlCommand cmd = new SqlCommand("insert into checkmain (CheckNo, fileno, createDate, emailcheck, emailstate) values ('" + check + "', '" + fileNo + "', '" + n + "', '1', 'OPEN')", conn);
                cmd.ExecuteNonQuery();
            }
            transcount = transcount + "460";//add transaction type code
            //checkamount = checkamount + Convert.ToDecimal(checkdr["CHECK_AMT"]);
            checkamount = Convert.ToDecimal(checkdr["CHECK_AMT"]);

            transcount = transcount + (checkamount * 100).ToString("F0").PadLeft(10, '0');
            transcount = transcount + getJulianDate(today);
            transcount = transcount + "0";
            
            string temp;
            temp = string.Format("{0,-3}", checkdr[("BANKCODE").ToString()]);
            transcount = transcount + temp.Substring(0, 3);

            //transcount = transcount + checkdr["BANKCODE"];

            temp = string.Format("{0,-5}", checkdr[("BRANCHCODE").ToString()]);
            transcount = transcount + temp.Substring(0, 5);

            //transcount = transcount + checkdr["BRANCHCODE"];

            temp = string.Format("{0,-12}", checkdr[("ACCOUNTCODE").ToString()]);
            transcount = transcount + temp.Substring(0, 12);



            //transcount = transcount + string.Format("{0,-12}", checkdr["ACCOUNTCODE"]);
            //transcount = transcount + checkdr["ACCOUNTCODE"].ToString().PadRight(12);

            transcount = transcount + string.Concat(Enumerable.Repeat("0", 25));
            transcount = transcount + string.Format("{0,-15}", "MULTI-LINE");
            //transcount = transcount + "MULTI-LINE".PadRight(15);
            temp = string.Format("{0,-30}", checkdr["COMPANY"].ToString());
            transcount = transcount + temp.Substring(0, 30);

            transcount = transcount + string.Format("{0,-30}", "Multi-Line Fastener Supply Co.");
            transcount = transcount + new string(' ', 10);
            transcount = transcount + string.Format("{0,-19}", checkdr["check_no"]);
            transcount = transcount + "000129502"; //Multi-Line's Bank Code and Branch Code
            transcount = transcount + string.Format("{0, -12}", "1050371");
            transcount = transcount + new string(' ', 39);
            transcount = transcount + string.Concat(Enumerable.Repeat("0", 11));




            //MessageBox.Show(check,checkamount.ToString());
            //MessageBox.Show(transcount);

        }

        private void Epayment_11125_Load(object sender, EventArgs e)
        {
            txtDate.Text = today.ToShortDateString();// fill in txtDate box with çurrent date
            //initiate value for declared public variables
            orgid = "MLFSCLCR20";
            destcode = "00120";

            checktotal = 0;
            checkamount = 0;


            //Find next file number from the database
            string cs = ConfigurationManager.ConnectionStrings["Multiline_db"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select max(checkmain.fileno) as FileNum from checkmain", conn);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    String fileRec;
                    while (dr.Read())
                    {
                        //if (dr["FileNum"] != DBNull.Value)
                        if (dr.HasRows)

                        {
                            fileRec = (int.Parse(dr.GetString(0)) + 1).ToString(); //fileRec = file no. in the system plus 1, is the next file no //.GetString(0))
                            fileRec = fileRec.PadLeft(4, '0');  // make it a 4 digit file no.

                        }
                        else
                        {

                            fileRec = "1";
                            fileRec = fileRec.PadLeft(4, '0');  // file number would be "0001".

                        }

                        fileNo = fileRec;
                        txtFileNum.Text = fileNo;//fill txtFileNum box with next file number

                    }


                }


            }
        }



        private void btnFile_Click(object sender, EventArgs e)
        {
            ////if (checkInfo_flg == false)
            ////{
            ////    MessageBox.Show("Please perform Step 1 create CheckInfor Table First");
            ////    btnCheckInfo.Focus();
            ////}

            ////else if (txtFileName.Text == "")
            ////{
            ////    MessageBox.Show("File Name cannnot be empty");
            ////}

            ////else
            ////{

            ////    //Generate transmission file header
            ////    recno = 1;
            ////    transcount = "A";
            ////    transcount = transcount + "000000001";//A000000001
            ////    transcount = transcount + orgid; //A000000001MLFSCLCR20
            ////    transcount = transcount + fileNo;//A000000001MLFSCLCR200244
            ////    transcount = transcount + getJulianDate(today); //A000000001MLFSCLCR200244020211
            ////    transcount = transcount + destcode; //A000000001MLFSCLCR20024402021100120,  total 35 charactors

            ////    string space = new string(' ', 1429);

            ////    transcount = transcount + space;// add 1429 space after the header
            ////    transcount = transcount + Environment.NewLine; //return carriage



            ////    //get detail checks data  from dbo.checkinfo for file body
            ////    string cs = ConfigurationManager.ConnectionStrings["Multiline_db"].ConnectionString;

            ////    using (SqlConnection conn = new SqlConnection(cs))
            ////    {
            ////        conn.Open();
            ////        SqlCommand cmd = new SqlCommand("select * from checkinfo", conn);
            ////        cmd.ExecuteNonQuery();
            ////        using (checkdr = cmd.ExecuteReader())
            ////        {
            ////            while (checkdr.Read())
            ////            {
            ////                checktotal = checktotal + 1;
            ////                int Modifier = checktotal % 6;//each line contains 6 records, when 6th records reached, change to newline
            ////                if (Modifier == 1)
            ////                {
            ////                    NewLineHeader();   //call NewLineRecord function


            ////                }

            ////                string checkno;
            ////                checkno = checkdr["CHECK_NO"].ToString();
            ////                PutCheck(checkno); //call PutCheck Method
            ////                string temp;
            ////                temp = string.Format("{0,-3}", checkdr[("BANKCODE").ToString()]);
            ////                transcount = transcount + temp.Substring(0, 3);

            ////                //transcount = transcount + checkdr["BANKCODE"];

            ////                temp = string.Format("{0,-5}", checkdr[("BRANCHCODE").ToString()]);
            ////                transcount = transcount + temp.Substring(0, 5);


            ////                //transcount = transcount + checkdr["BRANCHCODE"];

            ////                temp = string.Format("{0,-12}", checkdr[("ACCOUNTCODE").ToString()]);
            ////                transcount = transcount + temp.Substring(0, 12);



            ////                //transcount = transcount + string.Format("{0,-12}", checkdr["ACCOUNTCODE"]);
            ////                //transcount = transcount + checkdr["ACCOUNTCODE"].ToString().PadRight(12);

            ////                transcount = transcount + string.Concat(Enumerable.Repeat("0", 25));
            ////                transcount = transcount + string.Format("{0,-15}", "MULTI-LINE");
            ////                //transcount = transcount + "MULTI-LINE".PadRight(15);
            ////                temp = string.Format("{0,-30}", checkdr["COMPANY"].ToString());
            ////                transcount = transcount + temp.Substring(0, 30);

            ////                transcount = transcount + string.Format("{0,-30}", "Multi-Line Fastener Supply Co.");
            ////                transcount = transcount + new string(' ', 10);
            ////                transcount = transcount + string.Format("{0,-19}", checkdr["check_no"]);
            ////                transcount = transcount + "000129502"; //Multi-Line's Bank Code and Branch Code
            ////                transcount = transcount + string.Format("{0, -12}", "1050371");
            ////                transcount = transcount + new string(' ', 39);
            ////                transcount = transcount + string.Concat(Enumerable.Repeat("0", 11));

            ////                if (Modifier == 0)
            ////                {
            ////                    transcount = transcount + "\r";
            ////                }



            ////                //MessageBox.Show(transcount);
            ////            }


            ////        }
            ////    }

            ////    //Generate trailer record
            ////    //Data Connection and execute stored procedure sp_CheckInfo
            ////    //string cs = ConfigurationManager.ConnectionStrings["Multiline_db"].ConnectionString;

            ////    //using (SqlConnection conn = new SqlConnection(cs))
            ////    //{
            ////    //    conn.Open();
            ////    //    SqlCommand cmd1 = new SqlCommand("sp_CheckInfo", conn);
            ////    //    cmd1.CommandType = CommandType.StoredProcedure;
            ////    //    cmd1.ExecuteNonQuery();
            ////    //}

            ////    string total_checkamt;
            ////    string total_checknum;

            ////    using (SqlConnection conn = new SqlConnection(cs))

            ////    {
            ////        //get total check amount, and total number of checks.
            ////        conn.Open();
            ////        //SqlCommand cmd1 = new SqlCommand("Select sum(check_amt) from checkinfo", conn);
            ////        SqlCommand cmd1 = new SqlCommand("Select sum(check_amt), count(*) from checkinfo", conn);
            ////        cmd1.CommandType = CommandType.Text;
            ////        //cmd1.ExecuteNonQuery();
            ////        cmd1.ExecuteScalar();

            ////        using (SqlDataReader rdr = cmd1.ExecuteReader())

            ////        {
            ////            while (rdr.Read())
            ////            {
            ////                total_checkamt = rdr.GetValue(0).ToString();//total_checkamt equals to sum(check_amt)
            ////                                                            //        //total_checkamt = (float)rdr.GetValue(0);//total_checkamt equals to sum(check_amt)
            ////                total_checknum = rdr.GetValue(1).ToString();
            ////                //MessageBox.Show(total_checkamt.ToString());
            ////                //MessageBox.Show(total_checknum.ToString());

            ////                //}



            ////                transcount = transcount + "\n";
            ////                transcount = transcount + Environment.NewLine; //return carriage
            ////                recno = recno + 1;
            ////                transcount = transcount + "Z"; //Z
            ////                string recnoInString = recno.ToString().PadLeft(9, '0');
            ////                //transcount = transcount + string.Format("{0,-9}", recno);//Z000000015
            ////                transcount = transcount + recnoInString;
            ////                transcount = transcount + orgid;//Z000000015MLFSCLCR20
            ////                transcount = transcount + fileNo;//Z000000015MLFSCLCR200273
            ////                transcount = transcount + string.Concat(Enumerable.Repeat("0", 14));//Z000000015MLFSCLCR20027300000000000000
            ////                transcount = transcount + string.Concat(Enumerable.Repeat("0", 8));//Z000000015MLFSCLCR2002730000000000000000000000




            ////                transcount = transcount + (Double.Parse(total_checkamt) * 100).ToString("F0").PadLeft(14, '0');



            ////                transcount = transcount + (total_checknum.PadLeft(8, '0'));

            ////                transcount = transcount + new string(' ', 1396);


            ////                transcount = transcount + "\n";



            ////                //MessageBox.Show(transcount);
            ////                //MessageBox.Show(txtFileName.Text);

            ////                string fileName = @"e:\Data\epayment\" + txtFileName.Text + ".txt";
            ////                try
            ////                {
            ////                    //check if file already exit, if yes, delete it
            ////                    if (File.Exists(fileName))
            ////                    {
            ////                        File.Delete(fileName);
            ////                    }

            ////                    // Create a new file     
            ////                    using (StreamWriter sw = File.CreateText(fileName))
            ////                    {
            ////                        sw.WriteLine(transcount);

            ////                    }
            ////                }
            ////                catch (Exception Ex)
            ////                {
            ////                    Console.WriteLine(Ex.ToString());
            ////                }
            ////            }



            ////        }
            ////        MessageBox.Show("File Successful Created");
            ////        checkInfo_flg = false;






            ////    }



            ////}




            if (checkInfo_flg == false)
            {
                MessageBox.Show("Please perform Step 1 create CheckInfor Table First");
                btnCheckInfo.Focus();
            }

            else if (txtFileName.Text == "")
            {
                MessageBox.Show("File Name cannnot be empty");
            }

            else
            {

                //Generate transmission file header
                recno = 1;
                transcount = "A";
                //transcount = transcount + "000000001";//A000000001
                transcount = transcount + recno.ToString().PadLeft(9, '0');//A000000001
                orgid = "MLFSCLCR20";
                transcount = transcount + orgid; //A000000001MLFSCLCR20
                transcount = transcount + fileNo;//A000000001MLFSCLCR200244, fileNO defined from Form_Load ()
                transcount = transcount + getJulianDate(today); //A000000001MLFSCLCR200244020211
                destcode = "00120";
                transcount = transcount + destcode; //A000000001MLFSCLCR20024402021100120,  total 35 charactors

                string space = new string(' ', 1429);

                transcount = transcount + space;// add 1429 space after the header
                transcount = transcount + "\r"; //return carriage



                //get detail checks data  from dbo.checkinfo for file body
                string cs = ConfigurationManager.ConnectionStrings["Multiline_db"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("select * from checkinfo", conn);
                    cmd.ExecuteNonQuery();
                    using (checkdr = cmd.ExecuteReader())
                    {
                        while (checkdr.Read())
                        {
                            checktotal = checktotal + 1;  //checktotal previously declared in form_load as 0
                            //int Modifier = checktotal % 6;//each line contains 6 records, when 6th records reached, change to newline

                            if (checktotal % 6 == 1)
                            {
                                NewLineHeader();   //call NewLineRecord function
                            }

                            string checkno;
                            checkno = checkdr["CHECK_NO"].ToString();
                            PutCheck(checkno); //call PutCheck Method

                            //
                            //string temp;
                            //temp = string.Format("{0,-3}", checkdr[("BANKCODE").ToString()]);
                            //transcount = transcount + temp.Substring(0, 3);

                            //transcount = transcount + checkdr["BANKCODE"];

                            //temp = string.Format("{0,-5}", checkdr[("BRANCHCODE").ToString()]);
                            //transcount = transcount + temp.Substring(0, 5);


                            //transcount = transcount + checkdr["BRANCHCODE"];

                            ////temp = string.Format("{0,-12}", checkdr[("ACCOUNTCODE").ToString()]);
                            ////transcount = transcount + temp.Substring(0, 12);



                            //transcount = transcount + string.Format("{0,-12}", checkdr["ACCOUNTCODE"]);
                            //transcount = transcount + checkdr["ACCOUNTCODE"].ToString().PadRight(12);

                            //transcount = transcount + string.Concat(Enumerable.Repeat("0", 25));
                            //transcount = transcount + string.Format("{0,-15}", "MULTI-LINE");
                            //transcount = transcount + "MULTI-LINE".PadRight(15);
                            //temp = string.Format("{0,-30}", checkdr["COMPANY"].ToString());
                            //transcount = transcount + temp.Substring(0, 30);

                            //transcount = transcount + string.Format("{0,-30}", "Multi-Line Fastener Supply Co.");
                            //transcount = transcount + new string(' ', 10);
                            //transcount = transcount + string.Format("{0,-19}", checkdr["check_no"]);
                            //transcount = transcount + "000129502"; //Multi-Line's Bank Code and Branch Code
                            //transcount = transcount + string.Format("{0, -12}", "1050371");
                            //transcount = transcount + new string(' ', 39);
                            //transcount = transcount + string.Concat(Enumerable.Repeat("0", 11));
                            
                            
                            if (checktotal % 6 == 0)
                            {
                                transcount = transcount + "\r";
                            }
                            //MessageBox.Show(transcount);
                        }
                        if (checktotal % 6 !=0)
                         {
                            transcount = transcount + new string(' ',(6 - checktotal % 6) * 240);
                            transcount = transcount + "\r";
                         }
                        //transcount = transcount + "\r";
                    }
                }

                //Generate trailer record
                //Data Connection and execute stored procedure sp_CheckInfo
                //string cs = ConfigurationManager.ConnectionStrings["Multiline_db"].ConnectionString;

                //using (SqlConnection conn = new SqlConnection(cs))
                //{
                //    conn.Open();
                //    SqlCommand cmd1 = new SqlCommand("sp_CheckInfo", conn);
                //    cmd1.CommandType = CommandType.StoredProcedure;
                //    cmd1.ExecuteNonQuery();
                //}

                string total_checkamt;
                string total_checknum;

                using (SqlConnection conn = new SqlConnection(cs))

                {
                    //get total check amount, and total number of checks.
                    conn.Open();
                    //SqlCommand cmd1 = new SqlCommand("Select sum(check_amt) from checkinfo", conn);
                    SqlCommand cmd1 = new SqlCommand("Select sum(check_amt), count(*) from checkinfo", conn);
                    cmd1.CommandType = CommandType.Text;
                    //cmd1.ExecuteNonQuery();
                    cmd1.ExecuteScalar();

                    using (SqlDataReader rdr = cmd1.ExecuteReader())

                    {
                        while (rdr.Read())
                        {
                            total_checkamt = rdr.GetValue(0).ToString();//total_checkamt equals to sum(check_amt)
                                                                        //        //total_checkamt = (float)rdr.GetValue(0);//total_checkamt equals to sum(check_amt)
                            total_checknum = rdr.GetValue(1).ToString();
                            //MessageBox.Show(total_checkamt.ToString());
                            //MessageBox.Show(total_checknum.ToString());

                            //}



                            //transcount = transcount + "\n";
                            //transcount = transcount + "\r"; //return carriage ????????????????????????????
                            recno = recno + 1;
                            transcount = transcount + "Z"; //Z
                            string recnoInString = recno.ToString().PadLeft(9, '0');
                            //transcount = transcount + string.Format("{0,-9}", recno);//Z000000015
                            transcount = transcount + recnoInString;
                            transcount = transcount + orgid;//Z000000015MLFSCLCR20
                            transcount = transcount + fileNo;//Z000000015MLFSCLCR200273
                            transcount = transcount + string.Concat(Enumerable.Repeat("0", 14));//Z000000015MLFSCLCR20027300000000000000
                            transcount = transcount + string.Concat(Enumerable.Repeat("0", 8));//Z000000015MLFSCLCR2002730000000000000000000000




                            transcount = transcount + (Double.Parse(total_checkamt) * 100).ToString("F0").PadLeft(14, '0');



                            transcount = transcount + (total_checknum.PadLeft(8, '0'));

                            transcount = transcount + new string(' ', 1396);

                            transcount = transcount + "\r";



                            //MessageBox.Show(transcount);
                            //MessageBox.Show(txtFileName.Text);

                            string fileName = @"e:\Data\epayment\" + txtFileName.Text + ".txt";
                            try
                            {
                                //check if file already exit, if yes, delete it
                                if (File.Exists(fileName))
                                {
                                    File.Delete(fileName);
                                }

                                // Create a new file     
                                using (StreamWriter sw = File.CreateText(fileName))
                                {
                                    sw.WriteLine(transcount);
                                    //sw.WriteLine(transcount);

                                }

                            }
                            catch (Exception Ex)
                            {
                                Console.WriteLine(Ex.ToString());
                            }
                        }



                    }
                    MessageBox.Show("File Successful Created");
                    checkInfo_flg = false;






                }



            }










        }









        private void btnCheckInfo_Click(object sender, EventArgs e)
        {

            //Data Connection and execute stored procedure sp_CheckInfo 
            string cs = ConfigurationManager.ConnectionStrings["Multiline_db"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_CheckInfo", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }

            string total_checkamt;
            string total_checknum;
            string first_checkno;
            string last_checkno;

            using (SqlConnection conn = new SqlConnection(cs))

            {
                //get total check amount, and total number of checks.
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select sum(check_amt), count(*) from checkinfo", conn);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                using (SqlDataReader rdr = cmd.ExecuteReader())

                {
                    while (rdr.Read())
                    {
                        total_checkamt = rdr.GetValue(0).ToString();//total_checkamt equals to sum(check_amt)
                        total_checknum = rdr.GetValue(1).ToString();//total_checknum equals to count(*)

                        //MessageBox.Show(total_checkamt);
                        //MessageBox.Show(total_checknum);




                        using (SqlConnection conn1 = new SqlConnection(cs))

                        {
                            //get first check number
                            conn1.Open();

                            SqlCommand ccmd = new SqlCommand("SELECT COUNT(*) from checkinfo", conn1);

                            int result = (int)ccmd.ExecuteScalar();

                            if (result == 0)
                            {
                                MessageBox.Show("There's no record in checkinfo");
                            }
                            else
                            {
                                SqlCommand cmd1 = new SqlCommand("Select top 1 check_no from checkinfo", conn1);
                                cmd1.CommandType = CommandType.Text;
                                cmd1.ExecuteNonQuery();

                                using (SqlDataReader rdr1 = cmd1.ExecuteReader())

                                {
                                    while (rdr1.Read())
                                    {
                                        first_checkno = rdr1.GetValue(0).ToString();//get the first check number

                                        //MessageBox.Show(first_checkno);




                                        using (SqlConnection conn2 = new SqlConnection(cs))

                                        {
                                            //get last check number
                                            conn2.Open();
                                            SqlCommand cmd2 = new SqlCommand("Select top 1 check_no from checkinfo order by check_no desc", conn2);
                                            cmd2.CommandType = CommandType.Text;
                                            cmd2.ExecuteNonQuery();

                                            using (SqlDataReader rdr2 = cmd2.ExecuteReader())

                                            {
                                                while (rdr2.Read())
                                                {
                                                    last_checkno = rdr2.GetValue(0).ToString();//get the last check number

                                                    //MessageBox.Show(last_checkno);
                                                    MessageBox.Show(string.Format("Total check amount is {0}, total check count is {1}, first check number is {2}, last  check number is {3}", total_checkamt, total_checknum, first_checkno, last_checkno));

                                                    checkInfo_flg = true;  //change checkInfo_flg from false to true
                                                }



                                            }

                                        }

                                    }
                                }
                            }
                        }
                    }

                }


            }





        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFileNum_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

