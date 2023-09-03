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
    public partial class UpdateTimeStatus : Form
    {
        public UpdateTimeStatus()
        {
            InitializeComponent();
        }

        public static string iot = "";
        public static string t = "";
        public static string i = "in*";
        public static string o = "out*";

        private void button2_Click(object sender, EventArgs e)
        {
            //searchin
            string ConnectionString = "Server=192.168.1.190,1435;User ID=Office; Password=BCpr001!;Initial Catalog=multiline_db";
            SqlConnection con = new SqlConnection(ConnectionString);
            iot = "in";
            using (SqlCommand cmdi = new SqlCommand("select CardNumber, Name, statusin, Timein from TimeReport where CardNumber = ('" + textBox2.Text + "') order by Timein desc", con))
            {
                cmdi.CommandType = CommandType.Text;
                con.Open();
                DataTable dt = new DataTable();
                dt.Load(cmdi.ExecuteReader());
                dataGridView1.DataSource = dt;
                con.Close();

            }
            dataGridView1.Columns[0].Width = 80;
            button1.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //searchout
            string ConnectionString = "Server=192.168.1.190,1435;User ID=Office; Password=BCpr001!;Initial Catalog=multiline_db";
            SqlConnection con = new SqlConnection(ConnectionString);
            iot = "out";
            using (SqlCommand cmdo = new SqlCommand("select CardNumber, Name, statusout, Timeout from TimeReport where CardNumber = ('"+ textBox2.Text +"') order by Timeout desc", con))
            {
                cmdo.CommandType = CommandType.Text;
                con.Open();
                DataTable dt = new DataTable();
                dt.Load(cmdo.ExecuteReader());
                dataGridView1.DataSource = dt;
                con.Close();

            }
            dataGridView1.Columns[0].Width = 80;
            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //update
            string ConnectionString = "Server=192.168.1.190,1435;User ID=Office; Password=BCpr001!;Initial Catalog=multiline_db";
            SqlConnection con = new SqlConnection(ConnectionString);
            string query1 = "update TimeReport set Timein = ('"+ textBox1.Text +"'), statusin = ('"+ i +"') where Timein = ('"+ t +"')";
            string query2 = "update TimeReport set Timeout = ('" + textBox1.Text + "'), statusout = ('" + o + "') where Timeout = ('" + t + "')";
            if (iot == "in")
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand(query1, con);
                cmd1.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Timein and status successfully updated!");
            }
            else if (iot == "out")
            {
                con.Open();
                SqlCommand cmd2 = new SqlCommand(query2, con);
                cmd2.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Timeout and status successfully updated!");
            }
            else
                MessageBox.Show("Please choose the type of time you want to change!");
            iot = "";
            t = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //cancel
            iot = "";
            t = "";
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            t = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void UpdateTimeStatus_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
        }
    }
}
