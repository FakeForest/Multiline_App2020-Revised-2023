using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using System.Drawing.Printing;

namespace Multiline_App2020_Revised_2023
{
    public partial class orderprint : Form
    {
        public orderprint()
        {
            InitializeComponent();
        }

        public DataTable dt;

        public static class MyPrinters
        {
            [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern bool SetDefaultPrinter(string Name);
        }

        private void orderprint_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;

            string cs = ConfigurationManager.ConnectionStrings["Multiline_db"].ConnectionString;

            string query5 = "select count(1) from [MLAPPSVR\\STREAMLINE].sisl_data01.dbo.so_ordrev_details where srd_order_num = ('" + textBox1.Text +"')";

            string query6 = "select count(1) from [MLAPPSVR\\STREAMLINE].sisl_data01.dbo.quote_details where qd_quote_num = ('" + textBox1.Text +"')";

            string query0 = "IF OBJECT_ID ('dbo.OrderPrintTemp', 'U') IS NOT NULL TRUNCATE TABLE dbo.OrderPrintTemp";

            string query1 = "insert into OrderPrintTemp(PartNumber, Size, Descrb)" + 
                           " select srd_prod_id, prlkp_lang1_2_desc, prlkp_lang1_1_desc" +
                           " from [MLAPPSVR\\STREAMLINE].sisl_data01.dbo.so_ordrev_details" +
                           " inner join [MLAPPSVR\\STREAMLINE].sisl_data01.dbo.product_lookup" +
                           " on srd_prod_id = prlkp_prod_id" +
                           " where srd_order_num = ('" + textBox1.Text +"')";

            string query2 = "insert into OrderPrintTemp(PartNumber, Size, Descrb)" +
                           " select qd_prod_id, prlkp_lang1_2_desc, prlkp_lang1_1_desc" +
                           " from [MLAPPSVR\\STREAMLINE].sisl_data01.dbo.quote_details" +
                           " inner join [MLAPPSVR\\STREAMLINE].sisl_data01.dbo.product_lookup" +
                           " on qd_prod_id = prlkp_prod_id" +
                           " where qd_quote_num = ('"+ textBox1.Text +"')";

            string query3 = "select * from OrderPrintTemp";

            string query4 = "update OrderPrintTemp" +
                            " set PrintQty = ('"+ "1" +"')";

            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();

                SqlCommand cmd0 = new SqlCommand(query0, conn);
                cmd0.ExecuteNonQuery();

                if (radioButton1.Checked == true && radioButton2.Checked == false && radioButton3.Checked == false && radioButton4.Checked == false)
                {
                    SqlCommand cmd5 = new SqlCommand(query5, conn);
                    int reso = (int)cmd5.ExecuteScalar();
                    if (reso == 0)
                    {
                        MessageBox.Show("Id does not exist, please try again!");
                        return;
                    }
                    SqlCommand cmd1 = new SqlCommand(query1, conn);
                    cmd1.ExecuteNonQuery();
                    SqlCommand cmd4 = new SqlCommand(query4, conn);
                    cmd4.ExecuteNonQuery();
                    SqlCommand cmd3 = new SqlCommand(query3, conn);
                    cmd3.CommandType = CommandType.Text;
                    dt = new DataTable();
                    dt.Load(cmd3.ExecuteReader());
                    dataGridView1.DataSource = dt;
                }
                else if (radioButton2.Checked == true && radioButton1.Checked == false && radioButton3.Checked == false && radioButton4.Checked == false)
                {
                    SqlCommand cmd6 = new SqlCommand(query6, conn);
                    int resq = (int)cmd6.ExecuteScalar();
                    if (resq == 0)
                    {
                        MessageBox.Show("Id does not exist, please try again!");
                        return;
                    }
                    SqlCommand cmd1 = new SqlCommand(query2, conn);
                    cmd1.ExecuteNonQuery();
                    SqlCommand cmd4 = new SqlCommand(query4, conn);
                    cmd4.ExecuteNonQuery();
                    SqlCommand cmd3 = new SqlCommand(query3, conn);
                    cmd3.CommandType = CommandType.Text;
                    dt = new DataTable();
                    dt.Load(cmd3.ExecuteReader());
                    dataGridView1.DataSource = dt;
                }
                else 
                {
                    MessageBox.Show("Please choose only one type!");
                    button2.Enabled = false;
                    return;
                }

                conn.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ChangePrintQty cq = new ChangePrintQty();
            cq.ShowDialog();
            dataGridView1.CurrentRow.Cells[0].Value = cq.qty;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string pname = chooseprter.pname;
            MyPrinters.SetDefaultPrinter(pname);
            PrintDocument pd = new PrintDocument();
            int index = 0, count = 0;

            List<int> list1 = new List<int>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[0].Value != null && dataGridView1.Rows[i].Cells[0].Value.ToString() != "0")
                {
                    for (int j = 0; j < int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString()); j++)
                    {
                        list1.Add(i);
                    }
                }
            }

            pd.BeginPrint += (s, ev) =>
            {
                // find page count from form label
                count = list1.Count;
            };
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{

            //}

            pd.PrintPage += (s, ev) =>
            {
                string desc1 = "";
                string desc2 = "";

                string dqty = dataGridView1.Rows[list1[index]].Cells[0].Value.ToString();

                string id = dataGridView1.Rows[list1[index]].Cells[1].Value.ToString();

                string size = dataGridView1.Rows[list1[index]].Cells[2].Value.ToString();

                string desc = dataGridView1.Rows[list1[index]].Cells[3].Value.ToString();
                
                string[] descar = desc.Split(' ');

                int fh = descar.Length / 2;
                for (int i = 0; i < fh; i++)
                {
                    desc1 += descar[i];
                }
                for (int j = fh; j < descar.Length; j++)
                {
                    desc2 += descar[j];
                }
                
                // for each page
                index++;
                if (radioButton3.Checked == true && radioButton4.Checked == false && radioButton1.Checked == false && radioButton2.Checked == false)
                {
                    BarcodeWriter barcode = new BarcodeWriter()
                    {
                        Format = BarcodeFormat.CODE_128
                    };
                    //pictureBox1.Image = barcode.Write(id);
                    Image img = barcode.Write(id);

                    ev.Graphics.DrawString("PART NO", new Font("Times New Roman", 7, FontStyle.Bold), Brushes.Black, new PointF(7, 60));
                    var stringsize1 = ev.Graphics.MeasureString(id, new Font("Franklin Gothic Medium", 20, FontStyle.Bold));
                    ev.Graphics.DrawString(id, new Font("Franklin Gothic Medium", 20, FontStyle.Bold), Brushes.Black, new PointF((250 - stringsize1.Width) / 2.0f, 60));
                    //ev.Graphics.DrawString(textBox2.Text, new Font("Times New Roman", 18, FontStyle.Bold), Brushes.Black, new PointF(40, 60));
                    ev.Graphics.DrawImage(img, 40, 90, 180, 30);
                    ev.Graphics.DrawString("SIZE:---------------------------------------------------------", new Font("Times New Roman", 7, FontStyle.Bold), Brushes.Black, new PointF(10, 110));
                    var stringsize2 = ev.Graphics.MeasureString(size, new Font("Franklin Gothic Medium", 16, FontStyle.Bold));
                    ev.Graphics.DrawString(size, new Font("Franklin Gothic Medium", 16, FontStyle.Bold), Brushes.Black, new PointF((250 - stringsize2.Width) / 2.0f, 125));
                    //ev.Graphics.DrawString("M12X1.25X35", new Font("Times New Roman", 18, FontStyle.Bold), Brushes.Black, new PointF(40, 115));
                    ev.Graphics.DrawString("DESC:--------------------------------------------------------", new Font("Times New Roman", 7, FontStyle.Bold), Brushes.Black, new PointF(10, 145));
                    var stringsize3 = ev.Graphics.MeasureString(desc1, new Font("Franklin Gothic Medium", 15, FontStyle.Bold));
                    ev.Graphics.DrawString(desc1, new Font("Franklin Gothic Medium", 15, FontStyle.Bold), Brushes.Black, new PointF((250 - stringsize3.Width) / 2.0f, 155));
                    //ev.Graphics.DrawString("METRIC JIS FLANGE", new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Black, new PointF(10, 145));
                    var stringsize4 = ev.Graphics.MeasureString(desc2, new Font("Franklin Gothic Medium", 15, FontStyle.Bold));
                    ev.Graphics.DrawString(desc2, new Font("Franklin Gothic Medium", 15, FontStyle.Bold), Brushes.Black, new PointF((250 - stringsize4.Width) / 2.0f, 180));
                    //ev.Graphics.DrawString("BOLTS 8.8 ZI", new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Black, new PointF(40, 165));
                }
                else if (radioButton4.Checked == true && radioButton3.Checked == false && radioButton1.Checked == false && radioButton2.Checked == false)
                {
                    BarcodeWriter barcode = new BarcodeWriter()
                    {
                        Format = BarcodeFormat.CODE_128
                    };
                    Image img = barcode.Write(id);

                    var stringsize1 = ev.Graphics.MeasureString(id, new Font("Franklin Gothic Medium", 18));
                    ev.Graphics.DrawString(id, new Font("Franklin Gothic Medium", 18), Brushes.Black, new PointF((300 - stringsize1.Width) / 2.0f, 10));
                    ev.Graphics.DrawImage(img, 50, 35, 200, 25);
                    var stringsize2 = ev.Graphics.MeasureString(size, new Font("Franklin Gothic Medium", 12, FontStyle.Bold));
                    ev.Graphics.DrawString(size, new Font("Franklin Gothic Medium", 12, FontStyle.Bold), Brushes.Black, new PointF((300 - stringsize2.Width) / 2.0f, 60));
                    var stringsize3 = ev.Graphics.MeasureString(desc, new Font("Franklin Gothic Medium", 11, FontStyle.Bold));
                    ev.Graphics.DrawString(desc, new Font("Franklin Gothic Medium", 11, FontStyle.Bold), Brushes.Black, new PointF((300 - stringsize3.Width) / 2.0f, 78));
                }
                else
                {
                    MessageBox.Show("Please choose only one label format to continue!");
                    return;
                }


                // check for final page
                ev.HasMorePages = index < count;

            };

            pd.EndPrint += (s, ev) =>
            {
                // reset count and index
                index = 0;
                count = 0;
            };
            if (radioButton3.Checked == true && radioButton4.Checked == false)
            {
                PaperSize paper = new PaperSize("MyCustomSize", 250, 250);
                paper.RawKind = (int)PaperKind.Custom;
                // set paper size
                pd.DefaultPageSettings.PaperSize = paper;
                // set paper margins appropriately
                //pd.DefaultPageSettings.Margins = new Margins(10, 10, 10, 10);

                // call up the print preview dialog to see results
                PrintPreviewDialog dlg = new PrintPreviewDialog();

                dlg.Document = pd;
                dlg.ShowDialog();
            }
            else if (radioButton4.Checked == true && radioButton3.Checked == false)
            {
                PaperSize paper = new PaperSize("MyCustomSize", 300, 100);
                paper.RawKind = (int)PaperKind.Custom;
                // set paper size
                pd.DefaultPageSettings.PaperSize = paper;
                // set paper margins appropriately
                //pd.DefaultPageSettings.Margins = new Margins(10, 10, 10, 10);

                // call up the print preview dialog to see results
                PrintPreviewDialog dlg = new PrintPreviewDialog();

                dlg.Document = pd;
                dlg.ShowDialog();
            }
        }
    }
}
