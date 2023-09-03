using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multiline_App2020_Revised_2023
{
    public partial class prtlabelinfo : Form
    {
        public prtlabelinfo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int number2 = 0;
            int number3 = 0;
            int number4 = 0;
            if (textBox1.Text == "")
            {
                MessageBox.Show("ItemID can not as Null,Please input Itemid again!");
                textBox1.Focus();
                return;
            }
            else if (int.TryParse(textBox2.Text, out number2))
            {
                MessageBox.Show("Units of Package must be numeric,Please input again!");
                textBox2.Focus();
                return;
            }
            else if (int.TryParse(textBox3.Text, out number3))
            {
                MessageBox.Show("Qty to Print must be numeric,Please input again!");
                textBox3.Focus();
                return;
            }
            else if (int.TryParse(textBox4.Text, out number4))
            {
                MessageBox.Show("Total Package must be numeric,Please input again!");
                textBox4.Focus();
                return;
            }
            else if (textBox5.Text == null)
            {
                textBox5.Text = "";
            }

            string opidtxt = comboBox1.Text;

            string cs = ConfigurationManager.ConnectionStrings["Multiline_db"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                string query1 = "select  pl.prlkp_prod_id as itemid ,pl.prlkp_lang1_2_desc as size,pl.prlkp_lang1_upper_desc as DESCRIPTIO,pw.pw_bin_location1 as LOCATION1 ,pw.pw_bin_location2 as LOCATION2,pw.pw_bin_location3 as LOCATION3 from [MLAPPSVR\\STREAMLINE].sisl_data01.dbo.product_lookup as pl inner join [MLAPPSVR\\STREAMLINE].sisl_data01.dbo.prod_warehouse as pw on pl.prlkp_prod_id= pw.pw_prod_id where pl.prlkp_prod_id='"+ textBox1.Text +"'";

                SqlCommand cmd1 = new SqlCommand(query1, conn);
                cmd1.CommandType = CommandType.Text;
                cmd1.ExecuteNonQuery();
                string pbloctxt;
                string sizetxt;
                string desctxt;
                using (SqlDataReader rdr = cmd1.ExecuteReader())
                {
                    if (rdr.HasRows == false)
                    {
                        MessageBox.Show("Item  '" + textBox1 + "' not in our system,please refresh Data or add this item into our system");
                        textBox1.Focus();
                        return;
                    }
                    else 
                    {
                        pbloctxt = rdr["location1"].ToString().Trim() + " " + rdr["location2"].ToString().Trim() + " " + rdr["location3"].ToString().Trim();
                        sizetxt = rdr["size"].ToString() == "" ? "" : rdr["size"].ToString().Trim();
                        desctxt = rdr["descriptio"].ToString() == "" ? "" : rdr["descriptio"].ToString().Trim();
                    }

                }
                conn.Close();
            }
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                int u = Int32.Parse(textBox2.Text);
                int q = Int32.Parse(textBox3.Text);
                string totaltxt = (u * q).ToString();
                string query2 = "insert into labelprint_package (itemid, pkg, po_no, opid, qty, totalpkg, daydate, daytime) values ('"+ textBox1.Text +"', '"+ textBox2.Text +"', '"+ textBox5.Text +"', '"+ opidtxt +"', '"+ textBox3.Text +"', '"+ totaltxt +"', '"+ DateTime.Now.ToString("MM / dd / yyyy") + "', '"+ DateTime.Now.ToString("hh: mm:ss tt") +"')";
                SqlCommand cmd = new SqlCommand(query2, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }

            string printdata;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["Multiline_db"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();

                string query1 = "Select user_ini from user_info";

                SqlCommand cmd1 = new SqlCommand(query1, conn);
                cmd1.CommandType = CommandType.Text;
                cmd1.ExecuteNonQuery();
                using (SqlDataReader rdr = cmd1.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        comboBox1.Items.Add(rdr[0]);
                    }
                }
                conn.Close();
            }
        }
    }
}
