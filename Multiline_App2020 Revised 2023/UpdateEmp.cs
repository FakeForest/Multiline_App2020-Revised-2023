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
    public partial class UpdateEmp : Form
    {
        public UpdateEmp()
        {
            InitializeComponent();
            label8.Text = EditEmp.pn;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ConnectionString = "Server=192.168.1.190,1435;User ID=Office; Password=BCpr001!;Initial Catalog=multiline_db";

            SqlConnection con = new SqlConnection(ConnectionString);

            string query5 = "UPDATE TableEmployee SET Name = ('" + textBox1.Text + "'), CardNumber = ('" + textBox2.Text + "'), UserID = ('" + textBox3.Text + "'), Password = ('" + textBox4.Text + "'), Rights = ('" + textBox5.Text + "') WHERE UserID = ('" + EditEmp.pn + "');";

            con.Open();
            SqlCommand cmd = new SqlCommand(query5, con);
            cmd.ExecuteNonQuery();
            con.Close();

            label6.Text = "";
            label7.Text = "";
            label8.Text = "";
            label9.Text = "";
            label10.Text = "";

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";

            MessageBox.Show("Update Complete!");
            this.Close();
        }

        private void UpdateEmp_Load(object sender, EventArgs e)
        {
            string ConnectionString = "Server=192.168.1.190,1435;User ID=Office; Password=BCpr001!;Initial Catalog=multiline_db";

            SqlConnection con = new SqlConnection(ConnectionString);

            string usd = label8.Text;

            string query1 = "select convert(varchar(100), Name) from [dbo].[TableEmployee] where convert(varchar(100), UserID) = ('" + usd + "')";
            string query2 = "select convert(varchar(100), CardNumber) from [dbo].[TableEmployee] where convert(varchar(100), UserID) = ('" + usd + "')";
            string query3 = "select convert(varchar(100), Password) from [dbo].[TableEmployee] where convert(varchar(100), UserID) = ('" + usd + "')";
            string query4 = "select convert(varchar(100), Rights) from [dbo].[TableEmployee] where convert(varchar(100), UserID) = ('" + usd + "')";

            con.Open();

            SqlCommand cmd1 = new SqlCommand(query1, con);
            string nam = (string)cmd1.ExecuteScalar();

            SqlCommand cmd2 = new SqlCommand(query2, con);
            string cdn = (string)cmd2.ExecuteScalar();

            SqlCommand cmd3 = new SqlCommand(query3, con);
            string pwd = (string)cmd3.ExecuteScalar();

            SqlCommand cmd4 = new SqlCommand(query4, con);
            string rts = (string)cmd4.ExecuteScalar();

            con.Close();

            label6.Text = "Old Name: " + nam;
            label7.Text = "Old Card #: " + cdn;
            label8.Text = "Old User ID: " + usd;
            label9.Text = "Old Password: " + pwd;
            label10.Text = "Old Rights: " + rts;

            textBox1.Text = nam;
            textBox2.Text = cdn;
            textBox3.Text = usd;
            textBox4.Text = pwd;
            textBox5.Text = rts;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RightsData sd = new RightsData();
            sd.ShowDialog();
            textBox5.Text = sd.result;
        }
    }
}
