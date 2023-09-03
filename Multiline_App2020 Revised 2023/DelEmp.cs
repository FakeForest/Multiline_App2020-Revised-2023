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

namespace Multiline_App2020_Revised_2023
{
    public partial class DelEmp : Form
    {
        public DelEmp()
        {
            InitializeComponent();
        }

        public static string yn = "";

        private void button1_Click(object sender, EventArgs e)
        {
            string ConnectionString = "Server=192.168.1.190,1435;User ID=Office; Password=BCpr001!;Initial Catalog=multiline_db";

            SqlConnection con = new SqlConnection(ConnectionString);

            string prn = textBox1.Text;

            string query1 = "select convert(varchar(100), UserID) from [dbo].[TableEmployee] where convert(varchar(100), UserID) = ('" + prn + "')";

            string query2 = "DELETE FROM TableEmployee WHERE UserID = ('" + prn + "')";

            con.Open();
            SqlCommand cidcmd = new SqlCommand(query1, con);
            string cid = (string)cidcmd.ExecuteScalar();
            con.Close();

            if (cid != prn)
            {
                MessageBox.Show("Employee Does Not Exist!");
                textBox1.Text = "";
            }
            else
            {
                DelConfirm dc = new DelConfirm();
                dc.ShowDialog();
                yn = DelConfirm.yon;
                if (yn == "yes")
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query2, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    textBox1.Text = "";
                    MessageBox.Show("Succuessfully Deleted!");
                    this.Close();
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Showdata sd = new Showdata();
            sd.ShowDialog();
            textBox1.Text = sd.result;
        }
    }
}
