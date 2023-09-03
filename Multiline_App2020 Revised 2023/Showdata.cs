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
    public partial class Showdata : Form
    {
        public Showdata()
        {
            InitializeComponent();
        }

        public string result { get; set; }

        public String option = "";

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            result = dataGridView1.CurrentRow.Cells[2].Value.ToString();

            this.DialogResult = DialogResult.OK;

            option = "";
        }

        private void Showdata_Load(object sender, EventArgs e)
        {
            option = MainMenu.opt;

            string ConnectionString = "Server=192.168.1.190,1435;User ID=Office; Password=BCpr001!;Initial Catalog=multiline_db";

            SqlConnection con = new SqlConnection(ConnectionString);

            if (option == "del")
            {
                try
                {

                    {
                        using (SqlCommand cmd = new SqlCommand("select * from TableEmployee", con))
                        {
                            cmd.CommandType = CommandType.Text;
                            con.Open();
                            DataTable dt = new DataTable();
                            dt.Load(cmd.ExecuteReader());
                            dataGridView1.DataSource = dt;
                            con.Close();

                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error info:" + ex.Message);
                }

                dataGridView1.Columns[0].Width = 80;

            }

            if (option == "upt")
            {
                try
                {

                    {
                        using (SqlCommand cmd = new SqlCommand("select * from TableEmployee", con))
                        {
                            cmd.CommandType = CommandType.Text;
                            con.Open();
                            DataTable dt = new DataTable();
                            dt.Load(cmd.ExecuteReader());
                            dataGridView1.DataSource = dt;
                            con.Close();

                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error info:" + ex.Message);
                }

                dataGridView1.Columns[0].Width = 80;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
