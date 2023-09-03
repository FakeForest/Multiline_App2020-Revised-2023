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
    public partial class RightsEdit : Form
    {
        public RightsEdit()
        {
            InitializeComponent();
        }

        public static string res = "";

        private void button1_Click(object sender, EventArgs e)
        {
            RightsData rd = new RightsData();
            rd.ShowDialog();
            textBox1.Text = rd.result;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string ConnectionString = "Server=192.168.1.190,1435;User ID=Office; Password=BCpr001!;Initial Catalog=multiline_db";

            SqlConnection con = new SqlConnection(ConnectionString);

            string query1 = "select convert(varchar(100), Groups) from [dbo].[UserGroups] where convert(varchar(100), Groups) = ('" + textBox1.Text + "')";
            
            string query2 = "insert into UserGroups (Groups) values ('" + textBox1.Text + "')";

            con.Open();
            SqlCommand cncmd = new SqlCommand(query1, con);
            string cn = (string)cncmd.ExecuteScalar();
            con.Close();

            if (cn == textBox1.Text)
            {
                MessageBox.Show("Already Exist!");
                textBox1.Text = "";
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query2, con);
                cmd.ExecuteNonQuery();
                con.Close();
                textBox1.Text = "";
                MessageBox.Show("Succuessfully Added!");
                this.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string ConnectionString = "Server=192.168.1.190,1435;User ID=Office; Password=BCpr001!;Initial Catalog=multiline_db";

            SqlConnection con = new SqlConnection(ConnectionString);

            string scn = textBox1.Text;

            string query1 = "select convert(varchar(100), Groups) from [dbo].[UserGroups] where convert(varchar(100), Groups) = ('" + scn + "')";

            string query2 = "DELETE FROM Sections WHERE Section = ('" + scn + "')";

            con.Open();
            SqlCommand cidcmd = new SqlCommand(query1, con);
            string cid = (string)cidcmd.ExecuteScalar();
            con.Close();

            if (cid != scn)
            {
                MessageBox.Show("Does Not Exist!");
                textBox1.Text = "";
            }
            else
            {
                DelConfirm dc = new DelConfirm();
                dc.ShowDialog();
                res = DelConfirm.yon;
                if (res == "yes")
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

        private void RightsEdit_Load(object sender, EventArgs e)
        {
            button3.Enabled = false;
        }
    }
}
