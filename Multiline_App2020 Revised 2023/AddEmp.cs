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
    public partial class AddEmp : Form
    {
        public AddEmp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ConnectionString = "Server=192.168.1.190,1435;User ID=Office; Password=BCpr001!;Initial Catalog=multiline_db";

            SqlConnection con = new SqlConnection(ConnectionString);

            string nam = textBox1.Text;

            string cdn = textBox2.Text;

            string usd = textBox3.Text;

            string pwd = textBox4.Text;

            string rts = textBox5.Text;

            string query1 = "select convert(varchar(100), UserID) from [dbo].[TableEmployee] where convert(varchar(100), UserID) = ('" + usd + "')";

            string query2 = "insert into TableEmployee (Name, CardNumber, UserID, Password, Rights) values ('" + nam + "', '" + cdn + "', '" + usd + "', '" + pwd + "', '" + rts + "')";

            con.Open();
            SqlCommand cncmd = new SqlCommand(query1, con);
            string cn = (string)cncmd.ExecuteScalar();
            con.Close();

            if (cn == usd)
            {
                MessageBox.Show("Already Exist!");
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query2, con);
                cmd.ExecuteNonQuery();
                con.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                MessageBox.Show("Succuessfully Added!");
                this.Close();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RightsData sd = new RightsData();
            sd.ShowDialog();
            textBox5.Text = sd.result;
        }
    }
}
