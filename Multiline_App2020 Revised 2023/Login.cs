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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        public static string pos = "";

        private void button1_Click(object sender, EventArgs e)
        {
            string ConnectionString = "Server=192.168.1.190,1435;User ID=Office; Password=BCpr001!;Initial Catalog=multiline_db";

            SqlConnection con = new SqlConnection(ConnectionString);

            string usn = textBox1.Text;

            string pd = textBox2.Text;

            string query1 = "select convert(varchar(100), Name) from [dbo].[TableEmployee] where convert(varchar(100), Name) = ('" + usn + "')";

            string query2 = "select convert(varchar(100), Password) from [dbo].[TableEmployee] where convert(varchar(100), Password) = ('" + pd + "')";

            string query3 = "select convert(varchar(100), Rights) from [dbo].[TableEmployee] where convert(varchar(100), Name) = ('" + usn + "')";

            con.Open();
            SqlCommand cidcmd = new SqlCommand(query1, con);
            string cid = (string)cidcmd.ExecuteScalar();
            con.Close();

            if (cid != null)
            {
                cid = cid.ToLower();
            }

            if (cid == usn.ToLower())
            {
                con.Open();
                SqlCommand cpdcmd = new SqlCommand(query2, con);
                string cpd = (string)cpdcmd.ExecuteScalar();
                con.Close();
                if (cpd == pd)
                {
                    MessageBox.Show("Login success!");
                    con.Open();
                    SqlCommand cpocmd = new SqlCommand(query3, con);
                    string cpo = (string)cpocmd.ExecuteScalar();
                    con.Close();
                    pos = cpo;
                    textBox1.Text = "";
                    textBox2.Text = "";
                    MainMenu mm = new MainMenu();
                    mm.Show();
                }
                else
                {
                    MessageBox.Show("Wrong Password! Please try again!");
                    textBox2.Text = "";
                }

            }
            else
            {
                MessageBox.Show("User id does not exist! Please try again!");
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }
    }
}
