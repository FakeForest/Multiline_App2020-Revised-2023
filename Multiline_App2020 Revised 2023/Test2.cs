using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Data.SqlClient;
using System.Configuration;


namespace Multiline_App2020_Revised_2023
{
    public partial class Test2 : Form

    {
        //declare variables
        DateTime today = DateTime.Today;
        string fileNo = "";
        bool checkInfo_flg = false;
        string orgid = "";
        string destcode = "";
        int recno;
        string transcount = "";
        int checktotal;
        float checkamount;

        SqlDataReader checkdr;



        public string getJulianDate(DateTime date)
        {
            string twoDigitYear = date.ToString("yy");
            int julian = Convert.ToInt32(twoDigitYear) * 1000 + date.DayOfYear;
            string julianResult = "0" + julian.ToString();
            return julianResult;

        }

        private void NewLineHeader()
        {
            int recNo = 0;
            string recNoInString = "";


            recNo = recNo + 1;
            recNoInString = recNo.ToString().PadLeft(recNo.ToString().Length + 9, '0');
            transcount = transcount + "C";
            transcount = transcount + recNoInString;

        }


        public string fill(string input, int i, string status)
        {

            string inputData = input.Trim();
            int len = inputData.Length;
            MessageBox.Show(len.ToString());
            if (len > i)
            {
                //len = i;
                inputData = inputData.Substring(0, i);
                MessageBox.Show(inputData);
                //inputData = string.Concat(Enumerable.Repeat(i - len, '0'));
                inputData = string.Concat(Enumerable.Repeat(5, 2));
                //MessageBox.Show(i.ToString() +len.ToString()+inputData);
                MessageBox.Show(i.ToString() + len.ToString());
            }
            if (status == "N")
            {

            }


            return inputData;

        }



        public Test2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //DateTime thisDate = Convert.ToDateTime(txtInput.Text);
            //string result = getJulianDate(thisDate);
            //MessageBox.Show(result);


            string output = fill((Convert.ToDouble(txtInput.Text) * 100).ToString(), 10, "N");
            MessageBox.Show(output);
        }

        private void Test2_Load(object sender, EventArgs e)
        {
            orgid = "MLFSCLCR20";
            destcode = "00120";

            checktotal = 0;
            checkamount = 0f;

            //NewLineHeader();
            //MessageBox.Show(transcount);

            recno = 1;
            transcount = "A";
            transcount = transcount + "000000001";//A000000001
            transcount = transcount + orgid; //A000000001MLFSCLCR20
            transcount = transcount + fileNo;//A000000001MLFSCLCR200244
            transcount = transcount + getJulianDate(today); //A000000001MLFSCLCR200244020211
            transcount = transcount + destcode; //A000000001MLFSCLCR20024402021100120,  total 35 charactors

            string space = new string(' ', 1429);

            transcount = transcount + space;// add 1429 space after the header
            transcount = transcount + Environment.NewLine; //return carriage

            MessageBox.Show(transcount);




        }
    }
}